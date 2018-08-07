using OpenQA.Selenium;

namespace SeleniumWD.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchField => _driver.FindElement(By.Id("head_search_input"));

        public IWebElement SenseproductionLink => _driver.FindElement(By.ClassName("senseproduction"));
    }
}