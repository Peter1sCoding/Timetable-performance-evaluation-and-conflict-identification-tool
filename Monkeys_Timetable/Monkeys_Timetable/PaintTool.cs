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
    class PaintTool//封装绘制运行图所需的方法
    {
        Font font=new Font("宋体",8f);
        Brush brush=new SolidBrush(Color.Green);
        StringFormat SF = new StringFormat();
        StringFormat SF1 = new StringFormat();
        List<float> TimeX = new List<float>();
        List<float> staY = new List<float>();
        DataTable ct = new DataTable();
        public void TimetableFrame(double WinWidth, double WinHeight, double TotalMile, List<double> StationMile, Graphics gs,List<string> StationName)
        {
            SF.Alignment = StringAlignment.Far;
            SF1.Alignment = StringAlignment.Center;
            float Left = 55;
            float Right = 10;
            float Up = 5;
            float Down = 15;
            PointF p1 = new PointF();
            PointF p2 = new PointF();
            Pen pp1 = new Pen(Color.Green, 1);
            Pen pp2 = new Pen(Color.Green, 2);
            double Width = WinWidth - (Left + Right);
            double Height = WinHeight - (Up + Down);
            p1.X = Left;
            p1.Y = Up;
            p2.X = Left;
            int a = StationMile.Count;
            p2.Y = (float)(Up + Height * StationMile[a - 1] / TotalMile);
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
                p1.Y = (float)(Up + Height * StationMile[k] / TotalMile);
                p2.Y = (float)(Up + Height * StationMile[k] / TotalMile);
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

        public void ConflictDrawUp(Graphics gs,DataTable ct,Dictionary<string,Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Blue, 2);
            PointF p1 = new PointF();
            for(int i = 0; i < ct.Rows.Count; i++)
            {
                string No = ct.Rows[i]["前车"].ToString();
                if (TrainDic[No].Dir == "up")
                {
                    int cPoint = 0;
                    if ((ct.Rows[i]["冲突类型"].ToString() == "到发") || (ct.Rows[i]["冲突类型"].ToString() == "到到") || (ct.Rows[i]["冲突类型"].ToString() == "到通") || (ct.Rows[i]["冲突类型"].ToString() == "通通"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][0];
                        p1.X = TimeX[cPoint];
                        p1.Y = staY[StaionList.IndexOf(ct.Rows[i]["车站"].ToString())];
                        gs.DrawEllipse(pp, p1.X, p1.Y, 5, 5);
                    }
                }                
            }              
        }

        public void ConflictDrawDown(Graphics gs, DataTable ct, Dictionary<string, Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Blue, 2);
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
                }                
            }
        }

    }
}
