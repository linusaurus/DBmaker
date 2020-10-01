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

       // Delivery Selected Event Structure
        public delegate void   OnDeliverySelectedHandler(object sender, DeliverySelectedEventArgs e);
        public event OnDeliverySelectedHandler OnDeliverySelected;

        public delegate void OnJobSelectedHandler(object sender, JobSelectedEventArgs e);
        public event OnJobSelectedHandler OnJobSelected;
       
         public class JobSelectedEventArgs : EventArgs
        {
            public int JobID { get; set; } 
        }
        public class DeliverySelectedEventArgs : EventArgs
        { 
            public DeliveryDto selectedDelivery { get; set; }
        }

        protected virtual void OnSelectJob(JobSelectedEventArgs e)
        {
            if (OnJobSelected != null)
            {
                JobSelectedEventArgs args = new JobSelectedEventArgs { JobID = _activeJob.JobID };
                OnJobSelected(this, args);
            }
        }

        protected virtual void OnSelectDelivery(DeliverySelectedEventArgs e)
        {
            if (OnDeliverySelected != null)
            {
                DeliverySelectedEventArgs args = new DeliverySelectedEventArgs { selectedDelivery = _selectedDelivery };
                OnDeliverySelected(this, args);
            }
        }

        

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
     
            BindControls();
            BindEmployeePicker();

            bsDeliveries.ListChanged += BsDeliveries_ListChanged;
        }

      

        private void BsDeliveries_ListChanged(object sender, ListChangedEventArgs e)
        { CheckForDirtyState(e);}
           
        
        private void BindControls()
        {
            txtDeliverID.DataBindings.Clear();
            txtDeliverID.DataBindings.Add("Text", bsSelectedDelivery, "DeliveryID", true, DataSourceUpdateMode.OnPropertyChanged);
           
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
            if (dgDeliveryGrid.DataSource != null)
            {
                BindingManagerBase bm = BindingContext[dgDeliveryGrid.DataSource, dgDeliveryGrid.DataMember];
                if (bm.Count > 0 && bm.Current != null)
                {
                    _selectedDelivery  = (DeliveryDto)bm.Current;
                    bsSelectedDelivery.DataSource = _selectedDelivery;
                    if (OnDeliverySelected != null)
                    {
                        OnDeliverySelected(this, new DeliverySelectedEventArgs { selectedDelivery = _selectedDelivery });
                    }                      
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
        /// <summary>
        /// Job Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboJobPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            _activeJob = (JobListDto)cbx.SelectedItem;
            bsDeliveries.DataSource = _deliveryService.JobDeliveries(_activeJob.JobID);
            isDirty = false;
            ToogleButtonStyle(IsDirty);
            OnSelectJob(new JobSelectedEventArgs { JobID = _activeJob.JobID });
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
