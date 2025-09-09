namespace PortfolioApp.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string About { get; set; }
    public string Summary { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Profession { get; set; }
    public string FreelanceStatus { get; set; }
    public string ImageUrl { get; set; }
}
