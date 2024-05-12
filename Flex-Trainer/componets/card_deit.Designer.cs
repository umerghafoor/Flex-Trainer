namespace Flex_Trainer
{
    partial class card_deit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.details = new System.Windows.Forms.Label();
            this.dietname = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.diet_quantity = new System.Windows.Forms.Label();
            this.guna2GradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // details
            // 
            this.details.AutoSize = true;
            this.details.BackColor = System.Drawing.Color.Transparent;
            this.details.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.details.ForeColor = System.Drawing.Color.LightGray;
            this.details.Location = new System.Drawing.Point(33, 64);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(259, 19);
            this.details.TabIndex = 9;
            this.details.Text = "bsiofbe ifbewoigf bigwe oig ibgw";
            // 
            // dietname
            // 
            this.dietname.AutoSize = true;
            this.dietname.BackColor = System.Drawing.Color.Transparent;
            this.dietname.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.dietname.ForeColor = System.Drawing.Color.White;
            this.dietname.Location = new System.Drawing.Point(30, 16);
            this.dietname.Name = "dietname";
            this.dietname.Size = new System.Drawing.Size(79, 37);
            this.dietname.TabIndex = 8;
            this.dietname.Text = "Deit";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(0, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(575, 120);
            this.guna2Button1.TabIndex = 16;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel3.BorderRadius = 20;
            this.guna2GradientPanel3.BorderThickness = 4;
            this.guna2GradientPanel3.Controls.Add(this.diet_quantity);
            this.guna2GradientPanel3.Controls.Add(this.dietname);
            this.guna2GradientPanel3.Controls.Add(this.details);
            this.guna2GradientPanel3.Controls.Add(this.guna2Button1);
            this.guna2GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(575, 120);
            this.guna2GradientPanel3.TabIndex = 17;
            // 
            // diet_quantity
            // 
            this.diet_quantity.AutoSize = true;
            this.diet_quantity.BackColor = System.Drawing.Color.Transparent;
            this.diet_quantity.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.diet_quantity.ForeColor = System.Drawing.Color.White;
            this.diet_quantity.Location = new System.Drawing.Point(482, 46);
            this.diet_quantity.Name = "diet_quantity";
            this.diet_quantity.Size = new System.Drawing.Size(53, 37);
            this.diet_quantity.TabIndex = 17;
            this.diet_quantity.Text = "10";
            // 
            // card_deit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2GradientPanel3);
            this.Name = "card_deit";
            this.Size = new System.Drawing.Size(575, 120);
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label details;
        private System.Windows.Forms.Label dietname;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private System.Windows.Forms.Label diet_quantity;
    }
}
