using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class ChangeAdminPasswordForm : Form
    {
        private readonly AdministratorService _administratorService;
        public ChangeAdminPasswordForm(AdministratorService administratorService)
        {
            _administratorService = administratorService;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Result r = _administratorService.ChangePassword(oldPasswordTextBox.Text, newPasswordTextBox.Text, confirmPasswordTextBox.Text);
            if (r.IsSuccess)
                Close();

            errorLabel.Text = r.Error.Description;
        }
    }
}
