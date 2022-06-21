namespace backend.Register.Domain.Models;

public class Business: User
{
    public string Name { get; set; }
    public long Phone { get; set; }
    public String Description { get; set; }
    public String Img { get; set; }
    public String Address { get; set; }
    public float Score { get; set; }
    public String WebSite { get; set; }
    public String Days { get; set; }

    //Relationship
    //public IList<Client> Client { get; set; } = new List<Client>();
    public IList<BusinessProject> BusinessProjects { get; set; } = new List<BusinessProject>();
    public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
}