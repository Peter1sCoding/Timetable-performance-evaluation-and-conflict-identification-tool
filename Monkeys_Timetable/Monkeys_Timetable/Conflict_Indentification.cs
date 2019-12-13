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
                #region 判断上行到达冲突
                for (int j = 0; j < stationList[i].upStaTraArrList.Count - 1; j++)
                {
                    if((stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0]!=0)&&(stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] != 0))
                    {
                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["到到"]))
                            {
                                stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + ",到到," + stationList[i].upStaTraArrList[j + 1].trainNo, stationList[i].upStaTraArrList[j + 1]);
                                //stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到到," + stationList[i].upStaTraArrList[j].trainNo, stationList[i].upStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["到通"]))
                            {
                                stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + ",到通," + stationList[i].upStaTraArrList[j + 1].trainNo, stationList[i].upStaTraArrList[j + 1]);
                                //stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到通," + stationList[i].upStaTraArrList[j].trainNo, stationList[i].upStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通到"]))
                            {
                                stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + ",通到," + stationList[i].upStaTraArrList[j + 1].trainNo, stationList[i].upStaTraArrList[j + 1]);
                                //stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通到," + stationList[i].upStaTraArrList[j].trainNo, stationList[i].upStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通通"]))
                            {
                                stationList[i].upStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + ",通通," + stationList[i].upStaTraArrList[j + 1].trainNo, stationList[i].upStaTraArrList[j + 1]);
                                //stationList[i].upStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通通,"+ stationList[i].upStaTraArrList[j].trainNo, stationList[i].upStaTraArrList[j]);
                            }
                        }
                    }                   
                }
                #endregion
                #region 判断上行出发冲突
                for (int j = 0; j < stationList[i].upStaTraDepList.Count - 1; j++)
                {
                    if ((stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] != 0) && (stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] != 0))
                    {
                        if ((stationList[i].upStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraDepList[j].speed]["发发"]))
                            {
                                stationList[i].upStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + ",发发," + stationList[i].upStaTraDepList[j + 1].trainNo, stationList[i].upStaTraDepList[j + 1]);
                                //stationList[i].upStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",发发," + stationList[i].upStaTraDepList[j].trainNo, stationList[i].upStaTraDepList[j]);
                            }
                        }

                        if ((stationList[i].upStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraDepList[j].speed]["发通"]))
                            {
                                stationList[i].upStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + ",发通," + stationList[i].upStaTraDepList[j + 1].trainNo, stationList[i].upStaTraDepList[j + 1]);
                                //stationList[i].upStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",发通," + stationList[i].upStaTraDepList[j].trainNo, stationList[i].upStaTraDepList[j]);
                            }
                        }

                        if ((stationList[i].upStaTraDepList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraDepList[j].speed]["通发"]))
                            {
                                stationList[i].upStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + ",通发," + stationList[i].upStaTraDepList[j + 1].trainNo, stationList[i].upStaTraDepList[j + 1]);
                                //stationList[i].upStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通发," + stationList[i].upStaTraDepList[j].trainNo, stationList[i].upStaTraDepList[j]);
                            }
                        }
                    }                                    
                }
                #endregion
                #region 判断下行到达冲突
                for (int j = 0; j < stationList[i].downStaTraArrList.Count - 1; j++)
                {
                    if ((stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] != 0) && (stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] != 0))
                    {
                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["到到"]))
                            {
                                stationList[i].downStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + ",到到," + stationList[i].downStaTraArrList[j + 1].trainNo, stationList[i].downStaTraArrList[j + 1]);
                                //stationList[i].downStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到到," + stationList[i].downStaTraArrList[j].trainNo, stationList[i].downStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["到通"]))
                            {
                                stationList[i].downStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + ",到通," + stationList[i].downStaTraArrList[j + 1].trainNo, stationList[i].downStaTraArrList[j + 1]);
                                //stationList[i].downStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",到通," + stationList[i].downStaTraArrList[j].trainNo, stationList[i].downStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["通到"]))
                            {
                                stationList[i].downStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + ",通到," + stationList[i].downStaTraArrList[j + 1].trainNo, stationList[i].downStaTraArrList[j + 1]);
                                //stationList[i].downStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通到," + stationList[i].downStaTraArrList[j].trainNo, stationList[i].downStaTraArrList[j]);
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["通通"]))
                            {
                                stationList[i].downStaTraArrList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + ",通通," + stationList[i].downStaTraArrList[j + 1].trainNo, stationList[i].downStaTraArrList[j + 1]);
                                //stationList[i].downStaTraArrList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通通," + stationList[i].downStaTraArrList[j].trainNo, stationList[i].downStaTraArrList[j]);
                            }
                        }
                    }
                    


                }
                #endregion
                #region 判断下行出发冲突
                for (int j = 0; j < stationList[i].downStaTraDepList.Count - 1; j++)
                {
                    if ((stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] != 0) && (stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] != 0))
                    {
                        if ((stationList[i].downStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraDepList[j].speed]["发发"]))
                            {
                                stationList[i].downStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + ",发发," + stationList[i].downStaTraDepList[j + 1].trainNo, stationList[i].downStaTraDepList[j + 1]);
                                //stationList[i].downStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",发发," + stationList[i].downStaTraDepList[j].trainNo, stationList[i].downStaTraDepList[j]);
                            }
                        }

                        if ((stationList[i].downStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraDepList[j].speed]["发通"]))
                            {
                                stationList[i].downStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + ",发通," + stationList[i].downStaTraDepList[j + 1].trainNo, stationList[i].downStaTraDepList[j + 1]);
                                //stationList[i].downStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",发通," + stationList[i].downStaTraDepList[j].trainNo, stationList[i].downStaTraDepList[j]);
                            }
                        }

                        if ((stationList[i].downStaTraDepList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraDepList[j].speed]["通发"]))
                            {
                                stationList[i].downStaTraDepList[j].ConflictTrain.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + ",通发," + stationList[i].downStaTraDepList[j + 1].trainNo, stationList[i].downStaTraDepList[j + 1]);
                                //stationList[i].downStaTraDepList[j + 1].ConflictTrain.Add(stationList[i].stationName + ",通发," + stationList[i].downStaTraDepList[j].trainNo, stationList[i].downStaTraDepList[j]);
                            }
                        }
                    }                    
                }
                #endregion
            }
        }
    }
}
