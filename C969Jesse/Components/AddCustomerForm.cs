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
            // Save fields to DB
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
                && Validation.ValidateTextBox(txtAddCustomerPhone, "phone", errorProvider);
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
        #endregion
    }


}
