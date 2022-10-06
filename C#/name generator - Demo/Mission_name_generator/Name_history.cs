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
            Mission_list_display.Items.Clear();
            Person_list_display.Items.Clear();
            Place_list_display.Items.Clear();

            //Creates an array for saved names, reads the history document and fills the array with that information
            string [] Mission_history = System.IO.File.ReadAllLines(@"..\..\..\History\Mission name history.txt");
            string[] Person_history = System.IO.File.ReadAllLines(@"..\..\..\History\Person name history.txt");
            string[] Place_history = System.IO.File.ReadAllLines(@"..\..\..\History\Place name history.txt");

            //Goes through the mission array, adding the value at each position to the list as a string
            int Record_number = 0;
            while (Record_number < Mission_history.Length)
            {
                Mission_list_display.Items.Add(Mission_history[Record_number].ToString());
                Record_number++;
            }          

            //Resets the counter, then goes through the person array, adding the value at each position to the list as a string
            Record_number = 0;
            while (Record_number < Person_history.Length)
            {
                Person_list_display.Items.Add(Person_history[Record_number].ToString());
                Record_number++;
            }
            //Resets the counter, then goes through the place array, adding the value at each position to the list as a string
            Record_number = 0;
            while (Record_number < Place_history.Length)
            {
                Place_list_display.Items.Add(Place_history[Record_number].ToString());
                Record_number++;
            }
        }

        private void History_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deselect_history_Click(object sender, EventArgs e)
        {
            //Clearing each list's selected item
            Mission_list_display.ClearSelected();
            Person_list_display.ClearSelected();
            Place_list_display.ClearSelected();            
        }

        private void Delete_history_Click(object sender, EventArgs e)
        {
            //Making sure at least one of the boxes has something selected
            if (Mission_list_display.SelectedItem == null && Person_list_display.SelectedItem == null && Place_list_display.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Starts by removing the items from the list
            Mission_list_display.Items.Remove(Mission_list_display.SelectedItem);
            Person_list_display.Items.Remove(Person_list_display.SelectedItem);
            Place_list_display.Items.Remove(Place_list_display.SelectedItem);
            
            //Updating the file in the same way as the edit sources save button, starting with the mission list and running 3 times
            string File_location = string.Empty;
            string[] Updated_list = new string[0];
            int List_no = 1;

            while (List_no < 4)
            {
                //Setting the paramaters based on which list we are currently on
                if (List_no == 1)
                { Mission_list_display.Sorted = true; Updated_list = Mission_list_display.Items.OfType<string>().ToArray(); File_location = @"..\..\..\History\Mission name history.txt"; }
                else if (List_no == 2)
                { Person_list_display.Sorted = true; Updated_list = Person_list_display.Items.OfType<string>().ToArray(); File_location = @"..\..\..\History\Person name history.txt"; }
                else if (List_no == 3)
                { Place_list_display.Sorted = true; Updated_list = Place_list_display.Items.OfType<string>().ToArray(); File_location = @"..\..\..\History\Place name history.txt"; }
                else if (List_no == 4)
                { MessageBox.Show("it got to 4, idk how"); return; }
                try
                {
                    //Updating as in the edit sources page 
                    System.IO.File.WriteAllText(File_location, null);
                    int Update_item = 0;
                    while (Update_item < Updated_list.Length)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(File_location, true))
                            file.WriteLine(Updated_list[Update_item]);

                        Update_item++;
                    }
                    List_no++;
                }
                catch
                {
                    MessageBox.Show("Update saving failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Updates saved successfully","success",MessageBoxButtons.OK,MessageBoxIcon.Information);          
        }
    }
}
