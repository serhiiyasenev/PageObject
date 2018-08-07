using OpenQA.Selenium;
using SeleniumWD.Pages;

namespace SeleniumWD.Steps
{
    public class ProductPageSteps
    {
        private readonly ProductPage _productPage;

        public ProductPageSteps(IWebDriver driver)
        {
            _productPage = new ProductPage(driver);
        }

        public string GetTitle()
        {
            return _productPage.ProductTitle.Text;
        }
    }
}