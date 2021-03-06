import time
day = int(1)


try:
    growth_rate = float(input("Please enter the growth rate: "))
except:
    growth_rate = float(1.5)
    print("growth rate input was skipped, will default to 1.5")
try:
    target_days = int(input("Enter the number of days to run: "))
    target_days +=1
     #1st run is offset so that it runs from days 1 to target instead of 0
     #to target-1, this offset is undone on any 2nd run 
     #UX thing, this way it doesn't look like an off by 1 error
except:
    target_days = int(2)
    print("Run length input was skipped, will default to 1")

try:
    Count = int(input("set starting Count(optional, defualt 1): "))
except:
    Count = int(1)  

#Running through the count calculation for X days untill the user quits

close = bool(0)
Loop_start_day = int(0)
while close == 0:
    while day < Loop_start_day + target_days:
        if growth_rate !=0:
         Count = Count * growth_rate      
        print("After day",day,"there are",f'{Count:,.0f}',"counts")
        day +=1
        
    #Run complete, see if user wants to proceed
    run_again = str(input("Would you like to continue? Y/N"))
    if run_again.upper() == "Y":
        params = str(input("Would you like to change paramaters? Y/N"))
        
        #changing paramaters if the user wants to
        if params.upper() == "Y":
            try:
                growth_rate = float(input("Please enter the growth-rate: "))
            except:                
                print("growth-rate input was skipped, continuing with previous value")
            
            try:
                target_days = int(input("Enter the number of days to run: "))
                Loop_start_day = day               
            except:
                if day <= target_days: #remove 1st run offset
                    target_days -=1                  
                Loop_start_day = day    
                print("Run length input was skipped, will default to previous target")
            try:
                Count = int(input("set starting Count(optional, defualt current value):"))
            except:
                print("Count input skipped, continuing with previous count")            
        else:
            if day <= target_days: #remove 1st run offset
                    target_days -=1  
            Loop_start_day = day
            print("running again with no paramater changes")      
    #exit
    else:
        print("You have decided to not continue, final result is:",f'{Count:,.0f}',"Counts,")
        close = 1 
    
print("closed")
