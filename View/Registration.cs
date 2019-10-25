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
            if (emailValidation() && passwordValidation())
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
                if (!passwordValidation()) { label8.Visible = true; }
                else { label8.Visible = false; }
                if (!emailValidation()) label4.Visible = true;
                else label4.Visible = false; 
            }
        }

        private bool emailValidation()
        {
            string email = textBox2.Text;
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match match = Regex.Match(email, pattern);
            return match.Success;
        }

        private bool passwordValidation()
        {
            string password = textBox3.Text;
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            Match match = Regex.Match(password, pattern);
            return match.Success;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
