using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTP_server
{
    static class Logger
    {
        public static event Action<string, string> OnLog;
        public static event Action<string, string, string> InfoLog;
        public static event Func <Dictionary<string, string>> DEFRequested;
        public static void Log(string who, string msg) 
        {
            OnLog?.Invoke(who, $"{DateTime.Now:HH:mm:ss}   {msg}");
        }
        public static void Log_2(string a, string b, string c)
        {
            InfoLog?.Invoke(a, b, c);
        }

        public static Dictionary<string, string> GetMap()
        {
            return DEFRequested?.Invoke();
        }
    }
}
