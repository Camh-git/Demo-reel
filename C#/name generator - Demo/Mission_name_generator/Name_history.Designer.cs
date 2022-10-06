namespace Mission_name_generator
{
    partial class Name_history
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
            this.Mission_list_display = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Person_list_display = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.History_close = new System.Windows.Forms.Button();
            this.Place_list_display = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Delete_history = new System.Windows.Forms.Button();
            this.Deselect_history = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Mission_list_display
            // 
            this.Mission_list_display.FormattingEnabled = true;
            this.Mission_list_display.Location = new System.Drawing.Point(15, 133);
            this.Mission_list_display.Name = "Mission_list_display";
            this.Mission_list_display.Size = new System.Drawing.Size(120, 212);
            this.Mission_list_display.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MIssion names";
            // 
            // Person_list_display
            // 
            this.Person_list_display.FormattingEnabled = true;
            this.Person_list_display.Location = new System.Drawing.Point(141, 133);
            this.Person_list_display.Name = "Person_list_display";
            this.Person_list_display.Size = new System.Drawing.Size(120, 212);
            this.Person_list_display.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Person names";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name history";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(366, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bellow are lists of the previously generated names for each of the generators";
            // 
            // History_close
            // 
            this.History_close.Location = new System.Drawing.Point(159, 430);
            this.History_close.Name = "History_close";
            this.History_close.Size = new System.Drawing.Size(75, 23);
            this.History_close.TabIndex = 6;
            this.History_close.Text = "Close";
            this.History_close.UseVisualStyleBackColor = true;
            this.History_close.Click += new System.EventHandler(this.History_close_Click);
            // 
            // Place_list_display
            // 
            this.Place_list_display.FormattingEnabled = true;
            this.Place_list_display.Location = new System.Drawing.Point(267, 133);
            this.Place_list_display.Name = "Place_list_display";
            this.Place_list_display.Size = new System.Drawing.Size(120, 212);
            this.Place_list_display.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Place names";
            // 
            // Delete_history
            // 
            this.Delete_history.Location = new System.Drawing.Point(121, 360);
            this.Delete_history.Name = "Delete_history";
            this.Delete_history.Size = new System.Drawing.Size(75, 36);
            this.Delete_history.TabIndex = 9;
            this.Delete_history.Text = "Delete selected";
            this.Delete_history.UseVisualStyleBackColor = true;
            this.Delete_history.Click += new System.EventHandler(this.Delete_history_Click);
            // 
            // Deselect_history
            // 
            this.Deselect_history.Location = new System.Drawing.Point(202, 360);
            this.Deselect_history.Name = "Deselect_history";
            this.Deselect_history.Size = new System.Drawing.Size(75, 36);
            this.Deselect_history.TabIndex = 10;
            this.Deselect_history.Text = "Deselect";
            this.Deselect_history.UseVisualStyleBackColor = true;
            this.Deselect_history.Click += new System.EventHandler(this.Deselect_history_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(325, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "make sure you have the correct items selected before deleting";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(333, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "WARNING: the delete button deletes all selected items from all tables";
            // 
            // Name_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 465);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Deselect_history);
            this.Controls.Add(this.Delete_history);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Place_list_display);
            this.Controls.Add(this.History_close);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Person_list_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mission_list_display);
            this.Name = "Name_history";
            this.Text = "History";
            this.Load += new System.EventHandler(this.Name_history_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Mission_list_display;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Person_list_display;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button History_close;
        private System.Windows.Forms.ListBox Place_list_display;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Delete_history;
        private System.Windows.Forms.Button Deselect_history;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}