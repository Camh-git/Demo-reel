#Variable/input decleration
import time
day = int(1)
dead = int(0)

try:
    r_rate = float(input("Please enter the R-rate: "))
except:
    r_rate = float(1.5)
    print("R-rate input was skipped, will default to 1.5")
try:
    target_days = int(input("Enter the number of days to run: "))
except:
    target_days = int(1)
    print("Run length input was skipped, will default to 1")

try:
    infected = int(input("set starting infected(optional, defualt 1): "))
except:
    infected = int(1)
try:
    lethality = int(input("set lethality %(optional, defualt 1%, set as int):"))
except:
    lethality = int(1)    

#Running through the infection calculation for X days untill the user quits

close = bool(0)
Loop_start_day = int(0)
while close == 0:
    while day <= Loop_start_day + target_days:
        if r_rate !=0:
         infected = infected * r_rate
        if lethality !=0:
         dead = (infected/100) * lethality
        print("After day",day,"there are",f'{infected:,.0f}',"infections,",f'{dead:,.0f}',"deaths")
        day +=1   
    #Run complete, see if user wants to proceed
    run_again = str(input("Would you like to continue? Y/N"))
    if run_again.upper() == "Y":
        params = str(input("Would you like to change paramaters? Y/N"))
        #changing paramaters if the user wants to
        if params.upper() == "Y":
            try:
                r_rate = float(input("Please enter the R-rate: "))
            except:                
                print("R-rate input was skipped, continuing with previous value")
            
            try:
                target_days = int(input("Enter the number of days to run: "))
                Loop_start_day = day
                #target_days = (day + new_days)-1
            except:
                target_days = target_days + day
                print("Run length input was skipped, will default to previous target")
            try:
                infected = int(input("set starting infected(optional, defualt current value): "))
            except:
                print("Infected input skipped, continuing with previous count")
            try:
                lethality = int(input("set lethality %(optional, defualt 1%, set as int:"))
            except:                
                print("Lethality input skipped, continuing with previous value")
        else:
            Loop_start_day = day
            print("running again with no paramater changes")      
    #exit
    else:
        print("You have decided to not continue, final results:",f'{infected:,.0f}',"infections,",f'{dead:,.0f}',"deaths")
        close = 1 
    
print("closed")
