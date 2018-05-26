using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Tests
{
    [TestClass()]
    public class LHCOCRTests
    {
        [TestMethod()]
        public void ProcessDataTest()
        {
            try
            {
                string result = null;
                LHCOCR.ProcessData(LHCEnums.Machine.Vistar.Pages.LHC_Cryogenics, out result);
                if (result != null)
                    Console.WriteLine(result);
                else
                    Assert.Fail("Did not return good data.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }
    }
}