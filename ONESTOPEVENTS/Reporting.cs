using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;initial catalog=OnestopEvents;trusted_connection=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader re;
        DataSet ds;
        DataTable dt;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearDataGridView();
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ClearDataGridView();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ClearDataGridView();
        }
 
    

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ClearDataGridView();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Determine the query based on the selected radio button
            string query = GetQueryBasedOnSelection();

            if (query == null)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            // Get the start and end dates from the MonthCalendar controls
            DateTime startDate = monthCalendar1.SelectionStart;
            DateTime endDate = monthCalendar2.SelectionStart;

            // Ensure endDate is after startDate
            if (endDate < startDate)
            {
                MessageBox.Show("End date must be on or after the start date.");
                return;
            }

            // Generate the report
            GenerateReport(query, startDate, endDate);
        }

        private string GetQueryBasedOnSelection()
        {
            if (radioButton1.Checked)
            {
                return @"
            SELECT TOP 10 
                p.Partner_FirstName,
                p.Partner_SurName,
                p.Partner_Email,
                SUM(e.Event_Cost) AS TotalEarnings
            FROM 
                EVENTS e
            INNER JOIN 
                PARTNERS p ON e.Partner_ID = p.Partner_ID
            WHERE 
                e.Event_Date BETWEEN @StartDate AND @EndDate
            GROUP BY 
                p.Partner_FirstName,
                p.Partner_SurName,
                p.Partner_Email
            ORDER BY 
                TotalEarnings DESC;
        ";
            }
            else if (radioButton2.Checked)
            {
                return @"
            SELECT TOP 10 
                v.Venue_Name,
                v.Venue_Address,
                COUNT(e.Event_ID) AS NumberOfEvents
            FROM 
                EVENTS e
            INNER JOIN 
                VENUES v ON e.Venue_ID = v.Venue_ID
            WHERE 
                e.Event_Date BETWEEN @StartDate AND @EndDate
            GROUP BY 
                v.Venue_Name,
                v.Venue_Address
            ORDER BY 
                NumberOfEvents DESC;
        ";
            }
            else if (radioButton3.Checked)
            {
                return @"
            SELECT TOP 10 
                e.Event_Name,
                e.Event_Description,
                v.Venue_Name,
                SUM(e.Event_Cost) AS TotalRevenue
            FROM 
                EVENTS e
            INNER JOIN 
                VENUES v ON e.Venue_ID = v.Venue_ID
            WHERE 
                e.Event_Date BETWEEN @StartDate AND @EndDate
            GROUP BY 
                e.Event_Name,
                e.Event_Description,
                v.Venue_Name
            ORDER BY 
                TotalRevenue DESC;
        ";
            }
            else if (radioButton4.Checked)
            {
                return @"
            SELECT TOP 10 
                c.Client_FirstName,
                c.Client_SurName,
                c.Client_Email,
                SUM(e.Event_Cost) AS TotalSpent
            FROM 
                EVENTS e
            INNER JOIN 
                CLIENTS c ON e.Client_ID = c.Client_ID
            WHERE 
                e.Event_Date BETWEEN @StartDate AND @EndDate
            GROUP BY 
                c.Client_FirstName,
                c.Client_SurName,
                c.Client_Email
            ORDER BY 
                TotalSpent DESC;
        ";
            }
            return null;
        }

        private void GenerateReport(string query, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8Q3DTNR\SQLEXPRESS;initial catalog=OnestopEvents;trusted_connection=true"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ClearDataGridView(); // Clear previous data
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void ClearDataGridView()
        {
            dataGridView1.DataSource = null; // Clears bound data
            dataGridView1.Rows.Clear();      // Clears rows if not using data source
            dataGridView1.Columns.Clear();   // Clears columns if needed
        }

        private void Reporting_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
