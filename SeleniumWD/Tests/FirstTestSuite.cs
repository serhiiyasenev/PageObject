using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWD.Core;
using SeleniumWD.Steps;
using System;
using System.Linq;
#pragma warning disable 618
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
#pragma warning restore 618

namespace SeleniumWD.Tests
{
    [TestFixture]
    public class FirstTestSuite
    {
        private IWebDriver _driver;
        private const string Url = "https://f.ua/";

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = SeleniumDriver.Driver;
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void BuyLaptop()
        {
            _driver.Url = Url;

            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.Search("Ноутбук");
            resultPage.BuyItem("Ноутбук HP 15-bs006ur");

            Assert.AreEqual(_driver.Title, "Оформление заказа", "Incorrect page");
        }

        [Test]
        public void Alerts()
        {
            _driver.Url = "http://toolsqa.com/handling-alerts-using-selenium-webdriver/";
            var page = new ToolsQaStepscs(_driver);
            page.ClickAlertButton();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var alert = wait.Until(AlertIsPresent());
            alert.SendKeys("Test Text");
            alert.Accept();
        }

        [Test]
        public void Frame()
        {
            _driver.Url = "http://toolsqa.com/iframe-practice-page/";
            var page = new ToolsQaStepscs(_driver);
            _driver.SwitchTo().Frame(_driver.FindElement(By.Name("iframe1")));
            var message = _driver.FindElement(By.CssSelector(".vc_message_box ")).Text;
            _driver.SwitchTo().DefaultContent();
            _driver.SwitchTo().Frame(_driver.FindElement(By.Name("iframe2")));
            var isDisplayed = _driver.FindElement(By.CssSelector(".site-anchor")).Enabled;
        }

        [Test]
        public void Navigate()
        {
            _driver.Url = Url;
            var homePage = new HomePageSteps(_driver);
            var handle = _driver.CurrentWindowHandle;
            homePage.NavigateToSenseproduction();
            var handleList = _driver.WindowHandles;
            _driver.SwitchTo().Window(handleList.Last());
            var title = _driver.Title;
            _driver.Close();
            _driver.SwitchTo().Window(handle);
            var title2 = _driver.Title;
        }

        [Test]
        public void Test()
        {
            _driver.Url = Url;

            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.Search("Ноутбук");

            resultPage.SelectFilterItem("Класс", "игровой");

            //need to add verification
        }

        [Test]
        public void VerifyItemsInResultTest()
        {
            _driver.Url = Url;

            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);

            homePage.Search("Ноутбук");

            var resultList = resultPage.GetResultItemTitle();
            Assert.IsTrue(resultList.All(i => i.Contains("Ноутбук") || i.Equals(string.Empty)));
        }

        [Test]
        public void OpenItemTest()
        {
            _driver.Url = Url;

            var homePage = new HomePageSteps(_driver);
            var resultPage = new SearchResultPageSteps(_driver);
            var productPage = new ProductPageSteps(_driver);

            homePage.Search("Ноутбук");

            resultPage.OpenItem("Ноутбук LENOVO ThinkPad T470p");

            var productTitle = productPage.GetTitle();
            Assert.IsTrue(productTitle.Contains("Ноутбук Lenovo ThinkPad T470p"));
            Assert.IsTrue(resultPage.GetTitle().Contains("Lenovo ThinkPad T470p"));
        }

        [Test]
        public void PageTitleTest()
        {
            _driver.Url = Url;

            var homePage = new HomePageSteps(_driver);

            homePage.Search("Телефоны");

            Assert.IsTrue(_driver.Title.Contains("Телефоны".ToUpper()));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}