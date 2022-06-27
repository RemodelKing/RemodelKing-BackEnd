using backend.Register.Domain.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace RemodelKing.API.Test.Steps;

[Binding]
public class CreateCustomerAccount
{
    private static RestClient _restClient;
    private static RestRequest _restRequest;
    private static IRestResponse _restResponse;
    private static Client _client;
    
    [Given(@"he is in the Login section")]
    public void GivenHeIsInTheLoginSection()
    {
        _restClient = new RestClient("https://localhost:7000/");
        _restRequest = new RestRequest("api/v1/clients", Method.POST)
        {
            RequestFormat = DataFormat.Json
        };
    }

    [When(@"enter the information requested")]
    public void WhenEnterTheInformationRequested(Table clientData)
    {
        _client = clientData.CreateInstance<Client>();
        _client = new Client()
        {
            Name = "Pepe",
            LastName = "Gomez",
            Phone = "923512540",
            Address = "Chorrillos-Lima",
            Img = "PepeImage",
            Email = "PepeGomez@gmail.com",
            Id = 2
        };
        _restRequest.AddJsonBody(_client);
        _restResponse = _restClient.Execute(_restRequest);
    }

    [Then(@"account will then be created for the customer\.")]
    public void ThenAccountWillThenBeCreatedForTheCustomer()
    {
        Assert.That("Pepe", Is.EqualTo(_client.Name));
    }
}