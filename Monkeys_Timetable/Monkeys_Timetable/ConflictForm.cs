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
    public partial class ConflictForm : Form
    {
        /// <summary>
        ///以DataGridView格式显示各冲突的相关信息
        /// </summary>
        public ConflictForm(DataTable dt)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = dt;
            this.label1.Text = "共有冲突" + dt.Rows.Count + "处";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
