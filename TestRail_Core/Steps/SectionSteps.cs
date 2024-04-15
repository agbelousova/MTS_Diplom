using MTS_Diplom.Models;
using MTS_Diplom.Pages.SectionPages;
using OpenQA.Selenium;

namespace MTS_Diplom.Steps;

public class SectionSteps(IWebDriver driver) : BaseStep(driver)
{
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

    public string AddFaildSection(Section _section)
    {
        SectionBasePage = new SectionBasePage(Driver, true);
        
        SectionBasePage.AddSectionButton.Click();
        SectionBasePage.DescriptionSection.SendKeys(_section.Description);
        SectionBasePage.AddNewSectionButton.Click();
        
        return SectionBasePage.GetErrorLabelText();
    }
    public string PopUpMessage()
    {
        SectionBasePage = new SectionBasePage(Driver, true);
        return SectionBasePage.PopUpMessage.GetAttribute("tooltip-text");
    }
}