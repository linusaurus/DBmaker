using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProductionDataAccess.Mappers;
using ProductionDataAccess.Services;
using ProductionDataAccess.Models;
using ProductionDataAccess.Services.DataAccess.Service;
using ProductionDataAccess;

namespace DeliveryWeasel.UserControls
{
    public partial class DeliveriesListControl : UserControl
    {
        JobService _jobService;
        DeliveryService _deliveryService;

        BindingSource bsDeliveries = new BindingSource();
        BindingSource bsSelectedDelivery = new BindingSource();

        JobListDto _activeJob;
        DeliveryDto _selectedDelivery = new DeliveryDto();

        public event EventHandler OnDeliverySelectedHandler;

        private bool isDirty;

        #region Dirty State Check
        public bool IsDirty
        {
            get { return isDirty; }
            set { isDirty = value; }
        }

        private void ToogleButtonStyle(bool dirtyState)
        {
            if (dirtyState == true)
            {
                btnSave.BackColor = System.Drawing.Color.Cornsilk;
                btnSave.FlatStyle = FlatStyle.Flat;
                btnSave.FlatAppearance.BorderColor = Color.Red;
                btnSave.FlatAppearance.BorderSize = 3;
            }

            else if (dirtyState == false)
            {
                btnSave.BackColor = Color.Gainsboro;
                btnSave.FlatAppearance.BorderColor = Color.Cornsilk;
            }
        }

        private void CheckForDirtyState(ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged)
            {
                btnSave.Enabled = true;
                isDirty = true;
                ToogleButtonStyle(isDirty);
            }
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                btnSave.Enabled = true;
                isDirty = true;
                ToogleButtonStyle(isDirty);
            }
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                btnSave.Enabled = true;
                isDirty = true;
                ToogleButtonStyle(isDirty);
            }
        }

        #endregion

        public class DeliverySelectedEventArgs : EventArgs
        {
            public DeliveryDto selectedDelivery { get; set; }           
        }

        public void SaveChanges()
        {
           _deliveryService.CreateOrUpdateDelivery(_selectedDelivery);
            isDirty = false;
        }

        public DeliveriesListControl()
        {
            InitializeComponent();
            _jobService = new JobService();
            _deliveryService = new DeliveryService();

            BuildDeliveryGrid(dgDeliveryGrid);
            
            bsSelectedDelivery.DataSource = _selectedDelivery;
            dgDeliveryGrid.DataSource = bsDeliveries;
            bsDeliveries.CurrentItemChanged += BsDeliveries_CurrentItemChanged;
            BindControls();
            BindEmployeePicker();

            bsDeliveries.ListChanged += BsDeliveries_ListChanged;
        }

        private void BsDeliveries_CurrentItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BsDeliveries_ListChanged(object sender, ListChangedEventArgs e)
        { CheckForDirtyState(e);}
           
        
        private void BindControls()
        {
            txtDeliverID.DataBindings.Clear();
            txtDeliverID.DataBindings.Add("Text", bsSelectedDelivery.Current, "DeliveryID", true, DataSourceUpdateMode.OnPropertyChanged);
           
            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("Text", bsSelectedDelivery, "DeliveryDate");

            cboJobPicker.DataSource = _jobService.RecentJobs();
            cboJobPicker.DisplayMember = "JobName";
            cboJobPicker.ValueMember = "JobID";
        }

        private void BindEmployeePicker()
        {
            cboEmployeePicker.DataSource = _deliveryService.EmployeeList();
            cboEmployeePicker.DisplayMember = "EmployeeName";
            cboEmployeePicker.ValueMember = "EmployeeID";

            cboEmployeePicker.DataBindings.Clear();
            cboEmployeePicker.DataBindings.Add("SelectedValue", bsSelectedDelivery,
                                                "EmployeeID", true,
                                                    DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BuildDeliveryGrid(DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            #region Styles
            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
            dstyleCurrency.NullValue = "";
            dstyleCurrency.Alignment = DataGridViewContentAlignment.MiddleRight;
            // ShortDate Style
            DataGridViewCellStyle dstyleDate = new DataGridViewCellStyle();
            dstyleCurrency.Format = "d";
            dstyleCurrency.NullValue = "";
            dstyleCurrency.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Currency Decimal Style
            DataGridViewCellStyle dstyleDecimal = new DataGridViewCellStyle();
            dstyleDecimal.Format = "N2";
            dstyleDecimal.NullValue = "0.00";
            dstyleDecimal.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Wrapping Text Style
            DataGridViewCellStyle dstyleWrapText = new DataGridViewCellStyle();
            dstyleWrapText.NullValue = "";
            dstyleWrapText.Alignment = DataGridViewContentAlignment.TopLeft;
            dstyleWrapText.WrapMode = DataGridViewTriState.True;
            #endregion

            // ID Column --
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.HeaderText = "ID";
            colID.DataPropertyName = "DeliveryID";
            colID.Width = 65;

            // PartID Column --
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.HeaderText = "UnitID";
            colDate.DataPropertyName = "DeliveryDate";
            colDate.Width = 60;
            colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDate.DefaultCellStyle.Format = "d";
            

            // Description Column --
            DataGridViewTextBoxColumn colDriver = new DataGridViewTextBoxColumn();
            colDriver.DefaultCellStyle = dstyleWrapText;
            colDriver.HeaderText = "Driver";
            colDriver.DataPropertyName = "DriverName";

            colDriver.Width = 140;
            colDriver.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dg.Columns.AddRange(colID, colDate, colDriver);
           
        }
    
        protected virtual void OnSelectDelivery(EventArgs e)
        {
            if (OnDeliverySelectedHandler != null)
            {
                OnDeliverySelectedHandler(this, e);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_activeJob != null )
            {
                var newDelivery = _deliveryService.New(_activeJob.JobID,8);
                bsDeliveries.DataSource = _deliveryService.JobDeliveries(_activeJob.JobID);
            }
        }

        private void dgDeliveryGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.DataSource != null)
            {
                if (dg.Rows.Count > 0)
                {
                    ///TODO this is needs to sync with the binding on the 
                    _selectedDelivery = (DeliveryDto) dg.CurrentRow.DataBoundItem;
                 //  bsDeliveries.Current
                }
            }
        }

        #region Pickers
        //-----------------
        private void cboEmployeePicker_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            EmployeeDto dto = (EmployeeDto)cbx.SelectedItem;
            _selectedDelivery.EmployeeID = dto.EmployeeID;
            _selectedDelivery.DriverName = dto.EmployeeName;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            _selectedDelivery.DeliveryDate = dtp.Value;
        }

        private void cboJobPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            _activeJob = (JobListDto)cbx.SelectedItem;
            bsDeliveries.DataSource = _deliveryService.JobDeliveries(_activeJob.JobID);
            isDirty = false;
            ToogleButtonStyle(IsDirty);
        }

        //------------------
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            //Reload --
            isDirty = false;
            ToogleButtonStyle(IsDirty);
        }
    }





}
