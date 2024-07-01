# Exception Handling
def invalid_input():
    while True:
        try:
            a = int(input("Enter a number:"))
            break
        except ValueError:
            print("Invalid input. Please enter a valid integer.")

def division_error():
    while True:
        try:
            a = int(input("Enter a number:"))
            b = int(input("Enter a divisor (non-zero):"))
            if b == 0:
                raise ZeroDivisionError
            result = a / b
            print("Result:", result)
            break
        except ValueError:
            print("Invalid input. Please enter a valid integer.")
        except ZeroDivisionError:
            print("Error: Division by zero is not allowed.")


invalid_input()

division_error()