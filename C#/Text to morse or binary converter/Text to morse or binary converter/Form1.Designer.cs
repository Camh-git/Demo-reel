namespace Text_to_morse_or_binary_converter
{
    partial class Converter
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
            this.Input_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Select_morse = new System.Windows.Forms.RadioButton();
            this.Convert_BTN = new System.Windows.Forms.Button();
            this.Select_binary = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Results_box = new System.Windows.Forms.TextBox();
            this.Play_audio = new System.Windows.Forms.Button();
            this.Play_sound = new System.Windows.Forms.Button();
            this.tts = new System.Windows.Forms.Button();
            this.Speaking_indicator = new System.Windows.Forms.Label();
            this.Playing_indicator = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Input_box
            // 
            this.Input_box.Location = new System.Drawing.Point(160, 66);
            this.Input_box.Multiline = true;
            this.Input_box.Name = "Input_box";
            this.Input_box.Size = new System.Drawing.Size(237, 32);
            this.Input_box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please input your text here:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select conversion";
            // 
            // Select_morse
            // 
            this.Select_morse.AutoSize = true;
            this.Select_morse.Location = new System.Drawing.Point(85, 36);
            this.Select_morse.Name = "Select_morse";
            this.Select_morse.Size = new System.Drawing.Size(54, 17);
            this.Select_morse.TabIndex = 4;
            this.Select_morse.TabStop = true;
            this.Select_morse.Text = "Morse";
            this.Select_morse.UseVisualStyleBackColor = true;
            // 
            // Convert_BTN
            // 
            this.Convert_BTN.Location = new System.Drawing.Point(73, 82);
            this.Convert_BTN.Name = "Convert_BTN";
            this.Convert_BTN.Size = new System.Drawing.Size(75, 23);
            this.Convert_BTN.TabIndex = 0;
            this.Convert_BTN.Text = "Convert";
            this.Convert_BTN.UseVisualStyleBackColor = true;
            this.Convert_BTN.Click += new System.EventHandler(this.Convert_BTN_Click);
            // 
            // Select_binary
            // 
            this.Select_binary.AutoSize = true;
            this.Select_binary.Location = new System.Drawing.Point(85, 60);
            this.Select_binary.Name = "Select_binary";
            this.Select_binary.Size = new System.Drawing.Size(54, 17);
            this.Select_binary.TabIndex = 5;
            this.Select_binary.TabStop = true;
            this.Select_binary.Text = "Binary";
            this.Select_binary.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Select_binary);
            this.groupBox1.Controls.Add(this.Convert_BTN);
            this.groupBox1.Controls.Add(this.Select_morse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(160, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 113);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // Results_box
            // 
            this.Results_box.Location = new System.Drawing.Point(160, 271);
            this.Results_box.Multiline = true;
            this.Results_box.Name = "Results_box";
            this.Results_box.Size = new System.Drawing.Size(237, 78);
            this.Results_box.TabIndex = 15;
            // 
            // Play_audio
            // 
            this.Play_audio.Location = new System.Drawing.Point(241, 352);
            this.Play_audio.Name = "Play_audio";
            this.Play_audio.Size = new System.Drawing.Size(75, 50);
            this.Play_audio.TabIndex = 15;
            this.Play_audio.Text = "Play converted audio";
            this.Play_audio.UseVisualStyleBackColor = true;
            this.Play_audio.Click += new System.EventHandler(this.Play_audio_Click);
            // 
            // Play_sound
            // 
            this.Play_sound.Location = new System.Drawing.Point(160, 352);
            this.Play_sound.Name = "Play_sound";
            this.Play_sound.Size = new System.Drawing.Size(75, 50);
            this.Play_sound.TabIndex = 18;
            this.Play_sound.Text = "Play sound";
            this.Play_sound.UseVisualStyleBackColor = true;
            this.Play_sound.Click += new System.EventHandler(this.Play_sound_Click);
            // 
            // tts
            // 
            this.tts.Location = new System.Drawing.Point(322, 355);
            this.tts.Name = "tts";
            this.tts.Size = new System.Drawing.Size(75, 47);
            this.tts.TabIndex = 19;
            this.tts.Text = "tts";
            this.tts.UseVisualStyleBackColor = true;
            this.tts.Click += new System.EventHandler(this.tts_Click);
            // 
            // Speaking_indicator
            // 
            this.Speaking_indicator.AutoSize = true;
            this.Speaking_indicator.BackColor = System.Drawing.Color.White;
            this.Speaking_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speaking_indicator.ForeColor = System.Drawing.Color.Red;
            this.Speaking_indicator.Location = new System.Drawing.Point(239, 405);
            this.Speaking_indicator.Name = "Speaking_indicator";
            this.Speaking_indicator.Size = new System.Drawing.Size(77, 17);
            this.Speaking_indicator.TabIndex = 20;
            this.Speaking_indicator.Text = "SPEAKING";
            this.Speaking_indicator.Visible = false;
            this.Speaking_indicator.Paint += new System.Windows.Forms.PaintEventHandler(this.Speaking_indicator_Paint);
            // 
            // Playing_indicator
            // 
            this.Playing_indicator.AutoSize = true;
            this.Playing_indicator.BackColor = System.Drawing.Color.White;
            this.Playing_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playing_indicator.ForeColor = System.Drawing.Color.Red;
            this.Playing_indicator.Location = new System.Drawing.Point(245, 405);
            this.Playing_indicator.Name = "Playing_indicator";
            this.Playing_indicator.Size = new System.Drawing.Size(67, 17);
            this.Playing_indicator.TabIndex = 26;
            this.Playing_indicator.Text = "PLAYING";
            this.Playing_indicator.Visible = false;
            this.Playing_indicator.Paint += new System.Windows.Forms.PaintEventHandler(this.Playing_indicator_Paint);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.Speaking_indicator);
            this.Controls.Add(this.Playing_indicator);
            this.Controls.Add(this.tts);
            this.Controls.Add(this.Play_sound);
            this.Controls.Add(this.Results_box);
            this.Controls.Add(this.Play_audio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Input_box);
            this.Name = "Converter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text to morse/binary converter";
            this.Load += new System.EventHandler(this.Converter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Input_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Select_morse;
        private System.Windows.Forms.Button Convert_BTN;
        private System.Windows.Forms.RadioButton Select_binary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Results_box;
        private System.Windows.Forms.Button Play_audio;
        private System.Windows.Forms.Button Play_sound;
        private System.Windows.Forms.Button tts;
        private System.Windows.Forms.Label Speaking_indicator;
        private System.Windows.Forms.Label Playing_indicator;
    }
}

