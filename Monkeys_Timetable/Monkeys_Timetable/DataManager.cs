using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Monkeys_Timetable
{
    class DataManager  //读入到发时刻及车站等数据的类，封装读取列车、车站等方法
    {
        private List<Train> x_trainList; //列车列表
        public List<Train> trainList
        {
            get
            {
                return x_trainList;
            }
            set
            {
                x_trainList = value;
            }
        }
        private Dictionary<string, Train> m_TrainDic; //列车字典
        //列车字典
        public Dictionary<string, Train> trainDic
        {
            get
            {
                if (m_TrainDic == null)
                    m_TrainDic = new Dictionary<string, Train>();
                return m_TrainDic;
            }
            set { m_TrainDic = value; }
        }
        private List<Station> x_stationList;//车站列表
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

        public void ReadFile(string Filename)
        {
            trainDic.Clear();
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            sr.ReadLine();
            string str = sr.ReadLine();
            while (str != null)
            {
                Train tra = new Train();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                tra.trainNo = strr[0];
                string staname = strr[2];
                if (!trainDic.ContainsKey(tra.trainNo))
                {
                    tra.staTimeDic = new Dictionary<string, List<string>>();
                    if (!tra.staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[3]);
                        timelist.Add(strr[4]);
                        tra.staTimeDic.Add(staname, timelist);
                    }
                    trainDic.Add(tra.trainNo, tra);
                }
                else
                {
                    if (!trainDic[tra.trainNo].staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[3]);
                        timelist.Add(strr[4]);
                        trainDic[tra.trainNo].staTimeDic.Add(staname, timelist);
                    }
                }
                str = sr.ReadLine();
            }
            sr.Close();
            trainList = new List<Train>();
            foreach (KeyValuePair<string, Train> trainNumber in trainDic)
            {
                trainList.Add(trainDic[trainNumber.Key]);
            }
        }

        public void ReadStation(string Filename)
        {
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            string str = sr.ReadLine();
            stationList = new List<Station>();
            while (str != null)
            {
                Station sta = new Station();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                sta.stationName = strr[1];
                sta.totalMile = int.Parse(strr[2]);
                stationList.Add(sta);

                str = sr.ReadLine();
            }
            sr.Close();
        }
        /*public void OutPutTimetable(List<Train> trainList, List<Station> stationlist)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\\运行图输出.csv", System.IO.FileMode.Open, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write("车次,");
            for (int i = 0; i < stationlist.Count; i++)
            {
                if (i == 0)
                {
                    sw.Write(stationlist[i].stationName + "出发,");
                }
                else if (i == (stationlist.Count() - 1))
                {
                    sw.Write(stationlist[i].stationName + "到达,");
                }
                else
                {
                    sw.Write(stationlist[i].stationName + "到达," + stationlist[i].stationName + "出发,");
                }
            }
            sw.Write("\r\n");
            for (int i = 0; i < trainList.Count(); i++)
            {
                sw.Write(trainList[i].TrainNo + ",");
                foreach (ModelTrainStation sta in trainList[i].StaList)
                {
                    DateTime Arrdate = ModelTrain.GetTimeFromIntValue(sta.ArrIntTime);
                    DateTime Depdate = ModelTrain.GetTimeFromIntValue(sta.DepIntTime);
                    if (stationlist.IndexOf(sta.StaName) == 0)
                    {
                        sw.Write(Depdate.Hour + ":" + Depdate.Minute + ":" + Depdate.Second + ",");
                    }
                    else if (stationlist.IndexOf(sta.StaName) == (stationlist.Count() - 1))
                    {
                        sw.Write(Arrdate.Hour + ":" + Arrdate.Minute + ":" + Arrdate.Second + ",");
                    }
                    else
                    {
                        sw.Write(Arrdate.Hour + ":" + Arrdate.Minute + ":" + Arrdate.Second + ",");
                        sw.Write(Depdate.Hour + ":" + Depdate.Minute + ":" + Depdate.Second + ",");
                    }
                }
                sw.Write("\r\n");
            }
            sw.Close();
            fs.Close();
        }*/
    }
}
