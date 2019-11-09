using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using University_advisor.Entity;

namespace University_advisor.View
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserWS.UserWebService client = new UserWS.UserWebService();

            if (client.EmailValidation(textBox2.Text) && client.PasswordValidation(textBox3.Text))
            {
                try
                {
                    Menu menu = new Menu();
                    menu.currentUser = new RegularUser(textBox1.Text, textBox2.Text, textBox3.Text);
                    this.Hide();
                    menu.Closed += (s, args) => this.Close();
                    menu.Show();

                }
                catch (Exception err)
                {
                    label7.Visible = true;
                    label4.Visible = false;
                }
            }
            else
            {
                if (!client.PasswordValidation(textBox3.Text)) { label8.Visible = true; }
                else { label8.Visible = false; }
                if (!client.EmailValidation(textBox2.Text)) label4.Visible = true;
                else label4.Visible = false; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var loginForm = new Login();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
