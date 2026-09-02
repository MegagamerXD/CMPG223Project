using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class Venue : Form
    {
        private const string VenueChoiceQuery = @"
            SELECT Venue_ID, Venue_Name
            FROM VENUES
            ORDER BY Venue_Name;";

        private bool loadingChoices;

        public Venue()
        {
            InitializeComponent();
        }

        private void Venue_Load(object sender, EventArgs e)
        {
            SetUpdateFieldsVisible(false);
            BtnDeleteVenue.Visible = false;
            RefreshVenueChoices();
        }

        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            string name;
            string description;
            string address;
            decimal price;
            int size;
            decimal? rating;
            if (!TryReadVenue(txtADDVENUE_Name, rtbADDVENUE_Description,
                rtbADDVENUE_Address, txtADDVENUE_Price, txtADDVENUE_Size,
                txtADDVENUE_Rating, out name, out description, out address,
                out price, out size, out rating))
            {
                return;
            }

            char hasKitchen = chbHasKitchen.Checked ? 'Y' : 'N';
            try
            {
                Database.Execute(@"
                    INSERT INTO VENUES
                        (Venue_Name, Venue_Description, Venue_Address,
                         Venue_Price, Venue_Size, Venue_HasKitchen, Venue_Rating)
                    VALUES
                        (@Name, @Description, @Address, @Price, @Size, @HasKitchen, @Rating);",
                    parameters =>
                    {
                        AddVenueParameters(parameters, name, description, address,
                            price, size, hasKitchen, rating);
                    });

                ClearAddFields();
                RefreshVenueChoices();
                MessageBox.Show("Venue added successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("add the venue", ex);
            }
        }

        private void btnUpdateVenue_Click(object sender, EventArgs e)
        {
            int venueId;
            if (!ValidationHelper.TryGetSelectedId(cbxUpdateVenue, out venueId))
            {
                ShowSelectionError(cbxUpdateVenue, "Select a venue to update.");
                return;
            }

            string name;
            string description;
            string address;
            decimal price;
            int size;
            decimal? rating;
            if (!TryReadVenue(txtUpdateVenue_Name, rtbUpdateVenue_Description,
                rtbUpdateVenue_Address, txtUpdateVenue_Price, txtUpdateVenue_Size,
                txtUpdateVenue_Rating, out name, out description, out address,
                out price, out size, out rating))
            {
                return;
            }

            char hasKitchen = chbUpdateVenue_HasKitchen.Checked ? 'Y' : 'N';
            try
            {
                Database.Execute(@"
                    UPDATE VENUES
                    SET Venue_Name = @Name,
                        Venue_Description = @Description,
                        Venue_Address = @Address,
                        Venue_Price = @Price,
                        Venue_Size = @Size,
                        Venue_HasKitchen = @HasKitchen,
                        Venue_Rating = @Rating
                    WHERE Venue_ID = @VenueId;",
                    parameters =>
                    {
                        AddVenueParameters(parameters, name, description, address,
                            price, size, hasKitchen, rating);
                        Database.AddInt(parameters, "@VenueId", venueId);
                    });

                RefreshVenueChoices();
                SetUpdateFieldsVisible(false);
                MessageBox.Show("Venue updated successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("update the venue", ex);
            }
        }

        private void BtnDeleteVenue_Click(object sender, EventArgs e)
        {
            int venueId;
            if (!ValidationHelper.TryGetSelectedId(cbxDeleteVenue, out venueId))
            {
                ShowSelectionError(cbxDeleteVenue, "Select a venue to delete.");
                return;
            }

            try
            {
                int eventCount = Convert.ToInt32(Database.Scalar(@"
                    SELECT COUNT(*) FROM EVENTS WHERE Venue_ID = @VenueId;",
                    parameters => Database.AddInt(parameters, "@VenueId", venueId)));
                if (eventCount > 0)
                {
                    MessageBox.Show("This venue cannot be deleted because existing events reference it.",
                        "Deletion blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Delete the selected venue?", "Confirm deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                Database.Execute("DELETE FROM VENUES WHERE Venue_ID = @VenueId;",
                    parameters => Database.AddInt(parameters, "@VenueId", venueId));
                RefreshVenueChoices();
                BtnDeleteVenue.Visible = false;
                MessageBox.Show("Venue deleted successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("delete the venue", ex);
            }
        }

        private void BtnViewVenues_Click(object sender, EventArgs e)
        {
            int venueId;
            if (!ValidationHelper.TryGetSelectedId(CB_Selected_Venues, out venueId))
            {
                ShowSelectionError(CB_Selected_Venues, "Select a venue to view.");
                return;
            }

            try
            {
                dgvViewPartners.DataSource = Database.Query(@"
                    SELECT Venue_Name AS [Venue],
                           Venue_HasKitchen AS [Kitchen],
                           Venue_Size AS [Size (sq m)],
                           Venue_Description AS [Description],
                           Venue_Rating AS [Rating],
                           Venue_Price AS [Daily price],
                           Venue_Address AS [Address]
                    FROM VENUES
                    WHERE Venue_ID = @VenueId;",
                    parameters => Database.AddInt(parameters, "@VenueId", venueId));
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the venue", ex);
            }
        }

        private void cbxUpdateVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingChoices)
            {
                return;
            }

            int venueId;
            bool selected = ValidationHelper.TryGetSelectedId(cbxUpdateVenue, out venueId);
            SetUpdateFieldsVisible(selected);
            if (!selected)
            {
                return;
            }

            try
            {
                DataTable venue = Database.Query(@"
                    SELECT Venue_Name, Venue_HasKitchen, Venue_Size,
                           Venue_Description, Venue_Rating, Venue_Price, Venue_Address
                    FROM VENUES
                    WHERE Venue_ID = @VenueId;",
                    parameters => Database.AddInt(parameters, "@VenueId", venueId));

                if (venue.Rows.Count == 1)
                {
                    DataRow row = venue.Rows[0];
                    txtUpdateVenue_Name.Text = row.Field<string>("Venue_Name");
                    rtbUpdateVenue_Description.Text = row.Field<string>("Venue_Description");
                    rtbUpdateVenue_Address.Text = row.Field<string>("Venue_Address");
                    txtUpdateVenue_Price.Text = row.Field<decimal>("Venue_Price").ToString("0.00");
                    txtUpdateVenue_Size.Text = row.Field<int>("Venue_Size").ToString();
                    txtUpdateVenue_Rating.Text = row.IsNull("Venue_Rating")
                        ? string.Empty
                        : row.Field<decimal>("Venue_Rating").ToString("0.##");
                    chbUpdateVenue_HasKitchen.Checked =
                        string.Equals(row.Field<string>("Venue_HasKitchen"), "Y",
                            StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the selected venue", ex);
            }
        }

        private void cbxDeleteVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            BtnDeleteVenue.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(cbxDeleteVenue, out ignored);
        }

        private void RefreshVenueChoices()
        {
            try
            {
                DataTable venues = Database.Query(VenueChoiceQuery);
                loadingChoices = true;
                BindVenue(cbxUpdateVenue, venues.Copy());
                BindVenue(cbxDeleteVenue, venues.Copy());
                BindVenue(CB_Selected_Venues, venues);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load venues", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private void RefreshSingleVenueChoice(ComboBox comboBox)
        {
            try
            {
                object selectedValue = comboBox.SelectedValue;
                loadingChoices = true;
                BindVenue(comboBox, Database.Query(VenueChoiceQuery));
                if (selectedValue != null)
                {
                    comboBox.SelectedValue = selectedValue;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("refresh venues", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private static void BindVenue(ComboBox comboBox, DataTable data)
        {
            comboBox.DisplayMember = "Venue_Name";
            comboBox.ValueMember = "Venue_ID";
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static bool TryReadVenue(
            TextBox nameControl,
            RichTextBox descriptionControl,
            RichTextBox addressControl,
            TextBox priceControl,
            TextBox sizeControl,
            TextBox ratingControl,
            out string name,
            out string description,
            out string address,
            out decimal price,
            out int size,
            out decimal? rating)
        {
            name = nameControl.Text.Trim();
            description = descriptionControl.Text.Trim();
            address = addressControl.Text.Trim();
            price = 0;
            size = 0;
            rating = null;

            if (!ValidationHelper.IsTitle(name))
            {
                ShowValidationError(nameControl, "Enter a valid venue name.");
                return false;
            }

            nameControl.BackColor = Color.White;
            if (!ValidationHelper.HasRequiredText(description, 255, 5))
            {
                ShowValidationError(descriptionControl,
                    "Enter a venue description between 5 and 255 characters.");
                return false;
            }

            descriptionControl.BackColor = Color.White;
            if (!ValidationHelper.HasRequiredText(address, 255, 5))
            {
                ShowValidationError(addressControl,
                    "Enter a venue address between 5 and 255 characters.");
                return false;
            }

            addressControl.BackColor = Color.White;
            if (!ValidationHelper.TryReadPositiveMoney(priceControl.Text.Trim(), out price))
            {
                ShowValidationError(priceControl, "Enter a positive daily venue price.");
                return false;
            }

            priceControl.BackColor = Color.White;
            if (!ValidationHelper.TryReadPositiveInt(sizeControl.Text.Trim(), out size))
            {
                ShowValidationError(sizeControl, "Enter a positive venue size in square metres.");
                return false;
            }

            sizeControl.BackColor = Color.White;
            if (!ValidationHelper.TryReadOptionalRating(ratingControl.Text.Trim(), out rating))
            {
                ShowValidationError(ratingControl,
                    "Enter a venue rating from 0 to 10, or leave it blank.");
                return false;
            }

            ratingControl.BackColor = Color.White;
            return true;
        }

        private static void AddVenueParameters(
            SqlParameterCollection parameters,
            string name,
            string description,
            string address,
            decimal price,
            int size,
            char hasKitchen,
            decimal? rating)
        {
            Database.AddVarChar(parameters, "@Name", 50, name);
            Database.AddVarChar(parameters, "@Description", 255, description);
            Database.AddVarChar(parameters, "@Address", 255, address);
            Database.AddMoney(parameters, "@Price", price);
            Database.AddInt(parameters, "@Size", size);
            Database.AddChar(parameters, "@HasKitchen", hasKitchen);
            Database.AddNullableDecimal(parameters, "@Rating", 4, 2, rating);
        }

        private void SetUpdateFieldsVisible(bool visible)
        {
            lblUpdateVenueName.Visible = visible;
            lblUpdateVenueDescription.Visible = visible;
            lblUpdateVenueAddress.Visible = visible;
            lblUpdateVenuePrice.Visible = visible;
            lblUpdateVenueSize.Visible = visible;
            lblUpdateVenueRating.Visible = visible;
            btnUpdateVenue.Visible = visible;
            chbUpdateVenue_HasKitchen.Visible = visible;
            txtUpdateVenue_Name.Visible = visible;
            rtbUpdateVenue_Address.Visible = visible;
            rtbUpdateVenue_Description.Visible = visible;
            txtUpdateVenue_Price.Visible = visible;
            txtUpdateVenue_Size.Visible = visible;
            txtUpdateVenue_Rating.Visible = visible;
        }

        private void ClearAddFields()
        {
            txtADDVENUE_Name.Clear();
            rtbADDVENUE_Description.Clear();
            rtbADDVENUE_Address.Clear();
            txtADDVENUE_Price.Clear();
            txtADDVENUE_Size.Clear();
            txtADDVENUE_Rating.Clear();
            chbHasKitchen.Checked = false;
            txtADDVENUE_Name.Focus();
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

        private void cbxUpdateVenue_DropDown(object sender, EventArgs e) { RefreshSingleVenueChoice(cbxUpdateVenue); }
        private void cbxDeleteVenue_DropDown(object sender, EventArgs e) { RefreshSingleVenueChoice(cbxDeleteVenue); }
        private void CB_Selected_Venues_DropDown(object sender, EventArgs e) { RefreshSingleVenueChoice(CB_Selected_Venues); }
        private void btnExit_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel_Click(object sender, EventArgs e) { Close(); }
        private void btnPDeteteCencel_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel1_Click(object sender, EventArgs e) { Close(); }
    }
}
