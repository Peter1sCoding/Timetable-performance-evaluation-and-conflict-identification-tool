using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Assessment//封装各类运行图指标计算方法
    {
        public DataManager aDataManager = new DataManager();
        public double GetTravelSpeed()
        {
            double SumMile = 0;
            foreach (Train aTrain in aDataManager.trainList)
            {
                SumMile += Convert.ToDouble(aTrain.trainNo);//添加方法后改为SumMile += aTrain.GetMile();
            }
            double TravelSpeed = SumMile / aDataManager.trainList.Count();//添加方法后改为 RunningTime += trainlaststation.ArriveTime -  trainfirststation.DeptureTime;
            return TravelSpeed;
        }

        public double GetTechnicalSpeed()
        {
            double SumMile = 0;
            double RunningTime = 0;
            foreach (Train aTrain in aDataManager.trainList)
            {
                SumMile += Convert.ToDouble(aTrain.trainNo);//添加方法后改为SumMile += aTrain.GetMile();
            }
            foreach (Train aTrain in aDataManager.trainList)
            {
                RunningTime += Convert.ToDouble(aTrain.trainNo);//添加方法后改为 RunningTime += trainNo.ArriveTime - trainNo+1.DeptureTime;(for i从开始到最后)
            }
            double TechnicalSpeed = SumMile / RunningTime;
            return TechnicalSpeed;
        }

        public double GetIndexOfSpeed()
        {
            double IndexOfSpeed = GetTravelSpeed() / GetTechnicalSpeed();
            return IndexOfSpeed;
        }

        public int GetServiceFrequency()
        {
            int ServiceFrequency = 0;
            //输入数字得到需要查看哪一辆车的服务频率
            //if(trainNo.DeptureTime or trainNo.ArriveTime == null)
            //{
            //    ServiceFrequency += 1;
            //}
            //elseif(trainNo.DeptureTime - trainNo.ArriveTime > 0)
            //{
            //    ServiceFrequency += 1;
            //}
            return ServiceFrequency;
        }

        public int GetStationServiceCount()
        {
            //输入数字得到需要查看哪一个站的服务次数
            int StationServiceCount = 0;
            foreach (Train aTrain in aDataManager.trainList)
            {
                //每一辆车在这个站的出发时间-到达时间>0 
                //if(trainNo.DeptureTime or trainNo.ArriveTime == null)
                //{
                //    ServiceFrequency += 1;
                //}
                //elseif(trainNo.DeptureTime - trainNo.ArriveTime > 0)
                //{
                //    ServiceFrequency += 1;
                //}
                //如果需要划分时间 可以通过if判断 每个时段分别Count
            }
            return StationServiceCount;
        }
    }
}
