using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWD.Core
{
    public static class SeleniumDriver
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get => _driver ?? (_driver = new ChromeDriver());

            set => _driver = value;
        }
    }
}