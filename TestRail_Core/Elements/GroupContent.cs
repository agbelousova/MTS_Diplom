using OpenQA.Selenium;

namespace MTS_Diplom.Elements;

public class GroupContent
{
    private UIElement _uiElement;
    private List<UIElement> _uiElements;
    private List<string> _texts;
    private string _id;

    public GroupContent(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
        _uiElements = new List<UIElement>();
        _texts = new List<string>();
        
        foreach (var webElement in _uiElement.FindUIElements(By.XPath("//span[contains(@id,'sectionName-') and @class='title']")))
        {
            _uiElements.Add(webElement);
            _texts.Add(webElement.Text.Trim());
        }
    }
    public List<string> GetText()
    {
            return _texts;
    }
    
    public string GetId(string name)
    {
        foreach (var element in _uiElements)
        {
            if (element.Text.Trim() ==name)
                return element.GetAttribute("id");
        }
        return _id;
    }
}