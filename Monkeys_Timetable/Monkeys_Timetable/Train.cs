using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monkeys_Timetable
{
    /// <summary>
    ///存入各列车的到发时刻及停站信息
    /// </summary>
    public class Train 
    {
        /// <summary>
        ///判断是否初次生成trainDic
        /// </summary>
        public bool newbool = true;
        /// <summary>
        /// 冲突所在bmp中点位
        /// </summary>
        ///         
        private string x_trainNo;
        /// <summary>
        ///车次信息
        /// </summary>
        public string TrainNo
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
        /// <summary>
        ///始发站
        /// </summary>
        private string x_OriSta; 
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
        /// <summary>
        ///终到站
        /// </summary>
        private string x_DesSta; 
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
        private Dictionary<string, List<string>> x_staTimeDic;
        /// <summary>
        ///存放列车在各站时刻信息
        /// </summary>
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

        private List<string> x_staList;
        /// <summary>
        ///存放列车在各站时刻信息
        /// </summary>
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
        private Dictionary<string, List<int>> x_MinuteDic;
        /// <summary>
        ///存放列车在各站时刻int信息
        /// </summary>
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
        private Dictionary<string, bool> x_isStopDic;
        /// <summary>
        ///存放列车是否停站信息，true为停，false为不停
        /// </summary>
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
        private string x_ConflictString;
        /// <summary>
        ///冲突描述字符串
        /// </summary>
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
        /// <summary>
        /// 列车速度
        /// </summary>
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
        /// <summary>
        /// 列车运行方向
        /// </summary>
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
        private List<Dictionary<string, List<PointF>>> x_TrainPointList;
        /// <summary>
        /// 列车在bmp中点位信息
        /// </summary>
        public List<Dictionary<string, List<PointF>>> TrainPointList
        {
            get
            {
                if(x_TrainPointList == null)
                {
                    x_TrainPointList = new List<Dictionary<string, List<PointF>>>();
                }
                return x_TrainPointList;
            }
            set
            {
                x_TrainPointList = value;
            }
        }
        /// <summary>
        /// 列车支线信息
        /// 空表示仅为主线车
        /// 1,2,3……表示支线号
        /// 列车在多个支线则把支线号存在数组中
        /// 支线号在读取车站画图信息的字典中读得
        /// </summary>
        public List<int> BranchNum;

    }
}
