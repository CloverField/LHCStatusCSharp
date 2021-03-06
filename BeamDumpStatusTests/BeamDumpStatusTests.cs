﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void GetBeamBeamDumpStatusTest()
        {
            try
            {
                BeamDumpStatus.GetBeamBeamDumpStatus(Machine.Beam.Beam1);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetBeamDumpStatusTest()
        {
            try
            {
                BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.BeamDumped);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod()]
        public void GetBeamDumpStatusIndividualTest()
        {
            try
            {
                BeamDumpStatus.GetBeamDumpStatusIndividualComponent(Machine.Beam.Beam1, Machine.BeamDump.Components.BeamDumped);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}