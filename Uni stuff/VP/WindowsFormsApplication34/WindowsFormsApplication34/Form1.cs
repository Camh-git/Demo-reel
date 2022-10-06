using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication34
{
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
            int Current_Question = Variables.Current_Question;
            Current_Question = 1;
           


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //provides inital values to several variables
            Help_box.Visible = false;
            Results.Visible = false;
            Flaged_questions.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chose_answer_Click(object sender, EventArgs e)
        {

            Chose_answer.Visible = false;
            //Hides the  button when clicked

            if (Answer1.Checked)
            { Variables.question1correct = true; }
            else Variables.question1correct = false;

            if (Answer2.Checked) { Variables.question1correct = false; }
            if (Answer3.Checked) { Variables.question1correct = false; }
            if (Answer4.Checked) { Variables.question1correct = false; }
           Variables.question1answered = true;
            //If multiple boxes are ticked and one of them is correct it will initialy set to true before going down and setting (correctly) to false.
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Question_number.Value = Question_number.Value + 1;
            //nextcheck();

            //keeps the question number from being able to get high enough that there will be no questions visible
            if (Question_number.Value == 11)
            {
                Question_number.Value = Question_number.Value - 1;
                MessageBox.Show("You have reached the final question, if you have answered them all please click the finish button to see your score.");
            }
            
            txtboxcolor();
            flagedboxcolor();
        }

        public void nextcheck()
          {
              if ((Variables.question1flaged = true) && (Variables.question1answered = false )) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question2flaged = true) && (Variables.question2answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question3flaged = true) && (Variables.question3answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question4flaged = true) && (Variables.question4answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question5flaged = true) && (Variables.question5answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question6flaged = true) && (Variables.question6answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question7flaged = true) && (Variables.question7answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question8flaged = true) && (Variables.question8answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question9flaged = true) && (Variables.question9answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }
              if ((Variables.question10flaged = true) && (Variables.question10answered = false)) { MessageBox.Show("you have not answered the question, you will need to either flag or answer it"); }

          }
 
        public void Finish_Click(object sender, EventArgs e)
        {
            //Stops the finish button from running if you have flaged questions
            anyflag();
            if (Variables.Any_flaged == true)
            {
                MessageBox.Show("You have flaged questions, please answer them before finishing");
                return;
            }

            Results.Visible = true;
            int correct_count = 0;
            // Clears the list so that it won't retain incorrect data from the second use of the finish button onwards 
            Correct_list.Items.Clear();
            Incorrect_list.Items.Clear();


            // Adding up the correct answers and changing box colours for correct/incorrect answers.
            if (Variables.question1correct == true)
            { correct_count = correct_count + 1; textBox1.BackColor = Color.Green; Correct_list.Items.Add("Question1"); }
            else if (Variables.question1correct == false)
            { textBox1.BackColor = Color.Red; Chose_answer.Visible = true; Incorrect_list.Items.Add("Question1"); }

            if (Variables.question2correct == true)
            { correct_count = correct_count + 1; textBox2.BackColor = Color.Green; Correct_list.Items.Add("Question2"); }
            else if (Variables.question2correct == false)
            { textBox2.BackColor = Color.Red; Chose_answer2.Visible = true; Incorrect_list.Items.Add("Question2"); }

            if (Variables.question3correct == true)
            { correct_count = correct_count + 1; textBox3.BackColor = Color.Green; Correct_list.Items.Add("Question3"); }
            else if (Variables.question3correct == false)
            { textBox3.BackColor = Color.Red; Chose_answer3.Visible = true; Incorrect_list.Items.Add("Question3"); }

            if (Variables.question4correct == true)
            { correct_count = correct_count + 1; textBox4.BackColor = Color.Green; Correct_list.Items.Add("Question4"); }
            else if (Variables.question4correct == false)
            { textBox4.BackColor = Color.Red; Chose_answer4.Visible = true; Incorrect_list.Items.Add("Question4"); }

            if (Variables.question5correct == true)
            { correct_count = correct_count + 1; textBox5.BackColor = Color.Green; Correct_list.Items.Add("Question5"); }
            else if (Variables.question5correct == false)
            { textBox5.BackColor = Color.Red; Chose_answer5.Visible = true; Incorrect_list.Items.Add("Question5"); }

            if (Variables.question6correct == true)
            { correct_count = correct_count + 1; textBox6.BackColor = Color.Green; Correct_list.Items.Add("Question6"); }
            else if (Variables.question6correct == false)
            { textBox6.BackColor = Color.Red; Chose_answer6.Visible = true; Incorrect_list.Items.Add("Question6"); }

            if (Variables.question7correct == true)
            { correct_count = correct_count + 1; textBox7.BackColor = Color.Green; Correct_list.Items.Add("Question7"); }
            else if (Variables.question7correct == false)
            { textBox7.BackColor = Color.Red; Chose_answer7.Visible = true; Incorrect_list.Items.Add("Question7"); }

            if (Variables.question8correct == true)
            { correct_count = correct_count + 1; textBox8.BackColor = Color.Green; Correct_list.Items.Add("Question8"); }
            else if (Variables.question8correct == false)
            { textBox8.BackColor = Color.Red; Chose_answer8.Visible = true; Incorrect_list.Items.Add("Question8"); }

            if (Variables.question9correct == true)
            { correct_count = correct_count + 1; textBox9.BackColor = Color.Green; Correct_list.Items.Add("Question9"); }
            else if (Variables.question9correct == false)
            { textBox9.BackColor = Color.Red; Chose_answer9.Visible = true; Incorrect_list.Items.Add("Question9"); }

            if (Variables.question10correct == true)
            { correct_count = correct_count + 1; textBox10.BackColor = Color.Green; Correct_list.Items.Add("Question10"); }
            else if (Variables.question10correct == false)
            { textBox10.BackColor = Color.Red; Chose_answer10.Visible = true; Incorrect_list.Items.Add("Question10"); }

            //Detects how many times the finish code has run and keeps the score at it's value from the first time it was run
            Variables.Times_finished = Variables.Times_finished + 1;

            if (Variables.Times_finished == 1)
            { Variables.First_score = correct_count; }
            //Asigns the score on the first run to a variable and sets the score to it on any consecutive runs 
            if (Variables.Times_finished > 1)
            { correct_count = Variables.First_score; }

            if (correct_count > 0 && (correct_count < 6))
            {
                MessageBox.Show("You got  under 60%,try again");
                Score_comment.Text = ("Try again");
            }
            if (correct_count > 5 && (correct_count < 8))
            {
                MessageBox.Show("You got  between 60% and 80%");
                Score_comment.Text = ("Good job");
            }

            if (correct_count > 7 && (correct_count < 10))
            {
                MessageBox.Show("Well done you got over 80%");
                Score_comment.Text = ("Well done");
            }
            if (correct_count > 9)
            {
                MessageBox.Show("Perfect, you got 100%");
                Score_comment.Text = ("Perfect!");
            }
            Percent_text.Text = correct_count.ToString();
            Score_text.Text = correct_count.ToString();
            Incorrect_list.Visible = false;
            Correct_list.Visible = false;
        }
        public void anyflag()
        {// a simple method to check if any of the questions are flaged and set anyfalged to true if so 
            if (Variables.question1flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question2flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question3flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question4flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question5flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question6flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question7flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question8flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question9flaged == true) { Variables.Any_flaged = true; return; }
            if (Variables.question10flaged == true) { Variables.Any_flaged = true; return; }
            else { Variables.Any_flaged = false;}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Chose_answer2.Visible = false;
         
            if (Answer_2.Checked)
            { Variables.question2correct = true; }
            else Variables.question2correct = false;

            if (Answer_1.Checked) { Variables.question2correct = false; }
            if (Answer_3.Checked) { Variables.question2correct = false; }
            if (Answer_4.Checked) { Variables.question2correct = false; }
            Variables.question2answered = true;
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            Question_number.Value = Question_number.Value - 1;
            //Stops the value of the question number going bellow 0 and crashing.
            if (Question_number.Value == 0)
            {
                Question_number.Value = Question_number.Value + 1;
            }
            txtboxcolor();
            flagedboxcolor();

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // The following code it used to check the value of Question_number and decide if each question should be visible or not.
            if (Question_number.Value == 1)
            { Question1.Visible = true; }
            else { Question1.Visible = false; }

            if (Question_number.Value == 2)
            { Question2.Visible = true; }
            else { Question2.Visible = false; }

            if (Question_number.Value == 3)
            { Question3.Visible = true; }
            else { Question3.Visible = false; }

            if (Question_number.Value == 4)
            { Question4.Visible = true; }
            else { Question4.Visible = false; }

            if (Question_number.Value == 5)
            { Question5.Visible = true; }
            else { Question5.Visible = false; }

            if (Question_number.Value == 6)
            { Question6.Visible = true; }
            else { Question6.Visible = false; }

            if (Question_number.Value == 7)
            { Question7.Visible = true; }
            else { Question7.Visible = false; }

            if (Question_number.Value == 8)
            { Question8.Visible = true; }
            else { Question8.Visible = false; }

            if (Question_number.Value == 9)
            { Question9.Visible = true; }
            else { Question9.Visible = false; }

            if (Question_number.Value == 10)
            { Flag.Visible = true; }
            else { Flag.Visible = false; }


        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            //Closes the start menu and prepares for the user to view the first question
            Question_number.Value = Question_number.Value + 1;
            Start_menu.Visible = false;
            Question1.Visible = true;
            textBox1.BackColor = Color.Blue;
        }

        public void txtboxcolor()
        {
            //Method to be called by the next and previous buttons that allows the textbox for the corresponding question to change colour when selected
            if (Question_number.Value == 1)
            { textBox1.BackColor = Color.Blue; }
            else textBox1.BackColor = Color.White;

            if (Question_number.Value == 2)
            { textBox2.BackColor = Color.Blue; }
            else textBox2.BackColor = Color.White;

            if (Question_number.Value == 3)
            { textBox3.BackColor = Color.Blue; }
            else textBox3.BackColor = Color.White;

            if (Question_number.Value == 4)
            { textBox4.BackColor = Color.Blue; }
            else textBox4.BackColor = Color.White;

            if (Question_number.Value == 5)
            { textBox5.BackColor = Color.Blue; }
            else textBox5.BackColor = Color.White;

            if (Question_number.Value == 6)
            { textBox6.BackColor = Color.Blue; }
            else textBox6.BackColor = Color.White;

            if (Question_number.Value == 7)
            { textBox7.BackColor = Color.Blue; }
            else textBox7.BackColor = Color.White;

            if (Question_number.Value == 8)
            { textBox8.BackColor = Color.Blue; }
            else textBox8.BackColor = Color.White;

            if (Question_number.Value == 9)
            { textBox9.BackColor = Color.Blue; }
            else textBox9.BackColor = Color.White;

            if (Question_number.Value == 10)
            { textBox10.BackColor = Color.Blue; }
            else textBox10.BackColor = Color.White;

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Chose_answer3.Visible = false;
          
            if (Answer8.Checked)
            { Variables.question3correct = true; }
            else Variables.question3correct = false;

            if (Answer5.Checked) { Variables.question3correct = false; }
            if (Answer6.Checked) { Variables.question3correct = false; }
            if (Answer7.Checked) { Variables.question3correct = false; }
            Variables.question3answered = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chose_answer4.Visible = false;
            
            if (Answer10.Checked)
            { Variables.question4correct = true; }
            else Variables.question4correct = false;

            if (Answer9.Checked) { Variables.question4correct = false; }
            if (Answer11.Checked) { Variables.question4correct = false; }
            if (Answer12.Checked) { Variables.question4correct = false; }
            Variables.question4answered = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chose_answer5.Visible = false;
            
            if (Answer15.Checked)
            { Variables.question5correct = true; }
            else Variables.question5correct = false;

            if (Answer13.Checked) { Variables.question5correct = false; }
            if (Answer14.Checked) { Variables.question5correct = false; }
            if (Answer16.Checked) { Variables.question5correct = false; }
            Variables.question5answered = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Chose_answer6.Visible = false;
          
            if (Answer19.Checked)
            { Variables.question6correct = true; }
            else Variables.question6correct = false;

            if (Answer17.Checked) { Variables.question6correct = false; }
            if (Answer18.Checked) { Variables.question6correct = false; }
            if (Answer20.Checked) { Variables.question6correct = false; }
            Variables.question6answered = true;
        }

        private void Chose_answer7_Click(object sender, EventArgs e)
        {
            Chose_answer7.Visible = false;
           
            if (Answer24.Checked)
            { Variables.question7correct = true; }
            else Variables.question7correct = false;

            if (Answer21.Checked) { Variables.question7correct = false; }
            if (Answer22.Checked) { Variables.question7correct = false; }
            if (Answer23.Checked) { Variables.question7correct = false; }
            Variables.question7answered = true;

        }

        private void Chose_answer8_Click(object sender, EventArgs e)
        {
            Chose_answer8.Visible = false;
          
            if (Answer25.Checked)
            { Variables.question8correct = true; }
            else Variables.question8correct = false;

            if (Answer26.Checked) { Variables.question8correct = false; }
            if (Answer27.Checked) { Variables.question8correct = false; }
            if (Answer28.Checked) { Variables.question8correct = false; }
            Variables.question8answered = true;
        }

        private void Chose_answer9_Click(object sender, EventArgs e)
        {
            Chose_answer9.Visible = false;
         
            if (Answer30.Checked)
            { Variables.question9correct = true; }
            else Variables.question9correct = false;

            if (Answer29.Checked) { Variables.question9correct = false; }
            if (Answer31.Checked) { Variables.question9correct = false; }
            if (Answer32.Checked) { Variables.question9correct = false; }
            Variables.question9answered = true;
        }

        private void Chose_answer10_Click(object sender, EventArgs e)
        {
            Chose_answer10.Visible = false;
            
            if (Answer33.Checked)
            { Variables.question10correct = true; }
            else Variables.question10correct = false;

            if (Answer34.Checked) { Variables.question10correct = false; }
            if (Answer35.Checked) { Variables.question10correct = false; }
            if (Answer36.Checked) { Variables.question10correct = false; }
            Variables.question10answered = true;
        }

        private void Help_button_Click(object sender, EventArgs e)
        {
            //shows the help box and hides the start menu
            Help_box.Visible = true;
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //hides the help box and shows the start menu
            Help_box.Visible = false;
            Start_menu.Visible = true;
        }

        private void Results_back_Click(object sender, EventArgs e)
        {
            //Hides the results box on request
            Results.Visible = false;
        }

        private void Help_box_Enter(object sender, EventArgs e)
        {

        }

        private void View_incorrect_Click(object sender, EventArgs e)
        {
            //Shows the list of incorrect answers
            //The lists where originaly going to be vivible by default but the specification required a button to show it.
            Incorrect_list.Visible = true;
            View_incorrect.Visible = false;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {   //Shows the list of correct answers
            //The lists where originaly going to be vivible by default but the specification required a button to show it.
            Correct_list.Visible = true;
            View_correct_btn.Visible = false;
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            //restart button
            Application.Restart();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            //flaged variable, if flaged turn orange, when finish is pressed prompt to check flags
            if (Question_number.Value == 1) { Variables.question1flaged = true; }
            if (Question_number.Value == 2) { Variables.question2flaged = true; }
            if (Question_number.Value == 3) { Variables.question3flaged = true; }
            if (Question_number.Value == 4) { Variables.question4flaged = true; }
            if (Question_number.Value == 5) { Variables.question5flaged = true; }
            if (Question_number.Value == 6) { Variables.question6flaged = true; }
            if (Question_number.Value == 7) { Variables.question7flaged = true; }
            if (Question_number.Value == 8) { Variables.question8flaged = true; }
            if (Question_number.Value == 9) { Variables.question9flaged = true; }
            if (Question_number.Value == 10) { Variables.question10flaged = true; }
            // way to unflag. check if q ur on is flaged, if so button changes to unflag and pressing it removes  flaging

            flagedboxcolor();
           // Is_flaged();
        }

        public void flagedboxcolor()
        {
           //method to detect if a question is flaged and change it's colour if it is
            if (Variables.question1flaged == true) { textBox1.BackColor = Color.Orange; }
            if (Variables.question2flaged == true) { textBox2.BackColor = Color.Orange; }
            if (Variables.question3flaged == true) { textBox3.BackColor = Color.Orange; }
            if (Variables.question4flaged == true) { textBox4.BackColor = Color.Orange; }
            if (Variables.question4flaged == true) { textBox4.BackColor = Color.Orange; }
            if (Variables.question5flaged == true) { textBox5.BackColor = Color.Orange; }
            if (Variables.question6flaged == true) { textBox6.BackColor = Color.Orange; }
            if (Variables.question7flaged == true) { textBox7.BackColor = Color.Orange; }
            if (Variables.question8flaged == true) { textBox8.BackColor = Color.Orange; }
            if (Variables.question9flaged == true) { textBox9.BackColor = Color.Orange; }
            if (Variables.question10flaged == true) { textBox10.BackColor = Color.Orange; }
        }


        private void button2_Click_3(object sender, EventArgs e)
        {
            // works the same way as the flag button but sets false rather than true
            if (Question_number.Value == 1) { Variables.question1flaged = false; }
            if (Question_number.Value == 2) { Variables.question2flaged = false; }
            if (Question_number.Value == 3) { Variables.question3flaged = false; }
            if (Question_number.Value == 4) { Variables.question4flaged = false; }
            if (Question_number.Value == 5) { Variables.question5flaged = false; }
            if (Question_number.Value == 6) { Variables.question6flaged = false; }
            if (Question_number.Value == 7) { Variables.question7flaged = false; }
            if (Question_number.Value == 8) { Variables.question8flaged = false; }
            if (Question_number.Value == 9) { Variables.question9flaged = false; }
            if (Question_number.Value == 10) { Variables.question10flaged = false; }
            //calls txtbox color rather than flaged box since it achieves the correct colours 
            txtboxcolor();
        }
       

        private void button1_Click_5(object sender, EventArgs e)
        {
            //clears the List so it can Be populated properly
            Flaged_qs.Items.Clear();
            //checks if each question is flagged and if it is adds it to the list
            if (Variables.question1flaged == true) { Flaged_qs.Items.Add("Question1");}
            if (Variables.question2flaged == true) { Flaged_qs.Items.Add("Question2");}
            if (Variables.question3flaged == true) { Flaged_qs.Items.Add("Question3");}
            if (Variables.question4flaged == true) { Flaged_qs.Items.Add("Question4");}
            if (Variables.question5flaged == true) { Flaged_qs.Items.Add("Question5");}
            if (Variables.question6flaged == true) { Flaged_qs.Items.Add("Question6");}
            if (Variables.question7flaged == true) { Flaged_qs.Items.Add("Question7");}
            if (Variables.question8flaged == true) { Flaged_qs.Items.Add("Question8");}
            if (Variables.question9flaged == true) { Flaged_qs.Items.Add("Question9");}
            if (Variables.question10flaged == true){ Flaged_qs.Items.Add("Question10");}
            //displays the list
            Flaged_questions.Visible = true;
        }

        private void Close_flaglist_Click(object sender, EventArgs e)
        {
            Flaged_questions.Visible = false;
        }

        private void Next_flaged_Click(object sender, EventArgs e)
        { 

            // this button goes to the next unflaged question, displayes it, deflags it then returns to avoid always ending on the last
            if (Variables.question1flaged == true) { Question_number.Value = 1; Variables.question1flaged = false; return; }
            if (Variables.question2flaged == true) { Question_number.Value = 2; Variables.question2flaged = false; return; }
            if (Variables.question3flaged == true) { Question_number.Value = 3; Variables.question3flaged = false; return; }
            if (Variables.question4flaged == true) { Question_number.Value = 4; Variables.question4flaged = false; return; }
            if (Variables.question5flaged == true) { Question_number.Value = 5; Variables.question5flaged = false; return; }
            if (Variables.question6flaged == true) { Question_number.Value = 6; Variables.question6flaged = false; return; }
            if (Variables.question7flaged == true) { Question_number.Value = 7; Variables.question7flaged = false; return; }
            if (Variables.question8flaged == true) { Question_number.Value = 8; Variables.question8flaged = false; return; }
            if (Variables.question9flaged == true) { Question_number.Value = 9; Variables.question9flaged = false; return; }
            if (Variables.question10flaged == true) { Question_number.Value = 10;Variables.question10flaged = false; return; }

            txtboxcolor();


        }


    }
    }

