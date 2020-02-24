using System;
using ERCSelenium.SUT;
using Selenio.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ERCSelenium.Tools;

namespace ERC.Selenium
{
    [TestClass]
    public class AmazonAutomatedTests : MasterTestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            RunTest(() =>
            {
                App.Reporter.TestDescription = "Use Case #1: Locating a product using the search box";
                App.Reporter.TestStep = "Open the Amazon website";
                App.Amazon.OpenSite();

                App.Reporter.TestStep = "Search for product X using the text box.";
                App.Amazon.SearchForProduct("headphones");

                App.Reporter.TestStep = "Validate that at least one result was obtained.";
                App.Amazon.WaitForScreen(App.Amazon.ResultsList);
                App.Reporter.StatusUpdate("Validating that results with the word 'headphones were returned.'", App.Amazon.ResultsSection.Text.Contains("headphones"));

                App.Reporter.TestStep = "Click on any item from the list.";
                Random number = new Random();
                App.Amazon.GetItemFromResult(number.Next(10)).Click();

                App.Reporter.TestStep = "Add item to cart.";
                App.Amazon.WaitForScreen(App.Amazon.AddToCartBtn);
                App.Amazon.AddToCartBtn.Click();
            });
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
