# 5) Credit card validation - Luhn check algorithm

def luhn_check(card_number):
    digits = [int(d) for d in str(card_number)]
    
    digits.reverse()
    
    for i in range(1, len(digits), 2):
        digits[i] *= 2
        if digits[i] > 9:
            digits[i] -= 9
    
    total_sum = sum(digits)
    
    return total_sum % 10 == 0

card_number = input("Enter your credit card number: ")

if luhn_check(card_number):
    print("The credit card number is valid.")
else:
    print("The credit card number is invalid.")

