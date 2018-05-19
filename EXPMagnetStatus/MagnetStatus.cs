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
    }
}
