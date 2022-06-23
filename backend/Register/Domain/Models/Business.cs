using System.Text.Json.Serialization;

namespace backend.Register.Domain.Models;

public class Business
{
    public string? _description = String.Empty;
    public string? _img = String.Empty;
    public string? _webSite = String.Empty;
    public string? _days = String.Empty;
    public string Name { get; set; } = String.Empty;
    public long Phone { get; set; }

    public String Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    public String Img
    {
        get { return _img;}
        set { _img = value; }
    }
    public String Address { get; set; } = String.Empty;
    public float Score { get; set; }

    public String WebSite
    {
        get
        {
            return _webSite;
        }
        set
        {
            _webSite = value;
        }
    }

    public String Days
    {
        get
        {
            return _days;
        }
        set
        {
            _days = value;
        }
    }
    
    //Security
    public long Id { get; set; }
    public string Email { get; set; } = String.Empty;
    [JsonIgnore] 
    public string PasswordHash { get; set; }

    //Relationship
    //public IList<Client> Client { get; set; } = new List<Client>();
    public IList<BusinessProject> BusinessProjects { get; set; } = new List<BusinessProject>();
    public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    
    
}