using System.Text.Json.Serialization;

namespace backend.Security.Domain.Models;

public class UserClient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
}