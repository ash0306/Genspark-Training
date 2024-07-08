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
    - `extendRD()` -  Extend the RD past the current tenure

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