using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using ONESTOPEVENTS;
using System.Reflection;


namespace Events_Form
{
    public partial class EventForm : Form
    {
        public EventForm()
        {
            InitializeComponent();
        }

        // Initialise variables
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;initial catalog=OnestopEvents;trusted_connection=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string eDescription;
        string eName;
        int eID;
        int vID;
        int cID;
        int pID;
        decimal vRating;
        decimal vPrice;
        decimal pCost;
        decimal ePrice;
        decimal BaseFee = 10000.00M;
        DateTime eDate;

        private void Events_Form_Load(object sender, EventArgs e)
        {
            BtnViewEvent.Visible = false;
            lblDispCost.Visible = false;
            btnBookEvent.Visible = false;
            btnUpdateEvent.Visible = false;
            btnDelete.Visible = false;
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;
                cbxDeleteEvent.DisplayMember = "Event_Name";
                cbxDeleteEvent.ValueMember = "Event_ID";
                cbxDeleteEvent.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, (Venue_Name + ' (R ' + CAST(Venue_Price AS VARCHAR) + ')') AS Venue FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;
 

                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT P.Partner_ID, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS PartnerFullName FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Partner_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Partner_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnViewEvent_Click(object sender, EventArgs e)
        {
            // VALIDATION FOR VIEW EVENT
            if (CB_Selected_Event.SelectedIndex == -1)
            {
                CB_Selected_Event.BackColor = Color.Red;
                MessageBox.Show("Please select an event to view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CB_Selected_Event.BackColor = Color.White;
            }
            //END OF VALIDATION

            dgvViewPartner.DataSource = null;
            eID = (int)CB_Selected_Event.SelectedValue;
            try
            {
                // Open the connection
                con.Open();

                // Create the SQL command to retrieve data from the EVENTS table
                cmd = new SqlCommand("SELECT E.Event_Name, V.Venue_Name, (C.Client_FirstName + ' ' + C.Client_SurName) AS Clients_FullName, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS Partners_FullName, E.Event_Date, E.Event_Description, E.Event_Cost FROM EVENTS E INNER JOIN VENUES V ON E.Venue_ID = V.Venue_ID INNER JOIN CLIENTS C ON E.Client_ID = C.Client_ID INNER JOIN PARTNERS P ON E.Partner_ID = P.Partner_ID INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID WHERE E.Event_ID = @Event_ID", con);
                cmd.Parameters.AddWithValue("@Event_ID", eID);

                // Create a DataAdapter to fill a DataSet with the retrieved data
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // Set the DataGridView's DataSource to the DataTable in the DataSet
                dgvViewPartner.DataSource = dt;

                // Close the connection
                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                con.Close();
            }
        }

        private void btnBookEvent_Click(object sender, EventArgs e)
        {
            // VALIDATION TO BOOK EVENTS
            // Validate Venue Selection
            if (cbxAddEventVenue.SelectedIndex == -1)
            {
                cbxAddEventVenue.BackColor = Color.Red;
                MessageBox.Show("Please select a venue for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxAddEventVenue.BackColor = Color.White;
            }

            //Ensure Client and Partner are selected
            if (cbxClientSelectedBook.SelectedIndex == -1 || cbxPartnerSelectedBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client and a partner for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Validate Event name
            eName = txbEventNameBook.Text.Trim();
            if (eName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(eName, @"^[a-zA-Z\s]+$"))
            {
                txbEventNameBook.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventNameBook.BackColor = Color.White;
            }

            // Validate Event Description
            eDescription = RTBEventDescription.Text.Trim();
            if (eDescription.Length == 0 || eDescription.Length > 255)
            {
                RTBEventDescription.BackColor = Color.Red;
                MessageBox.Show("Please provide a description for the event. No longer than 255 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RTBEventDescription.BackColor = Color.White;
            }

            // Validate Event Date
            /*
            if (!DateTime.TryParse(monthCalendar1.DateSelected, out eDate))
            {
                monthCalendar1.BackColor = Color.Red;
                MessageBox.Show("Please select a valid date for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                monthCalendar1.BackColor = Color.White;
            }*/

            DateTime eDate = monthCalendar1.SelectionStart;
            // END OF VALIDATION

            vID = (int)cbxAddEventVenue.SelectedValue;
            pID = (int)cbxPartnerSelectedBook.SelectedValue;
            cID = (int)cbxClientSelectedBook.SelectedValue;

            // Cost Calculation
            try
            {
                // Open the connection
                con.Open();

                // Query to fetch Venue_Rating and Venue_Price based on selected Venue_ID
                cmd = new SqlCommand("SELECT Venue_Rating, Venue_Price FROM VENUES WHERE Venue_ID = @Venue_ID", con);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //vRating = reader.GetDecimal(reader.GetOrdinal("Venue_Rating"));
                        vPrice = reader.GetDecimal(reader.GetOrdinal("Venue_Price"));
                    }
                }

                // Query to fetch Partner_Cost based on selected Partner_ID
                cmd = new SqlCommand("SELECT PP.Partner_Cost FROM PARTNER_PROFESSIONS PP INNER JOIN PARTNERS P ON PP.Profession_ID = P.Profession_ID WHERE P.Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pCost = reader.GetDecimal(reader.GetOrdinal("Partner_Cost"));
                    }
                }

                ePrice = (BaseFee + pCost + vPrice) * 1.15M;
                lblDispCost.Text = ePrice.ToString("C");
                lblDispCost.Visible = true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                con.Close();
            }

            // Read into database
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO EVENTS (Event_Name, Venue_ID, Client_ID, Partner_ID, Event_Date, Event_Description, Event_Cost) VALUES (@Event_Name, @Venue_ID, @Client_ID, @Partner_ID, @Event_Date, @Event_Description, @Event_Cost)", con);
                cmd.Parameters.AddWithValue("@Event_Name", eName);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.Parameters.AddWithValue("@Event_Date", eDate);
                cmd.Parameters.AddWithValue("@Event_Description", eDescription);
                cmd.Parameters.AddWithValue("@Event_Cost", ePrice);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Event booked successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            // MODIFY BUTTON VALIDATION
            if (cbxUpdateEvent.SelectedIndex == -1)
            {
                cbxUpdateEvent.BackColor = Color.Red;
                MessageBox.Show("Please select an event to be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxUpdateEvent.BackColor = Color.White;
            }

            if (cbxUpdateEvent_Venue.SelectedIndex == -1)
            {
                cbxUpdateEvent_Venue.BackColor = Color.Red;
                MessageBox.Show("Please select an venue to be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxUpdateEvent_Venue.BackColor = Color.White;
            }

            eDescription = richTextBox2.Text.Trim();
            if (eDescription.Length == 0 || eDescription.Length > 255)
            {
                richTextBox2.BackColor = Color.Red;
                MessageBox.Show("Please give an updated description of your event. No longer than 255 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                richTextBox2.BackColor = Color.White;
            }

            DateTime eDate = monthCalendar2.SelectionStart;

            eName = txbEventNameUpdate.Text.Trim();
            if (eName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(eName, @"^[a-zA-Z\s]+$"))
            {
                txbEventNameUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txbEventNameUpdate.BackColor = Color.White;
            }
            // END OF VALIIDATION

            eID = (int)cbxUpdateEvent.SelectedValue;
            vID = (int)cbxUpdateEvent_Venue.SelectedValue;
            pID = (int)cbxPartnerSelectedUpdate.SelectedValue;
            cID = (int)cbxClientSelectedUpdate.SelectedValue;

            // Cost Calculation
            try
            {
                // Open the connection
                con.Open();

                // Query to fetch Venue_Rating and Venue_Price based on selected Venue_ID
                cmd = new SqlCommand("SELECT Venue_Rating, Venue_Price FROM VENUES WHERE Venue_ID = @Venue_ID", con);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //vRating = reader.GetDecimal(reader.GetOrdinal("Venue_Rating"));
                        vPrice = reader.GetDecimal(reader.GetOrdinal("Venue_Price"));
                    }
                }

                // Query to fetch Partner_Cost based on selected Partner_ID
                cmd = new SqlCommand("SELECT PP.Partner_Cost FROM PARTNER_PROFESSIONS PP INNER JOIN PARTNERS P ON PP.Profession_ID = P.Profession_ID WHERE P.Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pCost = reader.GetDecimal(reader.GetOrdinal("Partner_Cost"));
                    }
                }

                ePrice = (BaseFee + pCost + vPrice) * 1.15M;
                LBLDisp2.Text = ePrice.ToString("C");
                LBLDisp2.Visible = true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                con.Close();
            }

            // Read into database
            try
            {
                con.Open();

                cmd = new SqlCommand("UPDATE EVENTS SET Event_Name = @Event_Name, Venue_ID = @Venue_ID, Client_ID = @Client_ID, Partner_ID = @Partner_ID, Event_Date = @Event_Date, Event_Description = @Event_Description, Event_Cost = @Event_Cost WHERE Event_ID = @Event_ID ", con);
                cmd.Parameters.AddWithValue("@Event_Name", eName);
                cmd.Parameters.AddWithValue("@Venue_ID", vID);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.Parameters.AddWithValue("@Event_Date", eDate);
                cmd.Parameters.AddWithValue("@Event_Description", eDescription);
                cmd.Parameters.AddWithValue("@Event_Cost", ePrice);
                cmd.Parameters.AddWithValue("@Event_ID", eID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Event modified successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //######Unhide buttons when certain criteria are met
        private void CB_Selected_Event_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Selected_Event.SelectedIndex != -1)
            {
                BtnViewEvent.Visible = true;
            }
        }

        private void cbxAddEventVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAddEventVenue.SelectedIndex != -1)
            {
                btnBookEvent.Visible = true;
            }
        }

        private void cbxUpdateEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUpdateEvent.SelectedIndex != -1 && cbxUpdateEvent_Venue.SelectedIndex != -1)
            {
                btnUpdateEvent.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeleteEvent.SelectedIndex != -1)
            {
                btnDelete.Visible = true;
            }
        }
        //End of unhiding buttons code######

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CB_Selected_Event_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, (Venue_Name + ' (R ' + CAST(Venue_Price AS VARCHAR) + ')') AS Venue FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;

                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT P.Partner_ID, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS PartnerFullName FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Partner_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Partner_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxAddEventVenue_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, (Venue_Name + ' (R ' + CAST(Venue_Price AS VARCHAR) + ')') AS Venue FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;

                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT P.Partner_ID, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS PartnerFullName FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Partner_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Partner_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxUpdateEvent_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, (Venue_Name + ' (R ' + CAST(Venue_Price AS VARCHAR) + ')') AS Venue FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;

                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT P.Partner_ID, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS PartnerFullName FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Partner_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Partner_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxDeleteEvent_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Event_ID, Event_Name FROM EVENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cbxUpdateEvent.DisplayMember = "Event_Name";
                cbxUpdateEvent.ValueMember = "Event_ID";
                cbxUpdateEvent.DataSource = dt;
                CB_Selected_Event.DisplayMember = "Event_Name";
                CB_Selected_Event.ValueMember = "Event_ID";
                CB_Selected_Event.DataSource = dt;
                cbxDeleteEvent.DisplayMember = "Event_Name";
                cbxDeleteEvent.ValueMember = "Event_ID";
                cbxDeleteEvent.DataSource = dt;

                cmd = new SqlCommand("SELECT Venue_ID, (Venue_Name + ' (R ' + CAST(Venue_Price AS VARCHAR) + ')') AS Venue FROM VENUES", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddEventVenue.DisplayMember = "Venue";
                cbxAddEventVenue.ValueMember = "Venue_ID";
                cbxAddEventVenue.DataSource = dt;
                cbxUpdateEvent_Venue.DisplayMember = "Venue";
                cbxUpdateEvent_Venue.ValueMember = "Venue_ID";
                cbxUpdateEvent_Venue.DataSource = dt;


                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxClientSelectedBook.DisplayMember = "ClientFullName";
                cbxClientSelectedBook.ValueMember = "Client_ID";
                cbxClientSelectedBook.DataSource = dt;
                cbxClientSelectedUpdate.DisplayMember = "ClientFullName";
                cbxClientSelectedUpdate.ValueMember = "Client_ID";
                cbxClientSelectedUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT P.Partner_ID, (P.Partner_FirstName + ' ' + P.Partner_SurName + ' (' + PP.Partner_Profession + ')') AS PartnerFullName FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerSelectedUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedUpdate.ValueMember = "Partner_ID";
                cbxPartnerSelectedUpdate.DataSource = dt;
                cbxPartnerSelectedBook.DisplayMember = "PartnerFullName";
                cbxPartnerSelectedBook.ValueMember = "Partner_ID";
                cbxPartnerSelectedBook.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            eID = (int)cbxDeleteEvent.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM EVENTS WHERE Event_ID = @Event_ID", con);
                cmd.Parameters.AddWithValue("@Event_ID", eID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Event deleted successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
