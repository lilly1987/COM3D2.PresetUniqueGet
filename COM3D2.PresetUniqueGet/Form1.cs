using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COM3D2.PresetUniqueGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PresetUtill.PresetDirectory = textBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Wear);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PresetUtill.PresetDirectory = ((TextBox)sender).Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Body);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.All);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Wear);
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Body);
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.All);
        }
    }


}
