# DAY 5

## Topics Covered

* Selection Statements

* Control Statements

* Employee Tracker CRUD

* Logical Problems


## Logical Problems


[Bulls and Cows](https://leetcode.com/problems/bulls-and-cows/description/)

```
class Solution {
public:
    string getHint(string secret, string guess) {
        int countBull=0;
        unordered_map<char,int>guessMap;
        int n=secret.length();
        for (int i=0;i<n;i++) {
            if(secret[i]==guess[i]) {
                countBull++;
            }
            else{
                guessMap[guess[i]]++;
            }
        }
        
        int countCow=0;
        for (int i=0;i<n;i++) {
            if (secret[i] != guess[i] && guessMap[secret[i]]>0){
                countCow++;
                guessMap[secret[i]]--;
            }
        }
        string ans=to_string(countBull)+"A" +to_string(countCow)+"B";
        return ans;
    }
};
```