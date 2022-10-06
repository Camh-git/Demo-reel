namespace Mission_name_generator
{
    partial class Person_name_generator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioM = new System.Windows.Forms.RadioButton();
            this.RadioF = new System.Windows.Forms.RadioButton();
            this.RadioU = new System.Windows.Forms.RadioButton();
            this.RadioA = new System.Windows.Forms.RadioButton();
            this.Generate_Name = new System.Windows.Forms.Button();
            this.First_name_display = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Last_name_display = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Person_name_display = new System.Windows.Forms.TextBox();
            this.Save_name_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Reload_source_BTN = new System.Windows.Forms.Button();
            this.Component_watcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person name generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a gender option bellow and press the generate button";
            // 
            // RadioM
            // 
            this.RadioM.AutoSize = true;
            this.RadioM.Location = new System.Drawing.Point(46, 77);
            this.RadioM.Name = "RadioM";
            this.RadioM.Size = new System.Drawing.Size(48, 17);
            this.RadioM.TabIndex = 2;
            this.RadioM.TabStop = true;
            this.RadioM.Text = "Male";
            this.RadioM.UseVisualStyleBackColor = true;
            // 
            // RadioF
            // 
            this.RadioF.AutoSize = true;
            this.RadioF.Location = new System.Drawing.Point(100, 77);
            this.RadioF.Name = "RadioF";
            this.RadioF.Size = new System.Drawing.Size(59, 17);
            this.RadioF.TabIndex = 3;
            this.RadioF.TabStop = true;
            this.RadioF.Text = "Female";
            this.RadioF.UseVisualStyleBackColor = true;
            // 
            // RadioU
            // 
            this.RadioU.AutoSize = true;
            this.RadioU.Location = new System.Drawing.Point(165, 77);
            this.RadioU.Name = "RadioU";
            this.RadioU.Size = new System.Drawing.Size(57, 17);
            this.RadioU.TabIndex = 4;
            this.RadioU.TabStop = true;
            this.RadioU.Text = "Unisex";
            this.RadioU.UseVisualStyleBackColor = true;
            // 
            // RadioA
            // 
            this.RadioA.AutoSize = true;
            this.RadioA.Location = new System.Drawing.Point(242, 77);
            this.RadioA.Name = "RadioA";
            this.RadioA.Size = new System.Drawing.Size(43, 17);
            this.RadioA.TabIndex = 5;
            this.RadioA.TabStop = true;
            this.RadioA.Text = "Any";
            this.RadioA.UseVisualStyleBackColor = true;
            // 
            // Generate_Name
            // 
            this.Generate_Name.Location = new System.Drawing.Point(110, 111);
            this.Generate_Name.Name = "Generate_Name";
            this.Generate_Name.Size = new System.Drawing.Size(104, 23);
            this.Generate_Name.TabIndex = 6;
            this.Generate_Name.Text = "Generate name_BTN";
            this.Generate_Name.UseVisualStyleBackColor = true;
            this.Generate_Name.Click += new System.EventHandler(this.Generate_Name_Click);
            // 
            // First_name_display
            // 
            this.First_name_display.Location = new System.Drawing.Point(33, 165);
            this.First_name_display.Name = "First_name_display";
            this.First_name_display.Size = new System.Drawing.Size(100, 20);
            this.First_name_display.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "1st name";
            // 
            // Last_name_display
            // 
            this.Last_name_display.Location = new System.Drawing.Point(206, 165);
            this.Last_name_display.Name = "Last_name_display";
            this.Last_name_display.Size = new System.Drawing.Size(100, 20);
            this.Last_name_display.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Last name";
            // 
            // Person_name_display
            // 
            this.Person_name_display.Location = new System.Drawing.Point(110, 207);
            this.Person_name_display.Name = "Person_name_display";
            this.Person_name_display.Size = new System.Drawing.Size(109, 20);
            this.Person_name_display.TabIndex = 11;
            this.Person_name_display.Text = "Name will appear here";
            // 
            // Save_name_Btn
            // 
            this.Save_name_Btn.Location = new System.Drawing.Point(110, 233);
            this.Save_name_Btn.Name = "Save_name_Btn";
            this.Save_name_Btn.Size = new System.Drawing.Size(104, 23);
            this.Save_name_Btn.TabIndex = 12;
            this.Save_name_Btn.Text = "Save name";
            this.Save_name_Btn.UseVisualStyleBackColor = true;
            this.Save_name_Btn.Click += new System.EventHandler(this.Save_name_Btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Mass gen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reload_source_BTN
            // 
            this.Reload_source_BTN.Location = new System.Drawing.Point(8, 236);
            this.Reload_source_BTN.Name = "Reload_source_BTN";
            this.Reload_source_BTN.Size = new System.Drawing.Size(96, 23);
            this.Reload_source_BTN.TabIndex = 14;
            this.Reload_source_BTN.Text = "Reload source";
            this.Reload_source_BTN.UseVisualStyleBackColor = true;
            this.Reload_source_BTN.Click += new System.EventHandler(this.Reload_source_BTN_Click);
            // 
            // Component_watcher
            // 
            this.Component_watcher.EnableRaisingEvents = true;
            this.Component_watcher.Path = "..\\..\\..\\Generator components";
            this.Component_watcher.SynchronizingObject = this;
            this.Component_watcher.Changed += new System.IO.FileSystemEventHandler(this.Component_watcher_Changed);
            // 
            // Person_name_generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 271);
            this.Controls.Add(this.Reload_source_BTN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Save_name_Btn);
            this.Controls.Add(this.Person_name_display);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Last_name_display);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.First_name_display);
            this.Controls.Add(this.Generate_Name);
            this.Controls.Add(this.RadioA);
            this.Controls.Add(this.RadioU);
            this.Controls.Add(this.RadioF);
            this.Controls.Add(this.RadioM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Person_name_generator";
            this.Text = "Person name generator";
            this.Load += new System.EventHandler(this.Person_name_generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioM;
        private System.Windows.Forms.RadioButton RadioF;
        private System.Windows.Forms.RadioButton RadioU;
        private System.Windows.Forms.RadioButton RadioA;
        private System.Windows.Forms.Button Generate_Name;
        private System.Windows.Forms.TextBox First_name_display;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Last_name_display;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Person_name_display;
        private System.Windows.Forms.Button Save_name_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Reload_source_BTN;
        private System.IO.FileSystemWatcher Component_watcher;
    }
}