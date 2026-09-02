namespace Clients_form
{
    partial class Client_Form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.dgvViewPartners = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.CB_Selected_Client = new System.Windows.Forms.ComboBox();
            this.BtnViewClients = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TBClientEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBClient_ContactNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBClient_Surname = new System.Windows.Forms.TextBox();
            this.BAddClient = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBClient_name = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUpdateClient_Email = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUpdateClient_ContactNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUpdateClient_Surname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUpdateClient_Name = new System.Windows.Forms.TextBox();
            this.cbxUpdate_Client = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BCancel2 = new System.Windows.Forms.Button();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbxDeleteClient = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPartners)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(22, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.btnCancel1);
            this.tabPage4.Controls.Add(this.dgvViewPartners);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.CB_Selected_Client);
            this.tabPage4.Controls.Add(this.BtnViewClients);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(695, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "View Clients";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnCancel1
            // 
            this.btnCancel1.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.btnCancel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel1.Location = new System.Drawing.Point(465, 378);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(175, 50);
            this.btnCancel1.TabIndex = 3;
            this.btnCancel1.Text = "Cancel";
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // dgvViewPartners
            // 
            this.dgvViewPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewPartners.Location = new System.Drawing.Point(20, 19);
            this.dgvViewPartners.Name = "dgvViewPartners";
            this.dgvViewPartners.RowHeadersWidth = 51;
            this.dgvViewPartners.Size = new System.Drawing.Size(407, 322);
            this.dgvViewPartners.TabIndex = 23;
            this.dgvViewPartners.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(503, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 23);
            this.label13.TabIndex = 22;
            this.label13.Text = "Select client: \r\n";
            // 
            // CB_Selected_Client
            // 
            this.CB_Selected_Client.FormattingEnabled = true;
            this.CB_Selected_Client.Location = new System.Drawing.Point(441, 47);
            this.CB_Selected_Client.Name = "CB_Selected_Client";
            this.CB_Selected_Client.Size = new System.Drawing.Size(234, 21);
            this.CB_Selected_Client.TabIndex = 1;
            this.CB_Selected_Client.DropDown += new System.EventHandler(this.CB_Selected_Client_DropDown);
            // 
            // BtnViewClients
            // 
            this.BtnViewClients.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BtnViewClients.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnViewClients.Location = new System.Drawing.Point(34, 378);
            this.BtnViewClients.Name = "BtnViewClients";
            this.BtnViewClients.Size = new System.Drawing.Size(175, 50);
            this.BtnViewClients.TabIndex = 2;
            this.BtnViewClients.Text = "View";
            this.BtnViewClients.UseVisualStyleBackColor = true;
            this.BtnViewClients.Click += new System.EventHandler(this.BtnViewClients_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TBClientEmail);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TBClient_ContactNum);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TBClient_Surname);
            this.tabPage1.Controls.Add(this.BAddClient);
            this.tabPage1.Controls.Add(this.BCancel);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TBClient_name);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(695, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Surname:";
            // 
            // TBClientEmail
            // 
            this.TBClientEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBClientEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBClientEmail.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.TBClientEmail.Location = new System.Drawing.Point(431, 163);
            this.TBClientEmail.Name = "TBClientEmail";
            this.TBClientEmail.Size = new System.Drawing.Size(238, 27);
            this.TBClientEmail.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Contact number:";
            // 
            // TBClient_ContactNum
            // 
            this.TBClient_ContactNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBClient_ContactNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBClient_ContactNum.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.TBClient_ContactNum.Location = new System.Drawing.Point(431, 231);
            this.TBClient_ContactNum.Name = "TBClient_ContactNum";
            this.TBClient_ContactNum.Size = new System.Drawing.Size(238, 27);
            this.TBClient_ContactNum.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Email:";
            // 
            // TBClient_Surname
            // 
            this.TBClient_Surname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBClient_Surname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBClient_Surname.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.TBClient_Surname.Location = new System.Drawing.Point(431, 95);
            this.TBClient_Surname.Name = "TBClient_Surname";
            this.TBClient_Surname.Size = new System.Drawing.Size(238, 27);
            this.TBClient_Surname.TabIndex = 5;
            // 
            // BAddClient
            // 
            this.BAddClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BAddClient.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BAddClient.FlatAppearance.BorderSize = 10;
            this.BAddClient.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BAddClient.Location = new System.Drawing.Point(26, 387);
            this.BAddClient.Name = "BAddClient";
            this.BAddClient.Size = new System.Drawing.Size(175, 50);
            this.BAddClient.TabIndex = 8;
            this.BAddClient.Text = "ADD";
            this.BAddClient.UseVisualStyleBackColor = false;
            this.BAddClient.Click += new System.EventHandler(this.BAddClient_Click_1);
            // 
            // BCancel
            // 
            this.BCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BCancel.FlatAppearance.BorderSize = 10;
            this.BCancel.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BCancel.Location = new System.Drawing.Point(492, 387);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(175, 50);
            this.BCancel.TabIndex = 9;
            this.BCancel.Text = "CANCEL";
            this.BCancel.UseVisualStyleBackColor = false;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Name:";
            // 
            // TBClient_name
            // 
            this.TBClient_name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBClient_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBClient_name.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.TBClient_name.Location = new System.Drawing.Point(429, 27);
            this.TBClient_name.Name = "TBClient_name";
            this.TBClient_name.Size = new System.Drawing.Size(238, 27);
            this.TBClient_name.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtUpdateClient_Email);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtUpdateClient_ContactNumber);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtUpdateClient_Surname);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtUpdateClient_Name);
            this.tabPage2.Controls.Add(this.cbxUpdate_Client);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.BCancel2);
            this.tabPage2.Controls.Add(this.btnUpdateClient);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(695, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Client";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 23);
            this.label9.TabIndex = 44;
            this.label9.Text = "Surname:";
            // 
            // txtUpdateClient_Email
            // 
            this.txtUpdateClient_Email.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateClient_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateClient_Email.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.txtUpdateClient_Email.Location = new System.Drawing.Point(431, 225);
            this.txtUpdateClient_Email.Name = "txtUpdateClient_Email";
            this.txtUpdateClient_Email.Size = new System.Drawing.Size(236, 27);
            this.txtUpdateClient_Email.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 23);
            this.label10.TabIndex = 45;
            this.label10.Text = "Contact number:";
            // 
            // txtUpdateClient_ContactNumber
            // 
            this.txtUpdateClient_ContactNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateClient_ContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateClient_ContactNumber.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.txtUpdateClient_ContactNumber.Location = new System.Drawing.Point(431, 291);
            this.txtUpdateClient_ContactNumber.Name = "txtUpdateClient_ContactNumber";
            this.txtUpdateClient_ContactNumber.Size = new System.Drawing.Size(236, 27);
            this.txtUpdateClient_ContactNumber.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 46;
            this.label11.Text = "Email:";
            // 
            // txtUpdateClient_Surname
            // 
            this.txtUpdateClient_Surname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateClient_Surname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateClient_Surname.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.txtUpdateClient_Surname.Location = new System.Drawing.Point(431, 159);
            this.txtUpdateClient_Surname.Name = "txtUpdateClient_Surname";
            this.txtUpdateClient_Surname.Size = new System.Drawing.Size(236, 27);
            this.txtUpdateClient_Surname.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 23);
            this.label12.TabIndex = 43;
            this.label12.Text = "Name:";
            // 
            // txtUpdateClient_Name
            // 
            this.txtUpdateClient_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateClient_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateClient_Name.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.txtUpdateClient_Name.Location = new System.Drawing.Point(429, 93);
            this.txtUpdateClient_Name.Name = "txtUpdateClient_Name";
            this.txtUpdateClient_Name.Size = new System.Drawing.Size(236, 27);
            this.txtUpdateClient_Name.TabIndex = 11;
            // 
            // cbxUpdate_Client
            // 
            this.cbxUpdate_Client.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.cbxUpdate_Client.FormattingEnabled = true;
            this.cbxUpdate_Client.IntegralHeight = false;
            this.cbxUpdate_Client.Location = new System.Drawing.Point(431, 27);
            this.cbxUpdate_Client.Name = "cbxUpdate_Client";
            this.cbxUpdate_Client.Size = new System.Drawing.Size(234, 27);
            this.cbxUpdate_Client.TabIndex = 10;
            this.cbxUpdate_Client.DropDown += new System.EventHandler(this.cbxUpdate_Client_DropDown);
            this.cbxUpdate_Client.SelectedIndexChanged += new System.EventHandler(this.CBDelete_Client_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.label6.Location = new System.Drawing.Point(26, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 23);
            this.label6.TabIndex = 38;
            this.label6.Text = "Select client you want to update:";
            // 
            // BCancel2
            // 
            this.BCancel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BCancel2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BCancel2.FlatAppearance.BorderSize = 10;
            this.BCancel2.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BCancel2.Location = new System.Drawing.Point(492, 387);
            this.BCancel2.Name = "BCancel2";
            this.BCancel2.Size = new System.Drawing.Size(175, 50);
            this.BCancel2.TabIndex = 16;
            this.BCancel2.Text = "CANCEL";
            this.BCancel2.UseVisualStyleBackColor = false;
            this.BCancel2.Click += new System.EventHandler(this.BCancel2_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdateClient.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnUpdateClient.FlatAppearance.BorderSize = 10;
            this.btnUpdateClient.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.btnUpdateClient.Location = new System.Drawing.Point(26, 387);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(175, 50);
            this.btnUpdateClient.TabIndex = 15;
            this.btnUpdateClient.Text = "UPDATE";
            this.btnUpdateClient.UseVisualStyleBackColor = false;
            this.btnUpdateClient.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.cbxDeleteClient);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnDeleteClient);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(695, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Client";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbxDeleteClient
            // 
            this.cbxDeleteClient.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.cbxDeleteClient.FormattingEnabled = true;
            this.cbxDeleteClient.Location = new System.Drawing.Point(431, 27);
            this.cbxDeleteClient.Name = "cbxDeleteClient";
            this.cbxDeleteClient.Size = new System.Drawing.Size(234, 27);
            this.cbxDeleteClient.TabIndex = 17;
            this.cbxDeleteClient.DropDown += new System.EventHandler(this.cbxDeleteClient_DropDown);
            this.cbxDeleteClient.SelectedIndexChanged += new System.EventHandler(this.cbxDeleteClient_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.label5.Location = new System.Drawing.Point(26, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "Select client you want to delete:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.button1.Location = new System.Drawing.Point(492, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 50);
            this.button1.TabIndex = 19;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteClient.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnDeleteClient.FlatAppearance.BorderSize = 10;
            this.btnDeleteClient.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.btnDeleteClient.Location = new System.Drawing.Point(26, 387);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(175, 50);
            this.btnDeleteClient.TabIndex = 18;
            this.btnDeleteClient.Text = "DELETE";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(200, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(363, 78);
            this.label7.TabIndex = 25;
            this.label7.Text = "Clients Form";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(22, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 100);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 94);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(240, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 78);
            this.label8.TabIndex = 0;
            this.label8.Text = "Clients";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Client_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPartners)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBClientEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBClient_ContactNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBClient_Surname;
        private System.Windows.Forms.TextBox TBClient_name;
        private System.Windows.Forms.Button BAddClient;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.ComboBox cbxUpdate_Client;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BCancel2;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbxDeleteClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUpdateClient_Email;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUpdateClient_ContactNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUpdateClient_Surname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUpdateClient_Name;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.DataGridView dgvViewPartners;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CB_Selected_Client;
        private System.Windows.Forms.Button BtnViewClients;
    }
}

