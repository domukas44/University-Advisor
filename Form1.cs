using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace University_advisor
{
    public partial class Form1 : Form
    {
        private Subjects allSubjects;
        private Subjects shownSubjects;

        private Form2 subjectInfoForm;
        private string searchText;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allSubjects = new Subjects();
            allSubjects.createSubjects();
            populateTable(allSubjects);
        }

        public void populateTable(Subjects subjects)
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

            IEnumerable<Subject> query = allSubjects.Where(s => searchText.All(t => s.Name.ToLower().Contains(t.ToString().ToLower())));
            shownSubjects = new Subjects();
            int i = 0;
            foreach(Subject s in query)
            {
                shownSubjects.arr[i++] = s;
            }
            populateTable(shownSubjects);
            i = 0;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchText = textBox1.Text;
        }
    }
}
