using Boxed.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using DBmaker.Data;
using DBmaker.Models;
using ProductionDataAccess.Models;

namespace ProductionDataAccess.Mappers
{
    public class DeliveryMapper : IMapper<Delivery, DeliveryDto>
    {

        private readonly IMapper<DeliveryItem, DeliveryItemDto> deliveryItemMapper = new DeliveryItemMapper();
        
        public void Map(Delivery source, DeliveryDto destination)
        {
            destination.DeliveryID = source.DeliveryID;
            destination.DeliveryDate = source.DeliveryDate.GetValueOrDefault();
            destination.EmployeeID = source.EmployeeID.GetValueOrDefault();
            destination.JobID = source.JobID.GetValueOrDefault();
            destination.JobName = source.Job.JobName;
            destination.DriverName = source.Employee.firstname + ' ' + source.Employee.lastname;
            destination.Address = source.JobSite.StreetAddress;
            destination.City = source.JobSite.City;
            destination.JobSiteID = source.JobSiteID;
            destination.State = source.JobSite.State;
            destination.Zip = source.JobSite.Zip;
            

            destination.DeliveryItemDto = deliveryItemMapper.MapList(source.DeliveryItem);
    
        }

       
    }

    public class DeliveryItemMapper : IMapper<DeliveryItem, DeliveryItemDto>
    {
        public void Map(DeliveryItem source, DeliveryItemDto destination)
        {
            destination.DeliveryItemID = source.DeliveryItemID;
            destination.DeliveryID = source.DeliveryID.GetValueOrDefault();
            destination.Description = source.Description;
            destination.ItemDescription = source.ItemDescription;
            destination.ItemReference = source.ItemReference.GetValueOrDefault();
            destination.ItemReferenceType = source.ItemReferenceType;
            destination.PartID = source.PartID.GetValueOrDefault();
            destination.ProductID = source.ProductID.GetValueOrDefault();
            destination.Qnty = source.Qnty.GetValueOrDefault();
            destination.SubAssemblyID = source.SubAssemblyID;
            destination.Onboard = source.Onboard.GetValueOrDefault();
            destination.Delivered = source.Delivered.GetValueOrDefault();

        }
    }
}
