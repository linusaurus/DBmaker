using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DBmaker.Models;

namespace ProductionDataAccess
{
    public class SubAssemblyDTO : INotifyPropertyChanged
    {

        public int productID { get; set; }
        public int subAssemblyID { get; set; }
        public string subAssemblyName { get; set; }
        public string makeFile { get; set; }
        public decimal? w { get; set; }
        public decimal? h { get; set; }
        public decimal? d { get; set; }

        public int? glassPartID { get; set; }
        public int? cPD_id { get; set; }


        public int? GlassPartID
        {
            get { return glassPartID; }
            set
            {
                glassPartID = value;
                OnPropertyChange();
            }
        }

        public int? CPD_ID
        {
            get { return cPD_id; }
            set
            {
                cPD_id = value;
                OnPropertyChange();
            }
        }

        // ProductionDate
        public int ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                OnPropertyChange();
            }
        }

        // SUbAssemblyID
        public int SubAssemblyID
        {
            get { return subAssemblyID; }
            set
            {
                subAssemblyID = value;
                OnPropertyChange();
            }
        }

        // SubAssemblyName
        public string SubAssemblyName
        {
            get { return subAssemblyName; }
            set
            {
                subAssemblyName = value;
                OnPropertyChange();
            }
        }

        // MakeFile
        public string MakeFile
        {
            get { return makeFile; }
            set
            {
                makeFile = value;
                OnPropertyChange();
            }
        }

        // W
        public decimal? W
        {
            get { return w; }
            set
            {
                w = value;
                OnPropertyChange();
            }
        }

        // H
        public decimal? H
        {
            get { return h; }
            set
            {
                h = value;
                OnPropertyChange();
            }
        }
        // D
        public decimal? D
        {
            get { return d; }
            set
            {
                d = value;
                OnPropertyChange();
            }
        }

        public List<Part> Parts { get; set; }





        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
