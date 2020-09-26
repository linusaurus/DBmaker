namespace DeliveryWeasel.UserControls
{
    partial class PackingListControl
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
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.btnNewPackingList = new System.Windows.Forms.Button();
            this.txtPackingListID = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.dtpDeliverDate = new System.Windows.Forms.DateTimePicker();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.cboEmployees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintPackList = new System.Windows.Forms.Button();
            this.btnOpenPackingList = new System.Windows.Forms.Button();
            this.txtOpenListID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(17, 126);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(235, 23);
            this.txtJobName.TabIndex = 0;
            this.txtJobName.Text = "JobName";
            // 
            // btnNewPackingList
            // 
            this.btnNewPackingList.Location = new System.Drawing.Point(17, 19);
            this.btnNewPackingList.Name = "btnNewPackingList";
            this.btnNewPackingList.Size = new System.Drawing.Size(143, 23);
            this.btnNewPackingList.TabIndex = 1;
            this.btnNewPackingList.Text = "Created Packing List";
            this.btnNewPackingList.UseVisualStyleBackColor = true;
            // 
            // txtPackingListID
            // 
            this.txtPackingListID.Location = new System.Drawing.Point(17, 97);
            this.txtPackingListID.Name = "txtPackingListID";
            this.txtPackingListID.Size = new System.Drawing.Size(205, 23);
            this.txtPackingListID.TabIndex = 0;
            this.txtPackingListID.Text = "Pack ID";
            this.txtPackingListID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(17, 171);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(354, 23);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "Address";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(17, 200);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(207, 23);
            this.txtCity.TabIndex = 0;
            this.txtCity.Text = "City";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(230, 200);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(53, 23);
            this.txtState.TabIndex = 0;
            this.txtState.Text = "State";
            this.txtState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDeliverDate
            // 
            this.dtpDeliverDate.CustomFormat = "";
            this.dtpDeliverDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliverDate.Location = new System.Drawing.Point(258, 126);
            this.dtpDeliverDate.Name = "dtpDeliverDate";
            this.dtpDeliverDate.Size = new System.Drawing.Size(113, 23);
            this.dtpDeliverDate.TabIndex = 2;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(289, 200);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(82, 23);
            this.txtZip.TabIndex = 0;
            this.txtZip.Text = "Zip";
            this.txtZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboEmployees
            // 
            this.cboEmployees.FormattingEnabled = true;
            this.cboEmployees.Location = new System.Drawing.Point(68, 246);
            this.cboEmployees.Name = "cboEmployees";
            this.cboEmployees.Size = new System.Drawing.Size(147, 23);
            this.cboEmployees.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Driver";
            // 
            // txtItemCount
            // 
            this.txtItemCount.Location = new System.Drawing.Point(300, 246);
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.Size = new System.Drawing.Size(71, 23);
            this.txtItemCount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Count";
            // 
            // btnPrintPackList
            // 
            this.btnPrintPackList.Location = new System.Drawing.Point(23, 285);
            this.btnPrintPackList.Name = "btnPrintPackList";
            this.btnPrintPackList.Size = new System.Drawing.Size(166, 36);
            this.btnPrintPackList.TabIndex = 7;
            this.btnPrintPackList.Text = "Print";
            this.btnPrintPackList.UseVisualStyleBackColor = true;
            // 
            // btnOpenPackingList
            // 
            this.btnOpenPackingList.Location = new System.Drawing.Point(208, 19);
            this.btnOpenPackingList.Name = "btnOpenPackingList";
            this.btnOpenPackingList.Size = new System.Drawing.Size(57, 23);
            this.btnOpenPackingList.TabIndex = 1;
            this.btnOpenPackingList.Text = "Open";
            this.btnOpenPackingList.UseVisualStyleBackColor = true;
            // 
            // txtOpenListID
            // 
            this.txtOpenListID.Location = new System.Drawing.Point(271, 19);
            this.txtOpenListID.Name = "txtOpenListID";
            this.txtOpenListID.Size = new System.Drawing.Size(100, 23);
            this.txtOpenListID.TabIndex = 8;
            // 
            // PackingListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOpenListID);
            this.Controls.Add(this.btnPrintPackList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmployees);
            this.Controls.Add(this.dtpDeliverDate);
            this.Controls.Add(this.btnOpenPackingList);
            this.Controls.Add(this.btnNewPackingList);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPackingListID);
            this.Controls.Add(this.txtJobName);
            this.Name = "PackingListControl";
            this.Size = new System.Drawing.Size(390, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Button btnNewPackingList;
        private System.Windows.Forms.TextBox txtPackingListID;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.DateTimePicker dtpDeliverDate;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.ComboBox cboEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintPackList;
        private System.Windows.Forms.Button btnOpenPackingList;
        private System.Windows.Forms.TextBox txtOpenListID;
    }
}
