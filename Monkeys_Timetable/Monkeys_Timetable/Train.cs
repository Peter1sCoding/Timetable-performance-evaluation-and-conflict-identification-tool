using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monkeys_Timetable
{
    public class Train //存入各列车的到发时刻及停站信息
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
        private Dictionary<string, List<int>> x_MinuteDic; //存放列车在各站时刻int信息
        public Dictionary<string, List<int>> MinuteDic
        {
            get
            {
                return x_MinuteDic;
            }
            set
            {
                x_MinuteDic = value;
            }
        }
        private Dictionary<string, bool> x_isStopDic; //存放列车是否停站信息，true为停，false为不停
        public Dictionary<string, bool> isStopDic
        {
            get
            {
                return x_isStopDic;
            }
            set
            {
                x_isStopDic = value;
            }
        }
        private string x_ConflictString; //终到站
        public string ConflictString
        {
            get
            {
                return x_ConflictString;
            }
            set
            {
                x_ConflictString = value;
            }
        }
        private string x_speed;
        public string speed
        {
            get
            {
                return x_speed;
            }
            set
            {
                x_speed = value;
            }
        }
        private string x_Dir;
        public string Dir
        {
            get
            {
                return x_Dir;
            }
            set
            {
                x_Dir = value;
            }
        }
        public Dictionary<string, List<PointF>> trainPointDic = new Dictionary<string, List<PointF>>();

    }
}
