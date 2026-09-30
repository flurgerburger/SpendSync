using System.ComponentModel.DataAnnotations;

namespace SpendSync.Models;

public class Expense
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Please enter an expense title.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter an amount.")]
    [Range(0.01, 10_000_000, ErrorMessage = "Amount must be greater than ₱0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select a category.")]
    public string Category { get; set; } = "Food & Dining";

    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Please select a payment method.")]
    public string PaymentMethod { get; set; } = "GCash";

    [StringLength(250, ErrorMessage = "Notes cannot exceed 250 characters.")]
    public string? Notes { get; set; }

    // Predefined Philippine-localized options for UI dropdowns
    public static readonly List<string> Categories =
    [
        "Food & Dining",
        "Transportation",
        "Utilities & Bills",
        "Groceries",
        "Shopping",
        "Entertainment",
        "Health & Medical",
        "Education",
        "Other"
    ];

    public static readonly List<string> PaymentMethods =
    [
        "GCash",
        "Maya",
        "Cash",
        "Credit Card",
        "Debit Card",
        "Bank Transfer (BDO/BPI/UnionBank)",
        "Other"
    ];
}
