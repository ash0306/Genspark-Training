# 9) Find All Permutations of a given string

# from itertools import permutations

# input_string = input("Enter a string: ")

# perms = permutations(input_string)

# print("All permutations:")
# for perm in perms:
#     print(''.join(perm))


def permute(s, step=0):
    if step == len(s):
        print("".join(s))
    for i in range(step, len(s)):
        # Copy the string (since strings are immutable)
        s_copy = [c for c in s]
        s_copy[step], s_copy[i] = s_copy[i], s_copy[step]
        permute(s_copy, step + 1)

input_string = input("Enter a string: ")
permute(list(input_string))
