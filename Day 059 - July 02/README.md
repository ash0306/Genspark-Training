# Day 59

## PART A

#### Python (Basic) Certificate

Completed the Python (Basic) skills certification.

![certificate](./python_basic%20certificate.jpg)
 
The certificate can also be accessed using this [URL](https://www.hackerrank.com/certificates/a7d8496c6fb5)


## PART B

The solutions for the Hackerrank problems can be found below.

#### Merge The Tools
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

#### collections.Counter()
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

#### Company Logo

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

#### Python If-Else()

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

#### Arithmetic Operators

The question can be found [here](https://www.hackerrank.com/challenges/python-arithmetic-operators?isFullScreen=true)

```python
a = int(input())
b = int(input())

print("{0}\n{1}\n{2}".format((a+b),(a-b),(a*b)))
```

------------

#### Python: Division

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

#### Loops

The question can be found [here](https://www.hackerrank.com/challenges/python-loops?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i*i)
```

------------

#### Write a Function

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

#### Print function

The question can be found [here](https://www.hackerrank.com/challenges/python-print?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i+1, end="") 

```

------------

#### List Comprehensions

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

#### Find the Runner-Up Score

The question can be found [here](https://www.hackerrank.com/challenges/find-second-maximum-number-in-a-list?isFullScreen=true)

```python
if __name__ == '__main__':
    n = int(input())
    arr = list(map(int, input().split()))
    
    new_arr = list(set(arr))
    
    new_arr.sort()
    
    print(new_arr[-2])
```


## PART C

The solutions for the Leetcode problems can be found below

#### Longest Substring Without Repeating Characters

The question can be found [here](https://leetcode.com/problems/longest-substring-without-repeating-characters/description/)

```python
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        maxi = 0
        left = 0
        arr = [-1] * 128
        for right in range(len(s)):
            if arr[ord(s[right])] >= left:
                left = arr[ord(s[right])] + 1
            arr[ord(s[right])] = right
            maxi = max(maxi, right - left + 1)
        return maxi
```

------------

#### Zigzag Conversion

The question can be found [here](https://leetcode.com/problems/zigzag-conversion/description/)

```python
class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows <= 1:
            return s

        ans = ""
        j = 0
        dir = -1
        temp = [""] * numRows

        for i in range(len(s)):
            if j == numRows - 1 or j == 0:
                dir *= -1

            temp[j] += s[i]

            if dir == 1:
                j += 1
            else:
                j -= 1

        for x in temp:
            ans += x

        return ans
```

------------

#### 3Sum Closest

The question can be found [here](https://leetcode.com/problems/3sum-closest/)

```python
class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        min_difference = float('inf')
        nums.sort()
        length = len(nums)
        closest_sum = 0

        for i in range(length):
            left = i + 1
            right = length - 1

            while left < right:
                current_sum = nums[i] + nums[left] + nums[right]

                if current_sum == target:
                    return target
                else:
                    current_difference = abs(target - current_sum)

                    if current_difference < min_difference:
                        min_difference = current_difference
                        closest_sum = current_sum

                if current_sum < target:
                    left += 1
                elif current_sum > target:
                    right -= 1

        return closest_sum
```

------------

#### Generate Parentheses

The question can be found [here](https://leetcode.com/problems/generate-parentheses/description/)

```python
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        def backtrack(current_string='', left=0, right=0):
            if len(current_string) == 2 * n:
                combinations.append(current_string)
                return
            if left < n:
                backtrack(current_string + '(', left + 1, right)
            if right < left:
                backtrack(current_string + ')', left, right + 1)

        combinations = []
        backtrack()
        return combinations
```

------------

#### Multiply Strings

The question can be found [here](https://leetcode.com/problems/multiply-strings/description/)

```python
class Solution:
    def multiply(self, num1: str, num2: str) -> str:
        int_hash_table = {
            "1": 1,
            "2": 2,
            "3": 3,
            "4": 4,
            "5": 5,
            "6": 6,
            "7": 7,
            "8": 8,
            "9": 9,
            "0": 0,
        }

        def convert_to_int(string):
            integer = 0
            for i, j in enumerate(string):
                integer = integer + int_hash_table[j] * (10 ** (len(string) - (i + 1)))
            return integer

        return str(convert_to_int(num1) * convert_to_int(num2))
```

------------

#### Group Anagrams

The question can be found [here](https://leetcode.com/problems/group-anagrams/description/)

```python
from collections import defaultdict

class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagrams = defaultdict(list)
        
        for string in strs:
            sorted_string = ''.join(sorted(string))
            anagrams[sorted_string].append(string)
        
        return list(anagrams.values())

```

------------

#### Jump Game

The question can be found [here](https://leetcode.com/problems/jump-game/description/)

```python
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        n = len(nums)
        max_jump = 0

        for i in range(n):
            if i > max_jump:
                return False
            max_jump = max(max_jump, i + nums[i])

        return True
```

------------

#### Unique Paths

The question can be found [here](https://leetcode.com/problems/unique-paths/description/)

```python
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        total_steps = m + n - 2
        steps_down = m - 1
        
        result = 1
        for i in range(1, steps_down + 1):
            result = result * (total_steps - steps_down + i) / i
        
        return int(result)

```

------------

#### Text Justification

The question can be found [here](https://leetcode.com/problems/text-justification/description/)

```python
class Solution:
    def fullJustify(self, words: List[str], maxWidth: int) -> List[str]:
        result, line, width = [], [], 0
        
        for w in words:
            if width + len(w) + len(line) > maxWidth:
                for i in range(maxWidth - width):
                    line[i % (len(line) - 1 or 1)] += ' '
                result.append(''.join(line))
                line = []
                width = 0
            
            line.append(w)
            width += len(w)
        
        result.append(' '.join(line).ljust(maxWidth))
        
        return result

```