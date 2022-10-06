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
    public partial class Person_name_generator : Form
    {
        public Person_name_generator()
        {
            InitializeComponent();         
        }

        private void Generate_Name_Click(object sender, EventArgs e)
        {
            //Declaring variables
            Random Randnum = new Random();
            int First_name_num;
            int Last_name_num;
            int Check_num = 0;

            try
            {
                //Selecting 1st name by checking which button is checked and then choosing a random number and picking the word in that position
                if (RadioM.Checked == true)
                {
                    First_name_num = Randnum.Next(0, Male_first_names.Count);
                    First_name_display.Text = Male_first_names[First_name_num];
                }

                else if (RadioF.Checked == true)
                {
                    First_name_num = Randnum.Next(0, Female_first_names.Count);
                    First_name_display.Text = Female_first_names[First_name_num];
                }

                else if (RadioU.Checked == true)
                {
                    First_name_num = Randnum.Next(0, Unisex_first_names.Count);
                    First_name_display.Text = Unisex_first_names[First_name_num];
                }

                //The any name option selects a random number to choose with array to pick from, and then works like the other 3 options
                else if (RadioA.Checked == true)
                {
                    int i = Randnum.Next(1, 4);
                    if (i == 1)
                    {
                        First_name_num = Randnum.Next(0, Male_first_names.Count);
                        First_name_display.Text = Male_first_names[First_name_num];
                    }
                    if (i == 2)
                    {
                        First_name_num = Randnum.Next(0, Female_first_names.Count);
                        First_name_display.Text = Female_first_names[First_name_num];
                    }
                    if (i == 3)
                    {
                        First_name_num = Randnum.Next(0, Unisex_first_names.Count);
                        First_name_display.Text = Unisex_first_names[First_name_num];
                    }
                }

                else
                {
                    MessageBox.Show("Please select a gender option before continuing", "Missing selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Selecting the Last name by choosing a random number and picking the word in that position
                Last_name_num = Randnum.Next(0, Last_names.Count);
                Last_name_display.Text = Last_names[Last_name_num];

                //Outputting the result to a text box so it can be copy and pasted
                Person_name_display.Text = (First_name_display.Text + " " + Last_name_display.Text);

                //Checking the output to make sure it's not on the banned names list
                while (Check_num < Banned_person_names.Count)
                {
                    if (Person_name_display.Text == Banned_person_names[Check_num].ToString())
                    {
                        //Clears the display and goes back to pick a new name if this one is banned
                        Person_name_display.Text = (" ");
                        Generate_Name.PerformClick();
                    }

                    else
                        Check_num++;
                }
            }
            catch (Exception E) { MessageBox.Show("Error occured: " + E, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void Save_name_Btn_Click(object sender, EventArgs e)
        {
            //Makes sure a result has been generated before atempting to save
            if (Person_name_display.Text == "Name will appear here")
            {
                MessageBox.Show("Please generate a name before attempting to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //Declares the streamwriter and points it to the file           
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"..\..\..\History\Person name history.txt", true))
                {
                    //Checks the gender and writes the saved name, with a male or female tag if the apropriate button is checked, or just the name if not
                    if (RadioM.Checked == true)
                    {
                        file.WriteLine("Male   " + Person_name_display.Text);
                        MessageBox.Show("Saved successfully");
                    }
                    else if (RadioF.Checked == true)
                    {
                        file.WriteLine("Female " + Person_name_display.Text);
                        MessageBox.Show("Saved successfully");
                    }
                    else
                    {
                        file.WriteLine("       " + Person_name_display.Text);
                        MessageBox.Show("Saved successfully");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to save","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This button generates 24 male names, then 24 female names and 2 unisex names and outputs them to console for copying
           
            Random rand = new Random();
            int goes = 0;
            string first_name;
            string last_name;
            string full_name;

            Console.WriteLine("Male names");
            while (goes < 24)
            {
                first_name = Male_first_names[rand.Next(0, Male_first_names.Count)];
                last_name = Last_names[rand.Next(0,Last_names.Count)];
                full_name = first_name + " " + last_name;
                Console.WriteLine(full_name);
                goes = goes + 1;
                    
            }
            goes = 0;
            Console.WriteLine("Female names");
            while (goes < 24)
            {
                first_name = Female_first_names[rand.Next(0, Female_first_names.Count)];
                last_name = Last_names[rand.Next(0, Last_names.Count)];
                full_name = first_name + " " + last_name;
                Console.WriteLine(full_name);
                goes = goes + 1;
            }
            goes = 0;
            Console.WriteLine("Unisex names");
            while (goes < 2 )
            {
                first_name = Unisex_first_names[rand.Next(0, Unisex_first_names.Count)];
                last_name = Last_names[rand.Next(0, Last_names.Count)];
                full_name = first_name + " " + last_name;
                Console.WriteLine(full_name);
                goes = goes + 1;
            }
            Console.WriteLine("Complete");
            
        }

        List<string> Male_first_names = new List<string>();
        List<string> Female_first_names = new List<string>();
        List<string> Unisex_first_names = new List<string>();
        List<string> Last_names = new List<string>();
        List<string> Banned_person_names = new List<string>();

        private void Person_name_generator_Load(object sender, EventArgs e)
        {
            Reload_components();
        }

        private void Reload_components()
        {
            string[] Male_1st_names;
            string[] Female_1st_names;
            string[] Unisex_1st_names;
            string[] Last_name_list; 
            string[] Banned_names;
            try
            {
                
                Male_1st_names = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Person Male first names.txt");                
                Female_1st_names = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Person Female first names.txt");                
                Unisex_1st_names = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Person Unisex first names.txt");                
                Last_name_list = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Person Last names.txt");             
                Banned_names = System.IO.File.ReadAllLines(@"..\..\..\Generator components\Banned person names.txt");

                Male_first_names.Clear();
                foreach (string S in Male_1st_names)
                {
                    Male_first_names.Add(S);
                }
                Female_first_names.Clear();
                foreach (string S in Female_1st_names)
                {
                    Female_first_names.Add(S);
                }
                Unisex_first_names.Clear();
                foreach (string S in Unisex_1st_names)
                {
                    Unisex_first_names.Add(S);
                }
                Last_names.Clear();
                foreach (string S in Last_name_list)
                {
                    Last_names.Add(S);
                }

            }
            catch (Exception E) { MessageBox.Show("Error occured: " + E, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Reload_source_BTN_Click(object sender, EventArgs e)
        {
            Reload_components();
        }

        private void Component_watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            Reload_components();
        }
    }
}
