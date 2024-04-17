using System.Net;
using MTS_Diplom.Clients;
using MTS_Diplom.Models;
using NUnit.Allure.Attributes;
using RestSharp;

namespace MTS_Diplom.Services;

public class CaseService : ICaseService, IDisposable
{
    private readonly RestClientExtended _client;
    
    public CaseService(RestClientExtended client)
    {
        _client = client;
    }
    
    [AllureStep("Add Case By Id and newCase")]
    public Task<Case> AddCase(string sectionId, Case newCase)
    {
        var request = new RestRequest("index.php?/api/v2/add_case/{section_id}", Method.Post)
            .AddUrlSegment("section_id", sectionId)
            .AddJsonBody(newCase);

        return _client.ExecuteAsync<Case>(request);
    }
    
    [AllureStep("Get Case By Id")]
    public Task<RestResponse> GetCase(string caseId)
    {
        var request = new RestRequest("index.php?/api/v2/get_case/{case_id}")
            .AddUrlSegment("case_id", caseId);
        
        return _client.ExecuteAsync(request);
    }

    [AllureStep("Delete Case By Id")]
    public HttpStatusCode DeleteCase(string caseId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_case/{case_id}", Method.Post)
            .AddUrlSegment("case_id", caseId)
            .AddJsonBody("{}");
        
        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}