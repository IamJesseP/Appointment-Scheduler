namespace C969Jesse.Components
{
    partial class AddAppointmentForm
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
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddCustomerCity = new System.Windows.Forms.TextBox();
            this.txtAddCustomerAddress = new System.Windows.Forms.TextBox();
            this.CancelBttn = new System.Windows.Forms.Button();
            this.SaveBttn = new System.Windows.Forms.Button();
            this.comboBoxCustomers = new System.Windows.Forms.ComboBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.startTimeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
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
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(258, 227);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(103, 20);
            this.txtPostal.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Add New Appointment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Appointment Time";
            this.label5.Click += new System.EventHandler(this.label5_Click);
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtAddCustomerCity
            // 
            this.txtAddCustomerCity.Location = new System.Drawing.Point(135, 227);
            this.txtAddCustomerCity.Name = "txtAddCustomerCity";
            this.txtAddCustomerCity.Size = new System.Drawing.Size(99, 20);
            this.txtAddCustomerCity.TabIndex = 19;
            // 
            // txtAddCustomerAddress
            // 
            this.txtAddCustomerAddress.Location = new System.Drawing.Point(135, 179);
            this.txtAddCustomerAddress.Name = "txtAddCustomerAddress";
            this.txtAddCustomerAddress.Size = new System.Drawing.Size(226, 20);
            this.txtAddCustomerAddress.TabIndex = 18;
            // 
            // CancelBttn
            // 
            this.CancelBttn.Location = new System.Drawing.Point(135, 378);
            this.CancelBttn.Name = "CancelBttn";
            this.CancelBttn.Size = new System.Drawing.Size(99, 41);
            this.CancelBttn.TabIndex = 16;
            this.CancelBttn.Text = "Cancel";
            this.CancelBttn.UseVisualStyleBackColor = true;
            // 
            // SaveBttn
            // 
            this.SaveBttn.Location = new System.Drawing.Point(262, 378);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(99, 41);
            this.SaveBttn.TabIndex = 15;
            this.SaveBttn.Text = "Save";
            this.SaveBttn.UseVisualStyleBackColor = true;
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
            this.dateTimePicker1.Location = new System.Drawing.Point(135, 272);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // startTimeComboBox
            // 
            this.startTimeComboBox.FormattingEnabled = true;
            this.startTimeComboBox.Location = new System.Drawing.Point(137, 318);
            this.startTimeComboBox.Name = "startTimeComboBox";
            this.startTimeComboBox.Size = new System.Drawing.Size(115, 21);
            this.startTimeComboBox.TabIndex = 35;
            this.startTimeComboBox.SelectedIndexChanged += new System.EventHandler(this.startTimeComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Appointment Day";
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.startTimeComboBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.comboBoxCustomers);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddCustomerCity);
            this.Controls.Add(this.txtAddCustomerAddress);
            this.Controls.Add(this.CancelBttn);
            this.Controls.Add(this.SaveBttn);
            this.Name = "AddAppointmentForm";
            this.Text = "AddAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.TextBox txtPostal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddCustomerCity;
        private System.Windows.Forms.TextBox txtAddCustomerAddress;
        private System.Windows.Forms.Button CancelBttn;
        private System.Windows.Forms.Button SaveBttn;
        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox startTimeComboBox;
        private System.Windows.Forms.Label label7;
    }
}