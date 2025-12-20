using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_server
{
    public class HttpRequest
    {
        //private string FRaw;
        private string FMethod;
        private string FPath;
        private string FVer;
        private Dictionary <string, string> FHeaders;
        private string FJsonBody;

        private string FValue1;
        private string FValue2;
        private string FValue3;

        private HttpRequest(string method, string path, string ver, Dictionary <string, string> headers, string jsonBody, string a, string b, string c) 
        {
            FMethod = method;
            FPath = path;
            FVer = ver;
            FHeaders = headers;
            FJsonBody = jsonBody;
            FValue1 = a;
            FValue2 = b;
            FValue3 = c;
    }

        public string Method { get { return FMethod; } }
        public string Path { get { return FPath; } }
        public string Ver { get { return FVer; } }
        public Dictionary<string, string> Headers { get { return FHeaders; } }
        public string JsonBody { get { return FJsonBody; } }
        public string A { get { return FValue1; } }
        public string B { get { return FValue2; } }
        public string C { get { return FValue3; } }



        public string searchBody(string req)
        {
            int index = req.IndexOf("\r\n\r\n");
            string body = req.Substring(index + 4);
            return body.Trim();
        }

        public static HttpRequest TryParse(string req)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            string[] lines = req.Split(new[] {"\r\n"}, StringSplitOptions.None);

            string[] elements = lines[0].Split(' ');
            string method = elements[0].Trim();
            string path = elements[1].Trim();
            string ver = elements[2].Trim();
            //string path = string.Join("/", elements, 1, elements.Length - 2).Trim();
            for (int i = 1; i < lines.Length; i++)
            {
                int index = lines[i].IndexOf(':');
                if (index > 0)
                {
                    string key = lines[i].Substring(0, index).Trim();
                    string value = lines[i].Substring(index + 1).Trim();
                    headers[key] = value;
                }
            }
            string body = "";
            int bodyIndex = req.IndexOf("\r\n\r\n");
            if (bodyIndex >= 0)
            {
                body = req.Substring(bodyIndex + 4).Trim();
            }
            string jsonBody = Encoding.UTF8.GetString(Convert.FromBase64String(body));
            string v1 = "";
            string v2 = "";
            string v3 = "";
            int aStart = jsonBody.IndexOf("\"A\":\"") + 5;  
            if (aStart > 5)
            {
                int aEnd = jsonBody.IndexOf('"', aStart);
                if (aEnd > aStart)
                {
                    v1 = jsonBody.Substring(aStart, aEnd - aStart);
                }
            }
            int bStart = jsonBody.IndexOf("\"B\":\"") + 5;
            if (bStart > 5)
            {
                int bEnd = jsonBody.IndexOf('"', bStart);
                if (bEnd > bStart)
                {
                    v2 = jsonBody.Substring(bStart, bEnd - bStart);
                }
            }
            int cStart = jsonBody.IndexOf("\"C\":\"") + 5;
            if (cStart > 5)
            {
                int cEnd = jsonBody.IndexOf('"', cStart);
                if (cEnd > cStart)
                {
                    v3 = jsonBody.Substring(cStart, cEnd - cStart);
                }
            }
            HttpRequest r = new HttpRequest(method, path, ver, headers, jsonBody, v1, v2, v3);
            return r;
        }
    }
}
