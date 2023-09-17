using C969Jesse.Components;
using C969Jesse.Controller;
using C969Jesse.Controller.Utils;
using C969Jesse.Database;
using C969Jesse.Model.Enums;
using C969Jesse.Utils;
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
    public partial class Appointment : Form
    {

        private AppointmentController appointmentController = new AppointmentController();

        private UserController userController = new UserController();

        private CustomerController customerController = new CustomerController();

        private DataGridViewRow selectedRow = null;

        private string appointmentFilterState = "All";

        private FormState formState = FormState.Customers; // Default to customers

        private int selectedMonth = DateTime.Now.Month; // Default to the current month

        private int selectedYear = DateTime.Now.Year;   // and year

        private string selectedUserId = UserSession.CurrentUserId.ToString();

        private string selectedUserName = UserSession.CurrentUserName;

        public bool isUpdate = false;

        public Appointment()
        {
            InitializeComponent();
            UpdateButtons();
            RefreshTable();
            SetupCustomerDGV();
            RefreshTableSettings();
        }

        #region Event Handlers

        private void AddBttn_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            if (formState == FormState.Customers)
            {
                var addCustomerForm = new CustomerForm();
                addCustomerForm.UpdateCustomerFormTitle(isUpdate);
                addCustomerForm.MainFormInstance = this; // Dependency injection!
                addCustomerForm.Show();
            }
            else if (formState == FormState.Appointments)
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
                if (formState == FormState.Customers)
                {
                    var addCustomerForm = new CustomerForm();
                    addCustomerForm.PopulateFields(selectedRow);
                    addCustomerForm.UpdateCustomerFormTitle(isUpdate);
                    addCustomerForm.MainFormInstance = this;
                    addCustomerForm.Show();
                }
                else if (formState == FormState.Appointments)
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
                if (formState == FormState.Customers)
                {
                    int customerId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    customerController.DeleteCustomer(customerId);
                }
                else if (formState == FormState.Appointments)
                {
                    int appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
                    appointmentController.DeleteAppointment(appointmentId);
                }

                RefreshTable();
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
            formState = FormState.Customers;
            UpdateButtons();
            RefreshTable();
            RefreshTableSettings();
            SetupCustomerDGV();
        }
        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            formState = FormState.Appointments;
            UpdateButtons();
            RefreshTable();
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
        private void appointmentTypesPerMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formState = FormState.TypePerMonth;
            UpdateButtons();
            RefreshTableSettings();

            comboBoxMonths.SelectedIndex = selectedMonth - 1;
            mainDataGridView.DataSource = appointmentController.GetAppointmentTypesByMonthReport(selectedMonth, selectedYear);
        }
        private void consultantSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formState = FormState.Consultants;
            UpdateButtons();
            RefreshTableSettings();

            mainDataGridView.DataSource = userController.GetConsultantSchedule(selectedUserName, selectedUserId);
            SetupAppointmentDGV();
        }
        private void comboBoxMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMonth = comboBoxMonths.SelectedIndex + 1;
        }
        private void appointmentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAppointmentFilter.SelectedIndex == 1)
            {
                appointmentFilterState = "Weekly";
            }
            else if (comboBoxAppointmentFilter.SelectedIndex == 2)
            {
                appointmentFilterState = "Monthly";
            }
            else
            {
                appointmentFilterState = "All";
            }
            mainDataGridView.DataSource = appointmentController.GetAppointments(appointmentFilterState);
            SetupAppointmentDGV();
        }
        private void comboConsultants_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUserId = ((KeyValuePair<int, string>)comboConsultants.SelectedItem).Key.ToString();
            selectedUserName = ((KeyValuePair<int, string>)comboConsultants.SelectedItem).Value;
        }
        private void ViewReportBttn_Click(object sender, EventArgs e)
        {
            if (formState == FormState.TypePerMonth)
            {
                mainDataGridView.DataSource = appointmentController.GetAppointmentTypesByMonthReport(selectedMonth, selectedYear);
            }
            else if (formState == FormState.Consultants)
            {
                mainDataGridView.DataSource = userController.GetConsultantSchedule(selectedUserName, selectedUserId);
                SetupAppointmentDGV();
            }
        }

        #endregion

        #region Helper methods

        public void RefreshTable()
        {
            if (formState == FormState.Appointments)
            {
                mainDataGridView.DataSource = appointmentController.GetAppointments(appointmentFilterState);
                SetupAppointmentDGV();
            }
            else if (formState == FormState.Customers)
            {
                mainDataGridView.DataSource = customerController.GetCustomers(Queries.GetCustomerTableQuery);
                SetupCustomerDGV();
            }
        }
        public void RefreshTableSettings()
        {
            // Tab color
            if (formState == FormState.Customers)
            {
                CustomerTab.ForeColor = Color.Goldenrod;
                AppointmentsTab.ForeColor = Color.Black;
                reportsToolStripMenuItem.ForeColor = Color.Black;
            }
            else if (formState == FormState.Appointments)
            {
                CustomerTab.ForeColor = Color.Black;
                AppointmentsTab.ForeColor = Color.Goldenrod;
                reportsToolStripMenuItem.ForeColor = Color.Black;

            } else
            {
                CustomerTab.ForeColor = Color.Black;
                AppointmentsTab.ForeColor = Color.Black;
                reportsToolStripMenuItem.ForeColor = Color.Goldenrod;
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
        private void UpdateButtons()
        {
            AddBttn.Show();
            UpdateBttn.Show();
            DeleteBttn.Show();
            ViewReportBttn.Hide();

            lblFilterAppointments.Visible = false;
            lblConsultants.Visible = false;
            lblMonth.Visible = false;

            comboBoxAppointmentFilter.Visible = false;
            comboBoxMonths.Visible = false;
            comboConsultants.Visible = false;

            switch (formState)
            {
                case FormState.Customers:
                    AddBttn.Text = "Add Customer";
                    UpdateBttn.Text = "Update Customer";
                    DeleteBttn.Text = "Delete Customer";
                    break;

                case FormState.Appointments:
                    AddBttn.Text = "Add \nAppointment";
                    UpdateBttn.Text = "Update Appointment";
                    DeleteBttn.Text = "Delete Appointment";
                    break;

                default:
                    AddBttn.Hide();
                    UpdateBttn.Hide();
                    DeleteBttn.Hide();
                    ViewReportBttn.Show();
                    mainDataGridView.DataSource = null;

                    if (formState == FormState.TypePerMonth)
                    {
                        comboBoxMonths.Visible = true;
                        lblMonth.Visible = true;
                    }
                    else if (formState == FormState.Consultants)
                    {
                        comboConsultants.Visible = true;
                        lblConsultants.Visible = true;
                        var users = userController.GetUserNames();
                        comboConsultants.DataSource = new BindingSource(users, null);
                    }
                    // extra report here
                    break;
            }
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

            mainDataGridView.Columns["customerId"].Visible = false;
            mainDataGridView.Columns["addressId"].Visible = false;
            mainDataGridView.Columns["cityId"].Visible = false;
            mainDataGridView.Columns["countryId"].Visible = false;
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

            mainDataGridView.Columns["customerId"].Visible = false;
            mainDataGridView.Columns["addressId"].Visible = false;
            mainDataGridView.Columns["cityId"].Visible = false;
            mainDataGridView.Columns["countryId"].Visible = false;

            mainDataGridView.Columns["appointmentId"].Visible = false;
            mainDataGridView.Columns["userId"].Visible = false;
            comboBoxAppointmentFilter.SelectedIndex = 0;
        }

        #endregion




    }
}
