using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission_name_generator
{
    public partial class Place_name_generator : Form
    {
        public Place_name_generator()
        {
            InitializeComponent();
        }

        private void Generate_place_BTN_Click(object sender, EventArgs e)
        {
            //Declaring variables
            Random Randnum = new Random();
            int Prefix_num;
            int Suffix_num;
            int Place_num;
            int Min_num;
            int Max_num;
            int Check_num = 0;

            try
            {
                //Converting the numbers in the numeric updowns to int variables and ensuring that the range is valid
                Min_num = Convert.ToInt32(Min_place_num.Value);
                Max_num = Convert.ToInt32(Max_place_num.Value);

                if (Min_num < 0)
                {
                    MessageBox.Show("Please enter a valid minimum house number", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Min_num > Max_num)
                {
                    MessageBox.Show("Please make sure that the house number upper limit is higher than the lower limit", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Selecting the prefix by choosing a random number and picking the word in that position
                Prefix_num = Randnum.Next(0, Place_prefix.Count);
                Prefix_display.Text = Place_prefix[Prefix_num];

                //Selecting the prefix by choosing a random number and picking the word in that position
                Suffix_num = Randnum.Next(0, Place_suffix.Count);
                Suffix_display.Text = Place_suffix[Suffix_num];


                //Selecting the building number from the range provided
                Place_num = Randnum.Next(Min_num, Max_num);
                Number_display.Text = Place_num.ToString();


                //Outputting the result to a text box so it can be copy and pasted
                Place_name_display.Text = (Prefix_display.Text + " " + Suffix_display.Text);

                //Checking the output to make sure it's not on the banned names list
                while (Check_num < Banned_place_names.Count)
                {
                    if (Place_name_display.Text == Banned_place_names[Check_num].ToString())
                    {
                        //Clears the display and goes back to pick a new name if this one is banned
                        Place_name_display.Text = (" ");
                        Generate_place_BTN.PerformClick();
                    }

                    else
                        Check_num++;

                }
            }
            catch(Exception E) { MessageBox.Show("Error occured: " + E,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void Save_place_BTN_Click(object sender, EventArgs e)
        {
            if (Place_name_display.Text == "Result will appear here")
            {
                MessageBox.Show("Please generate a name before attempting to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //When pressed this button appends the current place name to the mission place history file
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"..\..\..\History\Place name history.txt", true))
                {
                    file.WriteLine(Place_name_display.Text);
                    MessageBox.Show("Saved successfully");
                }
            }
            catch            
            {
                MessageBox.Show("Failed to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }        
        }

        private void Save_place_and_num_BTN_Click(object sender, EventArgs e)
        {
            if (Place_name_display.Text == "Result will appear here")
            {
                MessageBox.Show("Please generate a name before attempting to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //When pressed this button appends the current place name and number to the mission place history file
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"..\..\..\History\Place name history.txt", true))
                {
                    file.WriteLine(Number_display.Text + " " + Place_name_display.Text);
                    MessageBox.Show("Saved successfully");
                }
            }
            catch
            {
                MessageBox.Show("Failed to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        List<string> Place_prefix = new List<string>();
        List<string> Place_suffix = new List<string>();
        List<string> Banned_place_names = new List<string>();

        private void Place_name_generator_Load(object sender, EventArgs e)
        {
            Reload_components();
        }
        
        private void Component_watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Reload_components();
        }

        public void Reload_components ()
        {
            string[] Prefix;
            string[] Suffix; 
            string[] Banned;
            try
            {                
                Prefix = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Place Prefix list.txt");
                Suffix = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Place suffix list.txt");
                Banned = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Banned place names.txt");
                Place_prefix.Clear();
                foreach (string S in Prefix)
                {
                    Place_prefix.Add(S);
                }
                Place_suffix.Clear();
                foreach (string S in Suffix)
                {
                    Place_suffix.Add(S);
                }
                Banned_place_names.Clear();
                foreach (string S in Banned)
                {
                    Banned_place_names.Add(S);
                }
            }
            catch (Exception E) { MessageBox.Show("Error occured: " + E, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }        
    }
}
