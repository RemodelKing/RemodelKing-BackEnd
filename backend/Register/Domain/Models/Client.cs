namespace backend.Register.Domain.Models;

public class Client : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    //Relationship
    public long BusinessId { get; set; }
    public Business Business { get; set; }
    
}