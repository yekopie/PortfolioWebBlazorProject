using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortfolioApp.Data.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = default!;

    [Required, MaxLength(200)]
    public string PasswordHash { get; set; } = default!;


    // Navigation
    [ForeignKey(nameof(Profile))]
    public int ProfileId { get; set; }  
    public Profile Profile { get; set; } = default!;
}
