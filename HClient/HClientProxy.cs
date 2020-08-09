using System.Net;

namespace HClient
{
    public class HClientProxy
    {
        public WebProxy wProxy;

        public HClientProxy()
        {
            wProxy = new WebProxy();
        }

        public HClientProxy(string _ip, int _port)
        {
            wProxy = new WebProxy(_ip, _port);
        }

        public void SetProxy(string _ip, int _port)
        {
            wProxy = new WebProxy(_ip, _port);
        }

        public void ClearProxy()
        {
            wProxy = null;
        }
    }
}
