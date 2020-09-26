using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            DeliveryItem = new HashSet<DeliveryItem>();
        }

        public int DeliveryID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? JobID { get; set; }
        public int? EmployeeID { get; set; }

        public int? ItemCount { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Job Job { get; set; }
       
        public virtual int JobSiteID   {get;set;}

        public virtual JobSite JobSite { get; set; }

        public virtual ICollection<DeliveryItem> DeliveryItem { get; set; }
    }
}
