using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_client
{
    static class Logger
    {
        public static event Action<string, string, string> InfoLog;
        public static event Action<string, string> OnLog;
        public static void Log(string who, string msg)
        {
            OnLog?.Invoke(who, $"{DateTime.Now:HH:mm:ss}  {msg}");
        }
        public static void Log_2(string a, string b, string c)
        {
            InfoLog?.Invoke(a, b, c);
        }
    }
}
