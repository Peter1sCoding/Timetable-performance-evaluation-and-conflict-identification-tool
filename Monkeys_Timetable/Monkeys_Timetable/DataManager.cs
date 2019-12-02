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
                value = x_trainList;
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
        private List<string> x_stationList;//车站列表
        public List<string> stationList
        {
            get
            {
                return x_stationList;
            }
            set
            {
                value = x_stationList;
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
                    if (tra.newbool)
                    {
                        tra.staTimeDic = new Dictionary<string, List<string>>();
                        tra.newbool = false;
                    }                  
                    if (!tra.staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[3]);
                        timelist.Add(strr[4]);
                        tra.staTimeDic.Add(staname, timelist);
                    }
                    trainDic.Add(tra.trainNo, tra);
                }               
                str = sr.ReadLine();
            }           
            sr.Close();
        }      
    }
}
