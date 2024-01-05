namespace Fill_Table {
    partial class AddInfo {
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
            this.label = new System.Windows.Forms.Label();
            this.dataGridViewAdd = new System.Windows.Forms.DataGridView();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(42, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 13);
            this.label.TabIndex = 0;
            this.label.Text = "labelName";
            // 
            // dataGridViewAdd
            // 
            this.dataGridViewAdd.AllowUserToAddRows = false;
            this.dataGridViewAdd.AllowUserToDeleteRows = false;
            this.dataGridViewAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdd.Location = new System.Drawing.Point(0, 72);
            this.dataGridViewAdd.Name = "dataGridViewAdd";
            this.dataGridViewAdd.ReadOnly = true;
            this.dataGridViewAdd.Size = new System.Drawing.Size(800, 378);
            this.dataGridViewAdd.TabIndex = 1;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(250, 25);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(372, 21);
            this.comboBox.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(689, 23);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.dataGridViewAdd);
            this.Controls.Add(this.label);
            this.Name = "AddInfo";
            this.Text = "Добавить";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dataGridViewAdd;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button buttonAdd;
    }
}