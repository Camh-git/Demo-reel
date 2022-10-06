namespace WindowsFormsApplication35
{
    partial class EmptyView
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
            this.Connect = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.DataGridView();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeSalaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeAgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vp_employeesDataSet = new WindowsFormsApplication35.Vp_employeesDataSet();
            this.table1TableAdapter = new WindowsFormsApplication35.Vp_employeesDataSetTableAdapters.Table1TableAdapter();
            this.Add = new System.Windows.Forms.Button();
            this.Sort = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.Individual = new System.Windows.Forms.Button();
            this.IndivBox = new System.Windows.Forms.GroupBox();
            this.Previous = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.IndivAge = new System.Windows.Forms.TextBox();
            this.IndivSalary = new System.Windows.Forms.TextBox();
            this.IndivDept = new System.Windows.Forms.TextBox();
            this.IndivName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IndivID = new System.Windows.Forms.TextBox();
            this.IndivHide = new System.Windows.Forms.Button();
            this.HelpBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.HelpHide = new System.Windows.Forms.Button();
            this.PrintTarget = new System.Windows.Forms.TextBox();
            this.PrintBox = new System.Windows.Forms.GroupBox();
            this.PrintHIde = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.GroupBox();
            this.SearchNow = new System.Windows.Forms.Button();
            this.HideSearch = new System.Windows.Forms.Button();
            this.Searchtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vp_employeesDataSet)).BeginInit();
            this.IndivBox.SuspendLayout();
            this.HelpBox.SuspendLayout();
            this.PrintBox.SuspendLayout();
            this.SearchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(219, 172);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Data
            // 
            this.Data.AutoGenerateColumns = false;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIdDataGridViewTextBoxColumn,
            this.employeeNameDataGridViewTextBoxColumn,
            this.employeeDepartmentDataGridViewTextBoxColumn,
            this.employeeSalaryDataGridViewTextBoxColumn,
            this.employeeAgeDataGridViewTextBoxColumn});
            this.Data.DataSource = this.table1BindingSource;
            this.Data.Location = new System.Drawing.Point(6, 10);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(543, 150);
            this.Data.TabIndex = 1;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "Employee id";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "Employee id";
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "Employee name";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "Employee name";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            // 
            // employeeDepartmentDataGridViewTextBoxColumn
            // 
            this.employeeDepartmentDataGridViewTextBoxColumn.DataPropertyName = "Employee Department";
            this.employeeDepartmentDataGridViewTextBoxColumn.HeaderText = "Employee Department";
            this.employeeDepartmentDataGridViewTextBoxColumn.Name = "employeeDepartmentDataGridViewTextBoxColumn";
            // 
            // employeeSalaryDataGridViewTextBoxColumn
            // 
            this.employeeSalaryDataGridViewTextBoxColumn.DataPropertyName = "Employee salary";
            this.employeeSalaryDataGridViewTextBoxColumn.HeaderText = "Employee salary";
            this.employeeSalaryDataGridViewTextBoxColumn.Name = "employeeSalaryDataGridViewTextBoxColumn";
            // 
            // employeeAgeDataGridViewTextBoxColumn
            // 
            this.employeeAgeDataGridViewTextBoxColumn.DataPropertyName = "employee age";
            this.employeeAgeDataGridViewTextBoxColumn.HeaderText = "employee age";
            this.employeeAgeDataGridViewTextBoxColumn.Name = "employeeAgeDataGridViewTextBoxColumn";
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "Table1";
            this.table1BindingSource.DataSource = this.vp_employeesDataSet;
            this.table1BindingSource.CurrentChanged += new System.EventHandler(this.table1BindingSource_CurrentChanged);
            // 
            // vp_employeesDataSet
            // 
            this.vp_employeesDataSet.DataSetName = "Vp_employeesDataSet";
            this.vp_employeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(64, 227);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 2;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Sort
            // 
            this.Sort.Location = new System.Drawing.Point(285, 227);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(75, 23);
            this.Sort.TabIndex = 4;
            this.Sort.Text = "Sort";
            this.Sort.UseVisualStyleBackColor = true;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(145, 227);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 5;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(64, 256);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 6;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(145, 256);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(209, 281);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(75, 23);
            this.Help.TabIndex = 16;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(366, 256);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 18;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.button1_Click);
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(367, 227);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(75, 23);
            this.Print.TabIndex = 20;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.button3_Click);
            // 
            // Individual
            // 
            this.Individual.Location = new System.Drawing.Point(285, 256);
            this.Individual.Name = "Individual";
            this.Individual.Size = new System.Drawing.Size(75, 23);
            this.Individual.TabIndex = 22;
            this.Individual.Text = "Individual";
            this.Individual.UseVisualStyleBackColor = true;
            this.Individual.Click += new System.EventHandler(this.Individual_Click);
            // 
            // IndivBox
            // 
            this.IndivBox.Controls.Add(this.Previous);
            this.IndivBox.Controls.Add(this.Next);
            this.IndivBox.Controls.Add(this.IndivAge);
            this.IndivBox.Controls.Add(this.IndivSalary);
            this.IndivBox.Controls.Add(this.IndivDept);
            this.IndivBox.Controls.Add(this.IndivName);
            this.IndivBox.Controls.Add(this.label8);
            this.IndivBox.Controls.Add(this.label7);
            this.IndivBox.Controls.Add(this.label6);
            this.IndivBox.Controls.Add(this.label5);
            this.IndivBox.Controls.Add(this.label4);
            this.IndivBox.Controls.Add(this.label3);
            this.IndivBox.Controls.Add(this.IndivID);
            this.IndivBox.Controls.Add(this.IndivHide);
            this.IndivBox.Location = new System.Drawing.Point(145, 98);
            this.IndivBox.Name = "IndivBox";
            this.IndivBox.Size = new System.Drawing.Size(256, 171);
            this.IndivBox.TabIndex = 16;
            this.IndivBox.TabStop = false;
            this.IndivBox.Text = "Individual";
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(166, 83);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(75, 23);
            this.Previous.TabIndex = 26;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(166, 45);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 25;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // IndivAge
            // 
            this.IndivAge.Location = new System.Drawing.Point(46, 129);
            this.IndivAge.Name = "IndivAge";
            this.IndivAge.Size = new System.Drawing.Size(100, 20);
            this.IndivAge.TabIndex = 24;
            // 
            // IndivSalary
            // 
            this.IndivSalary.Location = new System.Drawing.Point(46, 108);
            this.IndivSalary.Name = "IndivSalary";
            this.IndivSalary.Size = new System.Drawing.Size(100, 20);
            this.IndivSalary.TabIndex = 23;
            // 
            // IndivDept
            // 
            this.IndivDept.Location = new System.Drawing.Point(46, 86);
            this.IndivDept.Name = "IndivDept";
            this.IndivDept.Size = new System.Drawing.Size(100, 20);
            this.IndivDept.TabIndex = 22;
            // 
            // IndivName
            // 
            this.IndivName.Location = new System.Drawing.Point(46, 64);
            this.IndivName.Name = "IndivName";
            this.IndivName.Size = new System.Drawing.Size(100, 20);
            this.IndivName.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Age";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Salary";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Dept";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Welcome, feel free to view";
            // 
            // IndivID
            // 
            this.IndivID.Location = new System.Drawing.Point(46, 42);
            this.IndivID.Name = "IndivID";
            this.IndivID.Size = new System.Drawing.Size(100, 20);
            this.IndivID.TabIndex = 10;
            this.IndivID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // IndivHide
            // 
            this.IndivHide.Location = new System.Drawing.Point(166, 126);
            this.IndivHide.Name = "IndivHide";
            this.IndivHide.Size = new System.Drawing.Size(75, 23);
            this.IndivHide.TabIndex = 10;
            this.IndivHide.Text = "Hide";
            this.IndivHide.UseVisualStyleBackColor = true;
            this.IndivHide.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // HelpBox
            // 
            this.HelpBox.Controls.Add(this.label14);
            this.HelpBox.Controls.Add(this.label13);
            this.HelpBox.Controls.Add(this.label12);
            this.HelpBox.Controls.Add(this.label11);
            this.HelpBox.Controls.Add(this.label10);
            this.HelpBox.Controls.Add(this.label9);
            this.HelpBox.Controls.Add(this.HelpHide);
            this.HelpBox.Location = new System.Drawing.Point(165, 138);
            this.HelpBox.Name = "HelpBox";
            this.HelpBox.Size = new System.Drawing.Size(200, 162);
            this.HelpBox.TabIndex = 24;
            this.HelpBox.TabStop = false;
            this.HelpBox.Text = "Help";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Headings in the data grid";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = " The data can be sorted by using the";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "using the indvidual button";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = " You can view entries individualy by";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Click on the data grid then press update";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "In order to add, edit or delete data";
            // 
            // HelpHide
            // 
            this.HelpHide.Location = new System.Drawing.Point(60, 133);
            this.HelpHide.Name = "HelpHide";
            this.HelpHide.Size = new System.Drawing.Size(75, 23);
            this.HelpHide.TabIndex = 16;
            this.HelpHide.Text = "Hide";
            this.HelpHide.UseVisualStyleBackColor = true;
            this.HelpHide.Click += new System.EventHandler(this.HelpHide_Click);
            // 
            // PrintTarget
            // 
            this.PrintTarget.Location = new System.Drawing.Point(69, 26);
            this.PrintTarget.Multiline = true;
            this.PrintTarget.Name = "PrintTarget";
            this.PrintTarget.Size = new System.Drawing.Size(100, 20);
            this.PrintTarget.TabIndex = 25;
            // 
            // PrintBox
            // 
            this.PrintBox.Controls.Add(this.label15);
            this.PrintBox.Controls.Add(this.PrintHIde);
            this.PrintBox.Controls.Add(this.PrintTarget);
            this.PrintBox.Location = new System.Drawing.Point(177, 96);
            this.PrintBox.Name = "PrintBox";
            this.PrintBox.Size = new System.Drawing.Size(183, 88);
            this.PrintBox.TabIndex = 26;
            this.PrintBox.TabStop = false;
            this.PrintBox.Text = "Print";
            // 
            // PrintHIde
            // 
            this.PrintHIde.Location = new System.Drawing.Point(52, 52);
            this.PrintHIde.Name = "PrintHIde";
            this.PrintHIde.Size = new System.Drawing.Size(75, 23);
            this.PrintHIde.TabIndex = 27;
            this.PrintHIde.Text = "Hide";
            this.PrintHIde.UseVisualStyleBackColor = true;
            this.PrintHIde.Click += new System.EventHandler(this.PrintHIde_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Names:";
            // 
            // SearchBox
            // 
            this.SearchBox.Controls.Add(this.label1);
            this.SearchBox.Controls.Add(this.Searchtext);
            this.SearchBox.Controls.Add(this.HideSearch);
            this.SearchBox.Controls.Add(this.SearchNow);
            this.SearchBox.Location = new System.Drawing.Point(166, 130);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(200, 100);
            this.SearchBox.TabIndex = 27;
            this.SearchBox.TabStop = false;
            this.SearchBox.Text = "Search";
            // 
            // SearchNow
            // 
            this.SearchNow.Location = new System.Drawing.Point(18, 71);
            this.SearchNow.Name = "SearchNow";
            this.SearchNow.Size = new System.Drawing.Size(75, 23);
            this.SearchNow.TabIndex = 0;
            this.SearchNow.Text = "Search";
            this.SearchNow.UseVisualStyleBackColor = true;
            this.SearchNow.Click += new System.EventHandler(this.SearchNow_Click);
            // 
            // HideSearch
            // 
            this.HideSearch.Location = new System.Drawing.Point(108, 71);
            this.HideSearch.Name = "HideSearch";
            this.HideSearch.Size = new System.Drawing.Size(75, 23);
            this.HideSearch.TabIndex = 1;
            this.HideSearch.Text = "Hide";
            this.HideSearch.UseVisualStyleBackColor = true;
            this.HideSearch.Click += new System.EventHandler(this.HideSearch_Click);
            // 
            // Searchtext
            // 
            this.Searchtext.Location = new System.Drawing.Point(49, 39);
            this.Searchtext.Name = "Searchtext";
            this.Searchtext.Size = new System.Drawing.Size(100, 20);
            this.Searchtext.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter the term you want to search for";
            // 
            // EmptyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication35.Properties.Resources.databasepic;
            this.ClientSize = new System.Drawing.Size(559, 323);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.IndivBox);
            this.Controls.Add(this.HelpBox);
            this.Controls.Add(this.PrintBox);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.Individual);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Connect);
            this.Name = "EmptyView";
            this.Text = "Employee Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vp_employeesDataSet)).EndInit();
            this.IndivBox.ResumeLayout(false);
            this.IndivBox.PerformLayout();
            this.HelpBox.ResumeLayout(false);
            this.HelpBox.PerformLayout();
            this.PrintBox.ResumeLayout(false);
            this.PrintBox.PerformLayout();
            this.SearchBox.ResumeLayout(false);
            this.SearchBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.DataGridView Data;
        private Vp_employeesDataSet vp_employeesDataSet;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private Vp_employeesDataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Sort;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button Individual;
        private System.Windows.Forms.GroupBox IndivBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IndivID;
        private System.Windows.Forms.Button IndivHide;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TextBox IndivAge;
        private System.Windows.Forms.TextBox IndivSalary;
        private System.Windows.Forms.TextBox IndivDept;
        private System.Windows.Forms.TextBox IndivName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox HelpBox;
        private System.Windows.Forms.Button HelpHide;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeSalaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeAgeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PrintTarget;
        private System.Windows.Forms.GroupBox PrintBox;
        private System.Windows.Forms.Button PrintHIde;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox SearchBox;
        private System.Windows.Forms.Button HideSearch;
        private System.Windows.Forms.Button SearchNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Searchtext;
    }
}

