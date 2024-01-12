using Newtonsoft.Json;
using System.ComponentModel;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Chapter_time_calc
{
    public partial class Form1 : Form
    {
        int TotalTime = 0;
        int index = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_time_Click(object sender, EventArgs e)
        {
            try
            {
                int time_to_add = 0;
                string[] sections = Time_input.Text.Split(':');


                //Format input for display
                string formatted_input = "";
                for (int i =0; i < sections.Length; i++)
                {
                    if (sections[i].Length == 1)
                    {
                        sections[i] =string.Format("0{0}", sections[i]);
                    }
                    formatted_input += string.Format("{0}:",sections[i]);
                }
                formatted_input = formatted_input.Remove(formatted_input.Length - 1);

                //Calculate the amount of time to add
                switch (sections.Length)
                {
                    case 1:
                        if (Convert.ToInt32(sections[0])>59)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        time_to_add += Convert.ToInt32(sections[0]);
                        break;
                    case 2:
                        if (Convert.ToInt32(sections[0]) > 59 || Convert.ToInt32(sections[1]) > 59)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        time_to_add += Convert.ToInt32(sections[0])*60;
                        time_to_add += Convert.ToInt32(sections[1]);
                        break;
                    case 3:
                        if (Convert.ToInt32(sections[0]) > 23 || Convert.ToInt32(sections[1]) > 59 || Convert.ToInt32(sections[2]) >59)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        time_to_add += Convert.ToInt32(sections[0]) * 60 * 60;
                        time_to_add += Convert.ToInt32(sections[1]) * 60;
                        time_to_add += Convert.ToInt32(sections[2]);
                        break;
                    default:
                        MessageBox.Show("Error: there appear to be more than 2 or 0 : seperating the time segments","Invalid input",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                }

                //create new row with the index, formatted input as runtime, total time as start time and totalTime+time_to_add as the end time
                Timing_view.Rows.Add(index, formatted_input, TimeSpan.FromSeconds(TotalTime), TimeSpan.FromSeconds(TotalTime + time_to_add));
                TotalTime += time_to_add;
                index++;
            }
            catch
            {
                MessageBox.Show("Error: input is not a valid time, please ensure minutes and seconds are under 60 and hours are under 24, input format: hh:mm:ss", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Time_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_time.PerformClick();
            }
        }

        private void Zero_index_check_CheckedChanged(object sender, EventArgs e)
        {
            if (Timing_view.RowCount.ToString() == "1")
            {
                if (Zero_index_check.Checked)
                {
                    index = 0;
                }
                else {
                    index = 1;
                }
                MessageBox.Show("Index set to: " + index.ToString());
            }
            else
            {
                MessageBox.Show("Cannot revert indexing after data has been added, clear data or restart to change indexing.","Index error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }        
    }
}