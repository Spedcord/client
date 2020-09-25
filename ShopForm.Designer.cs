using System.ComponentModel;

namespace SpedcordClient
{
    partial class ShopForm
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
            this.purchasedTitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.purchasedLabel = new MaterialSkin.Controls.MaterialLabel();
            this.buttonCustomInvite = new MaterialSkin.Controls.MaterialRaisedButton();
            this.increaseMemberButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // purchasedTitleLabel
            // 
            this.purchasedTitleLabel.Depth = 0;
            this.purchasedTitleLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.purchasedTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.purchasedTitleLabel.Location = new System.Drawing.Point(12, 73);
            this.purchasedTitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.purchasedTitleLabel.Name = "purchasedTitleLabel";
            this.purchasedTitleLabel.Size = new System.Drawing.Size(192, 22);
            this.purchasedTitleLabel.TabIndex = 3;
            this.purchasedTitleLabel.Text = "Purchased items";
            this.purchasedTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchasedLabel
            // 
            this.purchasedLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.purchasedLabel.Depth = 0;
            this.purchasedLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.purchasedLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (222)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.purchasedLabel.Location = new System.Drawing.Point(12, 110);
            this.purchasedLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.purchasedLabel.Name = "purchasedLabel";
            this.purchasedLabel.Size = new System.Drawing.Size(192, 67);
            this.purchasedLabel.TabIndex = 4;
            this.purchasedLabel.Text = "None";
            this.purchasedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCustomInvite
            // 
            this.buttonCustomInvite.AutoSize = true;
            this.buttonCustomInvite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCustomInvite.Depth = 0;
            this.buttonCustomInvite.Icon = null;
            this.buttonCustomInvite.Location = new System.Drawing.Point(243, 99);
            this.buttonCustomInvite.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCustomInvite.Name = "buttonCustomInvite";
            this.buttonCustomInvite.Primary = true;
            this.buttonCustomInvite.Size = new System.Drawing.Size(257, 36);
            this.buttonCustomInvite.TabIndex = 5;
            this.buttonCustomInvite.Text = "Purchase a custom invite for $0";
            this.buttonCustomInvite.UseVisualStyleBackColor = true;
            this.buttonCustomInvite.Click += new System.EventHandler(this.buttonCustomInvite_Click);
            // 
            // increaseMemberButton
            // 
            this.increaseMemberButton.AutoSize = true;
            this.increaseMemberButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.increaseMemberButton.Depth = 0;
            this.increaseMemberButton.Icon = null;
            this.increaseMemberButton.Location = new System.Drawing.Point(243, 141);
            this.increaseMemberButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.increaseMemberButton.Name = "increaseMemberButton";
            this.increaseMemberButton.Primary = true;
            this.increaseMemberButton.Size = new System.Drawing.Size(264, 36);
            this.increaseMemberButton.TabIndex = 6;
            this.increaseMemberButton.Text = "Increase member limit by 1 for $0";
            this.increaseMemberButton.UseVisualStyleBackColor = true;
            this.increaseMemberButton.Click += new System.EventHandler(this.increaseMemberButton_Click);
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 197);
            this.Controls.Add(this.increaseMemberButton);
            this.Controls.Add(this.buttonCustomInvite);
            this.Controls.Add(this.purchasedLabel);
            this.Controls.Add(this.purchasedTitleLabel);
            this.MaximizeBox = false;
            this.Name = "ShopForm";
            this.Sizable = false;
            this.Text = "ShopForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialRaisedButton buttonCustomInvite;
        private MaterialSkin.Controls.MaterialRaisedButton increaseMemberButton;
        private MaterialSkin.Controls.MaterialLabel purchasedLabel;
        private MaterialSkin.Controls.MaterialLabel purchasedTitleLabel;

        #endregion
    }
}