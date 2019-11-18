using System;
using System.Windows.Forms;
using University_advisor.Entity;
using University_advisor.Controllers;

namespace University_advisor.View
{
    public partial class Login : Form
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

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var registrationForm = new Registration();
            registrationForm.Closed += (s, args) => this.Close();
            registrationForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Menu menu = new Menu(this);

                RegularUser currentUser = new RegularUser(textBox1.Text, textBox2.Text);

                LoginEventArgs logArgs = new LoginEventArgs(currentUser);
                OnRaiseLoginEvent(logArgs);

                this.Hide();
                menu.Closed += (s, args) => this.Close();
                menu.Show();

            }
            catch(Exception err)
            {
                label3.Visible = true;
            }
        }
    }
}
