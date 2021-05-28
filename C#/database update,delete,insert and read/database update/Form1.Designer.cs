namespace database_update
{
    partial class Form1
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
            this.Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Update_name_box = new System.Windows.Forms.TextBox();
            this.Update_age_box = new System.Windows.Forms.TextBox();
            this.Update_ID_box = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Create = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.New_name = new System.Windows.Forms.TextBox();
            this.New_age = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Delete_ID = new System.Windows.Forms.NumericUpDown();
            this.Delete = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Read_ID = new System.Windows.Forms.NumericUpDown();
            this.Read = new System.Windows.Forms.Button();
            this.Age_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Update_ID_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Read_ID)).BeginInit();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(83, 248);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 0;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Age:";
            // 
            // Update_name_box
            // 
            this.Update_name_box.Location = new System.Drawing.Point(97, 183);
            this.Update_name_box.Name = "Update_name_box";
            this.Update_name_box.Size = new System.Drawing.Size(100, 20);
            this.Update_name_box.TabIndex = 5;
            // 
            // Update_age_box
            // 
            this.Update_age_box.Location = new System.Drawing.Point(97, 209);
            this.Update_age_box.Name = "Update_age_box";
            this.Update_age_box.Size = new System.Drawing.Size(100, 20);
            this.Update_age_box.TabIndex = 6;
            // 
            // Update_ID_box
            // 
            this.Update_ID_box.Location = new System.Drawing.Point(97, 157);
            this.Update_ID_box.Name = "Update_ID_box";
            this.Update_ID_box.Size = new System.Drawing.Size(100, 20);
            this.Update_ID_box.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Update Existing user";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Add new user";
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(83, 95);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 10;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Age:";
            // 
            // New_name
            // 
            this.New_name.Location = new System.Drawing.Point(97, 30);
            this.New_name.Name = "New_name";
            this.New_name.Size = new System.Drawing.Size(97, 20);
            this.New_name.TabIndex = 13;
            // 
            // New_age
            // 
            this.New_age.Location = new System.Drawing.Point(97, 64);
            this.New_age.Name = "New_age";
            this.New_age.Size = new System.Drawing.Size(97, 20);
            this.New_age.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Delete user";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Read user data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "ID:";
            // 
            // Delete_ID
            // 
            this.Delete_ID.Location = new System.Drawing.Point(298, 35);
            this.Delete_ID.Name = "Delete_ID";
            this.Delete_ID.Size = new System.Drawing.Size(100, 20);
            this.Delete_ID.TabIndex = 18;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(301, 95);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 19;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(228, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Warning: this will pernemently delete the user";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(282, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "ID:";
            // 
            // Read_ID
            // 
            this.Read_ID.Location = new System.Drawing.Point(309, 164);
            this.Read_ID.Name = "Read_ID";
            this.Read_ID.Size = new System.Drawing.Size(100, 20);
            this.Read_ID.TabIndex = 22;
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(301, 207);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 23;
            this.Read.Text = "Read";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // Age_label
            // 
            this.Age_label.AutoSize = true;
            this.Age_label.Location = new System.Drawing.Point(306, 248);
            this.Age_label.Name = "Age_label";
            this.Age_label.Size = new System.Drawing.Size(76, 13);
            this.Age_label.TabIndex = 24;
            this.Age_label.Text = "changing label";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Start transaction";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(515, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Age_label);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.Read_ID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Delete_ID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.New_age);
            this.Controls.Add(this.New_name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Update_ID_box);
            this.Controls.Add(this.Update_age_box);
            this.Controls.Add(this.Update_name_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Update);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Update_ID_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Read_ID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Update_name_box;
        private System.Windows.Forms.TextBox Update_age_box;
        private System.Windows.Forms.NumericUpDown Update_ID_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox New_name;
        private System.Windows.Forms.TextBox New_age;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown Delete_ID;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown Read_ID;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Label Age_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

