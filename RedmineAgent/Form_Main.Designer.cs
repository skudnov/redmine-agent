namespace RedmineAgent
{
    partial class Form_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_newproject = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_newissue = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_apikey = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_project = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_issue = new System.Windows.Forms.ListView();
            this.ch_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_tracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mi_info = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.входToolStripMenuItem,
            this.mi_update});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(464, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_newproject,
            this.mi_newissue,
            this.mi_info,
            this.mi_exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mi_newproject
            // 
            this.mi_newproject.Enabled = false;
            this.mi_newproject.Name = "mi_newproject";
            this.mi_newproject.Size = new System.Drawing.Size(216, 22);
            this.mi_newproject.Text = "Новый проект";
            // 
            // mi_newissue
            // 
            this.mi_newissue.Enabled = false;
            this.mi_newissue.Name = "mi_newissue";
            this.mi_newissue.Size = new System.Drawing.Size(216, 22);
            this.mi_newissue.Text = "Новая задача";
            // 
            // mi_exit
            // 
            this.mi_exit.Name = "mi_exit";
            this.mi_exit.Size = new System.Drawing.Size(216, 22);
            this.mi_exit.Text = "Выход из программы";
            this.mi_exit.Click += new System.EventHandler(this.mi_exit_Click);
            // 
            // входToolStripMenuItem
            // 
            this.входToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_apikey});
            this.входToolStripMenuItem.Name = "входToolStripMenuItem";
            this.входToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.входToolStripMenuItem.Text = "Вход";
            // 
            // mi_apikey
            // 
            this.mi_apikey.Name = "mi_apikey";
            this.mi_apikey.Size = new System.Drawing.Size(158, 22);
            this.mi_apikey.Text = "Вход по api-key";
            this.mi_apikey.Click += new System.EventHandler(this.mi_apikey_Click);
            // 
            // mi_update
            // 
            this.mi_update.Name = "mi_update";
            this.mi_update.Size = new System.Drawing.Size(73, 20);
            this.mi_update.Text = "Обновить";
            this.mi_update.Click += new System.EventHandler(this.mi_update_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_project);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проекты:";
            // 
            // cb_project
            // 
            this.cb_project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_project.FormattingEnabled = true;
            this.cb_project.Items.AddRange(new object[] {
            "Выберите проект..."});
            this.cb_project.Location = new System.Drawing.Point(6, 19);
            this.cb_project.Name = "cb_project";
            this.cb_project.Size = new System.Drawing.Size(215, 21);
            this.cb_project.TabIndex = 0;
            this.cb_project.SelectedIndexChanged += new System.EventHandler(this.cb_project_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_issue);
            this.groupBox2.Location = new System.Drawing.Point(13, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 298);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задачи:";
            // 
            // lv_issue
            // 
            this.lv_issue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_name,
            this.ch_tracker,
            this.ch_status,
            this.ch_created});
            this.lv_issue.Location = new System.Drawing.Point(7, 20);
            this.lv_issue.Name = "lv_issue";
            this.lv_issue.Size = new System.Drawing.Size(429, 272);
            this.lv_issue.TabIndex = 0;
            this.lv_issue.UseCompatibleStateImageBehavior = false;
            this.lv_issue.View = System.Windows.Forms.View.Details;
            // 
            // ch_name
            // 
            this.ch_name.Text = "Название задачи";
            this.ch_name.Width = 109;
            // 
            // ch_tracker
            // 
            this.ch_tracker.Text = "Трекер";
            this.ch_tracker.Width = 64;
            // 
            // ch_status
            // 
            this.ch_status.Text = "Статус";
            // 
            // ch_created
            // 
            this.ch_created.Text = "Обновлено";
            this.ch_created.Width = 94;
            // 
            // mi_info
            // 
            this.mi_info.Enabled = false;
            this.mi_info.Name = "mi_info";
            this.mi_info.Size = new System.Drawing.Size(216, 22);
            this.mi_info.Text = "Информация об аккаунте";
            this.mi_info.Click += new System.EventHandler(this.mi_info_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redmine Agent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_newproject;
        private System.Windows.Forms.ToolStripMenuItem mi_newissue;
        private System.Windows.Forms.ToolStripMenuItem mi_exit;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_apikey;
        private System.Windows.Forms.ToolStripMenuItem mi_update;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_project;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_issue;
        private System.Windows.Forms.ColumnHeader ch_name;
        private System.Windows.Forms.ColumnHeader ch_tracker;
        private System.Windows.Forms.ColumnHeader ch_status;
        private System.Windows.Forms.ColumnHeader ch_created;
        private System.Windows.Forms.ToolStripMenuItem mi_info;

    }
}

