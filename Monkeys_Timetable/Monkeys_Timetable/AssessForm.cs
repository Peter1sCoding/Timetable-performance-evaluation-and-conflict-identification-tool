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
    public partial class AssessForm : Form
    {
        DataManager dm = new DataManager();
        Assessment ass = new Assessment();
        Dictionary<string, int[]> serviceCount = new Dictionary<string, int[]>();
        Dictionary<List<string>, List<int>> TrainDensity = new Dictionary<List<string>, List<int>>();
        List<int> allDen = new List<int>();
        int maxDensity;

        public AssessForm()
        {
            InitializeComponent();
            ShowFirst();
            TrainDensity = ass.GetTrainDensity(dm);
            allDen = ass.AllDensity;
            maxDensity = allDen.Max();
            serviceCount = ass.GetStationServiceCount(dm);

        }
        
        public void ShowFirst()
        {
            dm.ReadHeadway(Application.StartupPath + @"\\车站列车安全间隔.csv");
            dm.ReadStation(Application.StartupPath + @"\\沪宁车站信息.csv");
            dm.ReadTrain(Application.StartupPath + @"\\沪宁时刻图.csv");
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();

            this.Height = 700;
            this.Width = 1300;
            this.splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.SplitterDistance = 499;
            splitContainer1.SplitterWidth = 2;
            splitContainer2.SplitterDistance = 349;
            splitContainer2.SplitterWidth = 2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer2.IsSplitterFixed = true;
            ShowPanel_1();
            ShowPanel_2();
            
        }

        #region Panel_1全局变量
        Label lbTrain = new Label();
        ComboBox cbTrain = new ComboBox();
        Label lbTravalSpeed = new Label();
        TextBox tbTravalSpeed = new TextBox();
        Label lbTechicalSpeed = new Label();
        TextBox tbTechicalSpeed = new TextBox();
        Label lbSpeedIndex = new Label();
        TextBox tbSpeedIndex = new TextBox();
        Label lbTrainServe = new Label();
        TextBox tbTrainServe = new TextBox();
        Button btRunTrain;
        #endregion

        public void ShowPanel_1()
        {
            lbTrain.Text = "选择列车";
            lbTrain.Font = new Font("宋体", 10, FontStyle.Bold);
            lbTrain.Size = new Size(70, 30);
            lbTrain.Location = new Point(90, 55);
            //lbTrain.TextAlign = ContentAlignment.MiddleCenter;
            this.splitContainer2.Panel1.Controls.Add(lbTrain);

            //cbTrain.Items.AddRange(new object[] { 1, 2, 3 });
            foreach (Train tra in dm.TrainList)
            {
                string trainName = tra.trainNo;
                cbTrain.Items.Add(trainName);
            }
            cbTrain.Size = new Size(100, 30);
            cbTrain.Location = new Point(165, 50);
            splitContainer2.Panel1.Controls.Add(cbTrain);

            lbTravalSpeed.Text = "旅行速度";
            lbTravalSpeed.Size = new Size(80, 20);
            lbTravalSpeed.Location = new Point(100, 100);
            splitContainer2.Panel1.Controls.Add(lbTravalSpeed);
            tbTravalSpeed.Size = new Size(80, 50);
            tbTravalSpeed.Location = new Point(100, 100 + 20);
            splitContainer2.Panel1.Controls.Add(tbTravalSpeed);

            lbTechicalSpeed.Text = "技术速度";
            lbTechicalSpeed.Size = new Size(80, 20);
            lbTechicalSpeed.Location = new Point(300, 100);
            splitContainer2.Panel1.Controls.Add(lbTechicalSpeed);
            tbTechicalSpeed.Size = new Size(80, 50);
            tbTechicalSpeed.Location = new Point(300, 100 + 20);
            splitContainer2.Panel1.Controls.Add(tbTechicalSpeed);

            lbSpeedIndex.Text = "速度系数";
            lbSpeedIndex.Size = new Size(80, 20);
            lbSpeedIndex.Location = new Point(100, 200);
            splitContainer2.Panel1.Controls.Add(lbSpeedIndex);
            tbSpeedIndex.Size = new Size(80, 50);
            tbSpeedIndex.Location = new Point(100, 200 + 20);
            splitContainer2.Panel1.Controls.Add(tbSpeedIndex);

            lbTrainServe.Text = "列车服务频率";
            lbTrainServe.Size = new Size(80, 20);
            lbTrainServe.Location = new Point(300, 200);
            splitContainer2.Panel1.Controls.Add(lbTrainServe);
            tbTrainServe.Size = new Size(80, 50);
            tbTrainServe.Location = new Point(300, 200 + 20);
            splitContainer2.Panel1.Controls.Add(tbTrainServe);

            btRunTrain = new Button();
            btRunTrain.Text = "查询列车信息";
            btRunTrain.Font = new Font("宋体", 10, FontStyle.Bold);
            btRunTrain.Size = new Size(120, 30);
            btRunTrain.Location = new Point(280, 40);
            this.splitContainer2.Panel1.Controls.Add(btRunTrain);
            btRunTrain.Click += BtRunTrain_Click;
        }

        private void BtRunTrain_Click(object sender, EventArgs e)
        {
            if (cbTrain.SelectedItem == null)
            {
                MessageBox.Show("请先选择列车！");
            }
            else
            {
                String strtrain = cbTrain.SelectedItem.ToString();
                for (int i = 0; i < dm.TrainList.Count-1; i++)
                {
                    if(strtrain == dm.TrainList[i].trainNo)
                    {
                        tbTravalSpeed.Text = ass.GetTravelSpeed(dm)[i].ToString()+"km/h";
                        tbTechicalSpeed.Text = ass.GetTechnicalSpeed(dm)[i].ToString()+"km/h";
                        tbSpeedIndex.Text = ass.GetSpeedIndex(dm)[i].ToString();
                        tbTrainServe.Text = ass.GetServiceFrequency(dm)[i].ToString();
                    }
                }
            }
        }

        #region Panel_2 全局变量
        Label lbStation;
        ComboBox cbStation;
        Label lbTime1;
        TextBox tbTime1;
        Label lbTime2;
        TextBox tbTime2;
        Label lbTime3;
        TextBox tbTime3;
        Label lbTime4;
        TextBox tbTime4;
        Label lbTime5;
        TextBox tbTime5;
        Label lbTime6;
        TextBox tbTime6;
        Button btRunStation;
        #endregion

        public void ShowPanel_2()
        {
            lbStation = new Label();
            lbStation.Name = "lbStation";
            lbStation.Text = "选择车站";
            lbStation.Font = new Font("宋体", 10, FontStyle.Bold);
            lbStation.Size = new Size(70, 30);
            lbStation.Location = new Point(90, 35);
            this.splitContainer2.Panel2.Controls.Add(lbStation);


            cbStation = new ComboBox();
            cbStation.Name = "cbStation";
            //cbStation.Items.AddRange(new object[] { 1, 2, 3 });
            
            foreach(string strr in dm.stationStringList)
            {
                string strr2 = strr;
                cbStation.Items.Add(strr2);
            }
            cbStation.Size = new Size(100, 30);
            cbStation.Location = new Point(165, 30);
            splitContainer2.Panel2.Controls.Add(cbStation);


            lbTime1 = new Label();
            lbTime1.Text = "6:00-9:00";
            lbTime1.Size = new Size(80, 20);
            lbTime1.Location = new Point(60, 80);
            splitContainer2.Panel2.Controls.Add(lbTime1);
            tbTime1 = new TextBox();
            tbTime1.Name = "tbTime1";
            tbTime1.Size = new Size(80, 50);
            tbTime1.Location = new Point(60, 100);
            splitContainer2.Panel2.Controls.Add(tbTime1);

            lbTime2 = new Label();
            lbTime2.Text = "9:00-12:00";
            lbTime2.Size = new Size(80, 20);
            lbTime2.Location = new Point(50 + 150 + 10, 80);
            splitContainer2.Panel2.Controls.Add(lbTime2);
            tbTime2 = new TextBox();
            tbTime2.Name = "tbTime2";
            tbTime2.Size = new Size(80, 50);
            tbTime2.Location = new Point(50 + 150 + 10, 100);
            splitContainer2.Panel2.Controls.Add(tbTime2);

            lbTime3 = new Label();
            lbTime3.Text = "12:00-15:00";
            lbTime3.Size = new Size(80, 20);
            lbTime3.Location = new Point(50 + 150 * 2 + 10 , 80);
            splitContainer2.Panel2.Controls.Add(lbTime3);
            tbTime3 = new TextBox();
            tbTime3.Name = "tbTime3";
            tbTime3.Size = new Size(80, 50);
            tbTime3.Location = new Point(50 + 150 * 2 + 10, 100);
            splitContainer2.Panel2.Controls.Add(tbTime3);

            lbTime4 = new Label();
            lbTime4.Text = "15:00-18:00";
            lbTime4.Size = new Size(80, 20);
            lbTime4.Location = new Point(60, 165);
            splitContainer2.Panel2.Controls.Add(lbTime4);
            tbTime4 = new TextBox();
            tbTime4.Name = "tbTime4";
            tbTime4.Size = new Size(80, 50);
            tbTime4.Location = new Point(60, 190);
            splitContainer2.Panel2.Controls.Add(tbTime4);

            lbTime5 = new Label();
            lbTime5.Text = "18:00-21:00";
            lbTime5.Size = new Size(80, 20);
            lbTime5.Location = new Point(50 + 150 + 10, 165);
            splitContainer2.Panel2.Controls.Add(lbTime5);
            tbTime5 = new TextBox();
            tbTime5.Name = "tbTime5";
            tbTime5.Size = new Size(80, 50);
            tbTime5.Location = new Point(50 + 150 + 10, 190);
            splitContainer2.Panel2.Controls.Add(tbTime5);

            lbTime6 = new Label();
            lbTime6.Text = "21:00-24:00";
            lbTime6.Size = new Size(80, 20);
            lbTime6.Location = new Point(50 + 150 * 2 + 10, 165);
            splitContainer2.Panel2.Controls.Add(lbTime6);
            tbTime6 = new TextBox();
            tbTime6.Name = "tbTime6";
            tbTime6.Size = new Size(80, 50);
            tbTime6.Location = new Point(50 + 150 * 2 + 10 , 190);
            splitContainer2.Panel2.Controls.Add(tbTime6);

            btRunStation = new Button();
            btRunStation.Text = "查询车站服务次数";
            btRunStation.Font = new Font("宋体", 10, FontStyle.Bold);
            btRunStation.Size = new Size(150, 30);
            btRunStation.Location = new Point(280, 20);
            this.splitContainer2.Panel2.Controls.Add(btRunStation);
            btRunStation.Click += BtRunStation_Click;
        }

        private void BtRunStation_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cbStation.SelectedItem == null)
            {
                MessageBox.Show("请先选择车站！");
            }
            else
            {
                String str = cbStation.SelectedItem.ToString();
                int[] tbnums = serviceCount[str];//选中车站的6个时间段的服务次数
                for (int i = 1; i < 7; i++)
                {
                    string str1 = "tbTime" + i.ToString();
                    foreach (Control control in this.splitContainer2.Panel2.Controls)
                    {
                        if (control is TextBox && control.Name == str1)
                        {
                            string tbnum = tbnums[i-1].ToString();
                            (control as TextBox).Text = tbnum;
                            break;
                        }
                    }
                }
            }
        }

        public void drawDensity()
        {
            Graphics g = splitContainer1.Panel2.CreateGraphics();
            try
            {
                // title
                Font font = new Font("Arial", 10, FontStyle.Regular);
                Font font1 = new Font("宋体", 14, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Blue);
               
                g.DrawString("区间列车密度统计", font1, brush, new PointF(320, 30));
                // Up Down
                Font font2 = new Font("宋体", 10, FontStyle.Bold);
                SolidBrush brush2 = new SolidBrush(Color.Black);
                g.DrawString("上行", font2, brush2, new PointF(350, 55));
                g.DrawString("下行", font2, brush2, new PointF(420, 55));
                // 画个水平线找位置 圈出区域为绘图的地方
                g.DrawLine(new Pen(brush2), new Point(0, 70), new Point(750, 70));
                g.DrawLine(new Pen(brush2), new Point(0, 620), new Point(750, 620));
                g.DrawLine(new Pen(brush2), new Point(400, 70), new Point(400, 620));
                g.DrawLine(new Pen(brush2), new Point(120, 70), new Point(120, 620));// 最长的bar
                g.DrawLine(new Pen(brush2), new Point(400 + 280, 70), new Point(400 + 280, 620));// 最长的bar

                float aa =(float)0;//绘图的比例系数 
                if(maxDensity!=0)
                    aa = 280 / maxDensity;
                Font font3 = new Font("宋体", 10);
                int i = 0;
                foreach (List<string> sec in TrainDensity.Keys)
                {
                    List<int> den = TrainDensity[sec];
                    int d_up = den[0];
                    int d_down = den[1];

                    if (sec[0] == "上海" && sec[1] == "上海虹桥")
                    {
                        continue;
                    }
                    else
                    {
                        g.DrawString(sec[0].ToString() + "-" + sec[1].ToString(), font3, brush2, new PointF(0, 75 + 25 * i + 5));

                        #region 上行 橘色
                        float barLength1 = Convert.ToSingle(d_up * aa);// 每个bar的长度等于对应区间密度d * aa
                        SolidBrush brush3 = new SolidBrush(Color.Orange);

                        g.FillRectangle(brush3, 400 - barLength1-5, 75 + 25 * i, barLength1, 20);
                        g.DrawString(d_up.ToString(), font3, brush2, new PointF(400 - barLength1 - 30, 75 + 25 * i + 5));
                        #endregion

                        #region 下行 浅绿色
                        float barLength2 = Convert.ToSingle(d_down * aa);
                        SolidBrush brush4 = new SolidBrush(Color.LightGreen);

                        g.FillRectangle(brush4, 400+5, 25 * i + 75, barLength2, 20);
                        g.DrawString(d_down.ToString(), font3, brush2, new PointF(400 + barLength2+5, 25 * i + 75+5));
                        #endregion
                    }
                    i++;
                }
            }
            finally
            {
                g.Dispose();
            }
        }

        private void 绘制区间列车密度图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawDensity();
        }

        private void 查询列车停站信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTrain.SelectedItem == null)
            {
                MessageBox.Show("请先选择列车！");
            }
            else
            {
                for (int i = 0; i < dm.TrainList.Count; i++)
                {
                    string strsta = "";
                    string arrivetime = "";
                    string depturetime = "";
                    string title = "车站名" + "\t" + "到达时刻" + "\t" + "出发时刻" + "\n";
                    if (dm.TrainList[i].trainNo == cbTrain.SelectedItem.ToString())
                    {
                        for (int j = 0; j < dm.TrainList[i].staList.Count; j++)
                        {
                            arrivetime = dm.TrainList[i].staTimeDic[dm.TrainList[i].staList[j]][0];
                            depturetime = dm.TrainList[i].staTimeDic[dm.TrainList[i].staList[j]][1];
                            strsta = strsta + dm.TrainList[i].staList[j] + "\t" + arrivetime + "\t" + depturetime + "\n";
                        }
                        MessageBox.Show(title+strsta);
                        break;
                    }
                }
            }
            //之后添加控件选择列车 改成表格 加上时间 显示时关闭密度表
        }
    }
    
}
