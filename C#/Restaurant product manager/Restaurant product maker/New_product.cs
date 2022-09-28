using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Restaurant_product_maker
{
    

    public partial class new_product : Form
    {
        public new_product()
        {
            InitializeComponent();
        }
        Prod_info Info = new Prod_info();  
        

        private void Dir_select_BTN_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = ("Please select the correct directory for this type of product");
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    Info.Dir = (fbd.SelectedPath);
                    Dir_display.Text = Info.Dir;                   
                    Num_range_display.Text = string.Format("Number must be between {0}000 and {0}999.", Info.get_prod_type_num(Info.Dir).ToString()[0]);
                }
            
            }
        }       

      

        private void Obj_setup_btn_Click(object sender, EventArgs e)
        {
            //Check all required fields are populated
            if(Product_number_input.Text == "")
            {
                MessageBox.Show("Please enter a product number before continuing.","Null number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(Product_name_input.Text == "")
            {
                MessageBox.Show("Please enter a product name before continuing.", "Null name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Dir_display.Text == "N/A")
            {
                MessageBox.Show("Please select the product's folder before continuing.", "Null dir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Check for duplicate numbers/names
            string[] Dirs = Directory.GetDirectories(Info.Dir);
            foreach (String S in Dirs)
            {
                if (Convert.ToInt32(Product_number_input.Text) == Info.get_prod_num(S))
                {
                    MessageBox.Show("ERROR: Invalid product number, this number is already taken","Number in use",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (S.ToUpper().Contains(Product_name_input.Text.ToUpper()))
                {
                    MessageBox.Show("ERROR: Invalid product name, this name is already taken by product: " + Info.get_prod_type_num(S), "Name in use", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //Check number is within allowed range
            if(Convert.ToInt32(Product_number_input.Text) < Info.get_prod_type_num(Info.Dir) || Convert.ToInt32(Product_number_input.Text) > Info.get_prod_type_num(Info.Dir)+999)
            {
                MessageBox.Show(String.Format("ERROR: Invalid product number, the number must be between: {0}000 and {0}999", Info.get_prod_type_num(Info.Dir).ToString()[0]),
                    "Out of range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;             
            }

            //create & populate the directory, then move on to the next step
            Info.Full_dir = String.Format("{0}\\{1}-{2}", Info.Dir, Product_number_input.Text, Product_name_input.Text);
            if (Directory.Exists(Info.Full_dir))
            {
                MessageBox.Show("Error: directory: " + Info.Full_dir + " already exists, directory not created", "Directory exists",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            else
            {                
                Directory.CreateDirectory(Info.Full_dir);
                Directory.CreateDirectory(Info.Full_dir+"\\Imgs"); 
                DirectoryInfo Dir_info = new DirectoryInfo(Info.Full_dir);
                try
                {
                    File.Copy(Dir_info.Parent.Parent + "\\Prod-Template\\Info.json", Info.Full_dir + "\\Info.json");
                }
                catch 
                {
                    File.Create(Info.Full_dir + "\\Info.json");
                    MessageBox.Show("Failed to copy the Info.json template, a blank Info.json file has been created.","Copy error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                try
                {
                    File.Copy(Dir_info.Parent.Parent + "\\Prod-Template\\Desc.json", Info.Full_dir + "\\Desc.json");
                }
                catch
                {
                    File.Create(Info.Full_dir + "\\Desc.json");
                    MessageBox.Show("Failed to copy the Desc.json template, a blank Desc.json file has been created.", "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                try
                {
                    File.Copy(Dir_info.Parent.Parent + "\\Prod-Template\\Additional_nutritional_info.json", Info.Full_dir + "\\Additional_nutritional_info.json");
                }
                catch
                {
                    File.Create(Info.Full_dir + "\\Info.json");
                    MessageBox.Show("Failed to copy the Additional_nutritional_info.json template, a blank file has been created.", "Copy error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                        
            Setup_edit.Enabled = false;
            Description_edit.Enabled = true;
            Info_edit.Enabled = true;
            Additional_nutritional_info_edit.Enabled = true;
            Finish_btn.Enabled = true;
            Show_imgs_btn.Enabled = true;
            Title_input.Text = Product_name_input.Text;

        }
        private void Description_save_btn_Click(object sender, EventArgs e)
        {
            Description Desc = new Description();
            Desc.Title = Title_input.Text;
            Desc.Subtitle = Subtitle_input.Text;
            Desc.P1 = P1_input.Text;
            Desc.P2 = P2_input.Text;
            Desc.P3 = P3_input.Text;
            Desc.Desc = Description_input.Text;
            Desc.Major_note = Major_note_input.Text;
            Desc.Minor_note = Minor_note_input.Text;

            (bool Valid, string Errors) = Info.Check_Desc(Desc);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info.Save_prod(Info.Full_dir+"\\Desc.json",System.Text.Json.JsonSerializer.Serialize(Desc));
        }

        private void Info_save_btn_Click(object sender, EventArgs e)
        {            
            Info info = new Info();
            try
            {
                info.Nutritional_info["Calories"] = Convert.ToInt32(Calories_input.Text);
                info.Nutritional_info["Total_fat"] = float.Parse(Total_fat_input.Text);
                info.Nutritional_info["Saturated_fat"] = float.Parse(Sat_fat_input.Text);
                info.Nutritional_info["Sugars"] = float.Parse(Sugars_input.Text);
                info.Nutritional_info["Salt"] = float.Parse(Salt_input.Text);
                info.Price = float.Parse(Price_input.Text);
                info.Prep_time = Convert.ToInt32(Prep_time_input.Text);
                info.Parallel_time = Convert.ToInt32(Parallel_time_input.Text);
                info.Batch_time = Convert.ToInt32(Batch_time_input.Text);
            }
            catch
            {
                MessageBox.Show("The following entries must be populated in order to save an info file:\nCallories\nTotal fat\nSat fat\nSugars\nSalt\nPrice\nThe file will not be" +
                    "saved until all these entries have values.","Empty value", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            info.Ingredients.Clear();
            string[] Ingredients = Ingredients_input.Text.Split(',');
            foreach (String S in Ingredients)
            {
                info.Ingredients.Add(S.Trim());
            }
            info.Alergens.Clear();
            string[] Alergens = Alergens_input.Text.Split(',');
            foreach (string S in Alergens)
            {
                info.Alergens.Add(S.Trim());
            }
            info.Warnings.Clear();
            string[] Warnings = Warnings_input.Text.Split(',');
            foreach (string S in Warnings)
            {
                info.Warnings.Add(S.Trim());
            }
            info.Tags.Clear();
            string[] Tags = Tags_input.Text.Split(',');
            foreach (string S in Tags)
            {
                info.Tags.Add(S.Trim());
            }

            (bool Valid, string Errors) = Info.Check_info(info);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info.Save_prod(Info.Full_dir + "\\Info.json", System.Text.Json.JsonSerializer.Serialize(info));
        }

        private void Add_nutritional_info_save_btn_Click(object sender, EventArgs e)
        {
            Additional_nutritional_info Add_info = new Additional_nutritional_info();
            Add_info.Serving_size = Convert.ToInt32(Serving_size_input.Text);
            Add_info.Trans_fat = float.Parse(Trans_fat_input.Text);
            Add_info.Polyunsaturated_fat = float.Parse(Trans_fat_input.Text);
            Add_info.Monounsaturated_fat = float.Parse(Monounsaturated_fat_input.Text);
            Add_info.Cholesterol = float.Parse(Cholesterol_input.Text);
            Add_info.Sodium = float.Parse(Sodium_input.Text);
            Add_info.Total_carbohydrates = float.Parse(Total_carbohydrates_input.Text);
            Add_info.Dietary_fibre = float.Parse(Dietary_fibre_input.Text);
            Add_info.Added_sugar = float.Parse(Added_sugar_input.Text);
            Add_info.Sugar_alcohol = float.Parse(Sugar_alcohol_input.Text);
            Add_info.Protein = float.Parse(Protein_input.Text);
            Add_info.Calcium = float.Parse(Calcium_input.Text);
            Add_info.Iron = float.Parse(Iron_input.Text);
            Add_info.Vitamin_d = float.Parse(Vitamin_D_input.Text);
            Add_info.Potassium = float.Parse(Potassium_input.Text);
            Add_info.Vitamin_a = float.Parse(Vitamin_A_input.Text);
            Add_info.Vitamin_c = float.Parse(Vitamin_C_input.Text);
            Add_info.Vitamin_e = float.Parse(Vitamin_E_input.Text);
            Add_info.Vitamin_B12 = float.Parse(Vitamin_B12_input.Text);

            (bool Valid, string Errors) = Info.Check_add_info(Add_info);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info.Save_prod(Info.Full_dir + "\\Additional_nutritional_info.json", System.Text.Json.JsonSerializer.Serialize(Add_info));
        }

        private void Finish_btn_Click(object sender, EventArgs e)
        {
            //ask user if they want to save filess
            DialogResult Save = MessageBox.Show("Save before exiting?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);            
            if (Save == DialogResult.Yes)
            {
                bool [] Done = { false, false, false, false,false,false };//0=all done, 1=desc, 2=info, 3=add info, 4=upload, 5=Image_check pass
                while (!Done[0])
                {
                    string Failed_saves = "";
                    if (!Done[1])
                    {
                        try
                        {
                            Description_save_btn.PerformClick();
                            Done[1] = true;
                        }
                        catch
                        {
                            Failed_saves += "\nDesc.json" ;
                        }
                    }
                    if (!Done[2])
                    {
                        try
                        {
                            Info_save_btn.PerformClick();
                            Done[2] = true;
                        }
                        catch
                        {
                            Failed_saves += "\nInfo.json";
                        }
                    }
                    if (!Done[3])
                    {
                        try
                        {
                            Add_nutritional_info_save_btn.PerformClick();
                            Done[3] = true;
                        }
                        catch
                        {
                            Failed_saves += "\nAdditional_nutritional_info";
                        }
                    }  
                    if (!Done[4])
                    {
                        try
                        {
                            Upload_product_BTN.PerformClick();
                        }
                        catch
                        {
                            Failed_saves += "Database upload";
                        }
                    }
                    if (!Done[5])
                    {
                        try
                        {
                            Info.Check_images(Info.Full_dir+"\\images");
                        }
                        catch
                        {
                            Failed_saves += "Image check";
                        }
                    }
                    

                    if (Done[1] && Done[2] && Done[3])
                    {
                        if (!Done[4])
                        {
                            DialogResult retry = MessageBox.Show("Files saved but product failed to upload,  Retry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (retry == DialogResult.No)
                            {
                                Done[0] = true;
                            }
                            else
                            { break; }
                        }
                        if (!Done[5])
                        {
                            DialogResult retry = MessageBox.Show("Files saved but iamge check failed, Retry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (retry == DialogResult.No)
                            {
                                Done[0] = true;
                            }
                            else
                            { break; }
                        }
                        Done[0] = true;
                        MessageBox.Show("All files saved successfully, closing", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult retry = MessageBox.Show("The following files failed to save: " + Failed_saves + "Retry?","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                        if (retry == DialogResult.No)
                        {
                            Done[0] = true;
                        }
                    }
                }
            }
            this.Close();
        }

        private void Show_imgs_btn_Click(object sender, EventArgs e)
        {
            Process Explorer = new Process();
               // Process.Start("explorer.exe", Info.Full_dir + "\\Imgs");
            Explorer.EnableRaisingEvents = true;
            Explorer.Exited += Explorer_Exited;
            Explorer.Start();
        }

        private void Explorer_Exited(object? sender, EventArgs e)
        {
            MessageBox.Show("ended");
        }

        private void new_product_Load(object sender, EventArgs e)
        {
            Description_edit.Enabled = false;
            Info_edit.Enabled = false;
            Additional_nutritional_info_edit.Enabled=false;
            Finish_btn.Enabled = false;
            Show_imgs_btn.Enabled = false;
        }

        private void Set_thumb_BTN_Click(object sender, EventArgs e)
        {
            Info.Create_thumbnail();            
        }

        private void Upload_product_BTN_Click(object sender, EventArgs e)
        {
            string Full_path = "";
            if (Info.Full_dir != "")
            {
                Full_path = Info.Full_dir;
            }
            else
            {
                MessageBox.Show("ERROR: No valid path found", "No path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Description Desc = Generate_desc();
            (bool Valid, string Errors) = Info.Check_Desc(Desc);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info Info_for_JSON = Generate_info();
            (Valid, Errors) = Info.Check_info(Info_for_JSON);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Additional_nutritional_info Add_info = Generate_add_info();
            (Valid, Errors) = Info.Check_add_info(Add_info);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            string Prod_desc_json = System.Text.Json.JsonSerializer.Serialize(Desc);
            string Prod_info_json = System.Text.Json.JsonSerializer.Serialize(Info_for_JSON);
            string Prod_add_info_json = System.Text.Json.JsonSerializer.Serialize(Add_info);

            string Location = Full_path.Split("Products")[1];
            Info.Upload_product(Convert.ToInt32(Product_number_input.Text), Title_input.Text, Location, float.Parse(Price_input.Text),
                Prod_desc_json, Prod_info_json, Prod_add_info_json);
        }

        private Description Generate_desc()
        {
            Description Desc = new Description();
            Desc.Title = Title_input.Text;
            Desc.Subtitle = Subtitle_input.Text;
            Desc.Desc = Description_input.Text;
            Desc.P1 = P1_input.Text;
            Desc.P2 = P2_input.Text;
            Desc.P3 = P3_input.Text;
            Desc.Major_note = Major_note_input.Text;
            Desc.Minor_note = Minor_note_input.Text;
            return (Desc);
        }

        private Info Generate_info()
        {
            Info Prod_info = new Info();
            Prod_info.Nutritional_info["Calories"] = float.Parse(Calories_input.Text);
            Prod_info.Nutritional_info["Total_fat"] = float.Parse(Total_fat_input.Text);
            Prod_info.Nutritional_info["Saturated_fat"] = float.Parse(Sat_fat_input.Text);
            Prod_info.Nutritional_info["Sugars"] = float.Parse(Sugars_input.Text);
            Prod_info.Nutritional_info["Salt"] = float.Parse(Salt_input.Text);
            Prod_info.Price = float.Parse(Price_input.Text);
            Prod_info.Prep_time = Convert.ToInt32(Prep_time_input.Text);
            Prod_info.Parallel_time = Convert.ToInt32(Parallel_time_input.Text);
            Prod_info.Batch_time = Convert.ToInt32(Batch_time_input.Text);
            Prod_info.Ingredients.Clear();

            Prod_info.Ingredients.Clear();
            string[] Ingredients = Ingredients_input.Text.Split(',');
            foreach (string S in Ingredients)
            {
                Prod_info.Ingredients.Add(S.Trim());
            }
            Prod_info.Alergens.Clear();
            string[] Alergens = Alergens_input.Text.Split(',');
            foreach (string S in Alergens)
            {
                Prod_info.Alergens.Add(S.Trim());
            }
            Prod_info.Warnings.Clear();
            string[] Warnings = Warnings_input.Text.Split(',');
            foreach (string S in Warnings)
            {
                Prod_info.Warnings.Add(S.Trim());
            }
            Prod_info.Tags.Clear();
            string[] Tags = Tags_input.Text.Split(',');
            foreach (string S in Tags)
            {
                Prod_info.Tags.Add(S.Trim());
            }
            return (Prod_info);
        }

        private Additional_nutritional_info Generate_add_info()
        {
            Additional_nutritional_info Add_info = new Additional_nutritional_info();
            Add_info.Serving_size = Convert.ToInt32(Serving_size_input.Text);
            Add_info.Trans_fat = float.Parse(Trans_fat_input.Text);
            Add_info.Polyunsaturated_fat = float.Parse(Trans_fat_input.Text);
            Add_info.Monounsaturated_fat = float.Parse(Monounsaturated_fat_input.Text);
            Add_info.Cholesterol = float.Parse(Cholesterol_input.Text);
            Add_info.Sodium = float.Parse(Sodium_input.Text);
            Add_info.Total_carbohydrates = float.Parse(Total_carbohydrates_input.Text);
            Add_info.Dietary_fibre = float.Parse(Dietary_fibre_input.Text);
            Add_info.Added_sugar = float.Parse(Added_sugar_input.Text);
            Add_info.Sugar_alcohol = float.Parse(Sugar_alcohol_input.Text);
            Add_info.Protein = float.Parse(Protein_input.Text);
            Add_info.Calcium = float.Parse(Calcium_input.Text);
            Add_info.Iron = float.Parse(Iron_input.Text);
            Add_info.Vitamin_d = float.Parse(Vitamin_D_input.Text);
            Add_info.Potassium = float.Parse(Potassium_input.Text);
            Add_info.Vitamin_a = float.Parse(Vitamin_A_input.Text);
            Add_info.Vitamin_c = float.Parse(Vitamin_C_input.Text);
            Add_info.Vitamin_e = float.Parse(Vitamin_E_input.Text);
            Add_info.Vitamin_B12 = float.Parse(Vitamin_B12_input.Text);

            return (Add_info);
        }
    }
}
