using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Project
{
    [Key]
    public int Id { get; set; }
    public string? ProjectLink { get; set; }
    [MaxLength(200)]
    public string Name { get; set; } = default!;
    [MaxLength(500)]
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public DateOnly? PublishDate { get; set; }
    [ForeignKey(nameof(Image))]
    public int ImageId { get; set; }
    public Image Image { get; set; } = default!;
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; } = 1;
    public Profile Profile { get; set; } = default!;
}
