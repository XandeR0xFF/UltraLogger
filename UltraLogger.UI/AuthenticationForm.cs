using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class AuthenticationForm : Form
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationForm(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;

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
}
