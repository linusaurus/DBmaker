using System.Drawing;

namespace DeliveryWeasel
{
    partial class MainForm
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
            this.sstpMainStatusBar = new System.Windows.Forms.StatusStrip();
            this.tspMainTooBar = new System.Windows.Forms.ToolStrip();
            this.spcMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tbcWorkSurface = new System.Windows.Forms.TabControl();
            this.tbJobProducts = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.spcMainSplitContainer)).BeginInit();
            this.spcMainSplitContainer.Panel2.SuspendLayout();
            this.spcMainSplitContainer.SuspendLayout();
            this.tbcWorkSurface.SuspendLayout();
            this.SuspendLayout();
            // 
            // sstpMainStatusBar
            // 
            this.sstpMainStatusBar.Location = new System.Drawing.Point(0, 699);
            this.sstpMainStatusBar.Name = "sstpMainStatusBar";
            this.sstpMainStatusBar.Size = new System.Drawing.Size(1165, 22);
            this.sstpMainStatusBar.TabIndex = 0;
            this.sstpMainStatusBar.Text = "statusStrip1";
            // 
            // tspMainTooBar
            // 
            this.tspMainTooBar.Location = new System.Drawing.Point(0, 0);
            this.tspMainTooBar.Name = "tspMainTooBar";
            this.tspMainTooBar.Size = new System.Drawing.Size(1165, 25);
            this.tspMainTooBar.TabIndex = 1;
            this.tspMainTooBar.Text = "toolStrip1";
            this.tspMainTooBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tspMainTooBar_ItemClicked);
            // 
            // spcMainSplitContainer
            // 
            this.spcMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMainSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.spcMainSplitContainer.Name = "spcMainSplitContainer";
            // 
            // spcMainSplitContainer.Panel2
            // 
            this.spcMainSplitContainer.Panel2.Controls.Add(this.tbcWorkSurface);
            this.spcMainSplitContainer.Size = new System.Drawing.Size(1165, 674);
            this.spcMainSplitContainer.SplitterDistance = 300;
            this.spcMainSplitContainer.TabIndex = 2;
            this.spcMainSplitContainer.Text = "splitContainer1";
            // 
            // tbcWorkSurface
            // 
            this.tbcWorkSurface.Controls.Add(this.tbJobProducts);
            this.tbcWorkSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcWorkSurface.ItemSize = new System.Drawing.Size(80, 20);
            this.tbcWorkSurface.Location = new System.Drawing.Point(0, 0);
            this.tbcWorkSurface.Name = "tbcWorkSurface";
            this.tbcWorkSurface.SelectedIndex = 0;
            this.tbcWorkSurface.Size = new System.Drawing.Size(861, 674);
            this.tbcWorkSurface.TabIndex = 0;
            this.tbcWorkSurface.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tbcWorkSurface_DrawItem);
            this.tbcWorkSurface.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbcWorkSurface_MouseClick);
            // 
            // tbJobProducts
            // 
            this.tbJobProducts.Location = new System.Drawing.Point(4, 24);
            this.tbJobProducts.Name = "tbJobProducts";
            this.tbJobProducts.Size = new System.Drawing.Size(853, 646);
            this.tbJobProducts.TabIndex = 0;
            this.tbJobProducts.Text = "Job Products";
            this.tbJobProducts.Click += new System.EventHandler(this.tbJobProducts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 721);
            this.Controls.Add(this.spcMainSplitContainer);
            this.Controls.Add(this.tspMainTooBar);
            this.Controls.Add(this.sstpMainStatusBar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.spcMainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMainSplitContainer)).EndInit();
            this.spcMainSplitContainer.ResumeLayout(false);
            this.tbcWorkSurface.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);
        Image closeImage;

        private System.Windows.Forms.StatusStrip sstpMainStatusBar;
        private System.Windows.Forms.ToolStrip tspMainTooBar;
        private System.Windows.Forms.SplitContainer spcMainSplitContainer;
        private System.Windows.Forms.TabControl tbcWorkSurface;
        private System.Windows.Forms.TabPage tbJobProducts;
    }
}