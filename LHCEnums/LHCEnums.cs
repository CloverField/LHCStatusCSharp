using System;
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

        public enum Beam
        {
            Beam1,
            Beam2
        }

        public class BeamDump
        {
            public enum Components
            {
                BeamDumped,
                Kicker,
                BETS,
                IPOC_U_Beam_Dump_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                LASS,
                RETRIGGER,
                XPOC,
                REMOTE_U_Beam_Dump_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                ON_U_Beam_Dump_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                REMOTE_U_Injection_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                ON_U_Injection_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                TIMING_ON,
                CONDITIONING,
                TIMEOUT,
                IPOC_U_Injection_Pane, //The U will be replaced with a - for readablity, however enums dont let you use dashes
                IQC
            }
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

        public class Page1
        {
            public enum SMPFlags
            {
                Link_Status_of_Beam_Permits,
                Global_Beam_Permit,
                Setup_Beam,
                Beam_Presence,
                Moveable_Devices_Allowed_In,
                Stable_Beams
            }
        }
    }
}

