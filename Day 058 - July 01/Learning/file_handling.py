with open('Day 058 - July 01/Learning/sample.txt','w') as file:
    file.write("hello world")
    file.write("\nPython")

with open('Day 058 - July 01/Learning/ash.txt','r') as file:
    data = file.read()

print(data)