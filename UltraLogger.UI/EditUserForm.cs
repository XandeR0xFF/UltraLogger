using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class EditUserForm : Form
    {
        private readonly UserService _userService;

        private UserDTO? _user;

        public EditUserForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        public DialogResult ShowCreateUserDialog()
        {
            return ShowDialog();
        }

        public DialogResult ShowEditUserDialog(UserDTO userDTO)
        {
            _user = userDTO;
            loginTextBox.Enabled = false;
            passwordTextBox.Visible = false;
            label2.Visible = false;

            loginTextBox.Text = userDTO.Login;
            firstNameTextBox.Text = userDTO.FirstName;
            lastNameTextBox.Text = userDTO.LastName;
            middleNameTextBox.Text = userDTO.MiddleName;

            return ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Result result;
            if (_user == null)
            {
                CreateUserDTO userForCreate = new CreateUserDTO()
                { 
                    Login = loginTextBox.Text,
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    MiddleName = middleNameTextBox.Text,
                    Password = passwordTextBox.Text
                };
                result = _userService.CreateUser(userForCreate);
            }
            else
            {
                _user.FirstName = firstNameTextBox.Text;
                _user.LastName = lastNameTextBox.Text;
                _user.MiddleName = middleNameTextBox.Text;
                result = _userService.UpdateUser(_user);
            }

            if (result.IsSuccess)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                errorLabel.Text = result.Error.Description;
            }
        }
    }
}
