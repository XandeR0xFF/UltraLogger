namespace UltraLogger.UI
{
    partial class OrdersControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersControl));
            toolStrip1 = new ToolStrip();
            addButton = new ToolStripButton();
            editButton = new ToolStripButton();
            deleteButton = new ToolStripButton();
            ordersListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { addButton, editButton, deleteButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(601, 25);
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
            // ordersListView
            // 
            ordersListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            ordersListView.Dock = DockStyle.Fill;
            ordersListView.FullRowSelect = true;
            ordersListView.Location = new Point(0, 25);
            ordersListView.MultiSelect = false;
            ordersListView.Name = "ordersListView";
            ordersListView.Size = new Size(601, 310);
            ordersListView.TabIndex = 1;
            ordersListView.UseCompatibleStateImageBehavior = false;
            ordersListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Номер заказа";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Заказчик";
            columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Марка стали";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Размер";
            columnHeader4.Width = 120;
            // 
            // OrdersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ordersListView);
            Controls.Add(toolStrip1);
            Name = "OrdersControl";
            Size = new Size(601, 335);
            Load += OrdersControl_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ListView ordersListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ToolStripButton addButton;
        private ToolStripButton editButton;
        private ToolStripButton deleteButton;
    }
}
