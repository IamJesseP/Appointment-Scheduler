using C969Jesse.Database;
using C969Jesse.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Components
{
    public partial class AddCustomerForm : Form
    {
        DbManager dbManager = new DbManager();
        public MainForm MainFormInstance { get; set; }

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsValid())
            {
                MessageBox.Show("Please fill out all form fields correctly");
                return;
            }
            var customerData = new Dictionary<string, string>
            {
                { "CustomerName", txtAddCustomerName.Text },
                { "CustomerAddress", txtAddCustomerAddress.Text },
                { "CustomerCity", txtAddCustomerCity.Text },
                { "CustomerCountry", txtCustomerAddCountry.Text },
                { "CustomerPhone", txtAddCustomerPhone.Text },
                { "CustomerPostal", txtPostal.Text },
            };
            dbManager.SaveData(customerData, false);
            MainFormInstance?.RefreshTable("Customers");
            MainFormInstance?.RefreshTableSettings();
            this.Hide();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AreAllFieldsValid()
        {
            return Validation.ValidateTextBox(txtAddCustomerName, "string", errorProvider)
                && Validation.ValidateTextBox(txtAddCustomerAddress, "string", errorProvider)
                && Validation.ValidateTextBox(txtAddCustomerCity, "string", errorProvider)
                && Validation.ValidateTextBox(txtCustomerAddCountry, "string", errorProvider)
                && Validation.ValidateTextBox(txtAddCustomerPhone, "phone", errorProvider)
                && Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }

        #region TextChanged Validation
        private void txtAddCustomerName_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerName, "string", errorProvider);
        }

        private void txtAddCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerAddress, "string", errorProvider);
        }

        private void txtAddCustomerCity_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerCity, "string", errorProvider);
        }

        private void txtCustomerAddCountry_TextChanged(object sender, EventArgs e)
        {
             SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerAddCountry, "string", errorProvider);
        }

        private void txtAddCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerPhone, "string", errorProvider);
        }
        private void txtPostal_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }
        #endregion

    }


}
