using C969Jesse.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(mainDataGridView);

            // Default to customer data
            var customerData = new CustomerDataAccess();

            //edit props
            mainDataGridView.DataSource = customerData.GetData();
            mainDataGridView.ReadOnly = true;
            mainDataGridView.MultiSelect = false;
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            SetupCustomerDGV();
        }


        private void ClickCustomersTab(object sender, EventArgs e)
        {
            var customerData = new CustomerDataAccess();
            mainDataGridView.DataSource = customerData.GetData();
            SetupCustomerDGV();
        }

        private void SetupCustomerDGV()
        {
            // Setting column titles
            mainDataGridView.Columns["customerId"].HeaderText = "Customer ID";
            mainDataGridView.Columns["customerName"].HeaderText = "Customer Name";
            mainDataGridView.Columns["address"].HeaderText = "Address";
            mainDataGridView.Columns["phone"].HeaderText = "Phone";
            mainDataGridView.Columns["city"].HeaderText = "City";   
            mainDataGridView.Columns["country"].HeaderText = "Country";

            // Resizing columns to fit the current view
            mainDataGridView.AutoResizeColumns();
            mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;
            if (indexSelected < 0) { return; }//Error handler for clicking header row
            MessageBox.Show($"Clicked {indexSelected}");

        }
    }
}
