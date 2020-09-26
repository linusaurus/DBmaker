using System;
using System.Collections.Generic;
using System.Text;

namespace DBmaker.Models
{
    public class JobSite
    {
        public int JobSiteID { get; set; }

        public int JobID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Location { get; set; }
    }
}
