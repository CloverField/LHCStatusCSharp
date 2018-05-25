using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cryogenics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHCEnums;

namespace Cryogenics.Tests
{
    [TestClass()]
    public class CryoStatusTests
    {
        [TestMethod()]
        public void GetSectorStatusTest()
        {
            try
            {
                CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector12);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetSectorStatusIndividualTest()
        {
            try
            {
                CryoStatus.GetSectorStatusIndividual(Machine.Cryo.Sectors.Sector12, Machine.Cryo.Magnets.Magnet.CMAML3);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetSixyAmpPcPermitStatus()
        {
            try
            {
                CryoStatus.GetSixtyAmpPCPermitStatus();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetIndividualSixtyAmpPCPermitStatusTest()
        {
            try
            {
                CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S12);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetRFStatusTest()
        {
            try
            {
                CryoStatus.GetRFStatus(Machine.RF.Sectors.Sector1L4);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetRFStatusIndiviudalTest()
        {
            try
            {
                CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CM1L4);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}