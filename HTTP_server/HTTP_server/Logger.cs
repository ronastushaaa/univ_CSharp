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
        public static void Log(string who, string msg) 
        {
            OnLog?.Invoke(who, $"{DateTime.Now:HH:mm:ss}   {msg}");
        }
    }
}
