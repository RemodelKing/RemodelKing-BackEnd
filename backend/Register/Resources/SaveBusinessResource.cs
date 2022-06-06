using System.ComponentModel.DataAnnotations;

namespace backend.Register.Resources;

public class SaveBusinessResource: SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public long Phone { get; set; }
}