namespace UltraLogger.UI
{
    partial class AddToReportForm
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
            reportsComboBox = new ComboBox();
            groupBox1 = new GroupBox();
            sizeLabel = new Label();
            steelGradeLabel = new Label();
            customerLabel = new Label();
            orderLabel = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Открытые отчеты";
            // 
            // reportsComboBox
            // 
            reportsComboBox.FormattingEnabled = true;
            reportsComboBox.Location = new Point(12, 27);
            reportsComboBox.Name = "reportsComboBox";
            reportsComboBox.Size = new Size(157, 23);
            reportsComboBox.TabIndex = 1;
            reportsComboBox.SelectedIndexChanged += reportsComboBox_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(sizeLabel);
            groupBox1.Controls.Add(steelGradeLabel);
            groupBox1.Controls.Add(customerLabel);
            groupBox1.Controls.Add(orderLabel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 96);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Инормация об отчете";
            // 
            // sizeLabel
            // 
            sizeLabel.Location = new Point(92, 69);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(299, 15);
            sizeLabel.TabIndex = 7;
            // 
            // steelGradeLabel
            // 
            steelGradeLabel.Location = new Point(92, 54);
            steelGradeLabel.Name = "steelGradeLabel";
            steelGradeLabel.Size = new Size(299, 15);
            steelGradeLabel.TabIndex = 6;
            // 
            // customerLabel
            // 
            customerLabel.Location = new Point(92, 39);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(299, 15);
            customerLabel.TabIndex = 5;
            // 
            // orderLabel
            // 
            orderLabel.Location = new Point(92, 24);
            orderLabel.Name = "orderLabel";
            orderLabel.Size = new Size(299, 15);
            orderLabel.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 69);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 3;
            label5.Text = "Размер:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 54);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 2;
            label4.Text = "Марка стали:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 39);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 1;
            label3.Text = "Заказчик";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 24);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 0;
            label2.Text = "Заказ:";
            // 
            // okButton
            // 
            okButton.Location = new Point(253, 168);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 3;
            okButton.Text = "Ок";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(334, 168);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddToReportForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(421, 204);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(groupBox1);
            Controls.Add(reportsComboBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddToReportForm";
            Text = "AddToReportForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox reportsComboBox;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button okButton;
        private Button cancelButton;
        private Label orderLabel;
        private Label sizeLabel;
        private Label steelGradeLabel;
        private Label customerLabel;
    }
}