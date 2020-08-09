using System.Net.Http;

namespace HClient
{
    public class HClientService
    {
        public static HttpClient Create(HttpClient _client, HClientCookie _clientCookie, HClientHeader _clientHeader)
        {
            HttpClient client = _client;
            client.DefaultRequestHeaders.Clear();
            //Except:100-continueを送らないようにする
            client.DefaultRequestHeaders.ExpectContinue = false;
            if (_clientCookie != null && _clientCookie.CookieDictionary != null)
                foreach (var cookie in _clientCookie.CookieDictionary)
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", $"{cookie.Key}={cookie.Value}");

            if (_clientHeader != null)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", _clientHeader.Accept);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", _clientHeader.Referer);
                client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", _clientHeader.UserAgent);
            }

            if (_clientHeader != null && _clientHeader.headersKeyValuePairs != null)
                foreach (var header in _clientHeader.headersKeyValuePairs)
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);

            return client;
        }
    }
}