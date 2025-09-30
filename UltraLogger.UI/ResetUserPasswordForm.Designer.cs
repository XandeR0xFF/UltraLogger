namespace UltraLogger.UI
{
    partial class ResetUserPasswordForm
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
            passwordTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 28);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Новый пароль";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(111, 25);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(178, 23);
            passwordTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Location = new Point(133, 82);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 2;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(214, 82);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(17, 58);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(272, 21);
            errorLabel.TabIndex = 4;
            // 
            // ResetUserPasswordForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(301, 117);
            Controls.Add(errorLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetUserPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ResetUserPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox passwordTextBox;
        private Button okButton;
        private Button cancelButton;
        private Label errorLabel;
    }
}