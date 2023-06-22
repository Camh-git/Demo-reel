word = str(input("Please enter the word you want to check: "))

inverse = ""
i = len(word)

while i:
    i-=1
    inverse += word[i]

print("The inverse of ",word," is ",inverse)
if(word == inverse):
    print(word," is a palindrome")
else:
    print(word," is not a palindrome")

input = input()
