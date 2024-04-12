# DAY 1

## Overview

Today we learnt about GIT commands and worked with creating and working with repositories.
We also worked on some Logical Problems

## Repository Links

The repository for this can be found [here](https://github.com/ash0306/Genspark-demo).

## Leetcode Links

* [Two Sum](https://leetcode.com/problems/two-sum/description/)

```
class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        unordered_map<int, int> numMap;
        int n = nums.size();

        for (int i = 0; i < n; i++) {
            numMap[nums[i]] = i;
        }
        
        for (int i = 0; i < n; i++) {
            int complement = target - nums[i];
            if (numMap.count(complement) && numMap[complement] != i) {
                return {i, numMap[complement]};
            }
        }

        return {};
    }
};
```

* [Palindrome Number](https://leetcode.com/problems/palindrome-number/)
```
class Solution {
public:
    bool isPalindrome(int x) {
        if (x < 0) {
            return false;
        }

        long long reversed = 0;
        long long temp = x;

        while (temp != 0) {
            int digit = temp % 10;
            reversed = reversed * 10 + digit;
            temp /= 10;
        }

        return (reversed == x);
    }
};
```
