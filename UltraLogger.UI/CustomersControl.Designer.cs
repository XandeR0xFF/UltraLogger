namespace UltraLogger.UI
{
    partial class CustomersControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersControl));
            toolStrip1 = new ToolStrip();
            addButton = new ToolStripButton();
            editButton = new ToolStripButton();
            deleteButton = new ToolStripButton();
            customersListView = new ListView();
            columnHeader1 = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            descriptionLabel = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { addButton, editButton, deleteButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(591, 25);
            toolStrip1.TabIndex = 0;
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
            // customersListView
            // 
            customersListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            customersListView.Dock = DockStyle.Fill;
            customersListView.Location = new Point(0, 0);
            customersListView.Name = "customersListView";
            customersListView.Size = new Size(591, 229);
            customersListView.TabIndex = 1;
            customersListView.UseCompatibleStateImageBehavior = false;
            customersListView.View = View.Details;
            customersListView.SelectedIndexChanged += customersListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Наименование";
            columnHeader1.Width = 300;
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
            splitContainer1.Panel1.Controls.Add(customersListView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(descriptionLabel);
            splitContainer1.Size = new Size(591, 318);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 2;
            // 
            // descriptionLabel
            // 
            descriptionLabel.BorderStyle = BorderStyle.Fixed3D;
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.Location = new Point(0, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(591, 85);
            descriptionLabel.TabIndex = 0;
            descriptionLabel.Text = "label1";
            // 
            // CustomersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "CustomersControl";
            Size = new Size(591, 343);
            Load += CustomersControl_Load;
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
        private ListView customersListView;
        private ColumnHeader columnHeader1;
        private SplitContainer splitContainer1;
        private Label descriptionLabel;
        private ToolStripButton addButton;
        private ToolStripButton editButton;
        private ToolStripButton deleteButton;
    }
}
