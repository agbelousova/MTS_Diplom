using MTS_Diplom.Clients;
using MTS_Diplom.Services;
using NLog;
using NUnit.Allure.Core;

namespace MTS_Diplom.Tests.API;

[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected SectionService? SectionService;
    
    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        SectionService = new SectionService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        SectionService?.Dispose();
    }
}