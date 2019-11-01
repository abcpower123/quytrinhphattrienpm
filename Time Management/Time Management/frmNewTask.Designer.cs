namespace Time_Management
{
    partial class frmNewTask
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewTask));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lbTimeNoti = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbbTimeNoti = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLapLai = new System.Windows.Forms.Label();
            this.cbbLapLai = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnVienUsual = new System.Windows.Forms.Panel();
            this.pnUsual = new System.Windows.Forms.Panel();
            this.pnVienMedium = new System.Windows.Forms.Panel();
            this.pnMedium = new System.Windows.Forms.Panel();
            this.pnVienImportant = new System.Windows.Forms.Panel();
            this.pnImportant = new System.Windows.Forms.Panel();
            this.lbImportant = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnVienUsual.SuspendLayout();
            this.pnVienMedium.SuspendLayout();
            this.pnVienImportant.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên công việc";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource1, "Date", true));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 23);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Time_Management.Work);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thời gian";
            // 
            // lbTimeNoti
            // 
            this.lbTimeNoti.AutoSize = true;
            this.lbTimeNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeNoti.Location = new System.Drawing.Point(365, 147);
            this.lbTimeNoti.Name = "lbTimeNoti";
            this.lbTimeNoti.Size = new System.Drawing.Size(193, 17);
            this.lbTimeNoti.TabIndex = 2;
            this.lbTimeNoti.Text = "Thời gian cần nhắc nhở trước";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chi tiết công việc";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Name", true));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(131, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(571, 23);
            this.textBox1.TabIndex = 1;
            // 
            // cbbTimeNoti
            // 
            this.cbbTimeNoti.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource1, "TimeNotify", true));
            this.cbbTimeNoti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTimeNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTimeNoti.FormattingEnabled = true;
            this.cbbTimeNoti.Items.AddRange(new object[] {
            "Trong ngày",
            "Trong tuần",
            "Trong tháng",
            "Trong năm"});
            this.cbbTimeNoti.Location = new System.Drawing.Point(581, 144);
            this.cbbTimeNoti.Name = "cbbTimeNoti";
            this.cbbTimeNoti.Size = new System.Drawing.Size(121, 24);
            this.cbbTimeNoti.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Phân loại";
            // 
            // lblLapLai
            // 
            this.lblLapLai.AutoSize = true;
            this.lblLapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapLai.Location = new System.Drawing.Point(508, 104);
            this.lblLapLai.Name = "lblLapLai";
            this.lblLapLai.Size = new System.Drawing.Size(50, 17);
            this.lblLapLai.TabIndex = 2;
            this.lblLapLai.Text = "Lặp lại";
            // 
            // cbbLapLai
            // 
            this.cbbLapLai.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource1, "Recurrence", true));
            this.cbbLapLai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLapLai.FormattingEnabled = true;
            this.cbbLapLai.Items.AddRange(new object[] {
            "1 lần",
            "Hàng ngày",
            "Hàng tuần",
            "Hàng tháng",
            "Hàng năm"});
            this.cbbLapLai.Location = new System.Drawing.Point(582, 101);
            this.cbbLapLai.Name = "cbbLapLai";
            this.cbbLapLai.Size = new System.Drawing.Size(121, 24);
            this.cbbLapLai.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnVienUsual);
            this.groupBox1.Controls.Add(this.pnVienMedium);
            this.groupBox1.Controls.Add(this.pnVienImportant);
            this.groupBox1.Controls.Add(this.lbImportant);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(454, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 105);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mức quan trọng";
            // 
            // pnVienUsual
            // 
            this.pnVienUsual.Controls.Add(this.pnUsual);
            this.pnVienUsual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnVienUsual.Location = new System.Drawing.Point(186, 25);
            this.pnVienUsual.Name = "pnVienUsual";
            this.pnVienUsual.Size = new System.Drawing.Size(63, 42);
            this.pnVienUsual.TabIndex = 11;
            // 
            // pnUsual
            // 
            this.pnUsual.BackColor = System.Drawing.Color.Lime;
            this.pnUsual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnUsual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnUsual.Location = new System.Drawing.Point(5, 5);
            this.pnUsual.Name = "pnUsual";
            this.pnUsual.Size = new System.Drawing.Size(53, 32);
            this.pnUsual.TabIndex = 7;
            this.pnUsual.Click += new System.EventHandler(this.pnUsual_Click);
            // 
            // pnVienMedium
            // 
            this.pnVienMedium.Controls.Add(this.pnMedium);
            this.pnVienMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnVienMedium.Location = new System.Drawing.Point(103, 25);
            this.pnVienMedium.Name = "pnVienMedium";
            this.pnVienMedium.Size = new System.Drawing.Size(63, 42);
            this.pnVienMedium.TabIndex = 10;
            // 
            // pnMedium
            // 
            this.pnMedium.BackColor = System.Drawing.Color.Yellow;
            this.pnMedium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnMedium.Location = new System.Drawing.Point(5, 5);
            this.pnMedium.Name = "pnMedium";
            this.pnMedium.Size = new System.Drawing.Size(53, 32);
            this.pnMedium.TabIndex = 7;
            this.pnMedium.Click += new System.EventHandler(this.pnMedium_Click);
            // 
            // pnVienImportant
            // 
            this.pnVienImportant.Controls.Add(this.pnImportant);
            this.pnVienImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnVienImportant.Location = new System.Drawing.Point(15, 25);
            this.pnVienImportant.Name = "pnVienImportant";
            this.pnVienImportant.Size = new System.Drawing.Size(63, 42);
            this.pnVienImportant.TabIndex = 9;
            // 
            // pnImportant
            // 
            this.pnImportant.BackColor = System.Drawing.Color.Red;
            this.pnImportant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnImportant.Location = new System.Drawing.Point(5, 5);
            this.pnImportant.Name = "pnImportant";
            this.pnImportant.Size = new System.Drawing.Size(53, 32);
            this.pnImportant.TabIndex = 7;
            this.pnImportant.Click += new System.EventHandler(this.pnImportant_Click);
            // 
            // lbImportant
            // 
            this.lbImportant.AutoSize = true;
            this.lbImportant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportant.Location = new System.Drawing.Point(103, 74);
            this.lbImportant.Name = "lbImportant";
            this.lbImportant.Size = new System.Drawing.Size(80, 17);
            this.lbImportant.TabIndex = 8;
            this.lbImportant.Text = "Quan trọng";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Category", true));
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Gia đình",
            "Bạn bè",
            "Công việc"});
            this.comboBox3.Location = new System.Drawing.Point(131, 98);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(154, 24);
            this.comboBox3.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Detail", true));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(31, 204);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(373, 92);
            this.textBox3.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(608, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 21);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Bật nhắc nhở";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(167, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(454, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.cbbLapLai);
            this.Controls.Add(this.cbbTimeNoti);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLapLai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTimeNoti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTask";
            this.Text = "Chi tiết công việc";
            this.Load += new System.EventHandler(this.frmNewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnVienUsual.ResumeLayout(false);
            this.pnVienMedium.ResumeLayout(false);
            this.pnVienImportant.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTimeNoti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbbTimeNoti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLapLai;
        private System.Windows.Forms.ComboBox cbbLapLai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbImportant;
        private System.Windows.Forms.Panel pnUsual;
        private System.Windows.Forms.Panel pnImportant;
        private System.Windows.Forms.Panel pnMedium;
        private System.Windows.Forms.Panel pnVienImportant;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel pnVienUsual;
        private System.Windows.Forms.Panel pnVienMedium;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}