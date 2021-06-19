namespace Mission_name_generator
{
    partial class Main_menu
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
            this.Open_person = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Open_edit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to the name generator.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please select a generator to get started.";
            // 
            // Open_person
            // 
            this.Open_person.Location = new System.Drawing.Point(139, 87);
            this.Open_person.Name = "Open_person";
            this.Open_person.Size = new System.Drawing.Size(75, 35);
            this.Open_person.TabIndex = 3;
            this.Open_person.Text = "Person names";
            this.Open_person.UseVisualStyleBackColor = true;
            this.Open_person.Click += new System.EventHandler(this.Open_person_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Name History";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Open_edit
            // 
            this.Open_edit.Location = new System.Drawing.Point(139, 200);
            this.Open_edit.Name = "Open_edit";
            this.Open_edit.Size = new System.Drawing.Size(75, 35);
            this.Open_edit.TabIndex = 5;
            this.Open_edit.Text = "Edit source lists";
            this.Open_edit.UseVisualStyleBackColor = true;
            this.Open_edit.Click += new System.EventHandler(this.Open_edit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Place names";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Open_edit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Open_person);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main_menu";
            this.Text = "Name generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Open_person;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Open_edit;
        private System.Windows.Forms.Button button2;
    }
}