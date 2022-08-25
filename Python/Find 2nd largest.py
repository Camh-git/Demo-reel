import random

random_numbers=[]
Length = random.randint(5,10)
print("number of entries set to: " + str(Length))
x = 0

while (x<Length):
    random_numbers.append(random.randint(0,100))
    x+=1

largest = 0
second_largest = 0
third_largest = 0

for i in random_numbers:
    if i > largest:
        third_largest = second_largest
        second_largest = largest
        largest = i
    elif i > second_largest and i < largest:
        third_largest = second_largest
        second_largest = i
    elif i > third_largest and i < second_largest:
        third_largest = i
    #print("debug:"+str(largest)+","+str(second_largest)+","+str(third_largest))

print("The range is:")
for i in random_numbers:
    print(str(i))
    
print("The largest number is: " + str(largest))
print("The 2nd largest number is: " + str(second_largest))
print("The 3rd largest number is: " + str(third_largest))
