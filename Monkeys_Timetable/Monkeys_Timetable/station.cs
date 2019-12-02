using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class station
    {
        private string x_stationNo;//车站序号
        public string stationNo
        {
            get
            {
                return x_stationNo;
            }
            set
            {
                value = x_stationNo;
            }
        }

        private string x_stationName;//车站名称
        public string stationName
        {
            get
            {
                return x_stationName;
            }
            set
            {
                value = x_stationName;
            }
        }

        private int x_totalMile; //车站累计里程
        public int totalMile
        {
            get
            {
                return x_totalMile;
            }
            set
            {
                value = x_totalMile;
            }
        }
    }
}
