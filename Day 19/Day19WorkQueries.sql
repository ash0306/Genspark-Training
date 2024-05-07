use pubs
go

select * from authors
select * from publishers
select * from pub_info
select * from titleauthor
select * from titles
select * from employee
select * from sales



--1. Create a stored procedure that will take the author firstname 
--and print all the books polished by him with the publisher's name
create proc proc_GetAllBooksPublished(@afname varchar(50))
as 
begin
	select t.title, p.pub_name
	from authors a
	join titleauthor ta on ta.au_id = a.au_id
	join titles t on t.title_id = ta.title_id
	join publishers p on p.pub_id = t.pub_id
	where a.au_fname = @afname
end

exec proc_GetAllBooksPublished 'Akiko'


--2. Create a sp that will take the employee's firtname 
--and print all the titles sold by him/her, price, quantity and the cost.
create proc proc_GetAllTitles(@efname varchar(50))
as
begin
	select t.title, t.price, s.qty
	from employee e
	join titles t on t.pub_id = e.pub_id
	join sales s on t.title_id = s.title_id
	where e.fname = @efname
end

exec proc_GetAllTitles 'Paolo'



--3. Create a query that will print all names from authors and employees
select concat(fname, ' ', lname) as Fullname
from Employee
union 
select concat(au_fname, ' ', au_lname) as Fullname
from authors


--4. Create a  query that will float the data from sales,titles, publisher and authors table 
--to print title name, Publisher's name, author's full name with quantity ordered and price for the order 
--for all orders, print first 5 orders after sorting them based on the price of order

with OrderDetails_CTE(TitleName, AuthorFullName, PubName, Quantity, Price)
as
(
select t.title as 'Book Title', concat(a.au_fname, ' ', a.au_lname) as 'Author Name', p.pub_name as 'Publisher Name', s.qty as 'Quantity', (t.price*s.qty) as 'Order Price'
from titles t
join titleauthor ta on ta.title_id = t.title_id
join authors a on a.au_id = ta.au_id
join publishers p on p.pub_id = t.pub_id
join sales s on s.title_id = t.title_id
)

select top 5 * from OrderDetails_CTE order by price desc


-- 5. GRANT AND REVOKE

SELECT * FROM sys.database_principals

-- Create two roles 'role1' and 'role2'
CREATE ROLE role1
CREATE ROLE role2

-- Create a user and assign it to 'role1'
CREATE USER user1 WITHOUT LOGIN
ALTER ROLE role1 ADD MEMBER user1
CREATE USER user2 WITHOUT LOGIN
ALTER ROLE role2 ADD MEMBER user2

-- Grant 'SELECT' permission on a sample table to 'role1'
CREATE TABLE SampleTable (id INT, name VARCHAR(50))
INSERT INTO SampleTable VALUES (1, 'Sample Data')
GRANT SELECT ON SampleTable TO role1 -- Granting permission to 'role1'

--Demonstrate granting and revoking permissions from 'role1' perspective
EXECUTE AS USER = 'user1'
SELECT * FROM SampleTable -- This should work
REVERT

--Demonstrate granting and revoking permissions from 'role2' perspective
EXECUTE AS USER = 'user2'
SELECT * FROM SampleTable -- This shouldn't work as 'role2' doesn't have permission
REVERT  -- Reverts the user back to the main user

-- Revoke SELECT permission from 'role1'
REVOKE SELECT ON SampleTable TO role1;

-- Demonstrate revoking permissions from 'role1' perspective
EXECUTE AS USER = 'user1';
SELECT * FROM SampleTable; -- This should now throw an error due to revoked permissions
REVERT;


-- For deleting the users and the roles
DROP USER user1
DROP USER user2
DROP ROLE role1
DROP ROLE role2
DROP TABLE SampleTable