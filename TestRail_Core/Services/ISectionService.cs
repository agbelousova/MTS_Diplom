using MTS_Diplom.Models;
using RestSharp;

namespace MTS_Diplom.Services;

public interface ISectionService
{
    Task<RestResponse> GetSection(string sectionId);
}