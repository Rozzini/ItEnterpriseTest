using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Net
{
    public partial class Form1 : Form
    {
        private int gridHeadersCount;
        public Form1()
        {
            InitializeComponent();
        }

        //@"Data Source =.\SQLEXPRESS; AttachDbFilename =[DataDirectory]\Database1.mdf; Integrated Security = true; User Instance = true"
        //@"Data Source=.\SQLEXPRESS;  AttachDbFilename=Path\Database1.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True"
        private void button1_Click(object sender, EventArgs e)
        {
            string address = "Data Source=(localdb)\\v11.0;Initial Catalog=Database1;Integrated Security=True";
            //connection object
            SQLiteConnection con = new SQLiteConnection(@"Data Source=.\SQLEXPRESS;  AttachDbFilename=Path\Database1.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True");
            con.Open();
            //command object
            string query = "SELECT* from Sales";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            //adapter
            //datatable
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            gridHeadersCount = dataGridView1.ColumnCount;

            CheckBox box;
            for (int i = 1; i < gridHeadersCount; i++)
            {
                box = new CheckBox();
                box.Tag = i+1;
                box.Text = dataGridView1.Columns[i].HeaderText;
                box.AutoSize = true;
                box.Location = new Point(10, i * 40); //vertical
                                                      //box.Location = new Point(i * 50, 10); //horizontal
                this.Controls.Add(box);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
