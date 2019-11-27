using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{
    public partial class PaintForm : Form //实现绘制运行图的界面
    {
        Button a;
        public PaintForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 650);
        }
    }
}
