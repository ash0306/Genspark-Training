# 6) Find if the given number is prime

def is_prime(number):
    if number <= 1:
        return False
    for i in range(2, int(number/2) + 1):
        if number % i == 0:
            return False
    return True


number = int(input("Enter a number: "))
if is_prime(number):
    print(f"{number} is a prime number.")
else:
    print(f"{number} is not a prime number.")
