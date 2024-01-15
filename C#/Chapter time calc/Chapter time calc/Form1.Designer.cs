﻿namespace Chapter_time_calc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            this.Timing_view = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_time = new System.Windows.Forms.Button();
            this.Time_input = new System.Windows.Forms.TextBox();
            this.Zero_index_check = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Recalculate_times = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Timing_view)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(1, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(198, 64);
            label3.TabIndex = 7;
            label3.Text = "If you make a mistake simply change the \"Run time\" field for the chapter with the" +
    " issue and press the \"Recalculate\" button.";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timing_view
            // 
            this.Timing_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Timing_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.RunTime,
            this.StartTime,
            this.EndTime});
            this.Timing_view.Location = new System.Drawing.Point(12, 10);
            this.Timing_view.Name = "Timing_view";
            this.Timing_view.RowTemplate.Height = 25;
            this.Timing_view.Size = new System.Drawing.Size(443, 937);
            this.Timing_view.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.HeaderText = "Chapter num";
            this.Number.Name = "Number";
            // 
            // RunTime
            // 
            this.RunTime.HeaderText = "Run time";
            this.RunTime.Name = "RunTime";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // Add_time
            // 
            this.Add_time.Location = new System.Drawing.Point(54, 61);
            this.Add_time.Name = "Add_time";
            this.Add_time.Size = new System.Drawing.Size(75, 23);
            this.Add_time.TabIndex = 1;
            this.Add_time.Text = "Add time";
            this.Add_time.UseVisualStyleBackColor = true;
            this.Add_time.Click += new System.EventHandler(this.Add_time_Click);
            // 
            // Time_input
            // 
            this.Time_input.Location = new System.Drawing.Point(40, 32);
            this.Time_input.Name = "Time_input";
            this.Time_input.Size = new System.Drawing.Size(100, 23);
            this.Time_input.TabIndex = 2;
            this.Time_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Time_input_KeyDown);
            // 
            // Zero_index_check
            // 
            this.Zero_index_check.AutoSize = true;
            this.Zero_index_check.Location = new System.Drawing.Point(45, 120);
            this.Zero_index_check.Name = "Zero_index_check";
            this.Zero_index_check.Size = new System.Drawing.Size(95, 19);
            this.Zero_index_check.TabIndex = 3;
            this.Zero_index_check.Text = "Zero indexed";
            this.Zero_index_check.UseVisualStyleBackColor = true;
            this.Zero_index_check.CheckedChanged += new System.EventHandler(this.Zero_index_check_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter time";
            // 
            // Recalculate_times
            // 
            this.Recalculate_times.Location = new System.Drawing.Point(54, 91);
            this.Recalculate_times.Name = "Recalculate_times";
            this.Recalculate_times.Size = new System.Drawing.Size(75, 23);
            this.Recalculate_times.TabIndex = 5;
            this.Recalculate_times.Text = "Recalculate";
            this.Recalculate_times.UseVisualStyleBackColor = true;
            this.Recalculate_times.Click += new System.EventHandler(this.Recalculate_times_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Time_input);
            this.groupBox1.Controls.Add(this.Add_time);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Zero_index_check);
            this.groupBox1.Location = new System.Drawing.Point(504, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "(Select before inputing data)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Recalculate_times);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Location = new System.Drawing.Point(504, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 120);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editing";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 961);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Timing_view);
            this.Name = "Form1";
            this.Text = "Chapter time calculator";
            ((System.ComponentModel.ISupportInitialize)(this.Timing_view)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Timing_view;
        private Button Add_time;
        private TextBox Time_input;
        private CheckBox Zero_index_check;
        private Label label1;
        private Button Recalculate_times;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn RunTime;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
    }
}