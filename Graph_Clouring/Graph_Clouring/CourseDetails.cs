using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Graph_Clouring
{
    public partial class CourseDetails : Form
    {
        public CourseDetails()
        {
            InitializeComponent();
            BindGridView();
        }
        int id, index;
        bool response;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void CourseDetails_Load(object sender, EventArgs e)
        {

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from coursedetails_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (response)
            {
                txtcoursename.Clear();
                txtsmestername.Clear();
                response = false;
            }

            if (string.IsNullOrEmpty(txtsmestername.Text) == true)
            {
                txtsmestername.Focus();
                errorProvider1.SetError(this.txtsmestername, "Please Enter Item Name");
            }
            else if (string.IsNullOrEmpty(txtcoursename.Text) == true)
            {
                txtcoursename.Focus();

                errorProvider2.SetError(this.txtcoursename, "Please Enter Item Price");
            }
            else
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from coursedetails_tbl  where smester_name = @sname";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sname", txtsmestername.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    SqlConnection conupdate = new SqlConnection(cs);
                    string queryupdate = "update  coursedetails_tbl set courses_name=CONCAT(courses_name,@name) where smester_name=@id";
                    SqlCommand cmdupdate = new SqlCommand(queryupdate, conupdate);
                    cmdupdate.Parameters.AddWithValue("@id", txtsmestername.Text);
                    cmdupdate.Parameters.AddWithValue("@name", " " + txtcoursename.Text.Trim());
                    conupdate.Open();
                    int a = cmdupdate.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Insert SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    conupdate.Close();
                }
                else
                {
                    con.Close();
                    SqlConnection coninsert = new SqlConnection(cs);
                    string queryinsert = "insert into coursedetails_tbl values (@smester_name,@course_name)";
                    SqlCommand cmdinsert = new SqlCommand(queryinsert, coninsert);
                    cmdinsert.Parameters.AddWithValue("@smester_name", txtsmestername.Text);
                    cmdinsert.Parameters.AddWithValue("@course_name", txtcoursename.Text.Trim());
                    coninsert.Open();
                    int a = cmdinsert.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Inserted SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetControl();
                        BindGridView();
                    }
                    else
                    {
                        MessageBox.Show("Insertion Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    coninsert.Close();
                }
                con.Close();
            }

        }

        void ResetControl()
        {
            txtcoursename.Clear();
            txtsmestername.Clear();
            txtsmestername.Focus();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           


                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                txtsmestername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtcoursename.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                index = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Length;
                response = true;
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  coursedetails_tbl where smester_name=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", txtsmestername.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Delete SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                ResetControl();

            }
            else
            {
                MessageBox.Show("Delete Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string text = txtcoursename.Text.Substring(index).Trim();
            if (text == "")
            {
                return;
            }
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from coursedetails_tbl  where smester_name = @sname";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sname", txtsmestername.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                SqlConnection conupdate = new SqlConnection(cs);
                string queryupdate = "update  coursedetails_tbl set courses_name=CONCAT(courses_name,@name) where smester_name=@id";
                SqlCommand cmdupdate = new SqlCommand(queryupdate, conupdate);
                cmdupdate.Parameters.AddWithValue("@id", txtsmestername.Text);
                cmdupdate.Parameters.AddWithValue("@name", " " + text);
                conupdate.Open();
                int a = cmdupdate.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Insert SuccessFully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ResetControl();

                }
                else
                {
                    MessageBox.Show("Update Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                conupdate.Close();


            }
        }
    }
}
