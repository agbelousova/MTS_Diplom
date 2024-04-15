using OpenQA.Selenium;

namespace MTS_Diplom.Elements;

public class Checkbox
{
    private UIElement _uiElement;

    public Checkbox(IWebDriver webDriver, By by) => _uiElement = new UIElement(webDriver, by);
    public Checkbox(IWebDriver webDriver, IWebElement webElement) => _uiElement = new UIElement(webDriver, webElement);

    public bool Displayed => _uiElement.Displayed;

    public bool IsChecked() => !string.IsNullOrEmpty(_uiElement.GetAttribute("checked"));

    public void Click() => _uiElement.Click();

    public void SetState(bool state)
    {
        if (IsChecked() != state)
        {
            Click();
        }
    }
}