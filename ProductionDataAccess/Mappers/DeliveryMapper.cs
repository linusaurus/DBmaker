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
            destination.State = source.JobSite.State;
            destination.Zip = source.JobSite.Zip;
            
        }
    }
}
