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
        public Dictionary<int, List<string>> str1 = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> str2 = new Dictionary<int, List<string>>();//无重复的支线车站列表
        public Dictionary<int, List<double>> Mile1 = new Dictionary<int, List<double>>();
        public int MainLine = 0;
        public List<float> TimeX = new List<float>();
        List<float> staY = new List<float>();
        /// <summary>
        /// 存储支线分支点的坐标信息
        /// </summary>
        public struct BranchY
        {
            public double UpY;
            public double DownY;
        }
        public Dictionary<string,BranchY> BranchYinf=new Dictionary<string, BranchY>();//存放跨线列车连接线坐标信息
        public Dictionary<int, List<float>> staY2 = new Dictionary<int, List<float>>();
        /// <summary>
        /// 存放冲突信息的DataTable
        /// </summary>
        DataTable ct = new DataTable();

        public struct Border
        {
            public double up;
            public double down;
        }
        Border border1 = new Border();
        public List<Border> border2 = new List<Border>();
         

        public void TimetableFrame(double WinWidth, double WinUp,double WinDown, double TotalMile, List<double> StationMile, Graphics gs,List<string> StationName,int indd)
        {
            double WinHeight = WinDown - WinUp;
            SF.Alignment = StringAlignment.Far;
            SF1.Alignment = StringAlignment.Center;
            float Left = 55;//运行图左边留白
            float Right = 10;//运行图右边留白
            float Up = 15;//运行图上边留白
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
                        if (indd == 1)
                        {
                            TimeX.Add(p1.X);
                        }
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                        if (indd == staY2.Count)
                        {
                            gs.DrawString(Convert.ToString(Hour), font, brush, p2.X, p2.Y + 5, SF1);//在这添加插入时间语句
                            Hour++;
                        }
                        if (indd == 1)
                        {
                            gs.DrawString(Convert.ToString(Hour), font, brush, p1.X, p1.Y - 15, SF1);//在这添加插入时间语句
                            Hour++;
                        }
                        //gs.DrawString(Convert.ToString(Hour),font,brush,p2.X,p2.Y+5,SF1);//在这添加插入时间语句
                        //Hour++;
                    }
                    else if (j % 60 != 0 && j % 30 == 0)
                    {
                        gs.DrawLine(pp3, p1, p2);
                        if (indd == 1)
                        {
                            TimeX.Add(p1.X);
                        }
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                    else
                    {
                        gs.DrawLine(pp1, p1, p2);
                        if (indd == 1)
                        {
                            TimeX.Add(p1.X);
                        }
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
            List<float> ff=new List<float>();
            if (!staY2.TryGetValue(indd,out ff))
            {
                staY2.Add(indd, staY);
            }
            
            staY = new List<float>();
        }//运行图框架图
        public void TrainLine(Graphics gs,List<Train> TrainList,List<string> StaionList,int k)
        {
            Pen pp = new Pen(Color.Red, (float)1.2);
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
                        p1.Y = staY2[k][index1];
                        p2.Y = staY2[k][index2];                       
                        gs.DrawLine(pp, p1, p2);
                        
                    }
                }
                for (int i = 1; i < a - 1; i++)
                {
                    if (StaionList.IndexOf(train.staList[i]) != -1 && train.staList[i] != StaionList[0] && train.staList[i] != StaionList[StaionList.Count - 1]) 
                    {
                        int index1 = StaionList.IndexOf(train.staList[i]);
                        int i1 = train.MinuteDic[train.staList[i]][0];
                        int i2 = train.MinuteDic[train.staList[i]][1];
                        p1.X = TimeX[i1];
                        p2.X = TimeX[i2];
                        p1.Y = staY2[k][index1];
                        p2.Y = staY2[k][index1];
                        gs.DrawLine(pp, p1, p2);
                    }                   
                }
            }
        }//运行线铺画方法
         /// <summary>
         ///存入各列车点位坐标
         /// </summary>
        public void GetTrainPoint(List<Train> TrainList,List<string> StationList,int k)
        {
            foreach(Train train in TrainList)
            {
                Dictionary<string, List<PointF>> PointDic = new Dictionary<string, List<PointF>>();
                train.TrainPointList.Add(PointDic);
                for (int i = 0; i < train.staList.Count; i++)
                {
                    if (StationList.IndexOf(train.staList[i]) != -1)
                    {
                        PointF p1 = new PointF();
                        PointF p2 = new PointF();
                        int index1 = StationList.IndexOf(train.staList[i]);
                        int i1 = train.MinuteDic[train.staList[i]][0];
                        int i2 = train.MinuteDic[train.staList[i]][1];
                        p1.X = TimeX[i1];
                        p2.X = TimeX[i2];
                        p1.Y = staY2[k + 1][index1];
                        p2.Y = staY2[k + 1][index1];
                        List<PointF> pointList = new List<PointF>();
                        pointList.Add(p1);
                        pointList.Add(p2);
                        if (!train.TrainPointList[k].ContainsKey(train.staList[i]))
                        {
                            train.TrainPointList[k].Add(train.staList[i], pointList);
                        }
                    }                        
                }
            }
        }
        /// <summary>
        /// 获取各冲突点在bmp的坐标
        /// </summary>
        public void GetConflictPoint(List<Conflict> ConflictList,List<Train> TrainList)
        {
            foreach(Conflict conflict in ConflictList)
            {
                foreach(Train tra in TrainList)
                {
                    if(conflict.FrontTrain == tra)
                    {
                        if((conflict.ConflictType=="到通")|| (conflict.ConflictType == "通到") || (conflict.ConflictType == "到到") || (conflict.ConflictType == "通通"))
                        {
                            int i1 = tra.MinuteDic[conflict.ConflictSta][0];
                            PointF p = new PointF();
                            p.X = TimeX[i1];                             
                            for (int i = 0; i < str1.Count; i++)
                            {
                                if (str1[i + 1].Contains(conflict.ConflictSta))
                                {
                                    int index = str1[i + 1].IndexOf(conflict.ConflictSta);
                                    p.Y = staY2[i + 1][index];
                                    conflict.ConflictLocation = p;
                                }
                            }
                        }
                        else
                        {
                            int i1 = tra.MinuteDic[conflict.ConflictSta][1];
                            PointF p = new PointF();
                            p.X = TimeX[i1];
                            for (int i = 0; i < str1.Count; i++)
                            {
                                if (str1[i + 1].Contains(conflict.ConflictSta))
                                {
                                    int index = str1[i + 1].IndexOf(conflict.ConflictSta);
                                    p.Y = staY2[i + 1][index];
                                    conflict.ConflictLocation = p;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 在bmp中绘制上行列车间的冲突点
        /// </summary>
        public void ConflictDrawUp(Graphics gs,DataTable ct,Dictionary<string,Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Black, 2);
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
                        for(int j = 1; j < str1.Count + 1; j++)
                        {
                            if (str1[j].Contains(ct.Rows[i]["车站"].ToString()))
                            {
                                p1.Y = staY2[j][str1[j].IndexOf(ct.Rows[i]["车站"].ToString())];
                                gs.DrawEllipse(pp, p1.X-2, p1.Y-2, 5, 5);
                            }
                        }                        
                    }
                    if ((ct.Rows[i]["冲突类型"].ToString() == "发通") || (ct.Rows[i]["冲突类型"].ToString() == "通发") || (ct.Rows[i]["冲突类型"].ToString() == "发发"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][1];
                        p1.X = TimeX[cPoint];
                        for (int j = 1; j < str1.Count + 1; j++)
                        {
                            if (str1[j].Contains(ct.Rows[i]["车站"].ToString()))
                            {
                                p1.Y = staY2[j][str1[j].IndexOf(ct.Rows[i]["车站"].ToString())];
                                gs.DrawEllipse(pp, p1.X-2, p1.Y-2, 5, 5);
                            }
                        }
                    }
                }                
            }              
        }
        /// <summary>
        /// 在bmp中绘制下行列车间的冲突点
        /// </summary>
        public void ConflictDrawDown(Graphics gs, DataTable ct, Dictionary<string, Train> TrainDic, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Black, 2);
            PointF p1 = new PointF();
            for (int i = 0; i < ct.Rows.Count; i++)
            {
                string No = ct.Rows[i]["前车"].ToString();
                if (TrainDic[No].Dir == "down")
                {
                    int cPoint = 0;
                    if ((ct.Rows[i]["冲突类型"].ToString() == "通到") || (ct.Rows[i]["冲突类型"].ToString() == "到到") || (ct.Rows[i]["冲突类型"].ToString() == "到通") || (ct.Rows[i]["冲突类型"].ToString() == "通通"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][0];
                        p1.X = TimeX[cPoint];
                        for (int j = 1; j < str1.Count + 1; j++)
                        {
                            if (str1[j].Contains(ct.Rows[i]["车站"].ToString()))
                            {
                                p1.Y = staY2[j][str1[j].IndexOf(ct.Rows[i]["车站"].ToString())];
                                gs.DrawEllipse(pp, p1.X - 2, p1.Y - 2, 5, 5);
                            }
                        }
                    }
                    if ((ct.Rows[i]["冲突类型"].ToString() == "发通") || (ct.Rows[i]["冲突类型"].ToString() == "通发") || (ct.Rows[i]["冲突类型"].ToString() == "发发"))
                    {
                        cPoint = TrainDic[ct.Rows[i]["前车"].ToString()].MinuteDic[ct.Rows[i]["车站"].ToString()][1];
                        p1.X = TimeX[cPoint];
                        for (int j = 1; j < str1.Count + 1; j++)
                        {
                            if (str1[j].Contains(ct.Rows[i]["车站"].ToString()))
                            {
                                p1.Y = staY2[j][str1[j].IndexOf(ct.Rows[i]["车站"].ToString())];
                                gs.DrawEllipse(pp, p1.X - 2, p1.Y - 2, 5, 5);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
		/// 以一定误差判断点是否在由另外两点构成的直线上
		/// </summary>
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
        /// <summary>
		/// 以一定误差判断点是否在另一个点的附近
		/// </summary>
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
        /// <summary>
		/// 获取两点间距离
		/// </summary>
        public static double GetDistance(PointF p1, PointF p2)
        {
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;

            return Math.Sqrt(x * x + y * y);
        }
        /// <summary>
        /// 将车站画图信息拆分成主线和支线几段
        /// </summary>
        /// <param name="StationStr"></param>
        /// <param name="StationMile"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public void Branch(List<string> StationStr, List<double> StationMile, double Width, double Height)
        {
            //float divi = 5;
            str1 = new Dictionary<int, List<string>>();
            Mile1 = new Dictionary<int, List<double>>();
            border2 = new List<Border>();
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
            for (int j = 1; j <= k; j++)
            {
                for (int t = 0; t < a; t++)
                {
                    if (ind1[t] == j)
                    {
                        Str.Add(StationStr[t]);
                        Mile.Add(StationMile[t]);
                    }
                }
                str1.Add(j, Str);
                Mile1.Add(j, Mile);
                Str = new List<string>();
                Mile = new List<double>();
            }//将主线与支线分开
            foreach(int ke in str1.Keys)
            {
                int c = 0;
                if (str1[ke].Count >= c)
                {
                    MainLine = ke;
                    c = str1[ke].Count;
                }
            }////找出站数最多的作为主线，得出主线的号
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
            border1.up = 0;
            border1.down = h[0];
            for (int e = 1; e < k; e++)
            {
                border2.Add(border1);
                border1.up = border1.down;
                border1.down = border1.down + h[e];
            }//把picturebox分为k份，分别绘画支线
            border2.Add(border1);
            /////////////////////////////////////////////以上为划分支线的程序

        }//关于支线实现

        /// <summary>
        /// 找出运行图中的支点车站在运行图中的坐标关系,放入BranchYinf中
        /// </summary>
        /// <param name="StationStr"></param>
        /// <param name="staY2"></param>
        /// <param name="str1"></param>
        public void BranchXY(List<string> StationStr, Dictionary<int, List<float>> staY2, Dictionary<int, List<string>> str1)
        {
            List<string> RepititiveStation = new List<string>();
            int k = StationStr.Count;
            for (int i = 0; i < k; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (StationStr[i] == StationStr[j])
                    {
                        RepititiveStation.Add(StationStr[i]);
                    }
                } ///找出分支点的车站并存放在List中

                int a = staY2.Count;
                for (int b = 1; b + 1 <= a; b++)
                {
                    
                    for(int c = 0;c < RepititiveStation.Count; c++)
                    {
                        int ind1 = 0;
                        int ind2 = 0;
                        ind1 = str1[b].IndexOf(RepititiveStation[c]);
                        ind2 = str1[b + 1].IndexOf(RepititiveStation[c]);
                        BranchY Bran = new BranchY();
                        Bran.UpY = staY2[b][ind1];
                        Bran.DownY = staY2[b + 1][ind2];
                        BranchYinf.Add(RepititiveStation[c], Bran);
                    }///得出每个支点站在运行图上下两个的坐标
                    
                }
                
            }
            ///////////////////////////////////////////////以上为支线点的相关坐标信息
        }

        public int MainLineNum = 0;
        int MainLineCount = 0;
        PaintTool pt = new PaintTool();
        /// <summary>
        /// 找出线路中的主线，并得出主线的序号（站数最多的为主线）
        /// </summary>
        public void GetMainLine()
        {
            foreach (int l in str1.Keys)
            {
                if (pt.str1[l].Count > MainLineCount)
                {
                    MainLineNum = l;
                    MainLineCount = str1[l].Count;
                }
            }
        }

        /// <summary>
        /// 画出线路间的连接线
        /// </summary>
        public void DrawConLine(Graphics gs, List<Train> TrainList)
        {
            DataManager dm = new DataManager();
            BranchXY(dm.stationDrawStringList, staY2, str1);
            GetBranchStation();
            foreach (Train t in TrainList)
            {
                foreach (int k in t.BranchNum)
                {
                    if (t.BranchNum != null)
                    {

                    }
                }
                
            }
        }
        /// <summary>
        /// 获得支线车站字典，把主线删去，把支线中与主线连接的车站删去，放入str2中
        /// </summary>
        public void GetBranchStation()
        {
            GetMainLine();
            foreach (int k2 in str1.Keys)
            {
                if (k2 != MainLineNum)
                {
                    str2.Add(k2, str1[k2]);
                }
            }//把支线放入支线字典
          
            foreach (int k3 in str2.Keys)
            {
                int ii = str2[k3].Count;
                for (int jj = ii - 1; jj >= 0; jj--) 
                {
                    if (str1[MainLineNum].IndexOf(str2[k3][jj]) != -1)
                    {
                        str2[k3].Remove(str2[k3][jj]);
                    }
                }
            }//把主线有的车站删去

        }
    }
}
