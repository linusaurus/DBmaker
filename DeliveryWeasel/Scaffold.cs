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
using System.IO;

namespace DeliveryWeasel
{
    public partial class Scaffold : Form
    {

        DeliveryManager manager;
        DeliveryService deliveryService;
        ProductService productService;
        
        public Scaffold()
        {
            InitializeComponent();

            // Services --------------------------------------------------------------------
            deliveryService = new DeliveryService();
            productService = new ProductService();
            
            // Controls ----------------------------------------------------------------------

            DeliveriesListControl ctlDeliveries = new DeliveriesListControl();       
            splitContainer1.Panel1.Controls.Add(ctlDeliveries);
            ctlDeliveries.Dock = DockStyle.Fill;

            ctlDeliveries.OnJobSelected += Ctl_OnJobSelected;
            ctlDeliveries.OnDeliverySelected += Ctl_OnDeliverySelected;

            manager= new DeliveryManager();             
            splitContainer1.Panel2.Controls.Add(manager);
            manager.Dock = DockStyle.Fill;

            // Controls ---------------------------------------------------------------------
 
        }
        
        private void Ctl_OnDeliverySelected(object sender, DeliveriesListControl.DeliverySelectedEventArgs e)
        {
           var result = deliveryService.FindDelivery(e.selectedDelivery.DeliveryID);
            manager.SetActiveDelivery(result);
        }

        private void Ctl_OnJobSelected(object sender, DeliveriesListControl.JobSelectedEventArgs e)
        {
           manager.SetDatasource(e.JobID);
        }
        // Toolbar -----------------------------------------------------------------------
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch ( e.ClickedItem.Name)
            {
                case "Save":

                    deliveryService.CreateOrUpdateDelivery(manager.ActiveDelivery);
                    int k = manager.ActiveDelivery.DeliveryID;
                    var result = deliveryService.FindDelivery(k);
                    manager.SetActiveDelivery(result);
                    var job = manager.ActiveJob;
                    break;
                case "Print":

                   
                    break;

            }

           
            
            
        }
        // Toolbar -------------------------------------------------------------------------
    }
}
