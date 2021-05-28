using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overloading_and_multi_return
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Overloading, this is usefull as it allows mutliple functions with the same name, so a caller can call a function(such as add) with a variety of inputs that 
        //will all be handled appropriatly and still give the same result(a more complex version might have multiple methods that format the inputs then call a processor method)
        public double add (int a, int b)
        {
            double result = a + b;
            return (result);
        }
        public double add (int a, double b)
        {
            double result = a + b;
            return (result);
        }
        public double add (double a, double b)
        {
            double result = a + b;
            return(result);
        }

        //tuples, allows a method to return more than one value
        (double, string) Marked_add(int a, int b)
        {
            double result = a + b;
            return (result, "method 1");
        }
        (double, string) Marked_add(int a, double b)
        {
            double result = a + b;
            return (result, "method 2");
        }
        (double, string) Marked_add(double a, double b)
        {
            double result = a + b;
            return (result,"method 3");
        }


        private void Run_overload_Click(object sender, EventArgs e)
        {
            double answer = add(5.1,7.2);
            MessageBox.Show("Result: " + answer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //note: the vars can be named, this lets you access them as answer.name
            (double,string) answer = Marked_add(5,7.2);
            MessageBox.Show("Result:" + answer.Item1 + " " + answer.Item2 + " was used.");
        }
        //to check if a dec is also an int: if (dec % 1 == 0)
    }
}
