namespace backend.Register.Domain.Models;

public class Business: User
{
    public string Name { get; set; }
    public long Phone { get; set; }
    
    //Relationship
    public IList<Client> Client { get; set; } = new List<Client>();
    public IList<BusinessProject> BusinessProjects { get; set; } = new List<BusinessProject>();
    
}