using OpenQA.Selenium;

namespace SeleniumWD.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ProductTitle => _driver.FindElement(By.CssSelector(".info h1"));
    }
}