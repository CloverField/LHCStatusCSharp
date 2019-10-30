using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Net.Http;
using System.Threading;

namespace RetrieveBitmap
{
    public static class RetriveAsync
    {
        public static async Task<Bitmap> GetBitmapAsync(string address, CancellationToken cancellationToken)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(3000);

            var linkedToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken,cts.Token).Token;

            if (linkedToken.IsCancellationRequested)
            {
                return await Task.FromCanceled<Bitmap>(linkedToken)
                    .ConfigureAwait(false);
            }

            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.GetAsync(address, linkedToken)
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync()
                        .ConfigureAwait(false);

                    return await Task.FromResult((Bitmap)Image.FromStream(content))
                        .ConfigureAwait(false);
                }

                return await Task.FromException<Bitmap>(new FileNotFoundException("Unable to download image."))
                    .ConfigureAwait(false);
            }
        }
    }
}
