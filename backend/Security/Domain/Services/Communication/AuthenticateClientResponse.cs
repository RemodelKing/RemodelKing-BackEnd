namespace backend.Security.Domain.Services.Communication;

public class AuthenticateClientResponse
{
    public long Id { get; set; }
    /*public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }*/
    public string Email { get; set; }
    public string Name { get; set; }
    public long Phone { get; set; }
    public string Token { get; set; }
}