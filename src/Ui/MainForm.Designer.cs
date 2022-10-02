﻿namespace CockpitLights
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
            this.ProfileNameView = new System.Windows.Forms.TextBox();
            this.RemoveProfileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.SimVarView.Location = new System.Drawing.Point(5, 34);
            this.SimVarView.Name = "SimVarView";
            this.SimVarView.Size = new System.Drawing.Size(194, 23);
            this.SimVarView.TabIndex = 2;
            // 
            // FactorView
            // 
            this.FactorView.Location = new System.Drawing.Point(160, 63);
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
            this.SaveButton.Location = new System.Drawing.Point(124, 88);
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
            this.ColorView.Location = new System.Drawing.Point(48, 63);
            this.ColorView.Name = "ColorView";
            this.ColorView.Size = new System.Drawing.Size(37, 23);
            this.ColorView.TabIndex = 6;
            this.ColorView.Click += new System.EventHandler(this.ColorView_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(124, 117);
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
            this.ProfileView.Location = new System.Drawing.Point(6, 19);
            this.ProfileView.Name = "ProfileView";
            this.ProfileView.Size = new System.Drawing.Size(142, 23);
            this.ProfileView.TabIndex = 8;
            this.ProfileView.SelectedIndexChanged += new System.EventHandler(this.ProfileView_SelectedIndexChanged);
            // 
            // AddProfileButton
            // 
            this.AddProfileButton.Location = new System.Drawing.Point(154, 18);
            this.AddProfileButton.Name = "AddProfileButton";
            this.AddProfileButton.Size = new System.Drawing.Size(24, 24);
            this.AddProfileButton.TabIndex = 9;
            this.AddProfileButton.Text = "+";
            this.AddProfileButton.UseVisualStyleBackColor = true;
            this.AddProfileButton.Click += new System.EventHandler(this.AddProfileButton_Click);
            // 
            // ProfileNameView
            // 
            this.ProfileNameView.Location = new System.Drawing.Point(260, 42);
            this.ProfileNameView.Name = "ProfileNameView";
            this.ProfileNameView.Size = new System.Drawing.Size(142, 23);
            this.ProfileNameView.TabIndex = 10;
            this.ProfileNameView.Visible = false;
            this.ProfileNameView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProfileNameView_KeyDown);
            // 
            // RemoveProfileButton
            // 
            this.RemoveProfileButton.Location = new System.Drawing.Point(177, 18);
            this.RemoveProfileButton.Name = "RemoveProfileButton";
            this.RemoveProfileButton.Size = new System.Drawing.Size(24, 24);
            this.RemoveProfileButton.TabIndex = 11;
            this.RemoveProfileButton.Text = "-";
            this.RemoveProfileButton.UseVisualStyleBackColor = true;
            this.RemoveProfileButton.Click += new System.EventHandler(this.RemoveProfileButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProfileView);
            this.groupBox1.Controls.Add(this.RemoveProfileButton);
            this.groupBox1.Controls.Add(this.AddProfileButton);
            this.groupBox1.Location = new System.Drawing.Point(254, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 52);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SimVarView);
            this.groupBox2.Controls.Add(this.FactorView);
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Controls.Add(this.TestButton);
            this.groupBox2.Controls.Add(this.ColorView);
            this.groupBox2.Location = new System.Drawing.Point(255, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 148);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "SimConnect Variable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Factor";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 244);
            this.Controls.Add(this.ProfileNameView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LightsView);
            this.Controls.Add(this.BridgesView);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "Cockpit Lights";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private TextBox ProfileNameView;
        private Button RemoveProfileButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}