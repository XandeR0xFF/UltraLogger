namespace UltraLogger.UI
{
    partial class ChangeAdminPasswordForm
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
            oldPasswordTextBox = new TextBox();
            newPasswordTextBox = new TextBox();
            confirmPasswordTextBox = new TextBox();
            label1 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            label2 = new Label();
            label3 = new Label();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // oldPasswordTextBox
            // 
            oldPasswordTextBox.Location = new Point(155, 20);
            oldPasswordTextBox.Name = "oldPasswordTextBox";
            oldPasswordTextBox.Size = new Size(179, 23);
            oldPasswordTextBox.TabIndex = 0;
            oldPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Location = new Point(155, 61);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.Size = new Size(179, 23);
            newPasswordTextBox.TabIndex = 1;
            newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(155, 90);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.Size = new Size(179, 23);
            confirmPasswordTextBox.TabIndex = 2;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 3;
            label1.Text = "Старый пароль";
            // 
            // okButton
            // 
            okButton.Location = new Point(181, 147);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 4;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(262, 147);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 6;
            label2.Text = "Новый пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 7;
            label3.Text = "Подтверждение пароля";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 123);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(322, 21);
            errorLabel.TabIndex = 8;
            // 
            // ChangeAdminPasswordForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(349, 182);
            Controls.Add(errorLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(newPasswordTextBox);
            Controls.Add(oldPasswordTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangeAdminPasswordForm";
            Text = "Изменение пароля администратора";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox oldPasswordTextBox;
        private TextBox newPasswordTextBox;
        private TextBox confirmPasswordTextBox;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
        private Label label2;
        private Label label3;
        private Label errorLabel;
    }
}