using System.Text.Json.Serialization;

namespace backend.Register.Domain.Models;

public class Client
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
    //[JsonIgnore] 
    //public string PasswordHash { get; set; }

    
}