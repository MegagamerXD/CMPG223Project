using Clients_form;
using Events_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Partner_Form partner_Form = new Partner_Form();
            partner_Form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PartnerProfessionForm partner_Profession = new PartnerProfessionForm();
            partner_Profession.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm();
            eventForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Client_Form client_Form = new Client_Form();
            client_Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venue venue_form = new Venue();
            venue_form.ShowDialog();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
