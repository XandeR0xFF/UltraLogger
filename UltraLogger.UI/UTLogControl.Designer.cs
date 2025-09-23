namespace UltraLogger.UI
{
    partial class UTLogControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            splitContainer1 = new SplitContainer();
            entriesList = new ListView();
            defectogramColumn = new ColumnHeader();
            dateTimeColumn = new ColumnHeader();
            ustModeColumn = new ColumnHeader();
            dimensionsColumn = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            entryDetails = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(765, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(entriesList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(entryDetails);
            splitContainer1.Size = new Size(765, 341);
            splitContainer1.SplitterDistance = 520;
            splitContainer1.TabIndex = 1;
            // 
            // entriesList
            // 
            entriesList.Columns.AddRange(new ColumnHeader[] { defectogramColumn, dateTimeColumn, ustModeColumn, dimensionsColumn, columnHeader5 });
            entriesList.Dock = DockStyle.Fill;
            entriesList.FullRowSelect = true;
            entriesList.Location = new Point(0, 0);
            entriesList.Name = "entriesList";
            entriesList.Size = new Size(520, 341);
            entriesList.TabIndex = 0;
            entriesList.UseCompatibleStateImageBehavior = false;
            entriesList.View = View.Details;
            entriesList.SelectedIndexChanged += entriesList_SelectedIndexChanged;
            entriesList.Resize += entriesList_Resize;
            // 
            // defectogramColumn
            // 
            defectogramColumn.DisplayIndex = 1;
            defectogramColumn.Text = "Дефектограмма";
            defectogramColumn.Width = 120;
            // 
            // dateTimeColumn
            // 
            dateTimeColumn.DisplayIndex = 0;
            dateTimeColumn.Text = "Дата и время";
            dateTimeColumn.Width = 100;
            // 
            // ustModeColumn
            // 
            ustModeColumn.Text = "Режим";
            // 
            // dimensionsColumn
            // 
            dimensionsColumn.Text = "Размер ОК (мм)";
            dimensionsColumn.Width = 140;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Маркировка";
            columnHeader5.Width = 50;
            // 
            // entryDetails
            // 
            entryDetails.BorderStyle = BorderStyle.Fixed3D;
            entryDetails.Dock = DockStyle.Fill;
            entryDetails.Location = new Point(0, 0);
            entryDetails.Name = "entryDetails";
            entryDetails.Size = new Size(241, 341);
            entryDetails.TabIndex = 0;
            entryDetails.Text = "label1";
            // 
            // UTLogControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "UTLogControl";
            Size = new Size(765, 366);
            Load += UTLogControl_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private ListView entriesList;
        private ColumnHeader dateTimeColumn;
        private ColumnHeader defectogramColumn;
        private ColumnHeader dimensionsColumn;
        private ColumnHeader columnHeader5;
        private ColumnHeader ustModeColumn;
        private Label entryDetails;
    }
}
