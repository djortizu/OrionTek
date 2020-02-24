using ERCSelenium.SUT;
using ERCSelenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenio.Core.SUT;
using Selenio.Extensions;

namespace ERC.Selenium.PageObjects
{
    public class Amazon : PageObject
    {
        #region WebElements
        [WaitForThisElement]
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 's-breadcrumb')]//div[contains(@class, 'a-section')]")]
        public IWebElement ResultsSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@data-component-type='s-search-results']/div[contains(@class, 's-search-results')]")]
        public IWebElement ResultsList { get; set; }

        [FindsBy(How = How.Id, Using = "breadcrumb-back-link")]
        public IWebElement BackToResultsLink { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        public IWebElement AddToCartBtn { get; set; }
        #endregion

        #region Methods
        public Amazon OpenSite()
        {
            App.Driver.Url = AutoConfig.AmazonUrl;
            this.WaitForScreen();
            return this;
        }

        public Amazon SearchForProduct(string productName)
        {
            SearchBox.SetText(productName);
            SearchButton.Click();
            return this;
        }

        public IWebElement GetItemFromResult(int numberOnList)
        {
            IWebElement item = ResultsList.FindElement(By.XPath($"//div[@data-index={numberOnList}]")).FindElement(By.XPath("//a[@class='a-link-normal']"));
            return item;
        }
        #endregion
    }
}
