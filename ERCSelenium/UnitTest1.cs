using System;
using static Selenio.Core.SUT.SUTDriver;
using ERCSelenium.SUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ERCSelenium.Tools;

namespace ERCSelenium
{
    [TestClass]
    public class ERCSeleniumTest : MasterTestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            RunTest(() =>
            {
                Reporter.TestDescription = "Navigate to Google and make a search.";
                App.OpenURL();
                App.Google.Search("Youtube");
            });
        }

        [TestMethod]
        public void AutoConfigFileExists()
        {
            RunTest(() =>
            {
                Reporter.TestDescription = "Read my XML.";
                Reporter.TestStep = "Get deployment directory";
                Assertions.AreEqual(AutoConfig.XmlFilePath, AutoConfig.XmlFilePath, "File paths are not the same.");
                Assertions.AreEqual("", AutoConfig.XmlFilePath, "File paths are not the same.");

            });
        }
    }
}
