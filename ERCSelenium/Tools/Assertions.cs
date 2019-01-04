using ERCSelenium.SUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERCSelenium.Tools
{
    public class Assertions
    {
        public static void AreEqual(string a, string b, string message)
        {
            try
            {
                Assert.AreEqual(a, b, message);
                App.Reporter.ReportAssertion("element", "AreEqual", a, b, true, string.Empty);
            }
            catch (Exception ex)
            {
                App.Reporter.ReportAssertion("element", "AreEqual", a, b, false, ex.Message);
                throw;
            }
        }
    }
}
