using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ONESTOPEVENTS;

namespace Events_Form
{
    public partial class EventForm : Form
    {
        private const decimal BaseFee = 10000.00M;

        private const string EventChoiceQuery = @"
            SELECT Event_ID, Event_Name
            FROM EVENTS
            ORDER BY Event_Date, Event_Name;";

        private const string VenueChoiceQuery = @"
            SELECT Venue_ID,
                   Venue_Name + ' (R ' + CONVERT(VARCHAR(20),
                       CAST(Venue_Price AS DECIMAL(12, 2))) + ')' AS VenueDisplay
            FROM VENUES
            ORDER BY Venue_Name;";

        private const string ClientChoiceQuery = @"
            SELECT Client_ID,
                   Client_FirstName + ' ' + Client_SurName AS ClientFullName
            FROM CLIENTS
            ORDER BY Client_FirstName, Client_SurName;";

        private const string PartnerChoiceQuery = @"
            SELECT P.Partner_ID,
                   P.Partner_FirstName + ' ' + P.Partner_SurName
                       + ' (' + PP.Partner_Profession + ')' AS PartnerFullName
            FROM PARTNERS AS P
            INNER JOIN PARTNER_PROFESSIONS AS PP
                ON P.Profession_ID = PP.Profession_ID
            ORDER BY P.Partner_FirstName, P.Partner_SurName;";

        private bool loadingChoices;

        public EventForm()
        {
            InitializeComponent();
        }

        private void Events_Form_Load(object sender, EventArgs e)
        {
            BtnViewEvent.Visible = false;
            lblDispCost.Visible = false;
            LBLDisp2.Visible = false;
            btnBookEvent.Visible = false;
            btnUpdateEvent.Visible = false;
            btnDelete.Visible = false;
            LoadAllChoices();
        }

        private void BtnViewEvent_Click(object sender, EventArgs e)
        {
            int eventId;
            if (!ValidationHelper.TryGetSelectedId(CB_Selected_Event, out eventId))
            {
                ShowSelectionError(CB_Selected_Event, "Select an event to view.");
                return;
            }

            try
            {
                dgvViewPartner.DataSource = Database.Query(@"
                    SELECT E.Event_Name AS [Event],
                           V.Venue_Name AS [Venue],
                           C.Client_FirstName + ' ' + C.Client_SurName AS [Client],
                           P.Partner_FirstName + ' ' + P.Partner_SurName
                               + ' (' + PP.Partner_Profession + ')' AS [Partner],
                           E.Event_Date AS [Date],
                           E.Event_Description AS [Description],
                           E.Event_Cost AS [Cost]
                    FROM EVENTS AS E
                    INNER JOIN VENUES AS V ON E.Venue_ID = V.Venue_ID
                    INNER JOIN CLIENTS AS C ON E.Client_ID = C.Client_ID
                    INNER JOIN PARTNERS AS P ON E.Partner_ID = P.Partner_ID
                    INNER JOIN PARTNER_PROFESSIONS AS PP
                        ON P.Profession_ID = PP.Profession_ID
                    WHERE E.Event_ID = @EventId;",
                    parameters => Database.AddInt(parameters, "@EventId", eventId));
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the event", ex);
            }
        }

        private void btnBookEvent_Click(object sender, EventArgs e)
        {
            string eventName;
            string description;
            DateTime eventDate;
            int venueId;
            int clientId;
            int partnerId;
            if (!TryReadEvent(txbEventNameBook, RTBEventDescription, monthCalendar1,
                cbxAddEventVenue, cbxClientSelectedBook, cbxPartnerSelectedBook,
                out eventName, out description, out eventDate,
                out venueId, out clientId, out partnerId))
            {
                return;
            }

            decimal eventCost;
            if (!TryCalculateEventCost(venueId, partnerId, out eventCost))
            {
                return;
            }

            lblDispCost.Text = eventCost.ToString("C2");
            lblDispCost.Visible = true;

            try
            {
                Database.Execute(@"
                    INSERT INTO EVENTS
                        (Event_Name, Venue_ID, Client_ID, Partner_ID,
                         Event_Date, Event_Description, Event_Cost)
                    VALUES
                        (@EventName, @VenueId, @ClientId, @PartnerId,
                         @EventDate, @Description, @EventCost);",
                    parameters =>
                    {
                        AddEventParameters(parameters, eventName, description, eventDate,
                            venueId, clientId, partnerId, eventCost);
                    });

                ClearAddFields();
                RefreshEventChoices();
                MessageBox.Show("Event booked successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("book the event", ex);
            }
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            int eventId;
            if (!ValidationHelper.TryGetSelectedId(cbxUpdateEvent, out eventId))
            {
                ShowSelectionError(cbxUpdateEvent, "Select an event to update.");
                return;
            }

            string eventName;
            string description;
            DateTime eventDate;
            int venueId;
            int clientId;
            int partnerId;
            if (!TryReadEvent(txbEventNameUpdate, richTextBox2, monthCalendar2,
                cbxUpdateEvent_Venue, cbxClientSelectedUpdate, cbxPartnerSelectedUpdate,
                out eventName, out description, out eventDate,
                out venueId, out clientId, out partnerId))
            {
                return;
            }

            decimal eventCost;
            if (!TryCalculateEventCost(venueId, partnerId, out eventCost))
            {
                return;
            }

            LBLDisp2.Text = eventCost.ToString("C2");
            LBLDisp2.Visible = true;

            try
            {
                Database.Execute(@"
                    UPDATE EVENTS
                    SET Event_Name = @EventName,
                        Venue_ID = @VenueId,
                        Client_ID = @ClientId,
                        Partner_ID = @PartnerId,
                        Event_Date = @EventDate,
                        Event_Description = @Description,
                        Event_Cost = @EventCost
                    WHERE Event_ID = @EventId;",
                    parameters =>
                    {
                        AddEventParameters(parameters, eventName, description, eventDate,
                            venueId, clientId, partnerId, eventCost);
                        Database.AddInt(parameters, "@EventId", eventId);
                    });

                RefreshEventChoices();
                btnUpdateEvent.Visible = false;
                MessageBox.Show("Event updated successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("update the event", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int eventId;
            if (!ValidationHelper.TryGetSelectedId(cbxDeleteEvent, out eventId))
            {
                ShowSelectionError(cbxDeleteEvent, "Select an event to delete.");
                return;
            }

            try
            {
                Database.Execute("DELETE FROM EVENTS WHERE Event_ID = @EventId;",
                    parameters => Database.AddInt(parameters, "@EventId", eventId));
                RefreshEventChoices();
                btnDelete.Visible = false;
                MessageBox.Show("Event deleted successfully.", "One Stop Events",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("delete the event", ex);
            }
        }

        private bool TryCalculateEventCost(int venueId, int partnerId, out decimal eventCost)
        {
            eventCost = 0;
            try
            {
                object result = Database.Scalar(@"
                    SELECT CAST((@BaseFee + V.Venue_Price + PP.Partner_Cost) * 1.15 AS MONEY)
                    FROM VENUES AS V
                    CROSS JOIN PARTNERS AS P
                    INNER JOIN PARTNER_PROFESSIONS AS PP
                        ON P.Profession_ID = PP.Profession_ID
                    WHERE V.Venue_ID = @VenueId
                      AND P.Partner_ID = @PartnerId;",
                    parameters =>
                    {
                        Database.AddMoney(parameters, "@BaseFee", BaseFee);
                        Database.AddInt(parameters, "@VenueId", venueId);
                        Database.AddInt(parameters, "@PartnerId", partnerId);
                    });

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("The selected venue or partner is no longer available.",
                        "Cost unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                eventCost = Convert.ToDecimal(result);
                return true;
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("calculate the event cost", ex);
                return false;
            }
        }

        private void cbxUpdateEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingChoices)
            {
                return;
            }

            int eventId;
            bool selected = ValidationHelper.TryGetSelectedId(cbxUpdateEvent, out eventId);
            btnUpdateEvent.Visible = selected;
            if (!selected)
            {
                return;
            }

            try
            {
                DataTable selectedEvent = Database.Query(@"
                    SELECT Event_Name, Venue_ID, Client_ID, Partner_ID,
                           Event_Date, Event_Description, Event_Cost
                    FROM EVENTS
                    WHERE Event_ID = @EventId;",
                    parameters => Database.AddInt(parameters, "@EventId", eventId));

                if (selectedEvent.Rows.Count == 1)
                {
                    DataRow row = selectedEvent.Rows[0];
                    txbEventNameUpdate.Text = row.Field<string>("Event_Name");
                    cbxUpdateEvent_Venue.SelectedValue = row.Field<int>("Venue_ID");
                    cbxClientSelectedUpdate.SelectedValue = row.Field<int>("Client_ID");
                    cbxPartnerSelectedUpdate.SelectedValue = row.Field<int>("Partner_ID");
                    monthCalendar2.SetDate(row.Field<DateTime>("Event_Date"));
                    richTextBox2.Text = row.Field<string>("Event_Description");
                    LBLDisp2.Text = row.Field<decimal>("Event_Cost").ToString("C2");
                    LBLDisp2.Visible = true;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load the selected event", ex);
            }
        }

        private void LoadAllChoices()
        {
            try
            {
                DataTable events = Database.Query(EventChoiceQuery);
                DataTable venues = Database.Query(VenueChoiceQuery);
                DataTable clients = Database.Query(ClientChoiceQuery);
                DataTable partners = Database.Query(PartnerChoiceQuery);

                loadingChoices = true;
                BindEvent(cbxUpdateEvent, events.Copy());
                BindEvent(CB_Selected_Event, events.Copy());
                BindEvent(cbxDeleteEvent, events);
                BindVenue(cbxAddEventVenue, venues.Copy());
                BindVenue(cbxUpdateEvent_Venue, venues);
                BindClient(cbxClientSelectedBook, clients.Copy());
                BindClient(cbxClientSelectedUpdate, clients);
                BindPartner(cbxPartnerSelectedBook, partners.Copy());
                BindPartner(cbxPartnerSelectedUpdate, partners);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("load event choices", ex);
            }
            finally
            {
                loadingChoices = false;
            }
        }

        private void RefreshEventChoices()
        {
            try
            {
                DataTable events = Database.Query(EventChoiceQuery);
                loadingChoices = true;
                BindEvent(cbxUpdateEvent, events.Copy());
                BindEvent(CB_Selected_Event, events.Copy());
                BindEvent(cbxDeleteEvent, events);
            }
            catch (SqlException ex)
            {
                ShowDatabaseError("refresh events", ex);
            }
            finally
            {
                loadingChoices = false;
            }
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
                loadingChoices = true;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.DataSource = Database.Query(query);
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

        private static void BindEvent(ComboBox comboBox, DataTable data)
        {
            BindChoice(comboBox, data, "Event_Name", "Event_ID");
        }

        private static void BindVenue(ComboBox comboBox, DataTable data)
        {
            BindChoice(comboBox, data, "VenueDisplay", "Venue_ID");
        }

        private static void BindClient(ComboBox comboBox, DataTable data)
        {
            BindChoice(comboBox, data, "ClientFullName", "Client_ID");
        }

        private static void BindPartner(ComboBox comboBox, DataTable data)
        {
            BindChoice(comboBox, data, "PartnerFullName", "Partner_ID");
        }

        private static void BindChoice(
            ComboBox comboBox,
            DataTable data,
            string displayMember,
            string valueMember)
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DataSource = data;
            comboBox.SelectedIndex = -1;
        }

        private static bool TryReadEvent(
            TextBox nameControl,
            RichTextBox descriptionControl,
            MonthCalendar dateControl,
            ComboBox venueControl,
            ComboBox clientControl,
            ComboBox partnerControl,
            out string eventName,
            out string description,
            out DateTime eventDate,
            out int venueId,
            out int clientId,
            out int partnerId)
        {
            eventName = nameControl.Text.Trim();
            description = descriptionControl.Text.Trim();
            eventDate = dateControl.SelectionStart.Date;
            venueId = 0;
            clientId = 0;
            partnerId = 0;

            if (!ValidationHelper.IsTitle(eventName))
            {
                ShowValidationError(nameControl, "Enter a valid event name.");
                return false;
            }

            nameControl.BackColor = Color.White;
            if (!ValidationHelper.HasRequiredText(description, 255, 5))
            {
                ShowValidationError(descriptionControl,
                    "Enter an event description between 5 and 255 characters.");
                return false;
            }

            descriptionControl.BackColor = Color.White;
            if (!ValidationHelper.TryGetSelectedId(venueControl, out venueId))
            {
                ShowSelectionError(venueControl, "Select a venue.");
                return false;
            }

            venueControl.BackColor = Color.White;
            if (!ValidationHelper.TryGetSelectedId(clientControl, out clientId))
            {
                ShowSelectionError(clientControl, "Select a client.");
                return false;
            }

            clientControl.BackColor = Color.White;
            if (!ValidationHelper.TryGetSelectedId(partnerControl, out partnerId))
            {
                ShowSelectionError(partnerControl, "Select a partner.");
                return false;
            }

            partnerControl.BackColor = Color.White;
            return true;
        }

        private static void AddEventParameters(
            SqlParameterCollection parameters,
            string eventName,
            string description,
            DateTime eventDate,
            int venueId,
            int clientId,
            int partnerId,
            decimal eventCost)
        {
            Database.AddVarChar(parameters, "@EventName", 50, eventName);
            Database.AddInt(parameters, "@VenueId", venueId);
            Database.AddInt(parameters, "@ClientId", clientId);
            Database.AddInt(parameters, "@PartnerId", partnerId);
            Database.AddDate(parameters, "@EventDate", eventDate);
            Database.AddVarChar(parameters, "@Description", 255, description);
            Database.AddMoney(parameters, "@EventCost", eventCost);
        }

        private void ClearAddFields()
        {
            txbEventNameBook.Clear();
            RTBEventDescription.Clear();
            cbxAddEventVenue.SelectedIndex = -1;
            cbxClientSelectedBook.SelectedIndex = -1;
            cbxPartnerSelectedBook.SelectedIndex = -1;
            lblDispCost.Visible = false;
            btnBookEvent.Visible = false;
            txbEventNameBook.Focus();
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

        private void CB_Selected_Event_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            BtnViewEvent.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(CB_Selected_Event, out ignored);
        }

        private void cbxAddEventVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            btnBookEvent.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(cbxAddEventVenue, out ignored);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ignored;
            btnDelete.Visible = !loadingChoices
                && ValidationHelper.TryGetSelectedId(cbxDeleteEvent, out ignored);
        }

        private void CB_Selected_Event_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(CB_Selected_Event, EventChoiceQuery, "Event_Name", "Event_ID");
        }

        private void cbxAddEventVenue_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(cbxAddEventVenue, VenueChoiceQuery, "VenueDisplay", "Venue_ID");
        }

        private void cbxUpdateEvent_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(cbxUpdateEvent, EventChoiceQuery, "Event_Name", "Event_ID");
        }

        private void cbxDeleteEvent_DropDown(object sender, EventArgs e)
        {
            RefreshSingleChoice(cbxDeleteEvent, EventChoiceQuery, "Event_Name", "Event_ID");
        }

        private void btnCancel1_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel2_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel3_Click(object sender, EventArgs e) { Close(); }
        private void btnCancel4_Click(object sender, EventArgs e) { Close(); }
    }
}
