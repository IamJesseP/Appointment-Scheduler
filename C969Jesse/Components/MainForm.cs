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
        // TODO: Move to static class ?
        readonly string customerQuery = "SELECT " +
                "c.customerId, c.customerName, " +
                "a.address, a.phone, " +
                "ci.city, " +
                "co.country " +
                "FROM customer c " +
                "JOIN address a ON c.addressId = a.addressId " +
                "JOIN city ci ON a.cityId = ci.cityId " +
                "JOIN country co ON ci.countryId = co.countryId";

        readonly string appointmentQuery = "SELECT " +
                   "ap.appointmentId, ap.title, ap.description, ap.start, ap.end, ap.type, " +
                   "c.customerName, c.customerId, a.phone AS customerPhone " +
                   "FROM appointment ap " +
                   "JOIN customer c ON ap.customerId = c.customerId " +
                   "JOIN address a ON c.addressId = a.addressId " +
                   "JOIN user u ON ap.userId = u.userId " +
                   "ORDER BY ap.start";
        string bttnState = "Customers";

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(mainDataGridView);

            // Default to customerData
            var customerData = new DataAccess();
            mainDataGridView.DataSource = customerData.GetData(customerQuery);
            SetupCustomerDGV();
            UpdateButtons("Customers");

            //edit props
            mainDataGridView.ReadOnly = true;
            mainDataGridView.MultiSelect = false;
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


        private void ClickCustomersTab(object sender, EventArgs e)
        {
            var customerData = new DataAccess();
            mainDataGridView.DataSource = customerData.GetData(customerQuery);
            bttnState = "Customers";
            UpdateButtons(bttnState);
            SetupCustomerDGV();
        }
        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            var appointmentsData = new DataAccess();
            mainDataGridView.DataSource = appointmentsData.GetData(appointmentQuery);
            bttnState = "Appointments";
            UpdateButtons(bttnState);
            SetupAppointmentDGV();
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
        }

        private void SetupCustomerDGV()
        {
            // Tab color
            CustomerTab.ForeColor = Color.Goldenrod;
            AppointmentsTab.ForeColor = Color.Black;

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

        private void SetupAppointmentDGV()
        {
            // Tab color
            CustomerTab.ForeColor = Color.Black;
            AppointmentsTab.ForeColor = Color.Goldenrod;

            // Setting column titles
            mainDataGridView.Columns["appointmentId"].HeaderText = "Appointment ID";
            mainDataGridView.Columns["customerName"].HeaderText = "Customer Name";
            mainDataGridView.Columns["title"].HeaderText = "Title";
            mainDataGridView.Columns["description"].HeaderText = "Description";
            mainDataGridView.Columns["start"].HeaderText = "Start";
            mainDataGridView.Columns["end"].HeaderText = "End";
            mainDataGridView.Columns["type"].HeaderText = "Visit Type";
            mainDataGridView.Columns["customerPhone"].HeaderText = "Phone";


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

        private void AddBttn_Click(object sender, EventArgs e)
        {
            if (bttnState == "Customers")
            {
                var addCustomerForm = new AddCustomerForm();
                addCustomerForm.Show();
            }
            else if (bttnState == "Appointments")
            {
                // var addAppointmentForm = new AddAppointmentForm();
                // addAppointmentForm.ShowDialog();
            }
        }

    }
}
