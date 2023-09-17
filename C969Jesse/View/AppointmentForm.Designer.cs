namespace C969Jesse.Components
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPostal = new System.Windows.Forms.Label();
            this.appointmentFormTitle = new System.Windows.Forms.Label();
            this.lblAppointmentTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.CancelBttn = new System.Windows.Forms.Button();
            this.SaveBttn = new System.Windows.Forms.Button();
            this.comboBoxCustomers = new System.Windows.Forms.ComboBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAppointmentTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxLocations = new System.Windows.Forms.ComboBox();
            this.comboBoxVisitTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPostal
            // 
            this.lblPostal.AutoSize = true;
            this.lblPostal.Location = new System.Drawing.Point(259, 211);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(53, 13);
            this.lblPostal.TabIndex = 29;
            this.lblPostal.Text = "Visit Type";
            // 
            // appointmentFormTitle
            // 
            this.appointmentFormTitle.AutoSize = true;
            this.appointmentFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentFormTitle.Location = new System.Drawing.Point(173, 27);
            this.appointmentFormTitle.Name = "appointmentFormTitle";
            this.appointmentFormTitle.Size = new System.Drawing.Size(159, 16);
            this.appointmentFormTitle.TabIndex = 27;
            this.appointmentFormTitle.Text = "Add New Appointment";
            // 
            // lblAppointmentTime
            // 
            this.lblAppointmentTime.AutoSize = true;
            this.lblAppointmentTime.Location = new System.Drawing.Point(132, 312);
            this.lblAppointmentTime.Name = "lblAppointmentTime";
            this.lblAppointmentTime.Size = new System.Drawing.Size(92, 13);
            this.lblAppointmentTime.TabIndex = 26;
            this.lblAppointmentTime.Text = "Appointment Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Consultant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Customer Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(135, 179);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(226, 20);
            this.txtDescription.TabIndex = 18;
            // 
            // CancelBttn
            // 
            this.CancelBttn.Location = new System.Drawing.Point(135, 378);
            this.CancelBttn.Name = "CancelBttn";
            this.CancelBttn.Size = new System.Drawing.Size(99, 41);
            this.CancelBttn.TabIndex = 16;
            this.CancelBttn.Text = "Cancel";
            this.CancelBttn.UseVisualStyleBackColor = true;
            this.CancelBttn.Click += new System.EventHandler(this.CancelBttn_Click);
            // 
            // SaveBttn
            // 
            this.SaveBttn.Location = new System.Drawing.Point(262, 378);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(99, 41);
            this.SaveBttn.TabIndex = 15;
            this.SaveBttn.Text = "Save";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // comboBoxCustomers
            // 
            this.comboBoxCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCustomers.FormattingEnabled = true;
            this.comboBoxCustomers.Location = new System.Drawing.Point(135, 85);
            this.comboBoxCustomers.Name = "comboBoxCustomers";
            this.comboBoxCustomers.Size = new System.Drawing.Size(226, 21);
            this.comboBoxCustomers.TabIndex = 30;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(135, 134);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(226, 21);
            this.comboBoxUsers.TabIndex = 33;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(135, 279);
            this.dateTimePicker1.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 20);
            this.dateTimePicker1.TabIndex = 34;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // comboBoxAppointmentTime
            // 
            this.comboBoxAppointmentTime.FormattingEnabled = true;
            this.comboBoxAppointmentTime.Location = new System.Drawing.Point(135, 328);
            this.comboBoxAppointmentTime.Name = "comboBoxAppointmentTime";
            this.comboBoxAppointmentTime.Size = new System.Drawing.Size(115, 21);
            this.comboBoxAppointmentTime.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Appointment Day";
            // 
            // comboBoxLocations
            // 
            this.comboBoxLocations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxLocations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxLocations.FormattingEnabled = true;
            this.comboBoxLocations.Location = new System.Drawing.Point(137, 232);
            this.comboBoxLocations.Name = "comboBoxLocations";
            this.comboBoxLocations.Size = new System.Drawing.Size(97, 21);
            this.comboBoxLocations.TabIndex = 37;
            // 
            // comboBoxVisitTypes
            // 
            this.comboBoxVisitTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxVisitTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxVisitTypes.FormattingEnabled = true;
            this.comboBoxVisitTypes.Location = new System.Drawing.Point(262, 232);
            this.comboBoxVisitTypes.Name = "comboBoxVisitTypes";
            this.comboBoxVisitTypes.Size = new System.Drawing.Size(97, 21);
            this.comboBoxVisitTypes.TabIndex = 38;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.comboBoxVisitTypes);
            this.Controls.Add(this.comboBoxLocations);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAppointmentTime);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.comboBoxCustomers);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.appointmentFormTitle);
            this.Controls.Add(this.lblAppointmentTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.CancelBttn);
            this.Controls.Add(this.SaveBttn);
            this.Name = "AppointmentForm";
            this.Text = "AddAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.Label appointmentFormTitle;
        private System.Windows.Forms.Label lblAppointmentTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button CancelBttn;
        private System.Windows.Forms.Button SaveBttn;
        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxAppointmentTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxLocations;
        private System.Windows.Forms.ComboBox comboBoxVisitTypes;
    }
}