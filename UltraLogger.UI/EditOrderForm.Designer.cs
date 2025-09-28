namespace UltraLogger.UI
{
    partial class EditOrderForm
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
            okButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            numberTextBox = new TextBox();
            label2 = new Label();
            steelGradeTextBox = new TextBox();
            customersComboBox = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            thicknessTextBox = new TextBox();
            widthTextBox = new TextBox();
            lengthTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new Point(448, 175);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(529, 175);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 2;
            label1.Text = "Номер заказа";
            // 
            // numberTextBox
            // 
            numberTextBox.Location = new Point(100, 21);
            numberTextBox.Name = "numberTextBox";
            numberTextBox.Size = new Size(168, 23);
            numberTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(421, 75);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 4;
            label2.Text = "Марка стали";
            // 
            // steelGradeTextBox
            // 
            steelGradeTextBox.Location = new Point(504, 72);
            steelGradeTextBox.Name = "steelGradeTextBox";
            steelGradeTextBox.Size = new Size(100, 23);
            steelGradeTextBox.TabIndex = 5;
            // 
            // customersComboBox
            // 
            customersComboBox.FormattingEnabled = true;
            customersComboBox.Location = new Point(100, 111);
            customersComboBox.Name = "customersComboBox";
            customersComboBox.Size = new Size(504, 23);
            customersComboBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 114);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 7;
            label3.Text = "Заказчик";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 75);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 8;
            label4.Text = "Размер";
            // 
            // thicknessTextBox
            // 
            thicknessTextBox.Location = new Point(100, 72);
            thicknessTextBox.Name = "thicknessTextBox";
            thicknessTextBox.Size = new Size(62, 23);
            thicknessTextBox.TabIndex = 9;
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(168, 72);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new Size(100, 23);
            widthTextBox.TabIndex = 10;
            // 
            // lengthTextBox
            // 
            lengthTextBox.Location = new Point(274, 72);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.Size = new Size(100, 23);
            lengthTextBox.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 54);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 12;
            label5.Text = "Толщина";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(168, 54);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Ширина";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 54);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 14;
            label7.Text = "Длина";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(100, 149);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(504, 23);
            errorLabel.TabIndex = 15;
            // 
            // EditOrderForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(620, 210);
            Controls.Add(errorLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lengthTextBox);
            Controls.Add(widthTextBox);
            Controls.Add(thicknessTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(customersComboBox);
            Controls.Add(steelGradeTextBox);
            Controls.Add(label2);
            Controls.Add(numberTextBox);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditOrderForm";
            Text = "EditOrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private Label label1;
        private TextBox numberTextBox;
        private Label label2;
        private TextBox steelGradeTextBox;
        private ComboBox customersComboBox;
        private Label label3;
        private Label label4;
        private TextBox thicknessTextBox;
        private TextBox widthTextBox;
        private TextBox lengthTextBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label errorLabel;
    }
}