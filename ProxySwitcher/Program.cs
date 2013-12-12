using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxySwitcher
{
    static class Program
    {
        public static string ApplicationName = "ProxySwitcher";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }

    public class ProxyManager
    {

        private string URL, port;

        public ProxyManager()
        {

        }

        public string getProxyURL()
        {
            string res = "";
            res = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", "");
            if (res.Length > 0) {
                URL = res.Substring(0, res.IndexOf(":"));
                res = URL;
            }
            return res;
        }

        public string getProxyPort()
        {
            string res = "";
            res = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", "");
            if (res.Length > 0)
            {
                URL = res.Substring(res.IndexOf(":") + 1);
                res = URL;
            }
            return res;

        }

        public void setProxy(string proxy)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", proxy);
        }

        public void setProxy(string proxy, string port)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", proxy + ":" + port);
        }

        public bool getProxyState()
        {
            int res;
            bool resb = false;
            res = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyEnable", 0);

            if (res == 1)
            {
                resb = true;
            }
            return resb;
        }
                
        public void setProxyState(bool state)
        {
            int res = 0;
            if (state) res=1;
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyEnable", res);
        }

    }
}
