using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class PartnerProfessionForm : Form
    {
        private const string ProfessionChoiceQuery = @"
            SELECT Profession_ID, Partner_Profession
            FROM PARTNER_PROFESSIONS
            ORDER BY Partner_Profession;";

        private bool loadingChoices;

        public PartnerProfessionForm()
        {
            InitializeComponent();
        }

        private void PartnerProfessionForm_Load(object sender, EventArgs e)
        {
            SetUpdateFieldsVisible(false);
            RefreshProfessionChoices();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string professionName;
            decimal professionCost;
            if (!TryReadProfession(txtProfessionName, txtProfessionCost,
                out professionName, out professionCost))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    INSERT INTO PARTNER_PROFESSIONS (Partner_Profession, Partner_Cost)
                    VALUES (@ProfessionName, @ProfessionCost);",
                    parameters =>
                    {
                        Database.AddVarChar(parameters, "@ProfessionName", 150, professionName);
                        Database.AddMoney(parameters, "@ProfessionCost", professionCost);
                    });

                txtProfessionName.Clear();
                txtProfessionCost.Clear();
                RefreshProfessionChoices();
                MessageBox.Show("Profession added successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("add the profession", ex);
            }
        }

        private void btnProfessionUpdate_Click(object sender, EventArgs e)
        {
            int professionId;
            if (!ValidationHelper.TryGetSelectedId(cbxPartnerUpdate, out professionId))
            {
                ShowSelectionError(cbxPartnerUpdate, "Select a profession to update.");
                return;
            }

            string professionName;
            decimal professionCost;
            if (!TryReadProfession(txtProfessionNameUpdate, txtProfessionCostUpdate,
                out professionName, out professionCost))
            {
                return;
            }

            try
            {
                Database.Execute(@"
                    UPDATE PARTNER_PROFESSIONS
                    SET Partner_Profession = @ProfessionName,
                        Partner_Cost = @ProfessionCost
                    WHERE Profession_ID = @ProfessionId;",
                    parameters =>
                    {
                        Database.AddVarChar(parameters, "@ProfessionName", 150, professionName);
                        Database.AddMoney(parameters, "@ProfessionCost", professionCost);
                        Database.AddInt(parameters, "@ProfessionId", professionId);
                    });

                RefreshProfessionChoices();
                SetUpdateFieldsVisible(false);
                MessageBox.Show("Profession updated successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("update the profession", ex);
            }
        }

        private void BtnDeleteProfession_Click(object sender, EventArgs e)
        {
            int professionId;
            if (!ValidationHelper.TryGetSelectedId(cbxProfessionDelete, out professionId))
            {
                ShowSelectionError(cbxProfessionDelete, "Select a profession to delete.");
                return;
            }

            try
            {
                int partnerCount = Convert.ToInt32(Database.Scalar(@"
                    SELECT COUNT(*)
                    FROM PARTNERS
                    WHERE Profession_ID = @ProfessionId;",
                    parameters => Database.AddInt(parameters, "@ProfessionId", professionId)));
                if (partnerCount > 0)
                {
                    MessageBox.Show("This profession cannot be deleted because existing partners reference it.",
                        "Deletion blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Delete the selected profession?", "Confirm deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                Database.Execute(@"
                    DELETE FROM PARTNER_PROFESSIONS
                    WHERE Profession_ID = @ProfessionId;",
                    parameters => Database.AddInt(parameters, "@ProfessionId", professionId));
                RefreshProfessionChoices();
                MessageBox.Show("Profession deleted successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("delete the profession", ex);
            }
        }

        private void BtnViewProfession_Click(object sender, EventArgs e)
        {
            int professionId;
            if (!ValidationHelper.TryGetSelectedId(CB_Selected_Profession, out professionId))
            {
                ShowSelectionError(CB_Selected_Profession, "Select a profession to view.");
                return;
            }

            try
            {
                dgvViewProfessions.DataSource = Database.Query(@"
                    SELECT Partner_Profession AS [Profession],
                           Partner_Cost AS [Daily cost]
                    FROM PARTNER_PROFESSIONS
                    WHERE Profession_ID = @ProfessionId;",
                    parameters => Database.AddInt(parameters, "@ProfessionId", professionId));
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the profession", ex);
            }
        }

        private void cbxPartnerUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingChoices)
            {
                return;
            }

            int professionId;
            bool selected = ValidationHelper.TryGetSelectedId(cbxPartnerUpdate, out professionId);
            SetUpdateFieldsVisible(selected);
            if (!selected)
            {
                return;
            }

            try
            {
                DataTable profession = Database.Query(@"
                    SELECT Partner_Profession, Partner_Cost
                    FROM PARTNER_PROFESSIONS
                    WHERE Profession_ID = @ProfessionId;",
                    parameters => Database.AddInt(parameters, "@ProfessionId", professionId));

                if (profession.Rows.Count == 1)
                {
                    DataRow row = profession.Rows[0];
                    txtProfessionNameUpdate.Text = row.Field<string>("Partner_Profession");
                    txtProfessionCostUpdate.Text = row.Field<decimal>("Partner_Cost").ToString("0.00");
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the selected profession", ex);
            }
        }

        private void RefreshProfessionChoices()
        {
            try
            {
                DataTable professions = Database.Query(ProfessionChoiceQuery);
                loadingChoices = true;
                BindProfession(cbxPartnerUpdate, professions.Copy());
                BindProfession(cbxProfessionDelete, professions.Copy());
                BindProfession(CB_Selected_Profession, professions);
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

        private void RefreshSingleProfessionChoice(ComboBox comboBox)
        {
            try
            {
                object selectedValue = comboBox.SelectedValue;
                loadingChoices = true;
                BindProfession(comboBox, Database.Query(ProfessionChoiceQuery));
                if (selectedValue != null)
                {
                    comboBox.SelectedValue = selectedValue;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("refresh professions", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private static void BindProfession(ComboBox comboBox, DataTable data)
        {
            comboBox.DisplayMember = "Partner_Profession";
            comboBox.ValueMember = "Profession_ID";
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static bool TryReadProfession(
            TextBox nameControl,
            TextBox costControl,
            out string professionName,
            out decimal professionCost)
        {
            professionName = nameControl.Text.Trim();
            professionCost = 0;

            if (!ValidationHelper.IsPersonName(professionName))
            {
                ShowValidationError(nameControl, "Enter a valid profession name.");
                return false;
            }

            nameControl.BackColor = Color.White;
            if (!ValidationHelper.TryReadPositiveMoney(costControl.Text.Trim(), out professionCost))
            {
                ShowValidationError(costControl, "Enter a positive profession cost.");
                return false;
            }

            costControl.BackColor = Color.White;
            return true;
        }

        private void SetUpdateFieldsVisible(bool visible)
        {
            lblProfessionCost.Visible = visible;
            lblProfessionName.Visible = visible;
            btnProfessionUpdate.Visible = visible;
            txtProfessionNameUpdate.Visible = visible;
            txtProfessionCostUpdate.Visible = visible;
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

        private void cbxPartnerUpdate_DropDown(object sender, EventArgs e) { RefreshSingleProfessionChoice(cbxPartnerUpdate); }
        private void cbxProfessionDelete_DropDown(object sender, EventArgs e) { RefreshSingleProfessionChoice(cbxProfessionDelete); }
        private void CB_Selected_Profession_DropDown(object sender, EventArgs e) { RefreshSingleProfessionChoice(CB_Selected_Profession); }
        private void btnExit_Click(object sender, EventArgs e) { Close(); }
        private void button1_Click(object sender, EventArgs e) { Close(); }
        private void btnProfessionDeteteCencel_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel1_Click(object sender, EventArgs e) { Close(); }
    }
}
