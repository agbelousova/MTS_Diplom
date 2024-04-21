using System.Diagnostics;
using System.Net;
using Allure.Net.Commons;
using MTS_Diplom.Models;
using Newtonsoft.Json;
using RestSharp;
using NLog;
using NUnit.Allure.Attributes;
using TestRailComplexApi.Models;

namespace MTS_Diplom.Tests.API;

[AllureSuite("API Tests")]
public class GetTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Section _section;
    private Milestone _milestone = null;
    private Case _case = null;

    [Test]
    [Order(1)]
    [Category("NFE")]
    [AllureSubSuite("Section API Tests")]
    [AllureFeature("API GET Method")]
    [AllureFeature("API NFE Tests")]
    
    public void GetSectionTest()
    {
        AllureApi.Step("GetSectionTest запущен.");
        // Загрузка JSON из файла
        string sectionJson = File.ReadAllText(@"Resources/SectionGetPositive.json");
        _logger.Info(sectionJson);

        // Создем экземпляр объекта из JSON
        var _section = JsonConvert.DeserializeObject<Section>(sectionJson);
        _logger.Info(_section);

        var section = SectionService?.GetSection(_section.Id.ToString()).Result;
        _logger.Info(section);

        AllureApi.Step("Response processing");
        Section actualSection = JsonConvert.DeserializeObject<Section>(section.Content);

        //проверка что после десериализации файла JSON в объект, его поля равны объекту после API запроса
        Assert.Multiple(() =>
        {
            Assert.That(actualSection.Name, Is.EqualTo(_section.Name));
            Assert.That(actualSection.Id, Is.EqualTo(_section.Id));
            Assert.That(section.StatusCode == HttpStatusCode.OK);
        });
        AllureApi.Step("GetSectionTest выполнен.");
    }
    
    [Test]
    [Order(5)]
    [Category("NFE")]
    [AllureSubSuite("Section API Tests")]
    [AllureFeature("API POST Method")]
    [AllureFeature("API NFE Tests")]
    public void AddCaseTest()
    {
        _case = new Case()
        {
            Title = "This is a test case",
            PriorityId = 1
        };

        AllureApi.Step("AddCaseTest запущен.");
        
        var caseNew = CaseService!.AddCase("190", _case);

        _case = caseNew.Result;
        _logger.Info(_case.ToString());
        
        Assert.That(caseNew.Result.Title, Is.EqualTo(_case.Title));
        AllureApi.Step("AddCaseTest выполнен.");
    }
    
    [Test]
    [Order(6)]
    [Category("NFE")]
    [AllureSubSuite("Case API Tests")]
    [AllureFeature("API GET Method")]
    [AllureFeature("API NFE Tests")]
    public void GetCaseTest()
    {
        AllureApi.Step("GetCaseTest запущен.");
        var actualCase = CaseService?.GetCase(_case.Id.ToString()).Result;
        _logger.Info(actualCase.ToString);

        AllureApi.Step("Response processing");
        Case caseGet = JsonConvert.DeserializeObject<Case>(actualCase.Content);

        Assert.Multiple(() =>
        {
            Assert.That(actualCase.StatusCode == HttpStatusCode.OK);   
            Assert.That(caseGet.Title, Is.EqualTo(_case.Title));
            Assert.That(caseGet.Id, Is.EqualTo(_case.Id));
        });
        AllureApi.Step("GetCaseTest выполнен.");
    }
    
    [Test]
    [Order(7)]
    [Category("NFE")]
    [AllureSubSuite("Delete Case Tests")]
    [AllureFeature("API POST Method")]
    [AllureFeature("API NFE Tests")]
    public void DeleteCaseTest()
    {
        AllureApi.Step("DeleteCaseTest запущен.");
        Debug.Assert(CaseService != null, nameof(CaseService) + " != null");
        _logger.Info(CaseService.DeleteCase(_case.Id.ToString()));
        AllureApi.Step("DeleteCaseTest выполнен.");
    }
    
    [Test]
    [Order(4)]
    [Category("NFE")]
    [AllureSubSuite("Get Milestone Tests")]
    [AllureFeature("API GET Method")]
    [AllureFeature("API NFE Tests")]
    public void GetMilestoneTest()
    {
        _milestone = new Milestone
        {
            Name = "Release 1.5",
            Description = "",
            IdProject = 1
        };
        
        AllureApi.Step("GetMilestoneTest запущен.");
        
        var milestone = MilestoneService?.GetMilestone(_milestone.IdProject.ToString()).Result;
        _logger.Info(milestone);

        AllureApi.Step("Response processing");
        Milestone actualMilestone = JsonConvert.DeserializeObject<Milestone>(milestone.Content);
        
        _logger.Info(actualMilestone);
        
        Assert.Multiple(() =>
        {
            Assert.That(actualMilestone.Name, Is.EqualTo(_milestone.Name));
            Assert.That(milestone.StatusCode == HttpStatusCode.OK);
        });
        AllureApi.Step("GetMilestoneTest выполнен.");
    }

    [Test]
    [Order(2)]
    [Category("AFE")]
    [AllureSubSuite("Get Section Negative Tests")]
    [AllureFeature("API GET Method")]
    [AllureFeature("API AFE Tests")]
    public void GetSectionNegativeTest()
    {
        AllureApi.Step("GetSectionNegativeTest запущен.");

        var sectionGet = SectionService?.GetSection("1");
        _logger.Info(sectionGet.Result.StatusCode == HttpStatusCode.BadRequest);
        Assert.That(sectionGet.Result.StatusCode == HttpStatusCode.BadRequest);

        AllureApi.Step("GetSectionNegativeTest выполнен.");
    }
    
    [Test]
    [Order(3)]
    [Category("AFE")]
    [AllureSubSuite("Get Milestone Negative Tests")]
    [AllureFeature("API GET Method")]
    [AllureFeature("API AFE Tests")]
    public void GetMilestoneNegativeTest()
    {
        AllureApi.Step("GetMilestoneNegativeTest запущен.");

        var milestoneGet = MilestoneService?.GetMilestone("-1");
        _logger.Info(milestoneGet.Result.StatusCode== HttpStatusCode.BadRequest);
        Assert.That(milestoneGet.Result.StatusCode == HttpStatusCode.BadRequest);

        AllureApi.Step("GetMilestoneNegativeTest выполнен.");
    }
}