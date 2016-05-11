namespace BanksSearchApp
{
    partial class searchSettingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.showAllBanksCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Я хочу";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Купить",
            "Продать"});
            this.comboBox1.Location = new System.Drawing.Point(128, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // showAllBanksCheckBox
            // 
            this.showAllBanksCheckBox.AutoSize = true;
            this.showAllBanksCheckBox.Checked = true;
            this.showAllBanksCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAllBanksCheckBox.Location = new System.Drawing.Point(12, 12);
            this.showAllBanksCheckBox.Name = "showAllBanksCheckBox";
            this.showAllBanksCheckBox.Size = new System.Drawing.Size(143, 17);
            this.showAllBanksCheckBox.TabIndex = 4;
            this.showAllBanksCheckBox.Text = "Показывать все банки";
            this.showAllBanksCheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Выгодно",
            "Не выгодно"});
            this.comboBox2.Location = new System.Drawing.Point(57, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(65, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(227, 43);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // searchSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 89);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.showAllBanksCheckBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "searchSettingsForm";
            this.Text = "Критерии поиска";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox showAllBanksCheckBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}