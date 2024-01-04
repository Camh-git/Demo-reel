from os import remove
from sys import argv
import os
i = 1
target = int(input("Please enter the number of folders: "))

while i <= target:
    newpath = ""
    if i < 10:
        newpath = 'Season 0{0}'.format(i)
    else:
        newpath = 'Season {0}'.format(i)
    if not os.path.exists(newpath):
        os.makedirs(newpath)
    i+=1

delete = str(input("Delete this script?(y/n): "))
if delete.upper() == "Y" or delete.upper() == "YES":
    remove(argv[0])
