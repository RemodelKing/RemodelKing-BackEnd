using backend.Register.Domain.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace RemodelKing.API.Test.Steps;

[Binding]
public class AddActivityClient
{
    private static RestClient _restClient;
    private static RestRequest _restRequest;
    private static IRestResponse _restResponse;
    private static Activity _activity;
    
    [Given(@"the user is in the “Client Portfolio"" section")]
    public void GivenTheUserIsInTheClientPortfolioSection()
    {
        _restClient = new RestClient("https://localhost:7000/");
        _restRequest = new RestRequest("api/v1/activities", Method.POST)
        {
            RequestFormat = DataFormat.Json
        };
    }

    [When(@"he fill in the activity information and click - \+ Add -")]
    public void WhenHeFillInTheActivityInformationAndClickAdd(Table activityData)
    {
        _activity = activityData.CreateInstance<Activity>();
        _activity = new Activity()
        {
            Description = "Pint the walls",
            Title = "Pint the house",
            StartDate = "Monday",
            FinishDate = "Sunday",
            PortfolioId = 1
        };
        _restRequest.AddJsonBody(_activity);
        _restResponse = _restClient.Execute(_restRequest);
    }

    [Then(@"the created activity will be added\.")]
    public void ThenTheCreatedActivityWillBeAdded()
    {
        Assert.That("Pint the house", Is.EqualTo(_activity.Title));
    }
}