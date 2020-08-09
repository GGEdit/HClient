using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HClient
{
    public class HResponseService
    {
        public static List<string> GetSetCookies(HttpResponseMessage message)
        {
            if (message == null || message.Headers == null)
                return null;

            var headerCollection = message.Headers;
            if (headerCollection.TryGetValues("Set-Cookie", out IEnumerable<string> values))
                return values.ToList();

            return null;
        }
    }
}