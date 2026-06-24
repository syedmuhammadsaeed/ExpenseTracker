-- Query 1: Retrieve all expenses with their category names
SELECT Id, Title, Amount, Category, CreatedAt
FROM Expenses
ORDER BY CreatedAt DESC;

-- Query 2: Retrieve total amount spent per category
SELECT Category, SUM(Amount) AS TotalAmount
FROM Expenses
GROUP BY Category
ORDER BY TotalAmount DESC;

-- Query 3: Retrieve the most expensive expense
SELECT TOP 1 Id, Title, Amount, Category, CreatedAt
FROM Expenses
ORDER BY Amount DESC;
