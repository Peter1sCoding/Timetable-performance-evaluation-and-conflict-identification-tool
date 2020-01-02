using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Assessment//封装各类运行图指标计算方法
    {
        /// <summary>
        /// 将时间字符串转化为分钟
        /// </summary>
        public double GetMinute(string aTime)
        {
            double aMinute1, aMinute2, aMinute;
            if (aTime != "")
            {
                string[] str = aTime.Split(':');
                aMinute1 = Convert.ToDouble(str[0]);
                aMinute2 = Convert.ToDouble(str[1]);
                aMinute = aMinute1 * 60 + aMinute2;
            }
            else
            {
                aMinute = 0;
            }
            return aMinute;
        }

        /// <summary>
        /// 计算上下行车的早晚时间，总早晚时间
        /// </summary>
        public List<string> UpDownTime(DataManager dmm)//上下行车的早晚时间，总早晚时间
        {
            DataManager dm = dmm;
            List<string> UpDownTime = new List<string>();
            string UpEarlyTime = "", UpLateTime = "", DownEarlyTime = "", DownLateTime = "";
            double UpMinTime = 1440, UpMaxTime = 0, DownMinTime = 1440, DownMaxTime = 0;
            foreach (Train aTrain in dm.upTrainList)//上行列车的早晚时间
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aTime2 = GetMinute(staDicValue2[0]);//终到站的到达时间
                if (UpMinTime > aTime1)//寻找上行最早出发时间
                {
                    UpMinTime = aTime1;
                    UpEarlyTime = staDicValue1[1];
                }
                if (UpMaxTime < aTime2)//寻找上行最晚到达时间
                {
                    UpMaxTime = aTime2;
                    UpLateTime = staDicValue2[0];
                }
            }
            UpDownTime.Add(UpEarlyTime);
            UpDownTime.Add(UpLateTime);

            foreach (Train aTrain in dm.downTrainList)//下行列车早晚时间
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aTime2 = GetMinute(staDicValue2[0]);//终到站的到达时间
                if (DownMinTime > aTime1)//寻找下行最早出发时间
                {
                    DownMinTime = aTime1;
                    DownEarlyTime = staDicValue1[1];
                }
                if (DownMaxTime < aTime2)//寻找下行最晚到达时间
                {
                    DownMaxTime = aTime2;
                    DownLateTime = staDicValue2[0];
                }
            }
            UpDownTime.Add(DownEarlyTime);
            UpDownTime.Add(DownLateTime);

            if (GetMinute(UpEarlyTime) > GetMinute(DownEarlyTime))//寻找全部最早出发时间
            {
                UpDownTime.Add(DownEarlyTime);
            }
            else
            {
                UpDownTime.Add(UpEarlyTime);
            }
            if (GetMinute(UpLateTime) > GetMinute(DownLateTime))//寻找全部最晚到达时间
            {
                UpDownTime.Add(UpLateTime);
            }
            else
            {
                UpDownTime.Add(DownLateTime);
            }

            return UpDownTime;
        }

        /// <summary>
        /// 计算上下行车的旅行速度，总旅行速度
        /// </summary>
        public List<double> UpDownTravelSpeed(DataManager dmm)//上下行车的旅行速度，总旅行速度
        {
            DataManager dm = dmm;
            List<double> UpDownTravelSpeed = new List<double>();
            double UpSumMile = 0, UpSumTravelTime = 0, DownSumMile = 0, DownSumTravelTime = 0, SumMile = 0, SumTravelTime = 0;
            foreach (Train aTrain in dm.upTrainList)//上行列车的旅行速度
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue2[2]);
                double aTime2 = GetMinute(staDicValue2[0]);//终到站的到达时间
                double aTime = aTime2 - aTime1;
                UpSumMile = UpSumMile + aMile;
                UpSumTravelTime = UpSumTravelTime + aTime;
            }
            SumMile = SumMile + UpSumMile;
            SumTravelTime = SumTravelTime + UpSumTravelTime;
            double UpTravelSpeed = 60 * UpSumMile / UpSumTravelTime;//计算上行列车的旅行速度
            UpTravelSpeed = Math.Round(UpTravelSpeed, 2);
            UpDownTravelSpeed.Add(UpTravelSpeed);

            foreach (Train aTrain in dm.downTrainList)//下行列车的旅行速度
            {
                List<string> staDicValue1 = new List<string>();
                staDicValue1 = aTrain.staTimeDic[aTrain.staList[0]];//始发站的信息列表
                double aTime1 = GetMinute(staDicValue1[1]);//始发站的出发时间
                List<string> staDicValue2 = new List<string>();
                staDicValue2 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue2[2]);
                double aTime2 = GetMinute(staDicValue2[0]);//终到站的到达时间
                double aTime = aTime2 - aTime1;
                DownSumMile = DownSumMile + aMile;
                DownSumTravelTime = DownSumTravelTime + aTime;
            }
            SumMile = SumMile + DownSumMile;
            SumTravelTime = SumTravelTime + DownSumTravelTime;
            double DownTravelSpeed = 60 * DownSumMile / DownSumTravelTime;//计算下行列车的旅行速度
            DownTravelSpeed = Math.Round(DownTravelSpeed, 2);
            UpDownTravelSpeed.Add(DownTravelSpeed);
            double SumTravelSpeed= 60 * SumMile / SumTravelTime;//计算上下行所有列车的平均旅行速度
            SumTravelSpeed = Math.Round(SumTravelSpeed, 2);
            UpDownTravelSpeed.Add(SumTravelSpeed);

            return UpDownTravelSpeed;
        }

        /// <summary>
        /// 计算每一列车的旅行速度
        /// </summary>
        public List<double> GetTravelSpeed(DataManager dmm)//每一列车的旅行速度
        {
            DataManager dm = dmm;
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
                aSpeed = Math.Round(aSpeed, 2);
                TravelSpeed.Add(aSpeed);
            }
            return TravelSpeed;
        }

        /// <summary>
        /// 计算上下行车的技术速度，总技术速度
        /// </summary>
        public List<double> UpDownTechnicalSpeed(DataManager dmm)//上下行车的技术速度，总技术速度
        {
            DataManager dm = dmm;
            List<double> UpDownTechnicalSpeed = new List<double>();
            double UpSumMile = 0, UpSumTechnicalTime = 0, DownSumMile = 0, DownSumTechnicalTime = 0, SumMile = 0, SumTechnicalTime = 0;
            foreach (Train aTrain in dm.upTrainList)//上行列车的技术速度
            {
                int stationNum = aTrain.staList.Count - 1;
                double aTime = 0;
                for (int i = 0; i < stationNum; i++)
                {
                    List<string> staDicValue1 = new List<string>();
                    staDicValue1 = aTrain.staTimeDic[aTrain.staList[i]];//出发站的信息列表
                    double aTime1 = GetMinute(staDicValue1[1]);//出发站的出发时间
                    List<string> staDicValue2 = new List<string>();
                    staDicValue2 = aTrain.staTimeDic[aTrain.staList[i + 1]];//到达站的信息列表
                    double aTime2 = GetMinute(staDicValue2[0]);//到达站的到达时间
                    aTime = aTime + aTime2 - aTime1;
                }
                List<string> staDicValue3 = new List<string>();
                staDicValue3 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue3[2]);//终到站的累计里程
                UpSumMile = UpSumMile + aMile;
                UpSumTechnicalTime = UpSumTechnicalTime + aTime;
            }
            SumMile = SumMile + UpSumMile;
            SumTechnicalTime = SumTechnicalTime + UpSumTechnicalTime;
            double UpTechnicalSpeed = 60 * UpSumMile / UpSumTechnicalTime;//计算上行列车的技术速度
            UpTechnicalSpeed = Math.Round(UpTechnicalSpeed, 2);
            UpDownTechnicalSpeed.Add(UpTechnicalSpeed);

            foreach (Train aTrain in dm.downTrainList)//下行列车的技术速度
            {
                int stationNum = aTrain.staList.Count - 1;
                double aTime = 0;
                for (int i = 0; i < stationNum; i++)
                {
                    List<string> staDicValue1 = new List<string>();
                    staDicValue1 = aTrain.staTimeDic[aTrain.staList[i]];//出发站的信息列表
                    double aTime1 = GetMinute(staDicValue1[1]);//出发站的出发时间
                    List<string> staDicValue2 = new List<string>();
                    staDicValue2 = aTrain.staTimeDic[aTrain.staList[i + 1]];//到达站的信息列表
                    double aTime2 = GetMinute(staDicValue2[0]);//到达站的到达时间
                    aTime = aTime + aTime2 - aTime1;
                }
                List<string> staDicValue3 = new List<string>();
                staDicValue3 = aTrain.staTimeDic[aTrain.staList[aTrain.staList.Count - 1]];//终到站的信息列表
                double aMile = Convert.ToDouble(staDicValue3[2]);//终到站的累计里程
                DownSumMile = DownSumMile + aMile;
                DownSumTechnicalTime = DownSumTechnicalTime + aTime;
            }
            SumMile = SumMile + DownSumMile;
            SumTechnicalTime = SumTechnicalTime + DownSumTechnicalTime;
            double DownTechnicalSpeed = 60 * DownSumMile / DownSumTechnicalTime;//计算下行列车的技术速度
            DownTechnicalSpeed = Math.Round(DownTechnicalSpeed, 2);
            UpDownTechnicalSpeed.Add(DownTechnicalSpeed);
            double SumTechnicalSpeed = 60 * SumMile / SumTechnicalTime;//计算上下行所有列车的平均技术速度
            SumTechnicalSpeed = Math.Round(SumTechnicalSpeed, 2);
            UpDownTechnicalSpeed.Add(SumTechnicalSpeed);

            return UpDownTechnicalSpeed;
        }

        /// <summary>
        /// 计算每一列车的技术速度
        /// </summary>
        public List<double> GetTechnicalSpeed(DataManager dmm)//每一列车的技术速度
        {
            DataManager dm = dmm;
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
                aSpeed = Math.Round(aSpeed, 2);
                TechnicalSpeed.Add(aSpeed);
            }
            return TechnicalSpeed;
        }

        /// <summary>
        /// 计算每一列车的速度系数
        /// </summary>
        public List<double> GetSpeedIndex(DataManager dmm)//每一列车的速度系数=旅行速度/技术速度
        {
            DataManager dm = dmm;
            List<double> SpeedIndex = new List<double>();
            List<double> Speed1 = GetTravelSpeed(dm);
            List<double> Speed2 = GetTechnicalSpeed(dm);
            for (int i = 0; i < Speed1.Count; i++)
            {
                double aSpeedIndex = Speed1[i] / Speed2[i];
                aSpeedIndex = Math.Round(aSpeedIndex, 2);
                SpeedIndex.Add(aSpeedIndex);
            }
            return SpeedIndex;
        }

        /// <summary>
        /// 计算上下行车的速度系数，总速度系数
        /// </summary>
        public List<double> UpDownSpeedIndex(DataManager dmm)//上下行车的速度系数，总速度系数
        {
            DataManager dm = dmm;
            List<double> UpDownSpeedIndex = new List<double>();
            List<double> Speed1 = UpDownTravelSpeed(dm);
            List<double> Speed2 = UpDownTechnicalSpeed(dm);
            for (int i = 0; i < Speed1.Count; i++)
            {
                double aSpeedIndex = Speed1[i] / Speed2[i];
                aSpeedIndex = Math.Round(aSpeedIndex, 2);
                UpDownSpeedIndex.Add(aSpeedIndex);
            }
            return UpDownSpeedIndex;
        }

        /// <summary>
        /// 获得出发或者到达时刻是在哪一个小时里
        /// </summary>
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

        /// <summary>
        /// 计算车站服务次数，即有多少趟列车在本站进行服务，并按3小时为间隔将6-24点划分为6个时间段
        /// </summary>
        public Dictionary<string, int[]> GetStationServiceCount(DataManager dmm)//车站服务次数，即有多少趟列车在本站进行服务，并按3小时为间隔将6-24点划分为6个时间段
        {
            DataManager dm = dmm;
            Dictionary<string, int[]> StationService = new Dictionary<string, int[]>();
            foreach (string sta in dm.stationStringList)
            {
                int[] aCount = new int[] { 0, 0, 0, 0, 0, 0 };
                foreach (Train aTrain in dm.TrainList)
                {
                    if (!aTrain.staTimeDic.Keys.Contains(sta))//判断列车是否经过该车站
                    {
                        continue;
                    }
                        
                    List<string> aList1 = aTrain.staTimeDic[sta];
                    int aHour1 = GetHour(aList1[0]);//出发时间
                    int aHour2 = GetHour(aList1[1]);//到达时间
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

        /// <summary>
        /// 计算所有车的服务频率
        /// </summary>
        public List<int> GetServiceFrequency(DataManager dmm)//所有车的服务频率（即停站次数）
        {
            DataManager dm = dmm;
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
                    if (aTime2 - aTime1 != 0)//判断列车是否通过车站，若不是则服务次数加1
                    {
                        aCount += 1;
                    }
                }
                 ServiceFrequency.Add(aCount);
            }
            return ServiceFrequency;
        }

        public List<int> AllDensity = new List<int>();//读取所有密度值，用来在Assessform中判断可视化条形图大小
         /// <summary>
        /// 计算所有站的列车密度
        /// </summary>
        public Dictionary<List<string>, List<int>> GetTrainDensity(DataManager dmm)//列车密度表_返回形式(<站名，站名> -> <上行列车数，下行列车数>)
        {
            //调用方法实现PaintTool中str1的读取 完成密度值的计算
            DataManager dm = dmm;
            PaintTool pt = new PaintTool();
            PaintForm pf = new PaintForm();
            int ix = dm.stationDrawList.Count;
            List<double> staMile = new List<double>();
            for (int i = 0; i < ix; i++)
            {
                staMile.Add(dm.stationDrawList[i].totalMile);
            }
            pt.Branch(dm.stationDrawStringList, staMile, pf.bmp.Width, pf.bmp.Height);

            Dictionary<List<string>, List<int>> TrainDensity = new Dictionary<List<string>, List<int>>();
            
            for(int jjj = 1;jjj < pt.str1.Count+1;jjj++)
            {
                List<string> StationName = pt.str1[jjj];//读取各个线路的站名列表
                for (int i = 0; i < StationName.Count - 1; i++)
                {
                    List<string> Section = new List<string>();//读取区间名称
                    Section.Add(StationName[i]);
                    Section.Add(StationName[i + 1]);
                    List<int> Density = new List<int>();
                    int DensityUp = 0;
                    int DensityDown = 0;
                    foreach (Train aTrain in dm.UpTrainDic.Values)//上行列车
                    {
                        for (int j = 0; j < aTrain.staList.Count - 1; j++)
                        {
                            if (StationName[i + 1] == aTrain.staList[j] && StationName[i] == aTrain.staList[j + 1])//判断列车经过车站顺序符合则区间列车密度加1
                            {
                                DensityUp++;
                            }
                        }
                    }
                    Density.Add(DensityUp);
                    AllDensity.Add(DensityUp);

                    foreach (Train aTrain in dm.DownTrainDic.Values)//下行列车
                    {
                        for (int j = 0; j < aTrain.staList.Count - 1; j++)
                        {

                            if (StationName[i] == aTrain.staList[j] && StationName[i + 1] == aTrain.staList[j + 1])//判断列车经过车站顺序符合则区间列车密度加1
                            {
                                DensityDown++;
                            }
                        }
                    }
                    Density.Add(DensityDown);
                    AllDensity.Add(DensityDown);
                    TrainDensity.Add(Section, Density);
                }
            }
            return TrainDensity;
        }
        
    }
}