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

        public static bool GetBeamSMPStatus(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
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
                        if (colors[2] == Color.FromArgb(255, 0, 255, 0) && colors[5] == Color.FromArgb(255, 0, 255, 0)) // some weird mode we haven't see before
                            throw new Exception("New weird LHC mode discovered");
                        else if (colors[5] == Color.FromArgb(255, 0, 255, 0)) // if in stable beams remove the setup flag
                            colors.RemoveAt(2);
                        else if (colors[2] == Color.FromArgb(255, 0, 255, 0)) // if in setup remove the stable beams flag
                            colors.RemoveAt(5);

                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
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
                        if (colors[2] == Color.FromArgb(255, 0, 255, 0) && colors[5] == Color.FromArgb(255, 0, 255, 0)) // some weird mode we haven't see before
                            throw new Exception("New weird LHC mode discovered");
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

        public static bool GetSMPStatus(Machine.Beam beam, Machine.Page1.SMPFlags smpFlag)
        {
            return GetSMPStatusIndividual(beam, smpFlag);
        }

        public static bool GetSMPStatusIndividual(Machine.Beam beam, Machine.Page1.SMPFlags smpFlags)
        {
            switch (smpFlags)
            {
                case Machine.Page1.SMPFlags.Link_Status_of_Beam_Permits:
                    return CheckLinkStatusOfBeamPermits(beam);
                case Machine.Page1.SMPFlags.Global_Beam_Permit:
                    return CheckGlobalBeamPermit(beam);
                case Machine.Page1.SMPFlags.Setup_Beam:
                    return CheckSetupBeam(beam);
                case Machine.Page1.SMPFlags.Beam_Presence:
                    return CheckBeamPresence(beam);
                case Machine.Page1.SMPFlags.Moveable_Devices_Allowed_In:
                    return CheckMoveableDevicesAllowedIn(beam);
                case Machine.Page1.SMPFlags.Stable_Beams:
                    return CheckStableBeams(beam);
                default:
                    return false;
            }
        }

        private static bool CheckStableBeams(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap stableBeamsBeam1Img))
                        return false;
                    else
                    {
                        if (stableBeamsBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    stableBeamsBeam1Img.GetPixel(872,715)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap stableBeamsBeam2Img))
                        return false;
                    else
                    {
                        if (stableBeamsBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    stableBeamsBeam2Img.GetPixel(945,715)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }

        private static bool CheckMoveableDevicesAllowedIn(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap moveableDevicesAllowedInBeam1Img))
                        return false;
                    else
                    {
                        if (moveableDevicesAllowedInBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    moveableDevicesAllowedInBeam1Img.GetPixel(872,686)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap moveableDevicesAllowedInBeam2Img))
                        return false;
                    else
                    {
                        if (moveableDevicesAllowedInBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    moveableDevicesAllowedInBeam2Img.GetPixel(945,686)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }

        private static bool CheckBeamPresence(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap beamPresenceBeam1Img))
                        return false;
                    else
                    {
                        if (beamPresenceBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    beamPresenceBeam1Img.GetPixel(872,658)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap beamPresenceBeam2Img))
                        return false;
                    else
                    {
                        if (beamPresenceBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    beamPresenceBeam2Img.GetPixel(945,658)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }

        private static bool CheckSetupBeam(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap setupBeamBeam1Img))
                        return false;
                    else
                    {
                        if (setupBeamBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    setupBeamBeam1Img.GetPixel(872,629)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap setupBeamBeam2Img))
                        return false;
                    else
                    {
                        if (setupBeamBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    setupBeamBeam2Img.GetPixel(945,629)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }

        private static bool CheckGlobalBeamPermit(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap globalBeamPermitBeam1Img))
                        return false;
                    else
                    {
                        if (globalBeamPermitBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    globalBeamPermitBeam1Img.GetPixel(872,600)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap globalBeamPermitBeam2Img))
                        return false;
                    else
                    {
                        if (globalBeamPermitBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    globalBeamPermitBeam2Img.GetPixel(945,600)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }

        private static bool CheckLinkStatusOfBeamPermits(Machine.Beam beam)
        {
            switch (beam)
            {
                case Machine.Beam.Beam1:
                    if (!GetPage1PageAsync(out Bitmap linkStatusofBeamPermitsBeam1Img))
                        return false;
                    else
                    {
                        if (linkStatusofBeamPermitsBeam1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    linkStatusofBeamPermitsBeam1Img.GetPixel(872,572)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Beam.Beam2:
                    if (!GetPage1PageAsync(out Bitmap linkStatusofBeamPermitsBeam2Img))
                        return false;
                    else
                    {
                        if (linkStatusofBeamPermitsBeam2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    linkStatusofBeamPermitsBeam2Img.GetPixel(945,572)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    return false;
            }
        }
    }
}
