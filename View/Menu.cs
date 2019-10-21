using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using University_advisor.Controllers;
using System.Windows.Forms;
using University_advisor.Data.Enum;
using University_advisor.Entity;

namespace University_advisor
{
    public partial class Menu : Form
    {
        public RegularUser currentUser { get; set; }
        enum AllSubjects //should be something else as subjects are not constant
        {
            Bioinformatika = 0,
            Buhalterine_apskaita = 1,
            Verslo_vadyba = 2
        }

        private List<ListViewItem> mainList;
        private List<RandC> RandcList;
        Subjects subjects;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            label3.Text += currentUser.email;

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
            int Id = 0;
            foreach (String items in GetMenuItemsList())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                item.Tag = Id;
                Id++;
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

        private void OnSortIndexChange(object sender, EventArgs e)
        {
            var subjectsList = ((IEnumerable)subjects).Cast<Subject>().ToList();
            IEnumerable<Subject> _query = new List<Subject>();
            subjectListView.Items.Clear();

            int index = sortComboBox.SelectedIndex;
            switch (index)
            {
                case (int)SortValuesEnum.Name:
                    _query = subjectsList.OrderByDescending(i => i.Name);
                    break;
                case (int)SortValuesEnum.Rating:
                    _query = subjectsList.OrderByDescending(i => i.Rating);
                    break;
                default:
                    _query = subjectsList;
                    break;
            }

            mainList.Clear();

            foreach (var subject in _query)
            {
                var row = new string[] { subject.Name, subject.Rating.ToString("0.##") };
                var lvi = new ListViewItem(row);
                lvi.Tag = subject;
                mainList.Add(lvi);
            }

            foreach (ListViewItem item in mainList)
            {
                subjectListView.Items.Add(item);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Rikiavimas: ";
        }

        private void ReviewsBtn_Click(object sender, EventArgs e)
        {
            /*RandcList = new List<RandC>();
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
                System.Windows.Forms.MessageBox.Show(tmp1 + "   " + tmp2);
                //Console.WriteLine("Substring: {0}", tmp1 + " " + tmp2);
                RandcList.Add(new RandC(tmp1, tmp2));
            }

            //CurrUser = currentUser.email;
            List<RegularUser> Users = new List<RegularUser> {currentUser };
            //System.Windows.Forms.MessageBox.Show(CurrUser);

            var query =
                Users.GroupJoin(RandcList,
           RegularUser => RegularUser,
           RandC => RandC.email,
           (RegularUser, result) => new
           {
               UserName = RegularUser.email,
               Reviews = result.Select(RandC => RandC.email)

           }) ;
      

            // Enumerate results.
            foreach (var result in query)
            {
                Console.WriteLine("{0} bought...", result.Name);
                foreach (var item in result.Collection)
                {
                    Console.WriteLine(item.Product);
                }
            }*/
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
