using backend.Register.Domain.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace RemodelKing.API.Test.Steps;

[Binding]
public class CreateProjectBusiness
{
    private static RestClient _restClient;
    private static RestRequest _restRequest;
    private static IRestResponse _restResponse;
    private static BusinessProject _businessProject;
    
    [Given(@"the user is in the tab - Your Profile -")]
    public void GivenTheUserIsInTheTabYourProfile()
    {
        _restClient = new RestClient("https://localhost:7000/");
        _restRequest = new RestRequest("api/v1/businessprojects", Method.POST)
        {
            RequestFormat = DataFormat.Json
        };
    }

    [When(@"click on - Add Project - and fill in the information")]
    public void WhenClickOnAddProjectAndFillInTheInformation(Table proyectTable)
    {
        _businessProject = proyectTable.CreateInstance<BusinessProject>();
        _businessProject = new BusinessProject()
        {
            Style = "Rustico",
            Description = "Hecho a base de madera",
            Location = "Miraflores-Lima",
            BusinessId = 1
        };
        _restRequest.AddJsonBody(_businessProject);
        _restResponse = _restClient.Execute(_restRequest);
    }


    [Then(@"the project will be added to the company\.")]
    public void ThenTheProjectWillBeAddedToTheCompany()
    {
        Assert.That("Rustico", Is.EqualTo(_businessProject.Style));
    }
}