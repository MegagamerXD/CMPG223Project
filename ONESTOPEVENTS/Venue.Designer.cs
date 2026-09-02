namespace ONESTOPEVENTS
{
    partial class Venue
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
            this.tabPartners = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.dgvViewPartners = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_Selected_Venues = new System.Windows.Forms.ComboBox();
            this.BtnViewVenues = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbHasKitchen = new System.Windows.Forms.CheckBox();
            this.rtbADDVENUE_Address = new System.Windows.Forms.RichTextBox();
            this.txtADDVENUE_Size = new System.Windows.Forms.TextBox();
            this.rtbADDVENUE_Description = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtADDVENUE_Price = new System.Windows.Forms.TextBox();
            this.btnAddVenue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtADDVENUE_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbUpdateVenue_HasKitchen = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxUpdateVenue = new System.Windows.Forms.ComboBox();
            this.rtbUpdateVenue_Address = new System.Windows.Forms.RichTextBox();
            this.txtUpdateVenue_Size = new System.Windows.Forms.TextBox();
            this.rtbUpdateVenue_Description = new System.Windows.Forms.RichTextBox();
            this.lblUpdateVenuePrice = new System.Windows.Forms.Label();
            this.lblUpdateVenueAddress = new System.Windows.Forms.Label();
            this.txtUpdateVenue_Price = new System.Windows.Forms.TextBox();
            this.lblUpdateVenueName = new System.Windows.Forms.Label();
            this.lblUpdateVenueSize = new System.Windows.Forms.Label();
            this.txtUpdateVenue_Name = new System.Windows.Forms.TextBox();
            this.lblUpdateVenueDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdateVenue = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxDeleteVenue = new System.Windows.Forms.ComboBox();
            this.btnPDeteteCencel = new System.Windows.Forms.Button();
            this.BtnDeleteVenue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPartners.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPartners)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPartners
            // 
            this.tabPartners.Controls.Add(this.tabPage4);
            this.tabPartners.Controls.Add(this.tabPage1);
            this.tabPartners.Controls.Add(this.tabPage2);
            this.tabPartners.Controls.Add(this.tabPage3);
            this.tabPartners.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.tabPartners.Location = new System.Drawing.Point(25, 121);
            this.tabPartners.Name = "tabPartners";
            this.tabPartners.SelectedIndex = 0;
            this.tabPartners.Size = new System.Drawing.Size(700, 496);
            this.tabPartners.TabIndex = 0;
            this.tabPartners.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.btnCancel1);
            this.tabPage4.Controls.Add(this.dgvViewPartners);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.CB_Selected_Venues);
            this.tabPage4.Controls.Add(this.BtnViewVenues);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(692, 464);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "View Venues";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnCancel1
            // 
            this.btnCancel1.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.btnCancel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel1.Location = new System.Drawing.Point(464, 387);
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
            this.dgvViewPartners.Location = new System.Drawing.Point(19, 28);
            this.dgvViewPartners.Name = "dgvViewPartners";
            this.dgvViewPartners.RowHeadersWidth = 51;
            this.dgvViewPartners.Size = new System.Drawing.Size(407, 322);
            this.dgvViewPartners.TabIndex = 18;
            this.dgvViewPartners.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(502, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Select venue: \r\n";
            // 
            // CB_Selected_Venues
            // 
            this.CB_Selected_Venues.FormattingEnabled = true;
            this.CB_Selected_Venues.Items.AddRange(new object[] {
            "test"});
            this.CB_Selected_Venues.Location = new System.Drawing.Point(440, 56);
            this.CB_Selected_Venues.Name = "CB_Selected_Venues";
            this.CB_Selected_Venues.Size = new System.Drawing.Size(234, 27);
            this.CB_Selected_Venues.TabIndex = 1;
            this.CB_Selected_Venues.DropDown += new System.EventHandler(this.CB_Selected_Venues_DropDown);
            // 
            // BtnViewVenues
            // 
            this.BtnViewVenues.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.BtnViewVenues.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnViewVenues.Location = new System.Drawing.Point(33, 387);
            this.BtnViewVenues.Name = "BtnViewVenues";
            this.BtnViewVenues.Size = new System.Drawing.Size(175, 50);
            this.BtnViewVenues.TabIndex = 2;
            this.BtnViewVenues.Text = "View";
            this.BtnViewVenues.UseVisualStyleBackColor = true;
            this.BtnViewVenues.Click += new System.EventHandler(this.BtnViewVenues_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.chbHasKitchen);
            this.tabPage1.Controls.Add(this.rtbADDVENUE_Address);
            this.tabPage1.Controls.Add(this.txtADDVENUE_Size);
            this.tabPage1.Controls.Add(this.rtbADDVENUE_Description);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.txtADDVENUE_Price);
            this.tabPage1.Controls.Add(this.btnAddVenue);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtADDVENUE_Name);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Venue";
            // 
            // chbHasKitchen
            // 
            this.chbHasKitchen.AutoSize = true;
            this.chbHasKitchen.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHasKitchen.Location = new System.Drawing.Point(34, 332);
            this.chbHasKitchen.Name = "chbHasKitchen";
            this.chbHasKitchen.Size = new System.Drawing.Size(189, 27);
            this.chbHasKitchen.TabIndex = 6;
            this.chbHasKitchen.Text = "Has Kitchen (Yes/No)";
            this.chbHasKitchen.UseVisualStyleBackColor = true;
            // 
            // rtbADDVENUE_Address
            // 
            this.rtbADDVENUE_Address.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbADDVENUE_Address.Location = new System.Drawing.Point(348, 147);
            this.rtbADDVENUE_Address.MaxLength = 255;
            this.rtbADDVENUE_Address.Name = "rtbADDVENUE_Address";
            this.rtbADDVENUE_Address.Size = new System.Drawing.Size(328, 82);
            this.rtbADDVENUE_Address.TabIndex = 3;
            this.rtbADDVENUE_Address.Text = "";
            // 
            // txtADDVENUE_Size
            // 
            this.txtADDVENUE_Size.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtADDVENUE_Size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtADDVENUE_Size.Location = new System.Drawing.Point(438, 293);
            this.txtADDVENUE_Size.Name = "txtADDVENUE_Size";
            this.txtADDVENUE_Size.Size = new System.Drawing.Size(238, 27);
            this.txtADDVENUE_Size.TabIndex = 5;
            // 
            // rtbADDVENUE_Description
            // 
            this.rtbADDVENUE_Description.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbADDVENUE_Description.Location = new System.Drawing.Point(348, 59);
            this.rtbADDVENUE_Description.MaxLength = 255;
            this.rtbADDVENUE_Description.Name = "rtbADDVENUE_Description";
            this.rtbADDVENUE_Description.Size = new System.Drawing.Size(328, 82);
            this.rtbADDVENUE_Description.TabIndex = 2;
            this.rtbADDVENUE_Description.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price per day:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address:";
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
            // txtADDVENUE_Price
            // 
            this.txtADDVENUE_Price.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtADDVENUE_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtADDVENUE_Price.Location = new System.Drawing.Point(438, 254);
            this.txtADDVENUE_Price.Name = "txtADDVENUE_Price";
            this.txtADDVENUE_Price.Size = new System.Drawing.Size(238, 27);
            this.txtADDVENUE_Price.TabIndex = 4;
            // 
            // btnAddVenue
            // 
            this.btnAddVenue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddVenue.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAddVenue.FlatAppearance.BorderSize = 10;
            this.btnAddVenue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVenue.Location = new System.Drawing.Point(34, 387);
            this.btnAddVenue.Name = "btnAddVenue";
            this.btnAddVenue.Size = new System.Drawing.Size(175, 50);
            this.btnAddVenue.TabIndex = 7;
            this.btnAddVenue.Text = "ADD";
            this.btnAddVenue.UseVisualStyleBackColor = false;
            this.btnAddVenue.Click += new System.EventHandler(this.btnAddVenue_Click);
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
            this.label6.Location = new System.Drawing.Point(31, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Venue size (sq m):";
            // 
            // txtADDVENUE_Name
            // 
            this.txtADDVENUE_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtADDVENUE_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtADDVENUE_Name.Location = new System.Drawing.Point(436, 23);
            this.txtADDVENUE_Name.Name = "txtADDVENUE_Name";
            this.txtADDVENUE_Name.Size = new System.Drawing.Size(238, 27);
            this.txtADDVENUE_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Venue description:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.chbUpdateVenue_HasKitchen);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cbxUpdateVenue);
            this.tabPage2.Controls.Add(this.rtbUpdateVenue_Address);
            this.tabPage2.Controls.Add(this.txtUpdateVenue_Size);
            this.tabPage2.Controls.Add(this.rtbUpdateVenue_Description);
            this.tabPage2.Controls.Add(this.lblUpdateVenuePrice);
            this.tabPage2.Controls.Add(this.lblUpdateVenueAddress);
            this.tabPage2.Controls.Add(this.txtUpdateVenue_Price);
            this.tabPage2.Controls.Add(this.lblUpdateVenueName);
            this.tabPage2.Controls.Add(this.lblUpdateVenueSize);
            this.tabPage2.Controls.Add(this.txtUpdateVenue_Name);
            this.tabPage2.Controls.Add(this.lblUpdateVenueDescription);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.btnUpdateVenue);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Update Venue Info";
            // 
            // chbUpdateVenue_HasKitchen
            // 
            this.chbUpdateVenue_HasKitchen.AutoSize = true;
            this.chbUpdateVenue_HasKitchen.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUpdateVenue_HasKitchen.Location = new System.Drawing.Point(34, 331);
            this.chbUpdateVenue_HasKitchen.Name = "chbUpdateVenue_HasKitchen";
            this.chbUpdateVenue_HasKitchen.Size = new System.Drawing.Size(189, 27);
            this.chbUpdateVenue_HasKitchen.TabIndex = 15;
            this.chbUpdateVenue_HasKitchen.Text = "Has Kitchen (Yes/No)";
            this.chbUpdateVenue_HasKitchen.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(30, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(222, 23);
            this.label15.TabIndex = 39;
            this.label15.Text = "Select venue to be updated:";
            // 
            // cbxUpdateVenue
            // 
            this.cbxUpdateVenue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxUpdateVenue.FormattingEnabled = true;
            this.cbxUpdateVenue.Items.AddRange(new object[] {
            "test"});
            this.cbxUpdateVenue.Location = new System.Drawing.Point(438, 23);
            this.cbxUpdateVenue.Name = "cbxUpdateVenue";
            this.cbxUpdateVenue.Size = new System.Drawing.Size(238, 27);
            this.cbxUpdateVenue.TabIndex = 9;
            this.cbxUpdateVenue.DropDown += new System.EventHandler(this.cbxUpdateVenue_DropDown);
            this.cbxUpdateVenue.SelectedIndexChanged += new System.EventHandler(this.cbxUpdateVenue_SelectedIndexChanged);
            // 
            // rtbUpdateVenue_Address
            // 
            this.rtbUpdateVenue_Address.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbUpdateVenue_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbUpdateVenue_Address.Location = new System.Drawing.Point(348, 177);
            this.rtbUpdateVenue_Address.MaxLength = 255;
            this.rtbUpdateVenue_Address.Name = "rtbUpdateVenue_Address";
            this.rtbUpdateVenue_Address.Size = new System.Drawing.Size(328, 82);
            this.rtbUpdateVenue_Address.TabIndex = 12;
            this.rtbUpdateVenue_Address.Text = "";
            // 
            // txtUpdateVenue_Size
            // 
            this.txtUpdateVenue_Size.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateVenue_Size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateVenue_Size.Location = new System.Drawing.Point(438, 298);
            this.txtUpdateVenue_Size.Name = "txtUpdateVenue_Size";
            this.txtUpdateVenue_Size.Size = new System.Drawing.Size(238, 27);
            this.txtUpdateVenue_Size.TabIndex = 14;
            // 
            // rtbUpdateVenue_Description
            // 
            this.rtbUpdateVenue_Description.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbUpdateVenue_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbUpdateVenue_Description.Location = new System.Drawing.Point(348, 89);
            this.rtbUpdateVenue_Description.MaxLength = 255;
            this.rtbUpdateVenue_Description.Name = "rtbUpdateVenue_Description";
            this.rtbUpdateVenue_Description.Size = new System.Drawing.Size(328, 82);
            this.rtbUpdateVenue_Description.TabIndex = 11;
            this.rtbUpdateVenue_Description.Text = "";
            // 
            // lblUpdateVenuePrice
            // 
            this.lblUpdateVenuePrice.AutoSize = true;
            this.lblUpdateVenuePrice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateVenuePrice.Location = new System.Drawing.Point(30, 264);
            this.lblUpdateVenuePrice.Name = "lblUpdateVenuePrice";
            this.lblUpdateVenuePrice.Size = new System.Drawing.Size(115, 23);
            this.lblUpdateVenuePrice.TabIndex = 29;
            this.lblUpdateVenuePrice.Text = "Price per day:";
            // 
            // lblUpdateVenueAddress
            // 
            this.lblUpdateVenueAddress.AutoSize = true;
            this.lblUpdateVenueAddress.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateVenueAddress.Location = new System.Drawing.Point(31, 177);
            this.lblUpdateVenueAddress.Name = "lblUpdateVenueAddress";
            this.lblUpdateVenueAddress.Size = new System.Drawing.Size(78, 23);
            this.lblUpdateVenueAddress.TabIndex = 30;
            this.lblUpdateVenueAddress.Text = "Address:";
            // 
            // txtUpdateVenue_Price
            // 
            this.txtUpdateVenue_Price.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateVenue_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateVenue_Price.Location = new System.Drawing.Point(438, 265);
            this.txtUpdateVenue_Price.Name = "txtUpdateVenue_Price";
            this.txtUpdateVenue_Price.Size = new System.Drawing.Size(238, 27);
            this.txtUpdateVenue_Price.TabIndex = 13;
            // 
            // lblUpdateVenueName
            // 
            this.lblUpdateVenueName.AutoSize = true;
            this.lblUpdateVenueName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateVenueName.Location = new System.Drawing.Point(31, 56);
            this.lblUpdateVenueName.Name = "lblUpdateVenueName";
            this.lblUpdateVenueName.Size = new System.Drawing.Size(60, 23);
            this.lblUpdateVenueName.TabIndex = 26;
            this.lblUpdateVenueName.Text = "Name:";
            // 
            // lblUpdateVenueSize
            // 
            this.lblUpdateVenueSize.AutoSize = true;
            this.lblUpdateVenueSize.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateVenueSize.Location = new System.Drawing.Point(30, 297);
            this.lblUpdateVenueSize.Name = "lblUpdateVenueSize";
            this.lblUpdateVenueSize.Size = new System.Drawing.Size(149, 23);
            this.lblUpdateVenueSize.TabIndex = 34;
            this.lblUpdateVenueSize.Text = "Venue size (sq m):";
            // 
            // txtUpdateVenue_Name
            // 
            this.txtUpdateVenue_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUpdateVenue_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateVenue_Name.Location = new System.Drawing.Point(438, 56);
            this.txtUpdateVenue_Name.Name = "txtUpdateVenue_Name";
            this.txtUpdateVenue_Name.Size = new System.Drawing.Size(238, 27);
            this.txtUpdateVenue_Name.TabIndex = 10;
            // 
            // lblUpdateVenueDescription
            // 
            this.lblUpdateVenueDescription.AutoSize = true;
            this.lblUpdateVenueDescription.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateVenueDescription.Location = new System.Drawing.Point(30, 89);
            this.lblUpdateVenueDescription.Name = "lblUpdateVenueDescription";
            this.lblUpdateVenueDescription.Size = new System.Drawing.Size(154, 23);
            this.lblUpdateVenueDescription.TabIndex = 28;
            this.lblUpdateVenueDescription.Text = "Venue description:";
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
            // btnUpdateVenue
            // 
            this.btnUpdateVenue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdateVenue.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnUpdateVenue.FlatAppearance.BorderSize = 10;
            this.btnUpdateVenue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVenue.Location = new System.Drawing.Point(34, 387);
            this.btnUpdateVenue.Name = "btnUpdateVenue";
            this.btnUpdateVenue.Size = new System.Drawing.Size(175, 50);
            this.btnUpdateVenue.TabIndex = 16;
            this.btnUpdateVenue.Text = "UPDATE";
            this.btnUpdateVenue.UseVisualStyleBackColor = false;
            this.btnUpdateVenue.Click += new System.EventHandler(this.btnUpdateVenue_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cbxDeleteVenue);
            this.tabPage3.Controls.Add(this.btnPDeteteCencel);
            this.tabPage3.Controls.Add(this.BtnDeleteVenue);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 464);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete Venue";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 23);
            this.label8.TabIndex = 31;
            this.label8.Text = "Select partner ID you wish to delete:";
            // 
            // cbxDeleteVenue
            // 
            this.cbxDeleteVenue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxDeleteVenue.FormattingEnabled = true;
            this.cbxDeleteVenue.Items.AddRange(new object[] {
            "test"});
            this.cbxDeleteVenue.Location = new System.Drawing.Point(438, 23);
            this.cbxDeleteVenue.Name = "cbxDeleteVenue";
            this.cbxDeleteVenue.Size = new System.Drawing.Size(238, 27);
            this.cbxDeleteVenue.TabIndex = 18;
            this.cbxDeleteVenue.DropDown += new System.EventHandler(this.cbxDeleteVenue_DropDown);
            this.cbxDeleteVenue.SelectedIndexChanged += new System.EventHandler(this.cbxDeleteVenue_SelectedIndexChanged);
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
            // BtnDeleteVenue
            // 
            this.BtnDeleteVenue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDeleteVenue.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BtnDeleteVenue.FlatAppearance.BorderSize = 10;
            this.BtnDeleteVenue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteVenue.Location = new System.Drawing.Point(34, 387);
            this.BtnDeleteVenue.Name = "BtnDeleteVenue";
            this.BtnDeleteVenue.Size = new System.Drawing.Size(175, 50);
            this.BtnDeleteVenue.TabIndex = 19;
            this.BtnDeleteVenue.Text = "DELETE";
            this.BtnDeleteVenue.UseVisualStyleBackColor = false;
            this.BtnDeleteVenue.Click += new System.EventHandler(this.BtnDeleteVenue_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(22, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 100);
            this.panel1.TabIndex = 2;
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
            this.label7.Location = new System.Drawing.Point(233, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 78);
            this.label7.TabIndex = 0;
            this.label7.Text = "Venues";
            // 
            // Venue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 627);
            this.Controls.Add(this.tabPartners);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Venue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venues";
            this.Load += new System.EventHandler(this.Venue_Load);
            this.tabPartners.ResumeLayout(false);
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

        }

        #endregion

        private System.Windows.Forms.TabControl tabPartners;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtADDVENUE_Price;
        private System.Windows.Forms.Button btnAddVenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtADDVENUE_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdateVenue;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxDeleteVenue;
        private System.Windows.Forms.Button btnPDeteteCencel;
        private System.Windows.Forms.Button BtnDeleteVenue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbADDVENUE_Description;
        private System.Windows.Forms.RichTextBox rtbADDVENUE_Address;
        private System.Windows.Forms.TextBox txtADDVENUE_Size;
        private System.Windows.Forms.RichTextBox rtbUpdateVenue_Address;
        private System.Windows.Forms.TextBox txtUpdateVenue_Size;
        private System.Windows.Forms.RichTextBox rtbUpdateVenue_Description;
        private System.Windows.Forms.Label lblUpdateVenuePrice;
        private System.Windows.Forms.Label lblUpdateVenueAddress;
        private System.Windows.Forms.TextBox txtUpdateVenue_Price;
        private System.Windows.Forms.Label lblUpdateVenueName;
        private System.Windows.Forms.Label lblUpdateVenueSize;
        private System.Windows.Forms.Label lblUpdateVenueDescription;
        private System.Windows.Forms.TextBox txtUpdateVenue_Name;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxUpdateVenue;
        private System.Windows.Forms.CheckBox chbHasKitchen;
        private System.Windows.Forms.CheckBox chbUpdateVenue_HasKitchen;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.DataGridView dgvViewPartners;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_Selected_Venues;
        private System.Windows.Forms.Button BtnViewVenues;
    }
}