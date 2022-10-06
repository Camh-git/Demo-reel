namespace Mission_name_generator
{
    partial class Mission_name_generator
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
            this.Generate_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Prefix_display = new System.Windows.Forms.TextBox();
            this.Suffix_display = new System.Windows.Forms.TextBox();
            this.Mission_name_display = new System.Windows.Forms.TextBox();
            this.Save_name_Btn = new System.Windows.Forms.Button();
            this.Reload_source_BTN = new System.Windows.Forms.Button();
            this.Component_watcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // Generate_Btn
            // 
            this.Generate_Btn.Location = new System.Drawing.Point(72, 99);
            this.Generate_Btn.Name = "Generate_Btn";
            this.Generate_Btn.Size = new System.Drawing.Size(96, 23);
            this.Generate_Btn.TabIndex = 0;
            this.Generate_Btn.Text = "Generate Name";
            this.Generate_Btn.UseVisualStyleBackColor = true;
            this.Generate_Btn.Click += new System.EventHandler(this.Generate_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mission name generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Click the button to generate a name";
            // 
            // Prefix_display
            // 
            this.Prefix_display.Location = new System.Drawing.Point(16, 60);
            this.Prefix_display.Name = "Prefix_display";
            this.Prefix_display.Size = new System.Drawing.Size(100, 20);
            this.Prefix_display.TabIndex = 3;
            // 
            // Suffix_display
            // 
            this.Suffix_display.Location = new System.Drawing.Point(134, 60);
            this.Suffix_display.Name = "Suffix_display";
            this.Suffix_display.Size = new System.Drawing.Size(100, 20);
            this.Suffix_display.TabIndex = 4;
            // 
            // Mission_name_display
            // 
            this.Mission_name_display.Location = new System.Drawing.Point(63, 128);
            this.Mission_name_display.Name = "Mission_name_display";
            this.Mission_name_display.Size = new System.Drawing.Size(116, 20);
            this.Mission_name_display.TabIndex = 6;
            this.Mission_name_display.Text = "Result will appear here";
            // 
            // Save_name_Btn
            // 
            this.Save_name_Btn.Location = new System.Drawing.Point(72, 154);
            this.Save_name_Btn.Name = "Save_name_Btn";
            this.Save_name_Btn.Size = new System.Drawing.Size(96, 23);
            this.Save_name_Btn.TabIndex = 7;
            this.Save_name_Btn.Text = "Save Name";
            this.Save_name_Btn.UseVisualStyleBackColor = true;
            this.Save_name_Btn.Click += new System.EventHandler(this.Save_name_Btn_Click);
            // 
            // Reload_source_BTN
            // 
            this.Reload_source_BTN.Location = new System.Drawing.Point(72, 183);
            this.Reload_source_BTN.Name = "Reload_source_BTN";
            this.Reload_source_BTN.Size = new System.Drawing.Size(96, 23);
            this.Reload_source_BTN.TabIndex = 8;
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
            // Mission_name_generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 206);
            this.Controls.Add(this.Reload_source_BTN);
            this.Controls.Add(this.Save_name_Btn);
            this.Controls.Add(this.Mission_name_display);
            this.Controls.Add(this.Suffix_display);
            this.Controls.Add(this.Prefix_display);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Generate_Btn);
            this.Name = "Mission_name_generator";
            this.Text = "Mission name generator";
            this.Load += new System.EventHandler(this.Mission_name_generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Component_watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Prefix_display;
        private System.Windows.Forms.TextBox Suffix_display;
        private System.Windows.Forms.TextBox Mission_name_display;
        private System.Windows.Forms.Button Save_name_Btn;
        private System.Windows.Forms.Button Reload_source_BTN;
        private System.IO.FileSystemWatcher Component_watcher;
    }
}

