using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProductionDataAccess;
using ProductionDataAccess.Services;
using ProductionDataAccess.Models;
using ProductionDataAccess.Mappers;
using ProductionDataAccess.Services.DataAccess.Service;

namespace DeliveryWeasel.UserControls
{
    public partial class DeliveryManager : UserControl
    {
        BindingSource bsProducts = new BindingSource();
        BindingSource bsSubAssemblies = new BindingSource();
        BindingSource bsDeliveryItem = new BindingSource();
        //--------------
        ProductService productService;
        DeliveryService deliveryService;
        //JobService jobService;
        //--------------
        ProductDto _selectedProduct = new ProductDto();
        SubAssemblyDTO _selectedSubAssembly = new SubAssemblyDTO();
        JobListDto _activeJob = new JobListDto();

        public DeliveryManager()
        {
            InitializeComponent();
            productService = new ProductService();
            deliveryService = new DeliveryService();
            BuildProductGrid(dgProductGrid);
            BuildSubAssemblyGrid(dgSubAssemblies);
            BuildDeliveryItemsGrid(dataGridView1);
            dgProductGrid.SelectionChanged += DgProductGrid_SelectionChanged;           
        }

        private void DgProductGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.DataSource != null)
            {
                BindingManagerBase bm = BindingContext[dg.DataSource, dg.DataMember];
                if (bm.Count > 0 && bm.Current != null)
                {
                    _selectedProduct = (ProductDto)bm.Current;
                    dgSubAssemblies.DataSource = _selectedProduct.SubAssemblies;
                }
            }
        }

        public void SetDatasource(int jobID)
        {
            if (jobID != default)
            {
                _activeJob = productService.GetJobProducts(jobID);
                bsProducts.DataSource = _activeJob.Products;
                dgProductGrid.DataSource = bsProducts;
            }          
        }

        private void BuildProductGrid(DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
            dstyleCurrency.NullValue = "";
            dstyleCurrency.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Decimal Style
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
            DataGridViewTextBoxColumn colPID = new DataGridViewTextBoxColumn();
            colPID.HeaderText = "Product-ID";
            colPID.DataPropertyName = "ProductID";
            colPID.Width = 55;
            // UnitName Column --
            DataGridViewTextBoxColumn colUnitName = new DataGridViewTextBoxColumn();
            colUnitName.DefaultCellStyle = dstyleWrapText;
            colUnitName.HeaderText = "UnitName";
            colUnitName.DataPropertyName = "UnitName";
            colUnitName.Width = 120;
            colUnitName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // W ----------
            DataGridViewTextBoxColumn colW = new DataGridViewTextBoxColumn();
            colW.Width = 60;
            colW.HeaderText = "W";
            colW.DataPropertyName = "W";
            colW.DefaultCellStyle = dstyleCurrency;
            // H ----------
            DataGridViewTextBoxColumn colH = new DataGridViewTextBoxColumn();
            colH.Width = 60;
            colH.HeaderText = "H";
            colH.DataPropertyName = "H";
            colH.DefaultCellStyle = dstyleDecimal;
            // Delivered ----------
            DataGridViewCheckBoxColumn colDelivered = new DataGridViewCheckBoxColumn();
            colDelivered.Width = 60;
            colDelivered.HeaderText = "Delivered";
            colDelivered.DataPropertyName = "Delivered";
            

            //colUnit.DataSource = _partService.Units();
            dg.Columns.AddRange(colPID, colUnitName, colW, colH, colDelivered);
        }

        private void BuildSubAssemblyGrid(DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            #region Styles

            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
            dstyleCurrency.NullValue = "";
            dstyleCurrency.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Decimal Style
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

            // SubID ----------
            DataGridViewTextBoxColumn colSubID = new DataGridViewTextBoxColumn();
            colSubID.Width = 60;
            colSubID.HeaderText = "SiD";
            colSubID.DataPropertyName = "SubAssemblyID";
            colSubID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // SubAssembly Name ----------
            DataGridViewTextBoxColumn colSubName = new DataGridViewTextBoxColumn();
            colSubName.Width = 120;
            colSubName.HeaderText = "SubAssembly-Name";
            colSubName.DataPropertyName = "SubAssemblyName";
            colSubName.DefaultCellStyle = dstyleWrapText;
            colSubName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // W ----------
            DataGridViewTextBoxColumn colSW = new DataGridViewTextBoxColumn();
            colSW.Width = 60;
            colSW.HeaderText = "W";
            colSW.DataPropertyName = "W";
            colSW.DefaultCellStyle = dstyleDecimal;
            // H ----------
            DataGridViewTextBoxColumn colSH = new DataGridViewTextBoxColumn();
            colSH.Width = 60;
            colSH.HeaderText = "H";
            colSH.DataPropertyName = "H";
            colSH.DefaultCellStyle = dstyleDecimal;
            // GlassPart ----------
            DataGridViewTextBoxColumn colGlassPart = new DataGridViewTextBoxColumn();
            colGlassPart.Width = 90;
            colGlassPart.HeaderText = "Glass PN#";
            colGlassPart.DataPropertyName = "GlassPartID";
            // GlassCpdID ----------
            DataGridViewTextBoxColumn colCPD = new DataGridViewTextBoxColumn();
            colCPD.Width = 80;
            colCPD.HeaderText = "CPD#";
            colCPD.DataPropertyName = "CPD_ID";
            // Delivered ----------
            DataGridViewCheckBoxColumn colSDelivered = new DataGridViewCheckBoxColumn();
            colSDelivered.Width = 60;
            colSDelivered.HeaderText = "Delivered";
            colSDelivered.DataPropertyName = "Delivered";

            
            dg.Columns.AddRange(colSubID, colSubName, colSW, colSH, colGlassPart, colCPD, colSDelivered);

        }

        private void BuildDeliveryItemsGrid(DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            #region Styles

            // Currency Decimal Style
            DataGridViewCellStyle dstyleCurrency = new DataGridViewCellStyle();
            dstyleCurrency.Format = "C";
            dstyleCurrency.NullValue = "";
            dstyleCurrency.Alignment = DataGridViewContentAlignment.MiddleRight;
            // Decimal Style
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

            // SubID ----------
            DataGridViewTextBoxColumn colDeliveryItemID = new DataGridViewTextBoxColumn();
            colDeliveryItemID.Width = 60;
            colDeliveryItemID.HeaderText = "ID";
            colDeliveryItemID.DataPropertyName = "DeliveryItemID";
            colDeliveryItemID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // SubAssembly Name ----------
            DataGridViewTextBoxColumn colDeliveryID = new DataGridViewTextBoxColumn();
            colDeliveryID.Width = 120;
            colDeliveryID.HeaderText = "DeliveryID";
            colDeliveryID.DataPropertyName = "DeliveryID";
            colDeliveryID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // W ----------
            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.Width = 180;
            colDescription.HeaderText = "Description";
            colDescription.DataPropertyName = "Description";
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // H ----------
            DataGridViewTextBoxColumn colProductID = new DataGridViewTextBoxColumn();
            colProductID.Width = 60;
            colProductID.HeaderText = "Prod#";
            colProductID.DataPropertyName = "ProductID";
            colProductID.DefaultCellStyle = dstyleDecimal;
            // GlassPart ----------
            DataGridViewTextBoxColumn colPartID = new DataGridViewTextBoxColumn();
            colPartID.Width = 90;
            colPartID.HeaderText = "PN#";
            colPartID.DataPropertyName = "PartID";
            // GlassCpdID ----------
            DataGridViewTextBoxColumn colQnty = new DataGridViewTextBoxColumn();
            colQnty.Width = 80;
            colQnty.HeaderText = "CPD#";
            colQnty.DataPropertyName = "CPD_ID";
            // Delivered ----------
            DataGridViewCheckBoxColumn colSDelivered = new DataGridViewCheckBoxColumn();
            colSDelivered.Width = 60;
            colSDelivered.HeaderText = "Delivered";
            colSDelivered.DataPropertyName = "Delivered";


            dg.Columns.AddRange(colDeliveryItemID, colDeliveryID, colDescription, colProductID, colPartID, colQnty, colSDelivered);

        }

        private void tbMiscItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
