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
        List<int> TimeX = new List<int>();
        List<int> staY = new List<int>();

        public void TimetableFrame(double WinWidth, double WinHeight, double TotalMile, List<double> StationMile, Graphics gs)
        {
            Point p1 = new Point();
            Point p2 = new Point();
            Pen pp1 = new Pen(Color.Green, 1);
            Pen pp2 = new Pen(Color.Green, 2);
            double Width = WinWidth - 35;
            double Height = WinHeight - 15;
            p1.X = 30;
            p1.Y = 5;
            p2.X = 30;
            int a = StationMile.Count;
            p2.Y = (int)(5 + Height * StationMile[a - 1] / TotalMile);
            double add1 = Width / (18 * 60);
            int add = (int)Math.Round(add1);
            int xx = 0;
            for (int j = 6 * 60; j < 1440; j++)
            {
                if(j%10==0)
                {
                    if (j % 6 == 0)
                    {
                        gs.DrawLine(pp2, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (int)(p1.X + add);
                        p2.X = (int)(p2.X + add);
                    }
                    else
                    {
                        gs.DrawLine(pp1, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (int)(p1.X + add);
                        p2.X = (int)(p2.X + add);
                    }
                }
                else
                {
                    TimeX.Add(p1.X);
                    p1.X = (int)(p1.X + add);
                    p2.X = (int)(p2.X + add);
                }
            }
            xx = p1.X-add;
            ////////////////////////////////////////////////以上是时间线
            pp1 = new Pen(Color.Green, 1);
            p1.X = 30;
            p2.X = xx;
            int n = StationMile.Count();
            for (int k = 0; k < n; k++)
            {
                p1.Y = (int)(5 + Height * StationMile[k] / TotalMile);
                p2.Y = (int)(5 + Height * StationMile[k] / TotalMile);
                gs.DrawLine(pp1, p1, p2);
                staY.Add(p1.Y);
            }
        }//运行图框架图
        public void TrainLine(Graphics gs,List<Train> TrainList,List<string> StaionList)
        {
            Pen pp = new Pen(Color.Red, 1);
            Point p1 = new Point();
            Point p2 = new Point();
            foreach (Train train in TrainList)
            {
                int a = train.staList.Count;
                for (int i=0;i<a-1;i++)
                {
                    if (StaionList.IndexOf(train.staList[i]) != -1&& StaionList.IndexOf(train.staList[i + 1]) != -1)
                    {                    
                        int index1 = StaionList.IndexOf(train.staList[i]);
                        int index2 = StaionList.IndexOf(train.staList[i + 1]);
                        int i1 = train.MinuteDic[train.staList[i]][1];
                        int i2 = train.MinuteDic[train.staList[i + 1]][0];
                        p1.X = TimeX[i1];
                        p2.X = TimeX[i2];
                        p1.Y = staY[index1];
                        p2.Y = staY[index2];
                        gs.DrawLine(pp, p1, p2);
                    }
                }
                for (int i = 1; i < a - 1; i++)
                {
                    if (StaionList.IndexOf(train.staList[i]) != -1)
                    {
                        int index1 = StaionList.IndexOf(train.staList[i]);
                        int i1 = train.MinuteDic[train.staList[i]][0];
                        int i2 = train.MinuteDic[train.staList[i]][1];
                        p1.X = TimeX[i1];
                        p2.X = TimeX[i2];
                        p1.Y = staY[index1];
                        p2.Y = staY[index1];
                        gs.DrawLine(pp, p1, p2);
                    }
                    
                }
            }
        }//运行线铺画方法

    }
}
