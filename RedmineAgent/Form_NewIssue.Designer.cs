namespace RedmineAgent
{
    partial class Form_NewIssue
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_trackers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_topic = new System.Windows.Forms.TextBox();
            this.cb_private = new System.Windows.Forms.CheckBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_priority = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_assigned = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_startDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_complectionDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_estimated_hours = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_readiness = new System.Windows.Forms.ComboBox();
            this.bt_newissue = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Трекер*";
            // 
            // cb_trackers
            // 
            this.cb_trackers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_trackers.FormattingEnabled = true;
            this.cb_trackers.Location = new System.Drawing.Point(97, 18);
            this.cb_trackers.Name = "cb_trackers";
            this.cb_trackers.Size = new System.Drawing.Size(121, 21);
            this.cb_trackers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Тема*";
            // 
            // tb_topic
            // 
            this.tb_topic.Location = new System.Drawing.Point(97, 47);
            this.tb_topic.Name = "tb_topic";
            this.tb_topic.Size = new System.Drawing.Size(269, 20);
            this.tb_topic.TabIndex = 2;
            // 
            // cb_private
            // 
            this.cb_private.AutoSize = true;
            this.cb_private.Location = new System.Drawing.Point(286, 19);
            this.cb_private.Name = "cb_private";
            this.cb_private.Size = new System.Drawing.Size(69, 17);
            this.cb_private.TabIndex = 3;
            this.cb_private.Text = "Частная";
            this.cb_private.UseVisualStyleBackColor = true;
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(97, 77);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(269, 84);
            this.tb_description.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Описание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Статус*";
            // 
            // cb_status
            // 
            this.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Location = new System.Drawing.Point(153, 177);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(121, 21);
            this.cb_status.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(63, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Приоритет*";
            // 
            // cb_priority
            // 
            this.cb_priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_priority.FormattingEnabled = true;
            this.cb_priority.Location = new System.Drawing.Point(153, 204);
            this.cb_priority.Name = "cb_priority";
            this.cb_priority.Size = new System.Drawing.Size(121, 21);
            this.cb_priority.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(66, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Назначена";
            // 
            // cb_assigned
            // 
            this.cb_assigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_assigned.FormattingEnabled = true;
            this.cb_assigned.Location = new System.Drawing.Point(153, 234);
            this.cb_assigned.Name = "cb_assigned";
            this.cb_assigned.Size = new System.Drawing.Size(121, 21);
            this.cb_assigned.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(56, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Дата начала";
            // 
            // tb_startDate
            // 
            this.tb_startDate.Location = new System.Drawing.Point(153, 267);
            this.tb_startDate.Name = "tb_startDate";
            this.tb_startDate.Size = new System.Drawing.Size(121, 20);
            this.tb_startDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(25, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Дата завершения";
            // 
            // tb_complectionDate
            // 
            this.tb_complectionDate.Location = new System.Drawing.Point(153, 296);
            this.tb_complectionDate.Name = "tb_complectionDate";
            this.tb_complectionDate.Size = new System.Drawing.Size(121, 20);
            this.tb_complectionDate.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Оценка трудозатрат";
            // 
            // tb_estimated_hours
            // 
            this.tb_estimated_hours.Location = new System.Drawing.Point(153, 328);
            this.tb_estimated_hours.Name = "tb_estimated_hours";
            this.tb_estimated_hours.Size = new System.Drawing.Size(122, 20);
            this.tb_estimated_hours.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(65, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Готовность";
            // 
            // cb_readiness
            // 
            this.cb_readiness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_readiness.FormattingEnabled = true;
            this.cb_readiness.Location = new System.Drawing.Point(153, 358);
            this.cb_readiness.Name = "cb_readiness";
            this.cb_readiness.Size = new System.Drawing.Size(121, 21);
            this.cb_readiness.TabIndex = 5;
            // 
            // bt_newissue
            // 
            this.bt_newissue.Location = new System.Drawing.Point(71, 399);
            this.bt_newissue.Name = "bt_newissue";
            this.bt_newissue.Size = new System.Drawing.Size(75, 23);
            this.bt_newissue.TabIndex = 6;
            this.bt_newissue.Text = "Создать";
            this.bt_newissue.UseVisualStyleBackColor = true;
            this.bt_newissue.Click += new System.EventHandler(this.bt_newissue_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(265, 399);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 6;
            this.bt_cancel.Text = "Отмена";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(281, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "час(а,ов)";
            // 
            // Form_NewIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 437);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_newissue);
            this.Controls.Add(this.cb_readiness);
            this.Controls.Add(this.cb_assigned);
            this.Controls.Add(this.cb_priority);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.tb_estimated_hours);
            this.Controls.Add(this.tb_complectionDate);
            this.Controls.Add(this.tb_startDate);
            this.Controls.Add(this.tb_description);
            this.Controls.Add(this.cb_private);
            this.Controls.Add(this.tb_topic);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_trackers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_NewIssue";
            this.Text = "Создание задачи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_trackers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_topic;
        private System.Windows.Forms.CheckBox cb_private;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_priority;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_assigned;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_startDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_complectionDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_estimated_hours;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_readiness;
        private System.Windows.Forms.Button bt_newissue;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label label11;
    }
}