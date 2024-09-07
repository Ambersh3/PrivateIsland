namespace PrivateIsland_Client
{
    partial class PerformanceMonitorWidget
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceMonitorWidget));
            this.StatsTxt = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.HideWidgetForeverBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity20 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity40 = new System.Windows.Forms.ToolStripMenuItem();
            this.Opacity60 = new System.Windows.Forms.ToolStripMenuItem();
            this.PerformanceMonitorWorker = new System.Windows.Forms.Timer(this.components);
            this.Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatsTxt
            // 
            this.StatsTxt.ContextMenuStrip = this.Options;
            this.StatsTxt.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.StatsTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatsTxt.Font = new System.Drawing.Font("Verdana", 8F);
            this.StatsTxt.Location = new System.Drawing.Point(0, 0);
            this.StatsTxt.Name = "StatsTxt";
            this.StatsTxt.Padding = new System.Windows.Forms.Padding(5);
            this.StatsTxt.Size = new System.Drawing.Size(120, 27);
            this.StatsTxt.TabIndex = 0;
            this.StatsTxt.Text = "Loading...";
            this.StatsTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatsTxt.Click += new System.EventHandler(this.StatsTxt_Click);
            this.StatsTxt.DoubleClick += new System.EventHandler(this.StatsTxt_DoubleClick);
            this.StatsTxt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatsTxt_MouseDown);
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.Black;
            this.Options.DropShadowEnabled = false;
            this.Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseBtn,
            this.opacityToolStripMenuItem});
            this.Options.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.Options.Name = "Options";
            this.Options.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Options.ShowImageMargin = false;
            this.Options.Size = new System.Drawing.Size(118, 48);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.Black;
            this.CloseBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideWidgetForeverBtn});
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(117, 22);
            this.CloseBtn.Text = "Close widget";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // HideWidgetForeverBtn
            // 
            this.HideWidgetForeverBtn.BackColor = System.Drawing.Color.White;
            this.HideWidgetForeverBtn.ForeColor = System.Drawing.Color.Black;
            this.HideWidgetForeverBtn.Name = "HideWidgetForeverBtn";
            this.HideWidgetForeverBtn.Size = new System.Drawing.Size(168, 22);
            this.HideWidgetForeverBtn.Text = "Never show again";
            this.HideWidgetForeverBtn.Click += new System.EventHandler(this.HideWidgetForeverBtn_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opacity20,
            this.Opacity40,
            this.Opacity60});
            this.opacityToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.opacityToolStripMenuItem.Text = "Opacity";
            // 
            // Opacity20
            // 
            this.Opacity20.BackColor = System.Drawing.Color.White;
            this.Opacity20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity20.ForeColor = System.Drawing.Color.Black;
            this.Opacity20.Name = "Opacity20";
            this.Opacity20.Size = new System.Drawing.Size(96, 22);
            this.Opacity20.Text = "20%";
            this.Opacity20.Click += new System.EventHandler(this.Opacity20_Click);
            // 
            // Opacity40
            // 
            this.Opacity40.BackColor = System.Drawing.Color.White;
            this.Opacity40.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity40.ForeColor = System.Drawing.Color.Black;
            this.Opacity40.Name = "Opacity40";
            this.Opacity40.Size = new System.Drawing.Size(96, 22);
            this.Opacity40.Text = "40%";
            this.Opacity40.Click += new System.EventHandler(this.Opacity40_Click);
            // 
            // Opacity60
            // 
            this.Opacity60.BackColor = System.Drawing.Color.White;
            this.Opacity60.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Opacity60.ForeColor = System.Drawing.Color.Black;
            this.Opacity60.Name = "Opacity60";
            this.Opacity60.Size = new System.Drawing.Size(96, 22);
            this.Opacity60.Text = "60%";
            this.Opacity60.Click += new System.EventHandler(this.Opacity60_Click);
            // 
            // PerformanceMonitorWorker
            // 
            this.PerformanceMonitorWorker.Enabled = true;
            this.PerformanceMonitorWorker.Interval = 2000;
            this.PerformanceMonitorWorker.Tick += new System.EventHandler(this.PerformanceMonitorWorker_Tick);
            // 
            // PerformanceMonitorWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 27);
            this.ContextMenuStrip = this.Options;
            this.Controls.Add(this.StatsTxt);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerformanceMonitorWidget";
            this.Opacity = 0.2D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PerformanceMonitorWidget";
            this.TopMost = true;
            this.Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StatsTxt;
        private System.Windows.Forms.Timer PerformanceMonitorWorker;
        private System.Windows.Forms.ContextMenuStrip Options;
        private System.Windows.Forms.ToolStripMenuItem CloseBtn;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Opacity20;
        private System.Windows.Forms.ToolStripMenuItem Opacity60;
        private System.Windows.Forms.ToolStripMenuItem Opacity40;
        private System.Windows.Forms.ToolStripMenuItem HideWidgetForeverBtn;
    }
}