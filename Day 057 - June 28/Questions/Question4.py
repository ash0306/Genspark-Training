# 4) Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times

import random

def generate_secret_number():
    return str(random.randint(1000, 9999))

def get_cows_and_bulls(guess, secret):
    cows = 0
    bulls = 0
    for i in range(len(guess)):
        if guess[i] == secret[i]:
            bulls += 1
        elif guess[i] in secret:
            cows += 1
    return cows, bulls

def cow_and_bull_game():
    secret_number = generate_secret_number()
    attempts = 0
    max_attempts = 10
    
    print("Welcome to the Cow and Bull game!")
    print("You have to guess a 4 digit number in 10 attempts.")
    print("For each guess, you will get the number of Cows and Bulls.")
    print("Cows: Correct digit in the wrong position.")
    print("Bulls: Correct digit in the right position.")
    
    while attempts < max_attempts:
        guess = input(f"Attempt {attempts + 1}: Enter your 4-digit guess: ")
        
        if len(guess) != 4 or not guess.isdigit():
            print("Please enter a valid 4-digit number.")
            continue
        
        attempts += 1
        cows, bulls = get_cows_and_bulls(guess, secret_number)
        
        print(f"Cows: {cows}, Bulls: {bulls}")
        
        if bulls == 4:
            print(f"Congratulations! You guessed the secret number '{secret_number}' in {attempts} attempts.")
            break
    else:
        print(f"Sorry, you've used all your attempts. The secret number was '{secret_number}'.")

# Start the game
cow_and_bull_game()
