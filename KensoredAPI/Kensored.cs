using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

/// <summary>
/// Kensored API namespace
/// </summary>
namespace KensoredAPI
{
    /// <summary>
    /// Kensored API
    /// </summary>
    public static class Kensored
    {
        /// <summary>
        /// Serializer
        /// </summary>
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(KensoredResult), new DataContractJsonSerializerSettings()
        {
            UseSimpleDictionaryFormat = true
        });

        /// <summary>
        /// Request kensored asyncronous
        /// </summary>
        /// <param name="uri">URI</param>
        /// <returns>Kensored result task</returns>
        /// <exception cref="AggregateException">Aggregate exception</exception>
        /// <exception cref="WebException">Web exception</exception>
        /// <exception cref="SerializationException">Serialization exception</exception>
        public static Task<KensoredResult> RequestKensoredAsync(Uri uri)
        {
            Task<KensoredResult> ret = new Task<KensoredResult>(() =>
            {
                KensoredResult r = null;
                if (uri != null)
                {
                    using (WebClientEx wc = new WebClientEx(3000))
                    {
                        wc.Headers.Set(HttpRequestHeader.ContentType, "text/html");
                        wc.Headers.Set(HttpRequestHeader.Accept, "text/html, */*");
                        wc.Headers.Set(HttpRequestHeader.UserAgent, "Mozilla/3.0 (compatible; Kensored API)");
                        using (MemoryStream stream = new MemoryStream(wc.DownloadData(uri)))
                        {
                            r = serializer.ReadObject(stream) as KensoredResult;
                        }
                    }
                }
                if (r == null)
                {
                    r = new KensoredResult();
                }
                return r;
            });
            ret.Start();
            return ret;
        }
    }
}
