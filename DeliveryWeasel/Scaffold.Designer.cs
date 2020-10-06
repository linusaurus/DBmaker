namespace DeliveryWeasel
{
    partial class Scaffold
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scaffold));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Print = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1124, 640);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Print});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1124, 55);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Save
            // 
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(52, 52);
            this.Save.Text = "toolStripButton1";
            // 
            // Print
            // 
            this.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(52, 52);
            this.Print.Text = "toolStripButton2";
            // 
            // Scaffold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 668);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Scaffold";
            this.Text = "Scaffold";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripButton Print;
    }
}