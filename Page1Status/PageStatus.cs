using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RetrieveBitmap;
using LHCEnums;

namespace Page1Status
{
    public static class PageStatus
    {
        private static bool GetPage1PageAsync(out Bitmap lhc1Img)
        {
            if (!Retrieve.GetBitMap("https://vistar-capture.web.cern.ch/vistar-capture/lhc1.png", out lhc1Img))
                return false;
            return true;
        }

        public static bool GetBeamSMPStatus(Machine.Page1.Beam beam)
        {
            switch (beam)
            {
                case Machine.Page1.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap beam1StatusImg))
                        return false;
                    else
                    {
                        if (beam1StatusImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
							beam1StatusImg.GetPixel(872,572),
							beam1StatusImg.GetPixel(872,600),
							beam1StatusImg.GetPixel(872,629),
							beam1StatusImg.GetPixel(872,658),
							beam1StatusImg.GetPixel(872,686),
							beam1StatusImg.GetPixel(872,715)
                        };
                        if (colors[2] == Color.FromArgb(255, 0, 255, 0) && colors[5] == Color.FromArgb(255, 0, 255, 0)) // some weird mode we havent see before
                            break;
                        else if (colors[5] == Color.FromArgb(255, 0, 255, 0)) // if in stable beams remove the setup flag
                            colors.RemoveAt(2);
                        else if (colors[2] == Color.FromArgb(255, 0, 255, 0)) // if in setup remove the stable beams flag
                            colors.RemoveAt(5);

                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Page1.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap beam2Statusimg))
                        return false;
                    else
                    {
                        if (beam2Statusimg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            beam2Statusimg.GetPixel(945,572),
                            beam2Statusimg.GetPixel(945,600),
                            beam2Statusimg.GetPixel(945,629),
                            beam2Statusimg.GetPixel(945,658),
                            beam2Statusimg.GetPixel(945,686),
                            beam2Statusimg.GetPixel(945,715)
                        };
                        if (colors[2] == Color.FromArgb(255, 0, 255, 0) && colors[5] == Color.FromArgb(255, 0, 255, 0)) // some weird mode we havent see before
                            break;
                        else if (colors[5] == Color.FromArgb(255, 0, 255, 0)) // if in stable beams remove the setup flag
                            colors.RemoveAt(2);
                        else if (colors[2] == Color.FromArgb(255, 0, 255, 0)) // if in setup remove the stable beams flag
                            colors.RemoveAt(5);

                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetSMPStatus(Machine.Page1.Beam beam, Machine.Page1.SMPFlags smpFlag)
        {
            switch (beam)
            {
                case Machine.Page1.Beam.Beam1:
                    switch (smpFlag)
                    {
                        case Machine.Page1.SMPFlags.Link_Status_of_Beam_Permits:
                            if (!GetPage1PageAsync(out Bitmap linkStatusofBeamPermitsImg))
                                return false;
                            else
                            {
                                if (linkStatusofBeamPermitsImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    linkStatusofBeamPermitsImg.GetPixel(872,572)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Global_Beam_Permit:
                            if (!GetPage1PageAsync(out Bitmap globalBeamPermitImg))
                                return false;
                            else
                            {
                                if (globalBeamPermitImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    globalBeamPermitImg.GetPixel(872,600)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Setup_Beam:
                            if (!GetPage1PageAsync(out Bitmap setupBeamImg))
                                return false;
                            else
                            {
                                if (setupBeamImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    setupBeamImg.GetPixel(872,629)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Beam_Presence:
                            if (!GetPage1PageAsync(out Bitmap beamPresenceImg))
                                return false;
                            else
                            {
                                if (beamPresenceImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamPresenceImg.GetPixel(872,658)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Moveable_Devices_Allowed_In:
                            if (!GetPage1PageAsync(out Bitmap moveableDevicesAllowedInImg))
                                return false;
                            else
                            {
                                if (moveableDevicesAllowedInImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    moveableDevicesAllowedInImg.GetPixel(872,686)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Stable_Beams:
                            if (!GetPage1PageAsync(out Bitmap stableBeamsImg))
                                return false;
                            else
                            {
                                if (stableBeamsImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    stableBeamsImg.GetPixel(872,715)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        default:
                            break;
                    }
                    break;
                case Machine.Page1.Beam.Beam2:
                    switch (smpFlag)
                    {
                        case Machine.Page1.SMPFlags.Link_Status_of_Beam_Permits:
                            if (!GetPage1PageAsync(out Bitmap linkStatusofBeamPermitsImg))
                                return false;
                            else
                            {
                                if (linkStatusofBeamPermitsImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    linkStatusofBeamPermitsImg.GetPixel(945,572)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Global_Beam_Permit:
                            if (!GetPage1PageAsync(out Bitmap globalBeamPermitImg))
                                return false;
                            else
                            {
                                if (globalBeamPermitImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    globalBeamPermitImg.GetPixel(945,600)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Setup_Beam:
                            if (!GetPage1PageAsync(out Bitmap setupBeamImg))
                                return false;
                            else
                            {
                                if (setupBeamImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    setupBeamImg.GetPixel(945,629)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Beam_Presence:
                            if (!GetPage1PageAsync(out Bitmap beamPresenceImg))
                                return false;
                            else
                            {
                                if (beamPresenceImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    beamPresenceImg.GetPixel(945,658)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Moveable_Devices_Allowed_In:
                            if (!GetPage1PageAsync(out Bitmap moveableDevicesAllowedInImg))
                                return false;
                            else
                            {
                                if (moveableDevicesAllowedInImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    moveableDevicesAllowedInImg.GetPixel(945,686)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        case Machine.Page1.SMPFlags.Stable_Beams:
                            if (!GetPage1PageAsync(out Bitmap stableBeamsImg))
                                return false;
                            else
                            {
                                if (stableBeamsImg == null) return false;
                                List<Color> colors = new List<Color>
                                {
                                    stableBeamsImg.GetPixel(945,715)
                                };
                                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                            }
                        default:
                            break;
                    }
                    break;

            }
            return false;
        }
    }
}
