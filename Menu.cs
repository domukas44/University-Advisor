using System;
using System.Collections;
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
    public partial class Menu : Form
    {
        enum AllSubjects
        {
            Bioinformatika = 0,
            Buhalterine_apskaita = 1
        }

        private string searchText;

        public Menu()
        {
            InitializeComponent();
        }

        private void Load_MenuToolStripMenuItem()
        {
            int id = 0;
            foreach (String items in GetMenuItemsList())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                item.Tag = id;
                id++;
                pasirenkamiejiDalykaiToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(Item_click);
            }
        }

        private void Item_click(Object sender, EventArgs e)
        {
            Subjects subjects = new Subjects();
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SubjectCard subjectCardForm = new SubjectCard();
            switch (item.Tag)
            {
                case (int)AllSubjects.Bioinformatika:
                    subjectCardForm.ShowInformation(subjectsList[(int)AllSubjects.Bioinformatika].Name, subjectsList[(int)AllSubjects.Bioinformatika].Rating);                   
                    break;
                case (int)AllSubjects.Buhalterine_apskaita:
                    subjectCardForm.ShowInformation(subjectsList[(int)AllSubjects.Buhalterine_apskaita].Name, subjectsList[(int)AllSubjects.Buhalterine_apskaita].Rating);
                    break;

            }
            //subjectCardForm.ShowInformation("vienas", 2.00);
            subjectCardForm.Show();
        }

        private List<String> GetMenuItemsList()
        {
            List<String> menuItems = new List<String>();
            Subjects subjects = new Subjects();     

            foreach (var subject in subjects)
            {
                menuItems.Add((subject as Subject).Name);
            }

            return menuItems;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Load_MenuToolStripMenuItem();
            subjectListView.Items.Clear();
            Subjects subjects = new Subjects();
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();
            foreach (var subject in subjectsList)
            {
                var row = new string[] { subject.Name, subject.Rating.ToString("0.##") };
                var lvi = new ListViewItem(row);
                lvi.Tag = subject;
                subjectListView.Items.Add(lvi);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Subjects subjects = new Subjects();
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();
            IEnumerable<Subject> query = subjectsList.Where(s => searchText.All(t => s.Name.ToLower().Contains(t.ToString().ToLower())));
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchText = textBox1.Text;
        }
    }
}
