using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HClient
{
    public class HContentService
    {
        public static HttpContent Create(string json)
        {
            HttpContent hContent = null;
            hContent = new StringContent(json, Encoding.UTF8, "application/json");

            return hContent;
        }

        public static HttpContent Create(HClientHeader _clientHeader)
        {
            if (_clientHeader == null || _clientHeader.postKeyValuePairs == null)
                return null;

            HttpContent hContent = null;
            var param = "";
            foreach (var ss in _clientHeader.postKeyValuePairs)
            {
                param += $"{ss.Key}={ss.Value}&";
            }
            hContent = new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded");

            return hContent;
        }

        public static MultipartFormDataContent Create(HMultipart multipart, HClientHeader clientHeader)
        {
            var disposition = EncodeHelper.CreateDisposition(multipart);
            var mContent = new MultipartFormDataContent(multipart.Boundary);
            //フォームデータを追加
            if (clientHeader != null && clientHeader.postKeyValuePairs != null)
                foreach (var header in clientHeader.postKeyValuePairs)
                    mContent.Add(new StringContent(header.Value), header.Key);
            //ファイルを追加
            var fileContent = new StreamContent(File.OpenRead(multipart.filePath));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(multipart.ContentType);
            fileContent.Headers.Add("Content-Disposition", disposition);
            mContent.Add(fileContent);

            return mContent;
        }
    }
}