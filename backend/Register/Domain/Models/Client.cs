using System.Text.Json.Serialization;

namespace backend.Register.Domain.Models;

public class Client
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
    //[JsonIgnore] 
    //public string PasswordHash { get; set; }

    public string Phone { get; set; }
    public string Address { get; set; }
    public string Img { get; set; }

    public IList<Request> Requests { get; set; } = new List<Request>();

    
}