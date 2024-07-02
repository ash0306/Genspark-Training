# Hackerrank Solutions

The solutions for the Hackerrank problems can be found below.

## Merge The Tools
The question can be found [here](https://www.hackerrank.com/challenges/merge-the-tools?isFullScreen=true)

```python
def merge_the_tools(string, k):
    uniques = []
    for i in range(0, len(string), k):
        temp_string = ""
        for char in string[i:i+k]:
            if char not in temp_string:
                temp_string = temp_string + char
        uniques.append(temp_string)
    print("\n".join(uniques))

if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)
```

------------

## collections.Counter()
The question can be found [here](https://www.hackerrank.com/challenges/collections-counter?isFullScreen=true)

```python
from collections import Counter

no_of_shoes = int(input())
shoe_sizes = Counter(list(map(int, input().split())))
no_of_cust = int(input())

money_earned = 0
for i in range(no_of_cust):
    cust_size, cust_money = map(int, input().split())
    if cust_size in shoe_sizes and shoe_sizes[cust_size] >= 1:
        money_earned += cust_money
        shoe_sizes[cust_size] -= 1
    else:
        continue

print(money_earned)
```

------------

## Company Logo

The question can be found [here](https://www.hackerrank.com/challenges/most-commons?isFullScreen=true)

```python
from collections import Counter

if __name__ == '__main__':
    s = input()
    s = Counter(sorted(s)).most_common(3)
    for a in s:
        print(f'{a[0]} {a[1]}')
```

------------

## Python If-Else()

The question can be found [here](https://www.hackerrank.com/challenges/py-if-else?isFullScreen=true)

```python
n=int(input())

if (n%2)!=0:
    print("Weird")
else :
    if n>=2 and n<=5:
        print("Not Weird")
    elif n>=6 and n<=20:
        print("Weird")
    elif n>20:
        print("Not Weird")
```

------------

## Arithmetic Operators

The question can be found [here](https://www.hackerrank.com/challenges/python-arithmetic-operators?isFullScreen=true)

```python
a = int(input())
b = int(input())

print("{0}\n{1}\n{2}".format((a+b),(a-b),(a*b)))
```

------------

## Python: Division

The question can be found [here](https://www.hackerrank.com/challenges/python-division?isFullScreen=true)

```python
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    
    i = a//b
    f = a/b
    
    print (i)
    print (f)

```

------------

## Loops

The question can be found [here](https://www.hackerrank.com/challenges/python-loops?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i*i)
```

------------

## Write a Function

The question can be found [here](https://www.hackerrank.com/challenges/write-a-function?isFullScreen=true)

```python
def is_leap(year):
    leap = False
    
    # Write your logic here
    
    return leap

year = int(input())
print(is_leap(year))
```

------------

## Print function

The question can be found [here](https://www.hackerrank.com/challenges/python-print?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i+1, end="") 

```

------------

## List Comprehensions

The question can be found [here](https://www.hackerrank.com/challenges/list-comprehensions?isFullScreen=true)

```python
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())

    ar = []
    p = 0

    for i in range ( x + 1 ) :
        for j in range( y + 1):
            for k in range( z + 1):
                if i+j+k != n:
                    ar.append([])
                    ar[p] = [ i , j, k ]
                    p+=1
	print(ar)
```

------------

## Find the Runner-Up Score

The question can be found [here](https://www.hackerrank.com/challenges/find-second-maximum-number-in-a-list?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    arr = list(map(int, input().split()))
    
    new_arr = list(set(arr))
    
    new_arr.sort()
    
    print(new_arr[-2])
```
