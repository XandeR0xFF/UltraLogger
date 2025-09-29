namespace UltraLogger.UI
{
    partial class ReportsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsControl));
            toolStrip1 = new ToolStrip();
            addButton = new ToolStripButton();
            editButton = new ToolStripButton();
            deleteButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            lockButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            removePlate = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            reportsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            platesListView = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { addButton, editButton, deleteButton, toolStripSeparator1, lockButton, toolStripSeparator2, removePlate });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(642, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            addButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            addButton.Image = (Image)resources.GetObject("addButton.Image");
            addButton.ImageTransparentColor = Color.Magenta;
            addButton.Name = "addButton";
            addButton.Size = new Size(23, 22);
            addButton.Text = "toolStripButton1";
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            editButton.Image = (Image)resources.GetObject("editButton.Image");
            editButton.ImageTransparentColor = Color.Magenta;
            editButton.Name = "editButton";
            editButton.Size = new Size(23, 22);
            editButton.Text = "toolStripButton2";
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.ImageTransparentColor = Color.Magenta;
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(23, 22);
            deleteButton.Text = "toolStripButton3";
            deleteButton.Click += deleteButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // lockButton
            // 
            lockButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            lockButton.Image = (Image)resources.GetObject("lockButton.Image");
            lockButton.ImageTransparentColor = Color.Magenta;
            lockButton.Name = "lockButton";
            lockButton.Size = new Size(23, 22);
            lockButton.Text = "toolStripButton4";
            lockButton.Click += lockButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // removePlate
            // 
            removePlate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            removePlate.Image = (Image)resources.GetObject("removePlate.Image");
            removePlate.ImageTransparentColor = Color.Magenta;
            removePlate.Name = "removePlate";
            removePlate.Size = new Size(23, 22);
            removePlate.Text = "toolStripButton5";
            removePlate.Click += removePlate_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(reportsListView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(platesListView);
            splitContainer1.Size = new Size(642, 447);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 5;
            // 
            // reportsListView
            // 
            reportsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader8 });
            reportsListView.Dock = DockStyle.Fill;
            reportsListView.FullRowSelect = true;
            reportsListView.Location = new Point(0, 0);
            reportsListView.MultiSelect = false;
            reportsListView.Name = "reportsListView";
            reportsListView.Size = new Size(642, 200);
            reportsListView.TabIndex = 0;
            reportsListView.UseCompatibleStateImageBehavior = false;
            reportsListView.View = View.Details;
            reportsListView.SelectedIndexChanged += reportsListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Номер";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Создан";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Заказной размер ";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Заказчик";
            columnHeader4.Width = 200;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Статус";
            // 
            // platesListView
            // 
            platesListView.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7 });
            platesListView.Dock = DockStyle.Fill;
            platesListView.FullRowSelect = true;
            platesListView.Location = new Point(0, 0);
            platesListView.MultiSelect = false;
            platesListView.Name = "platesListView";
            platesListView.Size = new Size(642, 243);
            platesListView.TabIndex = 0;
            platesListView.UseCompatibleStateImageBehavior = false;
            platesListView.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Дата и время";
            columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Маркировка";
            columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Заключение";
            columnHeader7.Width = 100;
            // 
            // ReportsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "ReportsControl";
            Size = new Size(642, 472);
            Load += ReportsControl_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private ListView reportsListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView platesListView;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader4;
        private ToolStripButton addButton;
        private ToolStripButton editButton;
        private ToolStripButton deleteButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton lockButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton removePlate;
    }
}
