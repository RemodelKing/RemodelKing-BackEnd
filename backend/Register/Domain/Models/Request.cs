namespace backend.Register.Domain.Models;

public class Request
{
    public int Id { get; set; }
    public string BusinessName { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}