using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace database_update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // the database used here is a simple xampp local database called test with the table test_table being modified, it has the collums id(primary), name and age
            // the contents are irrelevent and the database should be re-createable to a working degree from just the information above
            
        }
        SqlConnection connection = new SqlConnection("datasource=localhost; port=3306; database=test; username=root; password=");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // creates the sql command to update the system, the comment bellow is an explainer of how it's put together
                // the two are different to make it practical to acutaly use
                // update "table name" set (thing being changed) "collum name"="new value" where "location, eg id =1" 

                using (SqlCommand command = new SqlCommand("update test_table set name =@name , age = @age where id =@id", connection))
                {

                    //adds the required paramaters, apparently you get sql injected to death otherwise
                    command.Parameters.AddWithValue("name", Update_name_box.Text);
                    command.Parameters.AddWithValue("age", Convert.ToInt32(Update_age_box.Text));
                    command.Parameters.AddWithValue("id", Update_ID_box.Value);

                    //exectues the command, notifies the user and closes the connection
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                //creates  a random id for the new user, irl this would be more complicated and check to see if it's been used already
                Random rand = new Random();
                int generated_id = rand.Next(1, 1000);

                //creates the command to insert the new user
                using (SqlCommand command = new SqlCommand("insert into test_table (id, name, age) Values(@id, @name, @age) ", connection))
                {
                    command.Parameters.AddWithValue("id", generated_id);
                    command.Parameters.AddWithValue("name", New_name.Text);
                    command.Parameters.AddWithValue("age", New_age.Text);

                    //executes the command, displays the user id and closes the connection
                    command.ExecuteNonQuery();
                    MessageBox.Show("user inserted, your ID is " + generated_id);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                //displays a message box to ensure that the user wants to continue
                DialogResult delete_dialog = MessageBox.Show("this action will permanently delete the user, are you sure you wish to continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (delete_dialog == DialogResult.No)
                { return; }

                connection.Open();

                //sets up the command to delete the user
                using (SqlCommand command = new SqlCommand("delete from test_table where id=@id", connection))
                {
                    command.Parameters.AddWithValue("id", Delete_ID.Value);

                    //executes the command, notifies the user and closes the connection
                    command.ExecuteNonQuery();
                    MessageBox.Show("user deleted");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Read_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                //sets up the reader and command
                using (SqlCommand command = new SqlCommand("select * from test_table where id=@id", connection))
                {
                    command.Parameters.AddWithValue("id", Read_ID.Value);

                    //executes the command and has the reader hold the data, note that the reader does not access the database itself
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //checks to ensure the result is not null
                            if (reader["id"] != DBNull.Value)
                            {
                                //tells the user the information, closes the connection and exits before it would drop out of the loop
                                MessageBox.Show("the user's name is " + reader["name"].ToString() + " and they are " + reader["age"].ToString());
                                Age_label.Text = reader["age"].ToString();
                                string collum = reader["age"].ToString();
                                connection.Close();
                                return;
                            }

                        }
                    }
                }
                //if the value is null the program will drop out of the loop, inform the user and close
                MessageBox.Show("user not found, please try again");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Demonstrating an sql transaction
            bool Good = false;
            connection.Open();
            SqlTransaction mytrans = connection.BeginTransaction();

            try
            {
                //do stuff
                Good = true;
            }
            catch
            {
                MessageBox.Show("An error occured, the transaction will be rolled back");
                Good = false;
            }

            if (Good = true)
            {
                mytrans.Commit();
            }
            else
            {
                mytrans.Rollback();
            }
            mytrans.Dispose();

            connection.Close();

        }
    }
}
