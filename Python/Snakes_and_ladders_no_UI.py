import random

class Jump():
  def __init__(self,entry,ext):
      self.Entrance = entry
      self.Exit = ext

def Roll():
  return(random.randrange(1,7))


def Setup_game():
  Snakes = [Jump(43,12),Jump(72,52),Jump(13,8),Jump(52,25),Jump(90,61),Jump(98,20)]
  Ladders = [Jump(8,20),Jump(21,35),Jump(40,52),Jump(58,73),Jump(62,78),Jump(74,82)]
  max_pos = 100
  return(Snakes,Ladders,max_pos)


def Auto_play(pos = 0, max_pos = 100):
  while pos < max_pos:
    Score = Roll()
    if (pos + Score <= max_pos):
      pos += Score
      print("Postion: " + str(pos))
    else:
      print("You rolled:" + str(Score) + ", unfortunatly this takes you over the end so you can't move.")
      print("Postion: " + str(pos))
    for x in Snakes:
      if pos == x.Entrance:     
        pos = x.Exit
        print("Oh no, you hit a snake at " + str(x.Entrance) +", you are now at " + str(pos))
    for x in Ladders:
      if pos == x.Entrance:      
        pos = x.Exit
        print("Yay, you found a ladder!, you have jumped from " + str(x.Entrance) + " to " + str(pos))

  print("Congratualtions, you won!")

#Changes:
#THIS VERSION HAS BEEN MODIFIED FOR TESTING, IT DOES NOT RUN AUTOMATICALY, USE Snakes and ladders_no_UI FOR THAT PURPOSE
