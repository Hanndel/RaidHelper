
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
            this.button1 = new System.Windows.Forms.Button();
            this.HeroesList = new System.Windows.Forms.ListView();
            this.ArtifactList = new System.Windows.Forms.ListView();
            this.Artifacts = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Artifacts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Heroes
            // 
            this.HeroesList.Location = new System.Drawing.Point(12, 12);
            this.HeroesList.Name = "Heroes";
            this.HeroesList.Size = new System.Drawing.Size(909, 458);
            this.HeroesList.TabIndex = 1;
            this.HeroesList.UseCompatibleStateImageBehavior = false;
            this.HeroesList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Artifacts
            // 
            this.ArtifactList.Location = new System.Drawing.Point(12, 12);
            this.ArtifactList.Name = "Artifacts";
            this.ArtifactList.Size = new System.Drawing.Size(909, 458);
            this.ArtifactList.TabIndex = 1;
            this.ArtifactList.UseCompatibleStateImageBehavior = false;
            this.ArtifactList.Visible = false;
            this.ArtifactList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Artifacts
            // 
            this.Artifacts.Location = new System.Drawing.Point(20, 20);
            this.Artifacts.Name = "Artifacts";
            this.Artifacts.Size = new System.Drawing.Size(100, 23);
            this.Artifacts.TabIndex = 2;
            this.Artifacts.Text = "Artifacts";
            this.Artifacts.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.Artifacts);
            this.Controls.Add(this.HeroesList);
            this.Controls.Add(this.ArtifactList);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainGui";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainGui_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView HeroesList;
        private System.Windows.Forms.ListView ArtifactList;
        private System.Windows.Forms.TextBox Artifacts;
    }
}