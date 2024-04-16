using System.Net;
using RestSharp;
using MTS_Diplom.Clients;
using MTS_Diplom.Models;

namespace MTS_Diplom.Services;
public class SectionService : ISectionService, IDisposable
{
    private readonly RestClientExtended _client;

    public SectionService(RestClientExtended client)
    {
        _client = client;
    }
    
    public Task<Section> GetSection(string sectionId)
    {
        var request = new RestRequest("index.php?/api/v2/get_section/{section_id}")
            .AddUrlSegment("section_id", sectionId);
        
        return _client.ExecuteAsync<Section>(request);
    }
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}