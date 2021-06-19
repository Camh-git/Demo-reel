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
    public partial class Name_history : Form
    {
        public Name_history()
        {
            InitializeComponent();
        }

        private void Name_history_Load(object sender, EventArgs e)
        {
            //Ensuring that the list boxes are empty prior to filling
            Person_list_display.Items.Clear();
            Place_list_display.Items.Clear();

            //Creates an array for saved names, reads the history document and fills the array with that information
            string[] Person_history = System.IO.File.ReadAllLines(@"History\Person name history.txt");
            string[] Place_history = System.IO.File.ReadAllLines(@"History\Place name history.txt");


            //go through the person array, adding the value at each position to the list as a string
            for(int i = 0; i < Person_history.Length; i++)
            {
                Person_list_display.Items.Add(Person_history[i].ToString());
            }
            //The same as above but for the place array
            for (int i = 0; i < Place_history.Length; i++)
            {
                Place_list_display.Items.Add(Place_history[i].ToString());
            }
        }

        private void History_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deselect_history_Click(object sender, EventArgs e)
        {
            //Clearing each list's selected item
            Person_list_display.ClearSelected();
            Place_list_display.ClearSelected();            
        }

        private void Delete_history_Click(object sender, EventArgs e)
        {
            //Making sure at least one of the boxes has something selected
            if (Person_list_display.SelectedItem == null && Place_list_display.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Starts by removing the items from the list
            Person_list_display.Items.Remove(Person_list_display.SelectedItem);
            Place_list_display.Items.Remove(Place_list_display.SelectedItem);
            
            //Updating the file in the same way as the edit sources save button, starting with the mission list and running 3 times
            string File_location = string.Empty;
            string[] Updated_list = new string[0];

            for(int i = 0; i<2; i++)
            {
                //Setting the paramaters based on which list we are currently on
                if (i == 0)
                { Person_list_display.Sorted = true; Updated_list = Person_list_display.Items.OfType<string>().ToArray(); File_location = @"History\Person name history.txt"; }
                else if (i == 1)
                { Place_list_display.Sorted = true; Updated_list = Place_list_display.Items.OfType<string>().ToArray(); File_location = @"History\Place name history.txt"; }               
                try
                {
                    //Updating as in the edit sources page 
                    System.IO.File.WriteAllText(File_location, null);
                    for (int x = 0; x < Updated_list.Length; x++)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(File_location, true))
                            file.WriteLine(Updated_list[x]);

                    }
                }
                catch
                {
                    MessageBox.Show("Update saving failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Deleted successfully","success",MessageBoxButtons.OK,MessageBoxIcon.Information);          
        }
    }
}
