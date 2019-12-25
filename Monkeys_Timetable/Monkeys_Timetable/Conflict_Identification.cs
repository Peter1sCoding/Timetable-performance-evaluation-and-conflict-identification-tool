using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Monkeys_Timetable
{

    class Conflict_Identification //封装判断各类间隔时间的方法
    {
        public List<Station> stationList;
        public Dictionary<string, Dictionary<string, int>> HeadwayDic;
        public Dictionary<string, Train> TrainDic;
        public List<Conflict> ConflictList;

        private List<String> x_ConflictTrains;
        public List<String> ConflictTrains
        {
            get
            {
                return x_ConflictTrains;
            }
            set
            {
                x_ConflictTrains = value;
            }
        }

        public Conflict_Identification (List<Station> stationList, Dictionary<string, Dictionary<string, int>> HeadwayDic,Dictionary<string,Train> TrainDic)
        {
            this.stationList = stationList;
            this.HeadwayDic = HeadwayDic;
            this.TrainDic = TrainDic;
        }
        public void Conflict_Judge()
        {
            ConflictTrains = new List<string>();
            
            
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
                                Conflict c = new Conflict();
                                c.ConflictSta = stationList[i].stationName;
                                c.ConflictType = "到到";
                                c.FrontTrain = stationList[i].upStaTraArrList[j];
                                c.LatterTrain = stationList[i].upStaTraArrList[j + 1];
                                ConflictList.Add(c);
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + "," + stationList[i].upStaTraArrList[j + 1].trainNo + ",到到");                               
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["到通"]))
                            {
                                Conflict c = new Conflict();
                                c.ConflictSta = stationList[i].stationName;
                                c.ConflictType = "到通";
                                c.FrontTrain = stationList[i].upStaTraArrList[j];
                                c.LatterTrain = stationList[i].upStaTraArrList[j + 1];
                                ConflictList.Add(c);
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + "," + stationList[i].upStaTraArrList[j + 1].trainNo + ",到通");
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通到"]))
                            {
                                Conflict c = new Conflict();
                                c.ConflictSta = stationList[i].stationName;
                                c.ConflictType = "通到";
                                c.FrontTrain = stationList[i].upStaTraArrList[j];
                                c.LatterTrain = stationList[i].upStaTraArrList[j + 1];
                                ConflictList.Add(c);
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + "," + stationList[i].upStaTraArrList[j + 1].trainNo + ",通到");
                            }
                        }

                        if ((stationList[i].upStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].upStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraArrList[j].speed]["通通"]))
                            {
                                Conflict c = new Conflict();
                                c.ConflictSta = stationList[i].stationName;
                                c.ConflictType = "通通";
                                c.FrontTrain = stationList[i].upStaTraArrList[j];
                                c.LatterTrain = stationList[i].upStaTraArrList[j + 1];
                                ConflictList.Add(c);
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraArrList[j].trainNo + "," + stationList[i].upStaTraArrList[j + 1].trainNo + ",通通");
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
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + "," + stationList[i].upStaTraDepList[j + 1].trainNo + ",发发");
                            }
                        }

                        if ((stationList[i].upStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].upStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraDepList[j].speed]["发通"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + "," + stationList[i].upStaTraDepList[j + 1].trainNo + ",发通");
                            }
                        }

                        if ((stationList[i].upStaTraDepList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].upStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].upStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].upStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].upStaTraDepList[j].speed]["通发"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].upStaTraDepList[j].trainNo + "," + stationList[i].upStaTraDepList[j + 1].trainNo + ",通发");
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
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + "," + stationList[i].downStaTraArrList[j + 1].trainNo + ",到到");
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["到通"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + "," + stationList[i].downStaTraArrList[j + 1].trainNo + ",到通");
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["通到"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + "," + stationList[i].downStaTraArrList[j + 1].trainNo + ",通到");
                            }
                        }

                        if ((stationList[i].downStaTraArrList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraArrList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraArrList[j + 1].MinuteDic[stationList[i].stationName][0] - stationList[i].downStaTraArrList[j].MinuteDic[stationList[i].stationName][0] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraArrList[j].speed]["通通"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraArrList[j].trainNo + "," + stationList[i].downStaTraArrList[j + 1].trainNo + ",通通");
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
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + "," + stationList[i].downStaTraDepList[j + 1].trainNo + ",发发");
                            }
                        }
                        if ((stationList[i].downStaTraDepList[j].isStopDic[stationList[i].stationName] == true) && (stationList[i].downStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == false))
                        {
                            if ((stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraDepList[j].speed]["发通"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + "," + stationList[i].downStaTraDepList[j + 1].trainNo + ",发通");                              
                            }
                        }
                        if ((stationList[i].downStaTraDepList[j].isStopDic[stationList[i].stationName] == false) && (stationList[i].downStaTraDepList[j + 1].isStopDic[stationList[i].stationName] == true))
                        {
                            if ((stationList[i].downStaTraDepList[j + 1].MinuteDic[stationList[i].stationName][1] - stationList[i].downStaTraDepList[j].MinuteDic[stationList[i].stationName][1] < HeadwayDic[stationList[i].stationName + "up" + stationList[i].downStaTraDepList[j].speed]["通发"]))
                            {
                                ConflictTrains.Add(stationList[i].stationName + "," + stationList[i].downStaTraDepList[j].trainNo + "," + stationList[i].downStaTraDepList[j + 1].trainNo + ",通发");
                            }
                        }
                    }                    
                }
                #endregion
            }
        }
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号");
            dt.Columns.Add("车站");
            dt.Columns.Add("前车");
            dt.Columns.Add("前车到发时刻");
            dt.Columns.Add("后车");
            dt.Columns.Add("后车到发时刻");
            dt.Columns.Add("冲突类型");

            for(int i = 0; i < ConflictTrains.Count; i++)
            {
                string[] str = ConflictTrains[i].Split(',');
                dt.Rows.Add(i + 1, str[0], str[1], TrainDic[str[1]].staTimeDic[str[0]][0] + "," + TrainDic[str[1]].staTimeDic[str[0]][1], str[2], TrainDic[str[2]].staTimeDic[str[0]][0] + "," + TrainDic[str[2]].staTimeDic[str[0]][1], str[3]);
            }
            return dt;
       
        }
    }
}
