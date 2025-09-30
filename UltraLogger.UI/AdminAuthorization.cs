using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class AdminAuthorization : Form
    {
        private readonly AdministratorService _administratorService;

        public AdminAuthorization(AdministratorService administratorService)
        {
            _administratorService = administratorService;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Result result = _administratorService.Authenticate(passwordTextBox.Text);
            if (result.IsSuccess)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            errorLabel.Text = result.Error.Description;
        }
    }
}
