using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxySwitcher
{
    public partial class Form1 : Form
    {
        ProxyManager pm;

        public Form1()
        {
            InitializeComponent();
            pm = new ProxyManager();
            updatePanel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = pm.getProxyURL();
            textBox2.Text = pm.getProxyPort();
            label4.Text = "Program loaded successfully.";
            label4.ForeColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pm.getProxyURL() == "")
            {
                label4.Text = "ERROR: Input Proxy!";
                label4.ForeColor = Color.Red;
            }
            else
            {
                pm.setProxyState(true);
                label4.Text = "Proxy Enabled succesfully.";
                label4.ForeColor = Color.Green;
            }
            updatePanel();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pm.setProxyState(false);
            label4.Text = "Proxy Disabled successfully.";
            label4.ForeColor = Color.Green;
            updatePanel();
        }

        private void updatePanel()
        {
            if (pm.getProxyState())
            {
                panel2.BackColor = Color.Green;
                label1.Text = "ENABLED";
                
            }
            else
            {
                panel2.BackColor = Color.Red;
                label1.Text = "DISABLED";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text, t2 = textBox2.Text;
            if (t1.Contains("") )
            {
                label4.Text = "ERROR: Input Proxy!";
                label4.ForeColor = Color.Red;
            }
            else
            {
                pm.setProxy(textBox1.Text, textBox2.Text);
                label4.Text = "Proxy set successfully";
                label4.ForeColor = Color.Green;
            }
            
        }

    }
}
