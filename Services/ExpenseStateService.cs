using SpendSync.Models;

namespace SpendSync.Services;

/// <summary>
/// In-memory state service to manage expenses and subscriptions across pages.
/// Implements state change notification so Blazor components automatically update.
/// </summary>
public class ExpenseStateService
{
    private readonly List<Expense> _expenses = [];
    private readonly List<Subscription> _subscriptions = [];

    /// <summary>
    /// Event triggered when state changes.
    /// </summary>
    public event Action? OnChange;

    public ExpenseStateService()
    {
        SeedSampleData();
    }

    #region Expenses Management

    public IReadOnlyList<Expense> Expenses => _expenses.OrderByDescending(e => e.Date).ToList().AsReadOnly();

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
        NotifyStateChanged();
    }

    public void UpdateExpense(Expense updatedExpense)
    {
        var index = _expenses.FindIndex(e => e.Id == updatedExpense.Id);
        if (index != -1)
        {
            _expenses[index] = updatedExpense;
            NotifyStateChanged();
        }
    }

    public void DeleteExpense(Guid id)
    {
        var removed = _expenses.RemoveAll(e => e.Id == id) > 0;
        if (removed)
        {
            NotifyStateChanged();
        }
    }

    #endregion

    #region Subscriptions Management

    public IReadOnlyList<Subscription> Subscriptions => _subscriptions.OrderBy(s => s.NextBillingDate).ToList().AsReadOnly();

    public void AddSubscription(Subscription subscription)
    {
        _subscriptions.Add(subscription);
        NotifyStateChanged();
    }

    public void UpdateSubscription(Subscription updatedSubscription)
    {
        var index = _subscriptions.FindIndex(s => s.Id == updatedSubscription.Id);
        if (index != -1)
        {
            _subscriptions[index] = updatedSubscription;
            NotifyStateChanged();
        }
    }

    public void DeleteSubscription(Guid id)
    {
        var removed = _subscriptions.RemoveAll(s => s.Id == id) > 0;
        if (removed)
        {
            NotifyStateChanged();
        }
    }

    #endregion

    #region Dashboard Financial Insights & Aggregations (in ₱ PHP)

    /// <summary>
    /// Total amount spent in the current calendar month.
    /// </summary>
    public decimal ThisMonthExpensesTotal => _expenses
        .Where(e => e.Date.Month == DateTime.Today.Month && e.Date.Year == DateTime.Today.Year)
        .Sum(e => e.Amount);

    /// <summary>
    /// Total normalized monthly cost for all active subscriptions.
    /// </summary>
    public decimal MonthlySubscriptionsTotal => _subscriptions
        .Where(s => s.IsActive)
        .Sum(s => s.MonthlyCost);

    /// <summary>
    /// Estimated total spend for the current month (Expenses + Subscriptions).
    /// </summary>
    public decimal TotalEstimatedMonthlySpend => ThisMonthExpensesTotal + MonthlySubscriptionsTotal;

    /// <summary>
    /// Returns the N most recent expenses.
    /// </summary>
    public IEnumerable<Expense> GetRecentExpenses(int count = 5) =>
        _expenses.OrderByDescending(e => e.Date).Take(count);

    /// <summary>
    /// Returns subscriptions due in the next given number of days.
    /// </summary>
    public IEnumerable<Subscription> GetUpcomingRenewals(int daysAhead = 14)
    {
        var limitDate = DateTime.Today.AddDays(daysAhead);
        return _subscriptions
            .Where(s => s.IsActive && s.NextBillingDate >= DateTime.Today && s.NextBillingDate <= limitDate)
            .OrderBy(s => s.NextBillingDate);
    }

    #endregion

    private void NotifyStateChanged() => OnChange?.Invoke();

    /// <summary>
    /// Pre-seeds authentic Philippine expense and subscription demo records.
    /// </summary>
    private void SeedSampleData()
    {
        _expenses.AddRange([
            new Expense
            {
                Title = "Jollibee 2-pc Chickenjoy w/ Drink",
                Amount = 215.00m,
                Category = "Food & Dining",
                Date = DateTime.Today,
                PaymentMethod = "GCash",
                Notes = "Lunch with office colleagues"
            },
            new Expense
            {
                Title = "GrabCar (Makati to BGC)",
                Amount = 285.50m,
                Category = "Transportation",
                Date = DateTime.Today.AddDays(-1),
                PaymentMethod = "Credit Card",
                Notes = "Rush hour fare"
            },
            new Expense
            {
                Title = "Meralco Electricity Bill",
                Amount = 3850.75m,
                Category = "Utilities & Bills",
                Date = DateTime.Today.AddDays(-3),
                PaymentMethod = "Maya",
                Notes = "Monthly power consumption"
            },
            new Expense
            {
                Title = "Puregold Weekly Groceries",
                Amount = 2450.00m,
                Category = "Groceries",
                Date = DateTime.Today.AddDays(-5),
                PaymentMethod = "Debit Card",
                Notes = "Pantry essentials & fresh produce"
            },
            new Expense
            {
                Title = "Mercury Drug Vitamins & Meds",
                Amount = 640.00m,
                Category = "Health & Medical",
                Date = DateTime.Today.AddDays(-6),
                PaymentMethod = "Cash",
                Notes = "Vitamin C and maintenance"
            }
        ]);

        _subscriptions.AddRange([
            new Subscription
            {
                Name = "Netflix Standard Plan",
                Amount = 459.00m,
                BillingCycle = "Monthly",
                Category = "Entertainment (Streaming)",
                NextBillingDate = DateTime.Today.AddDays(4),
                PaymentMethod = "GCash",
                IsActive = true
            },
            new Subscription
            {
                Name = "PLDT Home Fibr 200Mbps",
                Amount = 1699.00m,
                BillingCycle = "Monthly",
                Category = "Internet & Utilities",
                NextBillingDate = DateTime.Today.AddDays(10),
                PaymentMethod = "Bank Auto-Debit",
                IsActive = true
            },
            new Subscription
            {
                Name = "Spotify Premium Duo",
                Amount = 199.00m,
                BillingCycle = "Monthly",
                Category = "Entertainment (Streaming)",
                NextBillingDate = DateTime.Today.AddDays(12),
                PaymentMethod = "Maya",
                IsActive = true
            },
            new Subscription
            {
                Name = "Canva Pro (Annual)",
                Amount = 2490.00m,
                BillingCycle = "Yearly",
                Category = "Software & Tools",
                NextBillingDate = DateTime.Today.AddDays(45),
                PaymentMethod = "Credit Card",
                IsActive = true
            }
        ]);
    }
}
