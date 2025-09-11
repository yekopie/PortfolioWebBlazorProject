using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class SocialMedia
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Link { get; set; } = default!;
    [Required, MaxLength(50)]
    public string Icon { get; set; } = default!;
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; } = 1;
    public Profile Profile { get; set; } = default!;
}
