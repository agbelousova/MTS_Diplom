using RestSharp;
using TestRailComplexApi.Models;

namespace MTS_Diplom.Services;

public interface IMilestoneService
{
    Task<Milestone> AddMilestone(Milestone milestone, string project_id);
    Task<RestResponse> GetMilestone(string milestone_id);
}