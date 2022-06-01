package us_quiz;
import java.util.Scanner;
import java.util.ArrayList;

public class States_quiz {

	public static String Format_for_answer(String Input) {
		//Check if the input is one or two words, capitalise as needed
		String Output = "";		
		
		switch (Input.toUpperCase()) {
		case "NEW HAMPSHIRE":
		case "NEW_HAMPSHIRE":
			Output = "New Hampshire";
			break;
		case "NEW JERSEY":
		case "NEW_JERSEY":
			Output = "New Jersey";
			break;
		case "NEW MEXICO":
		case "NEW_MEXICO":
			Output = "New Mexico";
			break;
		case "NEW YORK":
		case "NEW_YORK":
			Output = "New York";
			break;
		case "NORTH CAROLINA":
		case "NORTH_CAROLINA":
			Output = "North Carolina";
			break;
		case "NORTH DAKOTA":
		case "NORTH_DAKOTA":
			Output = "North Dakota";
			break;
		case "RHODE ISLAND":
		case "RHODE_ISLAND":
			Output = "Rhode Island";
			break;
		case "SOUTH CAROLINA":
		case "SOUTH_CAROLINA":
			Output = "South Carolina";
			break;
		case "SOUTH DAKOTA":
		case "SOUTH_DAKOTA":
			Output = "South Dakota";
			break;
		default:
			Output = Input.substring(0,1).toUpperCase() + Input.substring(1);
		}
		return Output;
	}	
	public static void main(String[] args) {
		Scanner Scan = new Scanner(System.in);
		String Input = "";
		int Score = 0;
		String[] States = {"Alabama","Alaska","Arizona","Arkansas","California","Colorado",
			    "Connecticut","Delaware","Florida","Georgia","Hawaii","Idaho","Illinois",
			    "Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine","Maryland",
			    "Massachusetts","Michigan","Minnesota","Mississippi","Missouri","Montana",
			    "Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York",
			    "North Carolina","North Dakota","Ohio","Oklahoma","Oregon","Pennsylvania",
			    "Rhode Island","South Carolina","South Dakota","Tennesse","Texas","Utah",
			    "Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"};
		ArrayList<String> Answers = new ArrayList<>();
		System.out.println("Hello and welcome To the US states quiz, here you can test your knowledge and try to guess all 50 states");
		System.out.println();
		while (Score < 50)
		{			
			System.out.println("Please enter your input, the options are: 'list' to see the states you have already got right,'exit' to leave");
			System.out.println("or enter a state name to make a guess: ");
			Input = Scan.nextLine();			
			//Input = Input.replaceAll(" ","_");
			//System.out.println("input = " + Input);
			if (Input.toUpperCase().equals("LIST"))
			{
				System.out.println("The list of states you have already guessed is:");
				for(String State : Answers) 
				{
					System.out.println(State);
				}
				System.out.println(String.format("You have correctly guessed %1s out of %2s States",Answers.size(),States.length ));
				continue;				
			}
			else if (Input.toUpperCase().equals("EXIT") || Input.toUpperCase().equals("END"))
			{
				System.out.println("Exiting quiz, your final score was: " + Score);
				System.exit(0);
			}
			else if (Input.toUpperCase().equals("WIN")) //TODO: disable this on live
			{
				System.out.println("DEBUG: win button entered");
				Score = 50;
			}
			else //if not using a pre-set command check for states
			{
				boolean Correct = false;
				for(String State : States)
				{					
					if(Input.toUpperCase().equals(State.toUpperCase()))
					{
						//If input is a state check for duplicates
						boolean Dupe = false;
						for(String Answer : Answers)
						{
							if (Input.toUpperCase().equals(Answer.toUpperCase()))
							{
								Dupe = true;
								break;
							}
						}
						//award point and add to list if good, notify if not
						if (Dupe == false)
						{
							Score = Score + 1;
							System.out.println("Good job, that was a state, you have been awarded a point, your score is: " + Score);
							Answers.add(Format_for_answer(State));
							Correct = true;
							break;
							
						}
						else
						{
							Correct = true;
							System.out.println("That guess was a state, but unfortunatly you have already guessed it");
							break;
						}
					}	
				}
				if (Correct == false)
				{
					System.out.println("unfortunately that guess is not a state, please try again");
					Input = "";
				}
			}
		}
		System.out.println("CONGRATULATIONS you correctly guessed all 50 states");
		Scan.close();

	}

}
