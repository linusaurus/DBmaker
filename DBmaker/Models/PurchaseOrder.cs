using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class PurchaseOrder
    {
        public int? PurchaseOrderID { get; set; }
        public int? JobID { get; set; }
        public int? SupplierID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderSubtotal { get; set; }
        public decimal? OrderGrandTotal { get; set; }
    }
}
