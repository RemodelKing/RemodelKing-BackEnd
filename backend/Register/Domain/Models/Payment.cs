﻿namespace backend.RemodelKing.Domain.Models;

public class Payment
{
    public long Id { get; set; }
    public long CreditCard { get; set; }
    public string ExpiryDate { get; set; }
    public string CardHolder { get; set; }
    public string CardIssuer { get; set; }
    public string CVV { get; set; }
}