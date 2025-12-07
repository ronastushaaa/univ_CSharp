using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_server
{
    public class HttpRequest
    {
        private string FRaw;
        private string FMethod;
        private string FPath;
        private string FVer;
        private Dictionary <string, string> FHeaders;

        private HttpRequest(string method, string path, string ver, Dictionary <string, string> headers)
        {
            FMethod = method;
            FPath = path;
            FVer = ver;
            FHeaders = headers;
        }

        public string Method { get { return FMethod; } }
        public string Path { get { return FPath; } }
        public string Ver { get { return FVer; } }
        public Dictionary<string, string> Headers { get { return FHeaders; } }


        public string searchBody(string req)
        {
            int index = req.IndexOf("\r\n\r\n");
            string body = req.Substring(index + 4);
            return body.Trim();
        }

        public static HttpRequest TryParse(string req)
        {
            //string method = "";
            //string path = "";
            string ver = "";
            Dictionary<string, string> headers = new Dictionary<string, string>();


            string[] elements = req.Split('/');
            string method = elements[0].Trim();
            string general = elements[elements.Length - 1].Trim();
            string path = string.Join("/", elements, 1, elements.Length - 2).Trim();
            if (!string.IsNullOrEmpty(general))
            {
                int i = general.IndexOf("\r\n");
                if (i >= 0)
                {
                    ver = general.Substring(0, i).Trim();
                    string headers_split = general.Substring(i + 2);
                    string[] headerLines = headers_split.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0;  j< headerLines.Length; j++)
                    {
                        string[] c = headerLines[j].Split(':');
                        string key = c[0].Trim();
                        string value = c[1].Trim();
                        headers.Add(key, value);
                    }
                }
            }
            HttpRequest r = new HttpRequest(method, path, ver, headers);

        }
       
    }
}
