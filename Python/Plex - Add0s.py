import os
from pathlib import Path

#A tool to help convert filenames into the plex format, used alongside power rename
#Loops through the CWD and adds 0s to the first 10 episodes to match the plex format
#eg: S1E1 becomes S1E01 while S1E10 remains unaffected
directory = os.getcwd()
    
for file in os.listdir(directory):
    name = os.path.splitext(os.path.basename(file))[0]
    print(name)
    if len(name) < 5:
        name ="".join([name[:3],"0",name[3:]])
        os.rename(file,'{0}.mp4'.format(name))
        
