using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
    [Required]
    [MaxLength(50)]
    public string ConfirmPassword { get; set; }
}