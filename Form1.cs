using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace University_advisor
{
    public partial class Form1 : Form
    {
        private Subjects subjects;
        private Form2 subjectInfoForm;
        private string searchText;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            subjects = new Subjects();
            populateTable();
        }

        public void populateTable()
        {
            dataGridView1.DataSource = subjects.arr;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // rodyti kitą Form su dalyko informacija?
            if (subjectInfoForm == null)
            {
                subjectInfoForm = new Form2();
            }

            //...
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // filtruoti dalykus pagal tai, kas įvesta textBox1

            // šitie neveikia, bet maždaug panašiai turėtų atrodyt (LINQ)
            //IEnumerable<string> query = from s in subjects
            //                           where s .Contains(searchText) 
            //                            select s;
            //IEnumerable<string> query = subjects.Where(s => searchText.All(t => s.Contains(t)));

            MessageBox.Show("insert search functionality here");

            //...
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchText = textBox1.Text;
        }
    }
}
