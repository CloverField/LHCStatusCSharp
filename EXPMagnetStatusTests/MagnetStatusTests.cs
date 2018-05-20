using Microsoft.VisualStudio.TestTools.UnitTesting;
using EXPMagnetStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHCEnums;

namespace EXPMagnetStatus.Tests
{
    [TestClass()]
    public class MagnetStatusTests
    {
        [TestMethod()]
        public void GetEXPMagnetStatusIndividualTest()
        {
            try
            {
                MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.ALICE_dipole);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetEXPMagnetStatusTest()
        {
            try
            {
                MagnetStatus.GetEXPMagnetStatus();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}