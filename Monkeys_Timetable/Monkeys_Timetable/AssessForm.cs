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
        public AssessForm()
        {
            InitializeComponent();
            ShowFirst();
            
        }
        
        public void ShowFirst()
        {
            this.Height = 800;
            this.Width = 1200;
            this.splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer2.IsSplitterFixed = true;
            this.splitContainer1.Panel1.Width = 500;
            splitContainer2.Panel1.Height = splitContainer2.Height / 2;
            ShowPanel2();
        }

        public void ShowPanel2()
        {
            Label lbStation = new Label();
            lbStation.Text = "选择车站";
            lbStation.Size = new Size(100, 50);
            lbStation.Location = new Point(100, 450);
            this.splitContainer2.Panel2.Controls.Add(lbStation);

            ComboBox cbStation = new ComboBox();
            foreach (Train tra in aDataManager.TrainList)
            {
                string trainName = tra.trainNo;
                cbStation.Items.Add(trainName);
            }
            cbStation.Size = new Size(150, 50);
            cbStation.Location = new Point(250, 450);
            splitContainer2.Panel2.Controls.Add(cbStation);

            Label lbTime1 = new Label();
            lbTime1.Text = "6:00-9:00";
            lbTime1.Size = new Size(150, 50);
            lbTime1.Location = new Point(10, 400 + 120);
            splitContainer2.Panel2.Controls.Add(lbTime1);
            TextBox tbTime1 = new TextBox();
            tbTime1.Size = new Size(150, 50);
            tbTime1.Location = new Point(10, 400 + 120 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(tbTime1);

            Label lbTime2 = new Label();
            lbTime2.Text = "9:00-12:00";
            lbTime2.Size = new Size(150, 50);
            lbTime2.Location = new Point(10 + 150 + 10, 400 + 120);
            splitContainer2.Panel2.Controls.Add(lbTime2);
            TextBox tbTime2 = new TextBox();
            tbTime2.Size = new Size(150, 50);
            tbTime2.Location = new Point(10 + 150 + 10, 400 + 120 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(tbTime2);

            Label lbTime3 = new Label();
            lbTime3.Text = "12:00-15:00";
            lbTime3.Size = new Size(150, 50);
            lbTime3.Location = new Point(10 + 150 * 2 + 10 * 2, 400 + 120);
            splitContainer2.Panel2.Controls.Add(lbTime3);
            TextBox tbTime3 = new TextBox();
            tbTime3.Size = new Size(150, 50);
            tbTime3.Location = new Point(10 + 150 * 2 + 10 * 2, 400 + 120 + 50 + 5);
            splitContainer2.Panel2.Controls.Add(tbTime3);

            Label lbTime4 = new Label();
            lbTime4.Text = "15:00-18:00";
            lbTime4.Size = new Size(150, 50);
            lbTime4.Location = new Point(10, 400 + 120 + 50 * 2 + 5 + 20);
            splitContainer2.Panel2.Controls.Add(lbTime4);
            TextBox tbTime4 = new TextBox();
            tbTime4.Size = new Size(150, 50);
            tbTime4.Location = new Point(10, 400 + 120 + 50 * 3 + 5 * 2 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime4);

            Label lbTime5 = new Label();
            lbTime5.Text = "18:00-21:00";
            lbTime5.Size = new Size(150, 50);
            lbTime5.Location = new Point(10 + 150 + 10, 400 + 120 + 50 * 2 + 5 + 20);
            splitContainer2.Panel2.Controls.Add(lbTime5);
            TextBox tbTime5 = new TextBox();
            tbTime5.Size = new Size(150, 50);
            tbTime5.Location = new Point(10 + 150 + 10, 400 + 120 + 50 * 3 + 5 * 2 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime5);

            Label lbTime6 = new Label();
            lbTime6.Text = "21:00-24:00";
            lbTime6.Size = new Size(150, 50);
            lbTime6.Location = new Point(10 + 150 * 2 + 10 * 2, 400 + 120 + 50 * 2 + 5 + 20);
            splitContainer2.Panel2.Controls.Add(lbTime6);
            TextBox tbTime6 = new TextBox();
            tbTime6.Size = new Size(150, 50);
            tbTime6.Location = new Point(10 + 150 * 2 + 10 * 2, 400 + 120 + 50 * 3 + 5 * 2 + 20);
            splitContainer2.Panel2.Controls.Add(tbTime6);
        }

        public void ShowServiceFrequency()
        {
            Dictionary<string, int[]> serviceCount = new Dictionary<string, int[]>();
            serviceCount = ass.GetStationServiceCount();


            
        }
    }
}
