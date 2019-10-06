using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_advisor
{
    public partial class SubjectCard : Form
    {
        public SubjectCard()
        {
            InitializeComponent();
        }

        public void ShowInformation(string name, double rating)
        {
            label1.Text = name;
            label3.Text = rating.ToString() + "/5";       
        }
    }
}
