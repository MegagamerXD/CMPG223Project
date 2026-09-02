using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ONESTOPEVENTS
{
    public partial class Venue : Form
    {
        //VARIABLES
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;initial catalog=OnestopEvents;trusted_connection=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string vName;
        string vDescription;
        string vAddress;
        decimal vPrice;
        int vSize;
        char vKitchen;
        int vID;


        public Venue()
        {
            InitializeComponent();
        }

        private void Venue_Load(object sender, EventArgs e)
        {
            lblUpdateVenueName.Visible = false;
            lblUpdateVenueDescription.Visible = false;
            lblUpdateVenueAddress.Visible = false;
            lblUpdateVenuePrice.Visible = false;
            lblUpdateVenueSize.Visible = false;
            btnUpdateVenue.Visible = false;
            chbUpdateVenue_HasKitchen.Visible = false;
            txtUpdateVenue_Name.Visible = false;
            rtbUpdateVenue_Address.Visible = false;
            rtbUpdateVenue_Description.Visible = false;
            txtUpdateVenue_Price.Visible = false;
            txtUpdateVenue_Size.Visible = false;
            BtnDeleteVenue.Visible = false;

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Venue_ID, Venue_Name FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxUpdateVenue.DisplayMember = "Venue_Name";
                cbxUpdateVenue.ValueMember = "Venue_ID";
                cbxUpdateVenue.DataSource = dt;
                cbxDeleteVenue.DisplayMember = "Venue_Name";
                cbxDeleteVenue.ValueMember = "Venue_ID";
                cbxDeleteVenue.DataSource = dt;
                CB_Selected_Venues.DisplayMember = "Venue_Name";
                CB_Selected_Venues.ValueMember = "Venue_ID";
                CB_Selected_Venues.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxUpdateVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUpdateVenue.SelectedIndex != -1)
            {
                lblUpdateVenueName.Visible = true;
                lblUpdateVenueDescription.Visible = true;
                lblUpdateVenueAddress.Visible = true;
                lblUpdateVenuePrice.Visible = true;
                chbUpdateVenue_HasKitchen.Visible = true;
                lblUpdateVenueSize.Visible = true;
                btnUpdateVenue.Visible = true;
                txtUpdateVenue_Name.Visible = true;
                rtbADDVENUE_Description.Visible = true;
                rtbUpdateVenue_Description.Visible = true;
                txtUpdateVenue_Price.Visible = true;
                txtUpdateVenue_Size.Visible = true;
                rtbUpdateVenue_Address.Visible = true;
            }
        }

        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            // ADD VENUE VALIDATION
            vName = txtADDVENUE_Name.Text.Trim();
            if (vName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(vName, @"^[a-zA-Z\s]+$"))
            {
                txtADDVENUE_Name.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for venues name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtADDVENUE_Name.BackColor = Color.White;
            }

            vDescription = rtbADDVENUE_Description.Text.Trim();
            if (vDescription.Length == 0 || vDescription.Length > 255)
            {
                rtbADDVENUE_Description.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue description of at least 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                rtbADDVENUE_Description.BackColor = Color.White;
            }

            vAddress = rtbADDVENUE_Address.Text.Trim();
            if (vAddress.Length == 0 || vAddress.Length > 255)
            {
                rtbADDVENUE_Address.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue address of at least 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                rtbADDVENUE_Address.BackColor = Color.White;
            }

            if (!decimal.TryParse(txtADDVENUE_Price.Text, out vPrice) || vPrice <= 0)
            {
                txtADDVENUE_Price.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid price (numbers only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtADDVENUE_Price.BackColor = Color.White;
            }

            if (!int.TryParse(txtADDVENUE_Size.Text, out vSize))
            {
                txtADDVENUE_Size.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue size (numbers only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtADDVENUE_Size.BackColor = Color.White;
            }
            // END OF VALIDATION

            vKitchen = chbHasKitchen.Checked ? 'Y' : 'N';
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO VENUES (Venue_Name, Venue_Description, Venue_Address, Venue_Price, Venue_Size, Venue_HasKitchen) VALUES (@Venue_Name, @Venue_Description, @Venue_Address, @Venue_Price, @Venue_Size, @Venue_HasKitchen)", con);
                cmd.Parameters.AddWithValue("@Venue_Name", vName);
                cmd.Parameters.AddWithValue("@Venue_Description", vDescription);
                cmd.Parameters.AddWithValue("@Venue_Address", vAddress);
                cmd.Parameters.AddWithValue("@Venue_Price", vPrice);
                cmd.Parameters.AddWithValue("@Venue_Size", vSize);
                cmd.Parameters.AddWithValue("@Venue_HasKitchen", vKitchen);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Venue added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxDeleteVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeleteVenue.SelectedIndex != -1)
            {
                BtnDeleteVenue.Visible = true;
            }
        }

        private void btnUpdateVenue_Click(object sender, EventArgs e)
        {
            // UPDATE BUTTON VALIDATION
            vName = txtUpdateVenue_Name.Text.Trim();
            if (vName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(vName, @"^[a-zA-Z\s]+$"))
            {
                txtUpdateVenue_Name.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for venues name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateVenue_Name.BackColor = Color.White;
            }

            vDescription = rtbUpdateVenue_Description.Text.Trim();
            if (vDescription.Length == 0 || vDescription.Length > 255)
            {
                rtbUpdateVenue_Description.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue description of at least 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                rtbUpdateVenue_Description.BackColor = Color.White;
            }

            vAddress = rtbUpdateVenue_Address.Text.Trim();
            if (vAddress.Length == 0 || vAddress.Length > 255)
            {
                rtbUpdateVenue_Address.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue address of at least 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                rtbUpdateVenue_Address.BackColor = Color.White;
            }

            if (!decimal.TryParse(txtUpdateVenue_Price.Text, out vPrice))
            {
                txtUpdateVenue_Price.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid price (numbers only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateVenue_Price.BackColor = Color.White;
            }

            if (!int.TryParse(txtUpdateVenue_Size.Text, out vSize))
            {
                txtUpdateVenue_Size.BackColor = Color.Red;
                MessageBox.Show("Please enter a venue size (numbers only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateVenue_Size.BackColor = Color.White;
            }
            //END OF VALIDATION

            vKitchen = chbUpdateVenue_HasKitchen.Checked ? 'Y' : 'N';
            vID = (int)cbxUpdateVenue.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE VENUES SET Venue_Name = @Venue_Name, Venue_Description = @Venue_Description, Venue_Address = @Venue_Address, Venue_Price = @Venue_Price, Venue_Size = @Venue_Size, Venue_HasKitchen = @Venue_HasKitchen WHERE Venue_ID = @Venue_ID", con);
                cmd.Parameters.AddWithValue("@Venue_Name", vName);
                cmd.Parameters.AddWithValue("@Venue_Description", vDescription);
                cmd.Parameters.AddWithValue("@Venue_Address", vAddress);
                cmd.Parameters.AddWithValue("@Venue_Price", vPrice);
                cmd.Parameters.AddWithValue("@Venue_Size", vSize);
                cmd.Parameters.AddWithValue("@Venue_HasKitchen", vKitchen);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Venue added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteVenue_Click(object sender, EventArgs e)
        {
            vID = (int)cbxDeleteVenue.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM VENUES WHERE Venue_ID = @Venue_ID", con);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Venue deleted successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot delete, there is an event dependant on this venue");
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    try
                    {
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        // Log any exception that occurs while closing the connection
                        MessageBox.Show("Cannot delete, there is an event dependant on this venue");
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPDeteteCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxUpdateVenue_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Venue_ID, Venue_Name FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxUpdateVenue.DisplayMember = "Venue_Name";
                cbxUpdateVenue.ValueMember = "Venue_ID";
                cbxUpdateVenue.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxDeleteVenue_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Venue_ID, Venue_Name FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxDeleteVenue.DisplayMember = "Venue_Name";
                cbxDeleteVenue.ValueMember = "Venue_ID";
                cbxDeleteVenue.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnViewVenues_Click(object sender, EventArgs e)
        {
            vID = (int)CB_Selected_Venues.SelectedValue;
            try
            {
                // Open the connection
                con.Open();

                // Create the SQL command to retrieve the required client information
                cmd = new SqlCommand("SELECT Venue_Name, Venue_HasKitchen, Venue_Size, Venue_Description, Venue_Rating, Venue_Price, Venue_Address FROM VENUES WHERE Venue_ID = @Venue_ID", con);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                // Create a DataAdapter to fill a DataTable with the retrieved data
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // Bind the DataTable to the DataGridView
                dgvViewPartners.DataSource = dt;

                // Close the connection
                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CB_Selected_Venues_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Venue_ID, Venue_Name FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                CB_Selected_Venues.DisplayMember = "Venue_Name";
                CB_Selected_Venues.ValueMember = "Venue_ID";
                CB_Selected_Venues.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
