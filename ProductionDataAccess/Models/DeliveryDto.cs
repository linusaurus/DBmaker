using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Spatial;
using System.Text;
using ProductionDataAccess.Mappers;
using ProductionDataAccess.Models;
using ProductionDataAccess.Services;

namespace ProductionDataAccess.Models
{
    public class DeliveryDto : INotifyPropertyChanged
    {

        private int deliveryID;

        private DateTime? deliveryDate;
        public int? jobID { get; set; }
        public string jobName { get; set; }
        public int? employeeID { get; set; }
        public String driverName { get; set; }
        
        public int jobSiteID { get; set; }
        public string address { get; set; }

        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public Geometry location { get; set; }

        public int DeliveryID 
        {
            get { return deliveryID; }
            set
            {
               this.deliveryID = value ;
                OnPropertyChanged();
            } 
        }
        public DateTime? DeliveryDate
        {
            get {return deliveryDate; }
            set
            {
               deliveryDate = value ;
                OnPropertyChanged();
            }
        }
        public int? JobID 
        {
            get {return jobID; }
            set
            {
               jobID = value ;
                OnPropertyChanged();
            }
        }
        public string JobName 
        {
            get {return jobName; }
            set
            {
               jobName = value ;
                OnPropertyChanged();
            }
        }
        public int? EmployeeID 
        {
            get {return employeeID; }
            set
            {
               employeeID = value ;
               OnPropertyChanged();
            } 
        }
        public String DriverName 
        {
            get {return driverName; }
            set
            {
               driverName = value ;
                OnPropertyChanged();
            }
        }
       
        public  int JobSiteID
        {
            get {return jobSiteID; }
            set
            {
                jobSiteID = value   ;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value ;
                OnPropertyChanged();
            }
        }

        public string City 
        {
            get { return city; }
            set
            {
                city = value  ;
                OnPropertyChanged();
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                state = value   ;
                OnPropertyChanged();
            } 
        }
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value  ;
                OnPropertyChanged();
            }
        }

        public Geometry Location
        {
            get {return location; }
            set
            {
              location = value ;
                OnPropertyChanged();
            }
        }

        public List<DeliveryItemDto> DeliveryItemDto { get; set; } = new List<DeliveryItemDto>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
