using System;

namespace Text_to_morse_or_binary_converter
{
    class Conversion_lists
    {
        public static string[] Binary_convert(char[] Letters)
        {
            //This code takes each letter in the array and converts it to it's binary equivalent, based on it's ASCII value, does not include ' and \ as including them causes syntax errors.
            string[] Results = new string[Letters.Length];
            int i = 1;
            while (i <= Results.Length)
            {
                switch (Letters[i - 1])
                {
                    //Start by converting lower case letters, since most loops will involve a lower case letter
                    case 'a':
                        Results[i - 1] = "1100001"; break;
                    case 'b':
                        Results[i - 1] = "1100010"; break;
                    case 'c':
                        Results[i - 1] = "1100011"; break;
                    case 'd':
                        Results[i - 1] = "1100100"; break;
                    case 'e':
                        Results[i - 1] = "1100101"; break;
                    case 'f':
                        Results[i - 1] = "1100110"; break;
                    case 'g':
                        Results[i - 1] = "1100111"; break;
                    case 'h':
                        Results[i - 1] = "1101000"; break;
                    case 'i':
                        Results[i - 1] = "1101001"; break;
                    case 'j':
                        Results[i - 1] = "1101010"; break;
                    case 'k':
                        Results[i - 1] = "1101011"; break;
                    case 'l':
                        Results[i - 1] = "1101100"; break;
                    case 'm':
                        Results[i - 1] = "1101101"; break;
                    case 'n':
                        Results[i - 1] = "1101110"; break;
                    case 'o':
                        Results[i - 1] = "1101111"; break;
                    case 'p':
                        Results[i - 1] = "1110000"; break;
                    case 'q':
                        Results[i - 1] = "1110001"; break;
                    case 'r':
                        Results[i - 1] = "1110010"; break;
                    case 's':
                        Results[i - 1] = "1110011"; break;
                    case 't':
                        Results[i - 1] = "1110100"; break;
                    case 'u':
                        Results[i - 1] = "1110101"; break;
                    case 'v':
                        Results[i - 1] = "1110110"; break;
                    case 'w':
                        Results[i - 1] = "1110111"; break;
                    case 'x':
                        Results[i - 1] = "1111000"; break;
                    case 'y':
                        Results[i - 1] = "1111001"; break;
                    case 'z':
                        Results[i - 1] = "1111010"; break;

                    //After lower case comes Upper case
                    case 'A':
                        Results[i - 1] = "1000001"; break;
                    case 'B':
                        Results[i - 1] = "1000010"; break;
                    case 'C':
                        Results[i - 1] = "1000011"; break;
                    case 'D':
                        Results[i - 1] = "1000100"; break;
                    case 'E':
                        Results[i - 1] = "1000101"; break;
                    case 'F':
                        Results[i - 1] = "1000110"; break;
                    case 'G':
                        Results[i - 1] = "1000111"; break;
                    case 'H':
                        Results[i - 1] = "1001000"; break;
                    case 'I':
                        Results[i - 1] = "1001001"; break;
                    case 'J':
                        Results[i - 1] = "1001010"; break;
                    case 'K':
                        Results[i - 1] = "1001011"; break;
                    case 'L':
                        Results[i - 1] = "1001100"; break;
                    case 'M':
                        Results[i - 1] = "1001101"; break;
                    case 'N':
                        Results[i - 1] = "1001110"; break;
                    case 'O':
                        Results[i - 1] = "1001111"; break;
                    case 'P':
                        Results[i - 1] = "1010000"; break;
                    case 'Q':
                        Results[i - 1] = "1010001"; break;
                    case 'R':
                        Results[i - 1] = "1010010"; break;
                    case 'S':
                        Results[i - 1] = "1010011"; break;
                    case 'T':
                        Results[i - 1] = "1010100"; break;
                    case 'U':
                        Results[i - 1] = "1010101"; break;
                    case 'V':
                        Results[i - 1] = "1010110"; break;
                    case 'W':
                        Results[i - 1] = "1010111"; break;
                    case 'X':
                        Results[i - 1] = "1011000"; break;
                    case 'Y':
                        Results[i - 1] = "1011001"; break;
                    case 'Z':
                        Results[i - 1] = "1011010"; break;

                    //Numbers come next
                    case '0':
                        Results[i - 1] = "0110000"; break;
                    case '1':
                        Results[i - 1] = "0110001"; break;
                    case '2':
                        Results[i - 1] = "0110010"; break;
                    case '3':
                        Results[i - 1] = "0110011"; break;
                    case '4':
                        Results[i - 1] = "0110100"; break;
                    case '5':
                        Results[i - 1] = "0110101"; break;
                    case '6':
                        Results[i - 1] = "0110110"; break;
                    case '7':
                        Results[i - 1] = "0110111"; break;
                    case '8':
                        Results[i - 1] = "0111000"; break;
                    case '9':
                        Results[i - 1] = "0111001"; break;

                    //Finally, punctuation
                    case ' ':
                        Results[i - 1] = "0100000"; break;
                    case '!':
                        Results[i - 1] = "0100001"; break;
                    case '"':
                        Results[i - 1] = "0100010"; break;
                    case '#':
                        Results[i - 1] = "0100011"; break;
                    case '$':
                    case '£':
                        Results[i - 1] = "0100100"; break;
                    case '%':
                        Results[i - 1] = "0100101"; break;
                    case '&':
                        Results[i - 1] = "0100110"; break;
                    //The character ' was ommited at this point due to incompatability
                    case '(':
                        Results[i - 1] = "0101000"; break;
                    case ')':
                        Results[i - 1] = "0101001"; break;
                    case '*':
                        Results[i - 1] = "0101010"; break;
                    case '+':
                        Results[i - 1] = "0101011"; break;
                    case ',':
                        Results[i - 1] = "0101100"; break;
                    case '-':
                        Results[i - 1] = "0101101"; break;
                    case '.':
                        Results[i - 1] = "0101110"; break;
                    case '/':
                        Results[i - 1] = "0101111"; break;
                    case ':':
                        Results[i - 1] = "0111010"; break;
                    case ';':
                        Results[i - 1] = "0111011"; break;
                    case '<':
                        Results[i - 1] = "0111100"; break;
                    case '=':
                        Results[i - 1] = "0111101"; break;
                    case '>':
                        Results[i - 1] = "0111110"; break;
                    case '?':
                        Results[i - 1] = "0111111"; break;
                    case '@':
                        Results[i - 1] = "1000000"; break;
                    case '[':
                        Results[i - 1] = "1011011"; break;
                    //The character \ was ommited at this point due to incompatability
                    case ']':
                        Results[i - 1] = "1011101"; break;
                    case '^':
                        Results[i - 1] = "1011110"; break;
                    case '_':
                        Results[i - 1] = "1011111"; break;
                    case '`':
                        Results[i - 1] = "1100000"; break;
                    case '{':
                        Results[i - 1] = "1111011"; break;
                    case '|':
                        Results[i - 1] = "1111100"; break;
                    case '}':
                        Results[i - 1] = "1111101"; break;
                    case '~':
                        Results[i - 1] = "1111110"; break;

                    default:
                        System.Windows.Forms.MessageBox.Show("Error converting at character number: " + i + ".", "Conversion error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
                i = i + 1;
            }
            Console.WriteLine("Conversion complete");
            return (Results);
        }
        public static string[] Morse_convert(char[] Letters)
        {
            //This code takes each letter in the array and converts it to it's morse equivalent, based on ITU Internation morse code, does not include ' as including it causes syntax errors.
            //The conversion ignores capitalisation and uses the following timing (in units (u)):
            //Dot = 1u, Dash = 3u, silence between signals in same letter = 1u, silence between letters = 3u, space between words = 7u.
            string[] Results = new string[Letters.Length];
            int i = 1;
            while (i <= Results.Length)
            {
                switch (Letters[i - 1])
                {
                    //searching through the letters
                    case 'a':
                    case 'A':
                        Results[i - 1] = ".-"; break;
                    case 'b':
                    case 'B':
                        Results[i - 1] = "-..."; break;
                    case 'c':
                    case 'C':
                        Results[i - 1] = "-.-."; break;
                    case 'd':
                    case 'D':
                        Results[i - 1] = "-.."; break;
                    case 'e':
                    case 'E':
                        Results[i - 1] = "."; break;
                    case 'f':
                    case 'F':
                        Results[i - 1] = "..-."; break;
                    case 'g':
                    case 'G':
                        Results[i - 1] = "--."; break;
                    case 'h':
                    case 'H':
                        Results[i - 1] = "...."; break;
                    case 'i':
                    case 'I':
                        Results[i - 1] = ".."; break;
                    case 'j':
                    case 'J':
                        Results[i - 1] = ".---"; break;
                    case 'k':
                    case 'K':
                        Results[i - 1] = "-.-"; break;
                    case 'l':
                    case 'L':
                        Results[i - 1] = ".-.."; break;
                    case 'm':
                    case 'M':
                        Results[i - 1] = "--"; break;
                    case 'n':
                    case 'N':
                        Results[i - 1] = "-."; break;
                    case 'o':
                    case 'O':
                        Results[i - 1] = "---"; break;
                    case 'p':
                    case 'P':
                        Results[i - 1] = ".--."; break;
                    case 'q':
                    case 'Q':
                        Results[i - 1] = "--.-"; break;
                    case 'r':
                    case 'R':
                        Results[i - 1] = ".-."; break;
                    case 's':
                    case 'S':
                        Results[i - 1] = "..."; break;
                    case 't':
                    case 'T':
                        Results[i - 1] = "-"; break;
                    case 'u':
                    case 'U':
                        Results[i - 1] = "..-"; break;
                    case 'v':
                    case 'V':
                        Results[i - 1] = "...-"; break;
                    case 'w':
                    case 'W':
                        Results[i - 1] = ".--"; break;
                    case 'x':
                    case 'X':
                        Results[i - 1] = "-..-"; break;
                    case 'y':
                    case 'Y':
                        Results[i - 1] = "-.--"; break;
                    case 'z':
                    case 'Z':
                        Results[i - 1] = "--.."; break;

                    //Searching through numbers
                    case '0':
                        Results[i - 1] = "-----"; break;
                    case '1':
                        Results[i - 1] = ".----"; break;
                    case '2':
                        Results[i - 1] = "..---"; break;
                    case '3':
                        Results[i - 1] = "...--"; break;
                    case '4':
                        Results[i - 1] = "....-"; break;
                    case '5':
                        Results[i - 1] = "....."; break;
                    case '6':
                        Results[i - 1] = "-...."; break;
                    case '7':
                        Results[i - 1] = "--..."; break;
                    case '8':
                        Results[i - 1] = "---.."; break;
                    case '9':
                        Results[i - 1] = "----."; break;

                    //Searching through punctuation
                    case ' ':
                        Results[i - 1] = " "; break;
                    case '.':
                        Results[i - 1] = ".-.-.-"; break;
                    case '&':
                        Results[i - 1] = ".-..."; break;
                    //The character ' was ommited at this point due to incompatability
                    case '@':
                        Results[i - 1] = ".--.-."; break;
                    case ')':
                        Results[i - 1] = "-.--.-"; break;
                    case '(':
                        Results[i - 1] = "-.--."; break;
                    case ':':
                        Results[i - 1] = "---..."; break;
                    case ',':
                        Results[i - 1] = "--..--"; break;
                    case '=':
                        Results[i - 1] = "-...-"; break;
                    case '!':
                        Results[i - 1] = "-.-.--"; break;
                    case '-':
                        Results[i - 1] = "-....-"; break;
                    case '+':
                        Results[i - 1] = ".-.-."; break;
                    case '"':
                        Results[i - 1] = ".-..-."; break;
                    case '?':
                        Results[i - 1] = "..--.."; break;
                    case '/':
                        Results[i - 1] = "-..-."; break;

                    default:
                        System.Windows.Forms.MessageBox.Show("Error converting at character number: " + i + ".", "Conversion error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
                i = i + 1;
            }
            Console.WriteLine("Conversion complete");
            return (Results);
        }
        public static string[] Morse_Timing_convert(char[] Letters)
        {
            //This code takes each letter in the array and converts it to it's morse equivalent, based on ITU Internation morse code, does not include ' as including it causes syntax errors.
            //The conversion ignores capitalisation and uses the following timing (in units (u)):
            //Dot = 1u, Dash = 3u, silence between signals in same letter = 1u, silence between letters = 3u, space between words = 7u.
            string[] Results = new string[Letters.Length];
            int i = 1;
            while (i <= Results.Length)
            {
                switch (Letters[i - 1])
                {
                    //searching through the letters
                    case 'a':
                    case 'A':
                        Results[i - 1] = "10111"; break;
                    case 'b':
                    case 'B':
                        Results[i - 1] = "111010101"; break;
                    case 'c':
                    case 'C':
                        Results[i - 1] = "1110101110"; break;
                    case 'd':
                    case 'D':
                        Results[i - 1] = "1110101"; break;
                    case 'e':
                    case 'E':
                        Results[i - 1] = "1"; break;
                    case 'f':
                    case 'F':
                        Results[i - 1] = "101011101"; break;
                    case 'g':
                    case 'G':
                        Results[i - 1] = "111011101"; break;
                    case 'h':
                    case 'H':
                        Results[i - 1] = "1010101"; break;
                    case 'i':
                    case 'I':
                        Results[i - 1] = "101"; break;
                    case 'j':
                    case 'J':
                        Results[i - 1] = "1011101110111"; break;
                    case 'k':
                    case 'K':
                        Results[i - 1] = "111010111"; break;
                    case 'l':
                    case 'L':
                        Results[i - 1] = "101110101"; break;
                    case 'm':
                    case 'M':
                        Results[i - 1] = "1110111"; break;
                    case 'n':
                    case 'N':
                        Results[i - 1] = "11101"; break;
                    case 'o':
                    case 'O':
                        Results[i - 1] = "11101110111"; break;
                    case 'p':
                    case 'P':
                        Results[i - 1] = "10111011101"; break;
                    case 'q':
                    case 'Q':
                        Results[i - 1] = "1110111010111"; break;
                    case 'r':
                    case 'R':
                        Results[i - 1] = "1011101"; break;
                    case 's':
                    case 'S':
                        Results[i - 1] = "10101"; break;
                    case 't':
                    case 'T':
                        Results[i - 1] = "111"; break;
                    case 'u':
                    case 'U':
                        Results[i - 1] = "1010111"; break;
                    case 'v':
                    case 'V':
                        Results[i - 1] = "101010111"; break;
                    case 'w':
                    case 'W':
                        Results[i - 1] = "101110111"; break;
                    case 'x':
                    case 'X':
                        Results[i - 1] = "11101010111"; break;
                    case 'y':
                    case 'Y':
                        Results[i - 1] = "1110101110111"; break;
                    case 'z':
                    case 'Z':
                        Results[i - 1] = "11101110101"; break;

                    //Searching through numbers
                    case '0':
                        Results[i - 1] = "1110111011101110111"; break;
                    case '1':
                        Results[i - 1] = "10111011101110111"; break;
                    case '2':
                        Results[i - 1] = "101011101110111"; break;
                    case '3':
                        Results[i - 1] = "1010101110111"; break;
                    case '4':
                        Results[i - 1] = "10101010111"; break;
                    case '5':
                        Results[i - 1] = "101010101"; break;
                    case '6':
                        Results[i - 1] = "11101010101"; break;
                    case '7':
                        Results[i - 1] = "1110111010101"; break;
                    case '8':
                        Results[i - 1] = "111011101110101"; break;
                    case '9':
                        Results[i - 1] = "11101110111011101"; break;

                    //Searching through punctuation
                    case ' ':
                        Results[i - 1] = "0000000"; break;
                    case '.':
                        Results[i - 1] = "10111010111010111"; break;
                    case '&':
                        Results[i - 1] = "10111010101"; break;
                    //The character ' was ommited at this point due to incompatability
                    case '@':
                        Results[i - 1] = "10111011101011101"; break;
                    case ')':
                        Results[i - 1] = "1110101110111010111"; break;
                    case '(':
                        Results[i - 1] = "111010111011101"; break;
                    case ':':
                        Results[i - 1] = "11101110111010101"; break;
                    case ',':
                        Results[i - 1] = "1110111010101110111"; break;
                    case '=':
                        Results[i - 1] = "1110101010111"; break;
                    case '!':
                        Results[i - 1] = "1110101110101110111"; break;
                    case '-':
                        Results[i - 1] = "111010101010111"; break;
                    case '+':
                        Results[i - 1] = "1011101011101"; break;
                    case '"':
                        Results[i - 1] = "101110101011101"; break;
                    case '?':
                        Results[i - 1] = "101011101110101"; break;
                    case '/':
                        Results[i - 1] = "1110101011101"; break;

                    default:
                        System.Windows.Forms.MessageBox.Show("Error converting at character number: " + i + ".", "Conversion error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
                i = i + 1;
            }
            Console.WriteLine("Conversion complete");
            return (Results);
        }
    }
}
