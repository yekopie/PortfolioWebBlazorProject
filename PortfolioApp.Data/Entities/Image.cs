using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Data.Entities;

public class Image
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(200)]
    public string Path { get; set; } = default!;
    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;
    public List<Project> Projects { get; set; } = new List<Project>();
    public List<Profile> Profiles { get; set; } = new List<Profile>();
    public List<Testimonial> Testimonials { get; set; } = new List<Testimonial>();


}