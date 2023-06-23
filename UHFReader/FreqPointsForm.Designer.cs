namespace UHFReader
{
    partial class FreqPointsForm
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
            this.FreqPoints_treeView = new System.Windows.Forms.TreeView();
            this.Add_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FreqPoints_treeView
            // 
            this.FreqPoints_treeView.Location = new System.Drawing.Point(13, 13);
            this.FreqPoints_treeView.Name = "FreqPoints_treeView";
            this.FreqPoints_treeView.Size = new System.Drawing.Size(178, 237);
            this.FreqPoints_treeView.TabIndex = 0;
            this.FreqPoints_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.FreqPoints_treeView_AfterCheck);
            // 
            // Add_button
            // 
            this.Add_button.Location = new System.Drawing.Point(197, 186);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(75, 23);
            this.Add_button.TabIndex = 1;
            this.Add_button.Text = "添加";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(197, 227);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 2;
            this.Cancel_button.Text = "取消";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // FreqPointsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.FreqPoints_treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FreqPointsForm";
            this.Opacity = 0.8;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FreqPoints_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FreqPoints_treeView;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Cancel_button;
    }
}