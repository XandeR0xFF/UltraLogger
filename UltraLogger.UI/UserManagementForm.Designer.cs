namespace UltraLogger.UI
{
    partial class UserManagementForm
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
            panel1 = new Panel();
            resetPasswordButton = new Button();
            lockButton = new Button();
            editButton = new Button();
            createButton = new Button();
            userListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(resetPasswordButton);
            panel1.Controls.Add(lockButton);
            panel1.Controls.Add(editButton);
            panel1.Controls.Add(createButton);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(560, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 383);
            panel1.TabIndex = 0;
            // 
            // resetPasswordButton
            // 
            resetPasswordButton.Enabled = false;
            resetPasswordButton.Location = new Point(49, 98);
            resetPasswordButton.Name = "resetPasswordButton";
            resetPasswordButton.Size = new Size(167, 23);
            resetPasswordButton.TabIndex = 3;
            resetPasswordButton.Text = "Сброс пароля...";
            resetPasswordButton.UseVisualStyleBackColor = true;
            resetPasswordButton.Click += resetPasswordButton_Click;
            // 
            // lockButton
            // 
            lockButton.Enabled = false;
            lockButton.Location = new Point(49, 69);
            lockButton.Name = "lockButton";
            lockButton.Size = new Size(167, 23);
            lockButton.TabIndex = 2;
            lockButton.Text = "Заблокитровать";
            lockButton.UseVisualStyleBackColor = true;
            lockButton.Click += lockButton_Click;
            // 
            // editButton
            // 
            editButton.Enabled = false;
            editButton.Location = new Point(49, 40);
            editButton.Name = "editButton";
            editButton.Size = new Size(167, 23);
            editButton.TabIndex = 1;
            editButton.Text = "Редактировать...";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // createButton
            // 
            createButton.Location = new Point(49, 11);
            createButton.Name = "createButton";
            createButton.Size = new Size(167, 23);
            createButton.TabIndex = 0;
            createButton.Text = "Создать...";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // userListView
            // 
            userListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            userListView.Dock = DockStyle.Fill;
            userListView.FullRowSelect = true;
            userListView.Location = new Point(0, 0);
            userListView.MultiSelect = false;
            userListView.Name = "userListView";
            userListView.Size = new Size(560, 383);
            userListView.TabIndex = 1;
            userListView.UseCompatibleStateImageBehavior = false;
            userListView.View = View.Details;
            userListView.SelectedIndexChanged += userListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Логин";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Фамилия";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Имя";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Отчество";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Статус";
            columnHeader5.Width = 100;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 383);
            Controls.Add(userListView);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "UserManagementForm";
            Text = "Управление пользователями";
            Load += UserManagementForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button editButton;
        private Button createButton;
        private ListView userListView;
        private Button resetPasswordButton;
        private Button lockButton;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
    }
}