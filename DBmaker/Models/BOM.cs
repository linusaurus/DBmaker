using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class BOM
    {
        public int CutlistID { get; set; }
        public int? PartID { get; set; }
        public string SubAssemblyGUID { get; set; }
        public string FunctionalName { get; set; }
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public int? Qnty { get; set; }
        public decimal? Width { get; set; }
        public decimal? Thick { get; set; }
        public decimal? Length { get; set; }
        public string PartClass { get; set; }
        public string Note { get; set; }
        public string PartIdentifier { get; set; }
        public decimal? Price { get; set; }
        public decimal? Area { get; set; }
        public decimal? Weight { get; set; }
        public string PartLabel { get; set; }
        public decimal? Waste { get; set; }
        public decimal? Markup { get; set; }
        public string PartType { get; set; }
        public decimal? Rate { get; set; }
        public decimal? LaborAmount { get; set; }
        public decimal? UnitPrice { get; set; }
        public string AssemblyName { get; set; }
        public int? AssemblyID { get; set; }
        public decimal? Tax { get; set; }
        public decimal? AssemblyWidth { get; set; }
        public decimal? AssemblyHieght { get; set; }
        public decimal? AssemblyDepth { get; set; }
        public decimal? AssemblyArea { get; set; }
        public decimal? SubAssemblyWidth { get; set; }
        public decimal? SubAssemblyHieght { get; set; }
        public decimal? SubAssemblyDepth { get; set; }
        public decimal? SubAssemblyArea { get; set; }
        public short? UOM { get; set; }
        public int? JobID { get; set; }
        public int? ArticleID { get; set; }
        public string JobName { get; set; }
    }
}
