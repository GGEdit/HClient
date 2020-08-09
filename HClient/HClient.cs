using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HClient
{
    public class HClient
    {
        private HttpClient client;
        public HClientResponse hResponse;
        public HClientImgResponse hImgResponse;

        public HClient(bool allowAutoRedirect)
        {
            client = CreateInstance(allowAutoRedirect);
        }

        public HClient(bool allowAutoRedirect, HClientProxy _clientProxy)
        {
            client = CreateInstance(allowAutoRedirect, true, _clientProxy.wProxy);
        }

        private HttpClient CreateInstance(bool allowAutoRedirect, bool useProxy = false, WebProxy proxy = null)
        {
            var handler = new HttpClientHandler()
            {
                UseCookies = false,
                UseProxy = useProxy,
                Proxy = proxy,
                AllowAutoRedirect = allowAutoRedirect,
            };
            var client = new HttpClient(handler);
            return client;
        }

        private (HttpClient, HttpContent) Create(HttpClient _client, HClientCookie _clientCookie, HClientHeader _clientHeader, string _json = null)
        {
            HttpClient client = null;
            HttpContent hContent = null;
            client = HClientService.Create(_client, _clientCookie, _clientHeader);
            if (_json != null)
                hContent = HContentService.Create(_json);
            else
                hContent = HContentService.Create(_clientHeader);
            return (client, hContent);
        }

        private (HttpClient, MultipartFormDataContent) Create(HttpClient _client, HClientCookie _clientCookie, HClientHeader _clientHeader, HMultipart multipart)
        {
            HttpClient client = null;
            MultipartFormDataContent content = null;
            client = HClientService.Create(_client, _clientCookie, _clientHeader);
            content = HContentService.Create(multipart, _clientHeader);

            return (client, content);
        }

        public async Task<HClientResponse> Get(string _requestUrl, HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
        {
            try
            {
                var instance = Create(client, _clientCookie, _clientHeader);
                client = instance.Item1;
                var resultMessage = await client.GetAsync(_requestUrl);
                hResponse = new HClientResponse(resultMessage);
            }
            catch (Exception ex)
            {
                hResponse = null;
                throw new Exception(ex.Message);
            }
            return hResponse;
        }

        public async Task<HClientImgResponse> GetImage(string _requestUrl, HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
        {
            try
            {
                var instance = Create(client, _clientCookie, _clientHeader);
                client = instance.Item1;
                var resultMessage = await client.GetAsync(_requestUrl);
                hImgResponse = new HClientImgResponse(resultMessage);
            }
            catch(Exception ex)
            {
                hImgResponse = null;
                throw new Exception(ex.Message);
            }
            return hImgResponse;
        }

        public async Task<HClientResponse> Post(string _requestUrl, HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
        {
            try
            {
                var instance = Create(client, _clientCookie, _clientHeader);
                client = instance.Item1;
                var content = instance.Item2;
                var resultMessage = await client.PostAsync(_requestUrl, content);
                hResponse = new HClientResponse(resultMessage);
            }
            catch (Exception ex)
            {
                hResponse = null;
                throw new Exception(ex.Message);
            }
            return hResponse;
        }

        public async Task<HClientResponse> Post(string _requestUrl, HClientCookie _clientCookie = null, HClientHeader _clientHeader = null, string _json = null)
        {
            try
            {
                var instance = Create(client, _clientCookie, _clientHeader, _json);
                client = instance.Item1;
                var content = instance.Item2;
                var resultMessage = await client.PostAsync(_requestUrl, content);
                hResponse = new HClientResponse(resultMessage);
            }
            catch (Exception ex)
            {
                hResponse = null;
                throw new Exception(ex.Message);
            }
            return hResponse;
        }

        public async Task<HClientResponse> Post(string _requestUrl, HClientCookie _clientCookie = null, HClientHeader _clientHeader = null, HMultipart multipart = null)
        {
            try
            {
                var instance = Create(client, _clientCookie, _clientHeader, multipart);
                client = instance.Item1;
                var content = instance.Item2;
                var resultMessage = await client.PostAsync(_requestUrl, content);
                hResponse = new HClientResponse(resultMessage);
            }
            catch (Exception ex)
            {
                hResponse = null;
                throw new Exception(ex.Message);
            }
            return hResponse;
        }
    }
}