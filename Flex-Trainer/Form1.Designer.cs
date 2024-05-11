namespace Flex_Trainer
{
    partial class signin
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.user_selecter = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SignIn_Button = new Guna.UI2.WinForms.Guna2Button();
            this.SignUp_Button = new Guna.UI2.WinForms.Guna2Button();
            this.gmail_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.password_TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_selecter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.password_TextBox);
            this.groupBox1.Controls.Add(this.gmail_TextBox);
            this.groupBox1.Controls.Add(this.SignUp_Button);
            this.groupBox1.Controls.Add(this.SignIn_Button);
            this.groupBox1.Controls.Add(this.user_selecter);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Location = new System.Drawing.Point(360, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sign in";
            // 
            // user_selecter
            // 
            this.user_selecter.DropDownWidth = 151;
            this.user_selecter.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.user_selecter.Location = new System.Drawing.Point(216, 26);
            this.user_selecter.Name = "user_selecter";
            this.user_selecter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.user_selecter.Size = new System.Drawing.Size(151, 29);
            this.user_selecter.TabIndex = 13;
            this.user_selecter.Text = "User";
            this.user_selecter.SelectedIndexChanged += new System.EventHandler(this.kryptonComboBox1_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(26, 159);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(90, 29);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "Password";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(26, 72);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 29);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "Email";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(1077, 12);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(27, 28);
            this.kryptonButton3.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kryptonButton3.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kryptonButton3.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.kryptonButton3.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.kryptonButton3.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton3.StateCommon.Border.Rounding = 20;
            this.kryptonButton3.TabIndex = 4;
            this.kryptonButton3.Values.Text = " x";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // SignIn_Button
            // 
            this.SignIn_Button.BackColor = System.Drawing.Color.Transparent;
            this.SignIn_Button.BorderRadius = 12;
            this.SignIn_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.SignIn_Button.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SignIn_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SignIn_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SignIn_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SignIn_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SignIn_Button.FillColor = System.Drawing.Color.White;
            this.SignIn_Button.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SignIn_Button.Location = new System.Drawing.Point(244, 297);
            this.SignIn_Button.Name = "SignIn_Button";
            this.SignIn_Button.Size = new System.Drawing.Size(136, 51);
            this.SignIn_Button.TabIndex = 14;
            this.SignIn_Button.Text = "Sign In";
            this.SignIn_Button.UseTransparentBackground = true;
            this.SignIn_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // SignUp_Button
            // 
            this.SignUp_Button.BackColor = System.Drawing.Color.Transparent;
            this.SignUp_Button.BorderRadius = 12;
            this.SignUp_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.SignUp_Button.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SignUp_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SignUp_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SignUp_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SignUp_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SignUp_Button.FillColor = System.Drawing.Color.White;
            this.SignUp_Button.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SignUp_Button.Location = new System.Drawing.Point(26, 297);
            this.SignUp_Button.Name = "SignUp_Button";
            this.SignUp_Button.Size = new System.Drawing.Size(136, 51);
            this.SignUp_Button.TabIndex = 15;
            this.SignUp_Button.Text = "Sign Up";
            this.SignUp_Button.UseTransparentBackground = true;
            this.SignUp_Button.Click += new System.EventHandler(this.SignUp_Button_Click);
            // 
            // gmail_TextBox
            // 
            this.gmail_TextBox.AutoRoundedCorners = true;
            this.gmail_TextBox.BorderRadius = 24;
            this.gmail_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gmail_TextBox.DefaultText = "";
            this.gmail_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.gmail_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.gmail_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gmail_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.gmail_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gmail_TextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gmail_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gmail_TextBox.Location = new System.Drawing.Point(26, 107);
            this.gmail_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gmail_TextBox.Name = "gmail_TextBox";
            this.gmail_TextBox.PasswordChar = '\0';
            this.gmail_TextBox.PlaceholderText = "gmail";
            this.gmail_TextBox.SelectedText = "";
            this.gmail_TextBox.Size = new System.Drawing.Size(364, 51);
            this.gmail_TextBox.TabIndex = 19;
            // 
            // password_TextBox
            // 
            this.password_TextBox.AutoRoundedCorners = true;
            this.password_TextBox.BorderRadius = 24;
            this.password_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password_TextBox.DefaultText = "";
            this.password_TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password_TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password_TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password_TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password_TextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.password_TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password_TextBox.Location = new System.Drawing.Point(26, 194);
            this.password_TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password_TextBox.Name = "password_TextBox";
            this.password_TextBox.PasswordChar = '\0';
            this.password_TextBox.PlaceholderText = "Password";
            this.password_TextBox.SelectedText = "";
            this.password_TextBox.Size = new System.Drawing.Size(364, 51);
            this.password_TextBox.TabIndex = 20;
            // 
            // signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1116, 576);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.StateCommon.Back.Color2 = System.Drawing.Color.Black;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 20;
            this.Text = "Sign In";
            this.Load += new System.EventHandler(this.signin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_selecter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox user_selecter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private Guna.UI2.WinForms.Guna2Button SignUp_Button;
        private Guna.UI2.WinForms.Guna2Button SignIn_Button;
        private Guna.UI2.WinForms.Guna2TextBox password_TextBox;
        private Guna.UI2.WinForms.Guna2TextBox gmail_TextBox;
    }
}

