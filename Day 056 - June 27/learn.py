# 1. Understanding Execution
# Python code is executed line by line from top to bottom.

# 2. Input and Output
# Getting user input
# Input is by default a string if needed we have to explicitly cast to other data types
print("----------------------------------------------------------------")
print("Input and Output")
user_input = input("Enter something: ")
number = int(input("Enter a number: "))

# Printing output
print("You entered:", user_input)
print("Number:", number)

# 3. Datatypes
# Different datatypes in Python
print("----------------------------------------------------------------")
print("Datatypes")
integer = 10
floating_point = 10.5
string = "Hello, Python!"
boolean = True

# Printing datatype examples
print("Integer:", integer)
print("Floating Point:", floating_point)
print("String:", string)
print("Boolean:", boolean)

# 4. Operators
# Arithmetic operators
print("----------------------------------------------------------------")
print("Operators")
addition = 5 + 3
subtraction = 5 - 3
multiplication = 5 * 3
division = 5 / 3
modulus = 5 % 3

print("Addition:", addition)
print("Subtraction:", subtraction)
print("Multiplication:", multiplication)
print("Division:", division)
print("Modulus:", modulus)

# 5. Conditional statements
print("----------------------------------------------------------------")
print("Conditiona Statements")
# Using if-elif-else statements
print("If-elif-else statements")
number = 7
if number > 10:
    print("Number is greater than 10")
elif number == 10:
    print("Number is equal to 10")
else:
    print("Number is less than 10")

# Ternary operator
print("Ternary operator")
a = 10
b = 20
min = "a is minimum" if a < b else "b is minimum"
print(min)

# Match case statement
print("Match case")
def matchCase():
    num = int(input("Enter a number between 1 and 5: "))
    match num:
        case 1:
            print("Monday")
        case 2:
            print("Tuesday")
        case 3:
            print("Wednesday")
        case 4:
            print("Thursday")
        case 5:
            print("Friday")
        # default pattern
        case _:
            print("Number not between 1 and 3")

# 6. Iterations
print("----------------------------------------------------------------")
print("Iterations")
# Using for loop
for i in range(5):
    print(f"For loop iteration: {i}")

# Using while loop
count = 5
while count >= 0:
    print(f"While loop count:{count}")
    count -= 1

# 7. Methods
print("----------------------------------------------------------------")
print("Methods")
# Defining and calling methods (functions in Python)
def greet(name):
    return f"Hello, {name}!"

# Calling the method
greeting = greet("Alice")
print(greeting)

# 8. Parameters and Returns
print("----------------------------------------------------------------")
print("Functions with parameters and returns")
# Functions with parameters and return values
def add(a, b):
    return a + b

result = add(3, 4)
print(f"Addition Result:{result}")

# 9. List and Indexing
print("----------------------------------------------------------------")
print("List and Indexing")
# Creating a list
my_list = [1, 2, 3, 4, 5]

# Iterating a list
print("My List:")
for i in my_list:
    print(i)

# Accessing elements by index
print("Accessing elements by index")
first_element = my_list[0]
second_element = my_list[1]

print("First element:", first_element)
print("Second element:", second_element)

# Modifying an element
print("Modifying an element")
my_list[2] = 10
print("Modified list:", my_list)

# List methods
print("List methods")
my_list.append(6)
print("List after append:", my_list)

my_list.remove(10)
print("List after removal:", my_list)