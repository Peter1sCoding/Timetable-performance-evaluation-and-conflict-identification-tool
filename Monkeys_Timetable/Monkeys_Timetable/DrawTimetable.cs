using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{

    //运行图界面类，实现输入到发时刻数据后，绘制可缩放的运行图，最好站名线根据用户输入确定
    public partial class DrawTimetable : Form
    {      
        public DrawTimetable()
        {
            InitializeComponent();         
        }
    }
}
