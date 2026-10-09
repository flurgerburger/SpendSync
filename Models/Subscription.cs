using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendSync.Models;

/// <summary>
/// Represents a recurring subscription service.
/// </summary>
public class Subscription : BaseEntity
{
    [Required(ErrorMessage = "Please enter the subscription name.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the recurring amount.")]
    [Range(0.01, 1_000_000, ErrorMessage = "Amount must be greater than ₱0.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select a billing cycle.")]
    [StringLength(50, ErrorMessage = "Billing cycle cannot exceed 50 characters.")]
    public string BillingCycle { get; set; } = "Monthly";

    [Required(ErrorMessage = "Please select a category.")]
    [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
    public string Category { get; set; } = "Entertainment";

    public DateTime NextBillingDate { get; set; } = DateTime.Today.AddMonths(1);

    [Required(ErrorMessage = "Please select a payment method.")]
    [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
    public string PaymentMethod { get; set; } = "GCash";

    public bool IsActive { get; set; } = true;

    [StringLength(250, ErrorMessage = "Notes cannot exceed 250 characters.")]
    public string? Notes { get; set; }

    /// <summary>
    /// Computes the normalized monthly equivalent cost in ₱ PHP.
    /// Excluded from database mapping via [NotMapped].
    /// </summary>
    [NotMapped]
    public decimal MonthlyCost => BillingCycle switch
    {
        "Yearly" => Math.Round(Amount / 12m, 2),
        "Quarterly" => Math.Round(Amount / 3m, 2),
        "Weekly" => Math.Round(Amount * 4.33m, 2),
        _ => Amount
    };

    public static readonly List<string> BillingCycles =
    [
        "Monthly",
        "Quarterly",
        "Yearly",
        "Weekly"
    ];

    public static readonly List<string> Categories =
    [
        "Entertainment (Streaming)",
        "Internet & Utilities",
        "Software & Tools",
        "Fitness & Health",
        "Gaming",
        "Other"
    ];

    public static readonly List<string> PaymentMethods =
    [
        "GCash",
        "Maya",
        "Credit Card",
        "Debit Card",
        "Bank Auto-Debit"
    ];
}
