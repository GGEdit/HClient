using System.IO;
using System.Text;

namespace HClient
{
    public class EncodeHelper
    {
        public static string CreateDisposition(HMultipart multipart)
        {
            var fileInfo = new FileInfo(multipart.filePath);
            var headerValue = $"{multipart.DispositionHeaderValue}; name=\"{multipart.DispositionHeaderName}\"; filename=\"{multipart.DispositionHeaderFileName}\"";
            var headerValueByteArray = Encoding.UTF8.GetBytes(headerValue);
            var encHeaderValue = new StringBuilder();
            foreach (var b in headerValueByteArray)
            {
                encHeaderValue.Append((char)b);
            }
            return encHeaderValue.ToString();
        }
    }
}