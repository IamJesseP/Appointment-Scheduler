using C969Jesse.Components;
using C969Jesse.Controller;
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

        private string formState = "Customers"; // Default to customers

        private string appointmentFilterState = "All";

        public bool isUpdate = false;

        public MainForm()
        {
            InitializeComponent();
            UpdateButtons(formState);
            RefreshTable(formState);
            SetupCustomerDGV();
            RefreshTableSettings();
        }

        #region Event Handlers

        private void AddBttn_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            if (formState == "Customers")
            {
                var addCustomerForm = new CustomerForm();
                addCustomerForm.UpdateCustomerFormTitle(isUpdate);
                addCustomerForm.MainFormInstance = this; // Dependency injection!
                addCustomerForm.Show();
            }
            else if (formState == "Appointments")
            {
                var addAppointmentForm = new AppointmentForm();
                addAppointmentForm.MainFormInstance = this; // Dependency injection!
                addAppointmentForm.Show();
            }
        }
        private void UpdateBttn_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            if (selectedRow != null)
            {
                if (formState == "Customers")
                {
                    var addCustomerForm = new CustomerForm();
                    addCustomerForm.PopulateFields(selectedRow);
                    addCustomerForm.UpdateCustomerFormTitle(isUpdate);
                    addCustomerForm.MainFormInstance = this;
                    addCustomerForm.Show();
                }
                else if (formState == "Appointments")
                {
                    var addAppointmentForm = new AppointmentForm();
                    addAppointmentForm.MainFormInstance = this;
                    addAppointmentForm.PopulateFields(selectedRow);
                    addAppointmentForm.UpdateAppointmentFormTitle(isUpdate);
                    addAppointmentForm.Show();

                }
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
                if (!ConfirmDeletion()) { return; }
                if (formState == "Customers")
                {
                    int customerId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    dbManager.DeleteCustomer(customerId);
                }
                else if (formState == "Appointments")
                {
                    int appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
                    dbManager.DeleteAppointment(appointmentId);
                }

                RefreshTable(formState);
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
        private void ClickCustomersTab(object sender, EventArgs e)
        {
            UpdateButtons("Customers");
            RefreshTable(formState);
            RefreshTableSettings();
            SetupCustomerDGV();
        }
        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            UpdateButtons("Appointments");
            RefreshTable(formState);
            RefreshTableSettings();
            SetupAppointmentDGV();
        }
        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexSelected = e.RowIndex;
            if (indexSelected < 0) { return; }//Error handler for clicking header row
            selectedRow = mainDataGridView.Rows[indexSelected];
        }
        private void mainDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainDataGridView.ClearSelection();
        }

        #endregion

        #region Helper methods

        public void RefreshTable(string state)
        {
            if (state == "Appointments")
            {
                FilterAppointments();

                mainDataGridView.Columns["appointmentId"].Visible = false;
                mainDataGridView.Columns["userId"].Visible = false;
                appointmentFilter.SelectedIndex = 0;
            }
            else if (state == "Customers")
            {
                mainDataGridView.DataSource = dbManager.GetData(Queries.GetCustomerTableQuery);
            }

            mainDataGridView.Columns["customerId"].Visible = false;
            mainDataGridView.Columns["addressId"].Visible = false;
            mainDataGridView.Columns["cityId"].Visible = false;
            mainDataGridView.Columns["countryId"].Visible = false;
        }

        private void FilterAppointments()
        {
            if (appointmentFilter.Text == "Weekly" || appointmentFilterState == "Monthly")
            {
                mainDataGridView.DataSource = dbManager.GetFilteredAppointments(appointmentFilterState);
            }
            else
            {
                mainDataGridView.DataSource = dbManager.GetData(Queries.GetAppointmentTableQuery);
            }
        }

        public void RefreshTableSettings()
        {
            // Tab color
            if (formState == "Customers")
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
        private bool ConfirmDeletion()
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                                      "Confirm Deletion",
                                      MessageBoxButtons.YesNo);
            return confirmResult == DialogResult.Yes ? true : false;
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
            formState = state;
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

        #endregion

        private void appointmentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (appointmentFilter.SelectedIndex == 1)
            {
                appointmentFilterState = "Weekly";
            }
            else if (appointmentFilter.SelectedIndex == 2)
            {
                appointmentFilterState = "Monthly";
            }
            else
            {
                appointmentFilterState = "All";
            }
            FilterAppointments();
            SetupAppointmentDGV();
        }
    }
}
