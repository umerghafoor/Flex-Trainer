namespace Flex_Trainer
{
    partial class page_gym_owner
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.allgymsComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Submit_Button = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.logout_Button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.gym_requests1 = new Flex_Trainer.gym_requests();
            this.gym_trainer1 = new Flex_Trainer.gym_trainer();
            this.gym_member1 = new Flex_Trainer.gym_member();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.allgymsComboBox1);
            this.guna2Panel1.Controls.Add(this.Submit_Button);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Controls.Add(this.logout_Button);
            this.guna2Panel1.Controls.Add(this.guna2Button3);
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(222, 890);
            this.guna2Panel1.TabIndex = 2;
            // 
            // allgymsComboBox1
            // 
            this.allgymsComboBox1.AutoRoundedCorners = true;
            this.allgymsComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.allgymsComboBox1.BorderRadius = 17;
            this.allgymsComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allgymsComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allgymsComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.allgymsComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.allgymsComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.allgymsComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.allgymsComboBox1.ItemHeight = 30;
            this.allgymsComboBox1.Location = new System.Drawing.Point(31, 72);
            this.allgymsComboBox1.Name = "allgymsComboBox1";
            this.allgymsComboBox1.Size = new System.Drawing.Size(140, 36);
            this.allgymsComboBox1.TabIndex = 19;
            this.allgymsComboBox1.SelectedIndexChanged += new System.EventHandler(this.allgymsComboBox1_SelectedIndexChanged);
            // 
            // Submit_Button
            // 
            this.Submit_Button.AutoRoundedCorners = true;
            this.Submit_Button.BackColor = System.Drawing.Color.Transparent;
            this.Submit_Button.BorderRadius = 24;
            this.Submit_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.Submit_Button.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Submit_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Submit_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Submit_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Submit_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Submit_Button.FillColor = System.Drawing.Color.White;
            this.Submit_Button.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Submit_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Submit_Button.Location = new System.Drawing.Point(31, 148);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(136, 51);
            this.Submit_Button.TabIndex = 18;
            this.Submit_Button.Text = "Add gym";
            this.Submit_Button.UseTransparentBackground = true;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 28);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.label10.Size = new System.Drawing.Size(155, 41);
            this.label10.TabIndex = 17;
            this.label10.Text = "Select Gym";
            // 
            // logout_Button
            // 
            this.logout_Button.BackColor = System.Drawing.Color.Transparent;
            this.logout_Button.BorderRadius = 12;
            this.logout_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.logout_Button.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.logout_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logout_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logout_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logout_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logout_Button.FillColor = System.Drawing.Color.White;
            this.logout_Button.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.logout_Button.Location = new System.Drawing.Point(45, 827);
            this.logout_Button.Name = "logout_Button";
            this.logout_Button.Size = new System.Drawing.Size(136, 51);
            this.logout_Button.TabIndex = 16;
            this.logout_Button.Text = "Logout";
            this.logout_Button.UseTransparentBackground = true;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button3.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(21, 445);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(180, 63);
            this.guna2Button3.TabIndex = 2;
            this.guna2Button3.Text = "Account Requests";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(21, 380);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(180, 59);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "Trainer Reports";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.Checked = true;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(21, 316);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 58);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Member Reports";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // gym_requests1
            // 
            this.gym_requests1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gym_requests1.Location = new System.Drawing.Point(222, 0);
            this.gym_requests1.Name = "gym_requests1";
            this.gym_requests1.Size = new System.Drawing.Size(1267, 890);
            this.gym_requests1.TabIndex = 5;
            // 
            // gym_trainer1
            // 
            this.gym_trainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gym_trainer1.Location = new System.Drawing.Point(222, 0);
            this.gym_trainer1.Name = "gym_trainer1";
            this.gym_trainer1.Size = new System.Drawing.Size(1267, 890);
            this.gym_trainer1.TabIndex = 4;
            // 
            // gym_member1
            // 
            this.gym_member1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gym_member1.Location = new System.Drawing.Point(222, 0);
            this.gym_member1.Name = "gym_member1";
            this.gym_member1.Size = new System.Drawing.Size(1267, 890);
            this.gym_member1.TabIndex = 3;
            // 
            // page_gym_owner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 890);
            this.Controls.Add(this.gym_requests1);
            this.Controls.Add(this.gym_trainer1);
            this.Controls.Add(this.gym_member1);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "page_gym_owner";
            this.Text = "Owner";
            this.Load += new System.EventHandler(this.page_gym_owner_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private gym_member gym_member1;
        private gym_trainer gym_trainer1;
        private gym_requests gym_requests1;
        private Guna.UI2.WinForms.Guna2Button logout_Button;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox allgymsComboBox1;
        private Guna.UI2.WinForms.Guna2Button Submit_Button;
    }
}