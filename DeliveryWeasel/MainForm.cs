﻿using DeliveryWeasel.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DeliveryWeasel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            closeImage = Properties.Resources.twotone_highlight_off_black_18dp;    
            tbcWorkSurface.Padding = new System.Drawing.Point(16, 6);

            DeliveriesListControl delivControl = new DeliveriesListControl();

            spcMainSplitContainer.Panel1.Controls.Add(delivControl);
            delivControl.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tb = new TabPage("Test");
            PackingListControl ctl = new PackingListControl();
            tb.Controls.Add(ctl);
            ctl.Dock = DockStyle.Fill;
            this.tbcWorkSurface.TabPages.Add(tb);
      
        }

        private void tbcWorkSurface_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image img = new Bitmap(closeImage);
            Rectangle r = e.Bounds;
            r = this.tbcWorkSurface.GetTabRect(e.Index);
            r.Offset(2, 4);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tbcWorkSurface.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tbcWorkSurface.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }

        private void tbcWorkSurface_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tbcWorkSurface.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tbcWorkSurface.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 18;
            r.Height = 18;
            if (tbcWorkSurface.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    CloseActiveTab();
                }
            }
        }

        private void CloseActiveTab()
        {
            TabPage tabpage = tbcWorkSurface.SelectedTab;
            if (tbcWorkSurface.TabPages.Count > 1)
            {
               
                { tbcWorkSurface.TabPages.Remove(tabpage); }
            }
        }
    }
}
