using OpenQA.Selenium;
using SeleniumWD.Core;
using SeleniumWD.Pages;

namespace SeleniumWD.Steps
{
    public class ToolsQaStepscs
    {
        private readonly IWebDriver _driver;
        private readonly ToolsQaPage _toolsQaPage;

        public ToolsQaStepscs(IWebDriver driver)
        {
            _driver = driver;
            _toolsQaPage = new ToolsQaPage(_driver);
        }

        public void NavigateToFramePage()
        {
            _driver.HoverOver(_toolsQaPage.MenuItem);
            _toolsQaPage.SubMenuItem.Click();
        }

        public void ClickAlertButton()
        {
            _toolsQaPage.AlertButton.Click();
        }
    }
}