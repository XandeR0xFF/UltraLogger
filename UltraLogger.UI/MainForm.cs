using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class MainForm : Form
    {
        private readonly AuthenticationService _authenticationService;
        private readonly DefectogramService _defectogramService;
        private readonly AdministratorService _administratorService;

        private UserControl? _currentView;

        public MainForm(
            AuthenticationService authenticationService,
            DefectogramService defectogramService,
            AdministratorService administratorService)
        {
            _authenticationService = authenticationService;
            _defectogramService = defectogramService;
            _administratorService = administratorService;

            InitializeComponent();

            navigationMenu.Nodes["Log"]!.Tag = new UTLogControl(_defectogramService, _authenticationService);
            navigationMenu.Nodes["Reports"]!.Tag = new ReportsControl();
            navigationMenu.Nodes["Orders"]!.Tag = new OrdersControl();
            navigationMenu.Nodes["Customers"]!.Tag = new CustomersControl();

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Show();
            ShowAuthenticationView();
        }

        private void ShowAuthenticationView()
        {
            loginMenuItem.Visible = false;
            AuthenticationForm form = new AuthenticationForm(_authenticationService);
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                Close();
                return;
            }

            var userResult = _authenticationService.GetCurrentUser();
            if (userResult.IsSuccess)
            {
                loginMenuItem.Text = userResult.Value?.Login;
                loginMenuItem.Visible = true;
            }
            else
            {
                throw new InvalidOperationException(userResult.Error.Description);
            }
        }

        private void navigationMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _currentView?.Hide();
            _currentView = (UserControl)(e.Node!.Tag);
            _currentView.Parent = mainPanel;
            _currentView.Dock = DockStyle.Fill;
            _currentView.Show();
        }

        private void changeAdminPasswordMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAdminPasswordForm form = new ChangeAdminPasswordForm(_administratorService);
            form.ShowDialog();
        }
    }
}
