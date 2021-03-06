﻿namespace BanksSearchApp
{
    partial class MainForm
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
            this.searchSettingsButton = new System.Windows.Forms.Button();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.searchRadiusTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.searchRadiusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.searchRadiusTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // searchSettingsButton
            // 
            this.searchSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchSettingsButton.Location = new System.Drawing.Point(12, 12);
            this.searchSettingsButton.Name = "searchSettingsButton";
            this.searchSettingsButton.Size = new System.Drawing.Size(211, 53);
            this.searchSettingsButton.TabIndex = 0;
            this.searchSettingsButton.Text = "Критерии поиска";
            this.searchSettingsButton.UseVisualStyleBackColor = true;
            this.searchSettingsButton.Click += new System.EventHandler(this.searchSettingsButton_Click);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(1122, 632);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(35, 13);
            this.scaleLabel.TabIndex = 1;
            this.scaleLabel.Text = "label1";
            // 
            // searchRadiusTrackBar
            // 
            this.searchRadiusTrackBar.Location = new System.Drawing.Point(452, 632);
            this.searchRadiusTrackBar.Maximum = 10000;
            this.searchRadiusTrackBar.Minimum = 100;
            this.searchRadiusTrackBar.Name = "searchRadiusTrackBar";
            this.searchRadiusTrackBar.Size = new System.Drawing.Size(307, 45);
            this.searchRadiusTrackBar.TabIndex = 2;
            this.searchRadiusTrackBar.TickFrequency = 100;
            this.searchRadiusTrackBar.Value = 100;
            this.searchRadiusTrackBar.Scroll += new System.EventHandler(this.searchRadiusTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Радиус поиска";
            // 
            // searchRadiusLabel
            // 
            this.searchRadiusLabel.AutoSize = true;
            this.searchRadiusLabel.Location = new System.Drawing.Point(452, 664);
            this.searchRadiusLabel.Name = "searchRadiusLabel";
            this.searchRadiusLabel.Size = new System.Drawing.Size(35, 13);
            this.searchRadiusLabel.TabIndex = 4;
            this.searchRadiusLabel.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 707);
            this.Controls.Add(this.searchRadiusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchRadiusTrackBar);
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.searchSettingsButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приложение";
            ((System.ComponentModel.ISupportInitialize)(this.searchRadiusTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button searchSettingsButton;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.TrackBar searchRadiusTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label searchRadiusLabel;
    }
}

