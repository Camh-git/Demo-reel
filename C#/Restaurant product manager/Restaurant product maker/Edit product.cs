using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Restaurant_product_maker
{
    public partial class Edit_product : Form
    {
        public Edit_product(List<string>Files)
        {
            InitializeComponent();
            Description_edit.Enabled = false;
            Info_edit.Enabled = false;
            Additional_nutritional_info_edit.Enabled = false; 
            string Path = "";
            foreach (string s in Files)
            {
                if (s.ToUpper().Contains("DESC"))
                { 
                    Description_edit.Enabled = true;
                    Desc_path_display.Text = s;
                    Path = Desc_path_display.Text;
                }
                else if (s.ToUpper().Contains("INFO") && !s.ToUpper().Contains("ADDITIONAL"))
                {
                    Info_edit.Enabled= true;
                    Info_path_display.Text= s;
                    Path = Info_path_display.Text;
                }
                else if (s.ToUpper().Contains("ADDITIONAL"))
                {
                    Additional_nutritional_info_edit.Enabled = true;
                    Add_info_path_display.Text = s;
                    Path = Add_info_path_display.Text;
                }

                if (Path !="") 
                {
                    //Populate product number range label and info.full_dir
                    try
                    {
                        string[] Sections = Path.Split('\\');
                        String Small_Path = Sections[Sections.Length-2];
                        Product_number_input.Text = Small_Path.Split('-')[0];
                        for(int i = 0; i < Sections.Length-1; i++)
                        {
                            Info.Full_dir += Sections[i]+="\\";
                        }
                        for (int i = 0; i < Sections.Length - 2; i++)
                        {
                            Info.Dir += Sections[i];
                        }

                    }
                    catch 
                    {
                        MessageBox.Show("ERROR: File path did not include any folders, path: " + Path,"Invalid path",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Num_range_display.Text = string.Format("Number must be between {0}000 and {0}999.", Path[0].ToString());

                }
                else
                {
                    MessageBox.Show("ERROR: No file loaded","No file",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        Prod_info Info = new Prod_info();

        private void Edit_product_Load(object sender, EventArgs e)
        {
            //For each of the selected documents, load the data into it's text boxes
            if(Desc_path_display.Text != "N/A")
            {
                string json_string = File.ReadAllText(Desc_path_display.Text);
                Description Desc = JsonConvert.DeserializeObject<Description>(json_string);
                if (Desc != null)
                {
                    Title_input.Text = Desc.Title;
                    Subtitle_input.Text = Desc.Subtitle;
                    Description_input.Text = Desc.Desc;
                    P1_input.Text = Desc.P1;
                    P2_input.Text = Desc.P2;
                    P3_input.Text = Desc.P3;
                    Major_note_input.Text = Desc.Major_note;
                    Minor_note_input.Text = Desc.Minor_note;
                }
                else
                {
                    MessageBox.Show("ERROR: The json file deserialised to null, please check the file: " + Desc_path_display.Text, "Null file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if(Info_path_display.Text != "N/A")
            {
                string json_string = File.ReadAllText(Info_path_display.Text);                
                // var Inform = JsonConvert.SerializeObject(json_string);
                json_string = json_string.Replace("\"","").Replace("{","").Replace("}","");
                string nt_info_str = json_string.Split("Nutritional_info:")[1].Split(",price")[0].Replace(" ",""); ;
                string[] nutritional_info = nt_info_str.Split(",");

                Calories_input.Text = nutritional_info[0].Split(':')[1];
                Total_fat_input.Text = nutritional_info[1].Split(':')[1];
                Sat_fat_input.Text = nutritional_info[2].Split(':')[1];
                Sugars_input.Text = nutritional_info[3].Split(':')[1];
                Salt_input.Text = nutritional_info[4].Split(':')[1];
                Price_input.Text = json_string.ToUpper().Split("PRICE:")[1].Split(",")[0].Replace(" ","");
                Prep_time_input.Text = json_string.ToUpper().Split("PREP_TIME:")[1].Split(",")[0].Replace(" ", "");
                Parallel_time_input.Text = json_string.ToUpper().Split("PARALLEL_TIME:")[1].Split(",")[0].Replace(" ", "");
                Batch_time_input.Text = json_string.ToUpper().Split("BATCH_TIME:")[1].Split(",")[0].Replace(" ", "");               
                Ingredients_input.Text = json_string.ToUpper().Split("INGREDIENTS:[")[1].Split("]")[0];
                Alergens_input.Text = json_string.ToUpper().Split("ALERGENS:[")[1].Split("]")[0];
                Warnings_input.Text = json_string.ToUpper().Split("WARNINGS:[")[1].Split("]")[0];
                Tags_input.Text = json_string.ToUpper().Split("TAGS:[")[1].Split("]")[0];

                /*Info info = JsonConvert.DeserializeObject<Info>(json_string);
                if (info != null)
                {
                    Calories_input.Text = info.Nutritional_info["Callories"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR: The json file deserialised to null, please check the file: " + Info_path_display.Text, "Null file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

            }
            if(Add_info_path_display.Text !="N/A")
            {
                string json_string = File.ReadAllText(Add_info_path_display.Text);                
                Additional_nutritional_info Info = JsonConvert.DeserializeObject<Additional_nutritional_info>(json_string);
                if (Info != null)
                {
                    Serving_size_input.Text = Info.Serving_size.ToString();
                    Trans_fat_input.Text = Info.Trans_fat.ToString();
                    Polyunsaturate_fat_input.Text = Info.Polyunsaturated_fat.ToString();
                    Monounsaturated_fat_input.Text = Info.Monounsaturated_fat.ToString();
                    Cholesterol_input.Text = Info.Cholesterol.ToString();
                    Sodium_input.Text = Info.Sodium.ToString();
                    Total_carbohydrates_input.Text = Info.Total_carbohydrates.ToString();
                    Dietary_fibre_input.Text = Info.Dietary_fibre.ToString();
                    Added_sugar_input.Text = Info.Added_sugar.ToString();
                    Sugar_alcohol_input.Text = Info.Sugar_alcohol.ToString();
                    Protein_input.Text = Info.Protein.ToString();
                    Calcium_input.Text = Info.Calcium.ToString();
                    Iron_input.Text = Info.Iron.ToString();
                    Vitamin_D_input.Text = Info.Vitamin_d.ToString();
                    Potassium_input.Text = Info.Potassium.ToString();
                    Vitamin_A_input.Text = Info.Vitamin_a.ToString();
                    Vitamin_C_input.Text = Info.Vitamin_c.ToString();
                    Vitamin_E_input.Text = Info.Vitamin_e.ToString();
                    Vitamin_B12_input.Text = Info.Vitamin_B12.ToString();
                }
                else 
                {
                    MessageBox.Show("ERROR: The json file deserialised to null, please check the file: "+Add_info_path_display.Text,"Null file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error ) ; 
                }
            }
        }

        private void Save_all_btn_Click(object sender, EventArgs e)
        {
            Description_save_btn.PerformClick();
            Add_nutritional_info_save_btn.PerformClick();
            Info_save_btn.PerformClick();
            (bool Has_thumb, int Count) = Info.Check_images(Info.Full_dir+"\\Imgs");
            Upload_product_BTN.PerformClick();
        }

        private void Add_nutritional_info_save_btn_Click(object sender, EventArgs e)
        {
            Additional_nutritional_info Add_info = Generate_add_info();

            (bool Valid, string Errors) = Info.Check_add_info(Add_info);
            if (!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors, "Input error(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info.Save_prod(Add_info_path_display.Text, System.Text.Json.JsonSerializer.Serialize(Add_info));
        }
        
        private void Description_save_btn_Click(object sender, EventArgs e)
        {
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

            Info.Save_prod(Desc_path_display.Text, System.Text.Json.JsonSerializer.Serialize(Desc));
        }
        
        private void Info_save_btn_Click(object sender, EventArgs e)
        {
            Info Information = Generate_info();           
            
            (bool Valid,string Errors) = Info.Check_info(Information);
            if(!Valid)
            {
                DialogResult DR = MessageBox.Show(Errors,"Input error(s)",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if(DR != DialogResult.Yes)
                {
                    return;
                }
            }

            Info.Save_prod(Info_path_display.Text,System.Text.Json.JsonSerializer.Serialize(Information));
        }
        
        private void Change_prod_num_btn_Click(object sender, EventArgs e)
        {
            string Path = "";
            string Old_path = "";
            if (Desc_path_display.Text !="N/A")
            { Path = Desc_path_display.Text; }
            else if (Info_path_display.Text !="N/A")
            { Path =Info_path_display.Text; }
            else if (Add_info_path_display.Text !="N/A")
            { Path = Add_info_path_display.Text; }
            else
            { 
                MessageBox.Show("ERROR: No path to file found","No path", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(Product_number_input.Text) < Info.get_prod_type_num(Info.Dir) || Convert.ToInt32(Product_number_input.Text) > Info.get_prod_type_num(Info.Dir) + 999)
            {
                MessageBox.Show(String.Format("ERROR: Invalid product number, the number must be between: {0}000 and {0}999", Info.get_prod_type_num(Info.Dir).ToString()[0]),
                    "Out of range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Find the old path, what comes after the number and the parent directory 
            string[] Sections = Path.Split('\\');
            Old_path = string.Join("\\",Sections[..^2]);
            string Post_num = Sections[Sections.Length - 2].Split('-')[1];
            string New_path = string.Join("\\", Sections[..^2]) + "\\" + Product_number_input.Text + "-" + Post_num;

            try
            {
                Directory.Move(Old_path, New_path);
                MessageBox.Show("");
            }
            catch (Exception E)
            {
                MessageBox.Show("Product and folder number update failed with exception:\n" + E,"Save error",MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void Show_image_folder_btn_Click(object sender, EventArgs e)
        {
            var Explorer = Process.Start("explorer.exe", Info.Full_dir + "Imgs");
            Explorer.WaitForExit();
        }

        private void Select_thumb_BTN_Click(object sender, EventArgs e)
        {
            Info.Create_thumbnail();
        }

        private void Desc_path_display_Click(object sender, EventArgs e)
        {

        }

        private void Upload_product_BTN_Click(object sender, EventArgs e)
        {
            string Full_path = "";
            if (Info.Full_dir !="")
            {
                Full_path = Info.Full_dir;
            }
            else if (Desc_path_display.Text !="N/A")
            {
                Full_path = Desc_path_display.Text;
            }
            else if (Info_path_display.Text !="N/A")
            {
                Full_path = Info_path_display.Text;
            }
            else if(Add_info_path_display.Text !="N/A")
            {
                Full_path = Add_info_path_display.Text;
            }
            else
            {
                MessageBox.Show("ERROR: No valid path found","No path",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            Description Desc = Generate_desc();
            (bool Valid,string Errors) = Info.Check_Desc(Desc);
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
            Info.Upload_product(Convert.ToInt32(Product_number_input.Text),Title_input.Text,Location,float.Parse(Price_input.Text),
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

        private Additional_nutritional_info Generate_add_info ()
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
