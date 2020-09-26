using DBmaker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionDataAccess.Models
{
    public class DeliveryItemDto
    {
        public int DeliveryItemID { get; set; }
        public int? DeliveryID { get; set; }
        public string Description { get; set; }
        public int? ProductID { get; set; }
        public string ItemDescription { get; set; }
        public bool? Onboard { get; set; }
        public bool? Delivered { get; set; }
        public int? PartID { get; set; }
        public decimal? Qnty { get; set; }

        public int? SubAssemblyID { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
