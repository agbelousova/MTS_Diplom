using MTS_Diplom.Elements;
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
        SectionBasePage.NameSection.SendKeys(_section.Name);
        SectionBasePage.DescriptionSection.SendKeys(_section.Description);
        
        //загрузка файла
        //SectionBasePage.AddFile();
        
        SectionBasePage.AddNewSectionButton.Click();
        
        return new SectionBasePage(Driver);
    }

    [AllureStep]
    public string AddFaildSection(Section _section)
    {
        SectionBasePage = new SectionBasePage(Driver, true);
        
        SectionBasePage.AddSectionButton.Click();
        SectionBasePage.DescriptionSection.SendKeys(_section.Description);
       // Thread.Sleep(3000);
        SectionBasePage.AddNewSectionButton.Click();
       // Thread.Sleep(3000);
        return SectionBasePage.GetErrorLabelText();
    }
    
    [AllureStep]
    public string PopUpMessage()
    {
        SectionBasePage = new SectionBasePage(Driver, true);
        return SectionBasePage.PopUpMessage.GetAttribute("tooltip-text");
    }
}