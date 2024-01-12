namespace Chapter_time_calc
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
            this.Timing_view = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_time = new System.Windows.Forms.Button();
            this.Time_input = new System.Windows.Forms.TextBox();
            this.Zero_index_check = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Timing_view)).BeginInit();
            this.SuspendLayout();
            // 
            // Timing_view
            // 
            this.Timing_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Timing_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.RunTime,
            this.StartTime,
            this.EndTime});
            this.Timing_view.Location = new System.Drawing.Point(12, 12);
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
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End time";
            this.EndTime.Name = "EndTime";
            // 
            // Add_time
            // 
            this.Add_time.Location = new System.Drawing.Point(562, 162);
            this.Add_time.Name = "Add_time";
            this.Add_time.Size = new System.Drawing.Size(75, 23);
            this.Add_time.TabIndex = 1;
            this.Add_time.Text = "Add time";
            this.Add_time.UseVisualStyleBackColor = true;
            this.Add_time.Click += new System.EventHandler(this.Add_time_Click);
            // 
            // Time_input
            // 
            this.Time_input.Location = new System.Drawing.Point(548, 133);
            this.Time_input.Name = "Time_input";
            this.Time_input.Size = new System.Drawing.Size(100, 23);
            this.Time_input.TabIndex = 2;
            this.Time_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Time_input_KeyDown);
            // 
            // Zero_index_check
            // 
            this.Zero_index_check.AutoSize = true;
            this.Zero_index_check.Location = new System.Drawing.Point(553, 217);
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
            this.label1.Location = new System.Drawing.Point(562, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 961);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zero_index_check);
            this.Controls.Add(this.Time_input);
            this.Controls.Add(this.Add_time);
            this.Controls.Add(this.Timing_view);
            this.Name = "Form1";
            this.Text = "Chapter time calculator";
            ((System.ComponentModel.ISupportInitialize)(this.Timing_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView Timing_view;
        private Button Add_time;
        private TextBox Time_input;
        private CheckBox Zero_index_check;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn RunTime;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private Label label1;
    }
}