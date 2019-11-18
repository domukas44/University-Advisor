using System;
using System.Management;
using System.Collections.Generic;
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
        public SubjectCard(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        public void ShowInformation(Subject subject)
        {
            this.subject = subject;
            subject.UpdateList();
            label1.Text = subject.Name;
            label3.Text = subject.Rating.FormatForRating();
            
            foreach (Review r in subject.Reviews.Value)
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

            var review = new Review(subject: subject, author: menu.ReturnCurrentUserEmail(),
                comment: richTextBox1.Text, rating: Int32.Parse((string)comboBox1.SelectedItem));

            Serializer.Serialize(review); 

            subject.AddRating(Int32.Parse((string)comboBox1.SelectedItem));
            label3.Text = subject.Rating.ToString("0.##") + "/10";
            double rating = subject.Rating;
            UpdateData(ref rating, subject.Name)
            menu.UpdateRatings();

            MessageBox.Show("Atsiliepimas sėkmingai išsaugotas.");
        }

        private void UpdateData<T>(ref T rating, string name)
        {
            double NewRating = Convert.ToDouble(rating);
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\Data.txt");
            for(int i=0; i< lines.Length; i++)
            {
                string[] linesSplit = lines[i].Split('\t');
                if(linesSplit[0] == name)
                {
                    linesSplit[1] = NewRating.ToString("0.##");
                    int temp = Convert.ToInt32(linesSplit[2]);
                    temp++;
                    linesSplit[2] = (temp).ToString();
                    lines[i] = linesSplit[0] + "\t" + linesSplit[1] + "\t" + linesSplit[2];
                    break;
                }
            }
            System.IO.File.WriteAllLines(@"..\..\Resources\Data.txt", lines);
        }
    }
}
