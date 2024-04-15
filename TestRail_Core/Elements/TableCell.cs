using OpenQA.Selenium;

namespace MTS_Diplom.Elements;

public class TableCell
{
    private UIElement _uiElement;
    
    public TableCell(UIElement uiElement)
    {
        _uiElement = uiElement;
    }

    public UIElement GetLink() => _uiElement.FindUIElement(By.TagName("a"));
    public UIElement GetOverviewLink() => _uiElement.FindUIElement(By.CssSelector("span>a"));
    public string Text => _uiElement.Text;
}