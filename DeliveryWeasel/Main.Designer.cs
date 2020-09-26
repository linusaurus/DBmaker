namespace DeliveryWeasel
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgProductGrid = new System.Windows.Forms.DataGridView();
            this.spcProducts = new System.Windows.Forms.SplitContainer();
            this.dgDeliverItems = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.spcMainVertical = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcProducts)).BeginInit();
            this.spcProducts.Panel1.SuspendLayout();
            this.spcProducts.Panel2.SuspendLayout();
            this.spcProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliverItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMainVertical)).BeginInit();
            this.spcMainVertical.Panel2.SuspendLayout();
            this.spcMainVertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(251, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // dgProductGrid
            // 
            this.dgProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProductGrid.Location = new System.Drawing.Point(0, 0);
            this.dgProductGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgProductGrid.Name = "dgProductGrid";
            this.dgProductGrid.Size = new System.Drawing.Size(786, 310);
            this.dgProductGrid.TabIndex = 0;
            // 
            // spcProducts
            // 
            this.spcProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProducts.Location = new System.Drawing.Point(0, 0);
            this.spcProducts.Name = "spcProducts";
            this.spcProducts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcProducts.Panel1
            // 
            this.spcProducts.Panel1.Controls.Add(this.dgProductGrid);
            // 
            // spcProducts.Panel2
            // 
            this.spcProducts.Panel2.Controls.Add(this.dgDeliverItems);
            this.spcProducts.Size = new System.Drawing.Size(786, 622);
            this.spcProducts.SplitterDistance = 310;
            this.spcProducts.TabIndex = 1;
            this.spcProducts.Text = "splitContainer1";
            // 
            // dgDeliverItems
            // 
            this.dgDeliverItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliverItems.Location = new System.Drawing.Point(0, 0);
            this.dgDeliverItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgDeliverItems.Name = "dgDeliverItems";
            this.dgDeliverItems.Size = new System.Drawing.Size(786, 308);
            this.dgDeliverItems.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1225, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 669);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveChanges);
            // 
            // spcMainVertical
            // 
            this.spcMainVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMainVertical.Location = new System.Drawing.Point(12, 41);
            this.spcMainVertical.Name = "spcMainVertical";
            // 
            // spcMainVertical.Panel2
            // 
            this.spcMainVertical.Panel2.Controls.Add(this.spcProducts);
            this.spcMainVertical.Size = new System.Drawing.Size(1184, 622);
            this.spcMainVertical.SplitterDistance = 394;
            this.spcMainVertical.TabIndex = 4;
            this.spcMainVertical.Text = "splitContainer1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 736);
            this.Controls.Add(this.spcMainVertical);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Main";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgProductGrid)).EndInit();
            this.spcProducts.Panel1.ResumeLayout(false);
            this.spcProducts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcProducts)).EndInit();
            this.spcProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliverItems)).EndInit();
            this.spcMainVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMainVertical)).EndInit();
            this.spcMainVertical.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgDeliverItems;
        private System.Windows.Forms.DataGridView dgProductGrid;
        private System.Windows.Forms.SplitContainer spcProducts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer spcMainVertical;
    }
}

