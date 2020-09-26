using Boxed.Mapping;
using DBmaker.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ProductionDataAccess.Mappers
{
    public class JobMapper : IMapper<Job, JobListDto>
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
