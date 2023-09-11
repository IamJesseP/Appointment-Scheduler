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


        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(mainDataGridView);

            // Default to customerData
            var customerData = new DataAccess();
            mainDataGridView.DataSource = customerData.GetData(customerQuery);

            //edit props
            mainDataGridView.ReadOnly = true;
            mainDataGridView.MultiSelect = false;
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            SetupCustomerDGV();
        }


        private void ClickCustomersTab(object sender, EventArgs e)
        {
            var customerData = new DataAccess();
            mainDataGridView.DataSource = customerData.GetData(customerQuery);
            SetupCustomerDGV();
        }

        private void ClickAppointmentsTab(object sender, EventArgs e)
        {
            var appointmentsData = new DataAccess();
            mainDataGridView.DataSource = appointmentsData.GetData(appointmentQuery);
            SetupAppointmentDGV();
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
    }
}
