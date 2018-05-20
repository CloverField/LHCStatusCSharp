using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetrieveBitmap;
using LHCEnums;

namespace BeamDump
{
    public static class BeamDumpStatus
    {
        private static bool GetBeamDumpStatusAsync(out Bitmap beamDumpImg)
        {
            if (!Retrieve.GetBitMap("https://vistar-capture.web.cern.ch/vistar-capture/lhcbds.png", out beamDumpImg))
                return false;
            return true;
        }

        public static bool GetBeamBeamDumpStatus(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetBeamDumpStatusAsync(out Bitmap beamDumpBeamOneImg))
                        return false;
                    else
                    {
                        if (beamDumpBeamOneImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            beamDumpBeamOneImg.GetPixel(192, 38),//BeamOneDumped
                            beamDumpBeamOneImg.GetPixel(73,60),//Kicker
                            beamDumpBeamOneImg.GetPixel(200,60),//BETS
                            beamDumpBeamOneImg.GetPixel(323,60),//IPOC - Beam Dump Pane
                            beamDumpBeamOneImg.GetPixel(76,80),//LASS
                            beamDumpBeamOneImg.GetPixel(200,82),//RETRIGGER
                            beamDumpBeamOneImg.GetPixel(326,82),//XPOC
                            beamDumpBeamOneImg.GetPixel(81,101),//REMOTE - Beam Dump Pane
                            beamDumpBeamOneImg.GetPixel(193,102),//ON - Beam Dump Pane
                            beamDumpBeamOneImg.GetPixel(90,168),//REMOTE - Injection Pane
                            beamDumpBeamOneImg.GetPixel(194,168),//ON - Injection Pane
                            beamDumpBeamOneImg.GetPixel(333,168),//TIMING ON
                            beamDumpBeamOneImg.GetPixel(65,189),//CONDITIONING
                            beamDumpBeamOneImg.GetPixel(286,188),//TIMEOUT
                            beamDumpBeamOneImg.GetPixel(111,210),//IPOC - Injection Pane
                            beamDumpBeamOneImg.GetPixel(290,210)//IQC
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetBeamDumpStatusAsync(out Bitmap beamDumpBeamTwoImg))
                        return false;
                    else
                    {
                        if (beamDumpBeamTwoImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            beamDumpBeamTwoImg.GetPixel(593, 38),//BeamTwoDumped
                            beamDumpBeamTwoImg.GetPixel(472,60),//Kicker
                            beamDumpBeamTwoImg.GetPixel(600,60),//BETS
                            beamDumpBeamTwoImg.GetPixel(723,60),//IPOC - Beam Dump Pane
                            beamDumpBeamTwoImg.GetPixel(476,80),//LASS
                            beamDumpBeamTwoImg.GetPixel(600,82),//RETRIGGER
                            beamDumpBeamTwoImg.GetPixel(726,82),//XPOC
                            beamDumpBeamTwoImg.GetPixel(481,101),//REMOTE - Beam Dump Pane
                            beamDumpBeamTwoImg.GetPixel(593,102),//ON - Beam Dump Pane
                            beamDumpBeamTwoImg.GetPixel(490,168),//REMOTE - Injection Pane
                            beamDumpBeamTwoImg.GetPixel(594,168),//ON - Injection Pane
                            beamDumpBeamTwoImg.GetPixel(733,168),//TIMING ON
                            beamDumpBeamTwoImg.GetPixel(465,189),//CONDITIONING
                            beamDumpBeamTwoImg.GetPixel(686,188),//TIMEOUT
                            beamDumpBeamTwoImg.GetPixel(511,210),//IPOC - Injection Pane
                            beamDumpBeamTwoImg.GetPixel(690,210)//IQC
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetBeamDumpStatus(Machine.Beam beam, Machine.BeamDump.Components components)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    switch (components)
                    {
                        case Machine.BeamDump.Components.BeamDumped:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneDumpedImg))
                                return false;
                            else
                            {
                                if (beamOneDumpedImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneDumpedImg.GetPixel(192, 38),//BeamOneDumped
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.Kicker:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneKickerImg))
                                return false;
                            else
                            {
                                if (beamOneKickerImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneKickerImg.GetPixel(73,60),//Kicker
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.BETS:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneBETSImg))
                                return false;
                            else
                            {
                                if (beamOneBETSImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneBETSImg.GetPixel(200,60),//BETS
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IPOC_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneIPOCBeamDumpPaneImg))
                                return false;
                            else
                            {
                                if (beamOneIPOCBeamDumpPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneIPOCBeamDumpPaneImg.GetPixel(323,60),//IPOC - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.LASS:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneLASSImg))
                                return false;
                            else
                            {
                                if (beamOneLASSImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneLASSImg.GetPixel(76,80),//LASS
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.RETRIGGER:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneRetriggerImg))
                                return false;
                            else
                            {
                                if (beamOneRetriggerImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneRetriggerImg.GetPixel(200,82),//RETRIGGER
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.XPOC:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneXPOCImg))
                                return false;
                            else
                            {
                                if (beamOneXPOCImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneXPOCImg.GetPixel(326,82),//XPOC
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.REMOTE_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneRemoteBeamDumpPaneImg))
                                return false;
                            else
                            {
                                if (beamOneRemoteBeamDumpPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneRemoteBeamDumpPaneImg.GetPixel(81,101),//REMOTE - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.ON_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneOnBeamDumpPaneImg))
                                return false;
                            else
                            {
                                if (beamOneOnBeamDumpPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneOnBeamDumpPaneImg.GetPixel(193,102),//ON - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.REMOTE_U_Injection_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneRemoteInjectionPaneImg))
                                return false;
                            else
                            {
                                if (beamOneRemoteInjectionPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneRemoteInjectionPaneImg.GetPixel(90,168),//REMOTE - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.ON_U_Injection_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneOnInjectionPanelImg))
                                return false;
                            else
                            {
                                if (beamOneOnInjectionPanelImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneOnInjectionPanelImg.GetPixel(194,168),//ON - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.TIMING_ON:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneTimingOnImg))
                                return false;
                            else
                            {
                                if (beamOneTimingOnImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneTimingOnImg.GetPixel(333,168),//TIMING ON
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.CONDITIONING:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneConditioningImg))
                                return false;
                            else
                            {
                                if (beamOneConditioningImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneConditioningImg.GetPixel(65,189),//CONDITIONING
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.TIMEOUT:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneTimeoutImg))
                                return false;
                            else
                            {
                                if (beamOneTimeoutImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneTimeoutImg.GetPixel(286,188),//TIMEOUT
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IPOC_U_Injection_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneIPOCInjectionPaneImg))
                                return false;
                            else
                            {
                                if (beamOneIPOCInjectionPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneIPOCInjectionPaneImg.GetPixel(111,210),//IPOC - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IQC:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamOneIQCImg))
                                return false;
                            else
                            {
                                if (beamOneIQCImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamOneIQCImg.GetPixel(290,210)//IQC
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        default:
                            break;
                    }
                    break;
                case Machine.Beam.Beam2:
                    switch (components)
                    {
                        case Machine.BeamDump.Components.BeamDumped:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoBeamDumpedImg))
                                return false;
                            else
                            {
                                if (beamTwoBeamDumpedImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoBeamDumpedImg.GetPixel(593, 38),//BeamTwoDumped
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.Kicker:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoKickerImg))
                                return false;
                            else
                            {
                                if (beamTwoKickerImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoKickerImg.GetPixel(472,60),//Kicker
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.BETS:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoBETSImg))
                                return false;
                            else
                            {
                                if (beamTwoBETSImg  == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoBETSImg.GetPixel(600,60),//BETS
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IPOC_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoIPOCBeamDumpPane))
                                return false;
                            else
                            {
                                if (beamTwoIPOCBeamDumpPane == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoIPOCBeamDumpPane.GetPixel(723,60),//IPOC - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.LASS:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoLASSImg))
                                return false;
                            else
                            {
                                if (beamTwoLASSImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoLASSImg.GetPixel(476,80),//LASS
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.RETRIGGER:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoRetriggerImg))
                                return false;
                            else
                            {
                                if (beamTwoRetriggerImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoRetriggerImg.GetPixel(600,82),//RETRIGGER
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.XPOC:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoXPOCImg))
                                return false;
                            else
                            {
                                if (beamTwoXPOCImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoXPOCImg.GetPixel(726,82),//XPOC
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.REMOTE_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoRemoteBeamDumpPaneImg))
                                return false;
                            else
                            {
                                if (beamTwoRemoteBeamDumpPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoRemoteBeamDumpPaneImg.GetPixel(481,101),//REMOTE - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.ON_U_Beam_Dump_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoOnBeamDumpPaneImg))
                                return false;
                            else
                            {
                                if (beamTwoOnBeamDumpPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoOnBeamDumpPaneImg.GetPixel(593,102),//ON - Beam Dump Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.REMOTE_U_Injection_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoRemoteInjectionPaneImg))
                                return false;
                            else
                            {
                                if (beamTwoRemoteInjectionPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoRemoteInjectionPaneImg.GetPixel(490,168),//REMOTE - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.ON_U_Injection_Pane:
                            if(!GetBeamDumpStatusAsync(out Bitmap beamTwoOnInjectionPaneImg))
                                return false;
                            else
                            {
                                if (beamTwoOnInjectionPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoOnInjectionPaneImg.GetPixel(594,168),//ON - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.TIMING_ON:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoTimingOnImg))
                                return false;
                            else
                            {
                                if (beamTwoTimingOnImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoTimingOnImg.GetPixel(733,168),//TIMING ON
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.CONDITIONING:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoConditioningImg))
                                return false;
                            else
                            {
                                if (beamTwoConditioningImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoConditioningImg.GetPixel(465,189),//CONDITIONING
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.TIMEOUT:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoTimeoutImg))
                                return false;
                            else
                            {
                                if (beamTwoTimeoutImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoTimeoutImg.GetPixel(686,188),//TIMEOUT
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IPOC_U_Injection_Pane:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoIPOCInjectionPaneImg))
                                return false;
                            else
                            {
                                if (beamTwoIPOCInjectionPaneImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoIPOCInjectionPaneImg.GetPixel(511,210),//IPOC - Injection Pane
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.BeamDump.Components.IQC:
                            if (!GetBeamDumpStatusAsync(out Bitmap beamTwoIQCImg))
                                return false;
                            else
                            {
                                if (beamTwoIQCImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamTwoIQCImg.GetPixel(690,210)//IQC
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
