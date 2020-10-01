using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ProductionDataAccess;
using ProductionDataAccess.Services;
using ProductionDataAccess.Services.DataAccess.Service;

namespace DeliveryWeasel
{
    public partial class Main : Form
    {
        //-----------Services--------------------------------------
        private readonly ProductService _productService;        //-
        private readonly DeliveryService _deliveryService;      //-
        private readonly JobService _jobService;                //-
        //--------------------------------------------------------
        // Main Concurrency Object
        private JobListDto _selectedJobDto;
        private List<SubAssemblyDTO> _subassemblies;
        private List<ProductDto> _activeProductList;
        BindingSource bsProduct;

        UserControls.DeliveriesListControl delCtl;

        public Main()
        {
            _productService = new ProductService();
            _jobService = new JobService();
            _deliveryService = new DeliveryService();
            bsProduct = new BindingSource();

            InitializeComponent();
            comboBox1.DataSource = _jobService.RecentJobs();
            comboBox1.DisplayMember = "JobName";
            comboBox1.ValueMember = "JobID";
         
            delCtl = new UserControls.DeliveriesListControl();
            spcMainVertical.Panel1.Controls.Add(delCtl);
            delCtl.Dock = DockStyle.Fill;
           
          
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            dgProductGrid.CellContentClick += DgProductGrid_CellContentClick;
            dgProductGrid.CellValueChanged += DgProductGrid_CellValueChanged;
            dgProductGrid.CellClick += DgProductGrid_CellClick;
            dgProductGrid.SelectionChanged += DgProductGrid_SelectionChanged;

            dgDeliverItems.CellContentClick += DgDeliverItems_CellContentClick;

            BuildProductGrid();
            BuildSubAssemblyGrid();
            dgProductGrid.DataSource = bsProduct;
        }
        /// <summary>
        /// TODO  this should copy an object to the delivered item list and mark the original sub assembly to that deliveryID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgDeliverItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender ;
            DataGridViewButtonCell bCell = (DataGridViewButtonCell)dg.CurrentCell;
            SubAssemblyDTO sub = (SubAssemblyDTO)dg.Rows[bCell.RowIndex].DataBoundItem;
          
        }

        
       

        private void DgProductGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProductGrid.DataSource != null)
            {
                if (dgProductGrid.Rows.Count > 0)
                {
                    int idx = ((DataGridView)sender).CurrentCell.RowIndex;
                    ProductDto  item = (ProductDto)dgProductGrid.Rows[idx].DataBoundItem;
                    dgDeliverItems.DataSource = item.SubAssemblies;
                }

            }
        }

  
        private void DgProductGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DgProductGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var cbxCell = (DataGridViewCheckBoxCell)dgProductGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                if ((bool)cbxCell.Value)
                {
                    this.dgProductGrid.CurrentRow.DefaultCellStyle.BackColor = Color.Cornsilk;
                }
                else
                {
                    this.dgProductGrid.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void DgProductGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgProductGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        /// <summary> -----------------------------------------------------------------------------
        /// Hydrate the Products DTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>---------------------------------------------------------------
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            _selectedJobDto = (JobListDto)cbo.SelectedItem;
            _selectedJobDto = _productService.GetProducts(_selectedJobDto.JobID);
            _activeProductList = _selectedJobDto.Products;           
            bsProduct.DataSource = _activeProductList;
            FormateProductGrid();
           
        }

        private void FormateProductGrid()
        {
            foreach (DataGridViewRow row in dgProductGrid.Rows)
            {
                //string RowType = row.Cells[7].Value.ToString();
                ProductDto dto = (ProductDto)row.DataBoundItem;


                if (dto != null)
                {
                    if (dto.Delivered.GetValueOrDefault() == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.Cornsilk;
                        row.DefaultCellStyle.ForeColor = Color.Green;
                        row.ReadOnly = true;
                    }
                   
                }           

            }
        }

        private void BuildProductGrid()
        {
            dgProductGrid.AutoGenerateColumns = false;
            dgProductGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
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


            // ID Column --
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.HeaderText = "PID";
            colID.DataPropertyName = "ProductID";
            colID.Width = 75;

            // PartID Column --
            DataGridViewLinkColumn colUnitID = new DataGridViewLinkColumn();
            colUnitID.HeaderText = "UnitID";
            colUnitID.DataPropertyName = "UnitID";
            colUnitID.Width = 50;

            // Description Column --
            DataGridViewTextBoxColumn colArchDescription = new DataGridViewTextBoxColumn();
            colArchDescription.DefaultCellStyle = dstyleWrapText;
            colArchDescription.HeaderText = "Arch Description";
            colArchDescription.DataPropertyName = "ArchDescription";

            colArchDescription.Width = 450;
            colArchDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // W ----------
            DataGridViewTextBoxColumn colW = new DataGridViewTextBoxColumn();
            colW.Width = 60;
            colW.HeaderText = "Width";
            colW.DataPropertyName = "W";
            colW.DefaultCellStyle = dstyleDecimal;

            // H ----------
            DataGridViewTextBoxColumn colH = new DataGridViewTextBoxColumn();
            colH.Width = 60;
            colH.HeaderText = "Height";
            colH.DataPropertyName = "H";

            colH.DefaultCellStyle = dstyleDecimal;

            // D ----------
            DataGridViewTextBoxColumn colD = new DataGridViewTextBoxColumn();
            colD.Width = 60;
            colD.HeaderText = "Thick";
            colD.DataPropertyName = "T";

            colD.DefaultCellStyle = dstyleDecimal;
            // Extended ----------
            DataGridViewCheckBoxColumn colForDelivery = new DataGridViewCheckBoxColumn();


            // Delivered ----------
            DataGridViewCheckBoxColumn colDelivered = new DataGridViewCheckBoxColumn();
            colDelivered.Width = 60;
            colDelivered.HeaderText = "Delivered";
            colDelivered.DataPropertyName = "Delivered";
            //colForDelivery.DefaultCellStyle = dstyleCurrency;

            // Delivered ----------
            DataGridViewTextBoxColumn colDeliverDate = new DataGridViewTextBoxColumn();
            colDeliverDate.Width = 100;
            colDeliverDate.HeaderText = "Delivery Date";
            colDeliverDate.DataPropertyName = "DeliveryDate";
            //colDeliverDate.DefaultCellStyle.Format = "d";
            colDeliverDate.DefaultCellStyle.NullValue = String.Empty;
          
            dgProductGrid.Columns.AddRange(colID, colUnitID, colArchDescription, colW, colH, colD,  colDelivered, colDeliverDate);

        }

        private void BuildSubAssemblyGrid()
        {
            dgDeliverItems.AutoGenerateColumns = false;
            dgDeliverItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
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


            // ID Column --
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.HeaderText = "ID";
            colID.DataPropertyName = "SubAssemblyID";
            colID.Width = 75;

            // SubAssemblyName Column --
            DataGridViewTextBoxColumn colSubAssemblyName = new DataGridViewTextBoxColumn();
            colSubAssemblyName.DefaultCellStyle = dstyleWrapText;
            colSubAssemblyName.HeaderText = "SubAssembly Name";
            colSubAssemblyName.DataPropertyName = "SubAssemblyName";

            colSubAssemblyName.Width = 300;
            colSubAssemblyName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Add to Paking List Button
            DataGridViewButtonColumn colAddToPackingList = new DataGridViewButtonColumn();
            colAddToPackingList.Width = 40;
            colAddToPackingList.HeaderText = "Add";
            
            

            // W ----------
            DataGridViewTextBoxColumn colW = new DataGridViewTextBoxColumn();
            colW.Width = 60;
            colW.HeaderText = "Width";
            colW.DataPropertyName = "W";
            colW.DefaultCellStyle = dstyleDecimal;

            // H ----------
            DataGridViewTextBoxColumn colH = new DataGridViewTextBoxColumn();
            colH.Width = 60;
            colH.HeaderText = "Height";
            colH.DataPropertyName = "H";

            colH.DefaultCellStyle = dstyleDecimal;

            // D ----------
            DataGridViewTextBoxColumn colD = new DataGridViewTextBoxColumn();
            colD.Width = 60;
            colD.HeaderText = "Thick";
            colD.DataPropertyName = "T";
            colD.DefaultCellStyle = dstyleDecimal;

            DataGridViewCheckBoxColumn colForDelivery = new DataGridViewCheckBoxColumn();

            dgDeliverItems.Columns.AddRange(colID, colSubAssemblyName, colAddToPackingList, colW, colH, colD);
            //---------------------------------------------------------------------------
        }
        private void SaveChanges(object sender, EventArgs e)
        {
            _productService.AddOrUpdate(_activeProductList);
            FormateProductGrid();
        }
    }
}
