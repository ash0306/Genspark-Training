# 5) Add validation the entered  name, age, date of birth and phone print details in proper format

import re

def get_and_validate_details():
    while True:
        name = input("Enter your name: ")
        if not name.isalpha():
            print("Invalid name. Name should only contain alphabets.")
        else:
            break
        
    while True:
        age = int(input("Enter your age: "))
        if age <= 0:
            print("Age must be a positive integer.")
        else:
            break        
        
    while True:
        dob = input("Enter your date of birth (DD-MM-YYYY): ")
        if not re.match(r'\d{2}-\d{2}-\d{4}$',dob):
            print("Invalid date of birth. Please enter in DD-MM-YYYY format.")
        else:
            break
        
    while True:
        phone = input("Enter your phone number: ")
        if not re.match(r"^\d{10}$", phone):
            print("Invalid phone number. Please enter in XXX-XXX-XXXX format.")
        else:
            break
    
    return name, age, dob, phone

def print_details(name, age, dob, phone):
    print(f"Name: {name}")
    print(f"Age: {age}")
    print(f"Date of Birth: {dob}")
    print(f"Phone Number: {phone}")


name, age, dob, phone = get_and_validate_details()
print_details(name, age, dob, phone)
