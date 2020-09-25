using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using SpedcordClient.api;

namespace SpedcordClient
{
    public partial class ShopForm : MaterialForm
    {
        private ApiClient _apiClient;
        private Company _company;
        private readonly ManageCompanyForm _manageCompanyForm;

        private ShopItem _customInvite;
        private ShopItem _increaseLimit;
        
        public ShopForm(ApiClient apiClient, Company company, ManageCompanyForm manageCompanyForm)
        {
            _apiClient = apiClient;
            _company = company;
            _manageCompanyForm = manageCompanyForm;

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

            UpdateAll();
        }

        private void UpdateAll()
        {
            _manageCompanyForm.UpdateAll();
            _company = _manageCompanyForm._company;
            
            var shopItems = _apiClient.GetShopItems(_company.DiscordServerId);
            foreach (var shopItem in shopItems)
            {
                switch (shopItem.Id)
                {
                    case 0:
                        buttonCustomInvite.Text = "Purchase custom invite for $" + shopItem.Price;
                        _customInvite = shopItem;
                        break;
                    case 1:
                        increaseMemberButton.Text = "Increase member limit by 1 for $" + shopItem.Price;
                        _increaseLimit = shopItem;
                        break;
                }
            }

            string purchasedStr = "";
            if (_company.PurchasedItems.Contains(_customInvite.Id))
            {
                buttonCustomInvite.Enabled = false;
                purchasedStr += "1x Custom invite";

            }

            long upgrades = _company.PurchasedItems.Where(i => i == _increaseLimit.Id).LongCount();
            if (upgrades != 0)
            {
                purchasedStr += "\n" + upgrades + "x Member limit upgrades";

            }

            purchasedLabel.Text = purchasedStr;
        }

        private void buttonCustomInvite_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Custom invites can only be purchased once. You cannot edit a purchased custom invite.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.Cancel || result == DialogResult.None)
                return;

            var input = Interaction.InputBox(
                "Please enter id you'd like:\nThe invite link will look like this: https://i.spedcord.xyz/{id}",
                "Enter id");
            Regex filter = new Regex("[A-Za-z0-9_-]+");
            if (!filter.IsMatch(input))
            {
                MessageBox.Show("The id can only contain alphanumeric characters and _-", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var apiResponse = _apiClient.PurchaseItem(Program.DISCORD_ID, Program.KEY, _company.DiscordServerId, _customInvite.Id,
                new object[] {input});
            if (apiResponse.ReadResponseMessage().Equals("Purchase was cancelled (Hint: check your arguments)"))
                apiResponse.Response = "{\"message\":\"Purchase was cancelled\n(Hint: The id you chose is probably taken.)\"}";
            
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            UpdateAll();
        }

        private void increaseMemberButton_Click(object sender, EventArgs e)
        {
            var apiResponse = _apiClient.PurchaseItem(Program.DISCORD_ID, Program.KEY, _company.DiscordServerId, _increaseLimit.Id,
                new object[0]);
            Debug.WriteLine(apiResponse.Response);
            MessageBox.Show(apiResponse.ReadResponseMessage(),
                apiResponse.StatusCode != HttpStatusCode.OK ? "Error" : "Success",
                MessageBoxButtons.OK,
                apiResponse.StatusCode != HttpStatusCode.OK ? MessageBoxIcon.Error : MessageBoxIcon.Information);
            UpdateAll();
        }
    }
}