namespace Mars_rover_kata
{
    partial class Mars_rover_kata_UI
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
            Control_group_box = new GroupBox();
            label2 = new Label();
            Queue_display = new ListBox();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            Distance_input = new NumericUpDown();
            Turn_left_btn = new Button();
            Turn_right_btn = new Button();
            Location_display_group = new GroupBox();
            Position_display = new Label();
            Orientation_display = new Label();
            label4 = new Label();
            label3 = new Label();
            Control_group_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Distance_input).BeginInit();
            Location_display_group.SuspendLayout();
            SuspendLayout();
            // 
            // Control_group_box
            // 
            Control_group_box.Controls.Add(label2);
            Control_group_box.Controls.Add(Queue_display);
            Control_group_box.Controls.Add(button2);
            Control_group_box.Controls.Add(button1);
            Control_group_box.Controls.Add(label1);
            Control_group_box.Controls.Add(Distance_input);
            Control_group_box.Controls.Add(Turn_left_btn);
            Control_group_box.Controls.Add(Turn_right_btn);
            Control_group_box.Location = new Point(13, 77);
            Control_group_box.Name = "Control_group_box";
            Control_group_box.Size = new Size(291, 227);
            Control_group_box.TabIndex = 0;
            Control_group_box.TabStop = false;
            Control_group_box.Text = "Controls";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 194);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 7;
            label2.Text = "Limit: 5 actions";
            // 
            // Queue_display
            // 
            Queue_display.FormattingEnabled = true;
            Queue_display.ItemHeight = 15;
            Queue_display.Location = new Point(171, 36);
            Queue_display.Name = "Queue_display";
            Queue_display.Size = new Size(120, 124);
            Queue_display.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(191, 166);
            button2.Name = "button2";
            button2.Size = new Size(75, 40);
            button2.TabIndex = 5;
            button2.Text = "Execute";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Execute_queue;
            // 
            // button1
            // 
            button1.Location = new Point(18, 85);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 4;
            button1.Text = "Add to queue";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Move_rover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 38);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 3;
            label1.Text = "Distance";
            // 
            // Distance_input
            // 
            Distance_input.Location = new Point(18, 56);
            Distance_input.Name = "Distance_input";
            Distance_input.Size = new Size(120, 23);
            Distance_input.TabIndex = 2;
            // 
            // Turn_left_btn
            // 
            Turn_left_btn.Location = new Point(6, 147);
            Turn_left_btn.Name = "Turn_left_btn";
            Turn_left_btn.Size = new Size(75, 23);
            Turn_left_btn.TabIndex = 1;
            Turn_left_btn.Text = "Turn left";
            Turn_left_btn.UseVisualStyleBackColor = true;
            Turn_left_btn.Click += Turn_rover_left;
            // 
            // Turn_right_btn
            // 
            Turn_right_btn.Location = new Point(90, 147);
            Turn_right_btn.Name = "Turn_right_btn";
            Turn_right_btn.Size = new Size(75, 23);
            Turn_right_btn.TabIndex = 0;
            Turn_right_btn.Text = "Turn right";
            Turn_right_btn.UseVisualStyleBackColor = true;
            Turn_right_btn.Click += Turn_rover_right;
            // 
            // Location_display_group
            // 
            Location_display_group.Controls.Add(Position_display);
            Location_display_group.Controls.Add(Orientation_display);
            Location_display_group.Controls.Add(label4);
            Location_display_group.Controls.Add(label3);
            Location_display_group.Location = new Point(12, 22);
            Location_display_group.Name = "Location_display_group";
            Location_display_group.Size = new Size(292, 49);
            Location_display_group.TabIndex = 1;
            Location_display_group.TabStop = false;
            Location_display_group.Text = "Rover Location";
            // 
            // Position_display
            // 
            Position_display.AutoSize = true;
            Position_display.Location = new Point(70, 23);
            Position_display.Name = "Position_display";
            Position_display.Size = new Size(25, 15);
            Position_display.TabIndex = 3;
            Position_display.Text = "101";
            // 
            // Orientation_display
            // 
            Orientation_display.AutoSize = true;
            Orientation_display.Location = new Point(192, 23);
            Orientation_display.Name = "Orientation_display";
            Orientation_display.Size = new Size(38, 15);
            Orientation_display.TabIndex = 2;
            Orientation_display.Text = "South";
            Orientation_display.TextChanged += Orientation_display_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 23);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 1;
            label4.Text = "Orientation:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 23);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 0;
            label3.Text = "Position:";
            // 
            // Mars_rover_kata_UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 325);
            Controls.Add(Location_display_group);
            Controls.Add(Control_group_box);
            Name = "Mars_rover_kata_UI";
            Text = "Mars rover Kata (RIP ingenuity)";
            Load += Mars_rover_kata_UI_Load;
            Control_group_box.ResumeLayout(false);
            Control_group_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Distance_input).EndInit();
            Location_display_group.ResumeLayout(false);
            Location_display_group.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox Control_group_box;
        private Button Turn_left_btn;
        private Button Turn_right_btn;
        private ListBox Queue_display;
        private Button button2;
        private Button button1;
        private Label label1;
        private NumericUpDown Distance_input;
        private Label label2;
        private GroupBox Location_display_group;
        private Label Orientation_display;
        private Label label4;
        private Label label3;
        private Label Position_display;
    }
}
