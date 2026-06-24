 # ExpenseTracker

A professional ASP.NET Core Web API for managing personal expenses with an in-memory storage layer.

## Features
- Create, read, update, and delete expenses
- In-memory storage with auto-incrementing IDs
- Validation for required fields and positive amounts
- Summary endpoint with totals and category breakdown
- Swagger UI for interactive API testing

## API Endpoints
- GET /api/expenses
- GET /api/expenses/{id}
- POST /api/expenses
- DELETE /api/expenses/{id}
- GET /api/expenses/summary

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or VS Code with C# extension

## Installation
```bash
dotnet restore
dotnet build
```

## Run the Application
```bash
dotnet run
```

Then open:
```text
https://localhost:5001/swagger
```

## Example Requests
### Create Expense
```http
POST /api/expenses
Content-Type: application/json

{
  "title": "Lunch",
  "amount": 250,
  "category": "Food"
}
```

### Get Summary
```http
GET /api/expenses/summary
```

## Project Structure
- Controllers/
- Models/
- Services/
- Program.cs
- queries.sql
- ExpenseTracker.postman_collection.json