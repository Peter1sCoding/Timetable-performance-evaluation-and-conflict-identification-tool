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
            double travelSpeed = SumMile / aDataManager.trainList.Count();
            return travelSpeed;
        }

        public double GetTechnicalSpeed()
        {
            double SumMile = 0;
            foreach (Train aTrain in aDataManager.trainList)
            {
                SumMile += Convert.ToDouble(aTrain.trainNo);//添加方法后改为SumMile += aTrain.GetMile();
            }
            double travelSpeed = SumMile / aDataManager.trainList.Count();
            return travelSpeed;
        }
    }
}
