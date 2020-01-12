using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Monkeys_Timetable
{
    public partial class PaintForm : Form //实现绘制运行图的界面
    {
        /// <summary>
        /// 时刻表文件名
        /// </summary>
        string traFileName;
        /// <summary>
        /// 车站文件名
        /// </summary>
        string staFileName;
        /// <summary>
        /// 安全间隔文件名
        /// </summary>
        string headFileName;
        /// <summary>
        ///运行图总宽度
        /// </summary>
        static int TD_Width = 3000;
        /// <summary>
        ///运行图总高度
        /// </summary>
        static int TD_Height = 2000;
        /// <summary>
        ///DataManager对象，用于读取文件
        /// </summary>
        DataManager dm;
        /// <summary>
        ///Conflict_Identification对象，用于检测冲突
        /// </summary>
        Conflict_Identification ci;
        /// <summary>
        ///存放冲突信息
        /// </summary>
        DataTable dt;
        /// <summary>
        ///PaintTool对象，用于绘图
        /// </summary>
        PaintTool pt = new PaintTool();
        LinePlan lp;
        /// <summary>
        ///存放冲突信息
        /// </summary>
        DataTable ConflictTable;
        /// <summary>
        ///bmp，运行图绘制的底图
        /// </summary>
        public Bitmap bmp = new Bitmap(TD_Width, TD_Height);
        /// <summary>
        ///判断是否绘制冲突点
        /// </summary>
        static bool YesOrNo = false;
        /// <summary>
        ///构造方法，初始化各对象
        /// </summary>
        public PaintForm()
        {    
            pictureBox2 = new PictureBox();
            pictureBox2.Size = new Size(TD_Width, TD_Height);
            InitializeComponent();
            this.Size = new Size(TD_Width, TD_Height);
            dm = new DataManager();
            dm.ReadHeadway(Application.StartupPath + @"\\车站列车安全间隔.csv");
            dm.ReadStation(Application.StartupPath + @"\\沪宁车站信息.csv");
            dm.ReadTrain(Application.StartupPath + @"\\沪宁时刻图.csv");
            dm.ReadDrawStation(Application.StartupPath + @"\\沪宁车站画图信息.csv");
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();
            ci = new Conflict_Identification(dm.stationList, dm.HeadwayDic, dm.TrainDic);
            ci.Conflict_Judge();
            ConflictTable = ci.ToDataTable();
        }
        private void PaintForm_Load(object sender, EventArgs e)
        {
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        private void 读取文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
        }
        /// <summary>
        ///读取车站信息
        /// </summary>
        private void 读取车站信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                staFileName = dialog.FileName;
                dm.ReadStation(staFileName);
            }
            if(dialog.FileName == null)
            {
                MessageBox.Show("未找到相关文件");
            }
        }
        /// <summary>
        ///读取时刻表信息
        /// </summary>
        private void 读取时刻表信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                traFileName = dialog.FileName;
                dm.ReadTrain(traFileName);
                dm.DivideUpDown();
                dm.AddTra2sta();
                dm.GetStop();
            }
            if (dialog.FileName == null)
            {
                MessageBox.Show("未找到相关文件");
            }            
        }
        /// <summary>
        ///读取列车间隔信息
        /// </summary>
        private void 读取列车间隔信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                headFileName = dialog.FileName;
                dm.ReadHeadway(headFileName);
            }
            if (dialog.FileName == null)
            {
                MessageBox.Show("未找到相关文件");
            }
        }
        private void 图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void 绘制运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void 绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }       
        private void 冲突检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 冲突检测数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConflictForm cf = new ConflictForm(dt);
            cf.Show();
        }
        /// <summary>
        ///绘制时刻与站名线底图
        /// </summary>
        public void DrawFrame()
        {
            pictureBox2.Size = new Size(TD_Width, TD_Height);
            Graphics gs;
            gs = Graphics.FromImage(bmp);
            gs.Clear(this.pictureBox2.BackColor);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            pictureBox2.BackgroundImage = null;
            int ix = dm.stationDrawList.Count;
            List<double> staMile = new List<double>();
            for (int i = 0; i < ix; i++)
            {
                staMile.Add(dm.stationDrawList[i].totalMile);
            }
            pt.Branch(dm.stationDrawStringList, staMile, this.bmp.Width, this.bmp.Height);
            int k = pt.border2.Count;
            for (int i = 0; i < k; i++)
            {
                int ii = i + 1;
                double total1 = pt.Mile1[ii].Last();
                pt.TimetableFrame(this.bmp.Width, pt.border2[i].up,pt.border2[i].down, total1,pt.Mile1[ii], gs, pt.str1[ii],ii);
            }

            this.pictureBox2.BackgroundImage = bmp;
        }
        /// <summary>
        ///绘制运行线与冲突
        /// </summary>
        public void DrawPicture()
        {
            pictureBox2.Size = new Size(TD_Width, TD_Height);
            Graphics gs;
            gs = Graphics.FromImage(bmp);
            int ix = dm.stationDrawList.Count();
            List<double> staMile = new List<double>();
            for (int i = 0; i < ix; i++)
            {
                staMile.Add(dm.stationDrawList[i].totalMile);
            }
            pt.Branch(dm.stationDrawStringList, staMile, this.bmp.Width, this.bmp.Height);
            int k = pt.border2.Count;
            pictureBox2.BackgroundImage = null;
            gs.Clear(this.pictureBox2.BackColor);
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.TimetableFrame(this.bmp.Width, pt.border2[i].up,pt.border2[i].down, total1,pt.Mile1[ii], gs, pt.str1[ii],ii);
                    pt.TrainLine(gs, dm.upTrainList, pt.str1[ii],ii);
                    pt.TrainLine(gs, dm.downTrainList, pt.str1[ii],ii);
                }                
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.TimetableFrame(this.bmp.Width, pt.border2[i].up,pt.border2[i].down, total1,pt.Mile1[ii], gs, pt.str1[ii],ii);
                    pt.TrainLine(gs, dm.upTrainList, pt.str1[ii], ii);
                }                
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.TimetableFrame(this.bmp.Width, pt.border2[i].up, pt.border2[i].down, total1, pt.Mile1[ii], gs, pt.str1[ii], ii);
                    pt.TrainLine(gs, dm.downTrainList, pt.str1[ii], ii);
                }          
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.TimetableFrame(this.bmp.Width, pt.border2[i].up,pt.border2[i].down, total1,pt.Mile1[ii], gs, pt.str1[ii],ii);
                }
            }
            for (int i = 0; i < k; i++)
            {
                pt.GetTrainPoint(dm.TrainList, pt.str1[i + 1], i);
            }
            pt.GetConflictPoint(ci.ConflictList, dm.TrainList);
            this.pictureBox2.BackgroundImage = bmp;
        }
        private void 绘制运行图ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DrawFrame();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DrawPicture();
            if (YesOrNo)
            {
                ConflictShow();
            }
        }//上行运行图的绘制

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DrawPicture();
            if (YesOrNo)
            {
                ConflictShow();
            }
        }//下行运行图的绘制
        private void 开行方案数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinePlan lp = new LinePlan(pt.str1);
            lp.Show();
        }
        private void 检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conflict_Identification ci = new Conflict_Identification(dm.stationList,dm.HeadwayDic,dm.TrainDic);
            ci.Conflict_Judge();
            ConflictTable = ci.ToDataTable();
        }
        private void 显示冲突列车数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConflictForm cf = new ConflictForm(ConflictTable);
            cf.Show();
        }
        private void 显示开行方案数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lp.Show();
            lp.DrawUpPlan();
        }
        private void 运行图标记冲突ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (YesOrNo == false)
            {
                YesOrNo = true;
            }
            else
            {
                YesOrNo = false;
            }
            ConflictShow();     
        }
        /// <summary>
        ///绘制冲突点
        /// </summary>
        public void ConflictShow()
        {
            pictureBox2.Size = new Size(TD_Width, TD_Height);
            Graphics gs = Graphics.FromImage(bmp);
            if (checkBox1.Checked)
            {
                Refresh();
                int k = pt.border2.Count;
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.ConflictDrawUp(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                }
            }
            if (checkBox2.Checked)
            {
                Refresh();
                int k = pt.border2.Count;
                for (int i = 0; i < k; i++)
                {
                    int ii = i + 1;
                    double total1 = pt.Mile1[ii].Last();
                    pt.ConflictDrawDown(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                }
            }
            this.pictureBox2.BackgroundImage = bmp;
        }
        private void 计算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AssessForm af = new AssessForm();
            af.Show();
        }
        private void PaintForm_Scroll(object sender, ScrollEventArgs e)
        {         
        }
        private void 绘制运行图上行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Checked = true;
        }
        private void 绘制运行图下行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
        }
        private void 绘制运行图上下行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox1.Checked = true;
        }
        /// <summary>
        ///判断鼠标点位，生成选中列车和冲突点信息
        /// </summary>
        private void TimetableViewCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Size = new Size(TD_Width, TD_Height);
            float precision = 5f;
            int n = -1;
            int c = -1;
            if (checkBox1.Checked)
            {
                foreach (Train train in dm.upTrainList)
                {
                    Graphics gs;
                    gs = Graphics.FromImage(bmp);
                    if (checkBox1.Checked)
                    {
                        for (int i = 0; i < ci.ConflictList.Count; i++)
                        {
                            if(ci.ConflictList[i].FrontTrain.Dir == "up")
                            {
                                c = PaintTool.PointInCircle(e.Location, ci.ConflictList[i].ConflictLocation, 5f);
                                if (c == 0)
                                {
                                    dataGridView1.Visible = false;
                                    this.pictureBox2.Refresh();
                                    DrawPicture();
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawUp(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }                                       
                                    }
                                    ShowInfoTooltip(ci.ConflictList[i], e.Location);
                                    Pen SelectedPen = new Pen(Color.Blue, 2);
                                    if(YesOrNo)
                                    {
                                        gs.DrawEllipse(SelectedPen, ci.ConflictList[i].ConflictLocation.X - 2, ci.ConflictList[i].ConflictLocation.Y - 2, 5, 5);
                                    }                                    
                                    break;
                                }
                            }                            
                        }
                    }
                    if (c != 0)
                    {
                        dataGridView2.Visible = false;
                        for (int i = 0; i < train.TrainPointList.Count; i++)
                        {
                            for (int s = 0; s < pt.str1.Count; s++)
                            {
                                for(int m = 0; m < train.staList.Count - 1; m++)
                                {
                                    if ((train.TrainPointList[s].ContainsKey(train.staList[m])) && (train.TrainPointList[s].ContainsKey(train.staList[m + 1])))
                                    {
                                        n = PaintTool.PointInLine(e.Location, train.TrainPointList[s][train.staList[m]][1], train.TrainPointList[s][train.staList[m + 1]][0], precision);
                                        if (n == 0)
                                        {
                                            break;
                                        }
                                    }
                                }                                                   
                                if (n == 0)
                                {
                                    break;
                                }
                            }
                            if (n == 0)
                            {
                                this.pictureBox2.Refresh();
                                DrawPicture();
                                if (checkBox1.Checked)
                                {
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawUp(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }
                                        
                                    }
                                }
                                if (checkBox2.Checked)
                                {
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawDown(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }                                        
                                    }
                                }
                                ShowInfoTooltip(train, e.Location);
                                Pen SelectedPen = new Pen(Color.Blue, 2);
                                for (int j = 1; j < pt.str1.Count + 1; j++)
                                {
                                    for (int p = 0; p < pt.str1[j].Count - 1; p++)
                                    {
                                        if (train.TrainPointList[j - 1].Count <= 1)
                                        {
                                            break;
                                        }
                                        if((train.staList.Contains(pt.str1[j][p]))&& (train.staList.Contains(pt.str1[j][p + 1])))
                                        {
                                            gs.DrawLine(SelectedPen, train.TrainPointList[j - 1][pt.str1[j][p]][0], train.TrainPointList[j - 1][pt.str1[j][p + 1]][1]);                                         
                                        }
                                    }
                                    for (int p = 1; p < pt.str1[j].Count - 1; p++)
                                    {
                                        if (train.TrainPointList[j - 1].Count <= 1)
                                        {
                                            break;
                                        }
                                        if (train.staList.Contains(pt.str1[j][p]))
                                        {
                                            gs.DrawLine(SelectedPen, train.TrainPointList[j - 1][pt.str1[j][p]][1], train.TrainPointList[j - 1][pt.str1[j][p]][0]);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if ((c == 0) || (n == 0))
                    {
                        break;
                    }
                }
                Refresh();
            }
            if (checkBox2.Checked)
            {
                foreach (Train train in dm.downTrainList)
                {
                    Graphics gs;
                    gs = Graphics.FromImage(bmp);
                    if (checkBox2.Checked)
                    {
                        for (int i = 0; i < ci.ConflictList.Count; i++)
                        {
                            if (ci.ConflictList[i].FrontTrain.Dir == "down")
                            {
                                c = PaintTool.PointInCircle(e.Location, ci.ConflictList[i].ConflictLocation, 5f);
                                if (c == 0)
                                {
                                    dataGridView1.Visible = false;
                                    this.pictureBox2.Refresh();
                                    DrawPicture();
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawDown(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }
                                    }
                                        
                                    ShowInfoTooltip(ci.ConflictList[i],e.Location);
                                    Pen SelectedPen = new Pen(Color.Blue, 2);
                                    if (YesOrNo)
                                    {
                                        gs.DrawEllipse(SelectedPen, ci.ConflictList[i].ConflictLocation.X - 2, ci.ConflictList[i].ConflictLocation.Y - 2, 5, 5);
                                    }                                    
                                    break;
                                }
                            }                           
                        }
                    }
                    if (c != 0)
                    {
                        dataGridView2.Visible = false;
                        for (int i = 0; i < train.TrainPointList.Count - 1; i++)
                        {
                            for (int s = 0; s < pt.str1.Count; s++)
                            {
                                for (int m = 0; m < train.staList.Count - 1; m++)
                                {
                                    if ((train.TrainPointList[s].ContainsKey(train.staList[m])) && (train.TrainPointList[s].ContainsKey(train.staList[m + 1])))
                                    {
                                        n = PaintTool.PointInLine(e.Location, train.TrainPointList[s][train.staList[m]][1], train.TrainPointList[s][train.staList[m + 1]][0], precision);
                                        if (n == 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (n == 0)
                                {
                                    break;
                                }
                            }
                            if (n == 0)
                            {
                                this.pictureBox2.Refresh();
                                DrawPicture();
                                if (checkBox1.Checked)
                                {
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawUp(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }                                        
                                    }
                                }
                                if (checkBox2.Checked)
                                {
                                    int k = pt.border2.Count;
                                    for (int i1 = 0; i1 < k; i1++)
                                    {
                                        int ii = i1 + 1;
                                        double total1 = pt.Mile1[ii].Last();
                                        if (YesOrNo)
                                        {
                                            pt.ConflictDrawDown(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
                                        }                                        
                                    }
                                }
                                ShowInfoTooltip(train, e.Location);
                                Pen SelectedPen = new Pen(Color.Blue, 2);
                                for (int j = 1; j < pt.str1.Count + 1; j++)
                                {
                                    for (int p = 0; p < pt.str1[j].Count - 1; p++)
                                    {
                                        if (train.TrainPointList[j - 1].Count <= 0)
                                        {
                                            break;
                                        }
                                        if (train.staList.Contains(pt.str1[j][p]) && train.staList.Contains(pt.str1[j][p + 1]))
                                        {
                                            gs.DrawLine(SelectedPen, train.TrainPointList[j - 1][pt.str1[j][p]][1], train.TrainPointList[j - 1][pt.str1[j][p + 1]][0]);
                                        }
                                        
                                    }
                                    for (int p = 1; p < pt.str1[j].Count - 1; p++)
                                    {
                                        if (train.TrainPointList[j - 1].Count <= 1)
                                        {
                                            break;
                                        }
                                        if (train.staList.Contains(pt.str1[j][p]))
                                        {
                                            gs.DrawLine(SelectedPen, train.TrainPointList[j - 1][pt.str1[j][p]][1], train.TrainPointList[j - 1][pt.str1[j][p]][0]);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if ((c == 0) || (n == 0))
                    {
                        break;
                    }
                }
                Refresh();
            }
        }
        /// <summary>
        ///显示选中列车信息
        /// </summary>
        private void ShowInfoTooltip(Train train, Point location)
        {
            location.X += 15;
            location.Y += 15;
            DataTable dt = new DataTable();
            dt.TableName = train.TrainNo;
            dt.Columns.Add(train.TrainNo);
            dt.Columns.Add("车站");
            dt.Columns.Add("到达时刻");
            dt.Columns.Add("出发时刻");           
            for (int i = 0; i < train.staList.Count; i++)
            {
                dt.Rows.Add("",train.staList[i], train.staTimeDic[train.staList[i]][0], train.staTimeDic[train.staList[i]][1]);
            }
            location.X += this.AutoScrollPosition.X;
            location.Y += this.AutoScrollPosition.Y;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            if (checkBox3.Checked)
            {
                dataGridView1.Visible = true;
            }
            dataGridView1.Location = location;
        }
        /// <summary>
        ///显示选中冲突信息
        /// </summary>
        private void ShowInfoTooltip(Conflict con,Point location)
        {
            location.X += 15;
            location.Y += 15;
            DataTable dt = new DataTable();
            dt.Columns.Add("冲突类型");
            dt.Columns.Add("前车");
            dt.Columns.Add("前车时刻");
            dt.Columns.Add("后车");
            dt.Columns.Add("后车时刻");
            dt.Columns.Add("车站");
            dt.Rows.Add(con.ConflictType, con.FrontTrain.TrainNo, con.FrontTime, con.LatterTrain.TrainNo, con.LatterTime, con.ConflictSta);

            location.X += this.AutoScrollPosition.X;
            location.Y += this.AutoScrollPosition.Y;
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (checkBox3.Checked)
            {
                dataGridView2.Visible = true;
                dataGridView2.Location = location;
            }
        }
        private void 读取车站画图信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                staFileName = dialog.FileName;
            }
            dm.ReadDrawStation(staFileName);           
        }
        private void 框架图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox2.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox2.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            DrawPicture();
        }
        private void 上行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = false;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox2.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox2.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private void 下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            checkBox1.Checked = false;
                            checkBox2.Checked = true;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox2.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox2.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private void 上下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;


                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            checkBox1.Checked = true;
                            checkBox2.Checked = true;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox2.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox2.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        /// <summary>
        /////放大运行图
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (TD_Width < 6000 && TD_Height < 4000)
            {
                TD_Width += 30;
                TD_Height += 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX = new List<float>();
            pt.staY2 = new Dictionary<int, List<float>>();
            for (int ind = 0; ind < dm.upTrainList.Count; ind++)
            {
                dm.upTrainList[ind].TrainPointList = new List<Dictionary<string, List<PointF>>>();
            }
            for (int ind = 0; ind < dm.downTrainList.Count; ind++)
            {
                dm.downTrainList[ind].TrainPointList = new List<Dictionary<string, List<PointF>>>();
            }
            DrawPicture();
        }
        /// <summary>
        /////缩小运行图
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (TD_Width > 900 && TD_Height > 600)
            {
                TD_Width -= 30;
                TD_Height -= 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX = new List<float>();
            pt.staY2 = new Dictionary<int, List<float>>();
            for (int ind = 0; ind < dm.upTrainList.Count; ind++)
            {
                dm.upTrainList[ind].TrainPointList = new List<Dictionary<string, List<PointF>>>();
            }
            for (int ind = 0; ind < dm.downTrainList.Count; ind++)
            {
                dm.downTrainList[ind].TrainPointList = new List<Dictionary<string, List<PointF>>>();
            }
            DrawPicture();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 下行开行方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lp.Show();
            lp.DrawDownPlan();
        }

        private void 开行方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lp = new LinePlan(pt.str1);
        }
    }
}
