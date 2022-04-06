using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using static WindowsFormsAppDWM.DWM;

namespace WindowsFormsAppDWM
{
    public partial class FormMain : Form
    {
        private IntPtr reg;
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            buttonUnReg_Click(null, null);
            Process[] p = Process.GetProcessesByName(textBoxWindow.Text);
            RegDWM(this.Handle, p[0].MainWindowHandle, panel1, out reg);
        }

        private void buttonUnReg_Click(object sender, EventArgs e)
        {
            if(reg != null)
            {
                DwmUnregisterThumbnail(reg);
            }
        }

        private void buttonCap_Click(object sender, EventArgs e)
        {
            FormCap cap = new FormCap(CapControl(this.panel1));
            cap.ShowDialog();
        }

        private Bitmap CapControl(Control control)
        {
            Bitmap bit = new Bitmap(control.Width, control.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.CopyFromScreen(control.PointToScreen(Point.Empty), Point.Empty, control.Size);//只保存某个控件（这里是panel游戏区）
            return bit;
        }
    }

}
