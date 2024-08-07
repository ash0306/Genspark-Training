USE pubs

SELECT * FROM sales
SELECT * FROM stores
SELECT * FROM titles
SELECT * FROM publishers
SELECT * FROM authors

--1) Print the storeid and number of orders for the store
SELECT sales.stor_id, COUNT(*) AS num_orders
FROM sales
JOIN stores ON sales.stor_id = stores.stor_id
GROUP BY sales.stor_id;


--2) Print the number of orders for every title
SELECT t.title, COUNT(s.title_id) AS num_orders
FROM titles t
JOIN sales s ON t.title_id = s.title_id
GROUP BY t.title;


--3) Print the publisher name and book name
SELECT p.pub_name, t.title
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id;


--4) Print the author full name for all the authors
SELECT CONCAT(au_fname,' ', au_lname) 'Author Full Name'
FROM authors


--5) Print the price of every book with tax (price+price*12.36/100)
SELECT title, price, price + (price * 12.36 / 100) 'Price (+ Tax)'
FROM titles;


--6) Print the author name, title name
SELECT CONCAT(a.au_fname,' ', a.au_lname) 'Author Full Name'
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id


--7) print the author name, title name and the publisher name
SELECT CONCAT(a.au_fname,' ', a.au_lname) 'Author Full Name'
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id


--8) Print the average price of books pulished by every publisher
SELECT t.pub_id, p.pub_name, AVG(t.price) 'Average price'
FROM titles t
JOIN publishers p ON t.pub_id = p.pub_id
GROUP BY t.pub_id, p.pub_name

--9) print the books published by 'Marjorie'
SELECT t.title
FROM titles t
JOIN titleauthor ta ON ta.title_id = t.title_id
JOIN authors a ON a.au_id = ta.au_id
WHERE a.au_fname = 'Marjorie' OR a.au_lname = 'Marjorie'


--10) Print the order numbers of books published by 'New Moon Books'
SELECT s.ord_num
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON p.pub_id = t.pub_id
WHERE p.pub_name = 'New Moon Books'


--11) Print the number of orders for every publisher
SELECT p.pub_name, COUNT(s.ord_num) 'Number of Orders'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
JOIN publishers p ON p.pub_id = t.pub_id
GROUP BY p.pub_name


--12) print the order number , book name, quantity, price and the total price for all orders
SELECT s.ord_num, t.title, s.qty, t.price, (t.price*s.qty) 'Total Price' 
FROM sales s
JOIN titles t ON t.title_id = s.title_id


--13) print the total order quantity for every book
SELECT t.title, SUM(s.qty) 'Total Order Quantity'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title


--14) print the total ordervalue for every book
SELECT t.title, SUM((s.qty*t.price)) 'Total Order Value'
FROM sales s
JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title


--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
SELECT * FROM employee

SELECT s.ord_num
FROM sales s
JOIN titles t ON t.title_id = s.title_id
JOIN employee e ON e.pub_id = t.pub_id
WHERE e.fname = 'Paolo'