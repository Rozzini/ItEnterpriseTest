using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public static class SalesBL
    {
        public static void LoopControls(Dictionary<string, bool> checkBoxes, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is CheckBox)
                    checkBoxes.Add(control.Text, ((CheckBox)control).Checked);
                if (control.Controls.Count > 0)
                    LoopControls(checkBoxes, control.Controls);
            }
        }
        
        public static string QueryFormation(Dictionary<string, bool> checkBoxes)
        {
            List<string> columns = new List<string>();
            foreach(var x in checkBoxes)
            {
                if(x.Value)
                {
                    columns.Add(x.Key);
                }
            }

            if(columns.Count == 0)
            {
                return "SELECT* from Sales";
            }

            return QueryBuilder(columns);
        }

        private static string QueryBuilder(List<string> columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            foreach(string x in columns)
            {
                sb.Append(x + ", ");
            }
            sb.Append("SUM(Quantity) AS Quantity, SUM(Summ) As Summ from  Sales group by ");
            for(int i = 0; i < columns.Count; i++)
            {
                if (i == 0) sb.Append(columns[i]);
                else sb.Append(", " + columns[i]);
            }
            return sb.ToString();
        }
        
    }
}
