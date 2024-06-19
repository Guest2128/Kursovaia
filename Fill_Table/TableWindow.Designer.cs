namespace Fill_Table {
    partial class TableWindow {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.labelFaculty = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.buttonF = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.AllowUserToDeleteRows = false;
            this.dataGridViewTable.AllowUserToResizeColumns = false;
            this.dataGridViewTable.AllowUserToResizeRows = false;
            this.dataGridViewTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTable.Location = new System.Drawing.Point(259, 124);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.ReadOnly = true;
            this.dataGridViewTable.RowHeadersVisible = false;
            this.dataGridViewTable.Size = new System.Drawing.Size(461, 314);
            this.dataGridViewTable.TabIndex = 0;
            this.dataGridViewTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTable_CellContentDoubleClick);
            this.dataGridViewTable.CurrentCellChanged += new System.EventHandler(this.dataGridViewTable_CurrentCellChanged);
            // 
            // labelFaculty
            // 
            this.labelFaculty.AutoSize = true;
            this.labelFaculty.Location = new System.Drawing.Point(85, 39);
            this.labelFaculty.Name = "labelFaculty";
            this.labelFaculty.Size = new System.Drawing.Size(63, 13);
            this.labelFaculty.TabIndex = 0;
            this.labelFaculty.Text = "факультет:";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(85, 68);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(44, 13);
            this.labelGroup.TabIndex = 1;
            this.labelGroup.Text = "группа:";
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(259, 39);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(273, 21);
            this.comboBoxFaculty.TabIndex = 2;
            this.comboBoxFaculty.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculty_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(259, 68);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(273, 21);
            this.comboBoxGroup.TabIndex = 3;
            // 
            // buttonF
            // 
            this.buttonF.Location = new System.Drawing.Point(645, 36);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(75, 55);
            this.buttonF.TabIndex = 4;
            this.buttonF.Text = "Фильтр";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(44, 124);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            // 
            // TableWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.comboBoxFaculty);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelFaculty);
            this.Name = "TableWindow";
            this.Text = "Окно расписания";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Label labelFaculty;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}