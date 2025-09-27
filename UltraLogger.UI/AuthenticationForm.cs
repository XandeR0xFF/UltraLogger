using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class AuthenticationForm : Form
{
    private readonly AuthenticationService _authenticationService;
    private readonly AdministratorService _administratorService;

    public AuthenticationForm(AuthenticationService authenticationService, AdministratorService administratorService)
    {
        _authenticationService = authenticationService;
        _administratorService = administratorService;

        InitializeComponent();
        errorLabel.Visible = false;
    }

    private void logInButton_Click(object sender, EventArgs e)
    {
        var result = _authenticationService.LogIn(loginTextBox.Text, passwordTextBox.Text);

        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        errorLabel.Text = result.Error.Description;
        errorLabel.Visible = true;
    }

    private void userManagementButton_Click(object sender, EventArgs e)
    {
        UserManagementForm form = new UserManagementForm(_administratorService);
        form.ShowDialog();
    }
}
