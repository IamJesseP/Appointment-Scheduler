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

        private string formState = "Customers"; // Default to customerData

        public bool isUpdate = false;

        public MainForm()
        {
            InitializeComponent();

            this.Controls.Add(mainDataGridView);
            
            UpdateButtons(formState);
            RefreshTable(formState);
            SetupCustomerDGV();
            RefreshTableSettings();
        }

        #region Helper methods
        public void RefreshTable(string state)
        {
            if (state == "Appointments")
            {
                mainDataGridView.DataSource = dbManager.GetData(Queries.GetAppointmentTableQuery);

                mainDataGridView.Columns["appointmentId"].Visible = false;
                mainDataGridView.Columns["userId"].Visible = false;
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
                    // UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm();
                    // updateCustomerForm.PopulateFields(selectedRow);
                    //updateCustomerForm.MainFormInstance = this;
                    //updateCustomerForm.Show();

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
                var selectedRow = mainDataGridView.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                dbManager.DeleteCustomer(customerId);
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
        private void mainDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainDataGridView.ClearSelection();
        }
        #endregion

    }
}
