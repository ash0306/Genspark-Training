# String manipulations

# capitalize(): Converts the first character to upper case
def example_capitalize():
    text = "strings in python"
    print(text.capitalize())

# casefold(): Converts string into lower case
def example_casefold():
    text = "Strings In Python"
    print(text.casefold())

# center(): Returns a centered string
def example_center():
    text = "hello"
    print(text.center(20))

# count(): Returns the number of times a specified value occurs in a string
def example_count():
    text = "Strings In Python"
    print(text.count("o"))

# encode(): Returns an encoded version of the string
def example_encode():
    text = "strings in python"
    print(text.encode())

# endswith(): Returns true if the string ends with the specified value
def example_endswith():
    text = "strings in python"
    print(text.endswith("python"))

# expandtabs(): Sets the tab size of the string
def example_expandtabs():
    text = "python\tstrings"
    print(text.expandtabs(8))

# find(): Searches the string for a specified value and returns the position of where it was found
def example_find():
    text = "strings in python"
    print(text.find("in"))

# format(): Formats specified values in a string
def example_format():
    text = "Hello, {}!"
    print(text.format("world"))

# format_map(): Formats specified values in a string
def example_format_map():
    text = "Hello, {name}!"
    print(text.format_map({"name": "world"}))

# index(): Searches the string for a specified value and returns the position of where it was found
def example_index():
    text = "strings in python"
    print(text.index("in"))

# isalnum(): Returns True if all characters in the string are alphanumeric
def example_isalnum():
    text = "hello123"
    print(text.isalnum())

# isalpha(): Returns True if all characters in the string are in the alphabet
def example_isalpha():
    text = "hello"
    print(text.isalpha())

# isascii(): Returns True if all characters in the string are ascii characters
def example_isascii():
    text = "strings in python"
    print(text.isascii())

# isdecimal(): Returns True if all characters in the string are decimals
def example_isdecimal():
    text = "123"
    print(text.isdecimal())

# isdigit(): Returns True if all characters in the string are digits
def example_isdigit():
    text = "123"
    print(text.isdigit())

# isidentifier(): Returns True if the string is an identifier
def example_isidentifier():
    text = "variable1"
    print(text.isidentifier())

# islower(): Returns True if all characters in the string are lower case
def example_islower():
    text = "hello"
    print(text.islower())

# isnumeric(): Returns True if all characters in the string are numeric
def example_isnumeric():
    text = "123"
    print(text.isnumeric())

# isprintable(): Returns True if all characters in the string are printable
def example_isprintable():
    text = "strings in python"
    print(text.isprintable())

# isspace(): Returns True if all characters in the string are whitespaces
def example_isspace():
    text = "   "
    print(text.isspace())

# istitle(): Returns True if the string follows the rules of a title
def example_istitle():
    text = "strings in python"
    print(text.istitle())

# isupper(): Returns True if all characters in the string are upper case
def example_isupper():
    text = "HELLO"
    print(text.isupper())

# join(): Converts the elements of an iterable into a string
def example_join():
    text = ["hello", "world"]
    print(" ".join(text))

# ljust(): Returns a left justified version of the string
def example_ljust():
    text = "hello"
    print(text.ljust(10))

# lower(): Converts a string into lower case
def example_lower():
    text = "HELLO"
    print(text.lower())

# lstrip(): Returns a left trim version of the string
def example_lstrip():
    text = "   hello"
    print(text.lstrip())

# maketrans() and translate(): Returns a translation table to be used in translations
def example_maketrans_translate():
    intab = "aeiou"
    outtab = "12345"
    trantab = str.maketrans(intab, outtab)
    text = "strings in python"
    print(text.translate(trantab))

# partition(): Returns a tuple where the string is parted into three parts
def example_partition():
    text = "strings in python"
    print(text.partition(" "))

# replace(): Returns a string where a specified value is replaced with a specified value
def example_replace():
    text = "strings in python"
    print(text.replace("world", "Python"))

# rfind(): Searches the string for a specified value and returns the last position of where it was found
def example_rfind():
    text = "strings in python world"
    print(text.rfind("world"))

# rindex(): Searches the string for a specified value and returns the last position of where it was found
def example_rindex():
    text = "strings in python world"
    print(text.rindex("world"))

# rjust(): Returns a right justified version of the string
def example_rjust():
    text = "hello"
    print(text.rjust(10))

# rpartition(): Returns a tuple where the string is parted into three parts
def example_rpartition():
    text = "strings in python"
    print(text.rpartition(" "))

# rsplit(): Splits the string at the specified separator, and returns a list
def example_rsplit():
    text = "strings in python"
    print(text.rsplit(" "))

# rstrip(): Returns a right trim version of the string
def example_rstrip():
    text = "hello   "
    print(text.rstrip())

# split(): Splits the string at the specified separator, and returns a list
def example_split():
    text = "strings in python"
    print(text.split(" "))

# splitlines(): Splits the string at line breaks and returns a list
def example_splitlines():
    text = "hello\nworld"
    print(text.splitlines())

# startswith(): Returns true if the string starts with the specified value
def example_startswith():
    text = "strings in python"
    print(text.startswith("hello"))

# strip(): Returns a trimmed version of the string
def example_strip():
    text = "   hello   "
    print(text.strip())

# swapcase(): Swaps cases, lower case becomes upper case and vice versa
def example_swapcase():
    text = "strings in python"
    print(text.swapcase())

# title(): Converts the first character of each word to upper case
def example_title():
    text = "strings in python"
    print(text.title())

# translate(): Returns a translated string
def example_translate():
    intab = "aeiou"
    outtab = "12345"
    trantab = str.maketrans(intab, outtab)
    text = "strings in python"
    print(text.translate(trantab))

# upper(): Converts a string into upper case
def example_upper():
    text = "hello"
    print(text.upper())

# zfill(): Fills the string with a specified number of 0 values at the beginning
def example_zfill():
    text = "42"
    print(text.zfill(5))





# Calling each function to demonstrate the examples
example_capitalize()
example_casefold()
example_center()
example_count()
example_encode()
example_endswith()
example_expandtabs()
example_find()
example_format()
example_format_map()
example_index()
example_isalnum()
example_isalpha()
example_isascii()
example_isdecimal()
example_isdigit()
example_isidentifier()
example_islower()
example_isnumeric()
example_isprintable()
example_isspace()
example_istitle()
example_isupper()
example_join()
example_ljust()
example_lower()
example_lstrip()
example_maketrans_translate()
example_partition()
example_replace()
example_rfind()
example_rindex()
example_rjust()
example_rpartition()
example_rsplit()
example_rstrip()
example_split()
example_splitlines()
example_startswith()
example_strip()
example_swapcase()
example_title()
example_translate()
example_upper()
example_zfill()