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
            this.groupBoxHeader = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAllR = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.labelActive = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.dataGridViewPair = new System.Windows.Forms.DataGridView();
            this.groupBoxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxHeader
            // 
            this.groupBoxHeader.AutoSize = true;
            this.groupBoxHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxHeader.Controls.Add(this.label2);
            this.groupBoxHeader.Controls.Add(this.label1);
            this.groupBoxHeader.Controls.Add(this.labelAllR);
            this.groupBoxHeader.Controls.Add(this.labelPercent);
            this.groupBoxHeader.Controls.Add(this.labelActive);
            this.groupBoxHeader.Controls.Add(this.labelAll);
            this.groupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxHeader.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHeader.Name = "groupBoxHeader";
            this.groupBoxHeader.Size = new System.Drawing.Size(800, 123);
            this.groupBoxHeader.TabIndex = 0;
            this.groupBoxHeader.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(425, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "процент";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(425, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "студенты на паре";
            // 
            // labelAllR
            // 
            this.labelAllR.Location = new System.Drawing.Point(425, 19);
            this.labelAllR.Name = "labelAllR";
            this.labelAllR.Size = new System.Drawing.Size(100, 13);
            this.labelAllR.TabIndex = 3;
            this.labelAllR.Text = "студенты в группе";
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(292, 94);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(51, 13);
            this.labelPercent.TabIndex = 2;
            this.labelPercent.Text = "процент:";
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Location = new System.Drawing.Point(292, 60);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(36, 13);
            this.labelActive.TabIndex = 1;
            this.labelActive.Text = "было:";
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Location = new System.Drawing.Point(292, 19);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(39, 13);
            this.labelAll.TabIndex = 0;
            this.labelAll.Text = "всего:";
            // 
            // dataGridViewPair
            // 
            this.dataGridViewPair.AllowUserToAddRows = false;
            this.dataGridViewPair.AllowUserToDeleteRows = false;
            this.dataGridViewPair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPair.Location = new System.Drawing.Point(0, 123);
            this.dataGridViewPair.Name = "dataGridViewPair";
            this.dataGridViewPair.ReadOnly = true;
            this.dataGridViewPair.Size = new System.Drawing.Size(800, 327);
            this.dataGridViewPair.TabIndex = 1;
            // 
            // PairWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewPair);
            this.Controls.Add(this.groupBoxHeader);
            this.Name = "PairWindow";
            this.Text = "Окно отображения информации о группе";
            this.groupBoxHeader.ResumeLayout(false);
            this.groupBoxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPair)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHeader;
        private System.Windows.Forms.Label labelAll;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAllR;
        private System.Windows.Forms.DataGridView dataGridViewPair;
    }
}