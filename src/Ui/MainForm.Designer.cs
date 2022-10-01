namespace CockpitLights
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BridgesView = new System.Windows.Forms.ListBox();
            this.LightsView = new System.Windows.Forms.ListBox();
            this.SimVarView = new System.Windows.Forms.TextBox();
            this.FactorView = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.ColorView = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.ProfileView = new System.Windows.Forms.ComboBox();
            this.AddProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BridgesView
            // 
            this.BridgesView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BridgesView.FormattingEnabled = true;
            this.BridgesView.ItemHeight = 15;
            this.BridgesView.Items.AddRange(new object[] {
            "Searching..."});
            this.BridgesView.Location = new System.Drawing.Point(0, 0);
            this.BridgesView.Name = "BridgesView";
            this.BridgesView.Size = new System.Drawing.Size(120, 244);
            this.BridgesView.TabIndex = 0;
            this.BridgesView.SelectedIndexChanged += new System.EventHandler(this.BridgesView_SelectedIndexChanged);
            // 
            // LightsView
            // 
            this.LightsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LightsView.FormattingEnabled = true;
            this.LightsView.ItemHeight = 15;
            this.LightsView.Location = new System.Drawing.Point(126, 0);
            this.LightsView.Name = "LightsView";
            this.LightsView.Size = new System.Drawing.Size(120, 244);
            this.LightsView.TabIndex = 1;
            this.LightsView.SelectedIndexChanged += new System.EventHandler(this.LightsView_SelectedIndexChanged);
            // 
            // SimVarView
            // 
            this.SimVarView.Location = new System.Drawing.Point(254, 47);
            this.SimVarView.Name = "SimVarView";
            this.SimVarView.Size = new System.Drawing.Size(196, 23);
            this.SimVarView.TabIndex = 2;
            // 
            // FactorView
            // 
            this.FactorView.Location = new System.Drawing.Point(411, 74);
            this.FactorView.Name = "FactorView";
            this.FactorView.Size = new System.Drawing.Size(39, 23);
            this.FactorView.TabIndex = 3;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(145, 12);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 4;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Visible = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(375, 99);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ColorView
            // 
            this.ColorView.BackColor = System.Drawing.Color.White;
            this.ColorView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorView.Location = new System.Drawing.Point(368, 73);
            this.ColorView.Name = "ColorView";
            this.ColorView.Size = new System.Drawing.Size(37, 23);
            this.ColorView.TabIndex = 6;
            this.ColorView.Click += new System.EventHandler(this.ColorView_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(375, 128);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 7;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ProfileView
            // 
            this.ProfileView.FormattingEnabled = true;
            this.ProfileView.Location = new System.Drawing.Point(254, 12);
            this.ProfileView.Name = "ProfileView";
            this.ProfileView.Size = new System.Drawing.Size(121, 23);
            this.ProfileView.TabIndex = 8;
            // 
            // AddProfileButton
            // 
            this.AddProfileButton.Location = new System.Drawing.Point(381, 12);
            this.AddProfileButton.Name = "AddProfileButton";
            this.AddProfileButton.Size = new System.Drawing.Size(49, 23);
            this.AddProfileButton.TabIndex = 9;
            this.AddProfileButton.Text = "Add";
            this.AddProfileButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 244);
            this.Controls.Add(this.AddProfileButton);
            this.Controls.Add(this.ProfileView);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.ColorView);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.FactorView);
            this.Controls.Add(this.SimVarView);
            this.Controls.Add(this.LightsView);
            this.Controls.Add(this.BridgesView);
            this.Name = "MainForm";
            this.Text = "Cockpit Lights";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListBox BridgesView;
        private ListBox LightsView;
        private TextBox SimVarView;
        private TextBox FactorView;
        private Button RegisterButton;
        private Button SaveButton;
        private ColorDialog ColorPicker;
        private Label ColorView;
        private Button TestButton;
        private ComboBox ProfileView;
        private Button AddProfileButton;
    }
}