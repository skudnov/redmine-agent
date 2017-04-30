namespace RedmineAgent
{
    partial class Form_HistoryIssue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HistoryIssue));
            this.lv_history = new System.Windows.Forms.ListView();
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lv_history
            // 
            this.lv_history.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_name,
            this.ch_date,
            this.ch_created});
            this.lv_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_history.FullRowSelect = true;
            this.lv_history.Location = new System.Drawing.Point(0, 0);
            this.lv_history.Name = "lv_history";
            this.lv_history.Size = new System.Drawing.Size(528, 348);
            this.lv_history.TabIndex = 0;
            this.lv_history.UseCompatibleStateImageBehavior = false;
            this.lv_history.View = System.Windows.Forms.View.Details;
            this.lv_history.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_history_ColumnClick);
            // 
            // ch_name
            // 
            this.ch_name.Text = "Изменил";
            this.ch_name.Width = 101;
            // 
            // ch_date
            // 
            this.ch_date.Text = "Дата изменения";
            this.ch_date.Width = 136;
            // 
            // ch_created
            // 
            this.ch_created.Text = "Изменение";
            this.ch_created.Width = 269;
            // 
            // Form_HistoryIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 348);
            this.Controls.Add(this.lv_history);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(544, 387);
            this.Name = "Form_HistoryIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "История задачи";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_history;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.ColumnHeader ch_date;
        private System.Windows.Forms.ColumnHeader ch_created;
    }
}