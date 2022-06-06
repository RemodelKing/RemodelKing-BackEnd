namespace backend.Register.Resources;

public class UserResource
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}