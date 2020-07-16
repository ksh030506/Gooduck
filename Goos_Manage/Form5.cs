using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goos_Manage
{
    public partial class Form5 : Form
    {
        private SqlConnection sqlconn = null;
        private string constr = "SERVER=127.0.0.1,1200; DATABASE = EX01; UID = kim; PASSWORD = 1234";

        public Form5()
        {
            InitializeComponent();

            try
            {
                sqlconn = new SqlConnection(constr);
                sqlconn.Open();
            }
            catch (Exception EX)
            {
                MessageBox.Show("오류 발생 : \n" + EX.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)  // 제품 조회
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();

                string sql = "SELECT PID, Name, Price, Type, Ccount FROM Product";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Table_1");
            }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)  // 제품 변경
        {
            string name = textBox1.Text;
            string price = textBox5.Text;
            string pid = textBox3.Text;

            if (price == "" || pid=="")
            {
                MessageBox.Show("빈칸에 입력해주세요");
            }
            else
            {
                if (textBox1.Text == null)
                {
                    if (int.Parse(pid) > 25)
                    {
                        MessageBox.Show("해당 재고가 없습니다");
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(constr))
                        {
                            conn.Open();
                            SqlCommand command = new SqlCommand();

                            command.Connection = conn;
                            command.CommandText = "UPDATE Product SET Price = '" + price + "'WHERE PID =" + pid;
                            command.ExecuteNonQuery();
                            MessageBox.Show("구매 완료 되었습니다");

                            button3_Click(null, null);
                        }
                    }
                }
                else
                {
                    if (int.Parse(pid) > 25)
                    {
                        MessageBox.Show("해당 재고가 없습니다");
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(constr))
                        {
                            conn.Open();
                            SqlCommand command = new SqlCommand();

                            command.Connection = conn;
                            command.CommandText = "UPDATE Product SET Price = '" + price + "', Name = '" + name + "'WHERE PID =" + pid;
                            command.ExecuteNonQuery();
                            MessageBox.Show("변경되었습니다");

                            button3_Click(null, null);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  // 제품 추가 구매
        {
            string pid = textBox4.Text;
            string count = textBox2.Text;

            if (pid == "" || count == "")
            {
                MessageBox.Show("빈칸에 입력해주세요");
            }
            else
            {
                if (int.Parse(pid) > 25)
                {
                    MessageBox.Show("해당 재고가 없습니다");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();

                        command.Connection = conn;
                        command.CommandText = "UPDATE Product SET Ccount = ( select Ccount from Product where PID = '" + pid + "' ) + '" + count + "' WHERE PID =" + pid;
                        command.ExecuteNonQuery();
                        MessageBox.Show("변경되었습니다");

                        button3_Click(null, null);
                    }
                }
            }
        }
    }
    
}
