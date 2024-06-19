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
            this.labelPaR = new System.Windows.Forms.Label();
            this.labelPR = new System.Windows.Forms.Label();
            this.labelDR = new System.Windows.Forms.Label();
            this.labelPa = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.dataGridViewPair = new System.Windows.Forms.DataGridView();
            this.labelA = new System.Windows.Forms.Label();
            this.labelAR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPaR
            // 
            this.labelPaR.Location = new System.Drawing.Point(192, 88);
            this.labelPaR.Name = "labelPaR";
            this.labelPaR.Size = new System.Drawing.Size(373, 13);
            this.labelPaR.TabIndex = 5;
            this.labelPaR.Text = "время пары";
            // 
            // labelPR
            // 
            this.labelPR.Location = new System.Drawing.Point(192, 54);
            this.labelPR.Name = "labelPR";
            this.labelPR.Size = new System.Drawing.Size(373, 13);
            this.labelPR.TabIndex = 4;
            this.labelPR.Text = "преподаватель";
            // 
            // labelDR
            // 
            this.labelDR.Location = new System.Drawing.Point(192, 13);
            this.labelDR.Name = "labelDR";
            this.labelDR.Size = new System.Drawing.Size(373, 13);
            this.labelDR.TabIndex = 3;
            this.labelDR.Text = "дисциплина";
            // 
            // labelPa
            // 
            this.labelPa.AutoSize = true;
            this.labelPa.Location = new System.Drawing.Point(59, 88);
            this.labelPa.Name = "labelPa";
            this.labelPa.Size = new System.Drawing.Size(72, 13);
            this.labelPa.TabIndex = 2;
            this.labelPa.Text = "Время пары:";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(59, 54);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(89, 13);
            this.labelP.TabIndex = 1;
            this.labelP.Text = "Преподаватель:";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(59, 13);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(73, 13);
            this.labelD.TabIndex = 0;
            this.labelD.Text = "Дисциплина:";
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
            this.dataGridViewPair.Location = new System.Drawing.Point(0, 166);
            this.dataGridViewPair.Name = "dataGridViewPair";
            this.dataGridViewPair.ReadOnly = true;
            this.dataGridViewPair.Size = new System.Drawing.Size(800, 284);
            this.dataGridViewPair.TabIndex = 1;
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(62, 125);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(60, 13);
            this.labelA.TabIndex = 6;
            this.labelA.Text = "Аудитория";
            // 
            // labelAR
            // 
            this.labelAR.AutoSize = true;
            this.labelAR.Location = new System.Drawing.Point(195, 124);
            this.labelAR.Name = "labelAR";
            this.labelAR.Size = new System.Drawing.Size(59, 13);
            this.labelAR.TabIndex = 7;
            this.labelAR.Text = "аудитория";
            // 
            // PairWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAR);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.dataGridViewPair);
            this.Controls.Add(this.labelPaR);
            this.Controls.Add(this.labelPR);
            this.Controls.Add(this.labelDR);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelPa);
            this.Controls.Add(this.labelP);
            this.Name = "PairWindow";
            this.Text = "Окно отображения информации о группе";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelPa;
        private System.Windows.Forms.Label labelPaR;
        private System.Windows.Forms.Label labelPR;
        private System.Windows.Forms.Label labelDR;
        private System.Windows.Forms.DataGridView dataGridViewPair;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelAR;
    }
}