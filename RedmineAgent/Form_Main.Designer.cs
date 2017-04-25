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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_newissue = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_info = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_apikey = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_ifoprj = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_project = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_issue = new System.Windows.Forms.ListView();
            this.ch_subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_tracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_assigned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_updated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_role = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tm_infoIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_status = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_tracker = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_priority = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_apointed = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_history = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.входToolStripMenuItem,
            this.mi_update,
            this.mi_ifoprj});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(554, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_newissue,
            this.mi_info,
            this.mi_exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mi_newissue
            // 
            this.mi_newissue.Enabled = false;
            this.mi_newissue.Name = "mi_newissue";
            this.mi_newissue.Size = new System.Drawing.Size(216, 22);
            this.mi_newissue.Text = "Новая задача";
            this.mi_newissue.Click += new System.EventHandler(this.mi_newissue_Click);
            // 
            // mi_info
            // 
            this.mi_info.Name = "mi_info";
            this.mi_info.Size = new System.Drawing.Size(216, 22);
            this.mi_info.Text = "Информация об аккаунте";
            this.mi_info.Click += new System.EventHandler(this.mi_info_Click);
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
            // mi_ifoprj
            // 
            this.mi_ifoprj.Enabled = false;
            this.mi_ifoprj.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mi_ifoprj.Name = "mi_ifoprj";
            this.mi_ifoprj.Size = new System.Drawing.Size(75, 20);
            this.mi_ifoprj.Text = "О проекте";
            this.mi_ifoprj.Click += new System.EventHandler(this.mi_ifoprj_Click);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lv_issue);
            this.groupBox2.Location = new System.Drawing.Point(13, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 335);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задачи:";
            // 
            // lv_issue
            // 
            this.lv_issue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_issue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_subject,
            this.ch_tracker,
            this.ch_status,
            this.ch_priority,
            this.ch_assigned,
            this.ch_updated});
            this.lv_issue.FullRowSelect = true;
            this.lv_issue.Location = new System.Drawing.Point(7, 19);
            this.lv_issue.Name = "lv_issue";
            this.lv_issue.Size = new System.Drawing.Size(516, 309);
            this.lv_issue.TabIndex = 0;
            this.lv_issue.UseCompatibleStateImageBehavior = false;
            this.lv_issue.View = System.Windows.Forms.View.Details;
            this.lv_issue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_issue_MouseClick);
            // 
            // ch_subject
            // 
            this.ch_subject.Text = "Задача";
            this.ch_subject.Width = 74;
            // 
            // ch_tracker
            // 
            this.ch_tracker.Text = "Трекер";
            // 
            // ch_status
            // 
            this.ch_status.Text = "Статус";
            // 
            // ch_priority
            // 
            this.ch_priority.Text = "Приоритет";
            this.ch_priority.Width = 76;
            // 
            // ch_assigned
            // 
            this.ch_assigned.Text = "Назначена";
            // 
            // ch_updated
            // 
            this.ch_updated.Text = "Обновлено";
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Location = new System.Drawing.Point(247, 54);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(88, 13);
            this.lb_role.TabIndex = 3;
            this.lb_role.Text = "Роль в проекте:";
            this.lb_role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_role.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tm_infoIssue,
            this.tm_history,
            this.tm_status,
            this.tm_tracker,
            this.tm_priority,
            this.tm_apointed,
            this.tm_delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(198, 180);
            // 
            // tm_infoIssue
            // 
            this.tm_infoIssue.Enabled = false;
            this.tm_infoIssue.Name = "tm_infoIssue";
            this.tm_infoIssue.Size = new System.Drawing.Size(197, 22);
            this.tm_infoIssue.Text = "Информация о задаче";
            this.tm_infoIssue.Click += new System.EventHandler(this.tm_infoIssue_Click);
            // 
            // tm_status
            // 
            this.tm_status.Enabled = false;
            this.tm_status.Name = "tm_status";
            this.tm_status.Size = new System.Drawing.Size(197, 22);
            this.tm_status.Text = "Статус";
            this.tm_status.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tm_status_DropDownItemClicked);
            // 
            // tm_tracker
            // 
            this.tm_tracker.Enabled = false;
            this.tm_tracker.Name = "tm_tracker";
            this.tm_tracker.Size = new System.Drawing.Size(197, 22);
            this.tm_tracker.Text = "Трекер";
            this.tm_tracker.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tm_tracker_DropDownItemClicked);
            // 
            // tm_priority
            // 
            this.tm_priority.Enabled = false;
            this.tm_priority.Name = "tm_priority";
            this.tm_priority.Size = new System.Drawing.Size(197, 22);
            this.tm_priority.Text = "Приоритет";
            this.tm_priority.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tm_priority_DropDownItemClicked);
            // 
            // tm_apointed
            // 
            this.tm_apointed.Enabled = false;
            this.tm_apointed.Name = "tm_apointed";
            this.tm_apointed.Size = new System.Drawing.Size(197, 22);
            this.tm_apointed.Text = "Назначена";
            this.tm_apointed.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tm_apointed_DropDownItemClicked);
            // 
            // tm_delete
            // 
            this.tm_delete.Enabled = false;
            this.tm_delete.Name = "tm_delete";
            this.tm_delete.Size = new System.Drawing.Size(197, 22);
            this.tm_delete.Text = "Удалить";
            this.tm_delete.Click += new System.EventHandler(this.tm_delete_Click);
            // 
            // tm_history
            // 
            this.tm_history.Name = "tm_history";
            this.tm_history.Size = new System.Drawing.Size(197, 22);
            this.tm_history.Text = "История задачи";
            this.tm_history.Click += new System.EventHandler(this.tm_history_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 434);
            this.Controls.Add(this.lb_role);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(570, 473);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redmine Agent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_newissue;
        private System.Windows.Forms.ToolStripMenuItem mi_exit;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_apikey;
        private System.Windows.Forms.ToolStripMenuItem mi_update;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_project;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_issue;
        private System.Windows.Forms.ToolStripMenuItem mi_info;
        private System.Windows.Forms.ColumnHeader ch_subject;
        private System.Windows.Forms.ColumnHeader ch_tracker;
        private System.Windows.Forms.ColumnHeader ch_status;
        private System.Windows.Forms.ColumnHeader ch_priority;
        private System.Windows.Forms.ColumnHeader ch_assigned;
        private System.Windows.Forms.ColumnHeader ch_updated;
        private System.Windows.Forms.ToolStripMenuItem mi_ifoprj;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tm_status;
        private System.Windows.Forms.ToolStripMenuItem tm_priority;
        private System.Windows.Forms.ToolStripMenuItem tm_apointed;
        private System.Windows.Forms.ToolStripMenuItem tm_infoIssue;
        private System.Windows.Forms.ToolStripMenuItem tm_tracker;
        private System.Windows.Forms.ToolStripMenuItem tm_delete;
        private System.Windows.Forms.ToolStripMenuItem tm_history;

    }
}

