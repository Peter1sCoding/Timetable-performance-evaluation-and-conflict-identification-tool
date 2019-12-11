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
        }

        public void ShowServiceFrequency()
        {
            

        }
    }
}
