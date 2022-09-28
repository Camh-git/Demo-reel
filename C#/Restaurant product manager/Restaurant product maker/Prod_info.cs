using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_product_maker
{
    internal class Prod_info
    {
        private string Con_str = "datasource = 192.168.0.110; port=3306; database=Restaurant_DB; username = Restaurant_user; password = L3tm31n; sslmode=none;";
        public string Connection_string
        {
            get { return Con_str; }  set { Con_str = value; }
        }
        private string dir = "";
        public string Dir
        { 
            get { return dir; } 
            set
            {
                if (value.Contains("\\") || value.Contains("/"))
                {
                    
                    dir = value;
                }
                else
                {
                    MessageBox.Show("Error: Invalid string passed as dir, string was: " + value);
                }
            } 
        }
        private string name = "";
        public string Name
            { get { return name; } set { name = value; } }
        
        private int number = 0;
        public int Number
            { get { return number; } set { number = value; } }
        
        private string full_dir = "";
        public string Full_dir
            { get { return full_dir; } set { full_dir = value; } }

        ///<returns>int</returns>
        public int get_prod_type_num(string Dir)
        {
            int num = 0;
            if (Dir[Dir.Length-1] == '\\')
            {
                Dir = Dir.Substring(0, Dir.Length-1);
            }
            string[] Sections = Dir.Split('\\');
            string Path = Sections[Sections.Length - 1];
            num = Convert.ToInt32(Path.Split('-')[0]);
            return num;
        }
        ///<returns>int</returns>
        public int get_prod_num(string Dir)
        {
            int num = 0;
            if (Dir[Dir.Length - 1] == '\\')
            {
                Dir = Dir.Substring(0, Dir.Length - 2);
            }
            string[] Sections = Dir.Split('\\');
            string Path = Sections[Sections.Length - 2];
            num = Convert.ToInt32(Path.Split('-')[0]);
            return num;
        }
        ///<summary>
        ///<para>Takes the file path and json string</para>
        ///<returns>Void</returns>
        ///</summary>
        public void Save_prod(string Path, string Content)
        {
            try
            {
                File.WriteAllText(Path, Content);
                MessageBox.Show("Successfully updated file:" + Path.Split("Serverside\\")[1], "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            { MessageBox.Show("Update/save failed with exception:\n " + E, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        ///<summary>
        ///<para>Takes the file path and creates a 120*120px image called Thumbnail.thumb</para>
        ///<returns>Void</returns>
        ///</summary>
        public void Create_thumbnail(string path = "")
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = ("Please select the image for the thumbnail");
            ofd.Filter = "JPEG|*.JPG|PNG file|*.png|All files|*.*";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.InitialDirectory = path;
            string Chosen_img = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Chosen_img = ofd.FileName;
            }
            else
            {
                MessageBox.Show("File selection failed, canceling.", "Dialog not ok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Image img = Image.FromFile(Chosen_img);
            Image thumb = img.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            thumb.Save(Path.ChangeExtension(Chosen_img, "thumb"));
            MessageBox.Show("Thumbnail created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        ///<summary>
        ///<para>Checks the given folder to check if it contains a thumbnail</para>
        ///<returns>Bool passed, int file count</returns>
        ///</summary>
        public (bool,int) Check_images(string Path)
        {
            bool Has_thumb = false;
            int File_count = 0;
            foreach (string S in Directory.GetFiles(Path))
            {
                string[] Levels = S.Split("\\");
                string Filename = Levels[Levels.Length - 1];
                if (Filename.ToUpper().Contains("THUMB"))
                {
                    Has_thumb = true;
                }
                File_count++;
            }

            if (File_count < 2)
            {
                MessageBox.Show("Warning: Item does not have enough images, it should have at least 1 image and a seperate thumbnail(file ending in.thumb)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!Has_thumb)
            {
                DialogResult D = MessageBox.Show("ERROR: The images file doesn't contain a thumbnail, would you like to set one now?", "No thumbnail", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (D == DialogResult.Yes)
                {
                    Create_thumbnail();
                }
                else
                {
                    MessageBox.Show("No thumbnail, item may not display as intended", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (Has_thumb,File_count);
        }
        ///<summary>
        ///<para>Performs checks on a Description object to check for errors and issues</para>
        ///<returns>Bool passed, string info</returns>
        ///</summary>
        public (bool,string) Check_Desc(Description Desc)
        {
            bool Passed = true;
            string Errors = "The entry contains the following errors:\n";
            if (Desc.Title=="" || Desc.Title.Length == 0)
            {
                Passed = false;
                Errors += "Product must have a title\n";
            }
            if (Desc.Subtitle == "" || Desc.Subtitle.Length == 0)
            {
                Passed = false;
                Errors += "Product does not have a Subtitle\n";
            }
            if (Desc.P1 == "" || Desc.P1.Length == 0)
            {
                Passed = false;
                Errors += "Product does not have a first paragraph, it must have at least one\n";
            }
            if(Desc.Desc == "" || Desc.Desc.Length == 0)
            {
                Passed = false;
                Errors += "Product must have a description\n";
            }
            Errors += "\nAre you sure you want to save?";
            return (Passed,Errors);
        }
        ///<summary>
        ///<para>Performs checks on an Info object to check for errors and issues</para>
        ///<returns>Bool passed, string info</returns>
        ///</summary>
        public (bool, string) Check_info(Info info)
        {
            bool Passed = true;
            string Errors = "The entry contains the following errors:\n";
            if (info.Price <= 0)
            {
                Passed = false;
                Errors += "Price is less than or equal to £0.00\n";
            }
            if (info.Parallel_time > info.Prep_time)
            {
                Passed = false;
                Errors += "Prarallel_time is greater than total time\n";
            }
            if (info.Nutritional_info["Calories"] > 2000)
            {
                Passed = false;
                Errors += "Warning: calorie count exceeds GDA\n";
            }
            else if (info.Nutritional_info["Calories"] < 1)
            {
                Passed = false;
                Errors += "Calorie count must be at least 1\n";
            }
            if (info.Nutritional_info["Total_fat"] > 70)
            {
                Passed = false;
                Errors += "Warning: Fat content exceeds GDA\n";
            }
            if (info.Nutritional_info["Saturated_fat"] > 20)
            {
                Passed = false;
                Errors += "Warning: Saturated fat exceeds GDA\n";
            }
            if (info.Nutritional_info["Sugars"] > 90)
            {
                Passed = false;
                Errors += "Warning: Sugar content exceeds GDA\n";
            }
            if (info.Nutritional_info["Salt"] > 6)
            {
                Passed = false;
                Errors += "Warning: Salt content exceeds GDA\n";
            }
            if (info.Ingredients.Count <= 0)
            {
                Passed = false;
                Errors += "Dish must have at least 1 ingredient\n";
            }
            Errors += "\nAre you sure you want to save?";
            return (Passed,Errors);
        }

        ///<summary>
        ///<para>Performs checks on a Additional_nutritional_info object to check for errors and issues</para>
        ///<returns>Bool passed, string info</returns>
        ///</summary>
        public (bool,string) Check_add_info(Additional_nutritional_info Add)
        {
            bool Passed = true;
            string Errors = "The entry contains the following errors:\n";
            if (Add.Serving_size <= 0)
            {
                Passed = false;
                Errors += "Serving size cannot be 0\n";
            }
            if (Add.Total_carbohydrates >260)
            {
                Passed = false;
                Errors += "Warning: Total carbohydrates exceed GDA0\n";
            }
            if (Add.Protein >50)
            {
                Passed = false;
                Errors += "Warning: Protein content exceeds GDA\n";
            }
            if (Add.Vitamin_a > 700)
            {
                Passed = false;
                Errors += "Warning: Vitamin A content too high\n";
            }
            if (Add.Vitamin_B12 > 100)
            {
                Passed = false;
                Errors += "Warning: Vitamin B content too high\n";
            }
            if (Add.Vitamin_c > 100)
            {
                Passed = false;
                Errors += "Warning: Vitamin C content too high\n";
            }
            if (Add.Vitamin_d > 200)
            {
                Passed = false;
                Errors += "Warning: Vitamin D content too high\n";
            }
            if (Add.Vitamin_e > 540)
            {
                Passed = false;
                Errors += "Warning: Vitamin E content exceeds recomendations\n";
            }
            if (Add.Calcium > 1500)
            {
                Passed = false;
                Errors += "Warning: Calcuim content too high\n";
            }
            if (Add.Iron > 20)
            {
                Passed = false;
                Errors += "Warning: Iron content too high\n";
            }
            if (Add.Dietary_fibre > 24)
            {
                Passed = false;
                Errors += "Warning: Fibre content exceeds GDA\n";
            }

            Errors += "\nAre you sure you want to save?";
            return (Passed, Errors);
        }
        ///<summary>
        ///<para>Opens an folder browser and extracts data from the files, then calls upload_product </para>
        ///<returns>Bool success, string error</returns>
        ///</summary>

        public void Upload_product_from_folder()
        {
            List<string> list = new List<string>();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select the product folder to upload";

            string info_file = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                foreach (string item in files)
                {
                    if (item.Contains(".json"))
                    {

                        list.Add(item);

                        if (item.Contains("Info.json"))
                        {
                            info_file = item;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("File selection failed, canceling.", "Dialog not ok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (list.Count != 3)
            {
                MessageBox.Show("Please select the folder containing the 3 json files that describe the item", "Invalid folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string full_name = fbd.SelectedPath.Split("\\")[fbd.SelectedPath.Split("\\").Length - 1];

            int ID = Convert.ToInt32(full_name.Split("-")[0]);
            string Name = full_name.Split("-")[1].Replace("_", " ");
            string Location = fbd.SelectedPath.Split("Products")[1];
            fbd.Dispose();

            //TODO: create json strings from the files to pass to uploads
            string[] info_entries = File.ReadAllText(info_file).Split(",");
            float Price = 0.00f;
            int Prep_time = 0;
            foreach (string entry in info_entries)
            {
                if (entry.ToUpper().Contains("PRICE"))
                {
                    Price = float.Parse(entry.Split(":")[1]);
                }
                else if (entry.ToUpper().Contains("PREP_TIME"))
                {
                    Prep_time = Convert.ToInt32(entry.Split(":")[1]);
                }

            }
            Upload_product(ID, Name, Location, Price);

        }
        //TODO: maybe mod this to report info to callers
        ///<summary>
        ///<para>Takes required info and creates an entry in the products database,Json strings and overwrite check optional</para>
        ///<returns>Void</returns>
        ///</summary>
        public void Upload_product(int ID, string Name, string Location, float Price, string Desc_json ="", string Info_json ="", string Add_info_json ="", bool Check_exists = true)
        {
            using (MySqlConnection Conn = new MySqlConnection(Connection_string))
            {

                Conn.Open();
                MySqlTransaction Transaction = Conn.BeginTransaction();
                if(Check_exists)
                {
                    using (MySqlCommand Find_product = new MySqlCommand("SELECT name FROM Products WHERE ID = @ID", Conn))
                    { 
                        Find_product.Parameters.AddWithValue("@ID", ID);
                        using (MySqlDataReader Reader = Find_product.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                DialogResult Overwrite_warn = MessageBox.Show("A product called " + Reader.GetString("Name") + " is already using this ID, would you like to overwrite?",
                                    "ID match found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                Reader.Close();
                                if (Overwrite_warn == DialogResult.Yes)
                                {
                                    try
                                    {
                                        MySqlCommand Overwrite = new MySqlCommand("DELETE FROM Products WHERE ID = @ID", Conn, Transaction);
                                        Overwrite.Parameters.AddWithValue("@ID", ID);
                                        Overwrite.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Failed to overwrite old entry, cancelling upload","Overwrite error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else { return;/*This is the return if the user says they don't want to continue, not if no existing product is found, don't delete this*/ }
                            }
                            Reader.Close();
                        }
                    }
                }
                using (MySqlCommand set_mode = new MySqlCommand("SET SESSION sql_mode = ''", Conn))
                {
                    set_mode.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Products (ID,Name,Info,Price,Desc_json,Info_json,Add_info_json)VALUES" +
                    "(@ID,@NAME,@INFO,@PRICE,@INFO_JSON,@DESC_JSON,@ADD_JSON)", Conn, Transaction))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@NAME", Name);
                    cmd.Parameters.AddWithValue("@INFO", Location);
                    cmd.Parameters.AddWithValue("@PRICE", Price);
                    cmd.Parameters.AddWithValue("@DESC_JSON", Desc_json);
                    cmd.Parameters.AddWithValue("@INFO_JSON",Info_json);                   
                    cmd.Parameters.AddWithValue("@ADD_JSON", Add_info_json);

                    //try
                    //{
                        cmd.ExecuteNonQuery();
                    /*}
                    catch (Exception E)
                    {
                        MessageBox.Show("Failed with the following error:\n" + E.ToString(), "Upload error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmd.Dispose();
                        Transaction.Rollback();
                        Conn.Close();
                        return;
                    }*/
                    cmd.Dispose();
                }
                Transaction.Commit();
                Conn.Close();
                MessageBox.Show("Upload completed successfully", "Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}
