using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
#pragma warning disable 618
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
#pragma warning restore 618

namespace SeleniumWD.Pages
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        public IWebElement[] Items => _driver.FindElements(By.CssSelector(".catalog_item")).ToArray();

        public IWebElement[] ItemTitles => _driver.FindElements(By.CssSelector(".catalog_item .title a")).ToArray();

        public IWebElement[] Properties => _driver.FindElements(By.ClassName("properties_block")).ToArray();

        public IWebElement BuyButton => _driver.FindElement(By.ClassName("buy_button"));

        public IWebElement OrderButton => _wait.Until(ElementExists(By.LinkText("Оформить заказ")));
    }
}
