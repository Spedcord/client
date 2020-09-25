using System;
using System.ComponentModel;

namespace SpedcordClient
{
    partial class ManageCompanyForm
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
            this.companyOverviewTitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.roleManagementTitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.memberManagementTitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.companyNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.leftRowLabel = new MaterialSkin.Controls.MaterialLabel();
            this.rightRowLabel = new MaterialSkin.Controls.MaterialLabel();
            this.kickButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.addRoleButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.removeRoleButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.editRoleButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.memberList = new System.Windows.Forms.ListBox();
            this.roleList = new System.Windows.Forms.ListBox();
            this.changeRoleButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.editNameButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.editDefRole = new MaterialSkin.Controls.MaterialFlatButton();
            this.shopButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // companyOverviewTitleLabel
            // 
            this.companyOverviewTitleLabel.Depth = 0;
            this.companyOverviewTitleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.companyOverviewTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.companyOverviewTitleLabel.Location = new System.Drawing.Point(329, 74);
            this.companyOverviewTitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.companyOverviewTitleLabel.Name = "companyOverviewTitleLabel";
            this.companyOverviewTitleLabel.Size = new System.Drawing.Size(143, 22);
            this.companyOverviewTitleLabel.TabIndex = 0;
            this.companyOverviewTitleLabel.Text = "Company overview";
            this.companyOverviewTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roleManagementTitleLabel
            // 
            this.roleManagementTitleLabel.Depth = 0;
            this.roleManagementTitleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.roleManagementTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.roleManagementTitleLabel.Location = new System.Drawing.Point(599, 74);
            this.roleManagementTitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.roleManagementTitleLabel.Name = "roleManagementTitleLabel";
            this.roleManagementTitleLabel.Size = new System.Drawing.Size(143, 22);
            this.roleManagementTitleLabel.TabIndex = 1;
            this.roleManagementTitleLabel.Text = "Role management";
            this.roleManagementTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memberManagementTitleLabel
            // 
            this.memberManagementTitleLabel.Depth = 0;
            this.memberManagementTitleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.memberManagementTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.memberManagementTitleLabel.Location = new System.Drawing.Point(45, 74);
            this.memberManagementTitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.memberManagementTitleLabel.Name = "memberManagementTitleLabel";
            this.memberManagementTitleLabel.Size = new System.Drawing.Size(192, 22);
            this.memberManagementTitleLabel.TabIndex = 2;
            this.memberManagementTitleLabel.Text = "Member management";
            this.memberManagementTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (31)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(277, 74);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 364);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (31)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(531, 74);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(10, 364);
            this.materialDivider2.TabIndex = 4;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.companyNameLabel.Depth = 0;
            this.companyNameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.companyNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.companyNameLabel.Location = new System.Drawing.Point(293, 126);
            this.companyNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(232, 43);
            this.companyNameLabel.TabIndex = 5;
            this.companyNameLabel.Text = "CompanyName";
            this.companyNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // leftRowLabel
            // 
            this.leftRowLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.leftRowLabel.Depth = 0;
            this.leftRowLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.leftRowLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.leftRowLabel.Location = new System.Drawing.Point(293, 169);
            this.leftRowLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.leftRowLabel.Name = "leftRowLabel";
            this.leftRowLabel.Size = new System.Drawing.Size(115, 180);
            this.leftRowLabel.TabIndex = 6;
            this.leftRowLabel.Text = "LRow";
            // 
            // rightRowLabel
            // 
            this.rightRowLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.rightRowLabel.Depth = 0;
            this.rightRowLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.rightRowLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.rightRowLabel.Location = new System.Drawing.Point(408, 169);
            this.rightRowLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.rightRowLabel.Name = "rightRowLabel";
            this.rightRowLabel.Size = new System.Drawing.Size(117, 180);
            this.rightRowLabel.TabIndex = 7;
            this.rightRowLabel.Text = "RRow";
            this.rightRowLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // kickButton
            // 
            this.kickButton.AutoSize = true;
            this.kickButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kickButton.Depth = 0;
            this.kickButton.Icon = null;
            this.kickButton.Location = new System.Drawing.Point(159, 402);
            this.kickButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.kickButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.kickButton.Name = "kickButton";
            this.kickButton.Primary = false;
            this.kickButton.Size = new System.Drawing.Size(111, 36);
            this.kickButton.TabIndex = 8;
            this.kickButton.Text = "Kick member";
            this.kickButton.UseVisualStyleBackColor = true;
            // 
            // addRoleButton
            // 
            this.addRoleButton.AutoSize = true;
            this.addRoleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addRoleButton.Depth = 0;
            this.addRoleButton.Icon = null;
            this.addRoleButton.Location = new System.Drawing.Point(548, 402);
            this.addRoleButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addRoleButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addRoleButton.Name = "addRoleButton";
            this.addRoleButton.Primary = false;
            this.addRoleButton.Size = new System.Drawing.Size(29, 36);
            this.addRoleButton.TabIndex = 9;
            this.addRoleButton.Text = "+";
            this.addRoleButton.UseVisualStyleBackColor = true;
            // 
            // removeRoleButton
            // 
            this.removeRoleButton.AutoSize = true;
            this.removeRoleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeRoleButton.Depth = 0;
            this.removeRoleButton.Icon = null;
            this.removeRoleButton.Location = new System.Drawing.Point(762, 402);
            this.removeRoleButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.removeRoleButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.removeRoleButton.Name = "removeRoleButton";
            this.removeRoleButton.Primary = false;
            this.removeRoleButton.Size = new System.Drawing.Size(25, 36);
            this.removeRoleButton.TabIndex = 10;
            this.removeRoleButton.Text = "-";
            this.removeRoleButton.UseVisualStyleBackColor = true;
            // 
            // editRoleButton
            // 
            this.editRoleButton.AutoSize = true;
            this.editRoleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editRoleButton.Depth = 0;
            this.editRoleButton.Icon = null;
            this.editRoleButton.Location = new System.Drawing.Point(592, 402);
            this.editRoleButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.editRoleButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.editRoleButton.Name = "editRoleButton";
            this.editRoleButton.Primary = false;
            this.editRoleButton.Size = new System.Drawing.Size(155, 36);
            this.editRoleButton.TabIndex = 11;
            this.editRoleButton.Text = "Edit selected role";
            this.editRoleButton.UseVisualStyleBackColor = true;
            // 
            // memberList
            // 
            this.memberList.BackColor = System.Drawing.Color.Gainsboro;
            this.memberList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.memberList.FormattingEnabled = true;
            this.memberList.ItemHeight = 16;
            this.memberList.Location = new System.Drawing.Point(12, 99);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(258, 292);
            this.memberList.TabIndex = 12;
            // 
            // roleList
            // 
            this.roleList.BackColor = System.Drawing.Color.Gainsboro;
            this.roleList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.roleList.FormattingEnabled = true;
            this.roleList.ItemHeight = 16;
            this.roleList.Location = new System.Drawing.Point(548, 99);
            this.roleList.Name = "roleList";
            this.roleList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.roleList.Size = new System.Drawing.Size(240, 292);
            this.roleList.TabIndex = 13;
            // 
            // changeRoleButton
            // 
            this.changeRoleButton.AutoSize = true;
            this.changeRoleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.changeRoleButton.Depth = 0;
            this.changeRoleButton.Icon = null;
            this.changeRoleButton.Location = new System.Drawing.Point(13, 402);
            this.changeRoleButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.changeRoleButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.changeRoleButton.Name = "changeRoleButton";
            this.changeRoleButton.Primary = false;
            this.changeRoleButton.Size = new System.Drawing.Size(112, 36);
            this.changeRoleButton.TabIndex = 14;
            this.changeRoleButton.Text = "Change role";
            this.changeRoleButton.UseVisualStyleBackColor = true;
            // 
            // editNameButton
            // 
            this.editNameButton.AutoSize = true;
            this.editNameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editNameButton.Depth = 0;
            this.editNameButton.Icon = null;
            this.editNameButton.Location = new System.Drawing.Point(293, 402);
            this.editNameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.editNameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.editNameButton.Name = "editNameButton";
            this.editNameButton.Primary = false;
            this.editNameButton.Size = new System.Drawing.Size(92, 36);
            this.editNameButton.TabIndex = 15;
            this.editNameButton.Text = "Edit name";
            this.editNameButton.UseVisualStyleBackColor = true;
            // 
            // editDefRole
            // 
            this.editDefRole.AutoSize = true;
            this.editDefRole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editDefRole.Depth = 0;
            this.editDefRole.Icon = null;
            this.editDefRole.Location = new System.Drawing.Point(329, 355);
            this.editDefRole.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.editDefRole.MouseState = MaterialSkin.MouseState.HOVER;
            this.editDefRole.Name = "editDefRole";
            this.editDefRole.Primary = false;
            this.editDefRole.Size = new System.Drawing.Size(148, 36);
            this.editDefRole.TabIndex = 16;
            this.editDefRole.Text = "Edit default role";
            this.editDefRole.UseVisualStyleBackColor = true;
            // 
            // shopButton
            // 
            this.shopButton.AutoSize = true;
            this.shopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.shopButton.Depth = 0;
            this.shopButton.Icon = null;
            this.shopButton.Location = new System.Drawing.Point(428, 402);
            this.shopButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.shopButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.shopButton.Name = "shopButton";
            this.shopButton.Primary = false;
            this.shopButton.Size = new System.Drawing.Size(96, 36);
            this.shopButton.TabIndex = 17;
            this.shopButton.Text = "Open shop";
            this.shopButton.UseVisualStyleBackColor = true;
            // 
            // ManageCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shopButton);
            this.Controls.Add(this.editDefRole);
            this.Controls.Add(this.editNameButton);
            this.Controls.Add(this.changeRoleButton);
            this.Controls.Add(this.roleList);
            this.Controls.Add(this.memberList);
            this.Controls.Add(this.editRoleButton);
            this.Controls.Add(this.removeRoleButton);
            this.Controls.Add(this.addRoleButton);
            this.Controls.Add(this.kickButton);
            this.Controls.Add(this.rightRowLabel);
            this.Controls.Add(this.leftRowLabel);
            this.Controls.Add(this.companyNameLabel);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.memberManagementTitleLabel);
            this.Controls.Add(this.roleManagementTitleLabel);
            this.Controls.Add(this.companyOverviewTitleLabel);
            this.MaximizeBox = false;
            this.Name = "ManageCompanyForm";
            this.Sizable = false;
            this.Text = "Company Manager";
            this.Load += new System.EventHandler(this.ManageCompanyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialFlatButton shopButton;

        private MaterialSkin.Controls.MaterialFlatButton editDefRole;
        private MaterialSkin.Controls.MaterialFlatButton editNameButton;

        private MaterialSkin.Controls.MaterialFlatButton changeRoleButton;

        private System.Windows.Forms.ListBox roleList;

        private System.Windows.Forms.ListBox memberList;

        private MaterialSkin.Controls.MaterialFlatButton addRoleButton;
        private MaterialSkin.Controls.MaterialFlatButton editRoleButton;
        private MaterialSkin.Controls.MaterialFlatButton kickButton;
        private MaterialSkin.Controls.MaterialFlatButton removeRoleButton;

        private MaterialSkin.Controls.MaterialLabel leftRowLabel;
        private MaterialSkin.Controls.MaterialLabel rightRowLabel;

        private MaterialSkin.Controls.MaterialLabel companyNameLabel;

        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;

        private MaterialSkin.Controls.MaterialLabel memberManagementTitleLabel;
        private MaterialSkin.Controls.MaterialLabel roleManagementTitleLabel;

        private MaterialSkin.Controls.MaterialLabel companyOverviewTitleLabel;

        #endregion
    }
}