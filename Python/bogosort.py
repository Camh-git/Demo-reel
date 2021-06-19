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
data2 = data

print("Started as: ", data)
print("Note: very short run times will show as 0.0 sec")
print("Lists long enough to make the niave sort show >0.0 will make the bogo sort take forever")

times =[0]*4
times[0] = time.time()
#sorted,runs = bogosort(data,runs)
times[1] = time.time()

print("Bogosort result: ", sorted)
print("took: ", times[1] -  times[0], " seconds and: ", runs," attempts.")

times[2] = time.time()
sorted2 = niavesort(data2);
times[3] = time.time()
print("Naive sort result: ", sorted2)
print("took: ", times[3] - times[2], " seconds to complete.")
