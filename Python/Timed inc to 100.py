import time

i=0
start = time.time()
while i < 100:
    i=i+1
    print(i)


end = time.time()
print("Time taken:" , end - start,"seconds")
