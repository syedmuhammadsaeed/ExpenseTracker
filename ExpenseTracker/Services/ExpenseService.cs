using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides in-memory CRUD and summary operations for expenses.
    /// </summary>
    public class ExpenseService
    {
        private static readonly List<Expense> Expenses = new();
        private static int nextId = 1;

        /// <summary>
        /// Gets all expenses.
        /// </summary>
        public Task<List<Expense>> GetAllAsync()
        {
            var result = Expenses.OrderBy(e => e.CreatedAt).ToList();
            return Task.FromResult(result);
        }

        /// <summary>
        /// Gets an expense by id.
        /// </summary>
        public Task<Expense?> GetByIdAsync(int id)
        {
            var expense = Expenses.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(expense);
        }

        /// <summary>
        /// Creates a new expense.
        /// </summary>
        public Task<Expense> CreateAsync(Expense expense)
        {
            expense.Id = nextId++;
            expense.CreatedAt = DateTime.UtcNow;
            Expenses.Add(expense);
            return Task.FromResult(expense);
        }

        /// <summary>
        /// Deletes an expense by id.
        /// </summary>
        public Task<bool> DeleteAsync(int id)
        {
            var expense = Expenses.FirstOrDefault(e => e.Id == id);
            if (expense is null)
            {
                return Task.FromResult(false);
            }

            Expenses.Remove(expense);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Gets a summary of expenses.
        /// </summary>
        public Task<object> GetSummaryAsync()
        {
            var totalAmount = Expenses.Sum(e => e.Amount);
            var expenseCount = Expenses.Count;
            var categoryBreakdown = Expenses
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

            var summary = new
            {
                totalAmount,
                expenseCount,
                categoryBreakdown
            };

            return Task.FromResult<object>(summary);
        }
    }
}
