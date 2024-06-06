# Day 26

## Topics Covered

- ASP .Net Web API application

- JWT Web Token


## Work

### Question 1

**A Very Big Sum**

This is a hackerrank problem. The problem statement for the same can be found [here](https://www.hackerrank.com/challenges/a-very-big-sum/problem?isFullScreen=true)

```csharp
public static long aVeryBigSum(List<long> ar)
{
	long sum = 0;
	foreach(long a in ar){
		sum+=a;
	}
	return sum;
}
```

### Question 2

**Pizza Shop API**

- We continued working on the Pizza Shop API from Day 25.

- Add the token based authentication in you app for listing the pizzas

The repository for the assignment work can be found [here](https://github.com/ash0306/Genspark-Training/tree/master/Day%2025/PizzaShopApplicationSolution)


**Output**

![PizzaShopAPIOutput](./PizzaShopJWTOutput.gif)