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

        public static bool GetBeamDumpStatus(Machine.BeamDump beamDump)
        {
            switch (beamDump)
            {
                case Machine.BeamDump.Beam1:
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
                case Machine.BeamDump.Beam2:
                    if (!GetBeamDumpStatusAsync(out Bitmap beamDumpBeamTwoImg))
                        return false;
                    else
                    {
                        if (beamDumpBeamTwoImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            //TODO: Update pixel locations for Beam 2 Dump
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
    }
}
