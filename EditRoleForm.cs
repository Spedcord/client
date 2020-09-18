using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Windows.Data.Json;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace SpedcordClient
{
    public partial class EditRoleForm : MaterialForm
    {
        private ApiClient _apiClient;
        private Role _role;
        private int companyId;

        public EditRoleForm(ApiClient apiClient, Role role, int companyId)
        {
            _apiClient = apiClient;
            _role = role;
            this.companyId = companyId;

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

            roleLabel.Text = "Editing role " + _role.Name;
            payoutTextField.Text = _role.Payout + "";

            permAdmin.CheckStateChanged += (sender, args) =>
            {
                if (permAdmin.CheckState == CheckState.Checked)
                {
                    permEditCompany.Enabled = false;
                    permManageMembers.Enabled = false;
                    permManageRoles.Enabled = false;
                }
                else
                {
                    permEditCompany.Enabled = true;
                    permManageMembers.Enabled = true;
                    permManageRoles.Enabled = true;
                }
            };

            if (Role.PermissionMethods.HasPermission(role.Permissions, Role.Permission.Administrator))
            {
                permAdmin.CheckState = CheckState.Checked;
            }

            if (Role.PermissionMethods.HasPermission(role.Permissions, Role.Permission.EditCompany))
            {
                permEditCompany.CheckState = CheckState.Checked;
            }

            if (Role.PermissionMethods.HasPermission(role.Permissions, Role.Permission.ManageMembers))
            {
                permManageMembers.CheckState = CheckState.Checked;
            }

            if (Role.PermissionMethods.HasPermission(role.Permissions, Role.Permission.ManageRoles))
            {
                permManageRoles.CheckState = CheckState.Checked;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            double payout;
            try
            {
                payout = Double.Parse(payoutTextField.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a valid payout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (payout < 1 || payout > 100_000)
            {
                MessageBox.Show("Please enter a valid payout. (1 - 100.000)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var list = new List<Role.Permission>();
            if (permAdmin.CheckState == CheckState.Checked)
                list.Add(Role.Permission.Administrator);
            else
            {
                if (permEditCompany.CheckState == CheckState.Checked)
                    list.Add(Role.Permission.EditCompany);
                if (permManageMembers.CheckState == CheckState.Checked)
                    list.Add(Role.Permission.ManageMembers);
                if (permManageRoles.CheckState == CheckState.Checked)
                    list.Add(Role.Permission.ManageRoles);
            }

            var permsInt = Role.PermissionMethods.Calculate(list.ToArray());

            updateButton.Enabled = false;

            var apiResponse =
                _apiClient.EditRole(Program.DISCORD_ID, Program.KEY, companyId, _role.Name, payout, permsInt);

            var reader = new JsonTextReader(new StringReader(apiResponse.Response));
            string msg = null;
            bool next = false;
            while (reader.Read())
            {
                if (next)
                {
                    msg = (string) reader.Value;
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName && reader.Value.Equals("message"))
                {
                    next = true;
                }
            }

            MessageBox.Show(msg, apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                Hide();
                Dispose();
            }
            else
            {
                updateButton.Enabled = true;
            }
        }
    }
}