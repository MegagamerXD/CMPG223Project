namespace ONESTOPEVENTS
{
    partial class Partner_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxPSelectDelete = new System.Windows.Forms.ComboBox();
            this.btnPDeteteCencel = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPContactNumberUpdate = new System.Windows.Forms.Label();
            this.txtPNameUpdate = new System.Windows.Forms.TextBox();
            this.lblPEmailUpdate = new System.Windows.Forms.Label();
            this.txtPSurnameUpdate = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPContactNumberUpdate = new System.Windows.Forms.TextBox();
            this.lblPURLUpdate = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxProfessionUpdate = new System.Windows.Forms.ComboBox();
            this.lblPNameUpdate = new System.Windows.Forms.Label();
            this.txtPEmailUpdate = new System.Windows.Forms.TextBox();
            this.lblPSurnameUpdate = new System.Windows.Forms.Label();
            this.lblPProfessionUpdate = new System.Windows.Forms.Label();
            this.cbxPartnerUpdate = new System.Windows.Forms.ComboBox();
            this.txtPURLUpdate = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxAddPartnerProfession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartnerContactNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartnerSurname = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPartnerEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPartnerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartnerWebsite = new System.Windows.Forms.TextBox();
            this.tabPartners = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.dgvViewPartners = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_Selected_Partner = new System.Windows.Forms.ComboBox();
            this.BtnViewEvent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPartners.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPartners)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(24, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 93);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(226, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 78);
            this.label7.TabIndex = 0;
            this.label7.Text = "Partners";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cbxPSelectDelete);
            this.tabPage3.Controls.Add(this.btnPDeteteCencel);
            this.tabPage3.Controls.Add(this.BtnDelete);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 464);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Partner";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "Select Partner ID you wish to delete:";
            // 
            // cbxPSelectDelete
            // 
            this.cbxPSelectDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxPSelectDelete.FormattingEnabled = true;
            this.cbxPSelectDelete.Location = new System.Drawing.Point(438, 23);
            this.cbxPSelectDelete.Name = "cbxPSelectDelete";
            this.cbxPSelectDelete.Size = new System.Drawing.Size(238, 27);
            this.cbxPSelectDelete.TabIndex = 18;
            this.cbxPSelectDelete.DropDown += new System.EventHandler(this.cbxPSelectDelete_DropDown);
            this.cbxPSelectDelete.SelectedIndexChanged += new System.EventHandler(this.cbxPSelectDelete_SelectedIndexChanged);
            // 
            // btnPDeteteCencel
            // 
            this.btnPDeteteCencel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDeteteCencel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPDeteteCencel.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnPDeteteCencel.FlatAppearance.BorderSize = 10;
            this.btnPDeteteCencel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDeteteCencel.Location = new System.Drawing.Point(501, 387);
            this.btnPDeteteCencel.Name = "btnPDeteteCencel";
            this.btnPDeteteCencel.Size = new System.Drawing.Size(175, 50);
            this.btnPDeteteCencel.TabIndex = 20;
            this.btnPDeteteCencel.Text = "CANCEL";
            this.btnPDeteteCencel.UseVisualStyleBackColor = false;
            this.btnPDeteteCencel.Click += new System.EventHandler(this.btnPDeteteCencel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BtnDelete.FlatAppearance.BorderSize = 10;
            this.BtnDelete.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(34, 387);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(175, 50);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "DELETE";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.lblPContactNumberUpdate);
            this.tabPage2.Controls.Add(this.txtPNameUpdate);
            this.tabPage2.Controls.Add(this.lblPEmailUpdate);
            this.tabPage2.Controls.Add(this.txtPSurnameUpdate);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.txtPContactNumberUpdate);
            this.tabPage2.Controls.Add(this.lblPURLUpdate);
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.cbxProfessionUpdate);
            this.tabPage2.Controls.Add(this.lblPNameUpdate);
            this.tabPage2.Controls.Add(this.txtPEmailUpdate);
            this.tabPage2.Controls.Add(this.lblPSurnameUpdate);
            this.tabPage2.Controls.Add(this.lblPProfessionUpdate);
            this.tabPage2.Controls.Add(this.cbxPartnerUpdate);
            this.tabPage2.Controls.Add(this.txtPURLUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Partner Info";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(295, 23);
            this.label14.TabIndex = 27;
            this.label14.Text = "Select Partner ID you wish to update:";
            // 
            // lblPContactNumberUpdate
            // 
            this.lblPContactNumberUpdate.AutoSize = true;
            this.lblPContactNumberUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPContactNumberUpdate.Location = new System.Drawing.Point(31, 179);
            this.lblPContactNumberUpdate.Name = "lblPContactNumberUpdate";
            this.lblPContactNumberUpdate.Size = new System.Drawing.Size(141, 23);
            this.lblPContactNumberUpdate.TabIndex = 15;
            this.lblPContactNumberUpdate.Text = "Contact Number:";
            // 
            // txtPNameUpdate
            // 
            this.txtPNameUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPNameUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPNameUpdate.Location = new System.Drawing.Point(438, 75);
            this.txtPNameUpdate.Name = "txtPNameUpdate";
            this.txtPNameUpdate.Size = new System.Drawing.Size(238, 27);
            this.txtPNameUpdate.TabIndex = 10;
            // 
            // lblPEmailUpdate
            // 
            this.lblPEmailUpdate.AutoSize = true;
            this.lblPEmailUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPEmailUpdate.Location = new System.Drawing.Point(31, 231);
            this.lblPEmailUpdate.Name = "lblPEmailUpdate";
            this.lblPEmailUpdate.Size = new System.Drawing.Size(56, 23);
            this.lblPEmailUpdate.TabIndex = 16;
            this.lblPEmailUpdate.Text = "Email:";
            // 
            // txtPSurnameUpdate
            // 
            this.txtPSurnameUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPSurnameUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPSurnameUpdate.Location = new System.Drawing.Point(438, 127);
            this.txtPSurnameUpdate.Name = "txtPSurnameUpdate";
            this.txtPSurnameUpdate.Size = new System.Drawing.Size(238, 27);
            this.txtPSurnameUpdate.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnCancel.FlatAppearance.BorderSize = 10;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(501, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 50);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPContactNumberUpdate
            // 
            this.txtPContactNumberUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPContactNumberUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPContactNumberUpdate.Location = new System.Drawing.Point(438, 179);
            this.txtPContactNumberUpdate.Name = "txtPContactNumberUpdate";
            this.txtPContactNumberUpdate.Size = new System.Drawing.Size(238, 27);
            this.txtPContactNumberUpdate.TabIndex = 12;
            // 
            // lblPURLUpdate
            // 
            this.lblPURLUpdate.AutoSize = true;
            this.lblPURLUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPURLUpdate.Location = new System.Drawing.Point(30, 283);
            this.lblPURLUpdate.Name = "lblPURLUpdate";
            this.lblPURLUpdate.Size = new System.Drawing.Size(115, 23);
            this.lblPURLUpdate.TabIndex = 17;
            this.lblPURLUpdate.Text = "Website URL: ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnUpdate.FlatAppearance.BorderSize = 10;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(34, 387);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(175, 50);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxProfessionUpdate
            // 
            this.cbxProfessionUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxProfessionUpdate.FormattingEnabled = true;
            this.cbxProfessionUpdate.Items.AddRange(new object[] {
            "test"});
            this.cbxProfessionUpdate.Location = new System.Drawing.Point(438, 335);
            this.cbxProfessionUpdate.Name = "cbxProfessionUpdate";
            this.cbxProfessionUpdate.Size = new System.Drawing.Size(238, 27);
            this.cbxProfessionUpdate.TabIndex = 15;
            this.cbxProfessionUpdate.DropDown += new System.EventHandler(this.cbxProfessionUpdate_DropDown);
            // 
            // lblPNameUpdate
            // 
            this.lblPNameUpdate.AutoSize = true;
            this.lblPNameUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPNameUpdate.Location = new System.Drawing.Point(31, 75);
            this.lblPNameUpdate.Name = "lblPNameUpdate";
            this.lblPNameUpdate.Size = new System.Drawing.Size(60, 23);
            this.lblPNameUpdate.TabIndex = 1;
            this.lblPNameUpdate.Text = "Name:";
            // 
            // txtPEmailUpdate
            // 
            this.txtPEmailUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPEmailUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPEmailUpdate.Location = new System.Drawing.Point(438, 231);
            this.txtPEmailUpdate.Name = "txtPEmailUpdate";
            this.txtPEmailUpdate.Size = new System.Drawing.Size(238, 27);
            this.txtPEmailUpdate.TabIndex = 13;
            // 
            // lblPSurnameUpdate
            // 
            this.lblPSurnameUpdate.AutoSize = true;
            this.lblPSurnameUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPSurnameUpdate.Location = new System.Drawing.Point(31, 127);
            this.lblPSurnameUpdate.Name = "lblPSurnameUpdate";
            this.lblPSurnameUpdate.Size = new System.Drawing.Size(84, 23);
            this.lblPSurnameUpdate.TabIndex = 14;
            this.lblPSurnameUpdate.Text = "Surname:";
            // 
            // lblPProfessionUpdate
            // 
            this.lblPProfessionUpdate.AutoSize = true;
            this.lblPProfessionUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPProfessionUpdate.Location = new System.Drawing.Point(31, 335);
            this.lblPProfessionUpdate.Name = "lblPProfessionUpdate";
            this.lblPProfessionUpdate.Size = new System.Drawing.Size(97, 23);
            this.lblPProfessionUpdate.TabIndex = 19;
            this.lblPProfessionUpdate.Text = "Profession:";
            // 
            // cbxPartnerUpdate
            // 
            this.cbxPartnerUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxPartnerUpdate.FormattingEnabled = true;
            this.cbxPartnerUpdate.Items.AddRange(new object[] {
            "test"});
            this.cbxPartnerUpdate.Location = new System.Drawing.Point(438, 23);
            this.cbxPartnerUpdate.Name = "cbxPartnerUpdate";
            this.cbxPartnerUpdate.Size = new System.Drawing.Size(238, 27);
            this.cbxPartnerUpdate.TabIndex = 9;
            this.cbxPartnerUpdate.DropDown += new System.EventHandler(this.cbxPartnerUpdate_DropDown);
            this.cbxPartnerUpdate.SelectedIndexChanged += new System.EventHandler(this.cbxPartner_SelectedIndexChanged);
            // 
            // txtPURLUpdate
            // 
            this.txtPURLUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPURLUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPURLUpdate.Location = new System.Drawing.Point(438, 283);
            this.txtPURLUpdate.Name = "txtPURLUpdate";
            this.txtPURLUpdate.Size = new System.Drawing.Size(238, 27);
            this.txtPURLUpdate.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.cbxAddPartnerProfession);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtPartnerContactNumber);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtPartnerSurname);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.txtPartnerEmail);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPartnerName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtPartnerWebsite);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Partner";
            // 
            // cbxAddPartnerProfession
            // 
            this.cbxAddPartnerProfession.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxAddPartnerProfession.FormattingEnabled = true;
            this.cbxAddPartnerProfession.Items.AddRange(new object[] {
            "test"});
            this.cbxAddPartnerProfession.Location = new System.Drawing.Point(438, 328);
            this.cbxAddPartnerProfession.Name = "cbxAddPartnerProfession";
            this.cbxAddPartnerProfession.Size = new System.Drawing.Size(238, 27);
            this.cbxAddPartnerProfession.TabIndex = 6;
            this.cbxAddPartnerProfession.DropDown += new System.EventHandler(this.cbxAddPartnerProfession_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact Number:";
            // 
            // txtPartnerContactNumber
            // 
            this.txtPartnerContactNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPartnerContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartnerContactNumber.Location = new System.Drawing.Point(438, 145);
            this.txtPartnerContactNumber.Name = "txtPartnerContactNumber";
            this.txtPartnerContactNumber.Size = new System.Drawing.Size(238, 27);
            this.txtPartnerContactNumber.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // txtPartnerSurname
            // 
            this.txtPartnerSurname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPartnerSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartnerSurname.Location = new System.Drawing.Point(438, 84);
            this.txtPartnerSurname.Name = "txtPartnerSurname";
            this.txtPartnerSurname.Size = new System.Drawing.Size(238, 27);
            this.txtPartnerSurname.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnExit.FlatAppearance.BorderSize = 10;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(501, 387);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 50);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "CANCEL";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPartnerEmail
            // 
            this.txtPartnerEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPartnerEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartnerEmail.Location = new System.Drawing.Point(436, 206);
            this.txtPartnerEmail.Name = "txtPartnerEmail";
            this.txtPartnerEmail.Size = new System.Drawing.Size(238, 27);
            this.txtPartnerEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Website URL: ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatAppearance.BorderSize = 10;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(34, 387);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(175, 50);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Add Profession:";
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPartnerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartnerName.Location = new System.Drawing.Point(438, 23);
            this.txtPartnerName.Name = "txtPartnerName";
            this.txtPartnerName.Size = new System.Drawing.Size(238, 27);
            this.txtPartnerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Surname:";
            // 
            // txtPartnerWebsite
            // 
            this.txtPartnerWebsite.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPartnerWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartnerWebsite.Location = new System.Drawing.Point(436, 267);
            this.txtPartnerWebsite.Name = "txtPartnerWebsite";
            this.txtPartnerWebsite.Size = new System.Drawing.Size(238, 27);
            this.txtPartnerWebsite.TabIndex = 5;
            // 
            // tabPartners
            // 
            this.tabPartners.Controls.Add(this.tabPage4);
            this.tabPartners.Controls.Add(this.tabPage1);
            this.tabPartners.Controls.Add(this.tabPage2);
            this.tabPartners.Controls.Add(this.tabPage3);
            this.tabPartners.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.tabPartners.Location = new System.Drawing.Point(24, 121);
            this.tabPartners.Name = "tabPartners";
            this.tabPartners.SelectedIndex = 0;
            this.tabPartners.Size = new System.Drawing.Size(700, 496);
            this.tabPartners.TabIndex = 1;
            this.tabPartners.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.btnCancel1);
            this.tabPage4.Controls.Add(this.dgvViewPartners);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.CB_Selected_Partner);
            this.tabPage4.Controls.Add(this.BtnViewEvent);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(692, 464);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "View Partner";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnCancel1
            // 
            this.btnCancel1.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.btnCancel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel1.Location = new System.Drawing.Point(466, 389);
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
            this.dgvViewPartners.Location = new System.Drawing.Point(21, 30);
            this.dgvViewPartners.Name = "dgvViewPartners";
            this.dgvViewPartners.RowHeadersWidth = 51;
            this.dgvViewPartners.Size = new System.Drawing.Size(407, 322);
            this.dgvViewPartners.TabIndex = 13;
            this.dgvViewPartners.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(504, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Select partner: \r\n";
            // 
            // CB_Selected_Partner
            // 
            this.CB_Selected_Partner.FormattingEnabled = true;
            this.CB_Selected_Partner.Items.AddRange(new object[] {
            "test"});
            this.CB_Selected_Partner.Location = new System.Drawing.Point(442, 58);
            this.CB_Selected_Partner.Name = "CB_Selected_Partner";
            this.CB_Selected_Partner.Size = new System.Drawing.Size(234, 27);
            this.CB_Selected_Partner.TabIndex = 1;
            this.CB_Selected_Partner.DropDown += new System.EventHandler(this.CB_Selected_Partner_DropDown);
            // 
            // BtnViewEvent
            // 
            this.BtnViewEvent.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BtnViewEvent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnViewEvent.Location = new System.Drawing.Point(35, 389);
            this.BtnViewEvent.Name = "BtnViewEvent";
            this.BtnViewEvent.Size = new System.Drawing.Size(175, 50);
            this.BtnViewEvent.TabIndex = 2;
            this.BtnViewEvent.Text = "View";
            this.BtnViewEvent.UseVisualStyleBackColor = true;
            this.BtnViewEvent.Click += new System.EventHandler(this.BtnViewEvent_Click);
            // 
            // Partner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 627);
            this.Controls.Add(this.tabPartners);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Partner_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD_Partner_Form";
            this.Load += new System.EventHandler(this.Partner_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPartners.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPartners)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartnerWebsite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPartnerEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartnerContactNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartnerSurname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPartnerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabPartners;
        private System.Windows.Forms.ComboBox cbxPartnerUpdate;
        private System.Windows.Forms.Label lblPNameUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblPSurnameUpdate;
        private System.Windows.Forms.TextBox txtPURLUpdate;
        private System.Windows.Forms.TextBox txtPEmailUpdate;
        private System.Windows.Forms.Label lblPContactNumberUpdate;
        private System.Windows.Forms.TextBox txtPContactNumberUpdate;
        private System.Windows.Forms.Label lblPEmailUpdate;
        private System.Windows.Forms.TextBox txtPSurnameUpdate;
        private System.Windows.Forms.Label lblPURLUpdate;
        private System.Windows.Forms.ComboBox cbxProfessionUpdate;
        private System.Windows.Forms.Label lblPProfessionUpdate;
        private System.Windows.Forms.TextBox txtPNameUpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPDeteteCencel;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ComboBox cbxPSelectDelete;
        private System.Windows.Forms.ComboBox cbxAddPartnerProfession;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.DataGridView dgvViewPartners;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_Selected_Partner;
        private System.Windows.Forms.Button BtnViewEvent;
    }
}