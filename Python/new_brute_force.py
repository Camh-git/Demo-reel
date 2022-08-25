import random
import time


goal = 'hello world'
letters = ' eariotnslcudpmhgbfywkvxzjq'#ordered based on frequency
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

