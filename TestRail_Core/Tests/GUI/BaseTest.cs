using MTS_Diplom.Core;
using MTS_Diplom.Helpers.Configurator;
using MTS_Diplom.Models;
using MTS_Diplom.Pages.SectionPages;
using MTS_Diplom.Steps;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace MTS_Diplom.Tests;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }

    protected NavigationSteps _navigationSteps;
    //protected ProjectSteps _projectSteps;
    protected SectionSteps _sectionSteps;
    protected SectionBasePage _sectionBasePage;

    protected User? Admin { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
       // _projectSteps = new ProjectSteps(Driver);
        _sectionSteps = new SectionSteps(Driver);
        _sectionBasePage = new SectionBasePage(Driver);

        Admin = Configurator.Admin;
        
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        /*
        // Проверка, был ли тест сброшен
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Создание скриншота
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Прикрепление скриншота к отчету Allure
                AllureLifecycle.Instance.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        */
        Driver.Quit();
    }
}