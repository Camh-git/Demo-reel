#This is a text based, self playing version of snakes and ladders
import random

class Jump():
  def __init__(self,entry,ext):
      self.Entrance = entry
      self.Exit = ext
 
def Roll():
  return(random.randrange(1,7))

#setup
Snakes = [Jump(43,12),Jump(72,52),Jump(13,8),Jump(52,25),Jump(90,61),Jump(98,20)]
Ladders = [Jump(8,20),Jump(21,35),Jump(40,52),Jump(58,73),Jump(62,78),Jump(73,82)]
max_pos = 100
pos=0

#auto playing
while pos <max_pos:
  Score = Roll()
  if (pos + Score <= max_pos):
    pos += Score
  else:
    print("You rolled:" + str(Score) +", unfortunatly this takes you over the end so you cant move.")
  print("Postion: " + str(pos))
  for x in Snakes:
    if pos == x.Entrance:     
      pos = x.Exit
      print("Oh no, you hit a snake, you are now at:" + str(pos))
  for x in Ladders:
    if pos == x.Entrance:      
      pos = x.Exit
      print("Yay, you found a ladder!, you are now at: " + str(pos))

print("Congratualtions, you won!")
#for x in range(50):
 # print(Roll())
