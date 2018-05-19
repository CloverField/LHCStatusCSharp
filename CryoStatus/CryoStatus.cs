using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using LHCEnums;
using System.IO;

namespace Cryogenics
{
    public class CryoStatus
    {
        private static bool GetCryoStatusPage(out Bitmap cryoImg)
        {
            cryoImg = null;
            bool timedOut = false;
            var timer = new System.Timers.Timer
            {
                Interval = 30000
            };
            timer.Elapsed += (t, args) =>
            {
                timedOut = true;
            };
            using (WebClient wc = new WebClient())
            {
                timer.Start();
                cryoImg = (Bitmap)Bitmap.FromStream(new MemoryStream(wc.DownloadData("https://vistar-capture.web.cern.ch/vistar-capture/lhc2.png")));
                timer.Stop();
                return !timedOut;
            }
        }

        public static bool GetSectorStatus(Machine.Sector sector)
        {
            switch (sector)
            {
                case Machine.Sector.Sector12:
                    if (!GetCryoStatusPage(out Bitmap imgsecone))
                        return false;
                    else
                    {
                        if (imgsecone == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecone.GetPixel(100, 100),//CMITR1
                            imgsecone.GetPixel(188, 100),//CSITR1
                            imgsecone.GetPixel(288, 100),//CMMSR1
                            imgsecone.GetPixel(378, 100),//CSMSR1
                            imgsecone.GetPixel(478, 100),//CMAR12
                            imgsecone.GetPixel(568, 100),//CSAR12
                            imgsecone.GetPixel(668, 100),//CMMSL2
                            imgsecone.GetPixel(758, 100),//CSMSL2
                            imgsecone.GetPixel(858, 100),//CMITL2
                            imgsecone.GetPixel(948, 100)//CSITL2
                        };
                        return colors.Any(c => c == Color.FromArgb(255,0,255,0));
                    }
                case Machine.Sector.Sector23:
                    if (!GetCryoStatusPage(out Bitmap imgsectwo))
                        return false;
                    else
                    {
                        if (imgsectwo == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsectwo.GetPixel(100, 140),//CMITR2
                            imgsectwo.GetPixel(188, 140),//CSITR2
                            imgsectwo.GetPixel(288, 140),//CMMSR2
                            imgsectwo.GetPixel(378, 140),//CSMSR2
                            imgsectwo.GetPixel(478, 140),//CMAML3
                            imgsectwo.GetPixel(568, 140)//CSAML3
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector34:
                    if (!GetCryoStatusPage(out Bitmap imgsecthree))
                        return false;
                    else
                    {
                        if (imgsecthree == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecthree.GetPixel(478, 175),//CMAML3
                            imgsecthree.GetPixel(568, 175),//CSAML3
                            imgsecthree.GetPixel(668, 175),//CMMSL1
                            imgsecthree.GetPixel(758, 175)//CSMSL1
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector45:
                    if (!GetCryoStatusPage(out Bitmap imgsecfour))
                        return false;
                    else
                    {
                        if (imgsecfour == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecfour.GetPixel(288, 210),//CMMSR4
                            imgsecfour.GetPixel(378, 210),//CSMSR4
                            imgsecfour.GetPixel(478, 210),//CMAR45
                            imgsecfour.GetPixel(568, 210),//CSAR45
                            imgsecfour.GetPixel(668, 210),//CMMSL5
                            imgsecfour.GetPixel(758, 210),//CSMSL5
                            imgsecfour.GetPixel(858, 210),//CMITL6
                            imgsecfour.GetPixel(948, 210)//CSITL6
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector56:
                    if (!GetCryoStatusPage(out Bitmap imgsecfive))
                        return false;
                    else
                    {
                        if (imgsecfive == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecfive.GetPixel(100, 245),//CMITR5
                            imgsecfive.GetPixel(188, 245),//CSITR5
                            imgsecfive.GetPixel(288, 245),//CMMSR5
                            imgsecfive.GetPixel(378, 245),//CSMSR5
                            imgsecfive.GetPixel(478, 245),//CMAR56
                            imgsecfive.GetPixel(568, 245),//CSAR56
                            imgsecfive.GetPixel(668, 245),//CMMSL6
                            imgsecfive.GetPixel(758, 245)//CSMSL6
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector67:
                    if (!GetCryoStatusPage(out Bitmap imgsecsix))
                        return false;
                    else
                    {
                        if (imgsecsix == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecsix.GetPixel(288, 280),//CMMSR6
                            imgsecsix.GetPixel(378, 280),//CSMSR6
                            imgsecsix.GetPixel(478, 280),//CMAML7
                            imgsecsix.GetPixel(568, 280)//CSAML7
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector78:
                    if (!GetCryoStatusPage(out Bitmap imgsecseven))
                        return false;
                    else
                    {
                        if (imgsecseven == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsecseven.GetPixel(478, 315),//CMAMR7
                            imgsecseven.GetPixel(568, 315),//CSAMR7
                            imgsecseven.GetPixel(668, 315),//CMMSL8
                            imgsecseven.GetPixel(758, 315),//CSMSL8
                            imgsecseven.GetPixel(858, 315),//CMITL8
                            imgsecseven.GetPixel(948, 315)//CSITL8
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Sector.Sector81:
                    if (!GetCryoStatusPage(out Bitmap imgseceight))
                        return false;
                    else
                    {
                        if (imgseceight == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgseceight.GetPixel(100, 350),//CMITR8
                            imgseceight.GetPixel(188, 350),//CSITR8
                            imgseceight.GetPixel(288, 350),//CMMSR8
                            imgseceight.GetPixel(378, 350),//CSMSR8
                            imgseceight.GetPixel(478, 350),//CMAR81
                            imgseceight.GetPixel(568, 350),//CSAR81
                            imgseceight.GetPixel(668, 350),//CMMSL1
                            imgseceight.GetPixel(758, 350),//CSMSL1
                            imgseceight.GetPixel(858, 350),//CMITL1
                            imgseceight.GetPixel(948, 350)//CSITL1
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetSixtyAmpPCPermitStatus(Machine.Sector sector)
        {
            switch (sector)
            {
                case Machine.Sector.Sector12:
                    if (!GetCryoStatusPage(out Bitmap imgsecone))
                        return false;
                    else
                    {
                        if (imgsecone == null) return false;
                        return imgsecone.GetPixel(108, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector23:
                    if (!GetCryoStatusPage(out Bitmap imgsectwo))
                        return false;
                    else
                    {
                        if (imgsectwo == null) return false;
                        return imgsectwo.GetPixel(203, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector34:
                    if (!GetCryoStatusPage(out Bitmap imgsecthree))
                        return false;
                    else
                    {
                        if (imgsecthree == null) return false;
                        return imgsecthree.GetPixel(297, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector45:
                    if (!GetCryoStatusPage(out Bitmap imgsecfour))
                        return false;
                    else
                    {
                        if (imgsecfour == null) return false;
                        return imgsecfour.GetPixel(392, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector56:
                    if (!GetCryoStatusPage(out Bitmap imgsecfive))
                        return false;
                    else
                    {
                        if (imgsecfive == null) return false;
                        return imgsecfive.GetPixel(498, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector67:
                    if (!GetCryoStatusPage(out Bitmap imgsecsix))
                        return false;
                    else
                    {
                        if (imgsecsix == null) return false;
                        return imgsecsix.GetPixel(595, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector78:
                    if (!GetCryoStatusPage(out Bitmap imgsecseven))
                        return false;
                    else
                    {
                        if (imgsecseven == null) return false;
                        return imgsecseven.GetPixel(688, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Sector.Sector81:
                    if (!GetCryoStatusPage(out Bitmap imgseceight))
                        return false;
                    else
                    {
                        if (imgseceight == null) return false;
                        return imgseceight.GetPixel(772, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetRFStatus(Machine.RF rf)
        {

            switch (rf)
            {
                case Machine.RF.Sector1L4:
                    if (!GetCryoStatusPage(out Bitmap imgseconeL))
                        return false;
                    else
                    {
                        if (imgseconeL == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgseconeL.GetPixel(100, 440),//CM1L4
                            imgseconeL.GetPixel(188, 440)//CS1L4

                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sector1R4:
                    if (!GetCryoStatusPage(out Bitmap imgseconeR))
                        return false;
                    else
                    {
                        if (imgseconeR == null) return false;
                        List<Color> colors = new List<Color>
                        {

                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sector2L4:
                    if (!GetCryoStatusPage(out Bitmap imgsectwoL))
                        return false;
                    else
                    {
                        if (imgsectwoL == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsectwoL.GetPixel(290, 440),//CM2L4
                            imgsectwoL.GetPixel(380, 440)//CS2L4
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sector2R4:
                    if (!GetCryoStatusPage(out Bitmap imgsectwoR))
                        return false;
                    else
                    {
                        if (imgsectwoR == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsectwoR.GetPixel(670, 440),//CM2R4
                            imgsectwoR.GetPixel(760, 440)//CS2R4
                        };
                        return colors.Any(c => c == Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }
    }
}
