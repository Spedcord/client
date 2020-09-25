using System.ComponentModel;

namespace SpedcordClient
{
    partial class EditRoleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.roleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.payoutTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.permAdmin = new MaterialSkin.Controls.MaterialCheckBox();
            this.permEditCompany = new MaterialSkin.Controls.MaterialCheckBox();
            this.permManageRoles = new MaterialSkin.Controls.MaterialCheckBox();
            this.permManageMembers = new MaterialSkin.Controls.MaterialCheckBox();
            this.updateButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.permBuyItems = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // roleLabel
            // 
            this.roleLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.roleLabel.Depth = 0;
            this.roleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.roleLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.roleLabel.Location = new System.Drawing.Point(12, 74);
            this.roleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(431, 23);
            this.roleLabel.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 114);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(118, 23);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Payout:";
            // 
            // payoutTextField
            // 
            this.payoutTextField.Depth = 0;
            this.payoutTextField.Hint = "Please enter a number";
            this.payoutTextField.Location = new System.Drawing.Point(136, 114);
            this.payoutTextField.MaxLength = 100;
            this.payoutTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.payoutTextField.Name = "payoutTextField";
            this.payoutTextField.PasswordChar = '\0';
            this.payoutTextField.SelectedText = "";
            this.payoutTextField.SelectionLength = 0;
            this.payoutTextField.SelectionStart = 0;
            this.payoutTextField.Size = new System.Drawing.Size(307, 23);
            this.payoutTextField.TabIndex = 2;
            this.payoutTextField.TabStop = false;
            this.payoutTextField.Text = "1000";
            this.payoutTextField.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 140);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(118, 23);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Permissions:";
            // 
            // permAdmin
            // 
            this.permAdmin.Depth = 0;
            this.permAdmin.Font = new System.Drawing.Font("Roboto", 10F);
            this.permAdmin.Location = new System.Drawing.Point(136, 140);
            this.permAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.permAdmin.MouseLocation = new System.Drawing.Point(-1, -1);
            this.permAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.permAdmin.Name = "permAdmin";
            this.permAdmin.Ripple = true;
            this.permAdmin.Size = new System.Drawing.Size(127, 24);
            this.permAdmin.TabIndex = 4;
            this.permAdmin.Text = "Administrator";
            this.permAdmin.UseVisualStyleBackColor = true;
            // 
            // permEditCompany
            // 
            this.permEditCompany.Depth = 0;
            this.permEditCompany.Font = new System.Drawing.Font("Roboto", 10F);
            this.permEditCompany.Location = new System.Drawing.Point(263, 140);
            this.permEditCompany.Margin = new System.Windows.Forms.Padding(0);
            this.permEditCompany.MouseLocation = new System.Drawing.Point(-1, -1);
            this.permEditCompany.MouseState = MaterialSkin.MouseState.HOVER;
            this.permEditCompany.Name = "permEditCompany";
            this.permEditCompany.Ripple = true;
            this.permEditCompany.Size = new System.Drawing.Size(148, 24);
            this.permEditCompany.TabIndex = 5;
            this.permEditCompany.Text = "Edit Company";
            this.permEditCompany.UseVisualStyleBackColor = true;
            // 
            // permManageRoles
            // 
            this.permManageRoles.Depth = 0;
            this.permManageRoles.Font = new System.Drawing.Font("Roboto", 10F);
            this.permManageRoles.Location = new System.Drawing.Point(136, 164);
            this.permManageRoles.Margin = new System.Windows.Forms.Padding(0);
            this.permManageRoles.MouseLocation = new System.Drawing.Point(-1, -1);
            this.permManageRoles.MouseState = MaterialSkin.MouseState.HOVER;
            this.permManageRoles.Name = "permManageRoles";
            this.permManageRoles.Ripple = true;
            this.permManageRoles.Size = new System.Drawing.Size(127, 24);
            this.permManageRoles.TabIndex = 6;
            this.permManageRoles.Text = "Manage Roles";
            this.permManageRoles.UseVisualStyleBackColor = true;
            // 
            // permManageMembers
            // 
            this.permManageMembers.Depth = 0;
            this.permManageMembers.Font = new System.Drawing.Font("Roboto", 10F);
            this.permManageMembers.Location = new System.Drawing.Point(263, 164);
            this.permManageMembers.Margin = new System.Windows.Forms.Padding(0);
            this.permManageMembers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.permManageMembers.MouseState = MaterialSkin.MouseState.HOVER;
            this.permManageMembers.Name = "permManageMembers";
            this.permManageMembers.Ripple = true;
            this.permManageMembers.Size = new System.Drawing.Size(148, 24);
            this.permManageMembers.TabIndex = 7;
            this.permManageMembers.Text = "Manage Members";
            this.permManageMembers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.permManageMembers.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.AutoSize = true;
            this.updateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateButton.Depth = 0;
            this.updateButton.Icon = null;
            this.updateButton.Location = new System.Drawing.Point(12, 214);
            this.updateButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateButton.Name = "updateButton";
            this.updateButton.Primary = true;
            this.updateButton.Size = new System.Drawing.Size(111, 36);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Send Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // permBuyItems
            // 
            this.permBuyItems.Depth = 0;
            this.permBuyItems.Font = new System.Drawing.Font("Roboto", 10F);
            this.permBuyItems.Location = new System.Drawing.Point(136, 188);
            this.permBuyItems.Margin = new System.Windows.Forms.Padding(0);
            this.permBuyItems.MouseLocation = new System.Drawing.Point(-1, -1);
            this.permBuyItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.permBuyItems.Name = "permBuyItems";
            this.permBuyItems.Ripple = true;
            this.permBuyItems.Size = new System.Drawing.Size(127, 24);
            this.permBuyItems.TabIndex = 9;
            this.permBuyItems.Text = "Buy Items";
            this.permBuyItems.UseVisualStyleBackColor = true;
            // 
            // EditRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 261);
            this.Controls.Add(this.permBuyItems);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.permManageMembers);
            this.Controls.Add(this.permManageRoles);
            this.Controls.Add(this.permEditCompany);
            this.Controls.Add(this.permAdmin);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.payoutTextField);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.roleLabel);
            this.MaximizeBox = false;
            this.Name = "EditRoleForm";
            this.Sizable = false;
            this.Text = "Edit Role";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialCheckBox permBuyItems;

        private MaterialSkin.Controls.MaterialRaisedButton updateButton;

        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCheckBox permAdmin;
        private MaterialSkin.Controls.MaterialCheckBox permEditCompany;
        private MaterialSkin.Controls.MaterialCheckBox permManageMembers;
        private MaterialSkin.Controls.MaterialCheckBox permManageRoles;

        private MaterialSkin.Controls.MaterialSingleLineTextField payoutTextField;

        private MaterialSkin.Controls.MaterialLabel materialLabel1;

        private MaterialSkin.Controls.MaterialLabel roleLabel;

        #endregion
    }
}