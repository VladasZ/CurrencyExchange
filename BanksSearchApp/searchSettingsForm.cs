using CurrencyExchange.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanksSearchApp
{
    public partial class SearchSettingsForm : Form
    {
        public SearchSettingsForm()
        {
            StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();

            currencyComboBox.DataSource = DatabaseManager.getCurrenciesName();

            showAllBanksCheckBox.Checked = DatabaseManager.Settings.AllBanks;
            profitComboBox.SelectedIndex = DatabaseManager.Settings.Profitable ? 0 : 1;
            sellComboBox.SelectedIndex = DatabaseManager.Settings.Sell ? 1 : 0;
            currencyComboBox.SelectedIndex = DatabaseManager.Settings.Currency.Id - DatabaseManager.db.Currencies.First().Id;
        }

        private void showAllBanksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllBanksCheckBox.Checked)
            {
                profitComboBox.Enabled = false;

            }
            else
            {
                profitComboBox.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings()
            {
                AllBanks = showAllBanksCheckBox.Checked,
                Profitable = profitComboBox.SelectedIndex == 0 ? true : false,
                Sell = sellComboBox.SelectedIndex == 0 ? false : true,
                Currency = (from cur in DatabaseManager.db.Currencies
                            where cur.Name == currencyComboBox.Text
                            select cur).FirstOrDefault()
            };

            DatabaseManager.Settings = settings;

            DialogResult = DialogResult.OK;
        }
    }
}
