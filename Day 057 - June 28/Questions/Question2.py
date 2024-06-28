# 2) Print the list of prime numbers up to a given number

def is_prime(num):
    if num <= 1:
        return False
    if num == 2:
        return True
    if num % 2 == 0:
        return False
    for i in range(3, int(num**0.5) + 1, 2):
        if num % i == 0:
            return False
    return True

def list_prime_numbers_up_to(limit):
    prime_numbers = []
    for num in range(2, limit + 1):
        if is_prime(num):
            prime_numbers.append(num)
    return prime_numbers


limit = 50
print("Prime numbers up to", limit, "are:", list_prime_numbers_up_to(limit))
