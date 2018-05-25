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
                LHCOCR.ProcessData(LHCEnums.Machine.Vistar.Pages.LHC_Cryogenics);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }
    }
}