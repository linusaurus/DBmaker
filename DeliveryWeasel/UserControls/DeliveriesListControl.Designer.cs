namespace DeliveryWeasel.UserControls
{
    partial class DeliveriesListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNew = new System.Windows.Forms.Button();
            this.dgDeliveryGrid = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboEmployeePicker = new System.Windows.Forms.ComboBox();
            this.txtDeliverID = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboJobPicker = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(15, 69);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New Delivery";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgDeliveryGrid
            // 
            this.dgDeliveryGrid.AllowUserToAddRows = false;
            this.dgDeliveryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDeliveryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliveryGrid.Location = new System.Drawing.Point(15, 104);
            this.dgDeliveryGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgDeliveryGrid.MinimumSize = new System.Drawing.Size(230, 0);
            this.dgDeliveryGrid.Name = "dgDeliveryGrid";
            this.dgDeliveryGrid.Size = new System.Drawing.Size(276, 190);
            this.dgDeliveryGrid.TabIndex = 0;
            this.dgDeliveryGrid.SelectionChanged += new System.EventHandler(this.dgDeliveryGrid_SelectionChanged_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(130, 69);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cboEmployeePicker
            // 
            this.cboEmployeePicker.FormattingEnabled = true;
            this.cboEmployeePicker.Location = new System.Drawing.Point(17, 344);
            this.cboEmployeePicker.Name = "cboEmployeePicker";
            this.cboEmployeePicker.Size = new System.Drawing.Size(184, 23);
            this.cboEmployeePicker.TabIndex = 4;
            this.cboEmployeePicker.SelectedIndexChanged += new System.EventHandler(this.cboEmployeePicker_SelectedIndexChanged_1);
            // 
            // txtDeliverID
            // 
            this.txtDeliverID.Location = new System.Drawing.Point(205, 315);
            this.txtDeliverID.Name = "txtDeliverID";
            this.txtDeliverID.Size = new System.Drawing.Size(86, 23);
            this.txtDeliverID.TabIndex = 5;
            this.txtDeliverID.Text = "DeliverID";
            this.txtDeliverID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 315);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 23);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cboJobPicker
            // 
            this.cboJobPicker.FormattingEnabled = true;
            this.cboJobPicker.Location = new System.Drawing.Point(15, 29);
            this.cboJobPicker.Name = "cboJobPicker";
            this.cboJobPicker.Size = new System.Drawing.Size(276, 23);
            this.cboJobPicker.TabIndex = 7;
            this.cboJobPicker.SelectedIndexChanged += new System.EventHandler(this.cboJobPicker_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(36, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeliveriesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboJobPicker);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtDeliverID);
            this.Controls.Add(this.cboEmployeePicker);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgDeliveryGrid);
            this.MinimumSize = new System.Drawing.Size(275, 0);
            this.Name = "DeliveriesListControl";
            this.Size = new System.Drawing.Size(312, 534);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgDeliveryGrid;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboEmployeePicker;
        private System.Windows.Forms.TextBox txtDeliverID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboJobPicker;
        private System.Windows.Forms.Button btnSave;
    }
}
