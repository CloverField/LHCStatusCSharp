using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using RetrieveBitmap;
using Tesseract;
using LHCEnums;

namespace OCR
{
    public class LHCOCR
    {
        const string tessDataDir = @"./tessdata";

        private static bool GetVistarPageAsync(string webpage, out Bitmap lhc1Img)
        {
            if (!Retrieve.GetBitMap(webpage, out lhc1Img))
                return false;
            return true;
        }

        public static bool ProcessData(Machine.Vistar.Pages vistar)
        {
            string webPage = string.Empty;
            switch (vistar)
            {
                case Machine.Vistar.Pages.LHC_Configuration:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhcconfig.png";
                    break;
                case Machine.Vistar.Pages.LHC_Coordination:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhccoord.png";
                    break;
                case Machine.Vistar.Pages.LHC_Cryogenics:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhc2.png";
                    break;
                case Machine.Vistar.Pages.LHC_EXP_Magnets:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhcexpmag.png";
                    break;
                case Machine.Vistar.Pages.LHC_Luminosity:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhclumi.png?";
                    break;
                case Machine.Vistar.Pages.LHC_Operation:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhc3.png";
                    break;
                case Machine.Vistar.Pages.LHC_Page_1:
                    webPage = "https://vistar-capture.web.cern.ch/vistar-capture/lhc1.png";
                    break;
                default:
                    break;
            }

            if (webPage == string.Empty) return false;
            if (!GetVistarPageAsync(webPage,out Bitmap bitmap))
                return false;
            else
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                using (var image = Pix.LoadTiffFromMemory(ImageToByte2(bitmap)))
                using (var page = engine.Process(image))
                {
                    string text = page.GetText();
                    if (text != string.Empty)
                    {
                        Console.WriteLine(text);
                        return true;
                    }
                }
            }
            return false;
        }

        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                return stream.ToArray();
            }
        }
    }
}
