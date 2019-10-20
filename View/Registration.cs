using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
                registerAccount();
            }
            else
            {
                if (!passwordValidation()) { label5.Visible = true; label6.Visible = true; }
                if (!emailValidation()) label4.Visible = true;
            }
        }

        private bool emailValidation()
        {
            string email = textBox2.Text;
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match match = Regex.Match(email, pattern);
            if (match.Success) return true;
            else return false;
        }

        private bool passwordValidation()
        {
            string password = textBox3.Text;
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            Match match = Regex.Match(password, pattern);
            if (match.Success) return true;
            else return false;
        }

        private void registerAccount()
        {

        }
    }
}
