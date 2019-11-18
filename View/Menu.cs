using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using University_advisor.Controllers;
using System.Windows.Forms;
using University_advisor.Data.Enum;
using University_advisor.Data;
using University_advisor.Entity;
using University_advisor.View;

namespace University_advisor
{
    public partial class Menu : Form
    {
        public RegularUser currentUser { get; set; }

        private List<ListViewItem> mainList;
        Subjects subjects;

        public Menu(Login login) 
        {
            InitializeComponent();
            login.RaiseLoginEvent += HandleUpdateName;
        }

        public Menu(Registration registration)
        {
            InitializeComponent();
            registration.RaiseLoginEvent += HandleUpdateName;
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
            OpenCard(sender);           
        }

        private void OpenCard(Object sender)
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

        public string ReturnCurrentUserEmail()
        {
            return currentUser.Email;
        }

        private void ReviewsBtn_Click(object sender, EventArgs e)
        {
            var allReviews = Deserializer<Review>.DeserializeFile(@"..\..\Resources\Reviews.txt");
            List<string> users = new List<string>
            {
                currentUser.Email
            };

            var query =
                users.GroupJoin(allReviews,
                                user => user,
                                review => review.Author,
                                (user, reviewCollection) => new
                                {
                                    UserName = user,
                                    Reviews = reviewCollection.Select(review =>
                                        new
                                        {
                                            subject = review.Subject.Name,
                                            comment = review.Comment,
                                            rating = review.Rating
                                        })
                                    });

            MyReviews myReviewsForm = new MyReviews();
            myReviewsForm.usernameLabel.Text = currentUser.Email;

            // Enumerate results.
            foreach (var person in query)
            {
                foreach (var item in person.Reviews)
                {
                    myReviewsForm.reviewListView.Items.Add(new ListViewItem(new string[] { item.subject, item.comment, item.rating.ToString() }));
                }
            }
            myReviewsForm.Show();
        }
        private void HandleUpdateName(object sender, LoginEventArgs e)
        {
            currentUser = e.User;
            label3.Text += currentUser.Email;
        }
    }
}
