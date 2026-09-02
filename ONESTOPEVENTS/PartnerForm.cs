using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class Partner_Form : Form
    {
        private const string PartnerChoiceQuery = @"
            SELECT Partner_ID,
                   Partner_FirstName + ' ' + Partner_SurName AS PartnerFullName
            FROM PARTNERS
            ORDER BY Partner_FirstName, Partner_SurName;";

        private const string ProfessionChoiceQuery = @"
            SELECT Profession_ID, Partner_Profession
            FROM PARTNER_PROFESSIONS
            ORDER BY Partner_Profession;";

        private bool loadingChoices;

        public Partner_Form()
        {
            InitializeComponent();
        }

        private void Partner_Form_Load(object sender, EventArgs e)
        {
            BtnDelete.Visible = false;
            SetUpdateFieldsVisible(false);
            RefreshAllChoices();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName;
            string surname;
            string phone;
            string email;
            string website;
            int professionId;
            if (!TryReadPartner(txtPartnerName, txtPartnerSurname, txtPartnerContactNumber,
                txtPartnerEmail, txtPartnerWebsite, cbxAddPartnerProfession,
                out firstName, out surname, out phone, out email, out website, out professionId))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    INSERT INTO PARTNERS
                        (Partner_FirstName, Partner_SurName, Partner_ContactNumber,
                         Partner_Email, Partner_Domain, Profession_ID)
                    VALUES
                        (@FirstName, @Surname, @Phone, @Email, @Website, @ProfessionId);",
                    parameters =>
                    {
                        AddPartnerParameters(parameters, firstName, surname, phone, email, website, professionId);
                    });

                ClearAddFields();
                RefreshPartnerChoices();
                MessageBox.Show("Partner added successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("add the partner", ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int partnerId;
            if (!ValidationHelper.TryGetSelectedId(cbxPartnerUpdate, out partnerId))
            {
                ShowSelectionError(cbxPartnerUpdate, "Select a partner to update.");
                return;
            }

            string firstName;
            string surname;
            string phone;
            string email;
            string website;
            int professionId;
            if (!TryReadPartner(txtPNameUpdate, txtPSurnameUpdate, txtPContactNumberUpdate,
                txtPEmailUpdate, txtPURLUpdate, cbxProfessionUpdate,
                out firstName, out surname, out phone, out email, out website, out professionId))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    UPDATE PARTNERS
                    SET Partner_FirstName = @FirstName,
                        Partner_SurName = @Surname,
                        Partner_ContactNumber = @Phone,
                        Partner_Email = @Email,
                        Partner_Domain = @Website,
                        Profession_ID = @ProfessionId
                    WHERE Partner_ID = @PartnerId;",
                    parameters =>
                    {
                        AddPartnerParameters(parameters, firstName, surname, phone, email, website, professionId);
                        Database.AddInt(parameters, "@PartnerId", partnerId);
                    });

                RefreshPartnerChoices();
                SetUpdateFieldsVisible(false);
                MessageBox.Show("Partner updated successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("update the partner", ex);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int partnerId;
            if (!ValidationHelper.TryGetSelectedId(cbxPSelectDelete, out partnerId))
            {
                ShowSelectionError(cbxPSelectDelete, "Select a partner to delete.");
                return;
            }

            try
            {
                int eventCount = Convert.ToInt32(Database.Scalar(@"
                    SELECT COUNT(*) FROM EVENTS WHERE Partner_ID = @PartnerId;",
                    parameters => Database.AddInt(parameters, "@PartnerId", partnerId)));
                if (eventCount > 0)
                {
                    MessageBox.Show("This partner cannot be deleted because existing events reference it.",
                        "Deletion blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Delete the selected partner?", "Confirm deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                Database.Execute("DELETE FROM PARTNERS WHERE Partner_ID = @PartnerId;",
                    parameters => Database.AddInt(parameters, "@PartnerId", partnerId));
                RefreshPartnerChoices();
                BtnDelete.Visible = false;
                MessageBox.Show("Partner deleted successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("delete the partner", ex);
            }
        }

        private void BtnViewEvent_Click(object sender, EventArgs e)
        {
            int partnerId;
            if (!ValidationHelper.TryGetSelectedId(CB_Selected_Partner, out partnerId))
            {
                ShowSelectionError(CB_Selected_Partner, "Select a partner to view.");
                return;
            }

            try
            {
                dgvViewPartners.DataSource = Database.Query(@"
                    SELECT P.Partner_FirstName AS [First name],
                           P.Partner_SurName AS [Surname],
                           P.Partner_ContactNumber AS [Contact number],
                           P.Partner_Email AS [Email],
                           P.Partner_Domain AS [Website],
                           PP.Partner_Profession AS [Profession]
                    FROM PARTNERS AS P
                    INNER JOIN PARTNER_PROFESSIONS AS PP
                        ON P.Profession_ID = PP.Profession_ID
                    WHERE P.Partner_ID = @PartnerId;",
                    parameters => Database.AddInt(parameters, "@PartnerId", partnerId));
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the partner", ex);
            }
        }

        private void cbxPartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingChoices)
            {
                return;
            }

            int partnerId;
            bool selected = ValidationHelper.TryGetSelectedId(cbxPartnerUpdate, out partnerId);
            SetUpdateFieldsVisible(selected);
            if (!selected)
            {
                return;
            }

            try
            {
                DataTable partner = Database.Query(@"
                    SELECT Partner_FirstName, Partner_SurName, Partner_ContactNumber,
                           Partner_Email, Partner_Domain, Profession_ID
                    FROM PARTNERS
                    WHERE Partner_ID = @PartnerId;",
                    parameters => Database.AddInt(parameters, "@PartnerId", partnerId));

                if (partner.Rows.Count == 1)
                {
                    DataRow row = partner.Rows[0];
                    txtPNameUpdate.Text = row.Field<string>("Partner_FirstName");
                    txtPSurnameUpdate.Text = row.Field<string>("Partner_SurName");
                    txtPContactNumberUpdate.Text = row.Field<string>("Partner_ContactNumber");
                    txtPEmailUpdate.Text = row.Field<string>("Partner_Email");
                    txtPURLUpdate.Text = row.Field<string>("Partner_Domain");
                    cbxProfessionUpdate.SelectedValue = row.Field<int>("Profession_ID");
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the selected partner", ex);
            }
        }

        private void cbxPSelectDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            BtnDelete.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(cbxPSelectDelete, out ignored);
        }

        private void RefreshAllChoices()
        {
            RefreshProfessionChoices();
            RefreshPartnerChoices();
        }

        private void RefreshProfessionChoices()
        {
            try
            {
                DataTable professions = Database.Query(ProfessionChoiceQuery);
                loadingChoices = true;
                BindProfession(cbxAddPartnerProfession, professions.Copy());
                BindProfession(cbxProfessionUpdate, professions);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load professions", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private void RefreshPartnerChoices()
        {
            try
            {
                DataTable partners = Database.Query(PartnerChoiceQuery);
                loadingChoices = true;
                BindPartner(cbxPartnerUpdate, partners.Copy());
                BindPartner(cbxPSelectDelete, partners.Copy());
                BindPartner(CB_Selected_Partner, partners);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load partners", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private void RefreshSinglePartnerChoice(ComboBox comboBox)
        {
            RefreshSingleChoice(comboBox, PartnerChoiceQuery, "PartnerFullName", "Partner_ID");
        }

        private void RefreshSingleProfessionChoice(ComboBox comboBox)
        {
            RefreshSingleChoice(comboBox, ProfessionChoiceQuery, "Partner_Profession", "Profession_ID");
        }

        private void RefreshSingleChoice(
            ComboBox comboBox,
            string query,
            string displayMember,
            string valueMember)
        {
            try
            {
                object selectedValue = comboBox.SelectedValue;
                DataTable choices = Database.Query(query);
                loadingChoices = true;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.DataSource = choices;
                comboBox.SelectedIndex = -1;
                if (selectedValue != null)
                {
                    comboBox.SelectedValue = selectedValue;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("refresh choices", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private static void BindPartner(ComboBox comboBox, DataTable data)
        {
            comboBox.DisplayMember = "PartnerFullName";
            comboBox.ValueMember = "Partner_ID";
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static void BindProfession(ComboBox comboBox, DataTable data)
        {
            comboBox.DisplayMember = "Partner_Profession";
            comboBox.ValueMember = "Profession_ID";
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static bool TryReadPartner(
            TextBox firstNameControl,
            TextBox surnameControl,
            TextBox phoneControl,
            TextBox emailControl,
            TextBox websiteControl,
            ComboBox professionControl,
            out string firstName,
            out string surname,
            out string phone,
            out string email,
            out string website,
            out int professionId)
        {
            firstName = firstNameControl.Text.Trim();
            surname = surnameControl.Text.Trim();
            phone = phoneControl.Text.Trim();
            email = emailControl.Text.Trim();
            website = websiteControl.Text.Trim();
            professionId = 0;

            if (!ValidationHelper.IsPersonName(firstName))
            {
                ShowValidationError(firstNameControl, "Enter a valid partner first name.");
                return false;
            }

            firstNameControl.BackColor = Color.White;
            if (!ValidationHelper.IsPersonName(surname))
            {
                ShowValidationError(surnameControl, "Enter a valid partner surname.");
                return false;
            }

            surnameControl.BackColor = Color.White;
            if (!ValidationHelper.IsPhone(phone))
            {
                ShowValidationError(phoneControl, "Enter a 10-digit contact number.");
                return false;
            }

            phoneControl.BackColor = Color.White;
            if (!ValidationHelper.IsEmail(email))
            {
                ShowValidationError(emailControl, "Enter a valid email address.");
                return false;
            }

            emailControl.BackColor = Color.White;
            if (!ValidationHelper.IsWebsite(website))
            {
                ShowValidationError(websiteControl, "Enter a valid website address, such as example.com.");
                return false;
            }

            websiteControl.BackColor = Color.White;
            if (!ValidationHelper.TryGetSelectedId(professionControl, out professionId))
            {
                ShowSelectionError(professionControl, "Select a profession.");
                return false;
            }

            professionControl.BackColor = Color.White;
            return true;
        }

        private static void AddPartnerParameters(
            SqlParameterCollection parameters,
            string firstName,
            string surname,
            string phone,
            string email,
            string website,
            int professionId)
        {
            Database.AddVarChar(parameters, "@FirstName", 50, firstName);
            Database.AddVarChar(parameters, "@Surname", 50, surname);
            Database.AddVarChar(parameters, "@Phone", 15, phone);
            Database.AddVarChar(parameters, "@Email", 100, email);
            Database.AddVarChar(parameters, "@Website", 100, website);
            Database.AddInt(parameters, "@ProfessionId", professionId);
        }

        private void SetUpdateFieldsVisible(bool visible)
        {
            btnUpdate.Visible = visible;
            lblPNameUpdate.Visible = visible;
            lblPSurnameUpdate.Visible = visible;
            lblPContactNumberUpdate.Visible = visible;
            lblPEmailUpdate.Visible = visible;
            lblPURLUpdate.Visible = visible;
            lblPProfessionUpdate.Visible = visible;
            txtPNameUpdate.Visible = visible;
            txtPSurnameUpdate.Visible = visible;
            txtPContactNumberUpdate.Visible = visible;
            txtPEmailUpdate.Visible = visible;
            txtPURLUpdate.Visible = visible;
            cbxProfessionUpdate.Visible = visible;
        }

        private void ClearAddFields()
        {
            txtPartnerName.Clear();
            txtPartnerSurname.Clear();
            txtPartnerContactNumber.Clear();
            txtPartnerEmail.Clear();
            txtPartnerWebsite.Clear();
            cbxAddPartnerProfession.SelectedIndex = -1;
            txtPartnerName.Focus();
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

        private void cbxPartnerUpdate_DropDown(object sender, EventArgs e) { RefreshSinglePartnerChoice(cbxPartnerUpdate); }
        private void cbxPSelectDelete_DropDown(object sender, EventArgs e) { RefreshSinglePartnerChoice(cbxPSelectDelete); }
        private void CB_Selected_Partner_DropDown(object sender, EventArgs e) { RefreshSinglePartnerChoice(CB_Selected_Partner); }
        private void cbxAddPartnerProfession_DropDown(object sender, EventArgs e) { RefreshSingleProfessionChoice(cbxAddPartnerProfession); }
        private void cbxProfessionUpdate_DropDown(object sender, EventArgs e) { RefreshSingleProfessionChoice(cbxProfessionUpdate); }
        private void btnExit_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
        private void btnPDeteteCencel_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel1_Click(object sender, EventArgs e) { Close(); }
    }
}
