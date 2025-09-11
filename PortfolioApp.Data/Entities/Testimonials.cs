using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Testimonial
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(200)]
    public string FullName { get; set; } = default!;
    [Required, Range(1, 5)]
    public int Stars { get; set; }
    [Required, MaxLength(255)]
    public string Review { get; set; } = default!;
    [ForeignKey(nameof(Image))]
    public int ImageId { get; set; }
    public Image Image { get; set; } = default!;
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; } = 1;
    public Profile Profile { get; set; } = default!;

}
