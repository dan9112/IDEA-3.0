using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDEA_3._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(List<int> D, List<int> K)
        {
            InitializeComponent();
            Table(D, K);
        }
        private void Table(List<int> D, List<int> K)
        {
            dataGridView1.RowCount = 10;
            dataGridView1.ColumnCount = 10;
            for (int i = 0; i < 6; i++) dataGridView1.Rows[0].Cells[i].Value = "--";
            for (int i = 6; i < 10; i++)
            {
                for (int j = 0; j < 10; j++) dataGridView1.Rows[j].Cells[i].Value = X_10_to_16(D[i - 6 + j * 4]);
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if ((i == 5 || i == 4) && j == 9) dataGridView1.Rows[j].Cells[i].Value = "--";
                    else dataGridView1.Rows[j].Cells[i].Value = X_10_to_16(K[i + (j - 1) * 6]);
                }
            }
        }
        private string X_10_to_16(int a)
        {
            if (a / 4096 != 0) return (Convert.ToString(a, 16));
            else
            {
                if (a / 256 != 0) return ("0" + Convert.ToString(a, 16));
                else
                {
                    if (a / 16 != 0) return ("00" + Convert.ToString(a, 16));
                    else return ("000" + Convert.ToString(a, 16));
                }
            }
        }
    }
}