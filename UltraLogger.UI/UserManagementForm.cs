using System.Windows.Forms;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class UserManagementForm : Form
    {
        private readonly AdministratorService _administratorService;
        private readonly UserService _userService;

        public UserManagementForm(AdministratorService administratorService, UserService userService)
        {
            _administratorService = administratorService;
            _userService = userService;
            InitializeComponent();

            UpdateUserList();
        }

        private void UpdateUserList()
        {
            userListView.Items.Clear();
            IEnumerable<UserDTO> users = _userService.GetAll();
            foreach (UserDTO user in users)
            {
                var item = userListView.Items.Add(user.Login);
                item.Tag = user;
                item.SubItems.Add(user.LastName);
                item.SubItems.Add(user.FirstName);
                item.SubItems.Add(user.MiddleName);
                item.SubItems.Add(user.IsActive ? "Активен" : "Заблокирован");
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            AdminAuthorization form = new AdminAuthorization(_administratorService);
            if (form.ShowDialog() != DialogResult.OK)
                Close();
        }

        private void userListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userListView.SelectedItems.Count > 0)
            {
                UserDTO user = (UserDTO)userListView.SelectedItems[0].Tag!;
                editButton.Enabled = true;
                lockButton.Enabled = true;
                lockButton.Text = user.IsActive ? "Заблокировать" : "Разблокировать";
                resetPasswordButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
                lockButton.Enabled = false;
                resetPasswordButton.Enabled = false;
            }
        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            if (userListView.SelectedItems.Count > 0)
            {
                UserDTO user = (UserDTO)userListView.SelectedItems[0].Tag!;
                user.IsActive = !user.IsActive;
                if (_userService.UpdateUser(user).IsSuccess)
                    UpdateUserList();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            EditUserForm form = new EditUserForm(_userService);
            if (form.ShowCreateUserDialog() == DialogResult.OK)
                UpdateUserList();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (userListView.SelectedItems.Count > 0)
            {
                UserDTO user = (UserDTO)userListView.SelectedItems[0].Tag!;
                EditUserForm form = new EditUserForm(_userService);
                if (form.ShowEditUserDialog(user) == DialogResult.OK)
                    UpdateUserList();
            }
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            if (userListView.SelectedItems.Count > 0)
            {
                UserDTO user = (UserDTO)userListView.SelectedItems[0].Tag!;
                ResetUserPasswordForm form = new ResetUserPasswordForm(_userService, user.Id);
                if (form.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("Пароль успешно изменен.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
