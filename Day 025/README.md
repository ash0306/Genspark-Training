# Day 25

## Topics Covered

- ASP .Net Web API application

- DTO

- Password Hashing

- Attributes and other good coding principles

## Work

### Question 1

**Weather Observation Station 5**

This is a hackerrank problem. The problem statement for the same can be found [here](https://www.hackerrank.com/challenges/weather-observation-station-5/problem?isFullScreen=true)

```sql
SELECT TOP 1 city, LEN(city)
FROM station 
ORDER BY LEN(city), city;
SELECT TOP 1 city, LEN(city)
FROM station 
ORDER BY LEN(city) DESC, city;
```

### Question 2

**Ollivander's Inventory**

This is a hackerrank problem. The problem statement for the same can be found [here](https://www.hackerrank.com/challenges/harry-potter-and-wands/problem?isFullScreen=true)

```sql
WITH CTE_COINS 
AS 
(
    SELECT wp.age, w.power, MIN(w.coins_needed) AS 'min_coins_needed'
    FROM Wands w
    JOIN Wands_Property wp ON w.code = wp.code
    WHERE wp.is_evil = 0
    GROUP BY wp.age, w.power
)

SELECT w.id, wp.age, w.coins_needed, w.power
FROM Wands w
JOIN Wands_Property wp ON w.code = wp.code
JOIN CTE_COINS c ON w.power = c.power AND wp.age = c.age AND w.coins_needed = c.min_coins_needed
WHERE wp.is_evil = 0
ORDER BY w.power DESC, wp.age DESC;
```

### Question 3

**Pizza Shop API**

- Create an API that will allow user to login in a application that the user can order pizzas.(Sample Dominos/PizzaHut)

- Add an end-point that will list the pizza. List only those pizza's that are in stock.

- Device the model and DTOs as well.

The repository for the assignment work can be found [here](./PizzaShopApplicationSolution)


**Output**

![PizzaShopAPIOutput](./PizzaShopOutput.gif)
