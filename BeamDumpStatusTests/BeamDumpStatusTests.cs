using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeamDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHCEnums;

namespace BeamDump.Tests
{
    [TestClass()]
    public class BeamDumpStatusTests
    {
        [TestMethod()]
        public void GetBeamDumpStatusTest()
        {
            try
            {
                BeamDumpStatus.GetBeamDumpStatus(Machine.BeamDump.Beam1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}