using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ShowTable(string query)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SalesDataBaseConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dataGridView1.Columns.Clear();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> checkBoxes = new Dictionary<string, bool>();
            SalesBL.LoopControls(checkBoxes, this.Controls);

            string query = SalesBL.QueryFormation(checkBoxes);
            ShowTable(query);

            //SalesDataBaseEntities db = new SalesDataBaseEntities();
            //var result = db.Sales
            //            .GroupBy(a => a.Manager)
            //            .Select(a => new { Manager = a.Key, Quantity = a.Sum(g => g.Quantity), Summ = a.Sum(g => g.Summ) })
            //            .ToList();
            //dataGridView1.DataSource = result;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string query = "SELECT* from Sales";

            ShowTable(query);

            int gridHeadersCount = dataGridView1.ColumnCount;
            CheckBox box;
            for (int i = 1; i < gridHeadersCount-2; i++)
            {
                box = new CheckBox();
                box.Name = "i";
                box.Text = dataGridView1.Columns[i].HeaderText;
                box.AutoSize = true;
                box.Location = new Point(10, i * 40); 
                this.Controls.Add(box);
            }
        }

        private void Default_Click(object sender, EventArgs e)
        {
            string query = "SELECT* from Sales";
            ShowTable(query);

            foreach (Control cBox in this.Controls)
            {
                if (cBox is CheckBox)
                {
                    ((CheckBox)cBox).Checked = false;
                }
            }
        }

    }
}
