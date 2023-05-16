namespace Fill_Table {
    partial class Window {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.labelDS = new System.Windows.Forms.Label();
            this.labelDF = new System.Windows.Forms.Label();
            this.dateTimePickerS = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerF = new System.Windows.Forms.DateTimePicker();
            this.labelDSL = new System.Windows.Forms.Label();
            this.labelDSF = new System.Windows.Forms.Label();
            this.labelKol = new System.Windows.Forms.Label();
            this.textBoxKol = new System.Windows.Forms.TextBox();
            this.buttonGKol = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDS
            // 
            this.labelDS.AutoSize = true;
            this.labelDS.Location = new System.Drawing.Point(22, 28);
            this.labelDS.Name = "labelDS";
            this.labelDS.Size = new System.Drawing.Size(74, 13);
            this.labelDS.TabIndex = 0;
            this.labelDS.Text = "Дата начала:";
            // 
            // labelDF
            // 
            this.labelDF.AutoSize = true;
            this.labelDF.Location = new System.Drawing.Point(22, 63);
            this.labelDF.Name = "labelDF";
            this.labelDF.Size = new System.Drawing.Size(69, 13);
            this.labelDF.TabIndex = 1;
            this.labelDF.Text = "Дата конца:";
            // 
            // dateTimePickerS
            // 
            this.dateTimePickerS.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerS.Location = new System.Drawing.Point(155, 22);
            this.dateTimePickerS.Name = "dateTimePickerS";
            this.dateTimePickerS.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerS.TabIndex = 2;
            this.dateTimePickerS.Value = new System.DateTime(2022, 9, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerF
            // 
            this.dateTimePickerF.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerF.Location = new System.Drawing.Point(155, 57);
            this.dateTimePickerF.Name = "dateTimePickerF";
            this.dateTimePickerF.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerF.TabIndex = 3;
            this.dateTimePickerF.Value = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            // 
            // labelDSL
            // 
            this.labelDSL.AutoSize = true;
            this.labelDSL.Location = new System.Drawing.Point(97, 28);
            this.labelDSL.Name = "labelDSL";
            this.labelDSL.Size = new System.Drawing.Size(38, 13);
            this.labelDSL.TabIndex = 4;
            this.labelDSL.Text = "С 8:00";
            // 
            // labelDSF
            // 
            this.labelDSF.AutoSize = true;
            this.labelDSF.Location = new System.Drawing.Point(97, 63);
            this.labelDSF.Name = "labelDSF";
            this.labelDSF.Size = new System.Drawing.Size(52, 13);
            this.labelDSF.TabIndex = 5;
            this.labelDSF.Text = "До 22:00";
            // 
            // labelKol
            // 
            this.labelKol.AutoSize = true;
            this.labelKol.Location = new System.Drawing.Point(22, 110);
            this.labelKol.Name = "labelKol";
            this.labelKol.Size = new System.Drawing.Size(107, 13);
            this.labelKol.TabIndex = 6;
            this.labelKol.Text = "Количество входов:";
            // 
            // textBoxKol
            // 
            this.textBoxKol.Location = new System.Drawing.Point(155, 107);
            this.textBoxKol.Name = "textBoxKol";
            this.textBoxKol.Size = new System.Drawing.Size(82, 20);
            this.textBoxKol.TabIndex = 7;
            // 
            // buttonGKol
            // 
            this.buttonGKol.Location = new System.Drawing.Point(83, 142);
            this.buttonGKol.Name = "buttonGKol";
            this.buttonGKol.Size = new System.Drawing.Size(93, 23);
            this.buttonGKol.TabIndex = 8;
            this.buttonGKol.Text = "Сгенерировать";
            this.buttonGKol.UseVisualStyleBackColor = true;
            this.buttonGKol.Click += new System.EventHandler(this.buttonGKol_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(83, 212);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(93, 34);
            this.buttonShow.TabIndex = 9;
            this.buttonShow.Text = "Отобразить";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(83, 171);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(93, 35);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Очистить таблицу";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Window
            // 
            this.AcceptButton = this.buttonGKol;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 258);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonGKol);
            this.Controls.Add(this.textBoxKol);
            this.Controls.Add(this.labelKol);
            this.Controls.Add(this.labelDSF);
            this.Controls.Add(this.labelDSL);
            this.Controls.Add(this.dateTimePickerF);
            this.Controls.Add(this.dateTimePickerS);
            this.Controls.Add(this.labelDF);
            this.Controls.Add(this.labelDS);
            this.Name = "Window";
            this.Text = "Окно генерации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDS;
        private System.Windows.Forms.Label labelDF;
        private System.Windows.Forms.DateTimePicker dateTimePickerS;
        private System.Windows.Forms.DateTimePicker dateTimePickerF;
        private System.Windows.Forms.Label labelDSL;
        private System.Windows.Forms.Label labelDSF;
        private System.Windows.Forms.Label labelKol;
        private System.Windows.Forms.TextBox textBoxKol;
        private System.Windows.Forms.Button buttonGKol;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonClear;
    }
}
