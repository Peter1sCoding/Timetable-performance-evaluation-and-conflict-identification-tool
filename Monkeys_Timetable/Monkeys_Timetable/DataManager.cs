using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Monkeys_Timetable
{
    /// <summary>
    /// 读入到发时刻及车站等数据的类，封装读取列车、车站等方法
    /// </summary>
    class DataManager
    {
        private List<Train> x_TrainList;
        /// <summary>
        /// 所有列车列表
        /// </summary>
        public List<Train> TrainList
        {
            get
            {
                return x_TrainList;
            }
            set
            {
                x_TrainList = value;
            }
        }
        
        private List<Train> x_upTrainList;
        /// <summary>
        /// 上行列车列表
        /// </summary>
        public List<Train> upTrainList
        {
            get
            {
                return x_upTrainList;
            }
            set
            {
                x_upTrainList = value;
            }
        }

        private List<Train> x_downTrainList;
        /// <summary>
        /// 下行列车列表
        /// </summary>
        public List<Train> downTrainList
        {
            get
            {
                return x_downTrainList;
            }
            set
            {
                x_downTrainList = value;
            }
        }
       
        private Dictionary<string, Train> m_TrainDic;
        /// <summary>
        /// 所有列车字典
        /// </summary>
        public Dictionary<string, Train> TrainDic
        {
            get
            {
                if (m_TrainDic == null)
                    m_TrainDic = new Dictionary<string, Train>();
                return m_TrainDic;
            }
            set { m_TrainDic = value; }
        }
        
        private Dictionary<string, Train> m_UpTrainDic;
        /// <summary>
        /// 上行列车字典
        /// </summary>
        public Dictionary<string, Train> UpTrainDic
        {
            get
            {
                if (m_UpTrainDic == null)
                    m_UpTrainDic = new Dictionary<string, Train>();
                return m_UpTrainDic;
            }
            set { m_UpTrainDic = value; }
        }

       
        private Dictionary<string, Train> m_DownTrainDic;
        /// <summary>
        /// 下行列车字典
        /// </summary>
        public Dictionary<string, Train> DownTrainDic
        {
            get
            {
                if (m_DownTrainDic == null)
                    m_DownTrainDic = new Dictionary<string, Train>();
                return m_DownTrainDic;
            }
            set { m_DownTrainDic = value; }
        }

        private List<Station> x_stationList;
        /// <summary>
        /// 车站列表
        /// </summary>
        public List<Station> stationList
        {
            get
            {
                return x_stationList;
            }
            set
            {
                x_stationList = value;
            }
        }

        private List<String> x_stationStringList;
        /// <summary>
        /// 车站列表
        /// </summary>
        public List<String> stationStringList
        {
            get
            {
                return x_stationStringList;
            }
            set
            {
                x_stationStringList = value;
            }
        }
       
        private List<DrawStation> x_stationDrawList;
        public List<DrawStation> stationDrawList//车站列表
        {
            get
            {
                return x_stationDrawList;
            }
            set
            {
                x_stationDrawList = value;
            }
        }

        private List<String> x_stationDrawStringList;
        public List<String> stationDrawStringList//车站列表
        {
            get
            {
                return x_stationDrawStringList;
            }
            set
            {
                x_stationDrawStringList = value;
            }
        }

        private Dictionary<string, Dictionary<string,int>> x_HeadwayDic;
        /// <summary>
        /// 通过"站名+上下行+间隔类型"索引间隔时间标准
        /// </summary>
        public Dictionary<string, Dictionary<string, int>> HeadwayDic
        {
            get
            {
                return x_HeadwayDic;
            }
            set
            {
                x_HeadwayDic = value;
            }
        }

        /// <summary>
        /// 读取列车文件并根据尾号判断上下行
        /// </summary>
        public void ReadTrain(string Filename)
        {
            TrainDic.Clear();
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            sr.ReadLine();
            string str = sr.ReadLine();
            while (str != null)
            {
                Train tra = new Train();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                tra.TrainNo = strr[0];
                tra.speed = "350";
                string staname = strr[2];
                string LastNumber = tra.TrainNo.Substring(tra.TrainNo.Length - 1, 1);
                if (( LastNumber == "0")||(LastNumber == "2") || (LastNumber == "4") || (LastNumber == "6") || (LastNumber == "8"))
                {
                    tra.Dir = "up";
                }
                else
                {
                    tra.Dir = "down";
                }

                if (!TrainDic.ContainsKey(tra.TrainNo))
                {
                    tra.staTimeDic = new Dictionary<string, List<string>>();
                    if (!tra.staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[3]);
                        timelist.Add(strr[4]);
                        timelist.Add(strr[5]);
                        tra.staTimeDic.Add(staname, timelist);
                    }                  
                    TrainDic.Add(tra.TrainNo, tra);
                }
                else
                {
                    if (!TrainDic[tra.TrainNo].staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[3]);
                        timelist.Add(strr[4]);
                        timelist.Add(strr[5]);
                        TrainDic[tra.TrainNo].staTimeDic.Add(staname, timelist);
                    }
                }
                str = sr.ReadLine();
            }
            sr.Close();
            TrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in TrainDic)//给trainList赋值
            {
                TrainList.Add(TrainDic[trainNumber.Key]);
            }
            for(int i = 0; i < TrainList.Count(); i++)
            {
                TrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> trainNumber in TrainList[i].staTimeDic)
                {
                    TrainList[i].staList.Add(trainNumber.Key);
                }
            }
            ToMinute(TrainList);
        }

        /// <summary>
        /// 根据车次尾号将列车存入上行或下行列车字典
        /// </summary>
        public void DivideUpDown()
        {
            UpTrainDic = new Dictionary<string, Train>();
            DownTrainDic = new Dictionary<string, Train>();
            for (int i = 0; i < TrainList.Count; i++)
            {
                string LastNumber = TrainList[i].TrainNo.Substring(TrainList[i].TrainNo.Length - 1, 1);
                if (( LastNumber == "0")||(LastNumber == "2") || (LastNumber == "4") || (LastNumber == "6") || (LastNumber == "8"))
                {
                    UpTrainDic.Add(TrainList[i].TrainNo, TrainList[i]);
                }
                else if ((LastNumber == "1") || (LastNumber == "3") || (LastNumber == "5") || (LastNumber == "7") || (LastNumber == "9"))
                {
                    DownTrainDic.Add(TrainList[i].TrainNo, TrainList[i]);
                }
            }

            upTrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in UpTrainDic)//给uptrainList赋值
            {
                upTrainList.Add(UpTrainDic[trainNumber.Key]);
            }
            for (int i = 0; i < upTrainList.Count(); i++)
            {
                upTrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> trainNumber in upTrainList[i].staTimeDic)
                {
                    upTrainList[i].staList.Add(trainNumber.Key);
                }
            }
           ToMinute(upTrainList);

            downTrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in DownTrainDic)//给uptrainList赋值
            {
                downTrainList.Add(DownTrainDic[trainNumber.Key]);
            }
            for (int i = 0; i < downTrainList.Count(); i++)
            {
                downTrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> trainNumber in downTrainList[i].staTimeDic)
                {
                    downTrainList[i].staList.Add(trainNumber.Key);
                }
            }
            ToMinute(downTrainList);
        }

        /// <summary>
        /// 读取文件将车站存入车站信息列表和车站名列表
        /// </summary>
        public void ReadStation(string Filename)
        {
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            string str = sr.ReadLine();
            stationList = new List<Station>();
            stationStringList = new List<String>();
            while (str != null)
            {
                Station sta = new Station();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                sta.stationNo = strr[0];
                sta.stationName = strr[1];
                sta.totalMile = int.Parse(strr[2]);
                stationList.Add(sta);
                stationStringList.Add(sta.stationName);
                str = sr.ReadLine();
            }
            sr.Close();
        }

        public void ReadDrawStation(string Filename)
        {
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            string str = sr.ReadLine();
            stationDrawList = new List<DrawStation>();
            stationDrawStringList = new List<String>();
            while (str != null)
            {
                DrawStation sta = new DrawStation();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                sta.stationNo = strr[0];
                sta.stationName = strr[1];
                sta.totalMile = int.Parse(strr[2]);
                stationDrawList.Add(sta);
                stationDrawStringList.Add(sta.stationName);
                str = sr.ReadLine();
            }
            sr.Close();
        }

        /// <summary>
        /// 输出之前读取的信息为时刻表，包含车次、出发、到达车站以及列车停站信息
        /// </summary>
        public void OutPutTimetable(List<Train> trainList,List<string> stationlist)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\\运行图输出.csv", System.IO.FileMode.Open, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.Write("车次,");
            for (int i = 0; i < stationlist.Count; i++)
            {
                if (i == 0)
                {
                    sw.Write(stationlist[i] + "出发,");
                }
                else if (i == (stationlist.Count() - 1))
                {
                    sw.Write(stationlist[i] + "到达,");
                }
                else
                {
                    sw.Write(stationlist[i] + "到达," + stationlist[i] + "出发,");
                }
            }
            sw.Write("\r\n");
            for (int i = 0; i < trainList.Count(); i++)
            {               
                sw.Write(trainList[i].TrainNo + ",");
                int begin = stationStringList.IndexOf(trainList[i].staList[0]);
                int end = stationStringList.IndexOf(trainList[i].staList[trainList[i].staList.Count() - 1]);
                string front = "";
                for (int j = 0; j < begin; j++)
                {
                    if (j == 1)
                    {
                        front += "0,";
                    }
                    else if (j != 1)
                    {
                        front += "0,0,";
                    }
                }
                foreach (string station in trainList[i].staList)
                {
                    sw.Write(trainList[i].staTimeDic[station][0] + ",");
                    sw.Write(trainList[i].staTimeDic[station][1] + ",");                                  
                }              
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 读取车站列车安全间隔
        /// </summary>
        public void ReadHeadway(string FileName)
        {
            HeadwayDic = new Dictionary<string, Dictionary<string,int>>();
            StreamReader sr = new StreamReader(FileName, Encoding.Default);
            string[] speed = sr.ReadLine().Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty).Split(',');

            string speed1 = speed[2].Substring(2, 3);
            string speed2 = speed[11].Substring(2, 3);
            sr.ReadLine();
            string str = sr.ReadLine();
            while (str != null)
            {
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                string[] strr = str.Split(',');
                if (Convert.ToInt32(strr[1]) == 1) //判断上下行，存到不同的索引值中
                {
                    string key = ConcatenateAllString(strr[0], "down", speed1);
                    if (!HeadwayDic.ContainsKey(key))
                    {
                        Dictionary<string, int> TrainHeadway = new Dictionary<string, int>();
                        int dd = Convert.ToInt32(strr[2]);
                        int df = Convert.ToInt32(strr[3]);
                        int dt = Convert.ToInt32(strr[4]);
                        int fd = Convert.ToInt32(strr[5]);
                        int ff = Convert.ToInt32(strr[6]);
                        int ft = Convert.ToInt32(strr[7]);
                        int td = Convert.ToInt32(strr[8]);
                        int tf = Convert.ToInt32(strr[9]);
                        int tt = Convert.ToInt32(strr[10]);

                        TrainHeadway.Add("到到", dd);
                        TrainHeadway.Add("到发", df);
                        TrainHeadway.Add("到通", dt);
                        TrainHeadway.Add("发到", fd);
                        TrainHeadway.Add("发发", ff);
                        TrainHeadway.Add("发通", ft);
                        TrainHeadway.Add("通到", td);
                        TrainHeadway.Add("通发", tf);
                        TrainHeadway.Add("通通", tt);
                        HeadwayDic.Add(key, TrainHeadway);
                    }
                    string key1 = ConcatenateAllString(strr[0], "down", speed2);//存入第二个速度等级的间隔时分
                    if (!HeadwayDic.ContainsKey(key1))
                    {
                        Dictionary<string, int> TrainHeadway = new Dictionary<string, int>();
                        int dd = Convert.ToInt32(strr[11]);
                        int df = Convert.ToInt32(strr[12]);
                        int dt = Convert.ToInt32(strr[13]);
                        int fd = Convert.ToInt32(strr[14]);
                        int ff = Convert.ToInt32(strr[15]);
                        int ft = Convert.ToInt32(strr[16]);
                        int td = Convert.ToInt32(strr[17]);
                        int tf = Convert.ToInt32(strr[18]);
                        int tt = Convert.ToInt32(strr[19]);

                        TrainHeadway.Add("到到", dd);
                        TrainHeadway.Add("到发", df);
                        TrainHeadway.Add("到通", dt);
                        TrainHeadway.Add("发到", fd);
                        TrainHeadway.Add("发发", ff);
                        TrainHeadway.Add("发通", ft);
                        TrainHeadway.Add("通到", td);
                        TrainHeadway.Add("通发", tf);
                        TrainHeadway.Add("通通", tt);
                        HeadwayDic.Add(key1, TrainHeadway);
                    }
                }
                else if (Convert.ToInt32(strr[1]) == 0)
                {
                    string key = ConcatenateAllString(strr[0], "up", speed1);
                    if (!HeadwayDic.ContainsKey(key))
                    {
                        Dictionary<string, int> TrainHeadway = new Dictionary<string, int>();
                        int dd = Convert.ToInt32(strr[2]);
                        int df = Convert.ToInt32(strr[3]);
                        int dt = Convert.ToInt32(strr[4]);
                        int fd = Convert.ToInt32(strr[5]);
                        int ff = Convert.ToInt32(strr[6]);
                        int ft = Convert.ToInt32(strr[7]);
                        int td = Convert.ToInt32(strr[8]);
                        int tf = Convert.ToInt32(strr[9]);
                        int tt = Convert.ToInt32(strr[10]);
                        TrainHeadway.Add("到到", dd);
                        TrainHeadway.Add("到发", df);
                        TrainHeadway.Add("到通", dt);
                        TrainHeadway.Add("发到", fd);
                        TrainHeadway.Add("发发", ff);
                        TrainHeadway.Add("发通", ft);
                        TrainHeadway.Add("通到", td);
                        TrainHeadway.Add("通发", tf);
                        TrainHeadway.Add("通通", tt);
                        HeadwayDic.Add(key, TrainHeadway);
                    }
                    string key1 = ConcatenateAllString(strr[0], "up", speed2);
                    if (!HeadwayDic.ContainsKey(key1))
                    {
                        Dictionary<string, int> TrainHeadway = new Dictionary<string, int>();
                        int dd = Convert.ToInt32(strr[11]);
                        int df = Convert.ToInt32(strr[12]);
                        int dt = Convert.ToInt32(strr[13]);
                        int fd = Convert.ToInt32(strr[14]);
                        int ff = Convert.ToInt32(strr[15]);
                        int ft = Convert.ToInt32(strr[16]);
                        int td = Convert.ToInt32(strr[17]);
                        int tf = Convert.ToInt32(strr[18]);
                        int tt = Convert.ToInt32(strr[19]);
                        TrainHeadway.Add("到到", dd);
                        TrainHeadway.Add("到发", df);
                        TrainHeadway.Add("到通", dt);
                        TrainHeadway.Add("发到", fd);
                        TrainHeadway.Add("发发", ff);
                        TrainHeadway.Add("发通", ft);
                        TrainHeadway.Add("通到", td);
                        TrainHeadway.Add("通发", tf);
                        TrainHeadway.Add("通通", tt);
                        HeadwayDic.Add(key1, TrainHeadway);
                    }
                }
                str = sr.ReadLine();
            }
            sr.Close();
        }

        /// <summary>
        /// 组成key的方法，包含strr[]和上下行、速度
        /// </summary>
        public string ConcatenateAllString(string a1,string a2,string a3)
        {
            string s = a1 + a2 + a3;
            return s;
        }

        /// <summary>
        /// 将车站到发时间转成分钟存入minutelist
        /// </summary>
        public void ToMinute(List<Train> trainList)
        {
            foreach (Train train in TrainList)
            {
                train.MinuteDic = new Dictionary<string, List<int>>();
                foreach (KeyValuePair<string, List<string>> time in train.staTimeDic)
                {
                    List<int> minutelist = new List<int>();
                    if (train.staTimeDic[time.Key][0] != "")
                    {
                        string[] trainarrminute = train.staTimeDic[time.Key][0].Split(':');
                        minutelist.Add(int.Parse(trainarrminute[0]) * 60 + int.Parse(trainarrminute[1]));
                    }
                    else minutelist.Add(0);

                    if (train.staTimeDic[time.Key][1] != "")
                    {
                        string[] traindepminute = train.staTimeDic[time.Key][1].Split(':');
                        minutelist.Add(int.Parse(traindepminute[0]) * 60 + int.Parse(traindepminute[1]));
                    }
                    else minutelist.Add(0);
                    train.MinuteDic.Add(time.Key, minutelist);
                }
            }
        }

        /// <summary>
        /// 将上下行的停站存入isStopDic字典里
        /// </summary>
        public void GetStop()
        {
            for(int i = 0; i < upTrainList.Count; i++)
            {
                upTrainList[i].isStopDic = new Dictionary<string, bool>();
                for (int j = 0; j < upTrainList[i].staList.Count; j++)
                {
                    if (upTrainList[i].staTimeDic[upTrainList[i].staList[j]][0] == upTrainList[i].staTimeDic[upTrainList[i].staList[j]][1])
                    {
                        upTrainList[i].isStopDic.Add(upTrainList[i].staList[j], false);
                    }
                    else
                    {
                        upTrainList[i].isStopDic.Add(upTrainList[i].staList[j], true);
                    }
                }
            }

            for (int i = 0; i < downTrainList.Count; i++)
            {
                downTrainList[i].isStopDic = new Dictionary<string, bool>();
                for (int j = 0; j < downTrainList[i].staList.Count; j++)
                {
                    if (downTrainList[i].staTimeDic[downTrainList[i].staList[j]][0] == downTrainList[i].staTimeDic[downTrainList[i].staList[j]][1])
                    {
                        downTrainList[i].isStopDic.Add(downTrainList[i].staList[j], false);
                    }
                    else
                    {
                        downTrainList[i].isStopDic.Add(downTrainList[i].staList[j], true);
                    }
                }
            }
        }

        /// <summary>
        /// 把车和车站关联，生成车站的列车列表
        /// </summary>
        public void AddTra2sta()
        {
            for(int i = 0; i < stationList.Count; i++)
            {
                stationList[i].upStaTraArrList = new List<Train>();
                stationList[i].upStaTraDepList = new List<Train>();
                for (int j = 0; j < upTrainList.Count; j++)
                {
                    if (upTrainList[j].staList.Contains(stationList[i].stationName))
                    {
                        stationList[i].upStaTraArrList.Add(upTrainList[j]);
                        stationList[i].upStaTraDepList.Add(upTrainList[j]);
                    }
                }
                stationList[i].upStaTraArrList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][0].CompareTo(y.MinuteDic[stationList[i].stationName][0]);
                });
                stationList[i].upStaTraDepList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][1].CompareTo(y.MinuteDic[stationList[i].stationName][1]);
                });
            }
            for (int i = 0; i < stationList.Count; i++)
            {
                stationList[i].downStaTraArrList = new List<Train>();
                stationList[i].downStaTraDepList = new List<Train>();
                for (int j = 0; j < downTrainList.Count; j++)
                {
                    if (downTrainList[j].staList.Contains(stationList[i].stationName))
                    {
                        stationList[i].downStaTraArrList.Add(downTrainList[j]);
                        stationList[i].downStaTraDepList.Add(downTrainList[j]);
                    }
                }
                stationList[i].downStaTraArrList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][0].CompareTo(y.MinuteDic[stationList[i].stationName][0]);
                });
                stationList[i].downStaTraDepList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][1].CompareTo(y.MinuteDic[stationList[i].stationName][1]);
                });
            }
        }
        PaintTool pt = new PaintTool();
        /// <summary>
        /// 获得列车的支线信息，与支线车站字典进行匹配获得支线号
        /// </summary>
        public void GetLineNum()
        {
            foreach (Train t in TrainList)
            {
                foreach (string s in t.staList)
                {
                    foreach (int kk in pt.str2.Keys)
                    {
                        if (pt.str2[kk].IndexOf(s) != -1 && t.BranchNum.IndexOf(kk) == -1)
                        {
                            t.BranchNum.Add(kk);
                        }//如果列车停站列表中有支线车站列表中的车站，则把支线号放入列车属性中
                    }//遍历支线字典
                }//遍历列车停站列表
            }//遍历所有列车
        }
    }
}
