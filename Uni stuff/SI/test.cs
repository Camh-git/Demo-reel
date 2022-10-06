using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            
        }
        public int room(int rooms)
        {
            while (id != null)// this should be a foreach for the rooms
            {

                if (freeDates != Room.ReservedDate) ;
                {
                    return (rooms);
                }

            }
            if (rooms == null)
            {
                throw new NotImplementedException(); //throwing an error if the rooms list is empty
            }
            return (null);
            rooms = 2;//the rooms being looked for
            
            Console.WriteLine(rooms);
             return (rooms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomno = room(2);
            MessageBox.Show(roomno.ToString());
        }

           
       
    
        

    }
}
