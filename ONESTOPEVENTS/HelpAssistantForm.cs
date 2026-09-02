using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    public sealed class HelpAssistantForm : Form
    {
        private readonly RichTextBox conversationBox;
        private readonly TextBox questionTextBox;
        private readonly Button sendButton;
        private readonly IReadOnlyList<HelpTopic> topics;

        public HelpAssistantForm()
        {
            Text = "One Stop Events Help Assistant";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(760, 520);
            MinimumSize = new Size(700, 500);
            BackColor = SystemColors.Menu;

            topics = CreateTopics();

            Panel accentPanel = new Panel
            {
                BackColor = Color.Goldenrod,
                Dock = DockStyle.Top,
                Height = 86,
                Padding = new Padding(4)
            };

            Label heading = new Label
            {
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                Font = new Font("Calibri", 28F, FontStyle.Bold),
                Text = "Help Assistant",
                TextAlign = ContentAlignment.MiddleCenter
            };
            accentPanel.Controls.Add(heading);

            Label instructionLabel = new Label
            {
                AutoSize = false,
                Location = new Point(18, 102),
                Size = new Size(724, 38),
                Font = new Font("Calibri", 10.5F),
                Text = "Ask how to maintain records, book an event, calculate cost, prevent conflicts, " +
                       "run reports, or set up the database."
            };

            conversationBox = new RichTextBox
            {
                Name = "conversationBox",
                Location = new Point(18, 140),
                Size = new Size(724, 285),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Calibri", 11F),
                ReadOnly = true,
                TabStop = false
            };

            questionTextBox = new TextBox
            {
                Name = "questionTextBox",
                Location = new Point(18, 444),
                Size = new Size(590, 27),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Calibri", 11F)
            };

            sendButton = new Button
            {
                Name = "sendButton",
                Location = new Point(620, 440),
                Size = new Size(122, 38),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Font = new Font("Calibri", 11F),
                Text = "Send",
                UseVisualStyleBackColor = true
            };
            sendButton.Click += SendButton_Click;

            Label privacyLabel = new Label
            {
                AutoSize = true,
                Location = new Point(18, 487),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                ForeColor = Color.DimGray,
                Font = new Font("Calibri", 9F),
                Text = "Offline help: questions stay on this computer and no internet service is used."
            };

            Controls.Add(privacyLabel);
            Controls.Add(sendButton);
            Controls.Add(questionTextBox);
            Controls.Add(conversationBox);
            Controls.Add(instructionLabel);
            Controls.Add(accentPanel);

            AcceptButton = sendButton;
            AppendMessage("Assistant", "Hello! I can explain how to use One Stop Events. " +
                "Try asking: How do I book an event?");
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string question = questionTextBox.Text.Trim();
            if (question.Length == 0)
            {
                MessageBox.Show("Enter a question for the help assistant.", "Question required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                questionTextBox.Focus();
                return;
            }

            AppendMessage("You", question);
            AppendMessage("Assistant", FindAnswer(question));
            questionTextBox.Clear();
            questionTextBox.Focus();
        }

        private string FindAnswer(string question)
        {
            string normalized = new string(question.ToLowerInvariant()
                .Select(character => char.IsLetterOrDigit(character) ? character : ' ')
                .ToArray());

            HelpTopic bestMatch = topics
                .Select(topic => new
                {
                    Topic = topic,
                    Score = topic.Keywords.Count(keyword => normalized.Contains(keyword))
                })
                .Where(match => match.Score > 0)
                .OrderByDescending(match => match.Score)
                .ThenByDescending(match => match.Topic.Priority)
                .Select(match => match.Topic)
                .FirstOrDefault();

            if (bestMatch != null)
            {
                return bestMatch.Answer;
            }

            return "I do not have a matching help topic yet. Ask about clients, partners, professions, " +
                   "venues, event bookings, event cost, booking conflicts, deletion, reports, or database setup.";
        }

        private void AppendMessage(string speaker, string message)
        {
            if (conversationBox.TextLength > 0)
            {
                conversationBox.AppendText(Environment.NewLine + Environment.NewLine);
            }

            conversationBox.SelectionFont = new Font(conversationBox.Font, FontStyle.Bold);
            conversationBox.AppendText(speaker + ": ");
            conversationBox.SelectionFont = new Font(conversationBox.Font, FontStyle.Regular);
            conversationBox.AppendText(message);
            conversationBox.SelectionStart = conversationBox.TextLength;
            conversationBox.ScrollToCaret();
        }

        private static IReadOnlyList<HelpTopic> CreateTopics()
        {
            return new[]
            {
                new HelpTopic(10, new[] { "book", "event" },
                    "Open Events, choose Book Event, enter the event details, select a venue, client and partner, " +
                    "then choose a date and save. The system calculates the cost and rejects a venue or partner " +
                    "that is already booked on that date."),
                new HelpTopic(9, new[] { "event", "cost" },
                    "Event cost is calculated as (R10 000 base fee + venue price + partner profession cost) × 1.15. " +
                    "The 1.15 factor adds 15%."),
                new HelpTopic(9, new[] { "double", "book", "conflict", "available" },
                    "Before saving, the application checks whether the selected venue or partner already has an " +
                    "event on that date. Stored procedures and unique database indexes provide a second safeguard."),
                new HelpTopic(8, new[] { "report", "date" },
                    "Open Request Reports, select one of the four report types, choose a starting and ending date, " +
                    "and select Request report. Both selected dates are included in the results."),
                new HelpTopic(8, new[] { "delete", "remove" },
                    "Choose the Delete tab, select a record and confirm the action. A client, venue, partner or " +
                    "profession cannot be deleted while another record depends on it."),
                new HelpTopic(7, new[] { "client", "customer" },
                    "Open Clients from the home screen. The tabs let you view, add, update or delete a client. " +
                    "Names, email addresses and 10-digit phone numbers are validated before saving."),
                new HelpTopic(7, new[] { "profession", "service" },
                    "Create partner professions before partners. A profession records the service name and positive " +
                    "cost used when calculating an event price."),
                new HelpTopic(6, new[] { "partner", "supplier" },
                    "Open Partners to view, add, update or delete service providers. Each partner must be linked to " +
                    "an existing profession and must have valid contact and website details."),
                new HelpTopic(6, new[] { "venue", "kitchen", "capacity" },
                    "Open Venues to maintain location, kitchen availability, capacity, description, rating, price " +
                    "and address. Capacity and price must be positive; rating must be between 0 and 10."),
                new HelpTopic(6, new[] { "database", "setup", "localdb", "install" },
                    "Run database\\DatabaseSetup.sql against (LocalDB)\\MSSQLLocalDB, or import the supplied BACPAC. " +
                    "Then open ONESTOPEVENTS.sln, build the Release configuration and run the project."),
                new HelpTopic(5, new[] { "phone", "zero" },
                    "Phone numbers are stored as text, not integers. This keeps a leading zero and the validation " +
                    "requires exactly 10 digits."),
                new HelpTopic(1, new[] { "help", "what", "hello", "hi" },
                    "I can help with clients, partners, professions, venues, event bookings, cost calculations, " +
                    "booking conflicts, safe deletion, reports and database setup.")
            };
        }

        private sealed class HelpTopic
        {
            internal HelpTopic(int priority, string[] keywords, string answer)
            {
                Priority = priority;
                Keywords = keywords;
                Answer = answer;
            }

            internal int Priority { get; }
            internal IReadOnlyList<string> Keywords { get; }
            internal string Answer { get; }
        }
    }
}
