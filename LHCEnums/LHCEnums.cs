﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHCEnums
{
    public class Machine
    {
        public enum Sector
        {
            Sector12,
            Sector23,
            Sector34,
            Sector45,
            Sector56,
            Sector67,
            Sector78,
            Sector81
        }

        public enum RF
        {
            Sector1L4,
            Sector2L4,
            Sector1R4,
            Sector2R4
        }

        public enum BeamDump
        {
            Beam1,
            Beam2
        }

        public enum EXPMagnets
        {
            ALICE_solenoid,
            ALICE_dipole,
            ATLAS_solenoid,
            ATLAS_torid,
            CMS_solenoid,
            LHCb_dipole
        }
    }
}

