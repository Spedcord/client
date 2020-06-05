using System.ComponentModel;

namespace SpedcordClient
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.discordIdInput = new System.Windows.Forms.TextBox();
            this.keyInput = new System.Windows.Forms.TextBox();
            this.discordIdLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.registerButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.helpButton = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "https://spedcord.xyz/img/spedcord.png";
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Roboto", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(191, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spedcord Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // discordIdInput
            // 
            this.discordIdInput.Location = new System.Drawing.Point(213, 232);
            this.discordIdInput.MaxLength = 32;
            this.discordIdInput.Name = "discordIdInput";
            this.discordIdInput.Size = new System.Drawing.Size(456, 20);
            this.discordIdInput.TabIndex = 2;
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(213, 295);
            this.keyInput.MaxLength = 32;
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(456, 20);
            this.keyInput.TabIndex = 3;
            this.keyInput.UseSystemPasswordChar = true;
            // 
            // discordIdLabel
            // 
            this.discordIdLabel.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.discordIdLabel.Location = new System.Drawing.Point(213, 191);
            this.discordIdLabel.Name = "discordIdLabel";
            this.discordIdLabel.Size = new System.Drawing.Size(182, 29);
            this.discordIdLabel.TabIndex = 4;
            this.discordIdLabel.Text = "Discord ID:";
            this.discordIdLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // keyLabel
            // 
            this.keyLabel.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyLabel.Location = new System.Drawing.Point(213, 263);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(182, 29);
            this.keyLabel.TabIndex = 5;
            this.keyLabel.Text = "Key:";
            this.keyLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button
            // 
            this.button.AutoSize = true;
            this.button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button.Depth = 0;
            this.button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button.Icon = null;
            this.button.Location = new System.Drawing.Point(213, 381);
            this.button.MouseState = MaterialSkin.MouseState.HOVER;
            this.button.Name = "button";
            this.button.Primary = true;
            this.button.Size = new System.Drawing.Size(61, 36);
            this.button.TabIndex = 6;
            this.button.Text = "Login";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // registerButton
            // 
            this.registerButton.AutoSize = true;
            this.registerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.registerButton.Depth = 0;
            this.registerButton.Icon = null;
            this.registerButton.Location = new System.Drawing.Point(496, 381);
            this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerButton.Name = "registerButton";
            this.registerButton.Primary = true;
            this.registerButton.Size = new System.Drawing.Size(173, 36);
            this.registerButton.TabIndex = 7;
            this.registerButton.Text = "Register an account";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.AutoSize = true;
            this.helpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.helpButton.Depth = 0;
            this.helpButton.Icon = null;
            this.helpButton.Location = new System.Drawing.Point(130, 279);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.helpButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.helpButton.Name = "helpButton";
            this.helpButton.Primary = false;
            this.helpButton.Size = new System.Drawing.Size(55, 36);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.button);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.discordIdLabel);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.discordIdInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "Spedcord";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialRaisedButton button;
        private System.Windows.Forms.TextBox discordIdInput;
        private System.Windows.Forms.Label discordIdLabel;
        private MaterialSkin.Controls.MaterialFlatButton helpButton;
        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton registerButton;

        #endregion
    }
}