using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Windows.Data.Json;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using SpedcordClient.api;

namespace SpedcordClient
{
    public partial class EditRoleForm : MaterialForm
    {
        public bool Success = false;

        private bool edit;
        private ApiClient _apiClient;
        private Role _role;
        private int companyId;

        public EditRoleForm(ApiClient apiClient, Role role, int companyId, bool edit)
        {
            _apiClient = apiClient;
            _role = role;
            this.companyId = companyId;
            this.edit = edit;

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

            if (!edit)
            {
                Text = "Create Role";
                _role = new Role {Name = _role.Name, Payout = 1000, Permissions = 0, MemberDiscordIds = new long[0]};
            }

            roleLabel.Text = (edit ? "Editing" : "Creating") + " role " + _role.Name;
            payoutTextField.Text = _role.Payout.ToString(new NumberFormatInfo {NumberDecimalSeparator = "."});

            permAdmin.CheckStateChanged += (sender, args) =>
            {
                if (permAdmin.CheckState == CheckState.Checked)
                {
                    permEditCompany.Enabled = false;
                    permManageMembers.Enabled = false;
                    permManageRoles.Enabled = false;
                    permBuyItems.Enabled = false;
                }
                else
                {
                    permEditCompany.Enabled = true;
                    permManageMembers.Enabled = true;
                    permManageRoles.Enabled = true;
                    permBuyItems.Enabled = true;
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

            if (Role.PermissionMethods.HasPermission(role.Permissions, Role.Permission.BuyItems))
            {
                permBuyItems.CheckState = CheckState.Checked;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            double payout;
            try
            {
                var formatInfo = new NumberFormatInfo {NumberDecimalSeparator = "."};
                payout = double.Parse(payoutTextField.Text, NumberStyles.Float, formatInfo);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid payout.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Debug.WriteLine(payout);
            if (payout < 1 || payout > 100_000)
            {
                MessageBox.Show("Please enter a valid payout. (1 - 100.000)", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                if (permBuyItems.CheckState == CheckState.Checked)
                    list.Add(Role.Permission.BuyItems);
            }

            var permsInt = Role.PermissionMethods.Calculate(list.ToArray());

            updateButton.Enabled = false;

            var apiResponse = edit
                ? _apiClient.EditRole(Program.DISCORD_ID, Program.KEY, companyId, _role.Name, payout, permsInt)
                : _apiClient.CreateRole(Program.DISCORD_ID, Program.KEY, companyId, _role.Name, payout, permsInt);

            MessageBox.Show(apiResponse.ReadResponseMessage(), apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                Success = true;
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