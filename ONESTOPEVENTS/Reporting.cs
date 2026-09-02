using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = GetSelectedReportQuery();
            if (query == null)
            {
                MessageBox.Show("Select a report type.", "Selection required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = monthCalendar1.SelectionStart.Date;
            DateTime endDate = monthCalendar2.SelectionStart.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("The ending date must be on or after the starting date.",
                    "Invalid date range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateReport(query, startDate, endDate.AddDays(1));
        }

        private string GetSelectedReportQuery()
        {
            if (radioButton1.Checked)
            {
                return @"
                    SELECT TOP (10)
                           P.Partner_FirstName AS [First name],
                           P.Partner_SurName AS [Surname],
                           P.Partner_Email AS [Email],
                           COUNT(E.Event_ID) AS [Events],
                           SUM(E.Event_Cost) AS [Total event value]
                    FROM EVENTS AS E
                    INNER JOIN PARTNERS AS P ON E.Partner_ID = P.Partner_ID
                    WHERE E.Event_Date >= @StartDate
                      AND E.Event_Date < @EndDateExclusive
                    GROUP BY P.Partner_ID, P.Partner_FirstName,
                             P.Partner_SurName, P.Partner_Email
                    ORDER BY [Total event value] DESC, [Surname], [First name];";
            }

            if (radioButton2.Checked)
            {
                return @"
                    SELECT TOP (10)
                           V.Venue_Name AS [Venue],
                           V.Venue_Address AS [Address],
                           COUNT(E.Event_ID) AS [Number of events]
                    FROM EVENTS AS E
                    INNER JOIN VENUES AS V ON E.Venue_ID = V.Venue_ID
                    WHERE E.Event_Date >= @StartDate
                      AND E.Event_Date < @EndDateExclusive
                    GROUP BY V.Venue_ID, V.Venue_Name, V.Venue_Address
                    ORDER BY [Number of events] DESC, [Venue];";
            }

            if (radioButton3.Checked)
            {
                return @"
                    SELECT TOP (10)
                           E.Event_Name AS [Event],
                           E.Event_Date AS [Date],
                           V.Venue_Name AS [Venue],
                           E.Event_Cost AS [Event value]
                    FROM EVENTS AS E
                    INNER JOIN VENUES AS V ON E.Venue_ID = V.Venue_ID
                    WHERE E.Event_Date >= @StartDate
                      AND E.Event_Date < @EndDateExclusive
                    ORDER BY E.Event_Cost DESC, E.Event_Date, E.Event_Name;";
            }

            if (radioButton4.Checked)
            {
                return @"
                    SELECT TOP (10)
                           C.Client_FirstName AS [First name],
                           C.Client_SurName AS [Surname],
                           C.Client_Email AS [Email],
                           COUNT(E.Event_ID) AS [Events],
                           SUM(E.Event_Cost) AS [Total spent]
                    FROM EVENTS AS E
                    INNER JOIN CLIENTS AS C ON E.Client_ID = C.Client_ID
                    WHERE E.Event_Date >= @StartDate
                      AND E.Event_Date < @EndDateExclusive
                    GROUP BY C.Client_ID, C.Client_FirstName,
                             C.Client_SurName, C.Client_Email
                    ORDER BY [Total spent] DESC, [Surname], [First name];";
            }

            return null;
        }

        private void GenerateReport(string query, DateTime startDate, DateTime endDateExclusive)
        {
            try
            {
                dataGridView1.DataSource = Database.Query(query, parameters =>
                {
                    Database.AddDate(parameters, "@StartDate", startDate);
                    Database.AddDate(parameters, "@EndDateExclusive", endDateExclusive);
                });
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to generate the report.\n\n" + ex.Message,
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { ClearDataGridView(); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { ClearDataGridView(); }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) { ClearDataGridView(); }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) { ClearDataGridView(); }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void Reporting_Load(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { Close(); }
    }
}
