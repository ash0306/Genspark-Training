# Banking Management System

### Auth Microservice Design

#### Classes and their attributes/methods

1. **User**

   - **Attributes**:

     - `userId: String`: Unique identifier for the user.
     - `username: String`: Username for the user.
     - `role: String`: Role of the user (Admin, BankEmployee, Customer).
     - `isActiveUser: boolean`: Indicates if the user is active. For Soft Delete.

   - **Methods**:
     - `setUsername(username: String): void`: Sets the username.
     - `getUsername(): String`: Gets the username.
     - `setRole(role: String): void`: Sets the role.
     - `setIsActiveUser(isActiveUser: boolean): void`: Sets the active status.
     - `getIsActiveUser(): boolean`: Gets the active status.
     - `getRole(): String`: Gets the role.

2. **Password**

   - **Attributes**:

     - `userId: String`: Primary Key (Foreign key to the User).
     - `passwordHash: String`: Hashed password.

   - **Methods**:
     - `setPasswordHash(passwordHash: String): void`: Sets the hashed password.
     - `getPasswordHash(): String`: Gets the hashed password.
     - `matchPassword(password: String): boolean`: Matches the provided password with the stored hash.

#### Layer-wise Interfaces and Methods

##### Controller Layer

**AuthController**

- **Endpoints**:
  - `POST /auth/register`: Registers a new user.
  - `POST /auth/login`: Authenticates a user.
  - `PUT /auth/change-password`: Changes the user's password.
- **Methods**:
  - `registerUser(userDTO: UserDTO, passwordDTO: PasswordDTO): ResponseEntity`
  - `login(credentialsDTO: CredentialsDTO): ResponseEntity`
  - `changePassword(userId: String, passwordDTO: PasswordDTO): ResponseEntity`

**AdminController**

- **Endpoints**:
  - `POST /admin/users`: Creates a new user (BankEmployee or Customer).
  - `PUT /admin/users/{userId}`: Updates an existing user.
  - `PUT /admin/users/{userId}`: Soft Deletes a user.
  - `GET /admin/users/{userId}`: Retrieves a user by ID.
  - `GET /admin/users`: Retrieves all users.
- **Methods**:
  - `createUser(userDTO: UserDTO): ResponseEntity`
  - `updateUser(userId: String, userDTO: UserDTO): ResponseEntity`
  - `deleteUser(userId: String): ResponseEntity`
  - `getUser(userId: String): ResponseEntity`
  - `getAllUsers(): ResponseEntity`

**BankEmployeeController**

- **Endpoints**:
  - `POST /employee/customers`: Creates a new customer.
  - `PUT /employee/customers/{userId}`: Updates an existing customer.
  - `PUT /employee/customers/{userId}`: Soft Deletes a customer.
  - `GET /employee/customers/{userId}`: Retrieves a customer by ID.
  - `GET /employee/customers`: Retrieves all customers.
  - `POST /employee/accounts`: Creates a new account.
- **Methods**:
  - `createCustomer(userDTO: UserDTO): ResponseEntity`
  - `updateCustomer(userId: String, userDTO: UserDTO): ResponseEntity`
  - `deleteCustomer(userId: String): ResponseEntity`
  - `getCustomer(userId: String): ResponseEntity`
  - `getAllCustomers(): ResponseEntity`
  - `createAccount(accountDTO: AccountDTO): ResponseEntity`

##### Service Layer

**AuthService**

- **Methods**:
  - `registerUser(userDTO: UserDTO, passwordDTO: PasswordDTO): User`: Registers a new user.
  - `login(credentialsDTO: CredentialsDTO): User`: Authenticates a user.
  - `changePassword(userId: String, passwordDTO: PasswordDTO): User`: Changes the user's password.

**AdminService**

- **Methods**:
  - `createUser(userDTO: UserDTO): User`: Creates a new user (BankEmployee or Customer).
  - `updateUser(userId: String, userDTO: UserDTO): User`: Updates an existing user.
  - `deleteUser(userId: String): void`: Soft Deletes a user.
  - `getUser(userId: String): User`: Retrieves a user by ID.
  - `getAllUsers(): List<User>`: Retrieves all users.

**BankEmployeeService**

- **Methods**:
  - `createCustomer(userDTO: UserDTO): User`: Creates a new customer.
  - `updateCustomer(userId: String, userDTO: UserDTO): User`: Updates an existing customer.
  - `deleteCustomer(userId: String): void`: Soft a customer.
  - `getCustomer(userId: String): User`: Retrieves a customer by ID.
  - `getAllCustomers(): List<User>`: Retrieves all customers.
  - `createAccount(accountDTO: AccountDTO): Account`: Creates a new account.

**DTOs (Data Transfer Objects)**

1. **UserDTO**

   - **Attributes**:
     - `userId: String`: Unique identifier for the user.
     - `username: String`: Username for the user.
     - `role: String`: Role of the user (Admin, BankEmployee, Customer).

2. **PasswordDTO**

   - **Attributes**:
     - `userId: String`: Primary Key (Foreign key to the User.)
     - `passwordHash: String`: Hashed password.

3. **CredentialsDTO**

   - **Attributes**:
     - `username: String`: Username for the user.
     - `password: String`: Password for the user.

4. **AccountDTO**
   - **Attributes**:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).

**Endpoints and Corresponding DTOs**

1. **Register User Endpoint**

   - **URL**: `POST /auth/register`
   - **Request Body**: `UserDTO`, `PasswordDTO`
   - **Response Body**: `UserDTO`

2. **Login Endpoint**

   - **URL**: `POST /auth/login`
   - **Request Body**: `CredentialsDTO`
   - **Response Body**: `UserDTO`

3. **Change Password Endpoint**

   - **URL**: `PUT /auth/change-password`
   - **Request Body**: `PasswordDTO`
   - **Response Body**: `UserDTO`

4. **Create User Endpoint (Admin)**

   - **URL**: `POST /admin/users`
   - **Request Body**: `UserDTO`
   - **Response Body**: `UserDTO`

5. **Update User Endpoint (Admin)**

   - **URL**: `PUT /admin/users/{userId}`
   - **Request Body**: `UserDTO`
   - **Response Body**: `UserDTO`

6. **Delete User Endpoint (Admin)**

   - **URL**: `PUT /admin/users/{userId}`
   - **Response Body**: `void`

7. **Get User Endpoint (Admin)**

   - **URL**: `GET /admin/users/{userId}`
   - **Response Body**: `UserDTO`

8. **Get All Users Endpoint (Admin)**

   - **URL**: `GET /admin/users`
   - **Response Body**: `List<UserDTO>`

9. **Get All Users Endpoint (Admin)**

   - **URL**: `GET /admin/users`
   - **Response Body**: List of `UserDTO`

10. **Create Customer Endpoint (Bank Employee)**

    - **URL**: `POST /employee/customers`
    - **Request Body**: `UserDTO`
    - **Response Body**: `UserDTO`

11. **Update Customer Endpoint (Bank Employee)**

    - **URL**: `PUT /employee/customers/{userId}`
    - **Request Body**: `UserDTO`
    - **Response Body**: `UserDTO`

12. **Delete Customer Endpoint (Bank Employee)**

    - **URL**: `PUT /employee/customers/{userId}`
    - **Response Body**: `void`

13. **Get Customer Endpoint (Bank Employee)**

    - **URL**: `GET /employee/customers/{userId}`
    - **Response Body**: `UserDTO`

14. **Get All Customers Endpoint (Bank Employee)**

    - **URL**: `GET /employee/customers`
    - **Response Body**: List of `UserDTO`

15. **Create Account Endpoint (Bank Employee)**
    - **URL**: `POST /employee/accounts`
    - **Request Body**: `AccountDTO`
    - **Response Body**: `AccountDTO`

### Generic Process Flow for Auth Microservice

#### 1. User Registration

```plaintext
Actor -> Auth Service: registerUser(userDTO, passwordDTO)
Auth Service -> User Repository: save user details
Auth Service -> Password Repository: save hashed password
User Repository -> Auth Service: user saved confirmation
Password Repository -> Auth Service: password saved confirmation
Auth Service -> Actor: registration success response
```

#### 2. User Login

```plaintext
Actor -> Auth Service: login(credentialsDTO)
Auth Service -> User Repository: find user by username
User Repository -> Auth Service: user found
Auth Service -> Password Repository: find password by userId
Password Repository -> Auth Service: password found
Auth Service -> Actor: login success response with UserDTO
```

#### 3. Change Password

```plaintext
Actor -> Auth Service: changePassword(userId, passwordDTO)
Auth Service -> Password Repository: update passwordHash for userId
Password Repository -> Auth Service: password updated confirmation
Auth Service -> Actor: password change success response
```

#### 4. CRUD Operations by Admin on Users

```plaintext
Actor -> Admin Service: createUser(userDTO)
Admin Service -> User Repository: save user details
User Repository -> Admin Service: user saved confirmation
Admin Service -> Actor: creation success response

Actor -> Admin Service: updateUser(userId, userDTO)
Admin Service -> User Repository: update user details
User Repository -> Admin Service: user updated confirmation
Admin Service -> Actor: update success response

Actor -> Admin Service: deleteUser(userId)
Admin Service -> User Repository: update user by userId set isActiveUser=false
User Repository -> Admin Service: user update confirmation
Admin Service -> Actor: deletion success response

Actor -> Admin Service: getUser(userId)
Admin Service -> User Repository: find user by userId
User Repository -> Admin Service: return user details
Admin Service -> Actor: user details response

Actor -> Admin Service: getAllUsers()
Admin Service -> User Repository: find all users
User Repository -> Admin Service: return list of users
Admin Service -> Actor: list of users response
```

#### 5. CRUD Operations by Bank Employee on Customers

```plaintext
Actor -> Bank Employee Service: createCustomer(userDTO)
Bank Employee Service -> User Repository: save customer details
User Repository -> Bank Employee Service: customer saved confirmation
Bank Employee Service -> Actor: customer creation success response

Actor -> Bank Employee Service: updateCustomer(userId, userDTO)
Bank Employee Service -> User Repository: update customer details
User Repository -> Bank Employee Service: customer updated confirmation
Bank Employee Service -> Actor: update success response

Actor -> Bank Employee Service: deleteCustomer(userId)
Bank Employee Service -> User Repository: update customer by userId set isActiveUser=false
User Repository -> Bank Employee Service: customer deleted confirmation
Bank Employee Service -> Actor: deletion success response

Actor -> Bank Employee Service: getCustomer(userId)
Bank Employee Service -> User Repository: find customer by userId
User Repository -> Bank Employee Service: return customer details
Bank Employee Service -> Actor: customer details response

Actor -> Bank Employee Service: getAllCustomers()
Bank Employee Service -> User Repository: find all customers
User Repository -> Bank Employee Service: return list of customers
Bank Employee Service -> Actor: list of customers response
```

#### 6. Create Account by Bank Employee

```plaintext
Actor -> Bank Employee Service: createAccount(accountDTO)
Bank Employee Service -> Account Repository: save account details
Account Repository -> Bank Employee Service: account saved confirmation
Bank Employee Service -> Actor: account creation success response
```

### <------------ End Auth Module Microservice Design---------->

<br>
<br>

### Transactions Module Microservice Design

#### Classes and their attributes/methods

1. **Account**

   - Attributes:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).
   - Methods:
     - `deposit(amount: double): void`: Adds the specified amount to the account balance.
     - `withdraw(amount: double): void`: Subtracts the specified amount from the account balance if funds are sufficient.
     - `transfer(toAccount: Account, amount: double): void`: Transfers the specified amount to another account.
     - `validateFunds(amount: double): boolean`: Checks if the account has sufficient funds for a transaction.

2. **Customer**

   - Attributes:
     - `customerId: String`: Unique identifier for the customer.
     - `userId: String`: Foreign key to the associated user.
     - `name: String`: Name of the customer.
     - `accounts: List<Account>`: List of accounts associated with the customer.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction for the customer.

3. **BankEmployee**

   - Attributes:
     - `employeeId: String`: Unique identifier for the bank employee.
     - `name: String`: Name of the bank employee.
     - `role: String`: Role of the bank employee (e.g., Teller, Manager).
   - Methods:
     - `approveTransaction(transaction: Transaction): void`: Approves a transaction initiated by a customer.
     - `validateRole(role: String): boolean`: Validates if the employee has the correct role for performing a specific action.

4. **Transaction**

   - Attributes:
     - `transactionId: String`: Unique identifier for the transaction.
     - `fromAccountId: String`: Identifier for the account involved in the transaction.
     - `toAccountId: String`: Identifier for the target account in case of a transfer.
     - `type: String`: Type of the transaction (Deposit, Withdrawal, Transfer).
     - `amount: double`: Amount involved in the transaction.
     - `status: String`: Status of the transaction (Pending, Completed, Failed).
     - `date: Date`: Date and time when the transaction was created.
   - Methods:
     - `validate(): boolean`: Validates the transaction details.
     - `process(): void`: Processes the transaction.
     - `record(): void`: Records the transaction in the system.
     - `confirm(): void`: Confirms the transaction to the customer.

5. **System (Web Interface, Bank Branch, Mobile Application)**

   - Attributes:
     - `systemId: String`: Unique identifier for the system.
     - `location: String`: Location or identifier for the system's physical or virtual presence.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction through the system.

6. **ATM**
   - Attributes:
     - `atmId: String`: Unique identifier for the ATM.
     - `location: String`: Physical location of the ATM.
   - Methods:
     - `initiateTransaction(transaction: Transaction): void`: Initiates a transaction through the ATM.

### Layer-wise Interfaces and Methods

#### Controller Layer

**TransactionController**

- **Endpoints**:
  - `POST /transactions/deposit`: Endpoint for initiating a deposit transaction.
  - `POST /transactions/withdrawal`: Endpoint for initiating a withdrawal transaction.
  - `POST /transactions/transfer`: Endpoint for initiating a transfer transaction.
- **Methods**:
  - `initiateDeposit(transactionDTO: TransactionDTO): ResponseEntity`: Handles deposit requests.
  - `initiateWithdrawal(transactionDTO: TransactionDTO): ResponseEntity`: Handles withdrawal requests.
  - `initiateTransfer(transactionDTO: TransactionDTO): ResponseEntity`: Handles transfer requests.

**AccountController**

- **Endpoints**:
  - `GET /accounts/{accountId}`: Endpoint for retrieving account details.
  - `POST /accounts`: Endpoint for creating a new account.
- **Methods**:
  - `getAccountDetails(accountId: String): ResponseEntity`: Retrieves account details based on the account ID.
  - `createAccount(accountDTO: AccountDTO): ResponseEntity`: Creates a new account based on the provided account details.

#### Service Layer

**TransactionService**

- **Methods**:
  - `processDeposit(transactionDTO: TransactionDTO): Transaction`: Processes a deposit transaction.
  - `processWithdrawal(transactionDTO: TransactionDTO): Transaction`: Processes a withdrawal transaction.
  - `processTransfer(transactionDTO: TransactionDTO): Transaction`: Processes a transfer transaction.

**AccountService**

- **Methods**:
  - `getAccountDetails(accountId: String): Account`: Retrieves account details based on the account ID.

#### Repository Layer

### Common Base Repository for CRUD Operations

### Base Repository Interface

#### BaseRepository<T, ID>

**Methods**:

- `save(entity: T): T`: Saves an entity to the database.
  - **Description**: Persists the provided entity to the database and returns the saved entity, including any auto-generated fields.
  - **Parameters**:
    - `entity: T`: The entity to be saved.
  - **Returns**:
    - `T`: The saved entity.
- `findById(id: ID): Optional<T>`: Finds an entity by its ID.
  - **Description**: Retrieves an entity from the database based on its unique identifier.
  - **Parameters**:
    - `id: ID`: The unique identifier of the entity.
  - **Returns**:
    - `Optional<T>`: An optional containing the found entity or empty if no entity is found.
- `findAll(): List<T>`: Retrieves all entities.
  - **Description**: Fetches all entities of the specified type from the database.
  - **Returns**:
    - `List<T>`: A list of all entities.
- `update(entity: T): T`: Updates an existing entity in the database.
  - **Description**: Updates the provided entity in the database and returns the updated entity.
  - **Parameters**:
    - `entity: T`: The entity to be updated.
  - **Returns**:
    - `T`: The updated entity.
- `deleteById(id: ID): void`: Deletes an entity by its ID.
  - **Description**: Removes the entity with the specified ID from the database.
  - **Parameters**:
    - `id: ID`: The unique identifier of the entity to be deleted.
  - **Returns**:
    - `void`: No return value.

### Specific Repositories Extending Base Repository

Each specific repository can extend the base repository to inherit common CRUD operations, adding any additional methods unique to the entity it manages.

#### TransactionRepository

**Extends BaseRepository<Transaction, String>**

- **Methods**:
  - Inherits all methods from `BaseRepository<ModelClass, String>`
  - Additional methods specific to `ModelClass` can be defined here.

### Example Usage

**TransactionRepository**

- `save(transaction: Transaction): Transaction`: Saves a transaction to the database.
- `findById(transactionId: String): Optional<Transaction>`: Finds a transaction by its ID.
- `findAll(): List<Transaction>`: Retrieves all transactions.
- `update(transaction: Transaction): Transaction`: Updates an existing transaction.

### Endpoints with DTOs

**DTOs (Data Transfer Objects)**

1. **TransactionDTO**

   - `type: String`: Type of the transaction (Deposit, Withdrawal, Transfer).
   - `amount: double`: Amount involved in the transaction.
   - `fromAccountId: String`: Identifier for the account involved in the transaction.
   - `toAccountId: String`: Identifier for the target account in case of a transfer.

2. **AccountDTO**
   - Attributes:
     - `accountId: String`: Unique identifier for the account.
     - `balance: double`: Current balance of the account.
     - `accountHolder: String`: Name of the account holder.
     - `typeOfAccount: String`: Type of the account (e.g., Savings, Checking).

**Endpoints and Corresponding DTOs**

1. **Deposit Endpoint**

   - **URL**: `POST /transactions/deposit`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

2. **Withdrawal Endpoint**

   - **URL**: `POST /transactions/withdrawal`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

3. **Transfer Endpoint**

   - **URL**: `POST /transactions/transfer`
   - **Request Body**: `TransactionDTO`
   - **Response Body**: `TransactionDTO`

4. **Get Account Details Endpoint**
   - **URL**: `GET /accounts/{accountId}`
   - **Response Body**: `AccountDTO`

### Generic Process Flow for Transactions Through All Channels

#### 1. Generic Deposit

```plaintext
Actor -> System: initiateTransaction(deposit)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: deposit(amount)
Account -> System: update balance
System -> Actor: confirmation
```

#### 2. Generic Withdrawal

```plaintext
Actor -> System: initiateTransaction(withdrawal)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: withdraw(amount)
Account -> System: update balance
System -> Actor: confirmation
```

#### 3. Generic Transfer

```plaintext
Actor -> System: initiateTransaction(transfer)
System -> Account: validateFunds(amount)
Account -> System: validation result
System -> Account: transfer(toAccount, amount)
Account -> toAccount: update balance
System -> Actor: confirmation
```

---

# RD Class and its attributes/methods

1. **RecurringDeposit**

- Attributes:

  - `accountId:Account` - Unique Acoount ID
  - `customerId:Int` - Unique Id of the custoomer who holds the account
  - `depositInterval:String` - The deposit interval (e.g) Monthly, Half-Yearly, Annually etc.,
  - `depositAmount:Double` - Amount to be deposited for every interval
  - `interestRate:Double` - The interest rate specified by the bank
  - `tenure:Int` - The number of years that the RD is active.
  - `interestEarned:Double` - Interest amount earned for the deposits (compounded annually)
  - `totalAmount:Double` - Total amount that will be deposited by customer(excluding interest)
  - `maturityDate:Date` - The date on which the RD will mature
  - `amountDepositedTillDate:Double` - Amount deposited by till date by the customer

- Methods:
  - `addDeposit()` - Deposit the amount for each interval
  - `calcualteInterest()` - Calculate interest for each quarter
  - `calculateMaturityAmount()` - Calucate the total maturity amount to be given to the customer(including interest)
  - `prematureWithdrawal()` - Withdraw the amount in RD prematurely with a penalty(only after Admin approval)
  - `withdrawal()` - Withdraw the amount after maturity
  - `extendRD()` - Extend the RD past the current tenure

## Layer-wise Interfaces and Methods

### Repository Layer

**Repository**

- **Interface Methods**:

  - `Add(T item)` - Adds a item to the database.
  - `GetAll()` - Gets all items.
  - `GetById(K key)` - Finds a item by its ID.
  - `Update(T item)` - Updates the item.
  - `Delete(K key)` - Deletes the item

- **RecurringDepositRepository - Methods**
  - `Add(RecurringDeposit rd)` - Adds a new deposit to the database.
  - `GetAll()` - Gets all recurring deposit items
  - `GetById(int id)` - Finds the recurring deposit item with ID as id
  - `Update(RecurringDeposit rd)` - Updates an existing RD
  - `Delete(int id)` - Deletes an RD with the ID as id

### Service Layer

**RDService**

- **Methods**:
  - `addDeposit(RdDTO rd) : RdReturnDTO` - Deposit the amount for each interval
  - `calcualteInterest() : double` - Calculate interest for each quarter
  - `calculateMaturityAmount() : double` - Calucate the total maturity amount to be given to the customer(including interest)
  - `prematureWithdrawal(int amount) : WithdrawalDTO` - Withdraw the amount in RD prematurely with a penalty(only after Admin approval)
  - `withrawAmount()` - Withdraw the amount after maturity
  - `extendRD(extendDTO) : extendReturnDTO` - Extend the RD past the current tenure

### Controller Layer

**RDController**

- **Endpoints**:

  - `POST /recurring_deposit/deposit`: Endpoint for initiating a deposit. (This utilizes the `addDeposit()` function in services)
  - `GET /recurring_deposit/calculate_interest`: Endpoint for calcualting interest. (This utilizes the `calculateInterest()` function in services)
  - `GET /recurring_deposit/calculate_amount`: Endpoint for calculating total maturity amount. (This utilizes the `calculateMaturityAmount()` function in services)
  - `GET /recurring_deposit/premature_withdrawal`: Endpoint for prematurely withdrawing funds from RD. (This utilizes the `prematureWithdrawal()` function in services)
  - `POST /recurring_deposit/withdrawal` : Endpoint for withdrawing the amount after maturity
  - `PUT /recurring_deposit/extend_rd` : Endpoint for extending the tenure of the RD

- **Methods**:
  - `addDeposit(RdDTO rd) : RdReturnDTO` - Deposit the amount for each interval
  - `calcInterest() : double` - Calculate interest for each quarter
  - `calcMaturityAmount() : double` - Calucate the total maturity amount to be given to the customer(including interest)
  - `prematureWithdrawal(int amount) : WithdrawalDTO` - Withdraw the amount in RD prematurely with a penalty(only after Admin approval)
  - `withrawAmount()` - Withdraw the amount after maturity
  - `extendRD(extendDTO) : extendReturnDTO` - Extend the RD past the current tenure

### Endpoints with DTOs

**DTOs (Data Transfer Objects)**

1. **RdDTO**

   - `depositInterval:String` - The deposit interval (e.g) Monthly, Half-Yearly, Annually etc.,
   - `depositAmount:Double` - Amount to be deposited for every interval
   - `interestRate:Double` - The interest rate specified by the bank
   - `tenure:Int` - The number of years that the RD is active.
   - `interestEarned: Double` - Interest amount earned for the deposits (compounded annually)
   - `totalAmount:Double` - Total amount that will be deposited by customer(excluding interest)
   - `maturityDate:Date` - The date on which the RD will mature

2. **RdReturnDTO**

   - `customerId:Int` - Unique Id of the custoomer who holds the account
   - `depositInterval:String` - The deposit interval (e.g) Monthly, Half-Yearly, Annually etc.,
   - `depositAmount:Double` - Amount to be deposited for every interval
   - `interestRate:Double` - The interest rate specified by the bank
   - `tenure:Int` - The number of years that the RD is active.
   - `interestEarned: Double` - Interest amount earned for the deposits (compounded annually)
   - `totalAmount:Double` - Total amount that will be deposited by customer(excluding interest)
   - `maturityDate:Date` - The date on which the RD will mature
   - `amountDepositedTillDate:Double` - Amount deposited by till date by the customer

3. **WithdrawalDTO**

   - `withdrawalAmount:Double` - Amount to be withdrawn
   - `penalty:Double` - Penalty for premature withdrawal

4. **ExtendDTO**

   - `newTenure:Date` - The new date on which the RD matures
   - `newInterestRate:Double` - The new interest rate specified by the bank

5. **ExtendReturnDTO**
   - `newTenure:Date` - The new date on which the RD matures
   - `newInterestRate:Double` - The new interest rate specified by the bank
   - `status:bool` - Whether the extension was successful

## Endpoints and Corresponding DTOs

### Deposit Endpoint

URL: `POST /recurring_deposit/deposit`
Request Body: RdDTO
Response Body: RdReturnDTO

URL: `GET /recurring_deposit/calculate_interest`
Response Body: double

URL: `GET /recurring_deposit/calculate_amount`
Response Body: double

URL: `POST /recurring_deposit/premature_withdrawal`
Request Body: int (withdrawal amount)

URL: `POST /recurring_deposit/withdrawal`
Response Body: WithdrawalDTO

URL: `PUT /recurring_deposit/extend_rd`
Request Body: extendDTO
Response Body: extendReturnDTO

---

### LoanApplication

**Description**: Represents a loan application submitted by a customer.

**Attributes**:

- `application_id`: Unique identifier for the loan application.
- `customer_id`: Unique identifier for the customer applying for the loan.
- `loan_type`: Type of loan (Secured,UnSecured).

- `remarks`: Additional remarks or notes related to the application.

## Service methods for loan Application

### 1. Validating Borrower Details

#### Method: `validateBorrowerDetails(borrower_details)`

- **Description**: Validates the details of the borrower.
- **Parameters**: `borrower_details` (dictionary containing borrower's information)
- **Steps**:
  1. Check the borrower’s credit score.
  2. Verify the borrower’s identity and financial status.
  3. Ensure all required documents are submitted.

---

### 2. Processing the Loan Application

#### Method: `processLoanApplication(application_id, status)`

- **Description**: Processes the loan application by a loan officer (approve/reject).
- **Parameters**:
  - `application_id` (identifier of the loan application)
  - `status` (new status of the application, e.g., approved, rejected)
- **Steps**:
  1. Retrieve the application from the database.
  2. Perform necessary checks and validations.
  3. Update the status of the application based on the loan officer’s decision.

### 3. Generating Loan Terms

#### Method: `generateLoanTerms(loan_amount, loan_duration, interest_rate)`

- **Description**: Generates the loan terms based on the loan amount, duration, and interest rate.
- **Parameters**:
  - `loan_amount` (amount of the loan)
  - `loan_duration` (duration of the loan repayment)
  - `interest_rate` (interest rate applicable)
- **Steps**:
  1. Calculate the monthly installment.
  2. Create a repayment schedule.
  3. Document the terms and conditions.

---

### 4. Notifying the Customer

#### Method: `notifyCustomer(application_id, status, remarks)`

- **Description**: Notifies the customer about the status of their loan application.
- **Parameters**:
  - `application_id` (identifier of the loan application)
  - `status` (status of the application)
  - `remarks` (additional remarks or notes)
- **Steps**:
  1. Retrieve customer contact details.
  2. Prepare the notification message.
  3. Send the notification (e.g., email, SMS).

---

### 5. Disbursing the Loan

#### Method: `disburseLoan(loanDTO)`

- **Description**: Disburses the approved loan to the customer’s account.
- **Parameters**: `loanDTO` (contains details of the loan)
- **Steps**:

  1. Validate the final loan details.
  2. Transfer the loan amount to the customer’s account.
  3. Update the loan status to disbursed.

### UnsecuredLoanApplication(Loan-Sub-Class)

**Description**: Represents an application for an unsecured loan submitted by a customer.

**Attributes**:

- `unsecured_loan_id`: Unique identifier for the loan Id.
- `application_id`: Unique identifier for the loan application.

- `loan_amount`: Amount of money requested by the customer.
- `application_date`: Date when the loan application was submitted.
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
  `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `status`: Status of the application (e.g., pending, approved, rejected).
- `credit_score`: Credit score of the customer at the time of application.
- `income`: Customer's monthly or annual income.
- `purpose`: Purpose of the loan (e.g., debt consolidation, medical expenses).
- `documents`: List of documents submitted with the application (e.g., proof of income, ID proof).
- `remarks`: Additional remarks or notes related to the application.

# Unsecured Loan Application Module

## Layers, Interfaces, and Methods

### Controller Layer

**Interface: UnsecuredLoanApplicationController**

- **Methods**:
  - `applyForUnsecuredLoan(UnsecuredLoanApplicationDTO applicationDTO)`: Endpoint for submitting a new unsecured loan application.
  - `getUnsecuredLoanApplicationById(String applicationId)`: Endpoint for retrieving a specific unsecured loan application by its ID.
  - `updateUnsecuredLoanApplicationStatus(String applicationId, String status)`: Endpoint for updating the status of a loan application.
  - `getAllUnsecuredLoanApplications()`: Endpoint for retrieving all unsecured loan applications.

### Service Layer

**Interface: UnsecuredLoanApplicationService**

- **Methods**:
  - `submitUnsecuredLoanApplication(UnsecuredLoanApplicationDTO applicationDTO)`: Handles the submission of a new unsecured loan application.
  - `findUnsecuredLoanApplicationById(String applicationId)`: Retrieves a specific unsecured loan application by its ID.
  - `changeUnsecuredLoanApplicationStatus(String applicationId, String status)`: Updates the status of a loan application.
  - `listAllUnsecuredLoanApplications()`: Retrieves all unsecured loan applications.

### Repository Layer

**Interface: UnsecuredLoanApplicationRepository**

- **Methods**:
  - `Add(UnsecuredLoanApplication application)`: Saves a new unsecured loan application.
  - `GetById(String applicationId)`: Finds an unsecured loan application by its ID.
  - `Update(application DTO)`: Updates the status of an unsecured loan application.
  - `GetAll()`: Retrieves all unsecured loan applications.

## Endpoints and DTO

### Endpoints

- **POST /unsecured-loans/apply**: Submits a new unsecured loan application.
- **GET /unsecured-loans/{applicationId}**: Retrieves a specific unsecured loan application by its ID.
- **PUT /unsecured-loans/{applicationId}/status**: Updates the status of a loan application.
- **GET /unsecured-loans**: Retrieves all unsecured loan applications.

### DTO: UnsecuredLoanApplicationDTO

- `unsecured_loan_id`: Unique identifier for the loan Id.
- `application_id`: Unique identifier for the loan application.
- `loan_amount`: Amount of money requested by the customer.
- `application_date`: Date when the loan application was submitted.
- `loan_duration`: Duration over which the loan is repaid (e.g., 5 years).
- `repayment_terms`: Terms of repayment (e.g., Standard).
- `status`: Status of the application (e.g., pending, approved, rejected).
- `credit_score`: Credit score of the customer at the time of application.
- `income`: Customer's monthly or annual income.
- `purpose`: Purpose of the loan (e.g., debt consolidation, medical expenses).
- `documents`: List of documents submitted with the application (e.g., proof of income, ID proof).
- `remarks`: Additional remarks or notes related to the application.

### SecuredLoan Class (Sub Class of Loan)

**Attributes**:

- `secured_loan_id`: .
- `application_id`: Unique identifier for the loan application.
- `loan_amount`: (float) Total amount of the loan.

- `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
- `borrower_details`: (dict) Dictionary containing details about the borrower (name,id, credit score and other details).
- `application_date`: Date when the loan application was submitted.
- `cosigner`: (str, optional) Another party who guarantees the loan.
- `collateral`: (str, optional) Type of collateral provided for the loan (e.g., Property).
- `DownPayment`: (str, optional) Down Payment paid for the property or anything.

- `collateral_value`: (float, optional) Value of the collateral provided.

### 1. Submitting a Secured Loan Application

#### Method: `submitSecuredLoanApplication(securedLoanApplicationDTO)`

- **Description**: Submits a new secured loan application.
- **Parameters**: `securedLoanApplicationDTO` (contains details of the loan application)
- **Steps**:
  1. Validate the application details.
  2. Save the application to the database.
  3. Return a confirmation of submission.

### 2. Evaluating Collateral

#### Method: `evaluateCollateral(collateral, collateral_value)`

- **Description**: Evaluates the provided collateral and its value.
- **Parameters**:
  - `collateral` (type of collateral provided)
  - `collateral_value` (declared value of the collateral)
- **Steps**:

  1. Inspect the collateral.
  2. Verify the authenticity and value of the collateral.
  3. Document the evaluation findings.

  ### Repository Layer

**Interface: SecuredLoanApplicationRepository**

- **Methods**:

  - `Add(SecuredLoanApplication application)`: Saves a new secured loan application.
  - `GetById(String applicationId)`: Finds an Secured loan application by its ID.
  - `Update(application DTO)`: Updates the status of an secured loan application.
  - `GetAll()`: Retrieves all secured loan applications.

  ## Endpoints

### Submit Secured Loan Application

- **POST** `/secured-loan-applications`
  - Description: Submits a new secured loan application.
  - Method: `submitSecuredLoanApplication(securedLoanApplicationDTO)`

### Validate Borrower Details

- **POST** `/secured-loan-applications/{application_id}/validate`
  - Description: Validates the details of the borrower for a specific secured loan application.
  - Method: `validateBorrowerDetails(borrower_details)`

### Process Loan Application

- **PUT** `/secured-loan-applications/{application_id}/process`
  - Description: Processes a secured loan application by a loan officer (approve/reject).
  - Method: `processLoanApplication(application_id, status)`

### Evaluate Collateral

- **POST** `/secured-loan-applications/{application_id}/evaluate-collateral`
  - Description: Evaluates the provided collateral for a specific secured loan application.
  - Method: `evaluateCollateral(collateral, collateral_value)`

### Generate Loan Terms

- **POST** `/secured-loan-applications/{application_id}/generate-loan-terms`
  - Description: Generates loan terms for a specific secured loan application.
  - Method: `generateLoanTerms(loan_amount, loan_duration, interest_rate)`

### Notify Customer

- **POST** `/secured-loan-applications/{application_id}/notify-customer`
  - Description: Notifies the customer about the status of their secured loan application.
  - Method: `notifyCustomer(application_id, status, remarks)`

### Disburse Loan

- **POST** `/secured-loan-applications/{application_id}/disburse`
  - Description: Disburses the approved secured loan amount to the customer’s account.
  - Method: `disburseLoan(loanDTO)`

# DTO's

## SecuredLoanApplicationDTO

### Attributes

- **application_id**: (int) Unique identifier for the loan application.
- **loan_amount**: (float) Total amount of the loan.
- **repayment_terms**: (str) Terms of repayment (e.g., Standard).
- **loan_duration**: (str) Duration over which the loan is repaid (e.g., 5 years).
- **borrower_details**: (dict) Dictionary containing details about the borrower (name, id, credit score, and other details).
- **application_date**: (date) Date when the loan application was submitted.
- **cosigner**: (str, optional) Another party who guarantees the loan.
- **collateral**: (str, optional) Type of collateral provided for the loan (e.g., Property).
- **DownPayment**: (float, optional) Down payment paid for the property or anything.
- **collateral_value**: (float, optional) Value of the collateral provided.

### Loan

**Description**: Represents an approved unsecured loan that has been disbursed to a customer.

**Attributes**:

- `loan_id`: Unique identifier for the loan.
- `acc_id`: Account for which loan is initiated
- `loanofficer_id`: Officer who validated and processed the loan application
- `Loan Type`: Unique identifier for the associated loan application.
- `Loan Type Id`: Unique identifier for the type
- `loan_amount`: Amount of money disbursed to the customer.
- `disbursement_date`: Date when the loan was disbursed.
- `repayment_term`: Repayment term (e.g., 12 months, 5 years).
- `interest_rate`: Interest rate applied to the loan.
- `monthly_installment`: Monthly installment amount to be repaid by the customer.
- `remaining_balance`: Remaining balance of the loan.
- `repayment_schedule`: Detailed schedule of repayment dates and amounts.
- `Initiated_Repayments`: List of repayments made for loan amount
- `Loan Status` : Shows the status of the Loan (active, closed)

# Loan Module Structure

## Controller Layer

### Interface: LoanController

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `getLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `getLoanRepaymentSchedule(String loanId)`: Retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `getAllLoans()`: Retrieves all loans.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `getAllActiveLoans()`: Retrieves all active loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Service Layer

### Interface: LoanService

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `findLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `generateRepaymentSchedule(String loanId)`: Generates and retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `listAllLoans()`: Retrieves all loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Repository Layer

### Interface: LoanRepository

#### Methods:

- `Add(Loan loan)`: Saves a new loan record.
- `GetById(String loanId)`: Finds a loan by its ID.
- `Update(Loan loan)`: Updates a loan record.
- `GetAll()`: Retrieves all loans.

## Endpoints and DTO

#### Methods:

- **POST /loans**

  - Description: Initiates a new loan.
  - Request Body: LoanDTO

- **GET /loans/{loanId}**

  - Description: Retrieves a specific loan by its ID.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}**

  - Description: Updates loan details.
  - Path Parameter: loanId (String)
  - Request Body: LoanDTO

- **GET /loans/{loanId}/repayment-schedule**

  - Description: Retrieves the repayment schedule of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/repayment-schedule**

  - Description: Updates the repayment schedule of a loan.
  - Path Parameter: loanId (String)
  - Request Body: RepaymentScheduleDTO

- **PUT /loans/{loanId}/remaining-balance**

  - Description: Updates the remaining balance of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/interest-rate**

  - Description: Updates the interest rate of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/repayment-term**

  - Description: Updates the repayment term of a loan.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans**

  - Description: Retrieves all loans.

- **GET /loans/{loanId}/loan-history**

  - Description: Retrieves loan history for a customer.
  - Path Parameter: customerId (String)

- **GET /loans/{loanId}/notify-late-payment**

  - Description: Notifies the borrower of a late payment.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/request-loan-statement**

  - Description: Provides a detailed statement of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/make-repayment**

  - Description: Registers a repayment.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/apply-interest-accrual**

  - Description: Applies interest accrual to a loan.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/notify-upcoming-payments**

  - Description: Notifies the borrower of upcoming payments.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/close-loan**

  - Description: Closes a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/approve-modification**

  - Description: Approves a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: ModificationDetailsDTO

- **PUT /loans/{loanId}/reject-modification**

  - Description: Rejects a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans/{loanId}/review-default-risk**
  - Description: Reviews the default risk of a loan.
  - Path Parameter: loanId (String)

### DTOs

#### LoanDTO

Attributes:

- `loan_id: String`
- `acc_id: String`
- `loan_type: String`
- `loan_type_id: String`
- `loan_amount: BigDecimal`
- `disbursement_date: Date`
- `repayment_term: String`
- `interest_rate: BigDecimal`
- `monthly_installment: BigDecimal`
- `remaining_balance: BigDecimal`
- `repayment_schedule: RepaymentScheduleDTO`
- `initiated_repayments: List<Repayment>`

#### RepaymentScheduleDTO

Attributes:

- `repayment_schedule: String`

#### ModificationDetailsDTO

Attributes:

- `modification_details: String`

### Repayment

**Description**: Represents a repayment made by a customer towards a loan.

**Attributes**:

- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.

# Repayment Module in Banking System

## Layers

### Controller Layer

**Interface: RepaymentController**

- **Methods**:
  - `recordRepayment(RepaymentDTO repaymentDTO)`: Endpoint for recording a new repayment.
  - `getRepaymentById(String repaymentId)`: Endpoint for retrieving a specific repayment by its ID.
  - `getRepaymentsByLoanId(String loanId)`: Endpoint for retrieving all repayments made towards a specific loan.
  - `getAllRepayments()`: Endpoint for retrieving all repayments.

### Service Layer

**Interface: RepaymentService**

- **Methods**:
  - `submitRepayment(RepaymentDTO repaymentDTO)`: Handles the recording of a new repayment.
  - `findRepaymentById(String repaymentId)`: Retrieves a specific repayment by its ID.
  - `findRepaymentsByLoanId(String loanId)`: Retrieves all repayments made towards a specific loan.
  - `listAllRepayments()`: Retrieves all repayments.

### Repository Layer

**Interface: RepaymentRepository**

- **Methods**:
  - `add(Repayment repayment)`: Saves a new repayment record.
  - `GetById(String repaymentId)`: Finds a repayment by its ID.
  - `GetAll()`: Retrieves all repayments.

## Endpoints and DTO

### Endpoints

- `POST /repayments`: Submits a new repayment.
- `GET /repayments/{repaymentId}`: Retrieves a specific repayment by its ID.
- `GET /repayments/loan/{loanId}`: Retrieves all repayments made towards a specific loan.
- `GET /repayments`: Retrieves all repayments.

### DTO: RepaymentDTO

**Attributes**:

- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.

### FD Account Entity

```csharp
public class FDAccount
{
    public int FDAccountId { get; set; }
    public int AccountId { get; set; }
    public decimal DepositAmount { get; set; }
    public double InterestRate { get; set; }
    public string InterestType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime MaturityDate { get; set; }
    public string Status { get; set; }// "Active", "Matured", "Closed", "Renewed"
}


+-----------------------+
|       FDAccount       |
+-----------------------+
| - FDAccountId: int    |
| - AccountId: int      |
| - DepositAmount: decimal |
| - InterestRate: double|
| - InterestType: string|
| - StartDate: DateTime |
| - MaturityDate: DateTime |
| - Status: string      |
+-----------------------+

+--------------------------+
|      FDAccountService    |
+--------------------------+
| + CreateFDAccountAsync(accountId: int, depositAmount: decimal, interestRate: double, duration: int): Task<FDAccountResponse> |
| + GetFDAccountDetailsAsync(fdAccountId: int): Task<FDAccountResponse> |
| + WithdrawFromFDAccountAsync(fdAccountId: int): Task<FDAccountResponse> |
| + GetThePenaltyAndWithdrawFromFDAccountAsync(fdAccountId: int): Task<FDAccountResponse> |
|+ RenewFDAccountAsync(fdAccountId: int, newDuration: int): Task<FDAccountResponse> |
+--------------------------+

+--------------------------+
|      IFDAccountService   |
+--------------------------+
| + CreateFDAccountAsync(accountId: int, depositAmount: decimal, interestRate: double, duration: int): Task<FDAccountResponse> |
| + GetFDAccountDetailsAsync(fdAccountId: int): Task<FDAccountResponse> |
| + WithdrawFromFDAccountAsync(fdAccountId: int): Task<FDAccountResponse> |
| + GetThePenaltyAndWithdrawFromFDAccountAsync(fdAccountId: int): Task<FDAccountResponse> |
|+ RenewFDAccountAsync(fdAccountId: int, newDuration: int): Task<FDAccountResponse> |
+--------------------------+
```
