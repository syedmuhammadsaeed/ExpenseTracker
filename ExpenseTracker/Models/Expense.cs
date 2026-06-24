namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents a personal expense entry.
    /// </summary>
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
