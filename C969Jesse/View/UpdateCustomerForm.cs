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
    public partial class UpdateCustomerForm : Form
    {
        DbManager dbManager = new DbManager();
        public MainForm MainFormInstance { get; set; }

        private bool isUpdate = true;

        private string addressId;
        private string customerId;
        private string cityId;
        private string countryId;


        public UpdateCustomerForm()
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
                { "CustomerName", txtUpdateCustomerName.Text },
                { "CustomerAddress", txtUpdateCustomerAddress.Text },
                { "CustomerCity", txtUpdateCustomerCity.Text },
                { "CustomerCountry", txtUpdateCustomerCountry.Text },
                { "CustomerPhone", txtUpdateCustomerPhone.Text },
                { "CustomerPostal", txtPostal.Text },
                { "AddressId", addressId },
                { "CustomerId", customerId },
                { "CityId" , cityId },
                { "CountryId" , countryId },

            };
            dbManager.SaveCustomer(customerData, isUpdate);
            MainFormInstance?.RefreshTable("Customers");
            MainFormInstance?.RefreshTableSettings();
            MainFormInstance?.GiveUserFeedBack(isUpdate);
            this.Hide();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            MainFormInstance?.RefreshTableSettings();
            this.Close();
        }

        private bool AreAllFieldsValid()
        {
            return Validation.ValidateTextBox(txtUpdateCustomerName, "string", errorProvider)
                && Validation.ValidateTextBox(txtUpdateCustomerAddress, "string", errorProvider)
                && Validation.ValidateTextBox(txtUpdateCustomerCity, "string", errorProvider)
                && Validation.ValidateTextBox(txtUpdateCustomerCountry, "string", errorProvider)
                && Validation.ValidateTextBox(txtUpdateCustomerPhone, "phone", errorProvider)
                && Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }
        public void PopulateFields(DataGridViewRow row)
        {
            txtUpdateCustomerName.Text = row.Cells[1].Value.ToString();
            txtUpdateCustomerAddress.Text = row.Cells[2].Value.ToString();
            txtUpdateCustomerCity.Text = row.Cells[6].Value.ToString();
            txtUpdateCustomerCountry.Text = row.Cells[8].Value.ToString();
            txtUpdateCustomerPhone.Text = row.Cells[5].Value.ToString();
            
            //Set IDs
            txtPostal.Text = row.Cells[4].Value.ToString();
            addressId = row.Cells[3].Value.ToString();
            customerId = row.Cells[0].Value.ToString();
            cityId = row.Cells[7].Value.ToString();
            countryId = row.Cells[9].Value.ToString();
        }


        #region TextChanged Validation
        private void txtUpdateCustomerName_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtUpdateCustomerName, "string", errorProvider);
        }

        private void txtUpdateCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtUpdateCustomerAddress, "string", errorProvider);
        }

        private void txtUpdateCustomerCity_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtUpdateCustomerCity, "string", errorProvider);
        }

        private void txtUpdateCustomerCountry_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtUpdateCustomerCountry, "string", errorProvider);
        }

        private void txtUpdateCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtUpdateCustomerPhone, "string", errorProvider);
        }
        private void txtPostal_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }
        #endregion

    }
}
