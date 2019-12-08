using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Monkeys_Timetable
{
    class PaintTool//封装绘制运行图所需的方法
    {
        public void TimetableFrame(double WinWidth,double WinHeight,double TotalMile,List<double> StationMile, Graphics gs)
        {
            Point p1 = new Point();
            Point p2 = new Point();
            Pen pp1 = new Pen(Color.Green, 2);
            double Width = WinWidth - 70;
            double Height = WinHeight - 30;
            p1.X = 60;
            p1.Y = 10;
            p2.X = 60;
            p2.Y = (int)(60 + Height);
            double add = Width / 18;
            for (int i=6; i<=24;i++)
            {
                gs.DrawLine(pp1, p1, p2);
                p1.X = (int)(p1.X + add);
                p2.X = (int)(p2.X + add);
            }
            /////////////////////////////////////////////////小时线
            pp1 = new Pen(Color.Green, 1);
            p1.X = 60;
            p1.Y = 10;
            p2.X = 60;
            p2.Y = (int)(60 + Height);
            add = Width / (18*6);
            for (int j = 6*6; j <= 24*6 && j%6 != 0; j++)
            {
                gs.DrawLine(pp1, p1, p2);
                p1.X = (int)(p1.X + add);
                p2.X = (int)(p2.X + add);
            }
            ////////////////////////////////////////////////十分格线
            pp1 = new Pen(Color.Green, 1);
            p1.X = 60;
            p2.X = (int)(60+Width);
            int n = StationMile.Count();
            for (int k=1;k<=n;k++)
            {
                p1.Y =(int)(10+ Height * StationMile[k] / TotalMile);
                p2.Y =(int)(10+ Height * StationMile[k] / TotalMile);
                gs.DrawLine(pp1, p1, p2);
            }
        }//运行图框架图
        public void TrainLine()
        {

        }//运行线铺画方法

    }
}
