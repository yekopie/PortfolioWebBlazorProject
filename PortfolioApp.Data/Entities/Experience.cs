using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Experience
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string JobTitle { get; set; } = default!;
    [Required, MaxLength(50)]
    public string CompanyAdress { get; set; } = default!;
    [Required, MaxLength(100)]
    public string Company { get; set; } = default!;
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
