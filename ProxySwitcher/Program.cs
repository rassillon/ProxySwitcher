﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxySwitcher {
    static class Program {
        public static string ApplicationName = "ProxySwitcher";

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class ProxyManager {

        private string URL, port;

        public ProxyManager() {
            URL = getProxyURL();
            port = getProxyPort();
        }

        public string getProxyURL() {
            string res = "";
            res = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", "");
            if (res.Length > 0) {
                URL = res.Substring(0, res.IndexOf(":"));
                res = URL;
            }
            return res;
        }

        public string getProxyPort() {
            string res = "";
            res = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", "");
            if (res.Length > 0) {
                URL = res.Substring(res.IndexOf(":") + 1);
                res = URL;
            }
            return res;
        }

        public void setProxy(string proxy, string port) {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyServer", proxy + ":" + port);
        }

        public bool getProxyState() {
            int res;
            bool resb = false;
            res = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyEnable", 0);

            if (res == 1) {
                resb = true;
            }
            return resb;
        }
                
        public void setProxyState(bool state) {
            int res = 0;
            if (state) res=1;
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings",
                "ProxyEnable", res);
        }
    }

    public class IconExtractor
    {

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
    
        }
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
    
    }
   
}
