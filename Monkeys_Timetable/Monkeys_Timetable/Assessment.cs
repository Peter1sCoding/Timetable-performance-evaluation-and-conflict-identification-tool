using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Assessment//封装各类运行图指标计算方法
    {
        public DataManager dm = new DataManager();
        
       

        public double GetMinute(string aTime)//将时间字符串转化为分钟
        {
            string[] str = aTime.Split(':');
            double aMinute1 = Convert.ToDouble(str[0]);
            double aMinute2 = Convert.ToDouble(str[1]);
            double aMinute = aMinute1 * 60 + aMinute2;
            return aMinute;
        }

        public List<double> GetTravelSpeed()//所有车的旅行速度
        {
            List<double> TravelSpeed = new List<double>();
            foreach (Train aTrain in dm.TrainList)
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue2[2]);
                double aTime2 = GetMinute(staDicValue2[0]);//终到站的到达时间
                double aTime = aTime2 - aTime1;
                double aSpeed = 60 * aMile / aTime;
                TravelSpeed.Add(aSpeed);
            }
            return TravelSpeed;
        }

        public List<double> GetTechnicalSpeed()//所有车的技术速度
        {
            List<double> TechnicalSpeed = new List<double>();
            foreach (Train aTrain in dm.TrainList)
            {
                int stationNum = aTrain.staList.Count-1;
                double aTime = 0;
                for (int i = 0; i < stationNum; i++)
                {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[i]];//出发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//出发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[i+1]];//到达站的信息列表
                double aTime2 = GetMinute(staDicValue2[0]);//到达站的到达时间
                aTime = aTime + aTime2 - aTime1;
                }
                List<string> staDicValue3 = new List<string>();
                staDicValue3 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue3[2]);//终到站的累计里程
                double aSpeed = 60 * aMile / aTime;
                TechnicalSpeed.Add(aSpeed);
            }
            return TechnicalSpeed;
        }

        public List<double> GetSpeedIndex()//速度系数
        {
            List<double> SpeedIndex = new List<double>();
            List<double> Speed1 = GetTravelSpeed();
            List<double> Speed2 = GetTechnicalSpeed();
            for (int i = 0; i < Speed1.Count; i++)
            {
                double aSpeedIndex = Speed1[i] / Speed2[i];
                SpeedIndex.Add(aSpeedIndex);
            }
            return SpeedIndex;
        }

        public int GetHour(string aTime)//获得出发或者到达时刻是在哪一个小时里
        {
            int aHour = 0;
            if (aTime != "")
            {
                string[] str = aTime.Split(':');
                aHour = Convert.ToInt32(str[0]);
            }
            return aHour;
        }

        public Dictionary<string, int[]> GetStationServiceCount(DataManager dmm)//车站服务次数，即有多少趟列车在本站进行服务，并按3小时为间隔将6-24点划分为6个时间段
        {
            DataManager dm = dmm;
            Dictionary<string, int[]> StationService = new Dictionary<string, int[]>();
            foreach (string sta in dm.stationStringList)
            {
                int[] aCount = new int[] { 0, 0, 0, 0, 0, 0 };
                foreach (Train aTrain in dm.TrainList)
                {
                    if (!aTrain.staTimeDic.Keys.Contains(sta))
                        continue;
                    
                    List<string> aList1 = aTrain.staTimeDic[sta];
                    int aHour1 = GetHour(aList1[0]);
                    int aHour2 = GetHour(aList1[1]);
                    for (int i = 0; i < 6; i++)
                    {
                         if (aHour1 == 0)//始发站
                        {
                            if (aHour2 >= (3 * i + 6) && aHour2 <= (3 * i + 9))
                            {
                                aCount[i]++;
                            }
                        }
                        else if (aHour2 == 0)//终到站
                        {
                            if (aHour1 >= (3 * i + 6) && aHour1 <= (3 * i + 9))
                            {
                                aCount[i]++;
                            }
                        }
                        else if (aList1[0] != aList1[1])//非通过的中间车站
                        {
                            if (aHour1 >= (3 * i + 6) && aHour1 <= (3 * i + 9))
                            {
                                aCount[i]++;
                            }
                        }
                    }
                }
                StationService.Add(sta, aCount);
            }
            return StationService;
        }

        public List<int> GetServiceFrequency()//所有车的服务频率（停站次数及列车级别）级别还没有加
        {
            List<int> ServiceFrequency = new List<int>();
            int aCount = 2;
            foreach (Train aTrain in dm.TrainList)
            {
                int stationNum = aTrain.staList.Count - 1;
                for (int i = 1; i < stationNum; i++)
                {
                    List<string> staDicValue1 = new List<string>();
                    staDicValue1 = aTrain.staTimeDic[aTrain.staList[i]];//车站的信息列表
                    double aTime1 = GetMinute(staDicValue1[0]);//列车在该站的到达时间
                    double aTime2 = GetMinute(staDicValue1[1]);//列车在该站的出发时间
                    if (aTime2 - aTime1 != 0)
                    {
                        aCount += 1;
                    }
                }
                 ServiceFrequency.Add(aCount);
            }
            return ServiceFrequency;
        }

        public List<int> AllDensity = new List<int>();//读取所有密度值，用来在Assessform中判断可视化条形图大小
        public Dictionary<List<string>, List<int>> GetTrainDensity(DataManager dmm)//列车密度表_返回形式(<站名，站名> -> <上行列车数，下行列车数>)
        {
            DataManager dm = dmm;
            Dictionary<List<string>, List<int>> TrainDensity = new Dictionary<List<string>, List<int>>();
            List<string> StationName = dm.stationStringList;
            for (int i = 0; i < StationName.Count - 1; i++)
            {
                List<string> Section = new List<string>();
                Section.Add(StationName[i]);
                Section.Add(StationName[i + 1]);
                List<int> Density = new List<int>();
                int DensityUp = 0;
                int DensityDown = 0;
                foreach (Train aTrain in dm.UpTrainDic.Values)
                {
                    for (int j = 0; j < aTrain.staList.Count - 1; j++)
                    {
                        if (StationName[i] == aTrain.staList[j] && StationName[i + 1] == aTrain.staList[j + 1])
                        {
                            DensityUp++;
                        }
                    }
                }
                Density.Add(DensityUp);
                AllDensity.Add(DensityUp);
                foreach (Train aTrain in dm.DownTrainDic.Values)
                {
                    for (int j = 0; j < aTrain.staList.Count - 1; j++)
                    {
                        if (StationName[i + 1] == aTrain.staList[j] && StationName[i] == aTrain.staList[j + 1])
                        {
                            DensityDown++;
                        }
                    }
                }
                Density.Add(DensityDown);
                AllDensity.Add(DensityDown);
                TrainDensity.Add(Section, Density);
            }
            return TrainDensity;
        }
        
    }
}
