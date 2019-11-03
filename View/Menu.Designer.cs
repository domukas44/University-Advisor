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
            this.sortComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReviewsBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasirenkamiejiDalykaiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(924, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pasirenkamiejiDalykaiToolStripMenuItem
            // 
            this.pasirenkamiejiDalykaiToolStripMenuItem.Name = "pasirenkamiejiDalykaiToolStripMenuItem";
            this.pasirenkamiejiDalykaiToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.pasirenkamiejiDalykaiToolStripMenuItem.Text = "Išsamiau apie dalyką";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 22);
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
            this.subjectListView.Location = new System.Drawing.Point(16, 94);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(4);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(891, 526);
            this.subjectListView.TabIndex = 3;
            this.subjectListView.UseCompatibleStateImageBehavior = false;
            this.subjectListView.View = System.Windows.Forms.View.Details;
            this.subjectListView.SelectedIndexChanged += new System.EventHandler(this.subjectListView_SelectedIndexChanged);
            // 
            // ListName
            // 
            this.ListName.Text = "Dalyko pavadinimas";
            this.ListName.Width = 196;
            // 
            // ListRating
            // 
            this.ListRating.Text = "Įvertinimas";
            this.ListRating.Width = 62;
            // 
            // sortComboBox
            // 
            this.sortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortComboBox.FormattingEnabled = true;
            this.sortComboBox.Items.AddRange(new object[] {
            "Dalyko pavadinimas (Z - A)",
            "Įvertinimas (max - min)"});
            this.sortComboBox.Location = new System.Drawing.Point(335, 44);
            this.sortComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.Size = new System.Drawing.Size(207, 24);
            this.sortComboBox.TabIndex = 4;
            this.sortComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSortIndexChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rikiavimas: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(260, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paieška: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prisijungimo vardas: ";
            // 
            // ReviewsBtn
            // 
            this.ReviewsBtn.Location = new System.Drawing.Point(807, 37);
            this.ReviewsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ReviewsBtn.Name = "ReviewsBtn";
            this.ReviewsBtn.Size = new System.Drawing.Size(100, 28);
            this.ReviewsBtn.TabIndex = 7;
            this.ReviewsBtn.Text = "My reviews";
            this.ReviewsBtn.UseVisualStyleBackColor = true;
            this.ReviewsBtn.Click += new System.EventHandler(this.ReviewsBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rikiuoti:";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 633);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ReviewsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sortComboBox);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView subjectListView;
        private System.Windows.Forms.ColumnHeader ListName;
        private System.Windows.Forms.ColumnHeader ListRating;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.ToolStripMenuItem pasirenkamiejiDalykaiToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ReviewsBtn;
        private System.Windows.Forms.Label label4;
    }
}
