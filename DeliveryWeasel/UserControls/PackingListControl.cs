/**
-----------------------------------------------------------------------
Packing List Control
-----------------------------------------------------------------------
**/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProductionDataAccess.Models;
using ProductionDataAccess.Services;
using ProductionDataAccess.Mappers;
using DBmaker.Models;


namespace DeliveryWeasel.UserControls
{
    public partial class PackingListControl : UserControl
    {
        private BindingSource bsDelivery = new BindingSource();

        public event EventHandler OnSaveHandler;
        public event EventHandler OnPrintHandler;

        protected virtual void OnSave(EventArgs e)
        {
            if (OnSaveHandler != null)
            { OnSaveHandler(this, e); }
        }

        protected virtual void OnPrint(EventArgs e)
        {
            if (OnPrintHandler != null)
            {
                OnPrintHandler(this, e);
            }
        }

        public void LoadDataSource(BindingSource bsdelivery)
        {
            bsDelivery = bsdelivery;
            Bind();
        }

        private void Bind()
        {
            // Delivery Number -------------------------------------------------------
            txtPackingListID.DataBindings.Clear();
            txtPackingListID.DataBindings.Add("Text", bsDelivery, "PurchaseOrderID", true, DataSourceUpdateMode.OnPropertyChanged);

       
        }

        private Delivery _delivery;
        private List<EmployeeDto> _employees;
        private readonly DeliveryService _deliveryService;
        public PackingListControl()
        {
            InitializeComponent();
            _deliveryService = new DeliveryService();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            cboEmployees.DataSource = _deliveryService.EmployeeList();
            cboEmployees.DisplayMember = "EmployeeName";
            cboEmployees.ValueMember = "EmployeeID";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveHandler(this, e);
            // if the return value is true
          // btnSave.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintHandler(this, e);
        }
    }
}
