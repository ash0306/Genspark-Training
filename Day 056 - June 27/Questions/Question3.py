# 3) Take name and gender print greet with salutation

name = input("Enter a name:")
gender = input("Enter your gender:")
gender = gender.lower()

match gender:
    case "male":
        print(f"Hello, Mr.{name}")
    case "female":
        print(f"Hello, Ms.{name}")
    case _:
        print(f"Hello, {name}")