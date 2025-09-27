namespace UltraLogger.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("Журнал", 0, 0);
            TreeNode treeNode2 = new TreeNode("Отчеты", 1, 1);
            TreeNode treeNode3 = new TreeNode("Заказы", 4, 4);
            TreeNode treeNode4 = new TreeNode("Заказчики", 2, 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            menuStrip = new MenuStrip();
            loginMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            управлениеПользователямиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            navigationMenu = new TreeView();
            imageListNavigation = new ImageList(components);
            mainPanel = new Panel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 419);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(815, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { loginMenuItem, toolStripMenuItem4, toolStripMenuItem5 });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(815, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // loginMenuItem
            // 
            loginMenuItem.Alignment = ToolStripItemAlignment.Right;
            loginMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            loginMenuItem.Image = Properties.Resources.icons8_user_16;
            loginMenuItem.Name = "loginMenuItem";
            loginMenuItem.Size = new Size(93, 20);
            loginMenuItem.Text = "User Name";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(236, 22);
            toolStripMenuItem2.Text = "Параметры учетной записи...";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(236, 22);
            toolStripMenuItem3.Text = "Сменить пользователя";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, выходToolStripMenuItem });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(48, 20);
            toolStripMenuItem4.Text = "Файл";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            выходToolStripMenuItem.Size = new Size(180, 22);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { управлениеПользователямиToolStripMenuItem, toolStripMenuItem6 });
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(134, 20);
            toolStripMenuItem5.Text = "Администрирование";
            // 
            // управлениеПользователямиToolStripMenuItem
            // 
            управлениеПользователямиToolStripMenuItem.Name = "управлениеПользователямиToolStripMenuItem";
            управлениеПользователямиToolStripMenuItem.Size = new Size(274, 22);
            управлениеПользователямиToolStripMenuItem.Text = "Управление пользователями...";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(274, 22);
            toolStripMenuItem6.Text = "Изменить пароль администратора...";
            // 
            // navigationMenu
            // 
            navigationMenu.Dock = DockStyle.Left;
            navigationMenu.FullRowSelect = true;
            navigationMenu.HideSelection = false;
            navigationMenu.ImageIndex = 0;
            navigationMenu.ImageList = imageListNavigation;
            navigationMenu.ItemHeight = 28;
            navigationMenu.Location = new Point(0, 24);
            navigationMenu.Name = "navigationMenu";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Log";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Журнал";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Reports";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Отчеты";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "Orders";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Text = "Заказы";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Customers";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Заказчики";
            navigationMenu.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4 });
            navigationMenu.SelectedImageIndex = 0;
            navigationMenu.ShowLines = false;
            navigationMenu.ShowPlusMinus = false;
            navigationMenu.ShowRootLines = false;
            navigationMenu.Size = new Size(119, 395);
            navigationMenu.TabIndex = 2;
            navigationMenu.AfterSelect += navigationMenu_AfterSelect;
            // 
            // imageListNavigation
            // 
            imageListNavigation.ColorDepth = ColorDepth.Depth32Bit;
            imageListNavigation.ImageStream = (ImageListStreamer)resources.GetObject("imageListNavigation.ImageStream");
            imageListNavigation.TransparentColor = Color.Transparent;
            imageListNavigation.Images.SetKeyName(0, "icons8-moleskine-16.png");
            imageListNavigation.Images.SetKeyName(1, "icons8-overview-16.png");
            imageListNavigation.Images.SetKeyName(2, "icons8-factory-16.png");
            imageListNavigation.Images.SetKeyName(3, "icons8-worker-16.png");
            imageListNavigation.Images.SetKeyName(4, "icons8-deployment-16.png");
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(119, 24);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(696, 395);
            mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 441);
            Controls.Add(mainPanel);
            Controls.Add(navigationMenu);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "UltraLogger";
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem loginMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private TreeView navigationMenu;
        private ImageList imageListNavigation;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem управлениеПользователямиToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem6;
        private Panel mainPanel;
    }
}
