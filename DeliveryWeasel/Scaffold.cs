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

namespace DeliveryWeasel
{
    public partial class Scaffold : Form
    {
        public Scaffold()
        {
            InitializeComponent();

            DeliveriesListControl ctl = new DeliveriesListControl();

            splitContainer1.Panel1.Controls.Add(ctl);

          
        }

        
    }
}
