namespace Fill_Table {
    partial class Info {
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
            this.labelT = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.comboBoxT = new System.Windows.Forms.ComboBox();
            this.comboBoxS = new System.Windows.Forms.ComboBox();
            this.buttonF = new System.Windows.Forms.Button();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.textBoxS = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewT)).BeginInit();
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
            this.dataGridViewT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewT.Location = new System.Drawing.Point(0, 59);
            this.dataGridViewT.Name = "dataGridViewT";
            this.dataGridViewT.ReadOnly = true;
            this.dataGridViewT.Size = new System.Drawing.Size(643, 252);
            this.dataGridViewT.TabIndex = 0;
            // 
            // labelT
            // 
            this.labelT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(271, 8);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(57, 13);
            this.labelT.TabIndex = 1;
            this.labelT.Text = "Турникет:";
            // 
            // labelS
            // 
            this.labelS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(278, 35);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(50, 13);
            this.labelS.TabIndex = 2;
            this.labelS.Text = "Студент:";
            // 
            // comboBoxT
            // 
            this.comboBoxT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxT.FormattingEnabled = true;
            this.comboBoxT.Items.AddRange(new object[] {
            "все",
            "конкретный"});
            this.comboBoxT.Location = new System.Drawing.Point(349, 5);
            this.comboBoxT.Name = "comboBoxT";
            this.comboBoxT.Size = new System.Drawing.Size(70, 21);
            this.comboBoxT.TabIndex = 3;
            this.comboBoxT.Text = "все";
            this.comboBoxT.SelectedIndexChanged += new System.EventHandler(this.comboBoxT_SelectedIndexChanged);
            // 
            // comboBoxS
            // 
            this.comboBoxS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxS.FormattingEnabled = true;
            this.comboBoxS.Items.AddRange(new object[] {
            "все",
            "конкретный"});
            this.comboBoxS.Location = new System.Drawing.Point(349, 32);
            this.comboBoxS.Name = "comboBoxS";
            this.comboBoxS.Size = new System.Drawing.Size(70, 21);
            this.comboBoxS.TabIndex = 4;
            this.comboBoxS.Text = "все";
            this.comboBoxS.SelectedIndexChanged += new System.EventHandler(this.comboBoxS_SelectedIndexChanged);
            // 
            // buttonF
            // 
            this.buttonF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonF.Location = new System.Drawing.Point(526, 12);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(105, 36);
            this.buttonF.TabIndex = 5;
            this.buttonF.Text = "Фильтр";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // textBoxT
            // 
            this.textBoxT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxT.Location = new System.Drawing.Point(436, 6);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(62, 20);
            this.textBoxT.TabIndex = 6;
            // 
            // textBoxS
            // 
            this.textBoxS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxS.Location = new System.Drawing.Point(436, 33);
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(62, 20);
            this.textBoxS.TabIndex = 7;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(643, 312);
            this.Controls.Add(this.textBoxS);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.comboBoxS);
            this.Controls.Add(this.comboBoxT);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.dataGridViewT);
            this.Name = "Info";
            this.Opacity = 0.9D;
            this.Text = "Информация о генерации";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewT;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.ComboBox comboBoxT;
        private System.Windows.Forms.ComboBox comboBoxS;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.TextBox textBoxS;
    }
}