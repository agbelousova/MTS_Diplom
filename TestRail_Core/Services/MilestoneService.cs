using System.Net;
using MTS_Diplom.Clients;
using MTS_Diplom.Services;
using NUnit.Allure.Attributes;
using RestSharp;
using TestRailComplexApi.Models;

namespace TestRailComplexApi.Services;

public class MilestoneService : IMilestoneService, IDisposable
{
    private readonly RestClientExtended _client;
    
    public MilestoneService(RestClientExtended client)
    {
        _client = client;
    }
    
    [AllureStep("Add Milestone By Id and Milestone")]
    public Task<Milestone> AddMilestone(Milestone milestone, string project_id)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("project_id", project_id)
            .AddJsonBody(milestone);
        
        return _client.ExecuteAsync<Milestone>(request);
    }
    
    [AllureStep("Get Milestone By Id")]
    public Task<RestResponse> GetMilestone(string milestone_id)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}")
            .AddUrlSegment("milestone_id", milestone_id);
        
        return _client.ExecuteAsync(request);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}