using System.ComponentModel.DataAnnotations;

namespace SpendSync.Models;

public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Please enter the subscription name.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the recurring amount.")]
    [Range(0.01, 1_000_000, ErrorMessage = "Amount must be greater than ₱0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select a billing cycle.")]
    public string BillingCycle { get; set; } = "Monthly";

    [Required(ErrorMessage = "Please select a category.")]
    public string Category { get; set; } = "Entertainment";

    public DateTime NextBillingDate { get; set; } = DateTime.Today.AddMonths(1);

    [Required(ErrorMessage = "Please select a payment method.")]
    public string PaymentMethod { get; set; } = "GCash";

    public bool IsActive { get; set; } = true;

    [StringLength(250, ErrorMessage = "Notes cannot exceed 250 characters.")]
    public string? Notes { get; set; }

    /// <summary>
    /// Computes the normalized monthly equivalent cost in ₱ PHP.
    /// </summary>
    public decimal MonthlyCost => BillingCycle switch
    {
        "Yearly" => Math.Round(Amount / 12m, 2),
        "Quarterly" => Math.Round(Amount / 3m, 2),
        "Weekly" => Math.Round(Amount * 4.33m, 2),
        _ => Amount // Default is Monthly
    };

    // Predefined options for UI dropdowns
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
