# Dictionary manipulations in Python

# What is a Dictionary?
# A dictionary in Python is an unordered collection of items. Each item is a key-value pair.
# Dictionaries are written with curly brackets {}, with key-value pairs separated by commas and a colon between keys and values.

# Creating a dictionary
my_dict = {"name": "Alice", "age": 25, "city": "New York"}
print("Creating a dictionary:", my_dict)

# len(): Returns the number of items in a dictionary
def example_len():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    print("Length of dictionary:", len(my_dict))

# keys(): Returns a view object of all keys in the dictionary
def example_keys():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    print("Keys of dictionary:", my_dict.keys())

# values(): Returns a view object of all values in the dictionary
def example_values():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    print("Values of dictionary:", my_dict.values())

# items(): Returns a view object of all key-value pairs in the dictionary
def example_items():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    print("Items of dictionary:", my_dict.items())

# get(): Returns the value of a specified key
def example_get():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    print("Value for key 'name':", my_dict.get("name"))
    print("Value for key 'country' (default None):", my_dict.get("country"))
    print("Value for key 'country' (default 'USA'):", my_dict.get("country", "USA"))

# update(): Updates the dictionary with the specified key-value pairs
def example_update():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    my_dict.update({"age": 26, "country": "USA"})
    print("Updated dictionary:", my_dict)

# pop(): Removes the element with the specified key and returns its value
def example_pop():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    age = my_dict.pop("age")
    print("Removed age:", age)
    print("Dictionary after pop:", my_dict)

# popitem(): Removes the last inserted key-value pair and returns it
def example_popitem():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    item = my_dict.popitem()
    print("Removed item:", item)
    print("Dictionary after popitem:", my_dict)

# setdefault(): Returns the value of a key if it is in the dictionary, else inserts the key with a specified value
def example_setdefault():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    name = my_dict.setdefault("name", "Unknown")
    country = my_dict.setdefault("country", "USA")
    print("Value for key 'name':", name)
    print("Value for key 'country':", country)
    print("Dictionary after setdefault:", my_dict)

# clear(): Removes all elements from the dictionary
def example_clear():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    my_dict.clear()
    print("Dictionary after clear:", my_dict)

# fromkeys(): Creates a new dictionary with keys from a sequence and values set to a specified value
def example_fromkeys():
    keys = ("name", "age", "city")
    value = "unknown"
    new_dict = dict.fromkeys(keys, value)
    print("New dictionary from keys:", new_dict)

# Copy: Creates a shallow copy of the dictionary
def example_copy():
    my_dict = {"name": "Alice", "age": 25, "city": "New York"}
    new_dict = my_dict.copy()
    print("Original dictionary:", my_dict)
    print("Copied dictionary:", new_dict)

example_len()
example_keys()
example_values()
example_items()
example_get()
example_update()
example_pop()
example_popitem()
example_setdefault()
example_clear()
example_fromkeys()
example_copy()