using System.Windows.Forms;

namespace DeliveryWeasel.UserControls
{
    partial class DeliveryManager
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
            this.spcDeliveryItems = new System.Windows.Forms.SplitContainer();
            this.dgProductGrid = new System.Windows.Forms.DataGridView();
            this.tbMiscItems = new System.Windows.Forms.TabControl();
            this.tbpSubAssemblies = new System.Windows.Forms.TabPage();
            this.dgSubAssemblies = new System.Windows.Forms.DataGridView();
            this.tbDeliveryItems = new System.Windows.Forms.TabPage();
            this.dgDeliveryItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spcDeliveryItems)).BeginInit();
            this.spcDeliveryItems.Panel1.SuspendLayout();
            this.spcDeliveryItems.Panel2.SuspendLayout();
            this.spcDeliveryItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductGrid)).BeginInit();
            this.tbMiscItems.SuspendLayout();
            this.tbpSubAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubAssemblies)).BeginInit();
            this.tbDeliveryItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryItems)).BeginInit();
            this.SuspendLayout();
            // 
            // spcDeliveryItems
            // 
            this.spcDeliveryItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDeliveryItems.Location = new System.Drawing.Point(0, 0);
            this.spcDeliveryItems.Name = "spcDeliveryItems";
            this.spcDeliveryItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcDeliveryItems.Panel1
            // 
            this.spcDeliveryItems.Panel1.Controls.Add(this.dgProductGrid);
            this.spcDeliveryItems.Panel1.Padding = new System.Windows.Forms.Padding(6);
            // 
            // spcDeliveryItems.Panel2
            // 
            this.spcDeliveryItems.Panel2.Controls.Add(this.tbMiscItems);
            this.spcDeliveryItems.Panel2.Padding = new System.Windows.Forms.Padding(6);
            this.spcDeliveryItems.Size = new System.Drawing.Size(955, 653);
            this.spcDeliveryItems.SplitterDistance = 250;
            this.spcDeliveryItems.TabIndex = 0;
            this.spcDeliveryItems.Text = "splitContainer1";
            // 
            // dgProductGrid
            // 
            this.dgProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProductGrid.Location = new System.Drawing.Point(6, 6);
            this.dgProductGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgProductGrid.Name = "dgProductGrid";
            this.dgProductGrid.Size = new System.Drawing.Size(943, 238);
            this.dgProductGrid.TabIndex = 0;
            // 
            // tbMiscItems
            // 
            this.tbMiscItems.Controls.Add(this.tbpSubAssemblies);
            this.tbMiscItems.Controls.Add(this.tbDeliveryItems);
            this.tbMiscItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMiscItems.Location = new System.Drawing.Point(6, 6);
            this.tbMiscItems.Name = "tbMiscItems";
            this.tbMiscItems.SelectedIndex = 0;
            this.tbMiscItems.Size = new System.Drawing.Size(943, 387);
            this.tbMiscItems.TabIndex = 1;
            this.tbMiscItems.SelectedIndexChanged += new System.EventHandler(this.tbMiscItems_SelectedIndexChanged);
            // 
            // tbpSubAssemblies
            // 
            this.tbpSubAssemblies.Controls.Add(this.dgSubAssemblies);
            this.tbpSubAssemblies.Location = new System.Drawing.Point(4, 24);
            this.tbpSubAssemblies.Name = "tbpSubAssemblies";
            this.tbpSubAssemblies.Padding = new System.Windows.Forms.Padding(6);
            this.tbpSubAssemblies.Size = new System.Drawing.Size(935, 359);
            this.tbpSubAssemblies.TabIndex = 0;
            this.tbpSubAssemblies.Text = "SubAssemblies";
            this.tbpSubAssemblies.UseVisualStyleBackColor = true;
            // 
            // dgSubAssemblies
            // 
            this.dgSubAssemblies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubAssemblies.Location = new System.Drawing.Point(6, 6);
            this.dgSubAssemblies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgSubAssemblies.Name = "dgSubAssemblies";
            this.dgSubAssemblies.Size = new System.Drawing.Size(923, 347);
            this.dgSubAssemblies.TabIndex = 0;
            // 
            // tbDeliveryItems
            // 
            this.tbDeliveryItems.Controls.Add(this.dgDeliveryItems);
            this.tbDeliveryItems.Location = new System.Drawing.Point(4, 24);
            this.tbDeliveryItems.Name = "tbDeliveryItems";
            this.tbDeliveryItems.Padding = new System.Windows.Forms.Padding(6);
            this.tbDeliveryItems.Size = new System.Drawing.Size(935, 359);
            this.tbDeliveryItems.TabIndex = 1;
            this.tbDeliveryItems.Text = "Delivery Items";
            this.tbDeliveryItems.UseVisualStyleBackColor = true;
            // 
            // dgDeliveryItems
            // 
            this.dgDeliveryItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDeliveryItems.Location = new System.Drawing.Point(6, 6);
            this.dgDeliveryItems.Name = "dgDeliveryItems";
            this.dgDeliveryItems.Size = new System.Drawing.Size(923, 347);
            this.dgDeliveryItems.TabIndex = 0;
            // 
            // DeliveryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcDeliveryItems);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DeliveryManager";
            this.Size = new System.Drawing.Size(955, 653);
            this.spcDeliveryItems.Panel1.ResumeLayout(false);
            this.spcDeliveryItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDeliveryItems)).EndInit();
            this.spcDeliveryItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductGrid)).EndInit();
            this.tbMiscItems.ResumeLayout(false);
            this.tbpSubAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubAssemblies)).EndInit();
            this.tbDeliveryItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveryItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcDeliveryItems;
        private DataGridView dgSubAssemblies;
        private DataGridView dgProductGrid;
        private TabControl tbMiscItems;
        private TabPage tbpSubAssemblies;
        private TabPage tbDeliveryItems;
        private DataGridView dgDeliveryItems;
    }
}
