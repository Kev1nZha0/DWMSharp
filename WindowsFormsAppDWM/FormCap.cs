using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDWM
{
    public partial class FormCap : Form
    {
        public FormCap(Bitmap pic)
        {
            InitializeComponent();
            pictureBox1.Image = pic;
        }
    }
}
