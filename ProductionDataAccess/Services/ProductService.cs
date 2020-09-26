using System;
using System.Collections.Generic;
using System.Text;
using DBmaker.Data;
using DBmaker.Models;


namespace ProductionDataAccess.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Boxed.Mapping;
    using Microsoft.EntityFrameworkCore;
    using ProductionDataAccess.Mappers;

    public class ProductService
        {
            private readonly ProductionContext ctx;
            private readonly ProductMapper productMapper = new ProductMapper();
        private readonly JobMapper jobMapper = new JobMapper();

            public ProductService()
            {
            ctx = new ProductionContext();

            }

            public List<Product> GetJobUnits(int jobID)
            {
                return ctx.Product.Include(p => p.SubAssembly).Where(j => j.JobID == jobID).ToList();
            }

        public JobListDto GetProducts(int jobID)
        {

                Job job = ctx.Job.Include(p => p.Product).
                                   ThenInclude(s => s.SubAssembly)
                                   .Where(j => j.JobID == jobID).FirstOrDefault();
            
                JobListDto dto = new JobListDto();
                jobMapper.Map(job, dto);

                return dto;

            }
            public Product AddUnit(Product unit)
            {
                ctx.Add(unit);
                ctx.SaveChanges();
                return unit;
            }

            public void AddOrUpdate(List<ProductDto> productDTOList)
            {
                var productList = ctx.Product.Include(s => s.SubAssembly).Where(o => o.JobID == productDTOList[0].JobID).ToList();

                //remove deleted products -
                productList
                    .Where(d => !productDTOList.Any(dto => dto.ProductID == d.ProductID)).ToList()
                    .ForEach(deleted => ctx.Product.Remove(deleted));

                productDTOList.ToList().ForEach(ad =>
                {
                    var product = ctx.Product.Include(s => s.SubAssembly).FirstOrDefault(r => r.ProductID == ad.ProductID);
                    if (product == null)
                    {
                        product = new Product();
                        ctx.Product.Add(product);
                    }

                    product.JobID = ad.JobID;
                    product.ArchDescription = ad.ArchDescription;
                    product.UnitID = ad.UnitID;
                    product.UnitName = ad.UnitName;
                    product.RoomName = ad.RoomName;
                    product.ProductionDate = ad.ProductionDate;
                    product.W = ad.W.GetValueOrDefault();
                    product.H = ad.H.GetValueOrDefault();
                    product.D = ad.D.GetValueOrDefault();
                    product.Delivered = ad.Delivered.GetValueOrDefault();
                    product.DeliveredDate = ad.DeliveryDate;
                    product.Make = ad.Make;
                    product.NIC = ad.NIC;

                    ////remove deleted subassemblies -
                    //product.SubAssembly
                    //    .Where(d => !ad.SubAssemblies.Any(SubAssemblyDTO => SubAssemblyDTO.SubAssemblyID == d.SubAssemblyID)).ToList()
                    //    .ForEach(deleted => ctx.SubAssembly.Remove(deleted));

                    ////update or add SubAssembly --
                    //ad.SubAssemblies.ToList().ForEach(od =>
                    //{
                    //    var subassembly = product.SubAssembly.FirstOrDefault(r => r.SubAssemblyID == od.SubAssemblyID);
                    //    if (subassembly == null)
                    //    {
                    //        subassembly = new SubAssembly();
                    //        product.SubAssembly.Add(subassembly);
                    //    }
                    //    subassembly.ProductID = od.ProductID;
                    //    subassembly.SubAssemblyName = od.SubAssemblyName;
                    //    subassembly.MakeFile = od.MakeFile;
                    //    subassembly.W = od.W;
                    //    subassembly.H = od.H;
                    //    subassembly.D = od.D;
                    //    subassembly.GlassPartID = od.GlassPartID;
                    //    subassembly.CPD_id = od.CPD_ID;
                    //});


                });



                ctx.SaveChanges();
            }

        }
    }


