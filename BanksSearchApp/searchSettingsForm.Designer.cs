namespace BanksSearchApp
{
    partial class SearchSettingsForm
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
            this.sellComboBox = new System.Windows.Forms.ComboBox();
            this.showAllBanksCheckBox = new System.Windows.Forms.CheckBox();
            this.profitComboBox = new System.Windows.Forms.ComboBox();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Я хочу";
            // 
            // sellComboBox
            // 
            this.sellComboBox.FormattingEnabled = true;
            this.sellComboBox.Items.AddRange(new object[] {
            "Купить",
            "Продать"});
            this.sellComboBox.Location = new System.Drawing.Point(159, 53);
            this.sellComboBox.Name = "sellComboBox";
            this.sellComboBox.Size = new System.Drawing.Size(82, 21);
            this.sellComboBox.TabIndex = 2;
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
            this.showAllBanksCheckBox.CheckedChanged += new System.EventHandler(this.showAllBanksCheckBox_CheckedChanged);
            // 
            // profitComboBox
            // 
            this.profitComboBox.Enabled = false;
            this.profitComboBox.FormattingEnabled = true;
            this.profitComboBox.Items.AddRange(new object[] {
            "Выгодно",
            "Не выгодно"});
            this.profitComboBox.Location = new System.Drawing.Point(55, 53);
            this.profitComboBox.Name = "profitComboBox";
            this.profitComboBox.Size = new System.Drawing.Size(98, 21);
            this.profitComboBox.TabIndex = 5;
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Location = new System.Drawing.Point(247, 53);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(128, 21);
            this.currencyComboBox.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(219, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(300, 80);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Если ничего не будет найдено увеличьте радиус поиска";
            // 
            // SearchSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 115);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.profitComboBox);
            this.Controls.Add(this.showAllBanksCheckBox);
            this.Controls.Add(this.sellComboBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchSettingsForm";
            this.Text = "Критерии поиска";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sellComboBox;
        private System.Windows.Forms.CheckBox showAllBanksCheckBox;
        private System.Windows.Forms.ComboBox profitComboBox;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
    }
}