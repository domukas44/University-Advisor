using System;
using System.Windows.Forms;
using University_advisor.Controllers;
using University_advisor.Entity;
using University_advisor.View;

namespace University_advisor
{
    public partial class SubjectCard : Form
    {
        private Subject subject;
        private readonly Menu menu;
        private Func<double, string> formatRatingDel;

        public SubjectCard(Menu menu, Func<double, string> ratingFormatter)
        {
            InitializeComponent();
            this.menu = menu;
            formatRatingDel = ratingFormatter;
        }

        public void ShowInformation(Subject subject)
        {
            this.subject = subject;
            label1.Text = subject.Name;
            label3.Text = formatRatingDel(subject.Rating);
            foreach (Review r in Review.GetReviewList(subject))
            {
                label4.Text += r.Comment;
                label4.Text += " ";
                label4.Text += r.Rating.ToString();
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
                    ConfirmReview();
                }

                // if no comment found - asks to confirm the decision
                else
                {
                    ConfirmationBox confirmationBox = new ConfirmationBox(this);
                    confirmationBox.Show();
                }
            }
        }

        public void ConfirmReview()
        {
            Visible = false;
            Serializer.Serialize(new Review(subject: subject, author: menu.ReturnCurrentUserEmail(), comment: richTextBox1.Text, rating: Int32.Parse((string)comboBox1.SelectedItem)));        // named argument usage
            subject.AddRating(Int32.Parse((string)comboBox1.SelectedItem));
            label3.Text = formatRatingDel(subject.Rating);
            menu.UpdateRatings();
            MessageBox.Show("Atsiliepimas sėkmingai išsaugotas.");
        }
    }
}
