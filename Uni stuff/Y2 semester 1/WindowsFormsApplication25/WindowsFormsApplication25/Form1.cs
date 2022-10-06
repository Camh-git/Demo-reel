using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication25
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
            table.Columns.Add("usage",typeof(int));
            table.Columns.Add("drug",typeof(string));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         // table.Row.add(25 "lincoln","david", 12);
          table.Rows.Add(25, "lincoln");
          table.Rows.Add(12,"david");
          table.Rows.Add(30, "emtrel");
          table.Rows.Add(13,"bob");
          dataGridView1.DataSource = table;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();  //gets rid of useless extra label on button press
            chart1.Series.Add("age");
            this.chart1.Series["age"].Points.AddY(50);
            this.chart1.Series["age"].Points.AddY(30);
            this.chart1.Series["age"].Points.AddY(12);
            this.chart1.Series["age"].Points.AddY(13);
            
        }
    }
}
