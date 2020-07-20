using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowDB_Click(object sender, EventArgs e)
        {
            //connection object
            SQLiteConnection con = new SQLiteConnection(@"data source=D:\Project\ItEncTest\mobiles.db");

            //command object
            string query = "SELECT* from Phones";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            //adapter
            //datatable
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1) // Means that you've not clicked the column header
            {
                MessageBox.Show(
       "Выберите один из вариантов",
       "Сообщение",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Information,
       MessageBoxDefaultButton.Button1,
       MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
