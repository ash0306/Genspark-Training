# DAY 18

## Topics Covered

- SQL Queries (Outer Joins)
- ERD
- Design of ER Diagrams


## Work

### Designing an ER Diagram

**Shop Inventory and Billing System**

This system is designed to record the stock available and billed in a shop. The system minimizes the amount of customer data required and allows for multiple suppliers for a single product. A single supplier can also supply many products.

* A shop want to record the stock available and billed in a shop.
* Customer data has to be minimum.
* One product could be supplied by multiple supplier.
* A Single supplier can supply many products.


**Designing**

- Customer - Id(pk), Name, Phone, Email

- Product - Id(pk), SupplierProductsId(fk), Name, Price, Stock

- Supplier - Id(pk), Name, Phone

- SupplierProducts - Id(pk), SupplierId(fk), ProductId(fk)

- Bill - Id(pk), DateOfBilling, OverallDiscount, CustomerId(fk) 

- BillDetails - BillId(fk), ProductId(fk)


**ER Diagram**

![ERD](./ERD.svg)


### SQL QUeries

Worked on Outer join queries in SQL. The file for the same can be found [here](./Day18SQLQueries.sql)