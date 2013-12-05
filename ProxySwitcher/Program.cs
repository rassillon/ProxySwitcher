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

        public ProxyManager()
        {

        }

        public string getProxyURL()
        {
            string res = "";
            res = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", "");
            Console.WriteLine(res);
            return res;
        }
        
        public void setProxyURL(string proxy)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", proxy);
        }

        public bool getProxyState()
        {
            bool res;
            res = (bool)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyEnable", 0);

            return res;
        }
                
        public void setProxyState(bool state)
        {
            int res = 0;
            if (state) res=1;
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", res);
        }

    }
}
