using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Assessment//封装各类运行图指标计算方法
    {
        public DataManager aDataManager = new DataManager();

        public double getMinute(string aTime)//将时间字符串转化为分钟
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
            foreach (Train aTrain in aDataManager.TrainList)
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = getMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue2[2]);
                double aTime2 = getMinute(staDicValue2[0]);//终到站的到达时间
                double aTime = aTime2 - aTime1;
                double aSpeed = aMile / aTime;
                TravelSpeed.Add(aSpeed);
            }
            return TravelSpeed;
        }

        public List<double> GetTechnicalSpeed()//所有车的技术速度
        {
            List<double> TechnicalSpeed = new List<double>();
            foreach (Train aTrain in aDataManager.TrainList)
            {
                int stationNum = aTrain.staList.Count-1;
                double aTime = 0;
                for (int i = 0; i < stationNum; i++)
                {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[i]];//出发站的信息列表
                double aTime1 = getMinute(staDicValue1[1]);//出发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[i+1]];//到达站的信息列表
                double aTime2 = getMinute(staDicValue2[0]);//到达站的到达时间
                aTime = aTime + aTime2 - aTime1;
                }
                List<string> staDicValue3 = new List<string>();
                staDicValue3 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue3[2]);
                double aSpeed = aMile / aTime;
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

        public int GetHour(string aTime)//获得出发到达时刻在哪一个小时里
        {
            string[] str = aTime.Split(':');
            int aHour = Convert.ToInt32(str[0]);
            return aHour;
        }

        public Dictionary<string, int[]> GetStationServiceCount()//车站服务次数
        {
            Dictionary<string, int[]> StationService = new Dictionary<string, int[]>();
            foreach (string sta in aDataManager.stationStringList)
            {
                int[] aCount = new int[] { 0, 0, 0, 0, 0, 0 };
                for (int i = 0; i < 6; i++)
                {
                    foreach (Train aTrain in aDataManager.TrainList)
                    {
                        List<string> aList1 = aTrain.staTimeDic[sta];
                        int aHour1 = GetHour(aList1[0]);
                        int aHour2 = GetHour(aList1[1]);
                        if (aHour1 >= (3 * i + 6) && aHour1 <= (3 * i + 9))
                            aCount[i]++;
                        if (aHour2 >= (3 * i + 6) && aHour2 <= (3 * i + 9))
                            aCount[i]++;
                    }
                }
                StationService.Add(sta, aCount);
            }
            return StationService;
        }
      
       
        //public int GetServiceFrequency()
        //{
        //    int ServiceFrequency = 0;
        //    //输入数字得到需要查看哪一辆车的服务频率
        //    //if(trainNo.DeptureTime or trainNo.ArriveTime == null)
        //    //{
        //    //    ServiceFrequency += 1;
        //    //}
        //    //elseif(trainNo.DeptureTime - trainNo.ArriveTime > 0)
        //    //{
        //    //    ServiceFrequency += 1;
        //    //}
        //    return ServiceFrequency;
        //}

     
    }
}
