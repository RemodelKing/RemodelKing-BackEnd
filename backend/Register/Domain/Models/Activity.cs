namespace backend.Register.Domain.Models;

public class Activity
{
    public int Id { get; set; }
    
    public string Description { get; set; }
    
    public string StartDate { get; set; }
    
    public string FinisDate { get; set; }

    public int PortfolioId { get; set; }
    
    public Portfolio Portfolio { get; set; }
}