using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RetrieveBitmap;
using LHCEnums;

namespace EXPMagnetStatus
{
    public static class MagnetStatus
    {
        private static bool GetMagnetStatusPageAsync(out Bitmap expMagnetImg)
        {
            if (!Retrieve.GetBitMap("https://vistar-capture.web.cern.ch/vistar-capture/lhcexpmag.png", out expMagnetImg))
                return false;
            return true;
        }

        public static bool GetEXPMagnetStatus()
        {
            if (!GetMagnetStatusPageAsync(out Bitmap magnetStatusImg))
                return false;
            else
            {
                if (magnetStatusImg == null) return false;
                List<Color> colors = new List<Color>
                {
                    magnetStatusImg.GetPixel(365,60),
                    magnetStatusImg.GetPixel(365,100),
                    magnetStatusImg.GetPixel(365,140),
                    magnetStatusImg.GetPixel(365,180),
                    magnetStatusImg.GetPixel(365,220),
                    magnetStatusImg.GetPixel(365,260)
                };
                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
            }
        }

        public static bool GetEXPMagnetStatusIndividual(Machine.EXPMagnets expMagnets)
        {
            switch (expMagnets)
            {
                case Machine.EXPMagnets.ALICE_solenoid:
                    if (!GetMagnetStatusPageAsync(out Bitmap aliceSolenoidImg))
                        return false;
                    else
                    {
                        if (aliceSolenoidImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            aliceSolenoidImg.GetPixel(365,60)
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.EXPMagnets.ALICE_dipole:
                    if (!GetMagnetStatusPageAsync(out Bitmap aliceDipoleImg))
                        return false;
                    else
                    {
                        if (aliceDipoleImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            aliceDipoleImg.GetPixel(365,100)
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.EXPMagnets.ATLAS_solenoid:
                    if (!GetMagnetStatusPageAsync(out Bitmap atlasSolenoidImg))
                        return false;
                    else
                    {
                        if (atlasSolenoidImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            atlasSolenoidImg.GetPixel(365,140)
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.EXPMagnets.ATLAS_torid:
                    if (!GetMagnetStatusPageAsync(out Bitmap atlasToridImg))
                        return false;
                    else
                    {
                        if (atlasToridImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            atlasToridImg.GetPixel(365,180)
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.EXPMagnets.CMS_solenoid:
                    if (!GetMagnetStatusPageAsync(out Bitmap cmsSolenoidImg))
                        return false;
                    else
                    {
                        if (cmsSolenoidImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cmsSolenoidImg.GetPixel(365,220)
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.EXPMagnets.LHCb_dipole:
                    if (!GetMagnetStatusPageAsync(out Bitmap lhcbDipoleImg))
                        return false;
                    else
                    {
                        if (lhcbDipoleImg == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            lhcbDipoleImg.GetPixel(365,260)
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
