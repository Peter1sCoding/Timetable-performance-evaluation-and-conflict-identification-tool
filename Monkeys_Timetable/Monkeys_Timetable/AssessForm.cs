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
        DataManager aDataManager = new DataManager();
        Assessment ass = new Assessment();
        Dictionary<string, int[]> serviceCount = new Dictionary<string, int[]>();
        
        public AssessForm()
        {
            InitializeComponent();
            ShowFirst();
        }
        
        public void ShowFirst()
        {
            this.Height = 700;
            this.Width = 1200;
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
        #endregion

        public void ShowPanel_1()
        {
            lbTrain.Text = "选择列车";
            lbTrain.Font = new Font("宋体", 10, FontStyle.Bold);
            lbTrain.Size = new Size(80, 30);
            lbTrain.Location = new Point(130, 55);
            //lbTrain.TextAlign = ContentAlignment.MiddleCenter;
            this.splitContainer2.Panel1.Controls.Add(lbTrain);

            cbTrain.Items.AddRange(new object[] { 1, 2, 3 });
            //foreach (Train tra in aDataManager.TrainList)
            //{
            //    string trainName = tra.trainNo;
            //    cbStation.Items.Add(trainName);
            //}
            cbTrain.Size = new Size(100, 30);
            cbTrain.Location = new Point(210, 50);
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
        Button btRun;
        #endregion

        public void ShowPanel_2()
        {
            lbStation = new Label();
            lbStation.Name = "lbStation";
            lbStation.Text = "选择车站";
            lbStation.Font = new Font("宋体", 10, FontStyle.Bold);
            lbStation.Size = new Size(80, 30);
            lbStation.Location = new Point(130, 55);
            this.splitContainer2.Panel2.Controls.Add(lbStation);


            cbStation = new ComboBox();
            cbStation.Name = "cbStation";
            //cbStation.Items.AddRange(new object[] { 1, 2, 3 });
            foreach (Train tra in aDataManager.TrainList)
            {
                string trainName = tra.trainNo;
                cbStation.Items.Add(trainName);
            }
            cbStation.Size = new Size(100, 30);
            cbStation.Location = new Point(210, 50);
            splitContainer2.Panel2.Controls.Add(cbStation);


            lbTime1 = new Label();
            lbTime1.Text = "6:00-9:00";
            lbTime1.Size = new Size(80, 20);
            lbTime1.Location = new Point(50, 100);
            splitContainer2.Panel2.Controls.Add(lbTime1);
            tbTime1 = new TextBox();
            tbTime1.Name = "tbTime1";
            tbTime1.Size = new Size(80, 50);
            tbTime1.Location = new Point(50, 100 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime1);

            lbTime2 = new Label();
            lbTime2.Text = "9:00-12:00";
            lbTime2.Size = new Size(80, 20);
            lbTime2.Location = new Point(50 + 150 + 10, 100);
            splitContainer2.Panel2.Controls.Add(lbTime2);
            tbTime2 = new TextBox();
            tbTime2.Name = "tbTime2";
            tbTime2.Size = new Size(80, 50);
            tbTime2.Location = new Point(50 + 150 + 10, 100 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime2);

            lbTime3 = new Label();
            lbTime3.Text = "12:00-15:00";
            lbTime3.Size = new Size(80, 20);
            lbTime3.Location = new Point(50 + 150 * 2 + 10 * 2, 100);
            splitContainer2.Panel2.Controls.Add(lbTime3);
            tbTime3 = new TextBox();
            tbTime3.Name = "tbTime3";
            tbTime3.Size = new Size(80, 50);
            tbTime3.Location = new Point(50 + 150 * 2 + 10 * 2, 100 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime3);

            lbTime4 = new Label();
            lbTime4.Text = "15:00-18:00";
            lbTime4.Size = new Size(80, 20);
            lbTime4.Location = new Point(50, 100 + 30 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(lbTime4);
            tbTime4 = new TextBox();
            tbTime4.Name = "tbTime4";
            tbTime4.Size = new Size(80, 50);
            tbTime4.Location = new Point(50, 100 + 30 * 2 + 50);
            splitContainer2.Panel2.Controls.Add(tbTime4);

            lbTime5 = new Label();
            lbTime5.Text = "18:00-21:00";
            lbTime5.Size = new Size(80, 20);
            lbTime5.Location = new Point(50 + 150 + 10, 100 + 30 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(lbTime5);
            tbTime5 = new TextBox();
            tbTime5.Name = "tbTime5";
            tbTime5.Size = new Size(80, 50);
            tbTime5.Location = new Point(50 + 150 + 10, 100 + 30 * 2 + 50);
            splitContainer2.Panel2.Controls.Add(tbTime5);

            lbTime6 = new Label();
            lbTime6.Text = "21:00-24:00";
            lbTime6.Size = new Size(80, 20);
            lbTime6.Location = new Point(50 + 150 * 2 + 10 * 2, 100 + 30 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(lbTime6);
            tbTime6 = new TextBox();
            tbTime6.Name = "tbTime6";
            tbTime6.Size = new Size(80, 50);
            tbTime6.Location = new Point(50 + 150 * 2 + 10 * 2, 100 + 30 * 2 + 50);
            splitContainer2.Panel2.Controls.Add(tbTime6);

            btRun = new Button();
            btRun.Text = "查询车站服务次数";
            btRun.Font = new Font("宋体", 10, FontStyle.Bold);
            btRun.Size = new Size(150, 40);
            btRun.Location = new Point(180, 100 + 30 * 2 + 50 * 2);
            this.splitContainer2.Panel2.Controls.Add(btRun);
            btRun.Click += BtRun_Click;
        }

        private void BtRun_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cbStation.SelectedItem == null)
            {
                MessageBox.Show("请先选择车站！");
            }
            else
            {
                String str = cbStation.SelectedItem.ToString();
                for (int i = 1; i < 7; i++)
                {
                    string str1 = "lbTime" + i.ToString();
                    string str2 = "tbTime" + i.ToString();
                    foreach (Control control in this.splitContainer2.Panel2.Controls)
                    {
                        if (control is TextBox && control.Name == str2)
                        {
                            (control as TextBox).Text = str + "+" + i.ToString();
                            break;
                        }
                    }
                }
            }
        }

    }
    
}
