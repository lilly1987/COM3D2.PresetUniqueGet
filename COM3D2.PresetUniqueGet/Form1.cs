using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            //this.AllowDrop = true;

            //this.DragEnter += new DragEventHandler(Form1_DragEnter);

            //this.DragDrop += new DragEventHandler(Form1_DragDrop);

            MyLog.l= label1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PresetUtill.PresetDirectory = ((TextBox)sender).Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyLog.Log("처리 시작");
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Wear);
            MyLog.Log("처리 완료");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MyLog.Log("처리 시작");
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Body);
            MyLog.Log("처리 완료");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyLog.Log("처리 시작");
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.All);
            MyLog.Log("처리 완료");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyLog.Log("처리 시작");
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Wear);
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.Body);
            PresetUtill.GetUniqueProcSub(Preset.PresetListLoad(), PresetType.All);
            MyLog.Log("처리 완료");
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
            MyLog.Log("directoryName:" + directoryName[0]);
            //string[] dirs = Directory.GetDirectories(directoryName[0]);
            //MyLog.Log("dirs:" + dirs[0]);
            PresetUtill.PresetDirectory = ((TextBox)sender).Text
             = directoryName[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
