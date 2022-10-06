namespace Mission_name_generator
{
    partial class Place_name_generator
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
            this.Generate_place_BTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Prefix_display = new System.Windows.Forms.TextBox();
            this.Suffix_display = new System.Windows.Forms.TextBox();
            this.Place_name_display = new System.Windows.Forms.TextBox();
            this.Save_place_BTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Number_display = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Min_place_num = new System.Windows.Forms.NumericUpDown();
            this.Max_place_num = new System.Windows.Forms.NumericUpDown();
            this.Save_place_and_num_BTN = new System.Windows.Forms.Button();
            this.Component_watcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.Min_place_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Max_place_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate_place_BTN
            // 
            this.Generate_place_BTN.Location = new System.Drawing.Point(120, 177);
            this.Generate_place_BTN.Name = "Generate_place_BTN";
            this.Generate_place_BTN.Size = new System.Drawing.Size(75, 37);
            this.Generate_place_BTN.TabIndex = 0;
            this.Generate_place_BTN.Text = "Generate place";
            this.Generate_place_BTN.UseVisualStyleBackColor = true;
            this.Generate_place_BTN.Click += new System.EventHandler(this.Generate_place_BTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Place name generator";
            // 
            // Prefix_display
            // 
            this.Prefix_display.Location = new System.Drawing.Point(79, 146);
            this.Prefix_display.Name = "Prefix_display";
            this.Prefix_display.Size = new System.Drawing.Size(100, 20);
            this.Prefix_display.TabIndex = 2;
            // 
            // Suffix_display
            // 
            this.Suffix_display.Location = new System.Drawing.Point(196, 146);
            this.Suffix_display.Name = "Suffix_display";
            this.Suffix_display.Size = new System.Drawing.Size(100, 20);
            this.Suffix_display.TabIndex = 3;
            // 
            // Place_name_display
            // 
            this.Place_name_display.Location = new System.Drawing.Point(100, 220);
            this.Place_name_display.Name = "Place_name_display";
            this.Place_name_display.Size = new System.Drawing.Size(112, 20);
            this.Place_name_display.TabIndex = 4;
            this.Place_name_display.Text = "Result will appear here";
            // 
            // Save_place_BTN
            // 
            this.Save_place_BTN.Location = new System.Drawing.Point(76, 246);
            this.Save_place_BTN.Name = "Save_place_BTN";
            this.Save_place_BTN.Size = new System.Drawing.Size(75, 37);
            this.Save_place_BTN.TabIndex = 5;
            this.Save_place_BTN.Text = "Save place";
            this.Save_place_BTN.UseVisualStyleBackColor = true;
            this.Save_place_BTN.Click += new System.EventHandler(this.Save_place_BTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Suffix";
            // 
            // Number_display
            // 
            this.Number_display.Location = new System.Drawing.Point(17, 146);
            this.Number_display.Name = "Number_display";
            this.Number_display.Size = new System.Drawing.Size(44, 20);
            this.Number_display.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Select a number range and press the generate button";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Max number";
            // 
            // Min_place_num
            // 
            this.Min_place_num.Location = new System.Drawing.Point(79, 84);
            this.Min_place_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Min_place_num.Name = "Min_place_num";
            this.Min_place_num.Size = new System.Drawing.Size(59, 20);
            this.Min_place_num.TabIndex = 13;
            this.Min_place_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Max_place_num
            // 
            this.Max_place_num.Location = new System.Drawing.Point(169, 84);
            this.Max_place_num.Name = "Max_place_num";
            this.Max_place_num.Size = new System.Drawing.Size(59, 20);
            this.Max_place_num.TabIndex = 14;
            this.Max_place_num.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Save_place_and_num_BTN
            // 
            this.Save_place_and_num_BTN.Location = new System.Drawing.Point(157, 246);
            this.Save_place_and_num_BTN.Name = "Save_place_and_num_BTN";
            this.Save_place_and_num_BTN.Size = new System.Drawing.Size(75, 37);
            this.Save_place_and_num_BTN.TabIndex = 15;
            this.Save_place_and_num_BTN.Text = "Save place + number";
            this.Save_place_and_num_BTN.UseVisualStyleBackColor = true;
            this.Save_place_and_num_BTN.Click += new System.EventHandler(this.Save_place_and_num_BTN_Click);
            // 
            // Component_watcher
            // 
            this.Component_watcher.EnableRaisingEvents = true;
            this.Component_watcher.Path = "..\\..\\..\\Generator components";
            this.Component_watcher.SynchronizingObject = this;
            this.Component_watcher.Changed += new System.IO.FileSystemEventHandler(this.Component_watcher_Changed);
            // 
            // Place_name_generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 296);
            this.Controls.Add(this.Save_place_and_num_BTN);
            this.Controls.Add(this.Max_place_num);
            this.Controls.Add(this.Min_place_num);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Number_display);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Save_place_BTN);
            this.Controls.Add(this.Place_name_display);
            this.Controls.Add(this.Suffix_display);
            this.Controls.Add(this.Prefix_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Generate_place_BTN);
            this.Name = "Place_name_generator";
            this.Text = "Place name generator";
            this.Load += new System.EventHandler(this.Place_name_generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Min_place_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Max_place_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate_place_BTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Prefix_display;
        private System.Windows.Forms.TextBox Suffix_display;
        private System.Windows.Forms.TextBox Place_name_display;
        private System.Windows.Forms.Button Save_place_BTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Number_display;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Min_place_num;
        private System.Windows.Forms.NumericUpDown Max_place_num;
        private System.Windows.Forms.Button Save_place_and_num_BTN;
        private System.IO.FileSystemWatcher Component_watcher;
    }
}