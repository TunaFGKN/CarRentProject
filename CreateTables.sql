CREATE TABLE Users(
	UserID int PRIMARY KEY IDENTITY (1,1),
	FirstName nvarchar(40),
	LastName nvarchar(50),
	Email nvarchar(60),
	Password nvarchar(35)
)

CREATE TABLE Customers(
	CustomerID int PRIMARY KEY IDENTITY (1,1),
	UserID int,
	CompanyName nvarchar(40),
	FOREIGN KEY (UserID) REFERENCES Users(UserID) 
)

CREATE TABLE Rentals(
	RentalID int PRIMARY KEY IDENTITY (1,1),
	CarID int,
	CustomerID int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY(CarID) REFERENCES Cars(CarID),
	FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)