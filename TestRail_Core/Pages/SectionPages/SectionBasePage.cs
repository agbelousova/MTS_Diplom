using MTS_Diplom.Elements;
using MTS_Diplom.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MTS_Diplom.Pages.SectionPages;

public class SectionBasePage : BasePage
{
    private static string END_POINT = "index.php?/suites/view/1";

    //описание элементов
    private static readonly By AddSectionButtonBy = By.Id("addSection");
    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By NameSectionBy = By.Id("editSectionName");
    private static readonly By DescriptionSectionBy = By.Id("editSectionDescription_display");
    private static readonly By AddNewSectionButtonBy = By.Id("editSectionSubmit");
    private static readonly By SectionNewTitleBy = By.XPath("//span[contains(@id,'sectionName-') and @class='title']");
    private static readonly By AddFileIconBy = By.Id("entityAttachmentListEmptyIcon");
    private static readonly By AddNewFileButtonBy = By.Id("libraryAddAttachment");
    private static readonly By DeleteFileButtonBy = By.Id("libraryDeleteAttachment");
    private static readonly By AttachFileButtonBy = By.Id("attachmentNewSubmit");
    private static readonly By SelectUploadFileBy = By.CssSelector("[class='attachment-selection']");
    private static readonly By PopUpMessageBy = By.Id("printPopupLink");
    private static readonly By DeleteSectionButtonBy = By.ClassName("icon-small-delete");
    private static readonly By DeleteCheckboxBy = By.CssSelector("[data-testid='caseFieldsTabDeleteDialogCheckbox']");
    private static readonly By ErrorMessageBy = By.Id("editSectionErrors");
    public SectionBasePage(IWebDriver driver) : base(driver)
    {
    }
    public SectionBasePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint() => END_POINT;
    public override bool IsPageOpened() => TitleLabel.Text.Trim().Equals("Test Cases");

    public UIElement TitleLabel => new(Driver, TitleLabelBy);
    public Button AddSectionButton => new(Driver, AddSectionButtonBy);
    public UIElement NameSection => new(Driver, NameSectionBy);
    public UIElement DescriptionSection => new(Driver, DescriptionSectionBy);
    public Button AddNewSectionButton => new(Driver, AddNewSectionButtonBy);
    public GroupContent SectionNewTitle => new(Driver, SectionNewTitleBy);
    public UIElement AddFileIcon => new(Driver, AddFileIconBy);
    public Button AddNewFileButton => new(Driver, AddNewFileButtonBy);
    public Button DeleteFileButton => new(Driver, DeleteFileButtonBy);
    public Button AttachFileButton => new(Driver, AttachFileButtonBy);
    public UIElement SelectUploadFile => new(Driver, SelectUploadFileBy);
    public Button DeleteSectionButton => new(Driver, DeleteSectionButtonBy);
    public UIElement DeleteCheckbox => new(Driver, DeleteCheckboxBy);
    public UIElement ErrorMessage => new(Driver, ErrorMessageBy);
    public string GetErrorLabelText() => WaitsHelper.WaitForVisibilityLocatedBy(ErrorMessageBy).Text.Trim();
    
    public UIElement PopUpMessage => new(Driver, PopUpMessageBy);
    //методы
    public bool FindNewSection(string nameSection)
    {
        bool flag = false;
        foreach (var text in SectionNewTitle.GetText())
        {
            if (text == nameSection)
            {
                flag = true;
                Console.WriteLine(text);
            }
        }

        return flag;
    }
    
    public string FindNameSection(Section section)
    {
        foreach (var name in SectionNewTitle.GetText())
        {
            if (name.Length == section.Name.Length)
            {
                return name;
            }
        }
        return "error";
    }
    public void DeleteSection(string name)
    {
        var actions = new Actions(Driver);
//MoveToElement(WaitsHelper.FluentWaitForElement(By.XPath($"//span[@class = 'title' and contains(text(),'{name}')]/parent::div[@class='grid-title']")))
        actions
            .MoveToElement(WaitsHelper.FluentWaitForElement(By.CssSelector("[class^='grid-title']")))
            .Click(WaitsHelper.WaitForVisibilityLocatedBy(By.CssSelector("[class^='icon-small-delete']")))
            .Build()
            .Perform();
        
        DeleteCheckbox.Click();
        WaitsHelper.WaitForVisibilityLocatedBy(By.CssSelector("[data-testid='caseFieldsTabDeleteDialogButtonOk']")).Click();
    }
    
    /*
    public void AddFile()
    {
        try
        {
            AddFileIcon.Click();
            var fileUploadPath = WaitsHelper.WaitForExists(By.XPath("//input[@id='import']"));
            Thread.Sleep(3000);
            //AddNewFileButton.Click();

            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyPath, "Resources", "test.jpeg");

            fileUploadPath.SendKeys(filePath);
            Thread.Sleep(3000);
            //SelectUploadFile.Click();
            //WaitsHelper.WaitForExists(By.Id("attachmentNewSubmit")).Submit();

            // Assert.That(Driver.FindElement(DeleteFileButtonBy).Displayed);

            AttachFileButton.Click();
        }
        catch (Exception e)
        {
            Console.WriteLine("Файл не загружен!!!");
            throw;
        }
    }
    */
}