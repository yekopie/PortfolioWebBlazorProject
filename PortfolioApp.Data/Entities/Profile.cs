using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApp.Data.Entities;

public class Profile
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required, MaxLength(100)]
    public string Title { get; set; } = default!;
    [EmailAddress, MaxLength(100)]
    public string? Email { get; set; } = default!;
    [Required, MaxLength(1000)]
    public string About { get; set; } = default!;
    [Phone, MaxLength(30)]
    public string? Phone { get; set; }

    [Required, MaxLength(1000)]
    public string Summary { get; set; } = default!;

    [MaxLength(250)]
    public string Address { get; set; } = default!;

    [MaxLength(100)]
    public string Profession { get; set; } = default!;

    [MaxLength(50)]
    public string FreelanceStatus { get; set; } = default!;
    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }
    [MaxLength(250)]
    public string? ImageUrl { get; set; }

    // Navigation
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
    public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    public ICollection<Education> Educations { get; set; } = new List<Education>();
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}