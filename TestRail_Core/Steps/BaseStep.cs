using MTS_Diplom.Pages;
using MTS_Diplom.Pages.SectionPages;
using OpenQA.Selenium;

namespace MTS_Diplom.Steps;

public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;

    protected LoginPage? LoginPage { get; set; }
    protected DashboardPage? DashboardPage { get; set; }
    //protected AddProjectPage? AddProjectPage { get; set; }
    protected SectionBasePage? SectionBasePage { get; set; }
}