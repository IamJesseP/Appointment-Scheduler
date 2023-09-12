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
            if (!(Validation.ValidateTextBox(txtAddCustomerName, "string") 
                && Validation.ValidateTextBox(txtAddCustomerAddress, "string")
                && Validation.ValidateTextBox(txtAddCustomerCity, "string")
                && Validation.ValidateTextBox(txtCustomerAddCountry, "string")
                && Validation.ValidateTextBox(txtAddCustomerPhone, "int")))
            {
                SaveBttn.Enabled = false;
                MessageBox.Show("Please fill out all form fields");
            }
            else
            {
                this.Hide();

            }
            // MainForm mainForm = new MainForm();
            // mainForm.Show();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region TextChanged Validation
        private void txtAddCustomerName_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerName, "string");
        }

        private void txtAddCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerAddress, "string");
        }

        private void txtAddCustomerCity_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerCity, "string");
        }

        private void txtCustomerAddCountry_TextChanged(object sender, EventArgs e)
        {
             SaveBttn.Enabled = Validation.ValidateTextBox(txtCustomerAddCountry, "string");
        }

        private void txtAddCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            SaveBttn.Enabled = Validation.ValidateTextBox(txtAddCustomerPhone, "int");
        }
        #endregion
    }


}
