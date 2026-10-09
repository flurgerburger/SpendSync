using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendSync.Models;

/// <summary>
/// Represents a one-time out-of-pocket expense record.
/// </summary>
public class Expense : BaseEntity
{
    [Required(ErrorMessage = "Please enter an expense title.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter an amount.")]
    [Range(0.01, 10_000_000, ErrorMessage = "Amount must be greater than ₱0.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select a category.")]
    [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
    public string Category { get; set; } = "Food & Dining";

    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Please select a payment method.")]
    [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
    public string PaymentMethod { get; set; } = "GCash";

    [StringLength(250, ErrorMessage = "Notes cannot exceed 250 characters.")]
    public string? Notes { get; set; }

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
