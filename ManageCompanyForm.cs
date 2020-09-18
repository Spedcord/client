using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SpedcordClient
{
    public partial class ManageCompanyForm : MaterialForm
    {
        private readonly Company _company;
        private readonly User _user;
        private ApiClient _apiClient;

        public ManageCompanyForm(User user, Company company, ApiClient apiClient)
        {
            _user = user;
            _company = company;
            _apiClient = apiClient;

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

            UpdateCompanyInfo();
            UpdateMembers();
            UpdateRoles();
        }

        private void UpdateRoles()
        {
            roleList.Items.Clear();

            foreach (var role in _company.Roles)
            {
                roleList.Items.Add(role.Name);
            }
        }

        private void UpdateMembers()
        {
            memberList.Items.Clear();

            new Thread(() =>
            {
                foreach (var id in _company.MemberDiscordIds)
                {
                    var user = _apiClient.GetUser(id);
                    Invoke((Action<string>) AddItem,
                        (user.Oauth.Name ?? "Error " + id) + (user.Oauth.Name == null ? "" : "#") +
                        (user.Oauth.Discriminator ?? ""));
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
            leftRowLabel.Text = "Balance:\nRanking:\nMembers:\nRoles:";
            rightRowLabel.Text = "$" + $"{_company.Balance:#,0.##}" + "\n" + _company.Rank + ". place\n" +
                                 _company.MemberDiscordIds.Length + " members\n" + _company.Roles.Length + " roles";
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
            if (index == -1)
            {
                return;
            }

            var form = new EditRoleForm(_apiClient, _company.Roles[index], _company.Id);
            form.Show();
        }
    }
}