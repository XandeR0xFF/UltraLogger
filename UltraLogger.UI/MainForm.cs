using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class MainForm : Form
    {
        private readonly AuthenticationService _authenticationService;
        private readonly DefectogramService _defectogramService;
        private readonly AdministratorService _administratorService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        private readonly ReportService _reportService;
        private readonly PlateService _plateService;
        private readonly UserService _userService;

        private UserControl? _currentView;

        public MainForm(
            AuthenticationService authenticationService,
            DefectogramService defectogramService,
            AdministratorService administratorService,
            CustomerService customerService,
            OrderService orderService,
            ReportService reportService,
            PlateService plateService,
            UserService userService)
        {
            _authenticationService = authenticationService;
            _defectogramService = defectogramService;
            _administratorService = administratorService;
            _customerService = customerService;
            _orderService = orderService;
            _reportService = reportService;
            _plateService = plateService;
            _userService = userService;

            InitializeComponent();

            navigationMenu.Nodes["Log"]!.Tag = new UTLogControl(defectogramService, _authenticationService, _plateService, _userService, _reportService, _orderService, _customerService);
            navigationMenu.Nodes["Reports"]!.Tag = new ReportsControl(_reportService, _orderService, _customerService, _defectogramService, _plateService);
            navigationMenu.Nodes["Orders"]!.Tag = new OrdersControl(_orderService, _customerService);
            navigationMenu.Nodes["Customers"]!.Tag = new CustomersControl(_customerService);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Show();
            ShowAuthenticationView();
        }

        private void ShowAuthenticationView()
        {
            loginMenuItem.Visible = false;
            AuthenticationForm form = new AuthenticationForm(_authenticationService, _administratorService, _userService);
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

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userManagementMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementForm form = new UserManagementForm(_administratorService, _userService);
            form.ShowDialog();
        }

        private void switchUser_Click(object sender, EventArgs e)
        {
            ShowAuthenticationView();
        }
    }
}
