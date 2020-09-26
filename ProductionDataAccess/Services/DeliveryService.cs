using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxed.Mapping;
using DBmaker.Data;
using DBmaker.Models;
using ProductionDataAccess.Mappers;
using ProductionDataAccess.Models;

namespace ProductionDataAccess.Services
{
    public class DeliveryService
    {

        ProductionContext ctx;
       
        public DeliveryService()
        {
            ctx = new ProductionContext();
        }

        public List<EmployeeDto> EmployeeList()
        {
            var result = ctx.Employee.Select( d => new EmployeeDto
            {
                EmployeeID = d.employeeID,
                EmployeeName = d.firstname + ' ' + d.lastname

            }).ToList();

            return result;
        }

        public DeliveryDto New(int jobID,int empid)
        {
            string name = ctx.Employee.Find(empid).firstname + ' ' + ctx.Employee.Find(empid).lastname;
            JobSite jobsite  = ctx.JobSite.Where(p => p.JobID == jobID).FirstOrDefault() ;

            Delivery newEntity = new Delivery
            {
                JobID = jobID,
                JobSiteID = jobsite.JobSiteID,
                DeliveryDate = DateTime.Now,
                EmployeeID = empid   
            };

            ctx.Delivery.Add(newEntity);
            ctx.SaveChanges();

            DeliveryDto dto = new DeliveryDto
            {
                JobID = newEntity.JobID,
                DeliveryDate = newEntity.DeliveryDate,
                EmployeeID = newEntity.EmployeeID,
                DriverName = name,
                JobSiteID = newEntity.JobSiteID
                
            };

            return dto;
        }


        public List<DeliveryDto> JobDeliveries(int jobid)
        {
            var result = ctx.Delivery.Where(j => j.JobID == jobid).OrderByDescending(r => r.DeliveryID).Select(d => new DeliveryDto
            {
                DeliveryDate = d.DeliveryDate,
                DeliveryID = d.DeliveryID,
                DriverName = d.Employee.firstname + ' ' + d.Employee.lastname,
                EmployeeID = d.EmployeeID,
                JobID = d.JobID,
                JobSiteID = d.JobSiteID

            }).ToList();

            return result;
           
        }

        public void CreateOrUpdateDelivery(DeliveryDto deliveryDTO)
        {
            var delivery = ctx.Delivery.FirstOrDefault(d => d.DeliveryID == deliveryDTO.DeliveryID);
            if (delivery == null)
            {
                delivery = new Delivery();
                ctx.Delivery.Add(delivery);
            }

            // Map Properties
            delivery.DeliveryDate = deliveryDTO.DeliveryDate.GetValueOrDefault();
            delivery.EmployeeID = deliveryDTO.EmployeeID.GetValueOrDefault();
            delivery.JobID = deliveryDTO.JobID.GetValueOrDefault();
            delivery.JobSiteID = deliveryDTO.JobSiteID;
            delivery.ItemCount = delivery.ItemCount;

            // remove deleted deliveryItems -
            delivery.DeliveryItem
                    .Where(d => !deliveryDTO.DeliveryItemDto.Any(DeliveryItemDto => DeliveryItemDto.DeliveryItemID == d.DeliveryItemID)).ToList()
                    .ForEach(deleted => ctx.DeliveryItem.Remove(deleted));

            //update of add new delivery items -

            deliveryDTO.DeliveryItemDto.ToList().ForEach(deliveryDto =>
            {
                var detail = delivery.DeliveryItem.FirstOrDefault(d => d.DeliveryItemID == deliveryDto.DeliveryItemID);
                if (detail == null)
                {
                    detail = new DeliveryItem();
                    delivery.DeliveryItem.Add(detail);
                }

                detail.Delivered = deliveryDto.Delivered;
                detail.DeliveryID = deliveryDto.DeliveryID;
                detail.Description = deliveryDto.Description;
                detail.ItemDescription = deliveryDto.ItemDescription;
                detail.Onboard = deliveryDto.Onboard;
                detail.PartID = deliveryDto.PartID.GetValueOrDefault();
                detail.ProductID = deliveryDto.ProductID.GetValueOrDefault();
                detail.Qnty = deliveryDto.Qnty.GetValueOrDefault();
                detail.SubAssemblyID = deliveryDto.SubAssemblyID.GetValueOrDefault();

            });

            ctx.SaveChanges();

        }
    }
}
