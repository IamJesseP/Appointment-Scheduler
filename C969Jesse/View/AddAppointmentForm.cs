using C969Jesse.Controller;
using C969Jesse.Database;
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
    public partial class AddAppointmentForm : Form
    {
        private DbManager dbManager = new DbManager();

        private AppointmentController appointmentController = new AppointmentController();

        public MainForm MainFormInstance { get; set; }

        private bool isUpdate = true;

        public AddAppointmentForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            // Requirement F: Using combobox picker and dbManager to prevent
            // invalid customer and user data
            var customers = dbManager.GetCustomerNames();
            var users = dbManager.GetUserNames();
            comboBoxCustomers.DataSource = new BindingSource(customers, null);
            comboBoxUsers.DataSource = new BindingSource(users, null);
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
                { "AppointmentTime", comboBoxAppointmentTime.Text },
            };
            var startEndTime = appointmentController.ConvertStringToDateTime(selectedDate, selectedTimeStr);

            dbManager.SaveAppointment(appointmentData, startEndTime, !isUpdate);
            MainFormInstance?.RefreshTable("Appointment");
            MainFormInstance?.RefreshTableSettings();
            MainFormInstance?.GiveUserFeedBack(!isUpdate);
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            var availableSlots = appointmentController.GetAvailableSlots(selectedDate);
            comboBoxAppointmentTime.DataSource = availableSlots;
           
        }
    }
}

