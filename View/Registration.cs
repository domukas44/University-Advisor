using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using University_advisor.Entity;
using University_advisor.Controllers;

namespace University_advisor.View
{
    public partial class Registration : Form
    {
        public delegate void EventHandler<LoginEventArgs>(object sender, LoginEventArgs e);
        public event EventHandler<LoginEventArgs> RaiseLoginEvent;
        protected virtual void OnRaiseLoginEvent(LoginEventArgs e)
        {
            EventHandler<LoginEventArgs> handler = RaiseLoginEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmailValidation() && PasswordValidation())
            {
                try
                {
                    Menu menu = new Menu(this);

                    RegularUser currentUser = new RegularUser(textBox1.Text, textBox2.Text, textBox3.Text);

                    LoginEventArgs logArgs = new LoginEventArgs(currentUser);
                    OnRaiseLoginEvent(logArgs);

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
                if (!PasswordValidation()) { label8.Visible = true; }
                else { label8.Visible = false; }
                if (!EmailValidation()) label4.Visible = true;
                else label4.Visible = false; 
            }
        }

        private bool EmailValidation()
        {
            string email = textBox2.Text;
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match match = Regex.Match(email, pattern);
            return match.Success;
        }

        private bool PasswordValidation()
        {
            string password = textBox3.Text;
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            Match match = Regex.Match(password, pattern);
            return match.Success;
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
