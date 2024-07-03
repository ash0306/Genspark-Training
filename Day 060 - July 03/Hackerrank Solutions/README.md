# Hackerrank Solutions

The solutions for the Hackerrank problems can be found below.

## Nested Lists
The question can be found [here](https://www.hackerrank.com/challenges/nested-list/problem?isFullScreen=true)

```python
if __name__ == '__main__':
    list_of_names = []
    list_of_scores = []

    for _ in range(int(input())):
        name = input()
        score = float(input())

        list_of_names.append(name)
        list_of_scores.append(score)

    n = len(list_of_names)
    students = [[list_of_names[i], list_of_scores[i]] for i in range(n)]

    unique_score_list = list(set(list_of_scores))
    unique_score_list.sort()
    second_lowest_score = unique_score_list[1]

    name_result = [student[0] for student in students if student[1] == second_lowest_score]

    name_result.sort()

    for name in name_result:
        print(name)

```

------------

## Find the percentage
The question can be found [here](https://www.hackerrank.com/challenges/finding-the-percentage/problem?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    student_marks = {}
    for _ in range(n):
        name, *line = input().split()
        scores = list(map(float, line))
        student_marks[name] = scores
    query_name = input()
    
    print(f"{sum(student_marks[query_name]) / len(student_marks[query_name]):.2f}")

```

------------

## Lists

The question can be found [here](https://www.hackerrank.com/challenges/python-lists/problem?isFullScreen=true)

```python
if __name__ == '__main__':
    N = int(input())
    list = []

    for _ in range(N):
        query = input().split()
        if query[0] == "print":
            print(list)
        elif query[0] == "insert":
            list.insert(int(query[1]), int(query[2]))
        elif query[0] == "remove":
            list.remove(int(query[1]))
        elif query[0] == "append":
            list.append(int(query[1]))
        elif query[0] == "sort":
            list = sorted(list)
        elif query[0] == "pop":
            list.pop()
        elif query[0] == "reverse":
            list.reverse()
```

------------

## Tuples

The question can be found [here](https://www.hackerrank.com/challenges/python-tuples/problem?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    integer_list = map(int, input().split())
    t = tuple(integer_list)
    print(hash(t))

```

------------

## sWAP cASE

The question can be found [here](https://www.hackerrank.com/challenges/swap-case/problem?isFullScreen=true)

```python
def swap_case(s):
    return s.swapcase()

if __name__ == '__main__':
    s = input()
    result = swap_case(s)
    print(result)

```

------------

## String Split and Join

The question can be found [here](https://www.hackerrank.com/challenges/python-string-split-and-join/problem?isFullScreen=true)

```python
def split_and_join(line):
    return "-".join(line.split(" "))

if __name__ == '__main__':
    line = input()
    result = split_and_join(line)
    print(result)
```

------------

## What's Your Name?

The question can be found [here](https://www.hackerrank.com/challenges/whats-your-name/problem?isFullScreen=true)

```python
def print_full_name(first, last):
    print(f"Hello {first} {last}! You just delved into python.")

if __name__ == '__main__':
    first_name = input()
    last_name = input()
    print_full_name(first_name, last_name)

```

------------

## Mutations

The question can be found [here](https://www.hackerrank.com/challenges/python-mutations/problem?isFullScreen=true)

```python
def mutate_string(string, position, character):
    string = string[:position] + character + string[position+1:]
    return string

if __name__ == '__main__':
    s = input()
    i, c = input().split()
    s_new = mutate_string(s, int(i), c)
    print(s_new)
```

------------

## Find a string

The question can be found [here](https://www.hackerrank.com/challenges/find-a-string/problem?isFullScreen=true)

```python
def count_substring(string, sub_string):
    sum = 0
    sub_len = len(sub_string)
    for i in range(len(string)-sub_len+1):
        if string[i:i + sub_len] == sub_string:
            sum += 1
    return sum

if __name__ == '__main__':
    string = input().strip()
    sub_string = input().strip()
    
    count = count_substring(string, sub_string)
    print(count)

```

------------

## String Validators

The question can be found [here]()https://www.hackerrank.com/challenges/string-validators/problem?isFullScreen=true

```python
if __name__ == '__main__':
    s = input()

    alnum, alpha, digits, lower, upper = False, False, False, False, False

    for char in s:
        if char.isalnum():
            alnum = True
        if char.isalpha():
            alpha = True
        if char.isdigit():
            digits = True
        if char.islower():
            lower = True
        if char.isupper():
            upper = True

    print(alnum)
    print(alpha)
    print(digits)
    print(lower)
    print(upper)
```

------------

