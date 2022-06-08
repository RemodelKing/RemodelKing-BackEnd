using backend.Register.Domain.Models;

namespace backend.Register.Resources;

public class BusinessProjectResource
{
    public string Style { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Img { get; set; }
    public int Score { get; set; }
    public int BusinessId { get; set; }
}