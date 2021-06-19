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
    public partial class Edit_sources : Form
    {
        public Edit_sources()
        {
            InitializeComponent();
        }

        private void Close_edit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_sources_Load(object sender, EventArgs e)
        {
            //Ensures that the list boxes are empty prior to filling
            Male_first_name_list.Items.Clear();
            Female_first_name_list.Items.Clear();
            Unisex_first_name_list.Items.Clear();
            Last_name_list.Items.Clear();
            Place_prefix_list.Items.Clear();
            Place_suffix_list.Items.Clear();

            //Sorts the lists
            Male_first_name_list.Sorted = true;
            Female_first_name_list.Sorted = true;
            Unisex_first_name_list.Sorted = true;
            Last_name_list.Sorted = true;
            Place_prefix_list.Sorted = true;
            Place_suffix_list.Sorted = true;

            //Creates arrays for the prefix lists

            string [] Person_male_first_names = System.IO.File.ReadAllLines(@"Generator components\Person Male first names.txt");
            string [] Person_female_first_names = System.IO.File.ReadAllLines(@"Generator components\Person Female first names.txt");
            string [] Person_unisex_first_names = System.IO.File.ReadAllLines(@"Generator components\Person Unisex first names.txt");
            string [] Person_last_names = System.IO.File.ReadAllLines(@"Generator components\Person Last names.txt");

            string[] Place_prefixes = System.IO.File.ReadAllLines(@"Generator components\Place prefix list.txt");
            string[] Place_suffixes = System.IO.File.ReadAllLines(@"Generator components\Place suffix list.txt");
           
            //Fills the lists with the relevent data
            //Goes through the array, adding the value at each position to the list as a string
            int Record_number = 0;          
            Record_number = 0;
            while (Record_number < Person_male_first_names.Length)
            {
                Male_first_name_list.Items.Add(Person_male_first_names[Record_number].ToString());
                Record_number++;
            }
            Record_number = 0;
            while (Record_number < Person_female_first_names.Length)
            {
                Female_first_name_list.Items.Add(Person_female_first_names[Record_number].ToString());
                Record_number++;
            }
            Record_number = 0;
            while (Record_number < Person_unisex_first_names.Length)
            {
                Unisex_first_name_list.Items.Add(Person_unisex_first_names[Record_number].ToString());
                Record_number++;
            }
            Record_number = 0;
            while (Record_number < Person_last_names.Length)
            {
                Last_name_list.Items.Add(Person_last_names[Record_number].ToString());
                Record_number++;
            }
            Record_number = 0;
            while (Record_number < Place_prefixes.Length)
            {
                Place_prefix_list.Items.Add(Place_prefixes[Record_number].ToString());
                Record_number++;
            }
            Record_number = 0;
            while (Record_number < Place_suffixes.Length)
            {
                Place_suffix_list.Items.Add(Place_suffixes[Record_number].ToString());
                Record_number++;
            }

        }

        
        //Add new entry buttons, they are almost identical     
        
        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(Male_name_box.Text))
                {
                    MessageBox.Show("please enter a value first");
                }
                else
                    Male_first_name_list.Items.Add(Male_name_box.Text);
                Male_name_box.Text = string.Empty;
            }
        }
        private void Add_female_name_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Female_name_box.Text))
            {
                MessageBox.Show("please enter a value first");
            }
            else
                Female_first_name_list.Items.Add(Female_name_box.Text);
            Female_name_box.Text = string.Empty;
        }
        private void Add_unisex_name_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Unisex_name_box.Text))
            {
                MessageBox.Show("please enter a value first");
            }
            else
                Unisex_first_name_list.Items.Add(Unisex_name_box.Text);
            Unisex_name_box.Text = string.Empty;
        }
        private void Add_surname_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Surname_box.Text))
            {
                MessageBox.Show("please enter a value first");
            }
            else
                Last_name_list.Items.Add(Surname_box.Text);
            Surname_box.Text = string.Empty;

        }
        private void Add_place_prefix_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Place_prefix_box.Text))
            {
                MessageBox.Show("please enter a value first");
            }
            else
                Place_prefix_list.Items.Add(Place_prefix_box.Text);
            Place_prefix_box.Text = string.Empty;
        }
        private void Add_place_suffix_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Place_suffix_box.Text))
            {
                MessageBox.Show("please enter a value first");
            }
            else
                Place_suffix_list.Items.Add(Place_suffix_box.Text);
            Place_suffix_box.Text = string.Empty;
        }


        //Delete selected entry buttons       
        private void Delete_male_name_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Male_first_name_list.Items.Remove(Male_first_name_list.SelectedItem);
        }
        private void Delete_female_name_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Female_first_name_list.Items.Remove(Female_first_name_list.SelectedItem);
        }
        private void Delete_unisex_name_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Unisex_first_name_list.Items.Remove(Unisex_first_name_list.SelectedItem);
        }
        private void Delete_surname_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Last_name_list.Items.Remove(Last_name_list.SelectedItem);
        }
        private void Delete_place_prefix_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Place_prefix_list.Items.Remove(Place_prefix_list.SelectedItem);
        }
        private void Delete_place_suffix_BTN_Click(object sender, EventArgs e)
        {
            //Removes the entry in the selected position from the list
            Place_suffix_list.Items.Remove(Place_suffix_list.SelectedItem);
        }

        //Edit selected entry buttons, they are almost identical
        
        private void Edit_male_name_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Male_name_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Male_first_name_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Male_first_name_list.Items.IndexOf(Male_first_name_list.SelectedItem);
                Male_first_name_list.Items.RemoveAt(selected);
                Male_first_name_list.Items.Insert(selected, Male_name_box.Text);
                Male_name_box.Text = string.Empty;
            }
        }
        private void Edit_female_name_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Female_name_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Female_first_name_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Female_first_name_list.Items.IndexOf(Female_first_name_list.SelectedItem);
                Female_first_name_list.Items.RemoveAt(selected);
                Female_first_name_list.Items.Insert(selected, Female_name_box.Text);
                Female_name_box.Text = string.Empty;
            }
        }
        private void Edit_unisex_name_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Unisex_name_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Unisex_first_name_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Unisex_first_name_list.Items.IndexOf(Unisex_first_name_list.SelectedItem);
                Unisex_first_name_list.Items.RemoveAt(selected);
                Unisex_first_name_list.Items.Insert(selected, Unisex_name_box.Text);
                Unisex_name_box.Text = string.Empty;
            }
        }
        private void Edit_surname_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Surname_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Last_name_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Last_name_list.Items.IndexOf(Last_name_list.SelectedItem);
                Last_name_list.Items.RemoveAt(selected);
                Last_name_list.Items.Insert(selected, Surname_box.Text);
                Surname_box.Text = string.Empty;
            }
        }
        private void Edit_place_prefix_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Place_prefix_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Place_prefix_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Place_prefix_list.Items.IndexOf(Place_prefix_list.SelectedItem);
                Place_prefix_list.Items.RemoveAt(selected);
                Place_prefix_list.Items.Insert(selected, Place_prefix_box.Text);
                Place_prefix_box.Text = string.Empty;
            }

        }
        private void Edit_place_suffix_BTN_Click(object sender, EventArgs e)
        {
            //First we make sure the user has both filled in the box and selected the item as failure to do this without checking would crash the program
            if (string.IsNullOrWhiteSpace(Place_suffix_box.Text))
            {
                MessageBox.Show("Please make sure you have entered the edited word");
                return;
            }
            else if (Place_suffix_list.SelectedItem == null)
            {
                MessageBox.Show("Please select the word to be replaced");
                return;
            }
            else
            {
                //Gets the index of the item, removes the existing item and enters the new word in it's place
                int selected = Place_suffix_list.Items.IndexOf(Place_suffix_list.SelectedItem);
                Place_suffix_list.Items.RemoveAt(selected);
                Place_suffix_list.Items.Insert(selected, Place_suffix_box.Text);
                Place_suffix_box.Text = string.Empty;
            }
        }


        private void Save_changes_btn_Click(object sender, EventArgs e)
        {
            //Finds the correct list and saves it to the appropriate file
            string File_location = string.Empty;
            string[] Updated_list = new string[0];

            if (List_to_save_Select.Text == "Male first names")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Male_first_name_list.Sorted = true;
                Updated_list = Male_first_name_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Person Male first names.txt";
            }

            else if (List_to_save_Select.Text == "Female first names")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Female_first_name_list.Sorted = true;
                Updated_list = Female_first_name_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Person Female first names.txt";
            }

            else if (List_to_save_Select.Text == "Unisex first names")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Unisex_first_name_list.Sorted = true;
                Updated_list = Unisex_first_name_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Person Unisex first names.txt";
            }

            else if (List_to_save_Select.Text == "Last names")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Last_name_list.Sorted = true;
                Updated_list = Last_name_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Person Last names.txt";
            }

            else if (List_to_save_Select.Text == "Place prefixes")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Place_prefix_list.Sorted = true;
                Updated_list = Place_prefix_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Place prefix list.txt";
            }

            else if (List_to_save_Select.Text == "Place suffixes")
            {
                //Sorts list alphabeticaly, converts the list to the update array and defines the file location
                Place_suffix_list.Sorted = true;
                Updated_list = Place_suffix_list.Items.OfType<string>().ToArray();
                File_location = @"Generator components\Place suffix list.txt";

            }
            //If an apropriate list is not found displays an error message and returns
            else
            { MessageBox.Show("Please select a list to save","Invalid selection",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            //Updates the file
            try
            {
                //Overwrites or creates the existing file
                System.IO.File.WriteAllText(File_location, null);
                int Update_item = 0;
                while (Update_item < Updated_list.Length)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(File_location, true))
                        file.WriteLine(Updated_list[Update_item]);

                    Update_item++;
                }
                MessageBox.Show("Updates saved successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Update saving failed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

        }       

        private void Sort_all_lists_Click(object sender, EventArgs e)
        {
            Male_first_name_list.Sorted =false;
            Female_first_name_list.Sorted = false;
            Unisex_first_name_list.Sorted = false;
            Last_name_list.Sorted = false;
            Place_prefix_list.Sorted = false;
            Place_suffix_list.Sorted = false;
            //Sorts all of the lists
            Male_first_name_list.Sorted = true;
            Female_first_name_list.Sorted = true;
            Unisex_first_name_list.Sorted = true;
            Last_name_list.Sorted = true;
            Place_prefix_list.Sorted = true;
            Place_suffix_list.Sorted = true;
        }

        private void Deselect_BTN_Click(object sender, EventArgs e)
        {
            ///Goes through each of the list and clears anything selected in each of themS
            Male_first_name_list.ClearSelected();
            Female_first_name_list.ClearSelected();
            Unisex_first_name_list.ClearSelected();
            Last_name_list.ClearSelected();
            Place_prefix_list.ClearSelected();
            Place_suffix_list.ClearSelected();
                
        }

        private void Reload_sources_BTN_Click(object sender, EventArgs e)
        {
            //Opens a new copy of the form and closes this one as its easier then wiping and refiling the lists
            Form Edit_sources = new Edit_sources();
            Edit_sources.Show();
            this.Close();

        }

 
    }
}
