using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mission_name_generator
{
    public partial class Mission_name_generator : Form
    {
        public Mission_name_generator()
        {
            InitializeComponent();
        }

        private void Generate_Btn_Click(object sender, EventArgs e)
        {
            //Declaring variables
            Random Randnum = new Random();           
            int Prefix_num;
            int Suffix_num;
            int Check_num = 0;

            //Declaring the arrays and importing values, if you want new prefixes or suffixes, add them in the appropriate file
            try
            {              
                //Selecting the prefix by choosing a random number and picking the word in that position
                Prefix_num = Randnum.Next(0, Prefixes.Count);
                Prefix_display.Text = Prefixes[Prefix_num];

                //Selecting the Suffix by choosing a random number and picking the word in that position
                Suffix_num = Randnum.Next(0, Suffixes.Count);
                Suffix_display.Text = Suffixes[Suffix_num];

                //Outputts the result to a text box so it can be copy and pasted
                Mission_name_display.Text = (Prefix_display.Text + " " + Suffix_display.Text);

                //Checks the output to make sure it's not on the banned names list
                while (Check_num < Banned_Missions.Count)
                {
                    if (Mission_name_display.Text == Banned_Missions[Check_num].ToString())
                    {
                        //Clears the display and goes back to pick a new name if this one is banned
                        Mission_name_display.Text = (" ");
                        Generate_Btn.PerformClick();
                    }

                    else
                        Check_num++;
                }
            }
            catch (Exception E) { MessageBox.Show("Error occured: " + E, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Save_name_Btn_Click(object sender, EventArgs e)
        {
            //Makes sure the box is ocupied
            if (Mission_name_display.Text == "Result will appear here")
            { MessageBox.Show("Please generate a result before attempting to save","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //Appends the current mission name to the mission name history file            
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"..\..\..\History\Mission name history.txt", true))
                {
                    file.WriteLine(Mission_name_display.Text);
                    MessageBox.Show("Saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Failed to save","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        List<string> Prefixes = new List<string>();
        List<string> Suffixes = new List<string>();
        List<string> Banned_Missions = new List<string>();

        private void Mission_name_generator_Load(object sender, EventArgs e)
        {
            //Declares the arrays and imports the values, if you want new prefixes or suffixes, add them in the appropriate file
            Reload_components();
        }
        private void Reload_components()
        {
            try
            {
                string [] Prefix = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Mission Prefix list.txt"); 
                string [] Suffix = System.IO.File.ReadAllLines(@"..\..\..\\Generator components\Mission Suffix list.txt");      
                string [] Banned = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Banned mission names.txt");

                Prefixes.Clear();
                foreach(string S in Prefix)
                {
                    Prefixes.Add(S);
                }
                Suffixes.Clear();
                foreach (string S in Suffix)
                {
                    Suffixes.Add(S);
                }
                Banned_Missions.Clear();
                foreach (string S in Banned)
                {
                    Banned_Missions.Add(S);
                }

            }
            catch (Exception E) { MessageBox.Show("Error occured: " + E, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Reload_source_BTN_Click(object sender, EventArgs e)
        {
            Reload_components();
        }

        private void Component_watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Reload_components();
        }
    }
}
