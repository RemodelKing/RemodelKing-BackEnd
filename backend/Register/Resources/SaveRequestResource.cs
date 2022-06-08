using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveRequestResource
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string BusinessName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
}