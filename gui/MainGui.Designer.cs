
namespace Raid.gui
{
    partial class MainGui
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
            this.ArtifactButton = new System.Windows.Forms.Button();
            this.HeroButton = new System.Windows.Forms.Button();
            this.HeroListView = new System.Windows.Forms.ListView();
            this.ArtifactListView = new System.Windows.Forms.ListView();
            this.RaidInjectionStatus = new System.Windows.Forms.TextBox();
            this.HeroesScan = new System.Windows.Forms.TextBox();
            this.ArtifactsScan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ArtifactButton
            // 
            this.ArtifactButton.Location = new System.Drawing.Point(12, 12);
            this.ArtifactButton.Name = "ArtifactButton";
            this.ArtifactButton.Size = new System.Drawing.Size(175, 36);
            this.ArtifactButton.TabIndex = 0;
            this.ArtifactButton.Text = "Artifacts";
            this.ArtifactButton.UseVisualStyleBackColor = true;
            this.ArtifactButton.Click += new System.EventHandler(this.ArtifactClickButton);
            // 
            // HeroButton
            // 
            this.HeroButton.Location = new System.Drawing.Point(12, 54);
            this.HeroButton.Name = "HeroButton";
            this.HeroButton.Size = new System.Drawing.Size(175, 36);
            this.HeroButton.TabIndex = 0;
            this.HeroButton.Text = "Heroes";
            this.HeroButton.UseVisualStyleBackColor = true;
            this.HeroButton.Click += new System.EventHandler(this.HeroesClickButton);
            // 
            // HeroListView
            // 
            this.HeroListView.Location = new System.Drawing.Point(193, 12);
            this.HeroListView.Name = "HeroListView";
            this.HeroListView.Size = new System.Drawing.Size(728, 495);
            this.HeroListView.TabIndex = 1;
            this.HeroListView.UseCompatibleStateImageBehavior = false;
            // 
            // ArtifactListView
            // 
            this.ArtifactListView.Location = new System.Drawing.Point(193, 12);
            this.ArtifactListView.Name = "ArtifactListView";
            this.ArtifactListView.Size = new System.Drawing.Size(728, 495);
            this.ArtifactListView.TabIndex = 1;
            this.ArtifactListView.UseCompatibleStateImageBehavior = false;
            this.ArtifactListView.Visible = false;
            // 
            // RaidInjectionStatus
            // 
            this.RaidInjectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RaidInjectionStatus.Location = new System.Drawing.Point(12, 426);
            this.RaidInjectionStatus.Name = "RaidInjectionStatus";
            this.RaidInjectionStatus.ReadOnly = true;
            this.RaidInjectionStatus.Size = new System.Drawing.Size(142, 16);
            this.RaidInjectionStatus.TabIndex = 2;
            this.RaidInjectionStatus.Text = "Waiting for Raid process";
            // 
            // HeroesScan
            // 
            this.HeroesScan.BackColor = System.Drawing.SystemColors.Control;
            this.HeroesScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeroesScan.Location = new System.Drawing.Point(12, 455);
            this.HeroesScan.Name = "HeroesScan";
            this.HeroesScan.Size = new System.Drawing.Size(142, 16);
            this.HeroesScan.TabIndex = 3;
            // 
            // ArtifactsScan
            // 
            this.ArtifactsScan.BackColor = System.Drawing.SystemColors.Control;
            this.ArtifactsScan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArtifactsScan.Location = new System.Drawing.Point(12, 484);
            this.ArtifactsScan.Name = "ArtifactsScan";
            this.ArtifactsScan.Size = new System.Drawing.Size(142, 16);
            this.ArtifactsScan.TabIndex = 4;
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.ArtifactsScan);
            this.Controls.Add(this.HeroesScan);
            this.Controls.Add(this.RaidInjectionStatus);
            this.Controls.Add(this.HeroListView);
            this.Controls.Add(this.HeroButton);
            this.Controls.Add(this.ArtifactButton);
            this.Controls.Add(this.ArtifactListView);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainGui";
            this.Text = "C1C Raid Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainGui_FormClosed);
            this.Load += new System.EventHandler(this.MainGui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ArtifactButton;
        private System.Windows.Forms.Button HeroButton;
        private System.Windows.Forms.ListView HeroListView;
        private System.Windows.Forms.ListView ArtifactListView;
        private System.Windows.Forms.TextBox RaidInjectionStatus;
        private System.Windows.Forms.TextBox HeroesScan;
        private System.Windows.Forms.TextBox ArtifactsScan;
    }
}