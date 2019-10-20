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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasirenkamiejiDalykaiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pasirenkamiejiDalykaiToolStripMenuItem
            // 
            this.pasirenkamiejiDalykaiToolStripMenuItem.Name = "pasirenkamiejiDalykaiToolStripMenuItem";
            this.pasirenkamiejiDalykaiToolStripMenuItem.Size = new System.Drawing.Size(198, 29);
            this.pasirenkamiejiDalykaiToolStripMenuItem.Text = "Pasirenkamieji dalykai";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(376, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 26);
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
            this.subjectListView.Location = new System.Drawing.Point(18, 108);
            this.subjectListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subjectListView.Name = "subjectListView";
            this.subjectListView.Size = new System.Drawing.Size(544, 544);
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
            // sortComboBox
            // 
            this.sortComboBox.FormattingEnabled = true;
            this.sortComboBox.Items.AddRange(new object[] {
            "Dalyko pavadinimas (Z - A)",
            "Įvertinimas (max - min)"});
            this.sortComboBox.Location = new System.Drawing.Point(376, 56);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.Size = new System.Drawing.Size(186, 28);
            this.sortComboBox.TabIndex = 4;
            this.sortComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSortIndexChange);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 692);
            this.Controls.Add(this.sortComboBox);
            this.Controls.Add(this.subjectListView);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}