namespace UltraLogger.UI
{
    partial class AuthenticationForm
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
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            logInButton = new Button();
            label1 = new Label();
            label2 = new Label();
            userManagementButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(67, 12);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(224, 23);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(67, 41);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(224, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // logInButton
            // 
            logInButton.Location = new Point(12, 103);
            logInButton.Name = "logInButton";
            logInButton.Size = new Size(279, 23);
            logInButton.TabIndex = 2;
            logInButton.Text = "Войти";
            logInButton.UseVisualStyleBackColor = true;
            logInButton.Click += logInButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 3;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // userManagementButton
            // 
            userManagementButton.Enabled = false;
            userManagementButton.Location = new Point(12, 146);
            userManagementButton.Name = "userManagementButton";
            userManagementButton.Size = new Size(279, 23);
            userManagementButton.TabIndex = 6;
            userManagementButton.Text = "Управление пользователями...";
            userManagementButton.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 77);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(279, 23);
            errorLabel.TabIndex = 7;
            errorLabel.Text = "Неверный логин или пароль";
            // 
            // AuthenticationForm
            // 
            AcceptButton = logInButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 181);
            Controls.Add(errorLabel);
            Controls.Add(userManagementButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(logInButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AuthenticationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Аутентификация пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Button logInButton;
        private Label label1;
        private Label label2;
        private Button userManagementButton;
        private Label errorLabel;
    }
}