using System;
using System.Windows.Forms;

namespace OpenApp
{
    public partial class OpenAppWin : Form
    {
        public OpenAppWin()
        {
            InitializeComponent();
        }

        private void OpenAppWin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式.
            this.WindowState = FormWindowState.Maximized;    //最大化窗体.
        }
    }
}
