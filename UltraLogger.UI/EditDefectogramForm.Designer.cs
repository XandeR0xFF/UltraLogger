namespace UltraLogger.UI
{
    partial class EditDefectogramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDefectogramForm));
            label1 = new Label();
            dateTimePicker = new DateTimePicker();
            label2 = new Label();
            defectogramNumberTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            thicknessTextBox = new TextBox();
            platePartLengthTextBox = new TextBox();
            label5 = new Label();
            platePartWidthTextBox = new TextBox();
            label6 = new Label();
            ustModesComboBox = new ComboBox();
            label7 = new Label();
            plateDataCheckBox = new CheckBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            platePartsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label8 = new Label();
            platePartNumberTextBox = new TextBox();
            label9 = new Label();
            widthTextBox = new TextBox();
            label10 = new Label();
            lengthTextBox = new TextBox();
            label11 = new Label();
            label12 = new Label();
            platePartXTextBox = new TextBox();
            label13 = new Label();
            platePartYTextBox = new TextBox();
            label14 = new Label();
            label15 = new Label();
            meltYearTextBox = new TextBox();
            meltNumberTextBox = new TextBox();
            slabNuberTextBox = new TextBox();
            label16 = new Label();
            evaluationsComboBox = new ComboBox();
            addPlatePartButton = new Button();
            deletePlatePartButon = new Button();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 76);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 0;
            label1.Text = "Дата и время контроля";
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "dd.MM.yyy HH:mm:ss";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(154, 70);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(146, 23);
            dateTimePicker.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 44);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 2;
            label2.Text = "Номер дефектограммы";
            // 
            // defectogramNumberTextBox
            // 
            defectogramNumberTextBox.Location = new Point(154, 41);
            defectogramNumberTextBox.Name = "defectogramNumberTextBox";
            defectogramNumberTextBox.Size = new Size(146, 23);
            defectogramNumberTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(395, 23);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 4;
            label3.Text = "Толщина";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(328, 47);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 5;
            label4.Text = "Размер ОК";
            // 
            // thicknessTextBox
            // 
            thicknessTextBox.Location = new Point(400, 44);
            thicknessTextBox.Name = "thicknessTextBox";
            thicknessTextBox.Size = new Size(54, 23);
            thicknessTextBox.TabIndex = 6;
            // 
            // platePartLengthTextBox
            // 
            platePartLengthTextBox.Location = new Point(539, 241);
            platePartLengthTextBox.Name = "platePartLengthTextBox";
            platePartLengthTextBox.Size = new Size(83, 23);
            platePartLengthTextBox.TabIndex = 8;
            platePartLengthTextBox.TextChanged += platePartsControlsChangeValue;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(539, 223);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 7;
            label5.Text = "Длина";
            // 
            // platePartWidthTextBox
            // 
            platePartWidthTextBox.Location = new Point(462, 241);
            platePartWidthTextBox.Name = "platePartWidthTextBox";
            platePartWidthTextBox.Size = new Size(71, 23);
            platePartWidthTextBox.TabIndex = 10;
            platePartWidthTextBox.TextChanged += platePartsControlsChangeValue;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(462, 223);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 9;
            label6.Text = "Ширина";
            // 
            // ustModesComboBox
            // 
            ustModesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ustModesComboBox.FormattingEnabled = true;
            ustModesComboBox.Location = new Point(154, 12);
            ustModesComboBox.Name = "ustModesComboBox";
            ustModesComboBox.Size = new Size(146, 23);
            ustModesComboBox.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 15);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 12;
            label7.Text = "Режим контроля";
            // 
            // plateDataCheckBox
            // 
            plateDataCheckBox.AutoSize = true;
            plateDataCheckBox.Location = new Point(10, 114);
            plateDataCheckBox.Name = "plateDataCheckBox";
            plateDataCheckBox.Size = new Size(167, 19);
            plateDataCheckBox.TabIndex = 13;
            plateDataCheckBox.Text = "Добавить данные раската";
            plateDataCheckBox.UseVisualStyleBackColor = true;
            plateDataCheckBox.CheckedChanged += plateDataCheckBox_CheckedChanged;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(462, 386);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 14;
            buttonOk.Text = "Ок";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(543, 386);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // platePartsListView
            // 
            platePartsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            platePartsListView.FullRowSelect = true;
            platePartsListView.Location = new Point(10, 197);
            platePartsListView.MultiSelect = false;
            platePartsListView.Name = "platePartsListView";
            platePartsListView.Size = new Size(335, 148);
            platePartsListView.TabIndex = 16;
            platePartsListView.UseCompatibleStateImageBehavior = false;
            platePartsListView.View = View.Details;
            platePartsListView.SelectedIndexChanged += platePartsListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Лист";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Размер";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Заключение УЗК";
            columnHeader3.Width = 120;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(369, 200);
            label8.Name = "label8";
            label8.Size = new Size(79, 15);
            label8.TabIndex = 17;
            label8.Text = "Номер листа";
            // 
            // platePartNumberTextBox
            // 
            platePartNumberTextBox.Location = new Point(460, 197);
            platePartNumberTextBox.Name = "platePartNumberTextBox";
            platePartNumberTextBox.Size = new Size(162, 23);
            platePartNumberTextBox.TabIndex = 18;
            platePartNumberTextBox.TextChanged += platePartsControlsChangeValue;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(371, 244);
            label9.Name = "label9";
            label9.Size = new Size(81, 15);
            label9.TabIndex = 19;
            label9.Text = "Размер листа";
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(460, 44);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new Size(71, 23);
            widthTextBox.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(460, 26);
            label10.Name = "label10";
            label10.Size = new Size(52, 15);
            label10.TabIndex = 22;
            label10.Text = "Ширина";
            // 
            // lengthTextBox
            // 
            lengthTextBox.Location = new Point(537, 44);
            lengthTextBox.Name = "lengthTextBox";
            lengthTextBox.Size = new Size(85, 23);
            lengthTextBox.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(537, 26);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 20;
            label11.Text = "Длина";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(369, 289);
            label12.Name = "label12";
            label12.Size = new Size(85, 15);
            label12.TabIndex = 24;
            label12.Text = "Точка отсчета";
            // 
            // platePartXTextBox
            // 
            platePartXTextBox.Location = new Point(460, 286);
            platePartXTextBox.Name = "platePartXTextBox";
            platePartXTextBox.Size = new Size(71, 23);
            platePartXTextBox.TabIndex = 28;
            platePartXTextBox.TextChanged += platePartsControlsChangeValue;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(460, 268);
            label13.Name = "label13";
            label13.Size = new Size(14, 15);
            label13.TabIndex = 27;
            label13.Text = "X";
            // 
            // platePartYTextBox
            // 
            platePartYTextBox.Location = new Point(547, 286);
            platePartYTextBox.Name = "platePartYTextBox";
            platePartYTextBox.Size = new Size(75, 23);
            platePartYTextBox.TabIndex = 26;
            platePartYTextBox.TextChanged += platePartsControlsChangeValue;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(547, 268);
            label14.Name = "label14";
            label14.Size = new Size(14, 15);
            label14.TabIndex = 25;
            label14.Text = "Y";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(10, 166);
            label15.Name = "label15";
            label15.Size = new Size(90, 15);
            label15.TabIndex = 29;
            label15.Text = "Номер раската";
            // 
            // meltYearTextBox
            // 
            meltYearTextBox.Location = new Point(106, 163);
            meltYearTextBox.Name = "meltYearTextBox";
            meltYearTextBox.Size = new Size(53, 23);
            meltYearTextBox.TabIndex = 30;
            // 
            // meltNumberTextBox
            // 
            meltNumberTextBox.Location = new Point(165, 163);
            meltNumberTextBox.Name = "meltNumberTextBox";
            meltNumberTextBox.Size = new Size(82, 23);
            meltNumberTextBox.TabIndex = 31;
            // 
            // slabNuberTextBox
            // 
            slabNuberTextBox.Location = new Point(253, 163);
            slabNuberTextBox.Name = "slabNuberTextBox";
            slabNuberTextBox.Size = new Size(92, 23);
            slabNuberTextBox.TabIndex = 32;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(369, 325);
            label16.Name = "label16";
            label16.Size = new Size(100, 15);
            label16.TabIndex = 33;
            label16.Text = "Заключение УЗК";
            // 
            // evaluationsComboBox
            // 
            evaluationsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            evaluationsComboBox.FormattingEnabled = true;
            evaluationsComboBox.Location = new Point(475, 322);
            evaluationsComboBox.Name = "evaluationsComboBox";
            evaluationsComboBox.Size = new Size(143, 23);
            evaluationsComboBox.TabIndex = 34;
            evaluationsComboBox.SelectedIndexChanged += platePartsControlsChangeValue;
            // 
            // addPlatePartButton
            // 
            addPlatePartButton.Image = (Image)resources.GetObject("addPlatePartButton.Image");
            addPlatePartButton.Location = new Point(10, 351);
            addPlatePartButton.Name = "addPlatePartButton";
            addPlatePartButton.Size = new Size(28, 26);
            addPlatePartButton.TabIndex = 35;
            addPlatePartButton.UseVisualStyleBackColor = true;
            addPlatePartButton.Click += addPlatePartButton_Click;
            // 
            // deletePlatePartButon
            // 
            deletePlatePartButon.Image = (Image)resources.GetObject("deletePlatePartButon.Image");
            deletePlatePartButon.Location = new Point(44, 351);
            deletePlatePartButon.Name = "deletePlatePartButon";
            deletePlatePartButon.Size = new Size(28, 26);
            deletePlatePartButon.TabIndex = 36;
            deletePlatePartButon.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(106, 145);
            label17.Name = "label17";
            label17.Size = new Size(26, 15);
            label17.TabIndex = 37;
            label17.Text = "Год";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(253, 145);
            label18.Name = "label18";
            label18.Size = new Size(35, 15);
            label18.TabIndex = 38;
            label18.Text = "Сляб";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(165, 145);
            label19.Name = "label19";
            label19.Size = new Size(47, 15);
            label19.TabIndex = 39;
            label19.Text = "Плавка";
            // 
            // EditDefectogramForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(634, 424);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(deletePlatePartButon);
            Controls.Add(addPlatePartButton);
            Controls.Add(evaluationsComboBox);
            Controls.Add(label16);
            Controls.Add(slabNuberTextBox);
            Controls.Add(meltNumberTextBox);
            Controls.Add(meltYearTextBox);
            Controls.Add(label15);
            Controls.Add(platePartXTextBox);
            Controls.Add(label13);
            Controls.Add(platePartYTextBox);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(widthTextBox);
            Controls.Add(label10);
            Controls.Add(lengthTextBox);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(platePartNumberTextBox);
            Controls.Add(label8);
            Controls.Add(platePartsListView);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(plateDataCheckBox);
            Controls.Add(label7);
            Controls.Add(ustModesComboBox);
            Controls.Add(platePartWidthTextBox);
            Controls.Add(label6);
            Controls.Add(platePartLengthTextBox);
            Controls.Add(label5);
            Controls.Add(thicknessTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(defectogramNumberTextBox);
            Controls.Add(label2);
            Controls.Add(dateTimePicker);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditDefectogramForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddDefectogramForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker;
        private Label label2;
        private TextBox defectogramNumberTextBox;
        private Label label3;
        private Label label4;
        private TextBox thicknessTextBox;
        private TextBox platePartLengthTextBox;
        private Label label5;
        private TextBox platePartWidthTextBox;
        private Label label6;
        private ComboBox ustModesComboBox;
        private Label label7;
        private CheckBox plateDataCheckBox;
        private Button buttonOk;
        private Button buttonCancel;
        private ListView platePartsListView;
        private Label label8;
        private TextBox platePartNumberTextBox;
        private Label label9;
        private TextBox widthTextBox;
        private Label label10;
        private TextBox lengthTextBox;
        private Label label11;
        private Label label12;
        private TextBox platePartXTextBox;
        private Label label13;
        private TextBox platePartYTextBox;
        private Label label14;
        private Label label15;
        private TextBox meltYearTextBox;
        private TextBox meltNumberTextBox;
        private TextBox slabNuberTextBox;
        private Label label16;
        private ComboBox evaluationsComboBox;
        private Button addPlatePartButton;
        private Button deletePlatePartButon;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label17;
        private Label label18;
        private Label label19;
    }
}