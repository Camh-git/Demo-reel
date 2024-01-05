import os
from pathlib import Path
import re

#A tool to help convert filenames into the plex format, used alongside power rename
#Loops through the CWD and adds 0s to the first 10 episodes to match the plex format
#eg: S1E1 becomes S1E01 while S1E10 remains unaffected
directory = os.getcwd()

def Format_pass():
    loop = False
    for file in os.listdir(directory):
        name = os.path.splitext(os.path.basename(file))[0]
        print(name)
        nums = re.findall(r'\d+', name)
        try:
            #A bit of optional format policing
            if os.path.splitext(file)[1] != ".mp4":
                raise ValueError('Not a video')
            
            if name[0].upper() != "S":
               raise ValueError('Bad title')            
            elif name[:6].upper()== "SEASON":
                os.rename(file,'S{0}.mp4'.format(name.upper().split("SEASON")[1]))
                print("Replaced season with S")
                loop = True

            elif name[:5] == "SERIES":
                os.rename(file,'S{0}.mp4'.format(name.upper().split("SERIES")[1]))
                print("Replaced series with S")
                loop = True

            #Adding the 0s if needed(the only required part of this try)            
            if int(nums[1]) < 10:
                name = 'S{0}e0{1}'.format(nums[0],nums[1])
                os.rename(file,'{0}.mp4'.format(name))
                print("Renamed to: {0}".format(name))
            
        except Exception as e:
            print(e)
            print('The file: {0} is not a properly formatted video'.format(name))
    if loop:
        Format_pass()

Format_pass()
