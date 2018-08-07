using OpenQA.Selenium;

namespace SeleniumWD.Pages
{
    public class ToolsQaPage
    {
        private readonly IWebDriver _driver;

        public ToolsQaPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Frame1 => _driver.FindElement(By.Name("iframe1"));

        public IWebElement Frame2 => _driver.FindElement(By.ClassName("iframe2"));

        public IWebElement MenuItem => _driver.FindElement(By.LinkText("DEMO SITES"));

        public IWebElement SubMenuItem => _driver.FindElement(By.LinkText("IFrame practice page"));

        public IWebElement AlertButton => _driver.FindElement(By.CssSelector("button[onclick='promptConfirm()']"));
    }
}