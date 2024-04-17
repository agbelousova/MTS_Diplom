using MTS_Diplom.Clients;
using MTS_Diplom.Services;
using NLog;
using NUnit.Allure.Core;
using TestRailComplexApi.Services;

namespace MTS_Diplom.Tests.API;

[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected SectionService? SectionService;
    protected MilestoneService? MilestoneService;
    protected CaseService? CaseService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        SectionService = new SectionService(restClient);
        MilestoneService = new MilestoneService(restClient);
        CaseService = new CaseService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        SectionService?.Dispose();
        MilestoneService?.Dispose();
        CaseService?.Dispose();
    }
}