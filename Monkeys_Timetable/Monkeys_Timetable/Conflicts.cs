using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{
    public class Conflict
    {
        private PointF x_ConflictLocation;
        /// <summary>
        /// 冲突所在bmp中点位
        /// </summary>
        public PointF ConflictLocation
        {
            get
            {
                return x_ConflictLocation;
            }
            set
            {
                x_ConflictLocation = value;
            }
        }

        private Train m_FrontTrain;
        /// <summary>
        /// 冲突中的前车
        /// </summary>
        public Train FrontTrain
        {
            get
            {
                return m_FrontTrain;
            }
            set
            {
                m_FrontTrain = value;
            }
        }
        private Train m_LatterTrain;
        /// <summary>
        /// 冲突中的后车
        /// </summary>
        public Train LatterTrain
        {
            get
            {
                return m_LatterTrain;
            }
            set
            {
                m_LatterTrain = value;
            }
        }
        private String m_ConflictType;
        /// <summary>
        /// 冲突类型
        /// </summary>
        public String ConflictType
        {
            get
            {
                return m_ConflictType;
            }
            set
            {
                m_ConflictType = value;
            }
        }
        private String m_ConflictSta; 
        /// <summary>
        /// 车站到发间隔冲突所在车站
        /// </summary>
        public String ConflictSta
        {
            get
            {
                return m_ConflictSta;
            }
            set
            {
                m_ConflictSta = value;
            }
        }
        private String m_FrontTime;
        public String FrontTime
        {
            get
            {
                return m_FrontTime;
            }
            set
            {
                m_FrontTime = value;
            }
        }
        private String m_LatterTime;
        public String LatterTime
        {
            get
            {
                return m_LatterTime;
            }
            set
            {
                m_LatterTime = value;
            }
        }

    }
}
