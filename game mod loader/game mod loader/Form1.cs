using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace game_mod_loader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Write Data6.pak
            byte[] file1 = Properties.Resources.Data6;
            File.WriteAllBytes(textBox1.Text + "\\DW\\Data6.pak", file1);
            //Write dsound.dll
            byte[] file3 = Properties.Resources.dsound;
            File.WriteAllBytes(textBox1.Text + "\\dsound.dll", file3);
            //Create dide_mod.ini
            using (StreamWriter sw = new StreamWriter(textBox1.Text + "\\dide_mod.ini"))
            {
                sw.Write("[General]\nEnableMod = 1\nEnableLogging = 0\nLogFile = dide_mod_log.ini\n[Features]\nDeveloperMenu = 0\nCustomPak = 1\n[CustomPak]\n");
                sw.WriteLine(textBox1.Text + "\\DW\\Data6.pak=1");
            }
            MessageBox.Show("Successfully Loaded!", "Mod Loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete Data6.pak
            File.Delete(textBox1.Text + "\\DW\\Data6.pak");
           //Delete dide_mod.ini
            File.Delete(textBox1.Text + "\\dide_mod.ini");
            //Delete dsound.dll
            File.Delete(textBox1.Text + "\\dsound.dll");
            MessageBox.Show("Successfully Unloaded!", "Mod Unloaded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Launch Dying Light
            MessageBox.Show("Launching Dying Light", "Launching...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(textBox1.Text + "\\DyingLightGame.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
