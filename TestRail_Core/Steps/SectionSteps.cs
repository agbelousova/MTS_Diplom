using MTS_Diplom.Models;
using MTS_Diplom.Pages.SectionPages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace MTS_Diplom.Steps;

public class SectionSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep]
    public SectionBasePage AddSection(Section _section)
    {
        SectionBasePage = new SectionBasePage(Driver, true);

        //создание новой секции для тестов
        SectionBasePage.AddSectionButton.Click();
        //загрузка файла
        SectionBasePage.AddFile();
        Thread.Sleep(1000);
        SectionBasePage.DescriptionSection.SendKeys(_section.Description);
        SectionBasePage.NameSection.SendKeys(_section.Name);
        SectionBasePage.AddNewSectionButton.Click();
        Thread.Sleep(500);
        return new SectionBasePage(Driver);
    }

    [AllureStep]
    public string AddFaildSection(Section _section)
    {
        SectionBasePage = new SectionBasePage(Driver, true);

        SectionBasePage.AddSectionButton.Click();
        SectionBasePage.DescriptionSection.SendKeys(_section.Description);
        SectionBasePage.AddNewSectionButton.Click();
        return SectionBasePage.GetErrorLabelText();
    }

    [AllureStep]
    public string PopUpMessage()
    {
        SectionBasePage = new SectionBasePage(Driver, true);
        return SectionBasePage.PopUpMessage.GetAttribute("tooltip-text");
    }
}