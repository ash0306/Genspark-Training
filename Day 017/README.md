# DAY 17

## Topics Covered

- Sub Queries
- Joins
- Types of joins


## Work

### SQL Queries 

Worked with SQL Queries using the questions provided. This work can be found [here](./PubsSQLQueries_Day17.sql)


**Print the storeid and number of orders for the store**
```
SELECT sales.stor_id, COUNT(*) AS num_orders
FROM sales
JOIN stores ON sales.stor_id = stores.stor_id
GROUP BY sales.stor_id;
```

**Print the numebr of orders for every title**
```
SELECT t.title, COUNT(s.title_id) AS num_orders
FROM titles t
JOIN sales s ON t.title_id = s.title_id
GROUP BY t.title;
```

**Print the publisher name and book name**
```
SELECT p.pub_name, t.title
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id;
```

**Print the author full name for al the authors**
```
SELECT CONCAT(au_fname,' ', au_lname) 'Author Full Name'
FROM authors
```

**Print the price or every book with tax (price+price*12.36/100)**
```
SELECT title, price, price + (price * 12.36 / 100) 'Price (+ Tax)'
FROM titles;
```

**Print the author name, title name**
```
SELECT CONCAT(a.au_fname,' ', a.au_lname) 'Author Full Name'
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
```

**Print the author name, title name and the publisher name**
```
SELECT CONCAT(a.au_fname,' ', a.au_lname) 'Author Full Name'
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
```

**Print the average price of books pulished by every publisher**
```
SELECT t.pub_id, p.pub_name, AVG(t.price) 'Average price'
FROM titles t
JOIN publishers p ON t.pub_id = p.pub_id
GROUP BY t.pub_id, p.pub_name
```

**Print the books published by 'Marjorie'**
```
SELECT t.title
FROM titles t
JOIN titleauthor ta ON ta.title_id = t.title_id
JOIN authors a ON a.au_id = ta.au_id
WHERE a.au_fname = 'Marjorie' OR a.au_lname = 'Marjorie'
```

**Print the order numbers of books published by 'New Moon Books'**
```
SELECT s.ord_num
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON p.pub_id = t.pub_id
WHERE p.pub_name = 'New Moon Books'
```

**Print the number of orders for every publisher**
```
SELECT p.pub_name, COUNT(s.ord_num) 'Number of Orders'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
JOIN publishers p ON p.pub_id = t.pub_id
GROUP BY p.pub_name
```

**Print the order number , book name, quantity, price and the total price for all orders**
```
SELECT s.ord_num, t.title, s.qty, t.price, (t.price*s.qty) 'Total Price' 
FROM sales s
JOIN titles t ON t.title_id = s.title_id
```

**Print the total order quantity for every book**
```
SELECT t.title, SUM(s.qty) 'Total Order Quantity'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title
```

**Print the total ordervalue for every book**
```
SELECT t.title, SUM((s.qty*t.price)) 'Total Order Value'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title
```

**Print the orders that are for the books published by the publisher for which 'Paolo' works for**
```
SELECT s.ord_num
FROM sales s
JOIN titles t ON t.title_id = s.title_id
JOIN employee e ON e.pub_id = t.pub_id
WHERE e.fname = 'Paolo'
```