start = int(input("Please input the number you want to find the factorial of: "))
result = 1
position = 1

while position <= start:
    result = result*position
    position +=1

print("The factorial of " + str(start) + " is: " + str("{:,}".format(result)))
