using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveClientResource: UserResource
{
   
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
}