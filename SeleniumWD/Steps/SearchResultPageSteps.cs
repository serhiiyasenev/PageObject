using OpenQA.Selenium;
using SeleniumWD.Core;
using SeleniumWD.Pages;
using System.Linq;

namespace SeleniumWD.Steps
{
    public class SearchResultPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly SearchResultPage _searchPage;

        public SearchResultPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _searchPage = new SearchResultPage(_driver);
        }

        public string[] GetResultItemTitle()
        {
            return _searchPage.ItemTitles.Select(i => i.Text).ToArray();
        }

        public void OpenItem(string name)
        {
            var element = _searchPage.ItemTitles.First(i => i.Text.Contains(name));
            element.Click();
        }

        public void BuyItem(string name)
        {
            var element = _searchPage.ItemTitles.First(i => i.Text.Contains(name));
            _driver.HoverOver(element);
            _searchPage.BuyButton.Click();
            _searchPage.OrderButton.Click();
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void SelectFilterItem(string filterSection, string filterItem)
        {
            var elementList = GetFilterSection(filterSection).FindElements(By.CssSelector("li a"));
            var filter = elementList.First(i => i.Text.Contains(filterItem));
            filter.Click();
        }

        private IWebElement GetFilterSection(string name)
        {
            return _searchPage.Properties.First(i => i.Text.Contains(name));
        }
    }
}