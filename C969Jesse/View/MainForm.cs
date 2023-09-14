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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse
{
    public partial class MainForm : Form
    {
        private DbManager dbManager = new DbManager();

        private DataGridViewRow selectedRow = null;

        private string bttnState = "Customers";

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(mainDataGridView);

            // Default to customerData
            UpdateButtons(bttnState);
            RefreshTable(bttnState);
            SetupCustomerDGV();
            RefreshTableSettings();
        }

        #region Helper methods
        public void RefreshTable(string state)
        {
            if (state == "Appointments")
            {
                mainDataGridView.DataSource = dbManager.GetData(Queries.GetAppointmentsQuery);

                mainDataGridView.Columns["appointmentId"].Visible = false;
                mainDataGridView.Columns["userId"].Visible = false;
            }
            else if (state == "Customers")
            {
                mainDataGridView.DataSource = dbManager.GetData(Queries.GetCustomersQuery);
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

        }

        private void SetupAppointmentDGV()
        {
            // Setting column titles
            mainDataGridView.Columns["userName"].HeaderText = "Consultant";
            mainDataGridView.Columns["customerName"].HeaderText = "Customer Name";
            mainDataGridView.Columns["description"].HeaderText = "Description";
            mainDataGridView.Columns["type"].HeaderText = "Visit Type";
            mainDataGridView.Columns["location"].HeaderText = "Location";
            mainDataGridView.Columns["start"].HeaderText = "Start";
            mainDataGridView.Columns["end"].HeaderText = "End";
            mainDataGridView.Columns["phone"].HeaderText = "Phone";
            mainDataGridView.Columns["url"].HeaderText = "Visit Link";
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
            mainDataGridView.ReadOnly = true;
            mainDataGridView.MultiSelect = false;
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.AutoResizeColumns();
            mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainDataGridView.ClearSelection();
            successProvider.Clear();
            errorProvider.Clear();
            feedbackLabel.Text = string.Empty;
        }

        public void GiveUserFeedBack(bool isUpdate)
        {
            if (!isUpdate)
            {
                errorProvider.Clear();
                successProvider.SetError(feedbackLabel, "!");
                feedbackLabel.Text = "Successfully added.";
            }
            else
            {
                errorProvider.Clear();
                successProvider.SetError(feedbackLabel, "!");
                feedbackLabel.Text = "Successfully updated.";
            }
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
            RefreshTableSettings();
            SetupCustomerDGV();
        }
        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            UpdateButtons("Appointments");
            RefreshTable(bttnState);
            RefreshTableSettings();
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
                var addAppointmentForm = new AddAppointmentForm();
                addAppointmentForm.Show();
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
                successProvider.Clear();
                errorProvider.SetError(feedbackLabel, "!");
                feedbackLabel.Text = "Please select a row first.";
            }
            selectedRow = null;
        }
        private void DeleteBttn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                var selectedRow = mainDataGridView.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                dbManager.DeleteCustomerData(customerId);
                RefreshTable(bttnState);
                RefreshTableSettings();

                errorProvider.Clear();
                successProvider.SetError(feedbackLabel, "!");
                feedbackLabel.Text = "Successfully deleted.";
            }
            else
            {
                successProvider.Clear();
                errorProvider.SetError(feedbackLabel, "!");
                feedbackLabel.Text = "Please select a row first.";
            }
            selectedRow = null;
        }
        private void mainDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainDataGridView.ClearSelection();
        }
        #endregion

    }
}
