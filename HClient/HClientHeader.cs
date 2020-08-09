﻿using System.Collections.Generic;

namespace HClient
{
    public class HClientHeader
    {
        public Dictionary<string, string> headersKeyValuePairs;
        public Dictionary<string, string> postKeyValuePairs;

        public string ContentType = "";
        public string Accept = "";
        public string Referer = "";
        public string UserAgent = "";

        public HClientHeader()
        {
            headersKeyValuePairs = new Dictionary<string, string>();
            postKeyValuePairs = new Dictionary<string, string>();
        }
        
        public void AddHeader(string _key, string _value)
        {
            headersKeyValuePairs.Add(_key, _value);
        }

        public void AddHeader(Dictionary<string, string> _headersKeyValuePairs)
        {
            if (_headersKeyValuePairs != null)
                foreach (var data in _headersKeyValuePairs)
                    headersKeyValuePairs.Add(data.Key, data.Value);
        }

        public void SetHeader(Dictionary<string, string> _headersKeyValuePairs)
        {
            if (_headersKeyValuePairs != null)
                headersKeyValuePairs = new Dictionary<string, string>(_headersKeyValuePairs);
        }

        public void ClearHeader()
        {
            if (headersKeyValuePairs != null)
                headersKeyValuePairs.Clear();
        }
        
        public void AddParam(Dictionary<string, string> _postKeyValuePairs)
        {
            foreach (var data in _postKeyValuePairs)
                postKeyValuePairs.Add(data.Key, data.Value);
        }

        public void AddParam(string _key, string _value)
        {
            postKeyValuePairs.Add(_key, _value);
        }

        public void SetParam(Dictionary<string, string> _postKeyValuePairs)
        {
            if (_postKeyValuePairs == null)
                return;

            postKeyValuePairs = new Dictionary<string, string>(_postKeyValuePairs);
        }

        public void ClearParam()
        {
            if (postKeyValuePairs != null)
                postKeyValuePairs.Clear();
        }
    }
}
