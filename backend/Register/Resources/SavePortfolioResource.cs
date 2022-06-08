using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SavePortfolioResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public string Emai { get; set; }
    
    [Required]
    public long Phone { get; set; }
}