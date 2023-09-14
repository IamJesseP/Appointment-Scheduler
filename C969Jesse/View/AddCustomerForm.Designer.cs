namespace C969Jesse.Components
{
    partial class AddCustomerForm
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
            this.components = new System.ComponentModel.Container();
            this.SaveBttn = new System.Windows.Forms.Button();
            this.CancelBttn = new System.Windows.Forms.Button();
            this.txtCustomerAddCountry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtAddCustomerCity = new System.Windows.Forms.TextBox();
            this.txtAddCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddCustomerAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.lblPostal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveBttn
            // 
            this.SaveBttn.Location = new System.Drawing.Point(254, 375);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(99, 41);
            this.SaveBttn.TabIndex = 0;
            this.SaveBttn.Text = "Save";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // CancelBttn
            // 
            this.CancelBttn.Location = new System.Drawing.Point(127, 375);
            this.CancelBttn.Name = "CancelBttn";
            this.CancelBttn.Size = new System.Drawing.Size(99, 41);
            this.CancelBttn.TabIndex = 1;
            this.CancelBttn.Text = "Cancel";
            this.CancelBttn.UseVisualStyleBackColor = true;
            this.CancelBttn.Click += new System.EventHandler(this.CancelBttn_Click);
            // 
            // txtCustomerAddCountry
            // 
            this.txtCustomerAddCountry.Location = new System.Drawing.Point(127, 245);
            this.txtCustomerAddCountry.Name = "txtCustomerAddCountry";
            this.txtCustomerAddCountry.Size = new System.Drawing.Size(117, 20);
            this.txtCustomerAddCountry.TabIndex = 10;
            this.txtCustomerAddCountry.TextChanged += new System.EventHandler(this.txtCustomerAddCountry_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "City";
            // 
            // txtAddCustomerPhone
            // 
            this.txtAddCustomerPhone.Location = new System.Drawing.Point(127, 303);
            this.txtAddCustomerPhone.Name = "txtAddCustomerPhone";
            this.txtAddCustomerPhone.Size = new System.Drawing.Size(119, 20);
            this.txtAddCustomerPhone.TabIndex = 5;
            this.txtAddCustomerPhone.TextChanged += new System.EventHandler(this.txtAddCustomerPhone_TextChanged);
            // 
            // txtAddCustomerCity
            // 
            this.txtAddCustomerCity.Location = new System.Drawing.Point(127, 189);
            this.txtAddCustomerCity.Name = "txtAddCustomerCity";
            this.txtAddCustomerCity.Size = new System.Drawing.Size(117, 20);
            this.txtAddCustomerCity.TabIndex = 4;
            this.txtAddCustomerCity.TextChanged += new System.EventHandler(this.txtAddCustomerCity_TextChanged);
            // 
            // txtAddCustomerName
            // 
            this.txtAddCustomerName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddCustomerName.Location = new System.Drawing.Point(127, 82);
            this.txtAddCustomerName.Name = "txtAddCustomerName";
            this.txtAddCustomerName.Size = new System.Drawing.Size(226, 20);
            this.txtAddCustomerName.TabIndex = 2;
            this.txtAddCustomerName.TextChanged += new System.EventHandler(this.txtAddCustomerName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Address";
            // 
            // txtAddCustomerAddress
            // 
            this.txtAddCustomerAddress.Location = new System.Drawing.Point(127, 141);
            this.txtAddCustomerAddress.Name = "txtAddCustomerAddress";
            this.txtAddCustomerAddress.Size = new System.Drawing.Size(226, 20);
            this.txtAddCustomerAddress.TabIndex = 3;
            this.txtAddCustomerAddress.TextChanged += new System.EventHandler(this.txtAddCustomerAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(186, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Add New Customer";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(250, 189);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(103, 20);
            this.txtPostal.TabIndex = 13;
            this.txtPostal.TextChanged += new System.EventHandler(this.txtPostal_TextChanged);
            // 
            // lblPostal
            // 
            this.lblPostal.AutoSize = true;
            this.lblPostal.Location = new System.Drawing.Point(251, 173);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(36, 13);
            this.lblPostal.TabIndex = 14;
            this.lblPostal.Text = "Postal";
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomerAddCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddCustomerPhone);
            this.Controls.Add(this.txtAddCustomerCity);
            this.Controls.Add(this.txtAddCustomerAddress);
            this.Controls.Add(this.txtAddCustomerName);
            this.Controls.Add(this.CancelBttn);
            this.Controls.Add(this.SaveBttn);
            this.Name = "AddCustomerForm";
            this.Text = "Add Customer";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBttn;
        private System.Windows.Forms.Button CancelBttn;
        private System.Windows.Forms.TextBox txtCustomerAddCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddCustomerPhone;
        private System.Windows.Forms.TextBox txtAddCustomerCity;
        private System.Windows.Forms.TextBox txtAddCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddCustomerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.TextBox txtPostal;
    }
}