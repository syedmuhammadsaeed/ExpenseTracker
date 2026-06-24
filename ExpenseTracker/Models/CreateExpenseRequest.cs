namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the payload used to create a new expense.
    /// </summary>
    public class CreateExpenseRequest
    {
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
