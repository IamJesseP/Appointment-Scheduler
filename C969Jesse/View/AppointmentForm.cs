using C969Jesse.Controller;
using C969Jesse.Controller.Utils;
using C969Jesse.Database;
using C969Jesse.Model;
using C969Jesse.Model.Enums;
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
    public partial class AppointmentForm : Form
    {
        public Appointment MainFormInstance { get; set; }

        private AppointmentController appointmentController = new AppointmentController();

        private CustomerController customerController = new CustomerController();

        private UserController userController = new UserController();

        private string appointmentId;

        public AppointmentForm()
        {
            InitializeComponent();
            LoadForm();
        }

        #region Event Handlers
        private void SaveBttn_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            string selectedTimeStr = comboBoxAppointmentTime.SelectedValue.ToString();
       

            var appointmentData = new Dictionary<string, string>
            {
                { "CustomerId", ((KeyValuePair<int, string>)comboBoxCustomers.SelectedItem).Key.ToString() },
                { "UserId", ((KeyValuePair<int, string>)comboBoxUsers.SelectedItem).Key.ToString() },
                { "CustomerName", comboBoxCustomers.Text },
                { "ConsultantName", comboBoxUsers.Text },
                { "Description", txtDescription.Text },
                { "Location", comboBoxLocations.Text },
                { "VisitType", comboBoxVisitTypes.Text },
                { "AppointmentId", appointmentId }
            };
            var startEndTime = appointmentController.ConvertStringToDateTime(selectedDate, selectedTimeStr);

            // Requirement C: Add/Update appointments
            appointmentController.SaveAppointment(appointmentData, startEndTime, MainFormInstance.isUpdate);
            
            MainFormInstance?.RefreshTable();
            MainFormInstance?.RefreshTableSettings();
            MainFormInstance?.GiveUserFeedBack(MainFormInstance.isUpdate);
            this.Hide();
        }
        private void CancelBttn_Click(object sender, EventArgs e)
        {
            MainFormInstance?.RefreshTableSettings();
            this.Close();
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            // Requirement F: Picking appointments on days before current day is invalid
            if (selectedDate < DateTime.Now.Date)
            {
                MessageBox.Show("Appointment date cannot be before today's date.");
                selectedDate = DateTime.Now.Date;
            }
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);
            comboBoxAppointmentTime.DataSource = availableSlots;
           
        }
        #endregion

        #region Helper methods
        private void LoadForm()
        {
            // Requirement F: Using combobox picker and dbManager to prevent
            // invalid customer and user data input
            var customers = customerController.GetCustomerNames();
            var users = userController.GetUserNames();
            comboBoxUsers.DataSource = new BindingSource(users, null);
            comboBoxCustomers.DataSource = new BindingSource(customers, null);
            comboBoxCustomers.DisplayMember = "Value";
            comboBoxCustomers.ValueMember = "Key";
            comboBoxUsers.DisplayMember = "Value";
            comboBoxUsers.ValueMember = "Key";

            // Requirement F: Using combobox picker and appointmentController that
            // filters only available appointment times and 9-5pm business hours
            DateTime selectedDate = dateTimePicker1.Value;
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);
            comboBoxAppointmentTime.DataSource = availableSlots;
            comboBoxLocations.DataSource = Enum.GetNames(typeof(Locations));
            comboBoxVisitTypes.DataSource = Enum.GetNames(typeof(VisitTypes));
        }
        public void UpdateAppointmentFormTitle(bool isUpdate)
        {
            appointmentFormTitle.Text = isUpdate ? "Update Appointment" : "Add Appointment";
            lblAppointmentTime.Text = isUpdate ? "NEW Appointment Time" : "Appointment Time";
        }
        public void PopulateFields(DataGridViewRow row)
        {
            var customerKeyValuePair = new KeyValuePair<int, string>
            (
            //Set Customer ID and Name
            Convert.ToInt32(row.Cells[1].Value),
            row.Cells[10].Value.ToString()
            );

            // Set User ID and Consultant Name
            var userKeyValuePair = new KeyValuePair<int, string>
            (
                Convert.ToInt32(row.Cells[2].Value),
                row.Cells[9].Value.ToString()
            );

            comboBoxCustomers.SelectedItem = customerKeyValuePair;
            comboBoxUsers.SelectedItem = userKeyValuePair;
            txtDescription.Text = row.Cells[3].Value.ToString();
            comboBoxLocations.Text = row.Cells[4].Value.ToString();
            comboBoxVisitTypes.Text = row.Cells[5].Value.ToString();
            comboBoxAppointmentTime.Text = row.Cells[8].Value.ToString();

            appointmentId = row.Cells[0].Value.ToString();
        }
        #endregion
    }
}

