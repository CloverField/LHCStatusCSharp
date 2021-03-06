﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHCEnums
{
    public class Machine
    {
        public class Cryo
        {
            public enum Sectors
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

            public enum PCPermit
            {
                S12,
                S23,
                S34,
                S45,
                S56,
                S67,
                S78,
                S81
            }


            public class Magnets
            {

                public enum Magnet
                {
                    #region Sector12
                    //Sector12
                    CMITR1,
                    CSITR1,
                    CMMSR1,
                    CSMSR1,
                    CMAR12,
                    CSAR12,
                    CMMSL2,
                    CSMSL2,
                    CMITL2,
                    CSITL2,
                    #endregion
                    #region Sector23
                    //Sector23
                    CMITR2,
                    CSITR2,
                    CMMSR2,
                    CSMSR2,
                    CMAML3,
                    CSAML3,
                    #endregion
                    #region Sector34
                    //Sector34
                    CMAMR3,
                    CSAMR3,
                    CMMSL4,
                    CSMSL4,
                    #endregion
                    #region Sector45
                    //Sector45
                    CMMSR4,
                    CSMSR4,
                    CMAR45,
                    CSAR45,
                    CMMSL5,
                    CSMSL5,
                    CMITL5,
                    CSITL5,
                    #endregion
                    #region Sector56
                    //Sector56
                    CMITR5,
                    CSITR5,
                    CMMSR5,
                    CSMSR5,
                    CMAR56,
                    CSAR56,
                    CMMSL6,
                    CSMSL6,
                    #endregion
                    #region Sector67
                    //Sector67
                    CMMSR6,
                    CSMSR6,
                    CMAML7,
                    CSAML7,
                    #endregion
                    #region Sector78
                    //Sector78
                    CMAMR7,
                    CSAMR7,
                    CMMSL8,
                    CSMSL8,
                    CMITL8,
                    CSITL8,
                    #endregion
                    #region Sector81
                    //Sector81
                    CMITR8,
                    CSITR8,
                    CMMSR8,
                    CSMSR8,
                    CMAR81,
                    CSAR81,
                    CMMSL1,
                    CSMSL1,
                    CMITL1,
                    CSITL1
                    #endregion
                }
            }
        }

        public class RF
        {
            public enum Sectors
            {
                Sector1L4,
                Sector2L4,
                Sector1R4,
                Sector2R4
            }

            public enum Cryo
            {
                CM1L4,
                CS1L4,
                CM2L4,
                CS2L4,
                CM1R4,
                CS1R4,
                CM2R4,
                CS2R4
            }
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
                IPOC_U_Beam_Dump_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
                LASS,
                RETRIGGER,
                XPOC,
                REMOTE_U_Beam_Dump_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
                ON_U_Beam_Dump_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
                REMOTE_U_Injection_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
                ON_U_Injection_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
                TIMING_ON,
                CONDITIONING,
                TIMEOUT,
                IPOC_U_Injection_Pane, //The U will be replaced with a - for readability, however enums don't let you use dashes
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

        public class Vistar
        {
            public enum Pages
            {
                LHC_Configuration,
                LHC_Coordination,
                LHC_Cryogenics,
                LHC_EXP_Magnets,
                LHC_Luminosity,
                LHC_Operation,
                LHC_Page_1_Beam_Mode,
                LHC_Page_1_Comments
            }
        }
    }
}

