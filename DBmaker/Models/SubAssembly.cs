using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class SubAssembly
    {
        public int SubAssemblyID { get; set; }
        public int? ProductID { get; set; }
        public string SubAssemblyName { get; set; }
        public string MakeFile { get; set; }
        public decimal? W { get; set; }
        public decimal? H { get; set; }
        public decimal? D { get; set; }
        public int? CPD_id { get; set; }
        public int? GlassPartID { get; set; }
        public int? OpCode { get; set; }
        public int? UnitID { get; set; }

        public virtual Product Product { get; set; }
    }
}
