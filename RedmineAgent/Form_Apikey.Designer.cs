namespace RedmineAgent
{
    partial class Form_Apikey
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_login = new System.Windows.Forms.Button();
            this.cbapikey = new System.Windows.Forms.CheckBox();
            this.tbapikey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_cancel);
            this.groupBox1.Controls.Add(this.bt_login);
            this.groupBox1.Controls.Add(this.cbapikey);
            this.groupBox1.Controls.Add(this.tbapikey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(218, 81);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 3;
            this.bt_cancel.Text = "Отмена";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(6, 81);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(75, 23);
            this.bt_login.TabIndex = 3;
            this.bt_login.Text = "ОК";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // cbapikey
            // 
            this.cbapikey.AutoSize = true;
            this.cbapikey.Checked = true;
            this.cbapikey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbapikey.Location = new System.Drawing.Point(82, 58);
            this.cbapikey.Name = "cbapikey";
            this.cbapikey.Size = new System.Drawing.Size(141, 17);
            this.cbapikey.TabIndex = 2;
            this.cbapikey.Text = "Оставаться в системе";
            this.cbapikey.UseVisualStyleBackColor = true;
            // 
            // tbapikey
            // 
            this.tbapikey.Location = new System.Drawing.Point(6, 32);
            this.tbapikey.Name = "tbapikey";
            this.tbapikey.Size = new System.Drawing.Size(287, 20);
            this.tbapikey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите api-key:";
            // 
            // Form_Apikey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 146);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Apikey";
            this.Text = "Вход";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.CheckBox cbapikey;
        private System.Windows.Forms.TextBox tbapikey;
        private System.Windows.Forms.Label label1;
    }
}