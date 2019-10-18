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
            label3.Text = subject.Rating.ToString("0.##") + "/5.00";
            Text = subject.Name;
            Update();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Object o = comboBox1.SelectedItem;

            // jei nepasirinko įvertinimo, neleidžia išsaugoti
            if (o == null)
            {
                MessageBox.Show("Būtina pasirinkti įvertinimą.");
            }

            // jei pasirinko, tai tikrina, ar pakomentavo
            else
            {
                if (richTextBox1.Text != "")
                {
                    confirmReview();
                }

                // jei nepakomentavo, tai paprašo patvirtinti, ar tikrai taip norėjo
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
    }
}
