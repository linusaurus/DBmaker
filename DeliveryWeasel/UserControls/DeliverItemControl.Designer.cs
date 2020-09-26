namespace DeliveryWeasel.UserControls
{
    partial class DeliverItemControl
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
            this.spcMainContainer = new System.Windows.Forms.SplitContainer();
            this.spcSubContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.spcMainContainer)).BeginInit();
            this.spcMainContainer.Panel2.SuspendLayout();
            this.spcMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSubContainer)).BeginInit();
            this.spcSubContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMainContainer
            // 
            this.spcMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMainContainer.Location = new System.Drawing.Point(6, 6);
            this.spcMainContainer.Name = "spcMainContainer";
            this.spcMainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMainContainer.Panel2
            // 
            this.spcMainContainer.Panel2.Controls.Add(this.spcSubContainer);
            this.spcMainContainer.Size = new System.Drawing.Size(1156, 717);
            this.spcMainContainer.SplitterDistance = 200;
            this.spcMainContainer.TabIndex = 0;
            this.spcMainContainer.Text = "splitContainer1";
            // 
            // spcSubContainer
            // 
            this.spcSubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSubContainer.Location = new System.Drawing.Point(0, 0);
            this.spcSubContainer.Name = "spcSubContainer";
            this.spcSubContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.spcSubContainer.Size = new System.Drawing.Size(1156, 513);
            this.spcSubContainer.SplitterDistance = 250;
            this.spcSubContainer.TabIndex = 0;
            this.spcSubContainer.Text = "splitContainer1";
            // 
            // DeliverItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMainContainer);
            this.Name = "DeliverItemControl";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(1168, 729);
            this.spcMainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMainContainer)).EndInit();
            this.spcMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSubContainer)).EndInit();
            this.spcSubContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMainContainer;
        private System.Windows.Forms.SplitContainer spcSubContainer;
    }
}
