using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class Product
    {
        public Product()
        {
            SubAssembly = new HashSet<SubAssembly>();
        }

        public int ProductID { get; set; }
        public int? JobID { get; set; }
        public int? UnitID { get; set; }
        public string UnitName { get; set; }
        public string ArchDescription { get; set; }
        public bool? Make { get; set; }
        public decimal? W { get; set; }
        public decimal? H { get; set; }
        public decimal? D { get; set; }
        public string RoomName { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool? NIC { get; set; }

        public virtual Job Job { get; set; }
        public virtual ICollection<SubAssembly> SubAssembly { get; set; }
    }
}
