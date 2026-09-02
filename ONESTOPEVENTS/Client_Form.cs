using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ONESTOPEVENTS;

namespace Clients_form
{
    public partial class Client_Form : Form
    {
        private const string ClientChoiceQuery = @"
            SELECT Client_ID,
                   Client_FirstName + ' ' + Client_SurName AS ClientFullName
            FROM CLIENTS
            ORDER BY Client_FirstName, Client_SurName;";

        private bool loadingChoices;

        public Client_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDeleteClient.Visible = false;
            SetUpdateFieldsVisible(false);
            RefreshClientChoices();
        }

        private void BAddClient_Click_1(object sender, EventArgs e)
        {
            string firstName;
            string surname;
            string email;
            string phone;
            if (!TryReadClient(TBClient_name, TBClient_Surname, TBClientEmail,
                TBClient_ContactNum, out firstName, out surname, out email, out phone))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    INSERT INTO CLIENTS
                        (Client_FirstName, Client_SurName, Client_ContactNumber, Client_Email)
                    VALUES
                        (@FirstName, @Surname, @Phone, @Email);",
                    parameters =>
                    {
                        Database.AddVarChar(parameters, "@FirstName", 50, firstName);
                        Database.AddVarChar(parameters, "@Surname", 50, surname);
                        Database.AddVarChar(parameters, "@Phone", 10, phone);
                        Database.AddVarChar(parameters, "@Email", 100, email);
                    });

                ClearAddFields();
                RefreshClientChoices();
                MessageBox.Show("Client added successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("add the client", ex);
            }
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            int clientId;
            if (!ValidationHelper.TryGetSelectedId(cbxUpdate_Client, out clientId))
            {
                ShowSelectionError(cbxUpdate_Client, "Select a client to update.");
                return;
            }

            string firstName;
            string surname;
            string email;
            string phone;
            if (!TryReadClient(txtUpdateClient_Name, txtUpdateClient_Surname,
                txtUpdateClient_Email, txtUpdateClient_ContactNumber,
                out firstName, out surname, out email, out phone))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    UPDATE CLIENTS
                    SET Client_FirstName = @FirstName,
                        Client_SurName = @Surname,
                        Client_ContactNumber = @Phone,
                        Client_Email = @Email
                    WHERE Client_ID = @ClientId;",
                    parameters =>
                    {
                        Database.AddVarChar(parameters, "@FirstName", 50, firstName);
                        Database.AddVarChar(parameters, "@Surname", 50, surname);
                        Database.AddVarChar(parameters, "@Phone", 10, phone);
                        Database.AddVarChar(parameters, "@Email", 100, email);
                        Database.AddInt(parameters, "@ClientId", clientId);
                    });

                RefreshClientChoices();
                SetUpdateFieldsVisible(false);
                MessageBox.Show("Client updated successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("update the client", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int clientId;
            if (!ValidationHelper.TryGetSelectedId(cbxDeleteClient, out clientId))
            {
                ShowSelectionError(cbxDeleteClient, "Select a client to delete.");
                return;
            }

            try
            {
                int eventCount = Convert.ToInt32(Database.Scalar(@"
                    SELECT COUNT(*) FROM EVENTS WHERE Client_ID = @ClientId;",
                    parameters => Database.AddInt(parameters, "@ClientId", clientId)));
                if (eventCount > 0)
                {
                    MessageBox.Show("This client cannot be deleted because existing events reference it.",
                        "Deletion blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Delete the selected client?", "Confirm deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                Database.Execute("DELETE FROM CLIENTS WHERE Client_ID = @ClientId;",
                    parameters => Database.AddInt(parameters, "@ClientId", clientId));
                RefreshClientChoices();
                btnDeleteClient.Visible = false;
                MessageBox.Show("Client deleted successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("delete the client", ex);
            }
        }

        private void BtnViewClients_Click(object sender, EventArgs e)
        {
            int clientId;
            if (!ValidationHelper.TryGetSelectedId(CB_Selected_Client, out clientId))
            {
                ShowSelectionError(CB_Selected_Client, "Select a client to view.");
                return;
            }

            try
            {
                dgvViewPartners.DataSource = Database.Query(@"
                    SELECT Client_FirstName AS [First name],
                           Client_SurName AS [Surname],
                           Client_Email AS [Email],
                           Client_ContactNumber AS [Contact number]
                    FROM CLIENTS
                    WHERE Client_ID = @ClientId;",
                    parameters => Database.AddInt(parameters, "@ClientId", clientId));
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the client", ex);
            }
        }

        private void CBDelete_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingChoices)
            {
                return;
            }

            int clientId;
            bool selected = ValidationHelper.TryGetSelectedId(cbxUpdate_Client, out clientId);
            SetUpdateFieldsVisible(selected);
            if (!selected)
            {
                return;
            }

            try
            {
                DataTable client = Database.Query(@"
                    SELECT Client_FirstName, Client_SurName, Client_Email, Client_ContactNumber
                    FROM CLIENTS
                    WHERE Client_ID = @ClientId;",
                    parameters => Database.AddInt(parameters, "@ClientId", clientId));

                if (client.Rows.Count == 1)
                {
                    DataRow row = client.Rows[0];
                    txtUpdateClient_Name.Text = row.Field<string>("Client_FirstName");
                    txtUpdateClient_Surname.Text = row.Field<string>("Client_SurName");
                    txtUpdateClient_Email.Text = row.Field<string>("Client_Email");
                    txtUpdateClient_ContactNumber.Text = row.Field<string>("Client_ContactNumber");
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the selected client", ex);
            }
        }

        private void cbxDeleteClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            btnDeleteClient.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(cbxDeleteClient, out ignored);
        }

        private void cbxUpdate_Client_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(cbxUpdate_Client);
        }

        private void cbxDeleteClient_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(cbxDeleteClient);
        }

        private void CB_Selected_Client_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(CB_Selected_Client);
        }

        private void RefreshClientChoices()
        {
            try
            {
                DataTable clients = Database.Query(ClientChoiceQuery);
                loadingChoices = true;
                BindChoice(cbxUpdate_Client, clients.Copy());
                BindChoice(cbxDeleteClient, clients.Copy());
                BindChoice(CB_Selected_Client, clients);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load clients", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private void RefreshSingleChoice(ComboBox comboBox)
        {
            try
            {
                object selectedValue = comboBox.SelectedValue;
                DataTable clients = Database.Query(ClientChoiceQuery);
                loadingChoices = true;
                BindChoice(comboBox, clients);
                if (selectedValue != null)
                {
                    comboBox.SelectedValue = selectedValue;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("refresh clients", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private static void BindChoice(ComboBox comboBox, DataTable data)
        {
            comboBox.DisplayMember = "ClientFullName";
            comboBox.ValueMember = "Client_ID";
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static bool TryReadClient(
            TextBox firstNameControl,
            TextBox surnameControl,
            TextBox emailControl,
            TextBox phoneControl,
            out string firstName,
            out string surname,
            out string email,
            out string phone)
        {
            firstName = firstNameControl.Text.Trim();
            surname = surnameControl.Text.Trim();
            email = emailControl.Text.Trim();
            phone = phoneControl.Text.Trim();

            if (!ValidationHelper.IsPersonName(firstName))
            {
                ShowValidationError(firstNameControl,
                    "Enter a valid first name (letters, spaces, apostrophes and hyphens only).");
                return false;
            }

            firstNameControl.BackColor = Color.White;
            if (!ValidationHelper.IsPersonName(surname))
            {
                ShowValidationError(surnameControl,
                    "Enter a valid surname (letters, spaces, apostrophes and hyphens only).");
                return false;
            }

            surnameControl.BackColor = Color.White;
            if (!ValidationHelper.IsEmail(email))
            {
                ShowValidationError(emailControl, "Enter a valid email address.");
                return false;
            }

            emailControl.BackColor = Color.White;
            if (!ValidationHelper.IsPhone(phone))
            {
                ShowValidationError(phoneControl, "Enter a 10-digit contact number.");
                return false;
            }

            phoneControl.BackColor = Color.White;
            return true;
        }

        private void SetUpdateFieldsVisible(bool visible)
        {
            btnUpdateClient.Visible = visible;
            label12.Visible = visible;
            label9.Visible = visible;
            label11.Visible = visible;
            label10.Visible = visible;
            txtUpdateClient_Name.Visible = visible;
            txtUpdateClient_Surname.Visible = visible;
            txtUpdateClient_Email.Visible = visible;
            txtUpdateClient_ContactNumber.Visible = visible;
        }

        private void ClearAddFields()
        {
            TBClient_name.Clear();
            TBClient_Surname.Clear();
            TBClientEmail.Clear();
            TBClient_ContactNum.Clear();
            TBClient_name.Focus();
        }

        private static void ShowValidationError(Control control, string message)
        {
            control.BackColor = Color.MistyRose;
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private static void ShowSelectionError(ComboBox comboBox, string message)
        {
            comboBox.BackColor = Color.MistyRose;
            MessageBox.Show(message, "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            comboBox.Focus();
        }

        private static void ShowDatabaseError(string action, Exception exception)
        {
            MessageBox.Show("Unable to " + action + ".\n\n" + exception.Message,
                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BCancel_Click(object sender, EventArgs e) { Close(); }
        private void BCancel2_Click(object sender, EventArgs e) { Close(); }
        private void button1_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel1_Click(object sender, EventArgs e) { Close(); }
    }
}
