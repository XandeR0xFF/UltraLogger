using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class ResetUserPasswordForm : Form
{
    private readonly UserService _userService;
    private readonly long _userId;

    public ResetUserPasswordForm(UserService userService, long userId)
    {
        _userService = userService;
        _userId = userId;
        InitializeComponent();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        Result result = _userService.ResetUserPassword(_userId, passwordTextBox.Text);
        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        errorLabel.Text = result.Error.Description;
    }
}
