using System.Drawing;
using System.IO;
using System.Net.Http;

namespace HClient
{
    public class HClientImgResponse : HClientResponse
    {
        public Image Image;
        public Stream Stream;

        public HClientImgResponse(HttpResponseMessage responseMessage) : base(responseMessage)
        {
            CreateInstance(responseMessage);
        }

        protected new async void CreateInstance(HttpResponseMessage responseMessage)
        {
            if (responseMessage == null)
                return;

            ResponseMessage = responseMessage;
            Content = null;
            Stream = await ResponseMessage.Content.ReadAsStreamAsync();
            Image = Image.FromStream(Stream);
            ResponseCode = ResponseMessage.StatusCode;
            ResponseCodeString = ResponseMessage.StatusCode.ToString();
            SetCookies = HResponseService.GetSetCookies(ResponseMessage);
        }
    }
}