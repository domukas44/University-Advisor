using System;
using System.Windows.Forms;
using University_advisor.Controllers;
using University_advisor.View;

namespace University_advisor
{
    public partial class SubjectCard : Form
    {
        private Subject subject;
        public SubjectCard()
        {
            InitializeComponent();
        }

        public void ShowInformation(Subject subject)
        {
            this.subject = subject;
            label1.Text = subject.Name;
            label3.Text = subject.Rating.ToString("0.##") + "/10";
            foreach (Review r in Review.getReviewList(subject))
            {
                label4.Text += r.comment;
                label4.Text += " ";
                label4.Text += r.rating.ToString();
                label4.Text += "\n";
            }
            
            Text = subject.Name;
            Update();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Object o = comboBox1.SelectedItem;

            // if user hasn't chosen a rating - not allowed
            if (o == null)
            {
                MessageBox.Show("Būtina pasirinkti įvertinimą.");
            }

            // if rating was chosen - checks if a comment was added
            else
            {
                if (richTextBox1.Text != "")
                {
                    confirmReview();
                }

                // if no comment found - asks to confirm the decision
                else
                {
                    ConfirmationBox confirmationBox = new ConfirmationBox(this);
                    confirmationBox.Show();
                }
            }
        }

        public void confirmReview()
        {
            Visible = false;
            Serializer.serialize(new Review(subject, "author1", richTextBox1.Text, Int32.Parse((string)comboBox1.SelectedItem)));        // placeholder author value
            MessageBox.Show("Atsiliepimas sėkmingai išsaugotas.");
        }

        private void SubjectCard_Load(object sender, EventArgs e)
        {

        }
    }
}
