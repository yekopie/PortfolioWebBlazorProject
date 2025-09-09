namespace PortfolioApp.Data.Entities;

public class Education
{
    public int Id { get; set; }
    public string Degree {  get; set; }
    public string Field { get; set; }
    public string School { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}
