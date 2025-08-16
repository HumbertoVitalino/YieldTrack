using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Repositories.Models;

public abstract class Model
{
    [Key]
    public Guid Id { get; private set; }

    [Required]
    public DateTime CreatedAt { get; private set; }

    [Required]
    public DateTime UpdatedAt { get; private set; }

    protected Model() { }

    public Model(
        Guid id,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
