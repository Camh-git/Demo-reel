namespace Restaurant_product_maker
{
    partial class Landing_page
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Manual_schema_load = new System.Windows.Forms.Button();
            this.Schema_display = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Upload_prod_to_DB_BTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naming schema";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Manual_schema_load);
            this.groupBox1.Controls.Add(this.Schema_display);
            this.groupBox1.Location = new System.Drawing.Point(182, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product code schema";
            // 
            // Manual_schema_load
            // 
            this.Manual_schema_load.Location = new System.Drawing.Point(101, 79);
            this.Manual_schema_load.Name = "Manual_schema_load";
            this.Manual_schema_load.Size = new System.Drawing.Size(108, 23);
            this.Manual_schema_load.TabIndex = 4;
            this.Manual_schema_load.Text = "Load manually";
            this.Manual_schema_load.UseVisualStyleBackColor = true;
            this.Manual_schema_load.Click += new System.EventHandler(this.Manual_schema_load_Click);
            // 
            // Schema_display
            // 
            this.Schema_display.Location = new System.Drawing.Point(11, 23);
            this.Schema_display.Name = "Schema_display";
            this.Schema_display.Size = new System.Drawing.Size(320, 93);
            this.Schema_display.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open/edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Upload_prod_to_DB_BTN
            // 
            this.Upload_prod_to_DB_BTN.Location = new System.Drawing.Point(12, 157);
            this.Upload_prod_to_DB_BTN.Name = "Upload_prod_to_DB_BTN";
            this.Upload_prod_to_DB_BTN.Size = new System.Drawing.Size(75, 40);
            this.Upload_prod_to_DB_BTN.TabIndex = 4;
            this.Upload_prod_to_DB_BTN.Text = "Upload product";
            this.Upload_prod_to_DB_BTN.UseVisualStyleBackColor = true;
            this.Upload_prod_to_DB_BTN.Click += new System.EventHandler(this.Upload_prod_to_DB_BTN_Click);
            // 
            // Landing_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 222);
            this.Controls.Add(this.Upload_prod_to_DB_BTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Landing_page";
            this.Text = "Landing page";
            this.Load += new System.EventHandler(this.Landing_page_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label1;
        private GroupBox groupBox1;
        private Label Schema_display;
        private Button Manual_schema_load;
        private Button button2;
        private Button Upload_prod_to_DB_BTN;
    }
}