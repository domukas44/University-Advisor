using System;
using System.Windows.Forms;
using University_advisor.Controllers;

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
            Visible = false;
            Serializer.serialize(new Review(subject, "author1", richTextBox1.Text, 10));        // placeholder author and rating values
            MessageBox.Show("Atsiliepimas sėkmingai išsaugotas.");
        }
    }
}
