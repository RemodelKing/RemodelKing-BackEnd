using System.ComponentModel.DataAnnotations;

namespace backend.Security.Domain.Services.Communication;

public class AuthenticateClientRequest
{
    /*[Required]
    public string Username { get; set; }*/
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}