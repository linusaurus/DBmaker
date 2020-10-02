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
        DeliveryDto _activeDelivery = new DeliveryDto();

        public DeliveryDto ActiveDelivery
        {
            get { return _activeDelivery; }
            set { _activeDelivery = value; }
        }

        public JobListDto ActiveJob
        {
            get { return _activeJob; }
            set { _activeJob = value; }
        }

        public DeliveryManager()
        {
            InitializeComponent();

            productService = new ProductService();
            deliveryService = new DeliveryService();
            //-----------------------------------------
            BuildProductGrid(dgProductGrid);
            BuildSubAssemblyGrid(dgSubAssemblies);
            BuildDeliveryItemsGrid(dgDeliveryItems);
            //-----------------------------------------
            dgProductGrid.SelectionChanged += DgProductGrid_SelectionChanged;
            bsDeliveryItem.AddingNew += BsDeliveryItem_AddingNew;
        }

        private void BsDeliveryItem_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new DeliveryItemDto
            {
                Delivered = false,
                DeliveryID = _activeDelivery.DeliveryID,
                ProductID = _selectedProduct.ProductID,
                SubAssemblyID = _selectedSubAssembly.SubAssemblyID               
            };
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

        public void SaveChanges()
        {
            deliveryService.CreateOrUpdateDelivery(_activeDelivery);
        }


        public void SetActiveDelivery(DeliveryDto  dto)
        {
            _activeDelivery = dto;
            bsDeliveryItem.DataSource = _activeDelivery.DeliveryItemDto;
            dgDeliveryItems.DataSource = bsDeliveryItem;
          
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
            // Add to Delivery ----------
            DataGridViewTextBoxColumn colAddToDelivery = new DataGridViewTextBoxColumn();
            colAddToDelivery.Width = 120;
            colAddToDelivery.HeaderText = "SubAssembly-Name";
            colAddToDelivery.DataPropertyName = "SubAssemblyName";
            // W ----------
            DataGridViewTextBoxColumn colSW = new DataGridViewTextBoxColumn();
            colSW.Width = 60;
            colSW.HeaderText = "W";
            colSW.DataPropertyName = "W";
            colSW.DefaultCellStyle = dstyleDecimal;
            colSW.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // H ----------
            DataGridViewTextBoxColumn colSH = new DataGridViewTextBoxColumn();
            colSH.Width = 60;
            colSH.HeaderText = "H";
            colSH.DataPropertyName = "H";
            colSH.DefaultCellStyle = dstyleDecimal;
            colSW.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // GlassPart ----------
            DataGridViewTextBoxColumn colGlassPart = new DataGridViewTextBoxColumn();
            colGlassPart.Width = 90;
            colGlassPart.HeaderText = "Glass PN#";
            colGlassPart.DataPropertyName = "GlassPartID";
            colSW.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            // DeliveryItemID ----------
            DataGridViewTextBoxColumn colDeliveryItemID = new DataGridViewTextBoxColumn();
            colDeliveryItemID.Width = 60;
            colDeliveryItemID.HeaderText = "ID";
            colDeliveryItemID.DataPropertyName = "DeliveryItemID";
            colDeliveryItemID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // DeliveryID ----------
            DataGridViewTextBoxColumn colDeliveryID = new DataGridViewTextBoxColumn();
            colDeliveryID.Width = 90;
            colDeliveryID.HeaderText = "DeliveryID";
            colDeliveryID.DataPropertyName = "DeliveryID";
            colDeliveryID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            // Description ----------
            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.Width = 180;
            colDescription.HeaderText = "Description";
            colDescription.DataPropertyName = "Description";
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Qnty ----------
            DataGridViewTextBoxColumn colQnty = new DataGridViewTextBoxColumn();
            colQnty.Width = 90;
            colQnty.HeaderText = "Qnty";
            colQnty.DataPropertyName = "Qnty";
            colQnty.DefaultCellStyle = dstyleDecimal;

            //ProductID ----------
            DataGridViewTextBoxColumn colProductID = new DataGridViewTextBoxColumn();
            colProductID.Width = 60;
            colProductID.HeaderText = "Prod#";
            colProductID.DataPropertyName = "ProductID";
            
            // PartID ----------
            DataGridViewTextBoxColumn colPartID = new DataGridViewTextBoxColumn();
            colPartID.Width = 90;
            colPartID.HeaderText = "PN#";
            colPartID.DataPropertyName = "PartID";

            // OnBoard ----------
            DataGridViewCheckBoxColumn colOnBoard = new DataGridViewCheckBoxColumn();
            colOnBoard.Width = 60;
            colOnBoard.HeaderText = "Onboard";
            colOnBoard.DataPropertyName = "Onboard";
           

            // Delivered ----------
            DataGridViewCheckBoxColumn colSDelivered = new DataGridViewCheckBoxColumn();
            colSDelivered.Width = 60;
            colSDelivered.HeaderText = "Delivered";
            colSDelivered.DataPropertyName = "Delivered";


            dg.Columns.AddRange(colDeliveryItemID, colDeliveryID, colQnty, colDescription, colProductID, colPartID,colOnBoard,colSDelivered);

        }

        private void tbMiscItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
