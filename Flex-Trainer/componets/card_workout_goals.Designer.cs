namespace Flex_Trainer
{
    partial class card_workout_goals
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
            this.name_goal = new System.Windows.Forms.Label();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.goal_goal = new System.Windows.Forms.Label();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.desciption = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CircleProgressBar1.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // name_goal
            // 
            this.name_goal.AutoSize = true;
            this.name_goal.BackColor = System.Drawing.Color.Transparent;
            this.name_goal.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.name_goal.ForeColor = System.Drawing.Color.White;
            this.name_goal.Location = new System.Drawing.Point(35, 29);
            this.name_goal.Name = "name_goal";
            this.name_goal.Size = new System.Drawing.Size(144, 37);
            this.name_goal.TabIndex = 5;
            this.name_goal.Text = "Pull Ups";
            this.name_goal.Click += new System.EventHandler(this.label4_Click);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.Controls.Add(this.goal_goal);
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.SkyBlue;
            this.guna2CircleProgressBar1.FillThickness = 10;
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(473, 15);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.SteelBlue;
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.SteelBlue;
            this.guna2CircleProgressBar1.ProgressOffset = -4;
            this.guna2CircleProgressBar1.ProgressThickness = 10;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(82, 82);
            this.guna2CircleProgressBar1.TabIndex = 5;
            this.guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.Value = 78;
            this.guna2CircleProgressBar1.ValueChanged += new System.EventHandler(this.guna2CircleProgressBar1_ValueChanged);
            // 
            // goal_goal
            // 
            this.goal_goal.AutoSize = true;
            this.goal_goal.BackColor = System.Drawing.Color.Transparent;
            this.goal_goal.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.goal_goal.ForeColor = System.Drawing.Color.White;
            this.goal_goal.Location = new System.Drawing.Point(14, 24);
            this.goal_goal.Name = "goal_goal";
            this.goal_goal.Size = new System.Drawing.Size(53, 37);
            this.goal_goal.TabIndex = 8;
            this.goal_goal.Text = "16";
            this.goal_goal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goal_goal.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel3.BorderRadius = 20;
            this.guna2GradientPanel3.BorderThickness = 4;
            this.guna2GradientPanel3.Controls.Add(this.desciption);
            this.guna2GradientPanel3.Controls.Add(this.name_goal);
            this.guna2GradientPanel3.Controls.Add(this.guna2CircleProgressBar1);
            this.guna2GradientPanel3.Controls.Add(this.guna2Button1);
            this.guna2GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel3.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(571, 111);
            this.guna2GradientPanel3.TabIndex = 11;
            this.guna2GradientPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel3_Paint);
            // 
            // desciption
            // 
            this.desciption.AutoSize = true;
            this.desciption.BackColor = System.Drawing.Color.Transparent;
            this.desciption.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.desciption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.desciption.Location = new System.Drawing.Point(38, 66);
            this.desciption.Name = "desciption";
            this.desciption.Size = new System.Drawing.Size(198, 19);
            this.desciption.TabIndex = 7;
            this.desciption.Text = "umerghaforr@gmail.com";
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
            this.guna2Button1.Size = new System.Drawing.Size(571, 111);
            this.guna2Button1.TabIndex = 15;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // card_workout_goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel3);
            this.Name = "card_workout_goals";
            this.Size = new System.Drawing.Size(571, 111);
            this.guna2CircleProgressBar1.ResumeLayout(false);
            this.guna2CircleProgressBar1.PerformLayout();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label name_goal;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private System.Windows.Forms.Label desciption;
        private System.Windows.Forms.Label goal_goal;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
