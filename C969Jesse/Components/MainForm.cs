using C969Jesse.Components;
using C969Jesse.Database;
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
        private DbManager tableData = new DbManager();

        private DataGridViewRow selectedRow = null;

        private string bttnState = "Customers";

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(mainDataGridView);

            // Default to customerData
            RefreshTable(bttnState);
            UpdateButtons(bttnState);
            SetupCustomerDGV();

            //edit props
            mainDataGridView.ReadOnly = true;
            mainDataGridView.MultiSelect = false;
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        #region Helper methods
        public void RefreshTable(string table)
        {
            if (table == "Appointments")
            {
                mainDataGridView.DataSource = tableData.GetData(Queries.GetAppointmentsQuery);

                mainDataGridView.Columns["appointmentId"].Visible = false;
            }
            else if (table == "Customers")
            {
                mainDataGridView.DataSource = tableData.GetData(Queries.GetCustomersQuery);
            }

            mainDataGridView.Columns["customerId"].Visible = false;
            mainDataGridView.Columns["addressId"].Visible = false;
            mainDataGridView.Columns["cityId"].Visible = false;
            mainDataGridView.Columns["countryId"].Visible = false;
        }

        private void UpdateButtons(string state)
        {
            if (state == "Customers")
            {
                AddBttn.Show();
                UpdateBttn.Show();
                DeleteBttn.Show();
                ViewBttn.Hide();
                AddBttn.Text = "Add Customer";
                UpdateBttn.Text = "Update Customer";
                DeleteBttn.Text = "Delete Customer";
            }
            else if (state == "Appointments")
            {
                AddBttn.Show();
                UpdateBttn.Show();
                DeleteBttn.Show();
                ViewBttn.Hide();
                AddBttn.Text = "Add \nAppointment";
                UpdateBttn.Text = "Update Appointment";
                DeleteBttn.Text = "Delete Appointment";
            }
            else
            {
                AddBttn.Hide();
                UpdateBttn.Hide();
                DeleteBttn.Hide();
                ViewBttn.Show();
            }
            bttnState = state;
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
            RefreshTableSettings();
        }

        private void SetupAppointmentDGV()
        {

            // Setting column titles
            mainDataGridView.Columns["appointmentId"].HeaderText = "Appointment ID";
            mainDataGridView.Columns["customerName"].HeaderText = "Customer Name";
            mainDataGridView.Columns["title"].HeaderText = "Title";
            mainDataGridView.Columns["description"].HeaderText = "Description";
            mainDataGridView.Columns["start"].HeaderText = "Start";
            mainDataGridView.Columns["end"].HeaderText = "End";
            mainDataGridView.Columns["type"].HeaderText = "Visit Type";
            mainDataGridView.Columns["customerPhone"].HeaderText = "Phone";

            RefreshTableSettings();
        }

        public void RefreshTableSettings()
        {
            // Tab color
            if (bttnState == "Customers")
            {
                CustomerTab.ForeColor = Color.Goldenrod;
                AppointmentsTab.ForeColor = Color.Black;
            }
            else
            {
                CustomerTab.ForeColor = Color.Black;
                AppointmentsTab.ForeColor = Color.Goldenrod;

            }
            // Resizing columns to fit the current view
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.AutoResizeColumns();
            mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainDataGridView.ClearSelection();
        }
        #endregion

        #region Event Handlers
        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;
            if (indexSelected < 0) { return; }//Error handler for clicking header row
            selectedRow = mainDataGridView.Rows[indexSelected];
        }
        private void ClickCustomersTab(object sender, EventArgs e)
        {
            UpdateButtons("Customers");
            RefreshTable(bttnState);
            SetupCustomerDGV();
        }
        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            UpdateButtons("Appointments");
            RefreshTable(bttnState);
            SetupAppointmentDGV();
        }
        private void AddBttn_Click(object sender, EventArgs e)
        {
            if (bttnState == "Customers")
            {
                var addCustomerForm = new AddCustomerForm();
                addCustomerForm.MainFormInstance = this; // Dependency injection!
                addCustomerForm.Show();
            }
            else if (bttnState == "Appointments")
            {
                // var addAppointmentForm = new AddAppointmentForm();
                // addAppointmentForm.ShowDialog();
            }
        }
        private void UpdateBttn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm();
                updateCustomerForm.PopulateFields(selectedRow);
                updateCustomerForm.MainFormInstance = this;
                updateCustomerForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
            selectedRow = null;
        }
        #endregion

    }
}
