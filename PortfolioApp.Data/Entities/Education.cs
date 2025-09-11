using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Education
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Degree { get; set; } = default!;
    [Required, MaxLength(100)]
    public string Field { get; set; } = default!;
    [Required, MaxLength(150)]
    public string School { get; set; } = default!;
    [Required, DataType(DataType.Date)]
    public DateOnly StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? EndDate { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; } = 1;
    public Profile Profile { get; set; } = default!;
}