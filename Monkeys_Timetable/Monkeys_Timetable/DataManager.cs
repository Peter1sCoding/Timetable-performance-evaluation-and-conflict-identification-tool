using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
