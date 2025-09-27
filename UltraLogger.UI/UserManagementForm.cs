using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class UserManagementForm : Form
    {
        private readonly AdministratorService _administratorService;
        public UserManagementForm(AdministratorService administratorService)
        {
            _administratorService = administratorService;
            InitializeComponent();
        }
    }
}
