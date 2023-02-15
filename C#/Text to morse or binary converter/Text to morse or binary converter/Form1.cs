using System;
using System.Drawing;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Text_to_morse_or_binary_converter
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void Convert_BTN_Click(object sender, EventArgs e)
        {
            //Get the string from the textbox and convert it to an array
            if (Input_box.Text == "")
            {
                MessageBox.Show("Please enter the text to be converted", "No text", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Text = Input_box.Text;
            char[] letters = Text.ToCharArray();

            //Find which option is selected and run the apropriate conversion
            string[] Conversion_results = new string[letters.Length];
            string Result = "";
            int i = 1;
            if (Select_binary.Checked == true)
            {
                Conversion_results = Conversion_lists.Binary_convert(letters);
                while (i <= Conversion_results.Length)
                {
                    Result = Result + Conversion_results[i - 1];
                    Result = Result + " ";
                    i = i + 1;
                }
            }
            else if (Select_morse.Checked == true)
            {
                Conversion_results = Conversion_lists.Morse_convert(letters);
                while (i <= Conversion_results.Length)
                {
                    Result = Result + Conversion_results[i - 1];
                    Result = Result + " ";
                    i = i + 1;
                }

            }
            else
            {
                MessageBox.Show("Please select a conversion option in order to convert", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Write the result to the display
            Results_box.Text = Result;
        }

        private void Converter_Load(object sender, EventArgs e)
        {
            Select_morse.Checked = true;
            Results_box.Multiline = true;
            Results_box.ScrollBars = ScrollBars.Vertical;

        }
        private void Play_audio_Click(object sender, EventArgs e)
        {
            // SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            Playing_indicator.Visible = true;

            if (Select_binary.Checked == true)
            {
                var tts = new SpeechSynthesizer();
                tts.Speak(Results_box.Text);
            }

            else if (Select_morse.Checked == true)
            {
                var tts = new SpeechSynthesizer();
                char[] box_content = Results_box.Text.ToCharArray();
                string output = "";
                foreach (char c in box_content)
                {
                    if (c == '.')
                    {
                        output = output + "BE";
                    }
                    else if (c == '-')
                    {
                        output = output + "A";
                    }
                    else if (c == ' ')
                    {
                        output = output + "Break";
                    }
                }
                tts.Speak(output);
            }

            Playing_indicator.Visible = false;
        }

        private void Play_sound_Click(object sender, EventArgs e)
        {
            Playing_indicator.Visible = true;

            foreach (char C in Results_box.Text.ToCharArray())
            {
                System.Threading.Thread.Sleep(100); //beep distorts at all the given options faster than 2.5hz            
                switch (C)
                {
                    case '1':
                    case '.':
                        System.Media.SystemSounds.Beep.Play();
                        break;
                    case '-':
                        System.Media.SystemSounds.Question.Play();
                        break;
                    case ' ':
                        if (Select_morse.Checked)
                        {
                            System.Threading.Thread.Sleep(600);
                        }
                        break;
                    default:
                        break;
                }
            }

            Playing_indicator.Visible = false;
        }

        private void tts_Click(object sender, EventArgs e)
        {
            Speaking_indicator.Visible = true;
            var tts = new SpeechSynthesizer();
            if (Input_box.Text != "")
            {
                tts.Speak(Input_box.Text);
            }
            else
            {
                tts.Speak("Please enter some text in the input box");
            }
            Speaking_indicator.Visible = false;
        }

        
        private void Speaking_indicator_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void Blinking_indicator_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void Playing_indicator_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

    }
}
