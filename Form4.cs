using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBkp
{
    public partial class Form4 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=KR2023;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                conn.Open();
                SqlCommand cmd = new SqlCommand("RatingStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name_Stud", SqlDbType.VarChar).Value = Namme.Text;
                cmd.Parameters.AddWithValue("@Dicp", SqlDbType.VarChar).Value = Discp.Text;
                cmd.Parameters.Add("@res", SqlDbType.Float).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Rslt.Text = "" + cmd.Parameters["@res"].Value;
                conn.Close();
        }
    }
}
