namespace PrivateIsland_Client
{
    partial class ExceptionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionFrm));
            this.WindowContainer = new System.Windows.Forms.Panel();
            this.ExceptionMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.WindowContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowContainer
            // 
            this.WindowContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.WindowContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WindowContainer.Controls.Add(this.ExceptionMessage);
            this.WindowContainer.Controls.Add(this.label1);
            this.WindowContainer.Controls.Add(this.CloseBtn);
            this.WindowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowContainer.Location = new System.Drawing.Point(0, 0);
            this.WindowContainer.Name = "WindowContainer";
            this.WindowContainer.Padding = new System.Windows.Forms.Padding(20, 25, 0, 0);
            this.WindowContainer.Size = new System.Drawing.Size(487, 348);
            this.WindowContainer.TabIndex = 8;
            this.WindowContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowContainer_MouseDown);
            // 
            // ExceptionMessage
            // 
            this.ExceptionMessage.BackColor = System.Drawing.Color.Transparent;
            this.ExceptionMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExceptionMessage.Font = new System.Drawing.Font("Yu Gothic", 11.55F);
            this.ExceptionMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.ExceptionMessage.Location = new System.Drawing.Point(20, 50);
            this.ExceptionMessage.Name = "ExceptionMessage";
            this.ExceptionMessage.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.ExceptionMessage.Size = new System.Drawing.Size(465, 296);
            this.ExceptionMessage.TabIndex = 0;
            this.ExceptionMessage.Text = "The PrivateIsland client ran into an error.\r\n\r\nDetailed information:\r\n[exception_" +
    "details]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Something went wrong";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.AutoSize = true;
            this.CloseBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Segoe UI", 6.75F);
            this.CloseBtn.Location = new System.Drawing.Point(445, 2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(37, 22);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ExceptionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(487, 348);
            this.Controls.Add(this.WindowContainer);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExceptionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExceptionFrm";
            this.WindowContainer.ResumeLayout(false);
            this.WindowContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WindowContainer;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label ExceptionMessage;
        private System.Windows.Forms.Label label1;
    }
}