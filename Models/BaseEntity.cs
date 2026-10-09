using System.ComponentModel.DataAnnotations;

namespace SpendSync.Models;

/// <summary>
/// Abstract base entity providing primary key identity and audit timestamps
/// for domain models before database persistence setup.
/// </summary>
public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
