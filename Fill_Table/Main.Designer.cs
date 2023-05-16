namespace Fill_Table {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridViewT = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.корпусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.турникетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.факультетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специальностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.студентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewT)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewT
            // 
            this.dataGridViewT.AllowUserToAddRows = false;
            this.dataGridViewT.AllowUserToDeleteRows = false;
            this.dataGridViewT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewT.Location = new System.Drawing.Point(13, 39);
            this.dataGridViewT.Name = "dataGridViewT";
            this.dataGridViewT.ReadOnly = true;
            this.dataGridViewT.Size = new System.Drawing.Size(775, 399);
            this.dataGridViewT.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.генерацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.корпусToolStripMenuItem,
            this.турникетToolStripMenuItem,
            this.факультетToolStripMenuItem,
            this.специальностьToolStripMenuItem,
            this.группаToolStripMenuItem,
            this.студентToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // корпусToolStripMenuItem
            // 
            this.корпусToolStripMenuItem.Name = "корпусToolStripMenuItem";
            this.корпусToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.корпусToolStripMenuItem.Text = "Корпус";
            this.корпусToolStripMenuItem.Click += new System.EventHandler(this.корпусToolStripMenuItem_Click);
            // 
            // турникетToolStripMenuItem
            // 
            this.турникетToolStripMenuItem.Name = "турникетToolStripMenuItem";
            this.турникетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.турникетToolStripMenuItem.Text = "Турникет";
            this.турникетToolStripMenuItem.Click += new System.EventHandler(this.турникетToolStripMenuItem_Click);
            // 
            // факультетToolStripMenuItem
            // 
            this.факультетToolStripMenuItem.Name = "факультетToolStripMenuItem";
            this.факультетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.факультетToolStripMenuItem.Text = "Факультет";
            this.факультетToolStripMenuItem.Click += new System.EventHandler(this.факультетToolStripMenuItem_Click);
            // 
            // специальностьToolStripMenuItem
            // 
            this.специальностьToolStripMenuItem.Name = "специальностьToolStripMenuItem";
            this.специальностьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.специальностьToolStripMenuItem.Text = "Специальность";
            this.специальностьToolStripMenuItem.Click += new System.EventHandler(this.специальностьToolStripMenuItem_Click);
            // 
            // группаToolStripMenuItem
            // 
            this.группаToolStripMenuItem.Name = "группаToolStripMenuItem";
            this.группаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.группаToolStripMenuItem.Text = "Группа";
            this.группаToolStripMenuItem.Click += new System.EventHandler(this.группаToolStripMenuItem_Click);
            // 
            // студентToolStripMenuItem
            // 
            this.студентToolStripMenuItem.Name = "студентToolStripMenuItem";
            this.студентToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.студентToolStripMenuItem.Text = "Студент";
            this.студентToolStripMenuItem.Click += new System.EventHandler(this.студентToolStripMenuItem_Click);
            // 
            // генерацияToolStripMenuItem
            // 
            this.генерацияToolStripMenuItem.Name = "генерацияToolStripMenuItem";
            this.генерацияToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.генерацияToolStripMenuItem.Text = "Генерация";
            this.генерацияToolStripMenuItem.Click += new System.EventHandler(this.генерацияToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewT)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem корпусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem турникетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem факультетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem генерацияToolStripMenuItem;
    }
}