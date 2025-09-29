namespace UltraLogger.UI
{
    partial class EditReportForm
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
            label2 = new Label();
            groupBox1 = new GroupBox();
            dimensionsLabel = new Label();
            steelGradeLabel = new Label();
            label4 = new Label();
            label3 = new Label();
            customerLabel = new Label();
            label1 = new Label();
            orderComboBox = new ComboBox();
            okButton = new Button();
            cancelButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Заказ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dimensionsLabel);
            groupBox1.Controls.Add(steelGradeLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(customerLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 96);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация о заказе";
            // 
            // dimensionsLabel
            // 
            dimensionsLabel.Location = new Point(97, 61);
            dimensionsLabel.Name = "dimensionsLabel";
            dimensionsLabel.Size = new Size(276, 15);
            dimensionsLabel.TabIndex = 5;
            // 
            // steelGradeLabel
            // 
            steelGradeLabel.Location = new Point(97, 46);
            steelGradeLabel.Name = "steelGradeLabel";
            steelGradeLabel.Size = new Size(276, 15);
            steelGradeLabel.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 61);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 3;
            label4.Text = "Размер листа:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 46);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Марка стали:";
            // 
            // customerLabel
            // 
            customerLabel.Location = new Point(97, 31);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(329, 15);
            customerLabel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 31);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Закказчик:";
            // 
            // orderComboBox
            // 
            orderComboBox.FormattingEnabled = true;
            orderComboBox.Location = new Point(55, 12);
            orderComboBox.Name = "orderComboBox";
            orderComboBox.Size = new Size(180, 23);
            orderComboBox.TabIndex = 4;
            orderComboBox.SelectedIndexChanged += orderComboBox_SelectedIndexChanged;
            // 
            // okButton
            // 
            okButton.Location = new Point(288, 159);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 5;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(369, 159);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // EditReportForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(456, 194);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(orderComboBox);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Name = "EditReportForm";
            Text = "EditReportForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox orderComboBox;
        private Button okButton;
        private Button cancelButton;
        private Label customerLabel;
        private Label label1;
        private Label dimensionsLabel;
        private Label steelGradeLabel;
        private Label label4;
        private Label label3;
    }
}