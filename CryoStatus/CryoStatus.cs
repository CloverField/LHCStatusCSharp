using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.IO;
using LHCEnums;
using RetrieveBitmap;

namespace Cryogenics
{
    public class CryoStatus
    {
        private static bool GetCryoStatusPageAsync(out Bitmap cryoImg)
        {
            if (!Retrieve.GetBitMap("https://vistar-capture.web.cern.ch/vistar-capture/lhc2.png", out cryoImg))
                return false;
            return true;
        }

        public static bool GetSectorStatus(Machine.Cryo.Sectors sector)
        {
            switch (sector)
            {
                case Machine.Cryo.Sectors.Sector12:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecone))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector23:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsectwo))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector34:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecthree))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector45:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecfour))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector56:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecfive))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector67:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecsix))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector78:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecseven))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Sectors.Sector81:
                    if (!GetCryoStatusPageAsync(out Bitmap imgseceight))
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
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetSectorStatusIndividual(Machine.Cryo.Sectors sector, Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (sector)
            {
                case Machine.Cryo.Sectors.Sector12:
                    return CheckSector12StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector23:
                    return CheckSector23StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector34:
                    return CheckSector34StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector45:
                    return CheckSector45StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector56:
                    return CheckSector56StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector67:
                    return CheckSector67StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector78:
                    return CheckSector78StatusIndividual(magnet);
                case Machine.Cryo.Sectors.Sector81:
                    return CheckSector81StatusIndividual(magnet);
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector81StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMITR8:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitr8Img))
                        return false;
                    else
                    {
                        if (cmitr8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmitr8Img.GetPixel(100, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITR8:
                    if (!GetCryoStatusPageAsync(out Bitmap csitr8Img))
                        return false;
                    else
                    {
                        if (csitr8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csitr8Img.GetPixel(188, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSR8:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr8Img))
                        return false;
                    else
                    {
                        if (cmmsr8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmmsr8Img.GetPixel(288, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR8:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr8Img))
                        return false;
                    else
                    {
                        if (csmsr8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csmsr8Img.GetPixel(378, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAR81:
                    if (!GetCryoStatusPageAsync(out Bitmap cmar81Img))
                        return false;
                    else
                    {
                        if (cmar81Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmar81Img.GetPixel(478, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAR81:
                    if (!GetCryoStatusPageAsync(out Bitmap csar81Img))
                        return false;
                    else
                    {
                        if (csar81Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csar81Img.GetPixel(568, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL1:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl1Img))
                        return false;
                    else
                    {
                        if (cmmsl1Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmmsl1Img.GetPixel(668, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL1:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl1Img))
                        return false;
                    else
                    {
                        if (csmsl1Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csmsl1Img.GetPixel(758, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMITL1:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitl1Img))
                        return false;
                    else
                    {
                        if (cmitl1Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmitl1Img.GetPixel(858, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITL1:
                    if (!GetCryoStatusPageAsync(out Bitmap csitl1Img))
                        return false;
                    else
                    {
                        if (csitl1Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csitl1Img.GetPixel(948, 350)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector78StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMAMR7:
                    if (!GetCryoStatusPageAsync(out Bitmap cmamr7Img))
                        return false;
                    else
                    {
                        if (cmamr7Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmamr7Img.GetPixel(478,315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAMR7:
                    if (!GetCryoStatusPageAsync(out Bitmap csamr7Img))
                        return false;
                    else
                    {
                        if (csamr7Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csamr7Img.GetPixel(568,315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL8:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl8Img))
                        return false;
                    else
                    {
                        if (cmmsl8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmmsl8Img.GetPixel(668, 315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL8:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl8Img))
                        return false;
                    else
                    {
                        if (csmsl8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csmsl8Img.GetPixel(758, 315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMITL8:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitl8Img))
                        return false;
                    else
                    {
                        if (cmitl8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmitl8Img.GetPixel(858, 315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITL8:
                    if (!GetCryoStatusPageAsync(out Bitmap csitl8Img))
                        return false;
                    else
                    {
                        if (csitl8Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csitl8Img.GetPixel(948, 315)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector67StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMMSR6:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr6Img))
                        return false;
                    else
                    {
                        if (cmmsr6Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmmsr6Img.GetPixel(288,280)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR6:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr6Img))
                        return false;
                    else
                    {
                        if (csmsr6Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csmsr6Img.GetPixel(378, 280)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAML7:
                    if (!GetCryoStatusPageAsync(out Bitmap cmaml7Img))
                        return false;
                    else
                    {
                        if (cmaml7Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    cmaml7Img.GetPixel(478, 280)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAML7:
                    if (!GetCryoStatusPageAsync(out Bitmap csaml7Img))
                        return false;
                    else
                    {
                        if (csaml7Img == null) return false;
                        List<Color> colors = new List<Color>()
                                {
                                    csaml7Img.GetPixel(568, 280)
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector56StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMITR5:
                    if (!GetCryoStatusPageAsync(out Bitmap cmirt5Img))
                        return false;
                    else
                    {
                        if (cmirt5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmirt5Img.GetPixel(100, 245),//CMITR5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITR5:
                    if (!GetCryoStatusPageAsync(out Bitmap csirt5Img))
                        return false;
                    else
                    {
                        if (csirt5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csirt5Img.GetPixel(188, 245),//CSITR5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSR5:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr5Img))
                        return false;
                    else
                    {
                        if (cmmsr5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsr5Img.GetPixel(288, 245),//CMMSR5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR5:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr5Img))
                        return false;
                    else
                    {
                        if (csmsr5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsr5Img.GetPixel(378, 245),//CSMSR5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAR56:
                    if (!GetCryoStatusPageAsync(out Bitmap cmar56Img))
                        return false;
                    else
                    {
                        if (cmar56Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmar56Img.GetPixel(478, 245),//CMAR56
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAR56:
                    if (!GetCryoStatusPageAsync(out Bitmap csar56Img))
                        return false;
                    else
                    {
                        if (csar56Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csar56Img.GetPixel(568, 245),//CSAR56
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL6:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl6Img))
                        return false;
                    else
                    {
                        if (cmmsl6Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsl6Img.GetPixel(668, 245),//CMMSL6
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL6:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl6Img))
                        return false;
                    else
                    {
                        if (csmsl6Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsl6Img.GetPixel(758, 245)//CSMSL6 
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector45StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMMSR4:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr4Img))
                        return false;
                    else
                    {
                        if (cmmsr4Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsr4Img.GetPixel(288, 210),//CMMSR4
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR4:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr4Img))
                        return false;
                    else
                    {
                        if (csmsr4Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsr4Img.GetPixel(378, 210),//CSMSR4
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAR45:
                    if (!GetCryoStatusPageAsync(out Bitmap cmar45Img))
                        return false;
                    else
                    {
                        if (cmar45Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmar45Img.GetPixel(478, 210),//CMAR45
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAR45:
                    if (!GetCryoStatusPageAsync(out Bitmap csar45Img))
                        return false;
                    else
                    {
                        if (csar45Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csar45Img.GetPixel(568, 210),//CSAR45
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL5:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl5Img))
                        return false;
                    else
                    {
                        if (cmmsl5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsl5Img.GetPixel(668, 210),//CMMSL5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL5:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl5Img))
                        return false;
                    else
                    {
                        if (csmsl5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsl5Img.GetPixel(758, 210),//CSMSL5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMITL5:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitl5Img))
                        return false;
                    else
                    {
                        if (cmitl5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmitl5Img.GetPixel(858, 210),//CMITL5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITL5:
                    if (!GetCryoStatusPageAsync(out Bitmap csitl5Img))
                        return false;
                    else
                    {
                        if (csitl5Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csitl5Img.GetPixel(948, 210)//CSITL5
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector34StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMAML3:
                    if (!GetCryoStatusPageAsync(out Bitmap cmaml3Img))
                        return false;
                    else
                    {
                        if (cmaml3Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmaml3Img.GetPixel(478, 175),//CMAML3
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAML3:
                    if (!GetCryoStatusPageAsync(out Bitmap csaml3Img))
                        return false;
                    else
                    {
                        if (csaml3Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csaml3Img.GetPixel(568, 175),//CSAML3
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL1:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl1Img))
                        return false;
                    else
                    {
                        if (cmmsl1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsl1Img.GetPixel(668, 175),//CMMSL1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL1:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl1Img))
                        return false;
                    else
                    {
                        if (csmsl1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsl1Img.GetPixel(758, 175)//CSMSL1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector23StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMITR2:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitr2Img))
                        return false;
                    else
                    {
                        if (cmitr2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmitr2Img.GetPixel(100, 140),//CMITR2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITR2:
                    if (!GetCryoStatusPageAsync(out Bitmap csitr2Img))
                        return false;
                    else
                    {
                        if (csitr2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csitr2Img.GetPixel(188, 140),//CSITR2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSR2:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr2Img))
                        return false;
                    else
                    {
                        if (cmmsr2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsr2Img.GetPixel(288, 140),//CMMSR2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR2:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr2Img))
                        return false;
                    else
                    {
                        if (csmsr2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsr2Img.GetPixel(378, 140),//CSMSR2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAML3:
                    if (!GetCryoStatusPageAsync(out Bitmap cmaml3Img))
                        return false;
                    else
                    {
                        if (cmaml3Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmaml3Img.GetPixel(478, 140),//CMAML3
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAML3:
                    if (!GetCryoStatusPageAsync(out Bitmap csaml3Img))
                        return false;
                    else
                    {
                        if (csaml3Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csaml3Img.GetPixel(568, 140)//CSAML3
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        private static bool CheckSector12StatusIndividual(Machine.Cryo.Magnets.Magnet magnet)
        {
            switch (magnet)
            {
                case Machine.Cryo.Magnets.Magnet.CMITR1:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitrl1Img))
                        return false;
                    else
                    {
                        if (cmitrl1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmitrl1Img.GetPixel(100, 100),//CMITR1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITR1:
                    if (!GetCryoStatusPageAsync(out Bitmap csitr1Img))
                        return false;
                    else
                    {
                        if (csitr1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csitr1Img.GetPixel(188, 100),//CSITR1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSR1:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsr1Img))
                        return false;
                    else
                    {
                        if (cmmsr1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsr1Img.GetPixel(288, 100),//CMMSR1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSR1:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsr1Img))
                        return false;
                    else
                    {
                        if (csmsr1Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsr1Img.GetPixel(378, 100),//CSMSR1
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMAR12:
                    if (!GetCryoStatusPageAsync(out Bitmap cmar12Img))
                        return false;
                    else
                    {
                        if (cmar12Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmar12Img.GetPixel(478, 100),//CMAR12
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSAR12:
                    if (!GetCryoStatusPageAsync(out Bitmap csar12Img))
                        return false;
                    else
                    {
                        if (csar12Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csar12Img.GetPixel(568, 100),//CSAR12
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMMSL2:
                    if (!GetCryoStatusPageAsync(out Bitmap cmmsl2Img))
                        return false;
                    else
                    {
                        if (cmmsl2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmmsl2Img.GetPixel(668, 100),//CMMSL2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSMSL2:
                    if (!GetCryoStatusPageAsync(out Bitmap csmsl2Img))
                        return false;
                    else
                    {
                        if (csmsl2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csmsl2Img.GetPixel(758, 100),//CSMSL2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CMITL2:
                    if (!GetCryoStatusPageAsync(out Bitmap cmitl2Img))
                        return false;
                    else
                    {
                        if (cmitl2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    cmitl2Img.GetPixel(858, 100),//CMITL2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.Cryo.Magnets.Magnet.CSITL2:
                    if (!GetCryoStatusPageAsync(out Bitmap csitl2Img))
                        return false;
                    else
                    {
                        if (csitl2Img == null) return false;
                        List<Color> colors = new List<Color>
                                {
                                    csitl2Img.GetPixel(948, 100)//CSITL2
                                };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetSixtyAmpPCPermitStatus()
        {
            if (!GetCryoStatusPageAsync(out Bitmap pcPermitImg))
                return false;
            else
            {
                List<Color> colors = new List<Color>()
                {
                    pcPermitImg.GetPixel(108, 403),
                    pcPermitImg.GetPixel(203, 403),
                    pcPermitImg.GetPixel(297, 403),
                    pcPermitImg.GetPixel(392, 402),
                    pcPermitImg.GetPixel(498, 402),
                    pcPermitImg.GetPixel(595, 402),
                    pcPermitImg.GetPixel(688, 403),
                    pcPermitImg.GetPixel(772, 402)
                };
                return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
            }
        }

        public static bool GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit pcpermit)
        {
            switch (pcpermit)
            {
                case Machine.Cryo.PCPermit.S12:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecone))
                        return false;
                    else
                    {
                        if (imgsecone == null) return false;
                        return imgsecone.GetPixel(108, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S23:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsectwo))
                        return false;
                    else
                    {
                        if (imgsectwo == null) return false;
                        return imgsectwo.GetPixel(203, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S34:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecthree))
                        return false;
                    else
                    {
                        if (imgsecthree == null) return false;
                        return imgsecthree.GetPixel(297, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S45:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecfour))
                        return false;
                    else
                    {
                        if (imgsecfour == null) return false;
                        return imgsecfour.GetPixel(392, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S56:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecfive))
                        return false;
                    else
                    {
                        if (imgsecfive == null) return false;
                        return imgsecfive.GetPixel(498, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S67:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecsix))
                        return false;
                    else
                    {
                        if (imgsecsix == null) return false;
                        return imgsecsix.GetPixel(595, 402) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S78:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsecseven))
                        return false;
                    else
                    {
                        if (imgsecseven == null) return false;
                        return imgsecseven.GetPixel(688, 403) == Color.FromArgb(255, 0, 255, 0);
                    }
                case Machine.Cryo.PCPermit.S81:
                    if (!GetCryoStatusPageAsync(out Bitmap imgseceight))
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

        public static bool GetRFStatus(Machine.RF.Sectors rf)
        {
            switch (rf)
            {
                case Machine.RF.Sectors.Sector1L4:
                    if (!GetCryoStatusPageAsync(out Bitmap imgseconeL))
                        return false;
                    else
                    {
                        if (imgseconeL == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgseconeL.GetPixel(100, 440),//CM1L4
                            imgseconeL.GetPixel(188, 440)//CS1L4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sectors.Sector1R4:
                    if (!GetCryoStatusPageAsync(out Bitmap imgseconeR))
                        return false;
                    else
                    {
                        if (imgseconeR == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgseconeR.GetPixel(480,440), //CM1R4
                            imgseconeR.GetPixel(570,440) //CS1R4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sectors.Sector2L4:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsectwoL))
                        return false;
                    else
                    {
                        if (imgsectwoL == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsectwoL.GetPixel(290, 440),//CM2L4
                            imgsectwoL.GetPixel(380, 440)//CS2L4
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Sectors.Sector2R4:
                    if (!GetCryoStatusPageAsync(out Bitmap imgsectwoR))
                        return false;
                    else
                    {
                        if (imgsectwoR == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            imgsectwoR.GetPixel(670, 440),//CM2R4
                            imgsectwoR.GetPixel(760, 440)//CS2R4
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool GetRFStatusIndividual(Machine.RF.Cryo cryoFlag)
        {
            switch (cryoFlag)
            {
                case Machine.RF.Cryo.CM1L4:
                    if (!GetCryoStatusPageAsync(out Bitmap cm1l4Img))
                        return false;
                    else
                    {
                        if (cm1l4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cm1l4Img.GetPixel(100, 440)//CM1L4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CS1L4:
                    if (!GetCryoStatusPageAsync(out Bitmap cs1l4Img))
                        return false;
                    else
                    {
                        if (cs1l4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cs1l4Img.GetPixel(188, 440)//CS1L4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CM2L4:
                    if (!GetCryoStatusPageAsync(out Bitmap cm2l4Img))
                        return false;
                    else
                    {
                        if (cm2l4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cm2l4Img.GetPixel(290, 440)//CM2L4
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CS2L4:
                    if (!GetCryoStatusPageAsync(out Bitmap cs2l4Img))
                        return false;
                    else
                    {
                        if (cs2l4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cs2l4Img.GetPixel(380, 440)//CS2L4
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CM1R4:
                    if (!GetCryoStatusPageAsync(out Bitmap cm1r4Img))
                        return false;
                    else
                    {
                        if (cm1r4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cm1r4Img.GetPixel(480,440), //CM1R4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CS1R4:
                    if (!GetCryoStatusPageAsync(out Bitmap cs1r4Img))
                        return false;
                    else
                    {
                        if (cs1r4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cs1r4Img.GetPixel(570,440) //CS1R4

                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CM2R4:
                    if (!GetCryoStatusPageAsync(out Bitmap cm2r4Img))
                        return false;
                    else
                    {
                        if (cm2r4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cm2r4Img.GetPixel(670, 440)//CM2R4
                        };
                        return !colors.Any(c => c != Color.FromArgb(255, 0, 255, 0));
                    }
                case Machine.RF.Cryo.CS2R4:
                    if (!GetCryoStatusPageAsync(out Bitmap cs2r4Img))
                        return false;
                    else
                    {
                        if (cs2r4Img == null) return false;
                        List<Color> colors = new List<Color>
                        {
                            cs2r4Img.GetPixel(760, 440)//CS2R4
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
