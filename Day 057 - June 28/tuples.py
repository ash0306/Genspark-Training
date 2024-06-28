# Tuple 
# A tuple is an immutable sequence type that can hold a collection of items.
# Tuples are similar to lists, but unlike lists, tuples cannot be changed after they are created.

# Creating a tuple
tup = (1, 2, 3)
print("Creating a tuple:", tup)

# len(): Returns the number of items in a tuple
def example_len():
    tup = (1, 2, 3)
    print("Length of tuple:", len(tup))

# index(): Returns the first index of a specified value
def example_index():
    tup = (1, 2, 3, 2)
    print("Index of first occurrence of 2:", tup.index(2))

# count(): Returns the number of times a specified value appears in the tuple
def example_count():
    tup = (1, 2, 3, 2, 2)
    print("Count of 2 in tuple:", tup.count(2))

# Accessing elements: Accessing elements in a tuple using indexing
def example_access():
    tup = (1, 2, 3)
    print("First element:", tup[0])  # First element
    print("Last element:", tup[-1])  # Last element

# Slicing: Accessing a range of elements in a tuple
def example_slice():
    tup = (1, 2, 3, 4, 5)
    print("Elements from index 1 to 3:", tup[1:4])  # Elements from index 1 to 3

# Concatenation: Combining two or more tuples
def example_concatenate():
    tup1 = (1, 2, 3)
    tup2 = (4, 5, 6)
    print("Concatenated tuple:", tup1 + tup2)

# Repetition: Repeating a tuple multiple times
def example_repetition():
    tup = (1, 2, 3)
    print("Repeated tuple:", tup * 3)

# Checking membership: Checking if an item exists in a tuple
def example_membership():
    tup = (1, 2, 3)
    print("Is 2 in tuple?", 2 in tup)
    print("Is 4 in tuple?", 4 in tup)



# Calling each function
example_len()
example_index()
example_count()
example_access()
example_slice()
example_concatenate()
example_repetition()
example_membership()
