using Newtonsoft.Json;
using System.ComponentModel;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

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

        private static string Format_as_time(string input)
        {
            string formatted_input = "";
            string[] sections = input.Split(':');
            for (int i =0; i < sections.Length; i++)
            {
                if (sections[i].Length == 1)
                {
                    sections[i] = string.Format("0{0}", sections[i]);
                }
                formatted_input += string.Format("{0}:", sections[i]);
            }
            formatted_input = formatted_input.Remove(formatted_input.Length - 1);
            return formatted_input;
        }

        private static int  Calculate_time_to_add(string input)
        {
            int time_to_add = 0;
            string[] sections = input.Split(':');
            switch (sections.Count())
            {
                case 1:
                    if (Convert.ToInt32(sections[0]) > 59)
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
                    time_to_add += Convert.ToInt32(sections[0]) * 60;
                    time_to_add += Convert.ToInt32(sections[1]);
                    break;
                case 3:
                    if (Convert.ToInt32(sections[0]) > 23 || Convert.ToInt32(sections[1]) > 59 || Convert.ToInt32(sections[2]) > 59)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    time_to_add += Convert.ToInt32(sections[0]) * 60 * 60;
                    time_to_add += Convert.ToInt32(sections[1]) * 60;
                    time_to_add += Convert.ToInt32(sections[2]);
                    break;
                default:
                    MessageBox.Show("Error: there appear to be more than 2 or 0 : seperating the time segments", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
            }
            return time_to_add;
        }

        private void Add_time_Click(object sender, EventArgs e)
        {
            try
            {
                //Format input for display, Calculate the amount of time to add (can you tell this section was a lot longer before these became their own functions?)
                string formatted_input = Format_as_time(Time_input.Text);
                int time_to_add = Calculate_time_to_add(formatted_input);
            
                //create new row with the index, formatted input as runtime, total time as start time and totalTime+time_to_add as the end time
                Timing_view.Rows.Add(index, formatted_input, TimeSpan.FromSeconds(TotalTime), TimeSpan.FromSeconds(TotalTime + time_to_add));
                TotalTime += time_to_add;
                index++;
                Time_input.Text = "";
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

        private void Recalculate_times_Click(object sender, EventArgs e)
        {
            DialogResult confirm_recalc = MessageBox.Show("If you have applied all the runtime changes you want to make, press ok to continue","Recalculate",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm_recalc == DialogResult.OK)
            {
                int running_time = 0;
                foreach (DataGridViewRow row in Timing_view.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        //Make sure any changes the user made are properly formatted.
                        row.Cells[1].Value = Format_as_time(row.Cells[1].Value.ToString());
                        row.Cells[2].Value = Format_as_time(row.Cells[2].Value.ToString());
                        row.Cells[3].Value = Format_as_time(row.Cells[3].Value.ToString());

                        //Calculate at display the new values
                        int time_to_add = Calculate_time_to_add(row.Cells[1].Value.ToString());
                        row.Cells[2].Value = Format_as_time(TimeSpan.FromSeconds(running_time).ToString());
                        row.Cells[3].Value = Format_as_time(TimeSpan.FromSeconds((running_time + time_to_add)).ToString());
                        running_time += time_to_add;
                        TotalTime = running_time;
                    }

                }
                MessageBox.Show("New total time (Seconds): " + TotalTime.ToString());
            }
        }

        private void Load_file_btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm_recalc = MessageBox.Show("This will overwrite any existing data view content, are you sure you want to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm_recalc == DialogResult.Yes)
            {

                //Select the file
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Title = "";
                OFD.Filter = "JSON file|*.json|All files|*.*";
                OFD.InitialDirectory = String.Format("{0}../../../../Saved_JSON/", Directory.GetCurrentDirectory());
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    //Setup by removing any existing content, set save target to this file
                    string [] NameSegments = OFD.FileName.Split("\\");
                    Save_name_input.Text = NameSegments[NameSegments.Length - 1].Split(".")[0];
                    Timing_view.Rows.Clear();

                    try
                    {
                        //Open and parse the file
                        using (StreamReader file = File.OpenText(OFD.FileName))
                        {
                            using (JsonTextReader reader = new JsonTextReader(file))
                            {
                                JObject data = (JObject)JToken.ReadFrom(reader);
                                for (int i = 0; i < data["Chapters"].Count(); i++)
                                {
                                    Timing_view.Rows.Add(i, data["Chapters"][i]["Runtime"], data["Chapters"][i]["Start_time"], data["Chapters"][i]["End_time"]);
                                }
                                index = data["Chapters"].Count();
                                TotalTime = Calculate_time_to_add(data["Chapters"][data["Chapters"].Count()-1]["End_time"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load json file", "CRITICAL ERROR",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void Save_file_btn_Click(object sender, EventArgs e)
        {
            string path = String.Format("{0}../../../../Saved_JSON/{1}.Json",Directory.GetCurrentDirectory(), Save_name_input.Text);
            using (FileStream fs = File.Create(path))
            {
                //Populate the data
                string data = "{\"Chapters\":[";
                foreach (DataGridViewRow row in Timing_view.Rows)
                {
                    if (row.Cells[0].Value != null) //Prevents the currently empty new index from being saved
                    {
                        data += string.Format("{{\"Index\":\"{0}\",\"Runtime\":\"{1}\",\"Start_time\":\"{2}\",\"End_time\":\"{3}\"}},", row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
                    }
                }

                data = data.Remove(data.Length - 1);
                data += "]}";
                try
                {
                    //write the data to the file
                    byte[] info = new UTF8Encoding(true).GetBytes(data);
                    fs.Write(info, 0, info.Length);
                    MessageBox.Show("File saved successfully", "Saved", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Failed to save, please ensure that there are no other files with the same name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirm_restart = MessageBox.Show("All unsaved data will be lost, continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm_restart == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}