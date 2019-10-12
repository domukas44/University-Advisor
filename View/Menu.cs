using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace University_advisor
{
    public partial class Menu : Form
    {
        enum AllSubjects //should be something else as subjects are not constant
        {
            Bioinformatika = 0,
            Buhalterine_apskaita = 1,
            Verslo_vadyba = 2
        }

        private List<ListViewItem> mainList;
        Subjects subjects;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            subjects = new Subjects();
            mainList = new List<ListViewItem>();
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();

            Load_MenuToolStripMenuItem();
            mainList.Clear();

            foreach (var subject in subjectsList)
            {
                var row = new string[] { subject.Name, subject.Rating.ToString("0.##") };
                var lvi = new ListViewItem(row);
                lvi.Tag = subject;
                mainList.Add(lvi);
            }

            DisplayItems();
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
            openCard(sender);           
        }

        private void openCard(Object sender)
        {
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SubjectCard subjectCardForm = new SubjectCard();

            subjectCardForm.ShowInformation(subjectsList[Convert.ToInt32(item.Tag)]);

            subjectCardForm.Show();
        }

        private List<String> GetMenuItemsList()
        {
            List<String> menuItems = new List<String>();    

            foreach (var subject in subjects)
            {
                menuItems.Add((subject as Subject).Name);
            }

            return menuItems;
        }

        private void DisplayItems()
        {
            subjectListView.Items.Clear();

            foreach (ListViewItem item in mainList.Where(lvi => lvi.Text.ToLower().Contains(textBox1.Text.ToLower().Trim())))
            {
                subjectListView.Items.Add(item);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DisplayItems();
        }

        private void subjectListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //openCard(sender);
        }
    }
}
