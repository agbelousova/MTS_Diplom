using System.Net;
using RestSharp;
using MTS_Diplom.Clients;
using MTS_Diplom.Models;
using NUnit.Allure.Attributes;

namespace MTS_Diplom.Services;
public class SectionService : ISectionService, IDisposable
{
    private readonly RestClientExtended _client;

    public SectionService(RestClientExtended client)
    {
        _client = client;
    }
    
    [AllureStep("Get Section By Id")]
    public Task<RestResponse> GetSection(string sectionId)
    {
        var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
            .AddUrlSegment("section_id", sectionId);
        
        return _client.ExecuteAsync(request);
    }
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}