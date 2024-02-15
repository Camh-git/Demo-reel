using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_rover_kata
{
    internal class Rover
    {
        public int Collumn { get; set; }
        public int Row { get; set; }        
        public char Orientation { get; set; }
        public Rover() {
            this.Collumn = 1;
            this.Row = 1;            
            this.Orientation = 'S';
        }
        public bool Move(int Distance)
        {
            //Validate that the move is within bounds, move if so.
            if ( Check_bounds(Distance) ) {
                switch (this.Orientation)
                {
                    case 'N':
                        this.Row -= Distance;
                        break;
                    case 'E':
                        this.Collumn += Distance;
                        break;
                    case 'S':
                        this.Row += Distance;
                        break;
                    case 'W':
                        this.Collumn -= Distance;
                        break;
                    default: return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Check_bounds(int Distance)
        {
            bool Valid_move = false;
            switch (this.Orientation)
            {
                case 'N':
                    //Note: Only need to check one boundry since the direction is determined by the current orientation.
                    if (this.Row - Distance >= 1)
                    {
                        Valid_move = true;
                    }
                    break;
                case 'E':
                    if (this.Collumn + Distance <= 100)
                    {
                        Valid_move = true;
                    }
                    break;
                case 'S':
                    if (this.Row + Distance <= 100)
                    {
                        Valid_move = true;
                    }
                    break;
                case 'W':
                    if (this.Collumn - Distance >= 1)
                    {
                        Valid_move = true;
                    }
                    break;
            }
            return Valid_move;
        }
        public char Turn(string Direction)
        {
            Direction = Direction.ToUpper();

            //Check that the direction is valid
            if (Direction != "LEFT" && Direction != "RIGHT")
            {
                return ('I');
            }

            //Rotate the rover based on direction
            switch (this.Orientation)
            {
                case 'N':
                    if (Direction == "LEFT")
                    {
                        this.Orientation = 'W';
                    }
                    else
                    {
                        this.Orientation = 'E';
                    }
                    break;
                case 'E':
                    if (Direction == "LEFT")
                    {
                        this.Orientation = 'N';
                    }
                    else
                    {
                        this.Orientation = 'S';
                    }
                    break;
                case 'S':
                    if (Direction == "LEFT")
                    {
                        this.Orientation = 'E';
                    }
                    else
                    {
                        this.Orientation = 'W';
                    }
                    break;
                case 'W':
                    if (Direction == "LEFT")
                    {
                        this.Orientation = 'S';
                    }
                    else
                    {
                        this.Orientation = 'N';
                    }
                    break;
                default: return ('O');
            }
            return (this.Orientation);

        }
    }

}
