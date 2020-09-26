using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class Part
    {
        public int PartID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string PartNum { get; set; }
        public int? ManuID { get; set; }
        public bool? ObsoluteFlag { get; set; }
        public int? PartTypeID { get; set; }
        public decimal? Cost { get; set; }
        public string UOP { get; set; }
        public decimal? UOPCost { get; set; }
        public int? UID { get; set; }
        public string Location { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Waste { get; set; }
        public decimal? MarkUp { get; set; }
        public int? SupplierID { get; set; }
        public string SupplierDescription { get; set; }
        public int? FinishID { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? UseSupplierNameFlag { get; set; }
        public decimal? UnitToPurchaseFactor { get; set; }
        public string ManuPartNum { get; set; }
        public string SKU { get; set; }
        public bool? CARBtrack { get; set; }
        public string CARBlevel { get; set; }
        public int? ParentID { get; set; }
        public decimal? Amount_Required { get; set; }
    }
}
