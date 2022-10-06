using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WindowsFormsApplication35
{
      
    public partial class EmptyView : Form
    { 
       
       

        public EmptyView()
        {
          
             InitializeComponent();
            //Seting boxes to the default visibility, opening the connection, creating the tables  and addapters and filling the individual boxes
            //The first 2 boxs are no longer relevent
            IndivBox.Visible = false;
            Data.MultiSelect = false;
            HelpBox.Visible = false;
            PrintBox.Visible = false;
            SearchBox.Visible = false;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+@" C:\Users\camer_000\Documents\asignments y2\vp\assignment 2\WindowsFormsApplication35\WindowsFormsApplication35\Vp employees.accdb";
            OleDbDataAdapter adapter;
            DataTable dt = new DataTable();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Conecting to the database and filling the datagrid view.
            // TODO: This line of code loads data into the 'vp_employeesDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.vp_employeesDataSet.Table1);


        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //Slightly excessive button.
            MessageBox.Show("Connected");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            //     OleDbConnection conn = new OleDbConnection();
            // ensureing that it's still connected 

            Variables.lastrowno = Variables.lastrowno + 1;
            MessageBox.Show("Use the datagridview to add new rows");

            //After writing this code I  realised that the datagridview could be used to do this more efficiently, so it is commented out.
            /*
           conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+@"C:\Users\camer_000\Documents\asignments y2\vp\assignment 2\WindowsFormsApplication35\WindowsFormsApplication35\Vp employees.accdb";
            conn.Open();
            OleDbCommand cmmd = new OleDbCommand("INSERT INTO table1 (VP employees) lastrowno.Value (@Employee id)", conn);
            cmmd.Parameters.Add("@Name", OleDbType.VarWChar, 20).Value = Inbox;

            String sql ="INSERT INTO table1 (Employee id ) Values (@Employee id)";

            try
            {
                conn.Open();
            }
            catch
            { }
            Data.Refresh();
            Variables.currentshowingindiv = Variables.currentshowingindiv + 1;*/
          

            
            
            MessageBox.Show("entry added, click eddit to add information, alternativly use the datagridview to both add and edit");
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            //Since it's done by the datagridview i'm not going to add some extra code
            MessageBox.Show("Click on the relevent collum to sort it");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //Applys any changes made in the form to the database
            //This is done by filling a table with the information which is then sent through the dataset and onto the database via an adapter
        
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\camer_000\Documents\asignments y2\vp\assignment 2\WindowsFormsApplication35\WindowsFormsApplication35\Vp employees.accdb";
            conn.Open();
            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //OleDbCommandBuilder build = new OleDbCommandBuilder(adapter);  

            DataTable dtFromGrid = vp_employeesDataSet.Tables.Add();
            dtFromGrid = Data.DataSource as DataTable;

            this.table1BindingSource.EndEdit();
            Vp_employeesDataSet acceptchanges;
            table1TableAdapter.Update(this.vp_employeesDataSet.Table1);

            //Filing the adapter back up with the new information so as to keep the form up to date
            this.table1TableAdapter.Fill(this.vp_employeesDataSet.Table1);


            MessageBox.Show("Database updated");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //DeleteBox.Visible = true;
            MessageBox.Show("Items can be deleted using the datagridview");
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //EditBox.Visible = true;
            MessageBox.Show("Data entries can be edited using the datagridview");
        }

        private void HideEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpBox.Visible = true;
        }

        private void table1BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            IndivBox.Visible = false;
        }

        private void Individual_Click(object sender, EventArgs e)
        {
            IndivBox.Visible = true;
            IndivContent();
        }

        private void HelpHide_Click(object sender, EventArgs e)
        {
            HelpBox.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchBox.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void IndivContent()
        {
            //Setting each of the textboxes to inherit the value from the relevent rows and  cells.
            IndivID.Text = Data.Rows[Variables.currentshowingindiv].Cells["employeeIdDataGridViewTextBoxColumn"].Value.ToString();
            IndivName.Text = Data.Rows[Variables.currentshowingindiv].Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString();
            IndivDept.Text = Data.Rows[Variables.currentshowingindiv].Cells["employeeDepartmentDataGridViewTextBoxColumn"].Value.ToString();
            IndivSalary.Text = Data.Rows[Variables.currentshowingindiv].Cells["employeeSalaryDataGridViewTextBoxColumn"].Value.ToString();
            IndivAge.Text = Data.Rows[Variables.currentshowingindiv].Cells["employeeAgeDataGridViewTextBoxColumn"].Value.ToString();
         }

        private void Next_Click(object sender, EventArgs e)
        {
            //Adds one to the current possiton in order to cycle through the records, also stops the user from going past the final entry
            Variables.currentshowingindiv = Variables.currentshowingindiv + 1;
            
            if (Variables.currentshowingindiv >= Variables.lastrowno)
            {
                Variables.currentshowingindiv = Variables.currentshowingindiv -1;
                MessageBox.Show("You have reached the last entry and cannot go forward");
            }
            //populating boexes after checking to avoid bugs
            IndivContent();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            //Takes one from the current possiton in order to cycle through the records, also stops the user from going past the first entry
            Variables.currentshowingindiv = Variables.currentshowingindiv -1;
        
            if(Variables.currentshowingindiv == -1)
            {
                // making sure the user can't set the number to be bellow 0
                Variables.currentshowingindiv = Variables.currentshowingindiv +1;
                IndivContent();
                MessageBox.Show("The first record is being displayed, cannot go further back"); 
            }
            //populating boexes after checking to avoid bugs
            IndivContent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintBox.Visible = true;
            // Prints the values for each of the employees names into the textbox.
            PrintTarget.Text = Data.Rows[1].Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString() + Data.Rows[2].Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString()
            + Data.Rows[3].Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString() + Data.Rows[4].Cells["employeeNameDataGridViewTextBoxColumn"].Value.ToString();
        }
        private void PrintHIde_Click(object sender, EventArgs e)
        {
            PrintBox.Visible = false;
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void HideSearch_Click(object sender, EventArgs e)
        {
            SearchBox.Visible = false;
        }

        private void SearchNow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search complete");
            // search method goes here
        }
    }
}
