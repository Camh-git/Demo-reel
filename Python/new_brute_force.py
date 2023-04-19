import random
import time

goal =  str(input("please enter a goal: "))
if goal == "":
    goal = 'placeholder'
#Letters ordered based on frequency
letters = ' eariotnslcudpmhgbfywkvxzjq,..AIO+=-@÷×`EA!\"\'?RTNSLCUDPMHGBFYWKVXZJQ£$%’^:;&*()#~\/\\[]{}…ð™â™ªÏ‰Â©â„¢®?ý•8ÆØÅ°??ô«•²øæ|€¥Œ§½¼¹²³³'#ordered based on frequency
guess = ''
start_time = time.time()
i=0 #index in letters
x=0 #index in goal

while guess != goal:
    if letters[i] != goal[x]:
        i+=1
        #print(guess + letters[i])
    else:
        guess +=letters[i]
        i=0
        x+=1
        print(guess)

print("Brute forced in: " + str((time.time()-start_time)) + " seconds")


#Changes
#added input option
#added punctuation
#formated input as string to deal with unintended injection
#added capital letter support
#Added some less common characters that people might commonly try to trick the system with
