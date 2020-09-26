using System;
using System.Collections.Generic;

namespace DBmaker.Models
{
    public partial class Job
    {
        public Job()
        {
            Delivery = new HashSet<Delivery>();
            Product = new HashSet<Product>();
        }

        public int JobID { get; set; }
        public string JobName { get; set; }
        public int? JobNumber { get; set; }
        public string JobDescription { get; set; }
        public bool? Retired { get; set; }
        public bool? Visible { get; set; }
        public DateTime? start_ts { get; set; }

        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
