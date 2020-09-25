using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using SpedcordClient.api;

namespace SpedcordClient
{
    public partial class ManageCompanyForm : MaterialForm
    {
        private readonly ApiClient _apiClient;
        private readonly MainForm _mainForm;
        public Company _company;
        private User _user;

        public ManageCompanyForm(User user, Company company, ApiClient apiClient, MainForm mainForm)
        {
            _user = user;
            _company = company;
            _apiClient = apiClient;
            _mainForm = mainForm;

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600, Primary.Red700,
                Primary.Red500, Accent.Red200,
                TextShade.WHITE
            );


            kickButton.Click += kickButton_Click;
            addRoleButton.Click += addRoleButton_Click;
            removeRoleButton.Click += removeRoleButton_Click;
            editRoleButton.Click += editRoleButton_Click;
            changeRoleButton.Click += changeRoleButton_Click;
            editNameButton.Click += editNameButton_Click;
            editDefRole.Click += editDefRoleButton_Click;
            shopButton.Click += shopButton_Click;

            UpdateCompanyInfo();
            UpdateMembers();
            UpdateRoles();
        }

        private void UpdateRoles()
        {
            roleList.Items.Clear();

            foreach (var role in _company.Roles) roleList.Items.Add(role.Name);
        }

        private void UpdateMembers()
        {
            memberList.Items.Clear();

            new Thread(() =>
            {
                foreach (var id in _company.MemberDiscordIds)
                {
                    var user = _apiClient.GetUser(id);
                    var role = _company.GetRole(user.DiscordId);
                    Invoke((Action<string>) AddItem,
                        (user.Oauth.Name ?? "Error " + id) + (user.Oauth.Name == null ? "" : "#") +
                        (user.Oauth.Discriminator ?? "") + (role == null ? "" : " [" + role.Name + "]"));
                }
            }).Start();
        }

        private void AddItem(string item)
        {
            memberList.Items.Add(item);
        }

        private void UpdateCompanyInfo()
        {
            if (_company == null)
            {
                companyNameLabel.Text = "?";
                leftRowLabel.Text = "?";
                rightRowLabel.Text = "?";
                return;
            }

            companyNameLabel.Text = _company.Name;
            leftRowLabel.Text = "Balance:\nRanking:\nMembers:\nRoles:\nDefault role:";
            rightRowLabel.Text = "$" + $"{_company.Balance:#,0.##}" + "\n#" + _company.Rank + "\n" +
                                 _company.MemberDiscordIds.Length + " / " + _company.MemberLimit 
                                 + "\n" + _company.Roles.Length + " roles\n" + _company.DefaultRole;
        }

        public void UpdateAll()
        {
            _mainForm.Reload();
            _company = _mainForm.Company;
            _user = _mainForm.User;

            UpdateCompanyInfo();
            UpdateMembers();
            UpdateRoles();
        }

        private bool CanManageRoles()
        {
            return _company.HasPermission(_user.DiscordId, Role.Permission.ManageRoles);
        }

        private bool CanManageMembers()
        {
            return _company.HasPermission(_user.DiscordId, Role.Permission.ManageMembers);
        }

        private void ManageCompanyForm_Load(object sender, EventArgs e)
        {
        }

        private void editRoleButton_Click(object sender, EventArgs e)
        {
            var index = roleList.SelectedIndex;
            if (index == -1) return;

            var form = new EditRoleForm(_apiClient, _company.Roles[index], _company.Id, true);
            form.Show();
            form.Disposed += (o, args) =>
            {
                if (form.Success) UpdateAll();
            };
        }

        private void addRoleButton_Click(object sender, EventArgs e)
        {
            var input = Interaction.InputBox("Please enter a name for the new role", " ",
                "Name");
            if (input == null || input.Trim().Length == 0) return;

            var form = new EditRoleForm(_apiClient, new Role {Name = input}, _company.Id, false);
            form.Show();
            form.Disposed += (o, args) =>
            {
                if (form.Success) UpdateAll();
            };
        }

        private void removeRoleButton_Click(object sender, EventArgs e)
        {
            var index = roleList.SelectedIndex;
            if (index == -1) return;

            var response =
                _apiClient.RemoveRole(Program.DISCORD_ID, Program.KEY, _company.Id, _company.Roles[index].Name);
            MessageBox.Show(response.ReadResponseMessage(),
                response.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                response.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (response.StatusCode == HttpStatusCode.OK) UpdateAll();
        }

        private void kickButton_Click(object sender, EventArgs e)
        {
            var index = memberList.SelectedIndex;
            if (index == -1) return;

            var apiResponse = _apiClient.KickMember(Program.DISCORD_ID, Program.KEY, _company.DiscordServerId,
                _company.MemberDiscordIds[index]);
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK) UpdateAll();
        }

        private void changeRoleButton_Click(object sender, EventArgs e)
        {
            var index = memberList.SelectedIndex;
            if (index == -1) return;

            var input = Interaction.InputBox("Please enter the role", " ",
                "Role");
            if (input == null || input.Trim().Length == 0) return;
            if (!roleList.Items.Contains(input))
            {
                MessageBox.Show("Unknown role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var apiResponse = _apiClient.UpdateMember(Program.DISCORD_ID, Program.KEY, _company.DiscordServerId,
                _company.MemberDiscordIds[index], input);
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK) UpdateAll();
        }

        private void editNameButton_Click(object sender, EventArgs e)
        {
            var name = Interaction.InputBox("Question", "Please enter a new name for your company:", "");
            if (name == null || name.Equals("")) return;

            var apiResponse = _apiClient.EditCompany(Program.DISCORD_ID, Program.KEY, _company.Id, name, null);
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK) UpdateAll();
        }

        private void editDefRoleButton_Click(object sender, EventArgs e)
        {
            var role = Interaction.InputBox("Question", "Please enter the name of the new default role:", "");
            if (role == null || role.Equals("")) return;

            var apiResponse = _apiClient.EditCompany(Program.DISCORD_ID, Program.KEY, _company.Id, null, role);
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK) UpdateAll();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            var shopForm = new ShopForm(_apiClient, _company, this);
            shopForm.Show();
        }
    }
}