using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_advisor.View
{
    public partial class ConfirmationBox : Form
    {
        private SubjectCard subjectCard;

        public ConfirmationBox(SubjectCard subjectCard)
        {
            InitializeComponent();
            this.subjectCard = subjectCard;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            Visible = false;
            subjectCard.confirmReview();
        }
    }
}
