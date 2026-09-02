using System;
using System.Windows.Forms;
using Clients_form;
using Events_Form;

namespace ONESTOPEVENTS
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Venue form = new Venue())
            {
                form.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Reporting form = new Reporting())
            {
                form.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Partner_Form form = new Partner_Form())
            {
                form.ShowDialog(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (PartnerProfessionForm form = new PartnerProfessionForm())
            {
                form.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (EventForm form = new EventForm())
            {
                form.ShowDialog(this);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (Client_Form form = new Client_Form())
            {
                form.ShowDialog(this);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (HelpAssistantForm form = new HelpAssistantForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}
