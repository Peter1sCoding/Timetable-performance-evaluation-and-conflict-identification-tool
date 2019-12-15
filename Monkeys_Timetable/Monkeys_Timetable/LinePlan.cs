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
    public partial class LinePlan : Form
    {
        //显示开行方案

        DataManager dm;
        Bitmap bmp;
        DataTable PlanTable;
        Graphics g;
        Brush b;
        Font font;
        Pen p;
        Dictionary<string, int> PlanDic;
            
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
            PlanTable = new DataTable();
            PlanDic = new Dictionary<string, int>();
            for(int i = 0; i < dm.stationList.Count; i++)
            {
                PlanTable.Columns.Add(dm.stationList[i].stationName);
            }
            for(int i = 0; i < dm.TrainList.Count; i++)
            {
                string StaConList = "";
                for (int j = 0; j < dm.TrainList[i].staList.Count; j++)
                {                    
                    if (j == 0)
                    {
                        StaConList = dm.TrainList[i].staList[j];
                    }
                    else
                    {
                        StaConList = StaConList + "," + dm.TrainList[i].staList[j];
                    }                    
                }
                if (!PlanDic.Keys.Contains(StaConList))
                {
                    PlanDic.Add(StaConList, 1);
                }
                else if (PlanDic.Keys.Contains(StaConList))
                {
                    PlanDic[StaConList] += 1;
                }
            }
            Console.WriteLine(PlanDic.Count);
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
            for (int i = 0; i < dm.stationStringList.Count; i++)
            {
                dt.Columns.Add(dm.stationStringList[i]);
            }
            foreach (KeyValuePair<string, int> PlanNumber in PlanDic)
            {
                string[] str = PlanNumber.Key.Split(',');
                DataRow dr = dt.NewRow();
                for(int i = 0; i < dm.stationStringList.Count; i++)
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
        }
        /*public void DrawStation()
        {
            GetPlanTable();
            bmp = new Bitmap(1000, PlanTable.Rows.Count * 15 + 600);
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
