using System.Windows.Forms;

namespace SpedcordClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusTitle = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.jobInfoLabel = new System.Windows.Forms.Label();
            this.jobInfoTitle = new System.Windows.Forms.Label();
            this.placeholder = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.companyLabel = new System.Windows.Forms.Label();
            this.userAvatar = new SpedcordClient.OvalPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jobList = new System.Windows.Forms.ListBox();
            this.reloadButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.companyBalanceLabel = new System.Windows.Forms.Label();
            this.manageCompanyButton = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize) (this.userAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // statusTitle
            // 
            this.statusTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.statusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.statusTitle.Location = new System.Drawing.Point(12, 72);
            this.statusTitle.Name = "statusTitle";
            this.statusTitle.Size = new System.Drawing.Size(285, 30);
            this.statusTitle.TabIndex = 0;
            this.statusTitle.Text = "Current status";
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.statusLabel.Location = new System.Drawing.Point(12, 102);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(285, 24);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Not on a job";
            // 
            // jobInfoLabel
            // 
            this.jobInfoLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.jobInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.jobInfoLabel.Location = new System.Drawing.Point(12, 178);
            this.jobInfoLabel.Name = "jobInfoLabel";
            this.jobInfoLabel.Size = new System.Drawing.Size(285, 164);
            this.jobInfoLabel.TabIndex = 3;
            this.jobInfoLabel.Text = "Not connected to SDK plugin";
            this.jobInfoLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // jobInfoTitle
            // 
            this.jobInfoTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.jobInfoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.jobInfoTitle.Location = new System.Drawing.Point(12, 148);
            this.jobInfoTitle.Name = "jobInfoTitle";
            this.jobInfoTitle.Size = new System.Drawing.Size(285, 30);
            this.jobInfoTitle.TabIndex = 2;
            this.jobInfoTitle.Text = "Job info";
            // 
            // placeholder
            // 
            this.placeholder.BackColor = System.Drawing.Color.Gray;
            this.placeholder.Location = new System.Drawing.Point(-5, 380);
            this.placeholder.Name = "placeholder";
            this.placeholder.Size = new System.Drawing.Size(806, 73);
            this.placeholder.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Gray;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(1, 380);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(245, 34);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // companyLabel
            // 
            this.companyLabel.BackColor = System.Drawing.Color.Gray;
            this.companyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.companyLabel.ForeColor = System.Drawing.Color.White;
            this.companyLabel.Location = new System.Drawing.Point(1, 419);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(245, 34);
            this.companyLabel.TabIndex = 6;
            this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userAvatar
            // 
            this.userAvatar.BackColor = System.Drawing.Color.Gray;
            this.userAvatar.Location = new System.Drawing.Point(741, 389);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(54, 54);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 7;
            this.userAvatar.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(374, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Your deliveries";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // jobList
            // 
            this.jobList.BackColor = System.Drawing.Color.Gainsboro;
            this.jobList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.jobList.FormattingEnabled = true;
            this.jobList.ItemHeight = 20;
            this.jobList.Location = new System.Drawing.Point(374, 102);
            this.jobList.Name = "jobList";
            this.jobList.Size = new System.Drawing.Size(400, 200);
            this.jobList.TabIndex = 9;
            // 
            // reloadButton
            // 
            this.reloadButton.AutoSize = true;
            this.reloadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reloadButton.Depth = 0;
            this.reloadButton.Icon = null;
            this.reloadButton.Location = new System.Drawing.Point(702, 306);
            this.reloadButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.reloadButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Primary = false;
            this.reloadButton.Size = new System.Drawing.Size(72, 36);
            this.reloadButton.TabIndex = 10;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.BackColor = System.Drawing.Color.Gray;
            this.balanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.balanceLabel.ForeColor = System.Drawing.Color.White;
            this.balanceLabel.Location = new System.Drawing.Point(252, 380);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(245, 34);
            this.balanceLabel.TabIndex = 11;
            this.balanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stateLabel
            // 
            this.stateLabel.BackColor = System.Drawing.Color.Gray;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.stateLabel.ForeColor = System.Drawing.Color.White;
            this.stateLabel.Location = new System.Drawing.Point(252, 419);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(245, 34);
            this.stateLabel.TabIndex = 12;
            this.stateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // companyBalanceLabel
            // 
            this.companyBalanceLabel.BackColor = System.Drawing.Color.Gray;
            this.companyBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.companyBalanceLabel.ForeColor = System.Drawing.Color.White;
            this.companyBalanceLabel.Location = new System.Drawing.Point(252, 419);
            this.companyBalanceLabel.Name = "companyBalanceLabel";
            this.companyBalanceLabel.Size = new System.Drawing.Size(245, 34);
            this.companyBalanceLabel.TabIndex = 13;
            this.companyBalanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // manageCompanyButton
            // 
            this.manageCompanyButton.AutoSize = true;
            this.manageCompanyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.manageCompanyButton.Depth = 0;
            this.manageCompanyButton.Enabled = false;
            this.manageCompanyButton.Icon = null;
            this.manageCompanyButton.Location = new System.Drawing.Point(374, 306);
            this.manageCompanyButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.manageCompanyButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.manageCompanyButton.Name = "manageCompanyButton";
            this.manageCompanyButton.Primary = false;
            this.manageCompanyButton.Size = new System.Drawing.Size(148, 36);
            this.manageCompanyButton.TabIndex = 14;
            this.manageCompanyButton.Text = "Manage Company";
            this.manageCompanyButton.UseVisualStyleBackColor = true;
            this.manageCompanyButton.Click += new System.EventHandler(this.manageCompanyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.manageCompanyButton);
            this.Controls.Add(this.companyBalanceLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.jobList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userAvatar);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.placeholder);
            this.Controls.Add(this.jobInfoLabel);
            this.Controls.Add(this.jobInfoTitle);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusTitle);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Sizable = false;
            this.Text = "Spedcord";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize) (this.userAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialFlatButton manageCompanyButton;

        private System.Windows.Forms.Label companyBalanceLabel;

        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label jobInfoLabel;
        private System.Windows.Forms.Label jobInfoTitle;
        private System.Windows.Forms.ListBox jobList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label placeholder;
        private MaterialSkin.Controls.MaterialFlatButton reloadButton;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusTitle;
        private SpedcordClient.OvalPictureBox userAvatar;

        #endregion
    }
}