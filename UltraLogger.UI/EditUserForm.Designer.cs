namespace UltraLogger.UI
{
    partial class EditUserForm
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
            label1 = new Label();
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label2 = new Label();
            lastNameTextBox = new TextBox();
            label3 = new Label();
            firstNameTextBox = new TextBox();
            label4 = new Label();
            middleNameTextBox = new TextBox();
            label5 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(119, 12);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(161, 23);
            loginTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(119, 41);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(161, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 44);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 2;
            label2.Text = "Пароль";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(119, 89);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(161, 23);
            lastNameTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 92);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Фамилия";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(119, 118);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(161, 23);
            firstNameTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 121);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 6;
            label4.Text = "Имя";
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(119, 147);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(161, 23);
            middleNameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 150);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 8;
            label5.Text = "Отчество";
            // 
            // okButton
            // 
            okButton.Location = new Point(197, 214);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 10;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(278, 214);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 185);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(341, 23);
            errorLabel.TabIndex = 12;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 249);
            Controls.Add(errorLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(middleNameTextBox);
            Controls.Add(label5);
            Controls.Add(firstNameTextBox);
            Controls.Add(label4);
            Controls.Add(lastNameTextBox);
            Controls.Add(label3);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(loginTextBox);
            Controls.Add(label1);
            Name = "EditUserForm";
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Label label2;
        private TextBox lastNameTextBox;
        private Label label3;
        private TextBox firstNameTextBox;
        private Label label4;
        private TextBox middleNameTextBox;
        private Label label5;
        private Button okButton;
        private Button cancelButton;
        private Label errorLabel;
    }
}