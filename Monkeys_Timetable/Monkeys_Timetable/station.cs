using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Station
    {
        private string x_stationNo;
        /// <summary>
        ///车站序号
        /// </summary>
        public string stationNo
        {
            get
            {
                return x_stationNo;
            }
            set
            {
                x_stationNo = value;
            }
        }

        private string x_stationName;
        /// <summary>
        ///车站名称
        /// </summary>
        public string stationName
        {
            get
            {
                return x_stationName;
            }
            set
            {
                x_stationName = value;
            }
        }

        private int x_totalMile;
        /// <summary>
        ///车站累计里程
        /// </summary>
        public int totalMile
        {
            get
            {
                return x_totalMile;
            }
            set
            {
                x_totalMile = value;
            }
        }
        private List<Train> x_upStaTraArrList;
        /// <summary>
        /// 车站上行到达列车列表
        /// </summary>
        public List<Train> upStaTraArrList
        {
            get
            {
                return x_upStaTraArrList;
            }
            set
            {
                x_upStaTraArrList = value;
            }
        }
        private List<Train> x_upStaTraDepList;
        /// <summary>
        /// 车站上行出发列车列表
        /// </summary>
        public List<Train> upStaTraDepList
        {
            get
            {
                return x_upStaTraDepList;
            }
            set
            {
                x_upStaTraDepList = value;
            }
        }
        private List<Train> x_downStaTraArrList;
        /// <summary>
        /// 车站下行到达列车列表
        /// </summary>
        public List<Train> downStaTraArrList
        {
            get
            {
                return x_downStaTraArrList;
            }
            set
            {
                x_downStaTraArrList = value;
            }
        }
        private List<Train> x_downStaTraDepList;
        /// <summary>
        /// 车站下行出发列车列表
        /// </summary>
        public List<Train> downStaTraDepList
        {
            get
            {
                return x_downStaTraDepList;
            }
            set
            {
                x_downStaTraDepList = value;
            }
        }
        private float x_x;
        /// <summary>
        ///LinePlan中的坐标
        /// </summary>
        public float x
        {
            get
            {
                return x_x;
            }
            set
            {
                x_x = value;
            }
        }
    }
}
