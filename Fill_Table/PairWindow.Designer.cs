namespace Fill_Table {
    partial class PairWindow {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAllR = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.dataGridViewPair = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "процент";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(202, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "студенты на паре";
            // 
            // labelAllR
            // 
            this.labelAllR.Location = new System.Drawing.Point(202, 28);
            this.labelAllR.Name = "labelAllR";
            this.labelAllR.Size = new System.Drawing.Size(100, 13);
            this.labelAllR.TabIndex = 3;
            this.labelAllR.Text = "студенты в группе";
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(69, 103);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(51, 13);
            this.labelPercent.TabIndex = 2;
            this.labelPercent.Text = "процент:";
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Location = new System.Drawing.Point(69, 69);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(36, 13);
            this.labelActive.TabIndex = 1;
            this.labelActive.Text = "было:";
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Location = new System.Drawing.Point(69, 28);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(39, 13);
            this.labelAll.TabIndex = 0;
            this.labelAll.Text = "всего:";
            // 
            // dataGridViewPair
            // 
            this.dataGridViewPair.AllowUserToAddRows = false;
            this.dataGridViewPair.AllowUserToDeleteRows = false;
            this.dataGridViewPair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPair.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPair.Location = new System.Drawing.Point(0, 137);
            this.dataGridViewPair.Name = "dataGridViewPair";
            this.dataGridViewPair.ReadOnly = true;
            this.dataGridViewPair.Size = new System.Drawing.Size(800, 313);
            this.dataGridViewPair.TabIndex = 1;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(661, 65);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 6;
            this.button.Text = "Отобразить";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "dd.MM.yyyy";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(426, 64);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(80, 20);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.Value = new System.DateTime(2022, 9, 1, 0, 0, 0, 0);
            // 
            // PairWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dataGridViewPair);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAllR);
            this.Controls.Add(this.labelAll);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.labelActive);
            this.Name = "PairWindow";
            this.Text = "Окно отображения информации о группе";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAll;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAllR;
        private System.Windows.Forms.DataGridView dataGridViewPair;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}