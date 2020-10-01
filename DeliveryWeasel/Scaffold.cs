using DeliveryWeasel.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ProductionDataAccess.Services;
using ProductionDataAccess.Models;

namespace DeliveryWeasel
{
    public partial class Scaffold : Form
    {

        DeliveryManager manager;
        DeliveryService deliveryService;
        
        public Scaffold()
        {
            InitializeComponent();
            deliveryService = new DeliveryService();

            DeliveriesListControl ctl = new DeliveriesListControl();
         
            splitContainer1.Panel1.Controls.Add(ctl);
            ctl.Dock = DockStyle.Fill;

            ctl.OnJobSelected += Ctl_OnJobSelected;
            ctl.OnDeliverySelected += Ctl_OnDeliverySelected;

            manager= new DeliveryManager();
            
    
            splitContainer1.Panel2.Controls.Add(manager);
            manager.Dock = DockStyle.Fill;
            

          
        }

        private void Ctl_OnDeliverySelected(object sender, DeliveriesListControl.DeliverySelectedEventArgs e)
        {
           var result = deliveryService.FindDelivery(e.selectedDelivery.DeliveryID);
        }

        private void Ctl_OnJobSelected(object sender, DeliveriesListControl.JobSelectedEventArgs e)
        {
           manager.SetDatasource(e.JobID);
        }
    }
}
