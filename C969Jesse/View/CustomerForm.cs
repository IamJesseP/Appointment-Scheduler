using C969Jesse.Database;
using C969Jesse.Model;
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
    public partial class CustomerForm : Form
    {
        public Appointment MainFormInstance { get; set; }

        private DbManager dbManager = new DbManager();

        private string addressId;
        private string customerId;
        private string cityId;
        private string countryId;

        public CustomerForm()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void SaveBttn_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsValid())
            {
                MessageBox.Show("Please fill out all form fields correctly");
                return;
            }
            var customerData = new Dictionary<string, string>
            {
                { "CustomerName", txtCustomerName.Text },
                { "CustomerAddress", txtCustomerAddress.Text },
                { "CustomerCity", txtCustomerCity.Text },
                { "CustomerCountry", txtCustomerCountry.Text },
                { "CustomerPhone", txtCustomerPhone.Text },
                { "CustomerPostal", txtPostal.Text },
                { "AddressId", addressId },
                { "CustomerId", customerId },
                { "CityId", cityId },
                { "CountryId", countryId }
            };
      
            if (MainFormInstance.isUpdate)
            {
                dbManager.SaveCustomer(customerData, MainFormInstance.isUpdate);
            }
            else
            {
                dbManager.SaveCustomer(customerData, MainFormInstance.isUpdate);
            }
            MainFormInstance?.RefreshTable("Customers");
            MainFormInstance?.RefreshTableSettings();
            MainFormInstance?.GiveUserFeedBack(MainFormInstance.isUpdate);
            this.Hide();
        }
        private void CancelBttn_Click(object sender, EventArgs e)
        {
            MainFormInstance?.RefreshTableSettings();
            this.Close();
        }
        #endregion

        #region Helper Methods
        public void UpdateCustomerFormTitle(bool isUpdate)
        {
            customerTitle.Text = isUpdate ? "Update Customer" : "Add Customer";
        }
        public void PopulateFields(DataGridViewRow row)
        {
            txtCustomerName.Text = row.Cells[1].Value.ToString();
            txtCustomerAddress.Text = row.Cells[2].Value.ToString();
            txtCustomerCity.Text = row.Cells[6].Value.ToString();
            txtCustomerCountry.Text = row.Cells[8].Value.ToString();
            txtCustomerPhone.Text = row.Cells[5].Value.ToString();
            txtPostal.Text = row.Cells[4].Value.ToString();

            //Set IDs
            addressId = row.Cells[3].Value.ToString();
            customerId = row.Cells[0].Value.ToString();
            cityId = row.Cells[7].Value.ToString();
            countryId = row.Cells[9].Value.ToString();
        }
        private bool AreAllFieldsValid()
        {
            return Validation.ValidateTextBox(txtCustomerName, "string", errorProvider)
                && Validation.ValidateTextBox(txtCustomerAddress, "string", errorProvider)
                && Validation.ValidateTextBox(txtCustomerCity, "string", errorProvider)
                && Validation.ValidateTextBox(txtCustomerCountry, "string", errorProvider)
                && Validation.ValidateTextBox(txtCustomerPhone, "phone", errorProvider)
                && Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }
        #endregion

        #region TextChanged Validation
        private void txtAddCustomerName_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerName, "string", errorProvider);
        }

        private void txtAddCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerAddress, "string", errorProvider);
        }

        private void txtAddCustomerCity_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerCity, "string", errorProvider);
        }

        private void txtCustomerAddCountry_TextChanged(object sender, EventArgs e)
        {
             SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerCountry, "string", errorProvider);
        }

        private void txtAddCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerPhone, "string", errorProvider);
        }
        private void txtPostal_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtPostal, "string", errorProvider);
        }
        #endregion
    }


}
