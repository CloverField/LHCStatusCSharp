using LHCEnums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Page1Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page1Status.Tests
{
    [TestClass()]
    public class PageStatusTests
    {
        [TestMethod()]
        public void GetBeamSMPStatusTest()
        {
            try
            {
                PageStatus.GetBeamSMPStatus(Machine.Beam.Beam1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetSMPStatusTest()
        {
            try
            {
                PageStatus.GetSMPStatus(Machine.Beam.Beam1,Machine.Page1.SMPFlags.Beam_Presence);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}