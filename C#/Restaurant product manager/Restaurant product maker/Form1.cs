using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;

namespace Restaurant_product_maker
{
    public partial class Landing_page : Form
    {
        public Landing_page()
        {
            InitializeComponent();
        }
        Prod_info prod_info = new Prod_info();

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = ("Please select the file you wish to edit");
            ofd.Filter = "Json file|*.json|All files|*.*";
            ofd.Multiselect = true;
            ofd.CheckFileExists = true;
            List<string> list = new List<string>();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    
                    list.Add(item);
                }
            }
            else
            {
                MessageBox.Show("File selection failed, canceling.","Dialog not ok",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            Edit_product edit = new Edit_product(list);
            edit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_product prod = new new_product();
            prod.Show();
        }

        private void Landing_page_Load(object sender, EventArgs e)
        {
            Populate_schema("C:\\httpd-2.4.53-win64-VS16\\Apache24\\htdocs\\Restaurant site\\Serverside\\Products\\Code_schema.txt");            
        }

        private void Manual_schema_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = ("Please select the file you wish to edit");
            ofd.Filter = "Text file|*.txt|All files|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Populate_schema(ofd.FileName);
            }
        }

        private void Populate_schema(string path)
        {
            Manual_schema_load.Enabled = false;
            Manual_schema_load.Visible = false;
            try
            {
                string[] Lines = File.ReadAllLines(path);
                if (Lines.Length != 0)
                {
                    foreach (String S in Lines)
                    {
                        Schema_display.Text += S + "\n";
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            {
                MessageBox.Show("Failed to load schema for display, the program will still work, but the guide will not be populated.");
                Manual_schema_load.Enabled = true;
                Manual_schema_load.Visible = true;
                Schema_display.Text = "Error: file not found";
            }
        }

        private void Upload_prod_to_DB_BTN_Click(object sender, EventArgs e)
        {
            prod_info.Upload_product_from_folder();           
        }
    }
}