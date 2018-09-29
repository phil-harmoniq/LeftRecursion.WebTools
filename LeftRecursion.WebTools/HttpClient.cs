using System.Net;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace LeftRecursion.WebTools
{
    public class HttpClient : IHttpClient
    {
        private readonly IHttpClientLogger _logger;

        public HttpClient()
        {
            _logger = new ConsoleLogger();
        }

        public HttpClient(IHttpClientLogger logger)
        {
            _logger = logger;
        }

        public string Get(string url, Dictionary<string, string> headers = null)
        {
            using (var wc = new WebClient())
            {
                AddHeaders(wc, headers);
                try
                {
                    return wc.DownloadString(url);
                }
                catch (Exception e)
                {
                    _logger.Log($"HttpClient error: {e.Message}");
                    return null;
                }
            }
        }
        public async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            using (var wc = new WebClient())
            {
                AddHeaders(wc, headers);
                try
                {
                    return await wc.DownloadStringTaskAsync(url);
                }
                catch (Exception e)
                {
                    _logger.Log($"HttpClient error: {e.Message}");
                    return null;
                }
            }
        }

        private static void AddHeaders(WebClient webClient, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Keys.Count == 0)
                return;

            foreach (var key in headers.Keys)
            {
                webClient.Headers.Add(key, headers[key]);
            }
        }
    }
}
