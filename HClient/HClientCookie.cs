using System.Collections.Generic;

namespace HClient
{
    public class HClientCookie
    {
        public Dictionary<string, string> CookieDictionary;

        public HClientCookie()
        {
            CookieDictionary = new Dictionary<string, string>();
        }

        public HClientCookie(string _key, string _value)
        {
            CookieDictionary = new Dictionary<string, string>();
            CookieDictionary.Add(_key, _value);
        }

        public void AddCookie(string _key, string _value)
        {
            CookieDictionary.Add(_key, _value);
        }

        public void SetCookie(string _key, string _value)
        {
            CookieDictionary.Clear();
            CookieDictionary.Add(_key, _value);
        }

        public void SetCookie(Dictionary<string, string> _cookieKeyValuePairs)
        {
            if (_cookieKeyValuePairs == null)
                return;

            CookieDictionary.Clear();
            foreach (var dic in _cookieKeyValuePairs)
                CookieDictionary.Add(dic.Key, dic.Value);
        }

        public void Clear()
        {
            if (CookieDictionary != null)
                CookieDictionary.Clear();
        }
    }
}