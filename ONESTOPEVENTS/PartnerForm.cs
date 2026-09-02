using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ONESTOPEVENTS
{
    public partial class Partner_Form : Form
    {
        public Partner_Form()
        {
            InitializeComponent();
        }

        //declaration of variables
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;initial catalog=OnestopEvents;trusted_connection=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string pName;
        string pSurName;
        string pContactNumber;
        string pEmail;
        string pURL;
        int profession;
        int pID;
        int profID;
        int pIntNum;

        private void Partner_Form_Load(object sender, EventArgs e)
        {
            BtnDelete.Visible = false;
            btnUpdate.Visible = false;
            lblPNameUpdate.Visible = false;
            lblPSurnameUpdate.Visible = false;
            lblPContactNumberUpdate.Visible = false;
            lblPEmailUpdate.Visible = false;
            lblPURLUpdate.Visible = false;
            lblPProfessionUpdate.Visible = false;
            txtPNameUpdate.Visible = false;
            txtPContactNumberUpdate.Visible = false;
            txtPEmailUpdate.Visible = false;
            txtPURLUpdate.Visible = false;
            cbxProfessionUpdate.Visible = false;
            txtPSurnameUpdate.Visible = false;

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddPartnerProfession.DisplayMember = "Partner_Profession";
                cbxAddPartnerProfession.ValueMember = "Profession_ID";
                cbxAddPartnerProfession.DataSource = dt;
                cbxProfessionUpdate.DisplayMember = "Partner_Profession";
                cbxProfessionUpdate.ValueMember = "Profession_ID";
                cbxProfessionUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT Partner_ID, (Partner_FirstName + ' ' + Partner_SurName) AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                CB_Selected_Partner.DisplayMember = "PartnerFullName";
                CB_Selected_Partner.ValueMember = "Partner_ID";
                CB_Selected_Partner.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPartnerUpdate.SelectedIndex != -1)
            {
                // Show all fields
                btnUpdate.Visible = true;
                lblPNameUpdate.Visible = true;
                lblPSurnameUpdate.Visible = true;
                lblPContactNumberUpdate.Visible = true;
                lblPEmailUpdate.Visible = true;
                lblPURLUpdate.Visible = true;
                lblPProfessionUpdate.Visible = true;
                txtPNameUpdate.Visible = true;
                txtPContactNumberUpdate.Visible = true;
                txtPEmailUpdate.Visible = true;
                txtPURLUpdate.Visible = true;
                cbxProfessionUpdate.Visible = true;
                txtPSurnameUpdate.Visible = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validate Partner name
            pName = txtPartnerName.Text.Trim();
            if (pName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(pName, @"^[a-zA-Z\s]+$"))
            {
                txtPartnerName.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid partner name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPartnerName.BackColor = Color.White;
            }

            //Validate partner surname
            pSurName = txtPartnerSurname.Text.Trim();
            if (pSurName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(pSurName, @"^[a-zA-Z\s]+$"))
            {
                txtPartnerSurname.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid partner surname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPartnerSurname.BackColor = Color.White;
            }

            //Validate phone number
            pContactNumber = txtPartnerContactNumber.Text.Trim();
            if (pContactNumber.Length != 10 || !pContactNumber.All(char.IsDigit))
            {
                txtPartnerContactNumber.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid phone number with exactly 10 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPartnerContactNumber.BackColor = Color.White;
                pIntNum = int.Parse(pContactNumber);
            }

            //Validate email
            pEmail = txtPartnerEmail.Text.Trim();
            if (string.IsNullOrEmpty(pEmail) || !(pEmail.Contains("@")) || !(pEmail.Contains(".")))
            {
                txtPartnerEmail.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid email address with an '@' & '.' symbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPartnerEmail.BackColor = Color.White;
            }

            //Validate website URL
            pURL = txtPartnerWebsite.Text.Trim();
            if (!pURL.Contains(".") || pURL.Length < 3)
            {
                txtPartnerWebsite.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid website URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPartnerWebsite.BackColor = Color.White;
            }

            // Validate Profession
            profession = cbxAddPartnerProfession.SelectedIndex;
            if (profession == -1)
            {
                cbxAddPartnerProfession.BackColor = Color.Red;
                MessageBox.Show("Please select a profession.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxAddPartnerProfession.BackColor = Color.White;
                profID = (int)cbxAddPartnerProfession.SelectedValue;
            }
            /* ###END OF ADD BUTTON VALIDATION### */

            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO PARTNERS (Partner_FirstName, Partner_SurName, Partner_ContactNumber, Partner_Email, Partner_Domain, Profession_ID) VALUES (@Partner_FirstName, @Partner_SurName, @Partner_ContactNumber, @Partner_Email, @Partner_Domain, @Profession_ID)", con);
                cmd.Parameters.AddWithValue("@Partner_FirstName", pName);
                cmd.Parameters.AddWithValue("@Partner_SurName", pSurName);
                cmd.Parameters.AddWithValue("@Partner_ContactNumber", pIntNum);
                cmd.Parameters.AddWithValue("@Partner_Email", pEmail);
                cmd.Parameters.AddWithValue("@Partner_Domain", pURL);
                cmd.Parameters.AddWithValue("@Profession_ID", profID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Partner added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update Button Validation
            pName = txtPNameUpdate.Text.Trim();
            if (pName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(pName, @"^[a-zA-Z\s]+$"))
            {
                txtPNameUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid partner name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPNameUpdate.BackColor = Color.White;
            }

            //Validate partner surname
            pSurName = txtPSurnameUpdate.Text.Trim();
            if (pSurName.Length <= 1 || !System.Text.RegularExpressions.Regex.IsMatch(pSurName, @"^[a-zA-Z\s]+$"))
            {
                txtPSurnameUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid partner surname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPSurnameUpdate.BackColor = Color.White;
            }

            //Validate phone number
            pContactNumber = txtPContactNumberUpdate.Text.Trim();
            if (pContactNumber.Length != 10 || !pContactNumber.All(char.IsDigit))
            {
                txtPContactNumberUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid phone number with exactly 10 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPContactNumberUpdate.BackColor = Color.White;
                pIntNum = int.Parse(pContactNumber);
            }

            //Validate email
            pEmail = txtPEmailUpdate.Text.Trim();
            if (string.IsNullOrEmpty(pEmail) || !(pEmail.Contains("@")) || !(pEmail.Contains(".")))
            {
                txtPEmailUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid email address with an '@' & '.' symbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPEmailUpdate.BackColor = Color.White;
            }

            //Validate website URL
            pURL = txtPURLUpdate.Text.Trim();
            if (!pURL.Contains(".") || pURL.Length < 3)
            {
                txtPURLUpdate.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid website URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtPURLUpdate.BackColor = Color.White;
            }

            profession = cbxProfessionUpdate.SelectedIndex;
            if (profession == -1)
            {
                cbxProfessionUpdate.BackColor = Color.Red;
                MessageBox.Show("Please select a profession.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cbxProfessionUpdate.BackColor = Color.White;
                profID = (int)cbxProfessionUpdate.SelectedValue;
            }
            // END OF VALIDATION

            pID = (int)cbxPartnerUpdate.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE PARTNERS SET Partner_FirstName = @Partner_FirstName, Partner_SurName = @Partner_SurName, Partner_ContactNumber = @Partner_ContactNumber, Partner_Email = @Partner_Email, Partner_Domain = @Partner_Domain, Profession_ID = @Profession_ID WHERE Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_FirstName", pName);
                cmd.Parameters.AddWithValue("@Partner_SurName", pSurName);
                cmd.Parameters.AddWithValue("@Partner_ContactNumber", pIntNum);
                cmd.Parameters.AddWithValue("@Partner_Email", pEmail);
                cmd.Parameters.AddWithValue("@Partner_Domain", pURL);
                cmd.Parameters.AddWithValue("@Profession_ID", profID);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Partner updated successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPDeteteCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            pID = (int)cbxPSelectDelete.SelectedValue;
            try
            {
                con.Open();

                // Delete dependent records from EVENTS table
                cmd = new SqlCommand("DELETE FROM EVENTS WHERE Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.ExecuteNonQuery();

                // Now delete the partner from PARTNERS table
                cmd = new SqlCommand("DELETE FROM PARTNERS WHERE Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Partner and associated events deleted successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxPSelectDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPSelectDelete.SelectedIndex != -1)
            {
                BtnDelete.Visible = true;
            }
        }

        private void cbxPartnerUpdate_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Partner_ID, Partner_FirstName + ' ' + Partner_SurName AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                CB_Selected_Partner.DisplayMember = "PartnerFullName";
                CB_Selected_Partner.ValueMember = "Partner_ID";
                CB_Selected_Partner.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxPSelectDelete_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Partner_ID, Partner_FirstName + ' ' + Partner_SurName AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                        MessageBox.Show("Error closing connection: " + ex.Message);
                    }
                }
            }
        }

        private void BtnViewEvent_Click(object sender, EventArgs e)
        {
            pID = (int)CB_Selected_Partner.SelectedValue;
            try
            {
                // Open the connection
                con.Open();

                // Create the SQL command to retrieve the required client information
                cmd = new SqlCommand("SELECT P.Partner_FirstName, P.Partner_SurName, P.Partner_Email, P.Partner_ContactNumber, PP.Partner_Profession FROM PARTNERS P INNER JOIN PARTNER_PROFESSIONS PP ON P.Profession_ID = PP.Profession_ID WHERE P.Partner_ID = @Partner_ID", con);
                cmd.Parameters.AddWithValue("@Partner_ID", pID);
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

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CB_Selected_Partner_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Partner_ID, Partner_FirstName + ' ' + Partner_SurName AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                CB_Selected_Partner.DisplayMember = "PartnerFullName";
                CB_Selected_Partner.ValueMember = "Partner_ID";
                CB_Selected_Partner.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxAddPartnerProfession_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddPartnerProfession.DisplayMember = "Partner_Profession";
                cbxAddPartnerProfession.ValueMember = "Profession_ID";
                cbxAddPartnerProfession.DataSource = dt;
                cbxProfessionUpdate.DisplayMember = "Partner_Profession";
                cbxProfessionUpdate.ValueMember = "Profession_ID";
                cbxProfessionUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT Partner_ID, (Partner_FirstName + ' ' + Partner_SurName) AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                CB_Selected_Partner.DisplayMember = "PartnerFullName";
                CB_Selected_Partner.ValueMember = "Partner_ID";
                CB_Selected_Partner.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxProfessionUpdate_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Profession_ID, Partner_Profession FROM PARTNER_PROFESSIONS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxAddPartnerProfession.DisplayMember = "Partner_Profession";
                cbxAddPartnerProfession.ValueMember = "Profession_ID";
                cbxAddPartnerProfession.DataSource = dt;
                cbxProfessionUpdate.DisplayMember = "Partner_Profession";
                cbxProfessionUpdate.ValueMember = "Profession_ID";
                cbxProfessionUpdate.DataSource = dt;

                cmd = new SqlCommand("SELECT Partner_ID, (Partner_FirstName + ' ' + Partner_SurName) AS PartnerFullName FROM PARTNERS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxPartnerUpdate.DisplayMember = "PartnerFullName";
                cbxPartnerUpdate.ValueMember = "Partner_ID";
                cbxPartnerUpdate.DataSource = dt;
                cbxPSelectDelete.DisplayMember = "PartnerFullName";
                cbxPSelectDelete.ValueMember = "Partner_ID";
                cbxPSelectDelete.DataSource = dt;
                CB_Selected_Partner.DisplayMember = "PartnerFullName";
                CB_Selected_Partner.ValueMember = "Partner_ID";
                CB_Selected_Partner.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
