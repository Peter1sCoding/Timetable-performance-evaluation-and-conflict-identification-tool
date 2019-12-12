using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monkeys_Timetable
{

    class Conflict_Indentification //封装判断各类间隔时间的方法
    {
        public List<Station> stationList;
        public Dictionary<string, Dictionary<string, int>> HeadwayDic;

        public Conflict_Indentification (List<Station> stationList, Dictionary<string, Dictionary<string, int>> HeadwayDic)
        {
            this.stationList = stationList;
            this.HeadwayDic = HeadwayDic;
        }
        public void Conflict_Judge()
        {
            #region 为各个车站的到达出发列表new一个冲突字典
            for(int i = 0; i < stationList.Count; i++)
            {
                for(int j = 0; j < stationList[i].upStaTraArrList.Count; j++)
                {
                    stationList[i].upStaTraArrList[j].ConflictTrain = new Dictionary<string, Train>();
                }
            }
            for (int i = 0; i < stationList.Count; i++)
            {
                for (int j = 0; j < stationList[i].upStaTraDepList.Count; j++)
                {
                    stationList[i].upStaTraDepList[j].ConflictTrain = new Dictionary<string, Train>();
                }
            }
            for (int i = 0; i < stationList.Count; i++)
            {
                for (int j = 0; j < stationList[i].downStaTraArrList.Count; j++)
                {
                    stationList[i].downStaTraArrList[j].ConflictTrain = new Dictionary<string, Train>();
                }
            }
            for (int i = 0; i < stationList.Count; i++)
            {
                for (int j = 0; j < stationList[i].downStaTraDepList.Count; j++)
                {
                    stationList[i].downStaTraDepList[j].ConflictTrain = new Dictionary<string, Train>();
                }
            }
            #endregion

            for (int i = 0; i < stationList.Count; i++)
            {
                for(int j = 0; j < stationList[i].upStaTraArrList.Count - 1; j++)
                {                   
                    if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                    {
                        if((stationList[i].upStaTraArrList[j+1].MinuteDic[stationList[i].stationName][0]- stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName+"up"+ stationList[i].upStaTraArrList[j].speed]["到到"]))
                        {
                            stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + ",到到", stationList[i].upStaTraArrList[j + 1]);
                            stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到到", stationList[i].upStaTraArrList[j]);
                        }
                    }

                    if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                    {
                        if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["到通"]))
                        {
                            stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + ",到通", stationList[i].upStaTraArrList[j + 1]);
                            stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到通", stationList[i].upStaTraArrList[j]);
                        }
                    }

                    if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                    {
                        if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通到"]))
                        {
                            stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + ",通到", stationList[i].upStaTraArrList[j + 1]);
                            stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通到", stationList[i].upStaTraArrList[j]);
                        }
                    }

                    if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                    {
                        if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通通"]))
                        {
                            stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + ",通通", stationList[i].upStaTraArrList[j + 1]);
                            stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通通", stationList[i].upStaTraArrList[j]);
                        }
                    }
                }
            }
        }    
    }
}
