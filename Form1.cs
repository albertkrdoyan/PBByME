using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBByME_V1._0
{
    public partial class Form1: Form
    {
        private PhoneBookSqlManager pb;
        public Form1()
        {
            InitializeComponent();
        }

        private void MainFormClosing(Object sender, FormClosingEventArgs e)
        {
            pb.PCloseDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb = new PhoneBookSqlManager();

            pb.UpdateDataGrid(ref dataGridView1);
        }
    }
}
