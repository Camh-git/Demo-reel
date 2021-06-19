import sys
states = ["Alabama","Alaska","Arizona","Arkansas","California","Colorado",
    "Connecticut","Delaware","Florida","Georgia","Hawaii","Idaho","Illinois",
    "Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine","Maryland",
    "Massachusetts","Michigan","Minnesota","Mississippi","Missouri","Montana",
    "Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York",
    "North Carolina","North Dakota","Ohio","Oklahoma","Oregon","Pennsylvania",
    "Rhode Island","South Carolina","South Dakota","Tennesse","Texas","Utah",
    "Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"]
correct_guesses = []

Score = int(0)
print("Welcome to this U.S states quiz, see if you can guess the names"
      ,"of all", len(states) ,"U.S states, you can quit at any time by typing quit.");

while Score < len(states):
    guess = str(input("Please enter your guess: ").strip())
    #checks states for the value, then checks correct guesses for repeats
    good_guess = "false"
    for val in states:
        if guess.upper() == val.upper():#good value,checking for repeat
            repeat = "No"
            good_guess = "True"
            for val in correct_guesses:
                if guess.upper() == val.upper():
                    repeat = "Yes"                    
            if repeat == "No":                
                correct_guesses.append(guess)
                Score = Score +1
                print("Well done,", guess, "is a state, you have",Score, "/", len(states))               
            else:
                print("It appears you have already entered", guess)
        elif guess.upper() == "QUIT":
            print("Exiting")
            sys.exit()
    if good_guess == "false":
        print(guess, "is not a state, please try again")

print("Congratulations, you have managed to guess all", len(states),"states");

