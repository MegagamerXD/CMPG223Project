using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ONESTOPEVENTS;

namespace Clients_form
{
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }

        //declaration of variables
        SqlConnection con = Database.CreateConnection();
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        string cName;
        string cSurName;
        string cEmail;
        string cContactNumber;
        int cIntNum;
        int cID;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDeleteClient.Visible = false;
            btnUpdateClient.Visible = false;
            label12.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            txtUpdateClient_Name.Visible = false;
            txtUpdateClient_Surname.Visible = false;
            txtUpdateClient_Email.Visible = false;
            txtUpdateClient_ContactNumber.Visible = false;

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxUpdate_Client.DisplayMember = "ClientFullName";
                cbxUpdate_Client.ValueMember = "Client_ID";
                cbxUpdate_Client.DataSource = dt;
                cbxDeleteClient.DisplayMember = "ClientFullName";
                cbxDeleteClient.ValueMember = "Client_ID";
                cbxDeleteClient.DataSource = dt;
                CB_Selected_Client.DisplayMember = "ClientFullName";
                CB_Selected_Client.ValueMember = "Client_ID";
                CB_Selected_Client.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BAddClient_Click_1(object sender, EventArgs e)
        {
            // DATA VALIDATION ADD BUTTON
            cName = TBClient_name.Text.Trim();
            if (cName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(cName, @"^[a-zA-Z\s]+$"))
            {
                TBClient_name.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for Client Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TBClient_name.BackColor = Color.White;
            }

            cSurName = TBClient_Surname.Text.Trim();
            if (cSurName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(cSurName, @"^[a-zA-Z\s]+$"))
            {
                TBClient_Surname.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for Client Surname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TBClient_Surname.BackColor = Color.White;
            }

            cEmail = TBClientEmail.Text.Trim();
            if (string.IsNullOrEmpty(cEmail) || !(cEmail.Contains("@")) || !(cEmail.Contains(".")))
            {
                TBClientEmail.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid email address with an '@' & '.' symbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TBClientEmail.BackColor = Color.White;
            }

            cContactNumber = TBClient_ContactNum.Text.Trim();
            if (cContactNumber.Length != 10 || !cContactNumber.All(char.IsDigit))
            {
                TBClient_ContactNum.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid contact number with 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TBClient_ContactNum.BackColor= Color.White;
                cIntNum = int.Parse(cContactNumber);
            }
            // *END OF ADD BUTTON VALIDATION

            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO CLIENTS (Client_FirstName, Client_SurName, Client_ContactNumber, Client_Email) VALUES (@Client_FirstName, @Client_SurName, @Client_ContactNumber, @Client_Email)", con);
                cmd.Parameters.AddWithValue("@Client_FirstName", cName);
                cmd.Parameters.AddWithValue("@Client_SurName", cSurName);
                cmd.Parameters.AddWithValue("@Client_ContactNumber", cIntNum);
                cmd.Parameters.AddWithValue("@Client_Email", cEmail);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Client added successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            // UPDATE CLIENT BUTTON DATA VALIDATION
            cName = txtUpdateClient_Name.Text.Trim();
            if (cName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(cName, @"^[a-zA-Z\s]+$"))
            {
                txtUpdateClient_Name.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for client name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateClient_Name.BackColor = Color.White;
            }


            cSurName = txtUpdateClient_Surname.Text.Trim();
            if (cSurName.Length == 0 || !System.Text.RegularExpressions.Regex.IsMatch(cSurName, @"^[a-zA-Z\s]+$"))
            {
                txtUpdateClient_Surname.BackColor = Color.Red;
                MessageBox.Show("Please enter a string for client surname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateClient_Surname.BackColor = Color.White;
            }

            cEmail = txtUpdateClient_Email.Text.Trim();
            if (string.IsNullOrEmpty(cEmail) || !(cEmail.Contains("@")) || !(cEmail.Contains(".")))
            {
                txtUpdateClient_Email.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid email address with an '@' & '.' symbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateClient_Email.BackColor = Color.White;
            }

            cContactNumber = txtUpdateClient_ContactNumber.Text.Trim();
            if (cContactNumber.Length != 10 || !cContactNumber.All(char.IsDigit))
            {
                txtUpdateClient_ContactNumber.BackColor = Color.Red;
                MessageBox.Show("Please enter a valid phone number with 10 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtUpdateClient_ContactNumber.BackColor = Color.White;
                cIntNum = int.Parse(cContactNumber);
            }
            //END OF VALIDATION

            cID = (int)cbxUpdate_Client.SelectedValue;
            try
            {
                con.Open();

                // Correct the SQL UPDATE statement
                cmd = new SqlCommand("UPDATE CLIENTS SET Client_FirstName = @Client_FirstName, Client_SurName = @Client_SurName, Client_ContactNumber = @Client_ContactNumber, Client_Email = @Client_Email WHERE Client_ID = @Client_ID", con);

                // Add parameters with values
                cmd.Parameters.AddWithValue("@Client_FirstName", cName);
                cmd.Parameters.AddWithValue("@Client_SurName", cSurName);
                cmd.Parameters.AddWithValue("@Client_ContactNumber", cIntNum);
                cmd.Parameters.AddWithValue("@Client_Email", cEmail);
                cmd.Parameters.AddWithValue("@Client_ID", cID);

                // Execute the query
                cmd.ExecuteNonQuery();

                // Close the connection
                con.Close();

                MessageBox.Show("Client updated successfully");
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

        private void CBDelete_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUpdate_Client.SelectedIndex != -1)
            {
                btnUpdateClient.Visible = true;
                label6.Visible = true;
                label12.Visible = true;
                label9.Visible = true;
                label11.Visible = true;
                label10.Visible = true;
                cbxUpdate_Client.Visible = true;
                txtUpdateClient_Name.Visible = true;
                txtUpdateClient_Surname.Visible = true;
                txtUpdateClient_Email.Visible = true;
                txtUpdateClient_ContactNumber.Visible = true;
            }
        }

        private void BCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cID = (int)cbxDeleteClient.SelectedValue;
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM CLIENTS WHERE Client_ID = @Client_ID", con);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Client deleted successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxDeleteClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeleteClient.SelectedIndex != -1)
            {
                btnDeleteClient.Visible = true;
            }
        }

        private void cbxUpdate_Client_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxUpdate_Client.DisplayMember = "ClientFullName";
                cbxUpdate_Client.ValueMember = "Client_ID";
                cbxUpdate_Client.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxDeleteClient_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                cbxDeleteClient.DisplayMember = "ClientFullName";
                cbxDeleteClient.ValueMember = "Client_ID";
                cbxDeleteClient.DataSource = dt;
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

        private void BtnViewClients_Click(object sender, EventArgs e)
        {
            cID = (int)CB_Selected_Client.SelectedValue;
            try
            {
                // Open the connection
                con.Open();

                // Create the SQL command to retrieve the required client information
                cmd = new SqlCommand("SELECT Client_FirstName, Client_SurName, Client_Email, Client_ContactNumber FROM CLIENTS WHERE Client_ID = @Client_ID", con);
                cmd.Parameters.AddWithValue("@Client_ID", cID);
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

        private void CB_Selected_Client_DropDown(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Client_ID, (Client_FirstName + ' ' + Client_SurName) AS ClientFullName FROM CLIENTS", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // DataTable to the ComboBox
                CB_Selected_Client.DisplayMember = "ClientFullName";
                CB_Selected_Client.ValueMember = "Client_ID";
                CB_Selected_Client.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
