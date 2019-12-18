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
    public partial class LinePlan : Form//显示开行方案
    {
        

        DataManager dm;
        Bitmap bmp;
        DataTable UpPlanTable;
        DataTable DownPlanTable;
        Graphics g;
        Brush b;
        Font font;
        Pen p;
        Dictionary<string, int> UpPlanDic;
        Dictionary<string, int> DownPlanDic;

        public LinePlan()
        {
            InitializeComponent();

            dm = new DataManager();
            dm.ReadHeadway(Application.StartupPath + @"\\车站列车安全间隔.csv");
            dm.ReadStation(Application.StartupPath + @"\\沪宁车站信息.csv");
            dm.ReadTrain(Application.StartupPath + @"\\沪宁时刻图.csv");
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();

            b = new SolidBrush(Color.Black);
            font = new Font("黑体", 10);
            p = new Pen(Color.Black, 1);

            //DrawStation();
            GetPlanTable();
            ToDataGridView();
        }
        public void GetPlanTable()
        {
            UpPlanTable = new DataTable();
            UpPlanDic = new Dictionary<string, int>();
            DownPlanTable = new DataTable();
            DownPlanDic = new Dictionary<string, int>();

            for(int i = 0; i < dm.upTrainList.Count; i++)
            {
                string StaConList = "";
                for (int j = 0; j < dm.upTrainList[i].staList.Count; j++)
                {
                    if ((j == 0) && (dm.upTrainList[i].isStopDic[dm.upTrainList[i].staList[j]] == true))
                    {
                        StaConList = dm.upTrainList[i].staList[j];
                    }
                    else if (dm.upTrainList[i].isStopDic[dm.upTrainList[i].staList[j]] == true)
                    {
                        StaConList = StaConList + "," + dm.upTrainList[i].staList[j];
                    }
                }
                if (!UpPlanDic.Keys.Contains(StaConList))
                {
                    UpPlanDic.Add(StaConList, 1);
                }
                else if (UpPlanDic.Keys.Contains(StaConList))
                {
                    UpPlanDic[StaConList] += 1;
                }
            }
            for (int i = 0; i < dm.downTrainList.Count; i++)
            {
                string StaConList = "";
                for (int j = 0; j < dm.downTrainList[i].staList.Count; j++)
                {
                    if ((j == 0) && (dm.downTrainList[i].isStopDic[dm.downTrainList[i].staList[j]] == true))
                    {
                        StaConList = dm.downTrainList[i].staList[j];
                    }                                      
                    else if(dm.downTrainList[i].isStopDic[dm.downTrainList[i].staList[j]] == true)
                    {
                        StaConList = StaConList + "," + dm.downTrainList[i].staList[j];
                    }
                }
                if (!DownPlanDic.Keys.Contains(StaConList))
                {
                    DownPlanDic.Add(StaConList, 1);
                }
                else if (DownPlanDic.Keys.Contains(StaConList))
                {
                    DownPlanDic[StaConList] += 1;
                }
            }
        }
        public void GetStaX()
        {
            float total = dm.stationList[dm.stationList.Count - 1].totalMile;

            for(int i = 0; i < dm.stationList.Count; i++)
            {
                dm.stationList[i].x = 1000 * (dm.stationList[i].totalMile / total);
            }
        }
        public void ToDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("开行数量");
            for (int i = 0; i < dm.stationStringList.Count; i++)
            {
                dt.Columns.Add(dm.stationStringList[i]);
            }
            int total = 0;
            foreach (KeyValuePair<string, int> PlanNumber in UpPlanDic)
            {                
                string[] str = PlanNumber.Key.Split(',');
                DataRow dr = dt.NewRow();
                dr["开行数量"] = UpPlanDic[PlanNumber.Key];
                total += UpPlanDic[PlanNumber.Key];
                for (int i = 0; i < dm.stationStringList.Count; i++)
                {
                    if (str.Contains(dm.stationStringList[i]))
                    {
                        dr[dm.stationStringList[i]] = "1";
                    }
                    else
                    {
                        dr[dm.stationStringList[i]] = "0";
                    }
                }
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            Console.WriteLine(total);


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("开行数量");
            for (int i = 0; i < dm.stationStringList.Count; i++)
            {
                dt1.Columns.Add(dm.stationStringList[dm.stationList.Count - 1 - i]);
            }
            foreach (KeyValuePair<string, int> PlanNumber in DownPlanDic)
            {
                string[] str = PlanNumber.Key.Split(',');
                DataRow dr = dt1.NewRow();
                dr["开行数量"] = DownPlanDic[PlanNumber.Key];
                for (int i = 0; i < dm.stationStringList.Count; i++)
                {
                    if (str.Contains(dm.stationStringList[i]))
                    {
                        dr[dm.stationStringList[i]] = "1";
                    }
                    else
                    {
                        dr[dm.stationStringList[i]] = "0";
                    }
                }
                dt1.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt1;
        }
        /*public void DrawStation()
        {
            GetPlanTable();
            bmp = new Bitmap(1000, UpPlanTable.Rows.Count * 15 + 600);
            g = Graphics.FromImage(bmp);
           
            GetStaX();
            foreach(Station sta in dm.stationList)
            {
                if ((int.Parse(sta.stationNo) % 2) == 0)
                {
                    g.DrawString(sta.stationName, font, b, sta.x, 100);
                }
                else
                {
                    g.DrawString(sta.stationName, font, b, sta.x, 150);
                }
            }
            this.pictureBox1.BackgroundImage = bmp;
        }
        */

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
