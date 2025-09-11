using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Skill
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    [Range(0, 100)]
    public int Percentage { get; set; }
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; } = 1;
    public Profile Profile { get; set; } = default!;
}
