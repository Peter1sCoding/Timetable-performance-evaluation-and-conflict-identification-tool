using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Train //存入各列车的到发时刻及停站信息
    {
        private string x_trainNo; //车次信息
        public string trainNo
        {
            get
            {
                return x_trainNo;
            }
            set
            {
                x_trainNo = value;
            }
        }

        private string x_OriSta; //始发站
        public string OriSta
        {
            get
            {
                return x_OriSta;
            }
            set
            {
                x_OriSta = value;
            }
        }

        private string x_DesSta; //终到站
        public string DesSta
        {
            get
            {
                return x_DesSta;
            }
            set
            {
                x_DesSta = value;
            }
        }

        private Dictionary<string, List<int>> x_ArrDepTime; //封装列车在各站的到达出发时间以及是否停站 key为车站名，索引的List依次为到达时间、出发时间、是否停站(0、1)
        public Dictionary<string,List<int>> ArrDepTime
        {
            get
            {
                return x_ArrDepTime;
            }
            set
            {
                x_ArrDepTime = value;
            }
        }

        public int Conflict;//0,1,3,4,5,6,7
        
    }
}
