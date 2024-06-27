# 7) Take 10 numbers and find the average of all the prime numbers in the collection

def is_prime(number):
    if number <= 1:
        return False
    for i in range(2, int(number/2) + 1):
        if number % i == 0:
            return False
    return True

def average_of_primes(numbers):
    primes = [num for num in numbers if is_prime(num)]
    if primes:
        return sum(primes) / len(primes)
    else:
        return 0


numbers = []
for i in range(10):
    numbers.append(int(input(f"Enter number {i+1}: ")))
average = average_of_primes(numbers)
print(f"The average of prime numbers is: {average}")