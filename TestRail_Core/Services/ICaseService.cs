using System.Net;
using MTS_Diplom.Models;
using RestSharp;

namespace MTS_Diplom.Services;

public interface ICaseService
{
    Task<Case> AddCase(string sectionId, Case newCase);
    Task<RestResponse> GetCase(string caseId);
    HttpStatusCode DeleteCase(string caseId);
}