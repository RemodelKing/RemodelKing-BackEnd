﻿namespace backend.Register.Domain.Models;

public class Portfolio
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public long ContractDate { get; set; }
    
    public string Email { get; set; }
    
    public long Phone { get; set; }
    
    public IList<Activity> Activity { get; set; } = new List<Activity>();
}