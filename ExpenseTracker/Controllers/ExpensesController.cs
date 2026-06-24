using ExpenseTracker.Models;
using ExpenseTracker.Services;
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
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        /// <summary>
        /// Gets all expenses.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetAll()
        {
            var expenses = await _expenseService.GetAllAsync();
            return Ok(expenses);
        }

        /// <summary>
        /// Gets a single expense by id.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Expense>> GetById(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create([FromBody] CreateExpenseRequest request)
        {
            var validationError = ValidateRequest(request);
            if (validationError is not null)
            {
                return BadRequest(new { error = validationError });
            }

            var expense = new Expense
            {
                Title = request.Title.Trim(),
                Amount = request.Amount,
                Category = request.Category.Trim()
            };

            var createdExpense = await _expenseService.CreateAsync(expense);
            return CreatedAtAction(nameof(GetById), new { id = createdExpense.Id }, createdExpense);
        }

        /// <summary>
        /// Deletes an expense by id.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _expenseService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { error = "Expense not found." });
            }

            return NoContent();
        }

        /// <summary>
        /// Gets a summary of all expenses.
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<object>> GetSummary()
        {
            var summary = await _expenseService.GetSummaryAsync();
            return Ok(summary);
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
    }
}
