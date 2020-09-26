using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProductionDataAccess
{
    public class ProductDto : INotifyPropertyChanged
    {
        private int productID;
        private int jobID;
        private int unitID;
        private string unitName;
        private string archDescription;
        private string roomName;

        private bool make;
        private decimal? w;
        private decimal? d;
        private decimal? h;

        private bool? delivered;
        private DateTime deliveryDate;
        private DateTime productionDate;
        private bool nIC;
        private bool isDeleted;


        public bool IsDeleted
        {
            get { return isDeleted; }
            set
            {
                isDeleted = value;
                OnPropertyChange();
            }
        }

        // ProductID
        public int ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                OnPropertyChange();
            }
        }

        // JobID
        public int JobID
        {
            get { return jobID; }
            set
            {
                jobID = value;
                OnPropertyChange();
            }
        }

        // JobID
        public string UnitName
        {
            get { return unitName; }
            set
            {
                unitName = value;
                OnPropertyChange();
            }
        }
        // UnitID
        public int UnitID
        {
            get { return unitID; }
            set
            {
                unitID = value;
                OnPropertyChange();
            }
        }
        // ArchDescription
        public string ArchDescription
        {
            get { return archDescription; }
            set
            {
                archDescription = value;
                OnPropertyChange();
            }
        }
        // RoomName
        public string RoomName
        {
            get { return roomName; }
            set
            {
                roomName = value;
                OnPropertyChange();
            }
        }
        // Make
        public bool Make
        {
            get { return make; }
            set
            {
                make = value;
                OnPropertyChange();
            }
        }
        //FW
        public decimal? W
        {
            get { return w; }
            set
            {
                w = value;
                OnPropertyChange();
            }
        } 
        // FD
        public decimal? D
        {
            get { return d; }
            set
            {
                d = value;
                OnPropertyChange();
            }
        }
        // FH
        public decimal? H
        {
            get { return h; }
            set
            {
                h = value;
                OnPropertyChange();
            }
        }

        // Delivered
        public bool? Delivered
        {
            get { return delivered; }
            set
            {
                delivered = value;
                OnPropertyChange();
            }
        }
        
        // DeliveryDate
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set
            {
                deliveryDate = value;
                OnPropertyChange();
            }
        }

        // ProductionDate
        public DateTime ProductionDate
        {
            get { return productionDate; }
            set
            {
                productionDate = value;
                OnPropertyChange();
            }
        }

        // ProductionDate
        public bool NIC
        {
            get { return nIC; }
            set
            {
                nIC = value;
                OnPropertyChange();
            }
        }

        public List<SubAssemblyDTO> SubAssemblies { get; set; } = new List<SubAssemblyDTO>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
