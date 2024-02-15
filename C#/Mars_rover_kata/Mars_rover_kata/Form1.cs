using System.Collections;
using static Mars_rover_kata.Rover;

namespace Mars_rover_kata
{
    public partial class Mars_rover_kata_UI : Form
    {
        Rover MarsRover = new Rover();

        public Mars_rover_kata_UI()
        {
            InitializeComponent();
        }

        private void Mars_rover_kata_UI_Load(object sender, EventArgs e)
        {

        }

        private void Turn_rover_left(object sender, EventArgs e)
        {
            Queue_command("Turn left");
        }

        private void Turn_rover_right(object sender, EventArgs e)
        {
            Queue_command("Turn right");
        }

        private void Move_rover(object sender, EventArgs e)
        {
            Queue_command("Move: " + Distance_input.Value);
        }

        private void Queue_command(string Command)
        {
            //Check that the queue still has space and that the command is valid (is either turn left or right, or Move: followed by a number)
            if (Queue_display.Items.Count >= 5)
            {
                MessageBox.Show("The queue is already full, please delete or execute existing commands before adding more.", "Full queue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int distance;
            if (Command == "Turn right" || Command == "Turn left")
            {
                Queue_display.Items.Add(Command);

            }
            else if (Command.StartsWith("Move: ") && int.TryParse(Command.Split(": ")[1], out distance))
            {
                //TODO: Check from last postion in list, not just current
                if (MarsRover.Check_bounds(distance))
                {
                    Queue_display.Items.Add(Command);
                }
                else
                {
                    MessageBox.Show(string.Join("Failed to add command: ",Command));
                }
            }
            else
            {
                MessageBox.Show("Only Turn right, Turn left and Move are valid commands, you entered: " + Command, "Invalid command", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Execute_queue(object sender, EventArgs e)
        {
            foreach (var command in Queue_display.Items)
            {
                if (command.ToString() == "Turn left")
                {
                    MarsRover.Turn("Left");
                    Orientation_display.Text = MarsRover.Orientation.ToString();
                }
                else if (command.ToString() == "Turn right")
                {
                    MarsRover.Turn("Right");
                    Orientation_display.Text = MarsRover.Orientation.ToString();
                }
                else if (command.ToString().StartsWith("Move: "))
                {
                    bool Move_result = MarsRover.Move(Convert.ToInt32(command.ToString().Split(" ")[1]));
                    if (Move_result)
                    {
                        MessageBox.Show(string.Join(MarsRover.Row.ToString(), ", ",  MarsRover.Collumn.ToString()));
                        Position_display.Text = string.Join(MarsRover.Row.ToString(),", ", MarsRover.Collumn.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Failed to move");
                    }
                }
                else
                {
                    MessageBox.Show("Command did not match any valid command, only Turn right, Turn left and Move are valid.", "Invalid command", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Queue_display.Items.Clear();
        }

        private void Orientation_display_TextChanged(object sender, EventArgs e)
        {
            switch(MarsRover.Orientation)
            {
                case 'N':
                    this.Text = "North";
                    break;
                case 'E':
                    this.Text = "East";
                    break;
                case 'S':
                    this.Text = "South";
                    break;
                case 'W':
                    this.Text = "West";
                    break;
                default: this.Text = "Unknown"; break;
            }
        }
    }
}
