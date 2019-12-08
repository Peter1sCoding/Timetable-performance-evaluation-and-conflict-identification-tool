using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{
    class Train //存入各列车的到发时刻及停站信息
    {
        private string x_trainNo; //车次信息

        public bool newbool = true; //判断是否初次生成trainDic

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
        private Dictionary<string, List<string>> x_staTimeDic; //存放列车在各站时刻信息
        public Dictionary<string, List<string>> staTimeDic
        {
            get
            {
                return x_staTimeDic;
            }
            set
            {
                x_staTimeDic = value;
            }
        }

        private List<string> x_staList; //存放列车在各站时刻信息
        public List<string> staList
        {
            get
            {
                return x_staList;
            }
            set
            {
                x_staList = value;
            }
        }

        public int Conflict;//0,1,3,4,5,6,7        
    }
}
