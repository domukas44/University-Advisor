﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using University_advisor.Controllers;

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
                    RegularUser user = new RegularUser(textBox1.Text, textBox2.Text, textBox3.Text);
                    this.Hide();
                    var mainForm = new Menu();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.Show();

                }catch (Exception err)
                {
                    label7.Visible = true;
                    label4.Visible = false;
                }
            }
            else
            {
                if (!passwordValidation()) { label5.Visible = true; label6.Visible = true; }
                else { label5.Visible = false; label6.Visible = false; }
                if (!emailValidation()) label4.Visible = true;
                else label4.Visible = false; 
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
