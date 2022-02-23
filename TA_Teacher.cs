using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EducationManagementSystem
{
    public partial class TA_Teacher : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUS5TJV\SQLEXPRESS;database=OOPProject;UID=helloworld;password=hello");
        int stdid;
        public TA_Teacher()
        {
            InitializeComponent();
        }
        public void get(int stdid)
        {
            this.stdid=stdid;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand();
            if (comboBox1.Text == "")
            {
                cmd = new SqlCommand("SELECT t.t_id,tt.Name,t.Date,t.Attendance from T_Attendance t join Teacher tt on t.t_id=tt.id where tt.id=@id ", con);
                cmd.Parameters.AddWithValue("@id", stdid);
                
            }
            else if (comboBox1.Text == "Date")
            {
                string searchValue = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd = new SqlCommand("SELECT t.t_id,tt.Name,t.Date,t.Attendance from T_Attendance t join Teacher tt on t.t_id=tt.id where tt.id=@id AND t.Date=@date", con);
                cmd.Parameters.AddWithValue("@id", stdid);
                cmd.Parameters.AddWithValue("@date", searchValue);
            }
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr.ItemArray);
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
