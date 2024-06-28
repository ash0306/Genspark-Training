# 1) Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.

def longest_substring_without_repeating(s):
    n = len(s)
    longest = ""
    start = 0
    char_map = {}

    for end in range(n):
        if s[end] in char_map and char_map[s[end]] >= start:
            start = char_map[s[end]] + 1

        char_map[s[end]] = end

        if end - start + 1 > len(longest):
            longest = s[start:end + 1]

    return longest

input_str = "abcabcbb"
print("Longest substring without repeating characters:", longest_substring_without_repeating(input_str))
