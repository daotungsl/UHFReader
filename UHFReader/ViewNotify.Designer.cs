namespace UHFReader
{
    partial class ViewNotify
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoneFuel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.plnLpn = new System.Windows.Forms.Panel();
            this.lblLpnVeh = new System.Windows.Forms.Label();
            this.timeProgess = new System.Windows.Forms.Timer(this.components);
            this.timeVehOut = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timeEpc = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.plnLpn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDoneFuel);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.plnLpn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1880, 1017);
            this.panel1.TabIndex = 0;
            // 
            // btnDoneFuel
            // 
            this.btnDoneFuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDoneFuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoneFuel.Location = new System.Drawing.Point(139, 871);
            this.btnDoneFuel.Name = "btnDoneFuel";
            this.btnDoneFuel.Size = new System.Drawing.Size(387, 105);
            this.btnDoneFuel.TabIndex = 5;
            this.btnDoneFuel.Text = "ĐỔ XĂNG";
            this.btnDoneFuel.UseVisualStyleBackColor = false;
            this.btnDoneFuel.Visible = false;
            this.btnDoneFuel.Click += new System.EventHandler(this.btnDoneFuel_Click);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(1874, 264);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Xin chào PHẠM NGỌC HOÀI";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plnLpn
            // 
            this.plnLpn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(195)))), ((int)(((byte)(48)))));
            this.plnLpn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plnLpn.Controls.Add(this.lblLpnVeh);
            this.plnLpn.Location = new System.Drawing.Point(139, 344);
            this.plnLpn.Name = "plnLpn";
            this.plnLpn.Size = new System.Drawing.Size(1600, 401);
            this.plnLpn.TabIndex = 1;
            // 
            // lblLpnVeh
            // 
            this.lblLpnVeh.BackColor = System.Drawing.Color.White;
            this.lblLpnVeh.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLpnVeh.Location = new System.Drawing.Point(128, 114);
            this.lblLpnVeh.Name = "lblLpnVeh";
            this.lblLpnVeh.Size = new System.Drawing.Size(1350, 185);
            this.lblLpnVeh.TabIndex = 0;
            this.lblLpnVeh.Text = "SẴN SÀNG";
            this.lblLpnVeh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeProgess
            // 
            this.timeProgess.Enabled = true;
            this.timeProgess.Interval = 300;
            this.timeProgess.Tick += new System.EventHandler(this.timeProgess_Tick);
            // 
            // timeVehOut
            // 
            this.timeVehOut.Interval = 2000;
            this.timeVehOut.Tick += new System.EventHandler(this.timeVehOut_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 890);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 76);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // timeEpc
            // 
            this.timeEpc.Enabled = true;
            this.timeEpc.Tick += new System.EventHandler(this.timeEpc_Tick);
            // 
            // ViewNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Name = "ViewNotify";
            this.Text = "ViewNotify";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewNotify_FormClosed);
            this.Load += new System.EventHandler(this.CertificationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plnLpn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoneFuel;
        private System.Windows.Forms.Timer timeProgess;
        private System.Windows.Forms.Label lblLpnVeh;
        private System.Windows.Forms.Panel plnLpn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timeVehOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timeEpc;
    }
}