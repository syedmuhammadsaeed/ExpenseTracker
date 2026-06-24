-- SQL queries for ExpenseTracker
-- Example table creation
CREATE TABLE Expenses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Description NVARCHAR(255),
    Amount DECIMAL(10,2) NOT NULL,
    Date DATETIME NOT NULL,
    Category NVARCHAR(100)
);
