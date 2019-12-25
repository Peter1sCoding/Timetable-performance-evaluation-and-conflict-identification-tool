using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace Monkeys_Timetable
{
    public class PaintTool//封装绘制运行图所需的方法
    {
        Font font=new Font("宋体",8f);
        Brush brush=new SolidBrush(Color.Green);
        StringFormat SF = new StringFormat();
        StringFormat SF1 = new StringFormat();

        List<string> Str = new List<string>();
        List<double> Mile = new List<double>();
        Dictionary<int, List<string>> str1 = new Dictionary<int, List<string>>();
        Dictionary<int, List<double>> Mile1 = new Dictionary<int, List<double>>();

        List<float> TimeX = new List<float>();
        List<float> staY = new List<float>();
        DataTable ct = new DataTable();

        public struct Border
        {
            public double up;
            public double down;
        }
        Border border1 = new Border();
        public List<Border> border2 = new List<Border>();
         

        public void TimetableFrame(double WinWidth, double WinUp,double WinDown, double TotalMile, List<double> StationMile, Graphics gs,List<string> StationName)
        {
            double WinHeight = WinDown - WinUp;
            SF.Alignment = StringAlignment.Far;
            SF1.Alignment = StringAlignment.Center;
            float Left = 55;//运行图左边留白
            float Right = 10;//运行图右边留白
            float Up = 5;//运行图上边留白
            float Down = 15;//运行图下边留白
            PointF p1 = new PointF();
            PointF p2 = new PointF();
            Pen pp1 = new Pen(Color.Green, 1);
            Pen pp2 = new Pen(Color.Green, 2);
            Pen pp3 = new Pen(Color.Green, 1);
            pp3.DashStyle = DashStyle.Custom;
            pp3.DashPattern = new float[] { 10f, 5f };
            double Width = WinWidth - (Left + Right);
            double Height = WinHeight - (Up + Down);
            p1.X = Left;
            p1.Y = (float)(Up+WinUp);
            p2.X = Left;
            int a = StationMile.Count;
            p2.Y = (float)(WinUp + Up + Height * StationMile[a - 1] / TotalMile);
            double add1 = Width / (24 * 60);
            float add = (float)add1;
            float xx = 0;
            int Hour = 0;
            for (int j = 0; j <= 1440; j++)
            {
                if(j%10==0)
                {
                    if (j % 60 == 0)
                    {
                        gs.DrawLine(pp2, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                        gs.DrawString(Convert.ToString(Hour),font,brush,p2.X,p2.Y+5,SF1);//在这添加插入时间语句
                        Hour++;
                    }
                    else if (j % 60 != 0 && j % 30 == 0)
                    {
                        gs.DrawLine(pp3, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                    else
                    {
                        gs.DrawLine(pp1, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                }
                else
                {
                    TimeX.Add(p1.X);
                    p1.X = (float)(p1.X + add);
                    p2.X = (float)(p2.X + add);
                }
            }
            xx = p1.X-add;
            ////////////////////////////////////////////////以上是时间线
            pp1 = new Pen(Color.Green, 2);
            p1.X = Left;
            p2.X = xx;
            int n = StationMile.Count();
            for (int k = 0; k < n; k++)
            {
                p1.Y = (float)(WinUp + Up + Height * StationMile[k] / TotalMile);
                p2.Y = (float)(WinUp + Up + Height * StationMile[k] / TotalMile);
                gs.DrawLine(pp1, p1, p2);
                gs.DrawString(StationName[k], font, brush, p1.X-5, p1.Y-5,SF);//在这插入车站标签语句
                staY.Add(p1.Y);
            }
        }//运行图框架图
        public void TrainLine(Graphics gs,List<Train> TrainList,List<string> StaionList)
        {
            Pen pp = new Pen(Color.Red, 1);
            PointF p1 = new PointF();
            PointF p2 = new PointF();
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
        public void GetTrainPoint(List<Train> TrainList,List<string> StationList)//存入各列车点位坐标
        {
            foreach(Train train in TrainList)
            {
                for(int i = 0; i < train.staList.Count; i++)
                {
                    PointF p1 = new PointF();
                    PointF p2 = new PointF();
                    int index1 = StationList.IndexOf(train.staList[i]);
                    int i1 = train.MinuteDic[train.staList[i]][0];
                    int i2 = train.MinuteDic[train.staList[i]][1];
                    p1.X = TimeX[i1];
                    p2.X = TimeX[i2];
                    p1.Y = staY[index1];
                    p2.Y = staY[index1];
                    List<PointF> pointList = new List<PointF>();
                    pointList.Add(p1);
                    pointList.Add(p2);
                    if (!train.trainPointDic.ContainsKey(train.staList[i]))
                    {
                        train.trainPointDic.Add(train.staList[i], pointList);
                    }
                }
            }
        }
        public void GetConflictPoint(List<Conflict> ConflictList,List<Train> TrainList, List<string> StationList)
        {
            foreach(Conflict conflict in ConflictList)
            {
                foreach(Train tra in TrainList)
                {
                    if(conflict.FrontTrain == tra)
                    {
                        int i1 = tra.MinuteDic[conflict.ConflictSta][0];
                        PointF p = new PointF();
                        int index = StationList.IndexOf(conflict.ConflictSta);
                        p.X = TimeX[i1];
                        p.Y = staY[index];
                        conflict.ConflictLocation = p;
                                             
                    }
                }
            }
        }
        public void ConflictDrawUp(Graphics gs,DataTable ct,Dictionary<string,Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Green, 2);
            PointF p1 = new PointF();
            for(int i = 0; i < ct.Rows.Count; i++)
            {
                string No = ct.Rows[i]["前车"].ToString();
                if (TrainDic[No].Dir == "up")
                {
                    int cPoint = 0;
                    if ((ct.Rows[i]["冲突类型"].ToString() == "通到") || (ct.Rows[i]["冲突类型"].ToString() == "到到") || (ct.Rows[i]["冲突类型"].ToString() == "到通") || (ct.Rows[i]["冲突类型"].ToString() == "通通"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][0];
                        p1.X = TimeX[cPoint];
                        p1.Y = staY[StaionList.IndexOf(ct.Rows[i]["车站"].ToString())];
                        gs.DrawEllipse(pp, p1.X, p1.Y, 5, 5);
                    }
                    if ((ct.Rows[i]["冲突类型"].ToString() == "发通") || (ct.Rows[i]["冲突类型"].ToString() == "通发") || (ct.Rows[i]["冲突类型"].ToString() == "发发"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][1];
                        p1.X = TimeX[cPoint];
                        p1.Y = staY[StaionList.IndexOf(ct.Rows[i]["车站"].ToString())];
                        gs.DrawEllipse(pp, p1.X, p1.Y, 5, 5);
                    }
                }                
            }              
        }
        public void ConflictDrawDown(Graphics gs, DataTable ct, Dictionary<string, Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Green, 2);
            PointF p1 = new PointF();
            for (int i = 0; i < ct.Rows.Count; i++)
            {
                string No = ct.Rows[i]["前车"].ToString();
                if(TrainDic[No].Dir == "down")
                {
                    int cPoint = 0;
                    if ((ct.Rows[i]["冲突类型"].ToString() == "到发") || (ct.Rows[i]["冲突类型"].ToString() == "到到") || (ct.Rows[i]["冲突类型"].ToString() == "到通") || (ct.Rows[i]["冲突类型"].ToString() == "通通"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][0];
                        p1.X = TimeX[cPoint];
                        p1.Y = staY[StaionList.IndexOf(ct.Rows[i]["车站"].ToString())];
                        gs.DrawEllipse(pp, p1.X, p1.Y, 5, 5);
                    }
                    if ((ct.Rows[i]["冲突类型"].ToString() == "发通") || (ct.Rows[i]["冲突类型"].ToString() == "通发") || (ct.Rows[i]["冲突类型"].ToString() == "发发"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][1];
                        p1.X = TimeX[cPoint];
                        p1.Y = staY[StaionList.IndexOf(ct.Rows[i]["车站"].ToString())];
                        gs.DrawEllipse(pp, p1.X, p1.Y, 5, 5);
                    }
                }                
            }
        }       
        public static int PointInLine(PointF curPoint, PointF LineStart, PointF LineEnd, double Difference)
        {
            if (Difference < 0)
                Difference = 0 - Difference;

            //首先判断垂直情况
            if (Math.Abs(curPoint.X - LineStart.X) <= Difference && Math.Abs(curPoint.X - LineEnd.X) <= Difference)
            {
                if (curPoint.Y <= LineStart.Y && curPoint.Y >= LineEnd.Y || curPoint.Y >= LineStart.Y && curPoint.Y <= LineEnd.Y)
                    return 0;
                else if (curPoint.Y > LineStart.Y && LineStart.Y > LineEnd.Y || curPoint.Y < LineStart.Y && LineStart.Y < LineEnd.Y)
                    return 1;
                else
                    return 2;
            }
            //再判断水平或近似水平的情况
            else if (Math.Abs(curPoint.Y - LineStart.Y) <= Difference && Math.Abs(curPoint.Y - LineEnd.Y) <= Difference)
            {
                if (curPoint.X <= LineStart.X && curPoint.X >= LineEnd.X || curPoint.X >= LineStart.X && curPoint.X <= LineEnd.X)
                    return 0;
                else if (curPoint.X > LineStart.X && LineStart.X > LineEnd.X || curPoint.X < LineStart.X && LineStart.X < LineEnd.X)
                    return 1;
                else
                    return 2;
            }
            else
            {
                //通过三角形面积公式计算第三点距给定线的距离
                double a = GetDistance(curPoint, LineStart);
                double b = GetDistance(curPoint, LineEnd);
                double c = GetDistance(LineStart, LineEnd);

                double p = (a + b + c) / 2;

                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                double h = 2 * s / c;

                if (h < Difference)
                {
                    //先判断线起点所在角度是否为钝角
                    if (a * a + c * c - b * b < 0)
                        return 1;
                    else if (b * b + c * c - a * a < 0)
                        return 2;
                    else
                        return 0;
                }
            }
            return -1;
        }
        public static int PointInCircle(PointF curPoint, PointF CirclePoint, double Difference)
        {
            if (Difference < 0)
                Difference = 0 - Difference;
            double h = GetDistance(curPoint, CirclePoint);
            if (h < Difference)
            {
                return 0;
            }                          
            return -1;
        }
        public static double GetDistance(PointF p1, PointF p2)
        {
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;

            return Math.Sqrt(x * x + y * y);
        }

        public void Branch(List<string> StationStr, List<double> StationMile, double Width, double Height)
        {
            float divi = 5;
            int a = StationStr.Count;
            List<int> ind1 = new List<int>();
            int k = 0;
            for (int i = 0; i < a; i++)
            {
                if (StationMile[i] == 0)
                {
                    k++;
                }
                ind1.Add(k);
            }
            for (int j = 1; j < k; j++)
            {
                for (int t = 0; t < a; t++)
                {
                    if (ind1[t] == j)
                    {
                        Str.Add(StationStr[t]);
                        Mile.Add(StationMile[t]);
                    }
                }
                str1.Add(k, Str);
                Mile1.Add(k, Mile);
            }//将主线与支线分开
            double all = 0;
            for (int l = 1; l <= k; l++)
            {
                all = all + Mile1[l].Max();
            }
            List<double> h = new List<double>();
            for (int hh = 0; hh < k; hh++)
            {
                h.Add(Height * Mile1[hh + 1].Max() / all);
            }
            for (int e = 0; e < k - 1; e++)
            {
                border1.up = 0;
                border1.down = h[e];
                border2.Add(border1);
                border1.up = border1.down;
                border1.down = border1.down + h[e + 1];
            }//把picturebox分为k份，分别绘画支线

        }//关于支线实现

    }
}
