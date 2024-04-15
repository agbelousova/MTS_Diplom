using OpenQA.Selenium;

namespace MTS_Diplom.Elements;

public class DropDownMenu
{
    private UIElement _uiElement;
    private List<UIElement> _uiElements;
    private List<string> _texts;

    public DropDownMenu(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
        _uiElements = new List<UIElement>();
        _texts = new List<string>();

        _uiElement.Click();
        foreach (var webElement in _uiElement.FindUIElements(By.XPath("descendant::li")))
        {
            _uiElements.Add(webElement);
            _texts.Add(webElement.Text.Trim());
        }
        _uiElement.Click();
    }

    public void SelectText(string text)
    {
        _uiElement.Click();
        try
        {
            _uiElements[_texts.IndexOf(text)].Click();
        }
        catch (Exception e)
        {
            throw new AssertionException("Элемент не найден");
        }
    }

    public void SelectIndex(int index)
    {
        _uiElement.Click();
        try
        {
            _uiElements[index].Click();
        }
        catch (Exception e)
        {
            throw new AssertionException("Элемент не найден");
        }
    }

    public bool Displayed => _uiElement.Displayed;

    public string SelectedOption => _uiElement.FindUIElement(By.XPath("//*[contains(@class,'result-selected')]")).Text.Trim();
}