namespace UHFReader
{
    partial class CertificationForm
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
            this.MTITLE_label = new System.Windows.Forms.Label();
            this.LOGIN_label = new System.Windows.Forms.Label();
            this.PW_textBox = new System.Windows.Forms.TextBox();
            this.SIX_label = new System.Windows.Forms.Label();
            this.CTF_label = new System.Windows.Forms.Label();
            this.CTF_textBox = new System.Windows.Forms.TextBox();
            this.TBYTE_label = new System.Windows.Forms.Label();
            this.MPW_textBox = new System.Windows.Forms.TextBox();
            this.MANAGER_button = new System.Windows.Forms.Button();
            this.SIX2_label = new System.Windows.Forms.Label();
            this.SET_button = new System.Windows.Forms.Button();
            this.QUERY_button = new System.Windows.Forms.Button();
            this.INFO_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MTITLE_label
            // 
            this.MTITLE_label.AutoSize = true;
            this.MTITLE_label.Location = new System.Drawing.Point(171, 34);
            this.MTITLE_label.Name = "MTITLE_label";
            this.MTITLE_label.Size = new System.Drawing.Size(167, 12);
            this.MTITLE_label.TabIndex = 0;
            this.MTITLE_label.Text = "请输入(6位)标签认证管理密码";
            // 
            // LOGIN_label
            // 
            this.LOGIN_label.AutoSize = true;
            this.LOGIN_label.Location = new System.Drawing.Point(114, 75);
            this.LOGIN_label.Name = "LOGIN_label";
            this.LOGIN_label.Size = new System.Drawing.Size(59, 12);
            this.LOGIN_label.TabIndex = 1;
            this.LOGIN_label.Text = "登录密码:";
            // 
            // PW_textBox
            // 
            this.PW_textBox.Location = new System.Drawing.Point(205, 69);
            this.PW_textBox.Name = "PW_textBox";
            this.PW_textBox.Size = new System.Drawing.Size(100, 21);
            this.PW_textBox.TabIndex = 2;
            // 
            // SIX_label
            // 
            this.SIX_label.AutoSize = true;
            this.SIX_label.Location = new System.Drawing.Point(334, 75);
            this.SIX_label.Name = "SIX_label";
            this.SIX_label.Size = new System.Drawing.Size(71, 12);
            this.SIX_label.TabIndex = 3;
            this.SIX_label.Text = "(6 Numbers)";
            // 
            // CTF_label
            // 
            this.CTF_label.AutoSize = true;
            this.CTF_label.Location = new System.Drawing.Point(102, 125);
            this.CTF_label.Name = "CTF_label";
            this.CTF_label.Size = new System.Drawing.Size(71, 12);
            this.CTF_label.TabIndex = 4;
            this.CTF_label.Text = "标签认证码:";
            // 
            // CTF_textBox
            // 
            this.CTF_textBox.Location = new System.Drawing.Point(205, 122);
            this.CTF_textBox.Name = "CTF_textBox";
            this.CTF_textBox.Size = new System.Drawing.Size(100, 21);
            this.CTF_textBox.TabIndex = 5;
            // 
            // TBYTE_label
            // 
            this.TBYTE_label.AutoSize = true;
            this.TBYTE_label.Location = new System.Drawing.Point(334, 125);
            this.TBYTE_label.Name = "TBYTE_label";
            this.TBYTE_label.Size = new System.Drawing.Size(53, 12);
            this.TBYTE_label.TabIndex = 6;
            this.TBYTE_label.Text = "(2 byte)";
            // 
            // MPW_textBox
            // 
            this.MPW_textBox.Location = new System.Drawing.Point(109, 95);
            this.MPW_textBox.MaxLength = 6;
            this.MPW_textBox.Name = "MPW_textBox";
            this.MPW_textBox.PasswordChar = '*';
            this.MPW_textBox.Size = new System.Drawing.Size(100, 21);
            this.MPW_textBox.TabIndex = 7;
            this.MPW_textBox.Text = "111111";
            this.MPW_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MPW_textBox_KeyPress);
            // 
            // MANAGER_button
            // 
            this.MANAGER_button.Location = new System.Drawing.Point(237, 95);
            this.MANAGER_button.Name = "MANAGER_button";
            this.MANAGER_button.Size = new System.Drawing.Size(75, 23);
            this.MANAGER_button.TabIndex = 8;
            this.MANAGER_button.Text = "开始管理";
            this.MANAGER_button.UseVisualStyleBackColor = true;
            this.MANAGER_button.Click += new System.EventHandler(this.MANAGER_button_Click);
            // 
            // SIX2_label
            // 
            this.SIX2_label.AutoSize = true;
            this.SIX2_label.Location = new System.Drawing.Point(329, 100);
            this.SIX2_label.Name = "SIX2_label";
            this.SIX2_label.Size = new System.Drawing.Size(71, 12);
            this.SIX2_label.TabIndex = 9;
            this.SIX2_label.Text = "(6 Numbers)";
            // 
            // SET_button
            // 
            this.SET_button.Location = new System.Drawing.Point(104, 174);
            this.SET_button.Name = "SET_button";
            this.SET_button.Size = new System.Drawing.Size(75, 23);
            this.SET_button.TabIndex = 10;
            this.SET_button.Text = "设置";
            this.SET_button.UseVisualStyleBackColor = true;
            this.SET_button.Click += new System.EventHandler(this.SET_button_Click);
            // 
            // QUERY_button
            // 
            this.QUERY_button.Location = new System.Drawing.Point(312, 174);
            this.QUERY_button.Name = "QUERY_button";
            this.QUERY_button.Size = new System.Drawing.Size(75, 23);
            this.QUERY_button.TabIndex = 11;
            this.QUERY_button.Text = "查询";
            this.QUERY_button.UseVisualStyleBackColor = true;
            this.QUERY_button.Click += new System.EventHandler(this.QUERY_button_Click);
            // 
            // INFO_label
            // 
            this.INFO_label.AutoSize = true;
            this.INFO_label.Location = new System.Drawing.Point(107, 149);
            this.INFO_label.Name = "INFO_label";
            this.INFO_label.Size = new System.Drawing.Size(0, 12);
            this.INFO_label.TabIndex = 12;
            // 
            // CertificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 229);
            this.Controls.Add(this.INFO_label);
            this.Controls.Add(this.QUERY_button);
            this.Controls.Add(this.SET_button);
            this.Controls.Add(this.SIX2_label);
            this.Controls.Add(this.MANAGER_button);
            this.Controls.Add(this.MPW_textBox);
            this.Controls.Add(this.TBYTE_label);
            this.Controls.Add(this.CTF_textBox);
            this.Controls.Add(this.CTF_label);
            this.Controls.Add(this.SIX_label);
            this.Controls.Add(this.PW_textBox);
            this.Controls.Add(this.LOGIN_label);
            this.Controls.Add(this.MTITLE_label);
            this.Name = "CertificationForm";
            this.Text = "标签认证";
            this.Load += new System.EventHandler(this.CertificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MTITLE_label;
        private System.Windows.Forms.Label LOGIN_label;
        private System.Windows.Forms.TextBox PW_textBox;
        private System.Windows.Forms.Label SIX_label;
        private System.Windows.Forms.Label CTF_label;
        private System.Windows.Forms.TextBox CTF_textBox;
        private System.Windows.Forms.Label TBYTE_label;
        private System.Windows.Forms.TextBox MPW_textBox;
        private System.Windows.Forms.Button MANAGER_button;
        private System.Windows.Forms.Label SIX2_label;
        private System.Windows.Forms.Button SET_button;
        private System.Windows.Forms.Button QUERY_button;
        private System.Windows.Forms.Label INFO_label;
    }
}