using System;
using System.Windows.Forms;
using University_advisor.Controllers;

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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registrationForm = new Registration();
            registrationForm.Closed += (s, args) => this.Close();
            registrationForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegularUser user = new RegularUser(textBox1.Text, textBox2.Text);
                this.Hide();
                var mainForm = new Menu();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();

            }
            catch(Exception err)
            {
                label3.Visible = true;
            }
        }
    }
}
