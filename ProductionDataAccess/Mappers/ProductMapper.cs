using System;
using System.Collections.Generic;
using System.Text;
using Boxed;
using Boxed.Mapping;
using DBmaker.Models;

namespace ProductionDataAccess.Mappers
{
    public class ProductMapper : IMapper<Product, ProductDto>
    {
        private readonly IMapper<SubAssembly, SubAssemblyDTO> subAssemblyMapper = new SubAssemblyMapper();
        
        public void Map(Product source, ProductDto destination)
        {
            destination.ProductID = source.ProductID;
            destination.ProductionDate = source.ProductionDate.GetValueOrDefault();
            destination.RoomName = source.RoomName;
            destination.W = source.W.GetValueOrDefault();
            destination.H = source.H.GetValueOrDefault();
            destination.D = source.D.GetValueOrDefault();
            destination.ArchDescription = source.ArchDescription;
            destination.Delivered = source.Delivered.GetValueOrDefault();
            destination.UnitID = source.UnitID.GetValueOrDefault();
            destination.UnitName = source.UnitName;
            destination.DeliveryDate = source.DeliveredDate.GetValueOrDefault();
            destination.JobID = source.JobID.GetValueOrDefault();
            destination.NIC = source.NIC.GetValueOrDefault();
            destination.SubAssemblies = subAssemblyMapper.MapList(source.SubAssembly);
        }

    }

    public class SubAssemblyMapper : IMapper<SubAssembly, SubAssemblyDTO>
    {
        public void Map(SubAssembly source, SubAssemblyDTO destination)
        {
            destination.SubAssemblyID = source.SubAssemblyID;
            destination.ProductID = source.ProductID.GetValueOrDefault();
            destination.SubAssemblyName = source.SubAssemblyName;
            destination.W = source.W.GetValueOrDefault();
            destination.H = source.H.GetValueOrDefault();
            destination.D = source.D.GetValueOrDefault();
            destination.GlassPartID = source.GlassPartID.GetValueOrDefault();
            destination.MakeFile = source.MakeFile;
            destination.CPD_ID = source.CPD_id.GetValueOrDefault();
        }
    }

    public class JobProductMapper : IMapper<Job, JobListDto>
    {
        private readonly IMapper<Product, ProductDto> productMapper = new ProductMapper();
        public void Map(Job source, JobListDto destination)
        {
            destination.JobID = source.JobID;
            destination.JobName = source.JobName;
            destination.Products = productMapper.MapList(source.Product);
        }
    }



}
