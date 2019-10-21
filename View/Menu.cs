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
        private List<RandC> RandcList;

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
            SubjectCard subjectCardForm = new SubjectCard(this);

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

        public void UpdateRatings()
        {
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();
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

        private void MyReviews_Click(object sender, EventArgs e)
        {

            RandcList = new List<RandC>();
            string CurrUser = "user";
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\Reviews.txt");

            foreach (string line in lines)
            {
             string[] linesSplit = line.Split(',');
                string tmp1 = linesSplit[2];
                tmp1 = tmp1.Substring(10);
               
                tmp1 = tmp1.Remove(tmp1.Length - 1);
                string tmp2 = linesSplit[3];
                tmp2 = tmp2.Substring(11);
                tmp2 = tmp2.Remove(tmp2.Length - 1);
                System.Windows.Forms.MessageBox.Show( tmp1 + "                  " + tmp2);
                //Console.WriteLine("Substring: {0}", tmp1 + " " + tmp2);
                RandcList.Add(new RandC(tmp1,tmp2));
            }
            /*foreach (string line in lines)
            {
                string[] linesSplit = line.Split('\t');
                subjectList.Add(new Subject(linesSplit[0], Convert.ToDouble(linesSplit[1]), Convert.ToInt32(linesSplit[2])));
            }*/

        }
    }
}
