using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Handles expense-related API operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private static readonly List<ExpenseRecord> Expenses = new();
        private static int nextId = 1;

        /// <summary>
        /// Gets all expenses.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<ExpenseRecord>> GetAll()
        {
            return Ok(Expenses.OrderBy(e => e.CreatedAt).ToList());
        }

        /// <summary>
        /// Gets a single expense by id.
        /// </summary>
        [HttpGet("{id:int}")]
        public ActionResult<ExpenseRecord> GetById(int id)
        {
            var expense = Expenses.FirstOrDefault(e => e.Id == id);
            if (expense is null)
            {
                return NotFound(new { error = "Expense not found." });
            }

            return Ok(expense);
        }

        /// <summary>
        /// Creates a new expense.
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] CreateExpenseRequest request)
        {
            var validationError = ValidateRequest(request);
            if (validationError is not null)
            {
                return BadRequest(new { error = validationError });
            }

            var expense = new ExpenseRecord
            {
                Id = nextId++,
                Title = request.Title.Trim(),
                Amount = request.Amount,
                Category = request.Category.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            Expenses.Add(expense);
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
        }

        /// <summary>
        /// Deletes an expense by id.
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var expense = Expenses.FirstOrDefault(e => e.Id == id);
            if (expense is null)
            {
                return NotFound(new { error = "Expense not found." });
            }

            Expenses.Remove(expense);
            return NoContent();
        }

        /// <summary>
        /// Gets a summary of all expenses.
        /// </summary>
        [HttpGet("summary")]
        public ActionResult<object> GetSummary()
        {
            var totalAmount = Expenses.Sum(e => e.Amount);
            var expenseCount = Expenses.Count;
            var categoryBreakdown = Expenses
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

            return Ok(new
            {
                totalAmount,
                expenseCount,
                categoryBreakdown
            });
        }

        private static string? ValidateRequest(CreateExpenseRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return "Title is required.";
            }

            if (request.Amount <= 0)
            {
                return "Amount must be greater than zero.";
            }

            return null;
        }

        public sealed class ExpenseRecord
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Category { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
        }

        public sealed class CreateExpenseRequest
        {
            public string Title { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Category { get; set; } = string.Empty;
        }
    }
}
