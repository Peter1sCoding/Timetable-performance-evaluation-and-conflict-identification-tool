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
    class Conflict
    {
        private PointF x_ConflictLocation;
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

        private Train m_FrontTrain;//冲突中的前车

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
        private Train m_LatterTrain;//冲突中的后车
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
        private String m_ConflictType;//冲突类型
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
        private String m_ConflictSta; //车站到发间隔冲突所在车站
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
    }
}
