#import os if you want to remove files, os.remove("filename.filetype")
#r to read, a to append, w to write (overwrites), x to create
import random
import os
X = random.randint(1,100)
#getting a random number to insert

def create():
    File = open("hello.txt", "x")

def read():
 File = open("Log.txt","r")
 print (File.read())

def write():
 File = open("Log.txt","w")
 File.write("this overwrites everything else, why would you do this?")

def delete():
    os.remove("file.txt")

def append():
 File = open ("Log.txt","a")
 #File.write("apple") #to add text
 File.write("\n") #adds a new line
 File.write(str(X)) #note this writes the number as a string

def extract_ints():
 print ("hi")    
 with open("Log.txt") as File:
  content = File.read() #fill the content variable with the file contents
  array = content.split()
  numbers = map(int, array)
  print (array)
 


append()
read()
#extract_ints()

#note this could be changed to use an array for the proccess and
#to use the file to make it persistant
