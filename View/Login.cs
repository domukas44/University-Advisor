using System;
using System.Windows.Forms;
using University_advisor.Entity;

namespace University_advisor.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            rememberCheckBox.Checked = Properties.Settings.Default.RememberEmail;
            if (rememberCheckBox.Checked)
            {
                textBox1.Text = Properties.Settings.Default.Email;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var registrationForm = new Registration();
            registrationForm.Closed += (s, args) => this.Close();       // standard event + lambda
            registrationForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rememberCheckBox.Checked)       // remember email for next time if user checked the box
                {
                    Properties.Settings.Default.Email = textBox1.Text;
                    Properties.Settings.Default.Save();
                }
                Menu menu = new Menu();
                menu.currentUser = new RegularUser(textBox1.Text, textBox2.Text);
                this.Hide();
                menu.Closed += (s, args) => this.Close();           // standard event + lambda
                menu.Show();

            }
            catch(Exception err)
            {
                label3.Visible = true;
            }
        }

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberEmail = rememberCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
