using OpenQA.Selenium;
using SeleniumWD.Pages;

namespace SeleniumWD.Steps
{
    public class HomePageSteps
    {
        private readonly HomePage _homePage;

        public HomePageSteps(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
        }

        public void Search(string searchText)
        {
            _homePage.SearchField.SendKeys(searchText);
            _homePage.SearchField.Submit();
        }

        public void NavigateToSenseproduction()
        {
            _homePage.SenseproductionLink.Click();
        }
    }
}