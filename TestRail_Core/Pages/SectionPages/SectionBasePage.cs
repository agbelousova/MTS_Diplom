using System.Reflection;
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
    
    //для вставки value файла
    private static readonly By InputFileBy = By.Id("newAttachments");
    //элемент в котором хранится код вставляемого файла
    private static readonly By PuthFileBy = By.XPath("//div[@id='attachmentsNewList']//div[contains(@id,'libraryAttachment-')]");
    
    
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
    public UIElement InputFile => new(Driver, InputFileBy);
    public UIElement PuthFile => new(Driver, PuthFileBy);
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
    
   
    //метод для удаления секции по ид
    public void DeleteIdSection(Section section)
    {
        /*
       foreach (var name in SectionNewTitle.GetText())
       {
           if (name.Length == section.Name.Length)
           {
               var id = SectionNewTitle.GetId(name);

               Console.WriteLine(id);

               var actions = new Actions(Driver);
               Thread.Sleep(50000);
               actions
                   .MoveToElement(WaitsHelper.WaitForVisibleElementsLocatedBy(By.CssSelector($"#{id} > div.grid-title")))
                   .Click(WaitsHelper.WaitForExists(By.CssSelector($"#{id} > div.grid-title > a:nth-child(4) > div")))
                   .Build()
                   .Perform();
               Thread.Sleep(5000);
               DeleteCheckbox.Click();
               WaitsHelper.WaitForVisibilityLocatedBy(
                   By.CssSelector("[data-testid='caseFieldsTabDeleteDialogButtonOk']")).Click();
           }
       }
       */
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
   
   /*
   public void AddFile()
   {
     //  try
     //  {
           AddFileIcon.Click();
           var fileUploadPath = WaitsHelper.WaitForExists(By.XPath("//input[@id='import']"));
           Thread.Sleep(3000);
           //AddNewFileButton.Click();

           string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           string filePath = Path.Combine(assemblyPath, "Resources", "test.jpeg");

           fileUploadPath.SendKeys(filePath);
          // Thread.Sleep(50000);

           string puth = PuthFile.GetAttribute("id");
           Console.WriteLine($"Файл ---- {puth}");
           puth = puth.Replace("libraryAttachment-", "");
           Console.WriteLine($"Путь после удаления --{puth}");
           InputFile.SendKeys(puth);
           Console.WriteLine($"Value={InputFile.GetAttribute("value")}");
          // SelectUploadFile.Click();
           //WaitsHelper.WaitForExists(By.Id("attachmentNewSubmit")).Submit();

           Assert.That(Driver.FindElement(DeleteFileButtonBy).Displayed);

           AttachFileButton.Click();
    //   }
     /*  catch (Exception e)
       {
           Console.WriteLine("Файл не загружен!!!");
           throw;
       }

   }*/
}