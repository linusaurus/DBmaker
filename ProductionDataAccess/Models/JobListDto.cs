using System;
using System.Collections.Generic;
using System.Text;
using DBmaker.Models;
using DBmaker.Data;

namespace ProductionDataAccess
{
    public class JobListDto
    {
        public int JobID { get; set; }
        public string JobName { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
