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
    public partial class Main_menu : Form
    {
        public Main_menu()
        {
            InitializeComponent();
        }
            

        private void Open_person_Click(object sender, EventArgs e)
        {
            Form Person_name_generator = new Person_name_generator();
            Person_name_generator.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Name_history = new Name_history();
            Name_history.Show();
        }

        private void Open_edit_Click(object sender, EventArgs e)
        {
            Form Edit_sources = new Edit_sources();
            Edit_sources.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Place_name_generator = new Place_name_generator();
            Place_name_generator.Show();
        }
    }
}
