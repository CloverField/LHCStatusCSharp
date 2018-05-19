using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveBitmap
{
    public static class Retrieve
    {
        public static bool GetBitMap(string address, out Bitmap bitmap)
        {
            using (WebClient wc = new WebClient())
            {
                bitmap = null;
                var result = wc.DownloadDataTaskAsync(address);
                if (!result.Wait(3000))
                    return false;

                if (result.IsFaulted)
                {
                    if (result.Exception != null)
                    {
                        Console.WriteLine("Failed to get Bitmap with Exception: {0}", result.Exception);
                        return false;
                    }
                    Console.WriteLine("Failed to retrieve  BitMap");
                    return false;
                }

                bitmap = (Bitmap)Bitmap.FromStream(new MemoryStream(result.Result));
                return true;
            }
        }
    }
}
