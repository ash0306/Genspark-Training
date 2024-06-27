# 10) Print a pyramid of starts for the number of rows specified
#    *
#   ***
#  ******

rows = int(input("Enter the number of rows for the star pyramid: "))
for i in range(rows):
        print(' ' * (rows - i - 1) + '*' * (2 * i + 1))