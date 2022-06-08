using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveActivityResource: UserResource
{
   
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string StartDate { get; set; }
    
    [Required]
    public string FinisDate { get; set; }
}