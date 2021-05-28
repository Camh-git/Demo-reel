from random import shuffle
import time
import random

def is_sorted(data) -> bool:
    """Determine whether the data is sorted."""
    return all(data[i] <= data[i + 1] for i in range(len(data) - 1))

def bogosort(data,runs) -> list:
    """Shuffle data until sorted."""
    while not is_sorted(data):
        shuffle(data)
        runs = runs +1
    return data, runs

def niavesort(data):
    "go through swaping numbers from high to low, repeat until done"
    while not is_sorted(data):       
        for i in range(len(data)-1):
            if (data[i] > data[i+1]):
                data[i], data[i+1] = data[i+1],data[i]
    return data
runs = 0
length = int(input("Please enter the array length: "))
data = [random.randint(1,99) for _ in range(length)]

print("Started as: ", data)
times =[0]*2
times[0] = time.time()
sorted,runs = bogosort(data,runs)
times[1] = time.time()

print("Result: ", sorted)
print("took: ", times[1] -  times[0], "seconds and: ", runs," attempts")
