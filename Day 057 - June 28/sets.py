# Set manipulations in Python

# What is a Set?
# A set is an unordered collection of unique items in Python.
# Sets are written with curly brackets {}, and elements are separated by commas.
# Sets do not allow duplicate elements.

# Creating a set
my_set = {1, 2, 3}
print("Creating a set:", my_set)

# len(): Returns the number of items in a set
def example_len():
    my_set = {1, 2, 3}
    print("Length of set:", len(my_set))

# add(): Adds an element to the set
def example_add():
    my_set = {1, 2, 3}
    my_set.add(4)
    print("Set after add:", my_set)

# remove(): Removes the specified element from the set
def example_remove():
    my_set = {1, 2, 3}
    my_set.remove(2)
    print("Set after remove:", my_set)

# discard(): Removes the specified element from the set if it is present
def example_discard():
    my_set = {1, 2, 3}
    my_set.discard(2)
    print("Set after discard:", my_set)
    my_set.discard(4)  # No error even if the element is not present
    print("Set after discarding non-existent element:", my_set)

# pop(): Removes and returns an arbitrary element from the set
def example_pop():
    my_set = {1, 2, 3}
    element = my_set.pop()
    print("Removed element:", element)
    print("Set after pop:", my_set)

# clear(): Removes all elements from the set
def example_clear():
    my_set = {1, 2, 3}
    my_set.clear()
    print("Set after clear:", my_set)

# copy(): Returns a shallow copy of the set
def example_copy():
    my_set = {1, 2, 3}
    new_set = my_set.copy()
    print("Original set:", my_set)
    print("Copied set:", new_set)

# union(): Returns a set containing the union of sets
def example_union():
    set1 = {1, 2, 3}
    set2 = {3, 4, 5}
    print("Union of sets:", set1.union(set2))

# intersection(): Returns a set containing the intersection of sets
def example_intersection():
    set1 = {1, 2, 3}
    set2 = {2, 3, 4}
    print("Intersection of sets:", set1.intersection(set2))

# difference(): Returns a set containing the difference of sets
def example_difference():
    set1 = {1, 2, 3}
    set2 = {2, 3, 4}
    print("Difference of sets:", set1.difference(set2))

# symmetric_difference(): Returns a set containing the symmetric difference of sets
def example_symmetric_difference():
    set1 = {1, 2, 3}
    set2 = {2, 3, 4}
    print("Symmetric difference of sets:", set1.symmetric_difference(set2))

# issubset(): Returns whether another set contains this set
def example_issubset():
    set1 = {1, 2}
    set2 = {1, 2, 3}
    print("Is set1 a subset of set2?", set1.issubset(set2))

# issuperset(): Returns whether this set contains another set
def example_issuperset():
    set1 = {1, 2, 3}
    set2 = {1, 2}
    print("Is set1 a superset of set2?", set1.issuperset(set2))

# isdisjoint(): Returns whether two sets have a null intersection
def example_isdisjoint():
    set1 = {1, 2, 3}
    set2 = {4, 5, 6}
    print("Are set1 and set2 disjoint?", set1.isdisjoint(set2))

example_len()
example_add()
example_remove()
example_discard()
example_pop()
example_clear()
example_copy()
example_union()
example_intersection()
example_difference()
example_symmetric_difference()
example_issubset()
example_issuperset()
example_isdisjoint()
