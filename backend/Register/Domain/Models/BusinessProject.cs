namespace backend.Register.Domain.Models;

public class BusinessProject
{
    public int Id { get; set; }
    public string Style { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Img { get; set; }
    public int Score { get; set; }
    public int BusinessId { get; set; }
    
    public Business Business { get; set; }
}