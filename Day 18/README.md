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


**Video Store**

Create an ER model for a movie store with the following specifications:

A video store rents movies to members.

Each movie in the store has a title and is identified by a unique movie number.

A movie can be in VHS, VCD, or DVD format.

Each movie belongs to one of a given set of categories (action, adventure, comedy, etc.)

The store has a name and a unique phone number for each member.

Each member may provide a favorite movie category (used for marketing purposes).

There are two types of members: Golden Members and Bronze Members.

Golden Members can rent one or more movies using their credit cards, while Bronze Members can rent a maximum of one movie.

A member may have a number of dependents (with known names), each of whom is allowed to rent one movie at a time.


**Designing**

- Movie - Id(pk), Format, Title, Category

- Member - Id(pk),Name, Phone, FavouriteCategory, MemberType

- MemberType - Golden, Bronze

- Dependents - Id(pk), MemberId(fk)

- Rentals - Id(pk), MemberId(fk), DateOfRental

- RentalDetails - RentalId(fk), MovieId(fk)


**ER Diagram**

![ERD](./Day18VideoStoreERD.svg)


### SQL QUeries

Worked on Outer join queries in SQL. The file for the same can be found [here](./Day18SQLQueries.sql)