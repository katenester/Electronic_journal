using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBkp
{
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=KR2023;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("RatingAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dGV1.DataSource = dt;
            foreach (DataGridViewRow row in dGV1.Rows)
                if (Convert.ToString(row.Cells[1].Value) != "" && Convert.ToDouble(row.Cells[1].Value) < 50)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            conn.Close();
        }
    }
}
