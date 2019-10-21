namespace University_advisor
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pasirenkamiejiDalykaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.subjectListView = new System.Windows.Forms.ListView();
            this.ListName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MyReviews = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasirenkamiejiDalykaiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pasirenkamiejiDalykaiToolStripMenuItem
            // 
            this.pasirenkamiejiDalykaiToolStripMenuItem.Name = "pasirenkamiejiDalykaiToolStripMenuItem";
            this.pasirenkamiejiDalykaiToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.pasirenkamiejiDalykaiToolStripMenuItem.Text = "Pasirenkamieji dalykai";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // subjectListView
            // 
            this.subjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListName,
            this.ListRating});
            this.subjectListView.GridLines = true;
            this.subjectListView.HideSelection = false;
            this.subjectListView.Location = new System.Drawing.Point(12, 42);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(364, 383);
            this.subjectListView.TabIndex = 3;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            this.subjectListView.SelectedIndexChanged += new System.EventHandler(this.subjectListView_SelectedIndexChanged);
            // 
            // ListName
            // 
            this.ListName.Text = "Dalyko pavadinimas";
            this.ListName.Width = 162;
            // 
            // ListRating
            // 
            this.ListRating.Text = "Įvertinimas";
            this.ListRating.Width = 62;
            // 
            // MyReviews
            // 
            this.MyReviews.Location = new System.Drawing.Point(112, 452);
            this.MyReviews.Name = "MyReviews";
            this.MyReviews.Size = new System.Drawing.Size(161, 23);
            this.MyReviews.TabIndex = 4;
            this.MyReviews.Text = "My reviews";
            this.MyReviews.UseVisualStyleBackColor = true;
            this.MyReviews.Click += new System.EventHandler(this.MyReviews_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 542);
            this.Controls.Add(this.MyReviews);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "University Advisor";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasirenkamiejiDalykaiToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.ColumnHeader ListName;
        private System.Windows.Forms.ColumnHeader ListRating;
        private System.Windows.Forms.Button MyReviews;
    }
}