using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumWD.Core
{
    public static class WdExtension
    {
        public static void HoverOver(this IWebDriver driver, IWebElement element)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }
    }
}