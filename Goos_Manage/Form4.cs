using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Goos_Manage
{
    public partial class Form4 : Form
    {

        private SqlConnection sqlconn = null;
        private string constr = "SERVER=127.0.0.1,1200; DATABASE = EX01; UID = kim; PASSWORD = 1234";

        public Form4()
        {
            InitializeComponent();

            TotalCost();

            Record();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           

        }

        private void button21_Click(object sender, EventArgs e)
        {
            int i = 1;
            AlertMessage(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 2;
            AlertMessage(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 3;
            AlertMessage(i);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 4;
            AlertMessage(i);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 5;
            AlertMessage(i);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 6;
            AlertMessage(i);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = 7;
            AlertMessage(i);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = 8;
            AlertMessage(i);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = 9;
            AlertMessage(i);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 10;
            AlertMessage(i);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i = 11;
            AlertMessage(i);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i = 12;
            AlertMessage(i);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int i = 13;
            AlertMessage(i);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int i = 14;
            AlertMessage(i);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int i = 15;
            AlertMessage(i);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int i = 16;
            AlertMessage(i);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int i = 17;
            AlertMessage(i);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int i = 18;
            AlertMessage(i);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int i = 19;
            AlertMessage(i);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i = 20;
            AlertMessage(i);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int i = 21;
            AlertMessage(i);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int i = 22;
            AlertMessage(i);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int i = 23;
            AlertMessage(i);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int i = 24;
            AlertMessage(i);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int i = 25;
            AlertMessage(i);
        }
        public void AlertMessage(int pid)
        {

                string a;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "select SUM(a.Ccount), a.Type from ( select Sale.Ccount, Product.Type from Sale, Product where Sale.PID = Product.PID and Product.PID = "+ pid +" ) a group by a.Type; ";

                    a = command.ExecuteScalar().ToString();


                    command.CommandText = "select a.Type, SUM(a.Ccount) from ( select Sale.Ccount, Product.Type from Sale, Product where Sale.PID = Product.PID and Product.PID = " + pid +" ) a group by a.Type; ";

                    string b = command.ExecuteScalar().ToString();

                    MessageBox.Show("판매 갯수 : " + a + "\n제품 타입 : " + b);
                }

                buttonRecord(pid, int.Parse(a));

            
            
        }

        private void TotalCost()    // 판매 총액 구하는 부분
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "select SUM(Sprice*Ccount) from Sale;";
                int price = (int)command.ExecuteScalar();

                label2.Text = price.ToString()+" 원";
            }
        }

        private void Record()   // 데이터 그리드 뷰에 출력
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();

                string sql = "select SUM(Sale.Ccount * Product.Price) as '총 가격', Product.Name from Sale, Product where Sale.PID = Product.PID group by Product.PID, Product.Name order by Product.PID ASC; ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Table_1");
            }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void buttonRecord(int pid, int count)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();

                string sql = "SELECT SID, Sname, Ccount FROM Sale where PID =" + pid +";";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Table_1");
            }
            dataGridView1.DataSource = ds.Tables[0];

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "select Price from Product;";
                int abc = (int)command.ExecuteScalar();

                label2.Text = (abc*count).ToString() + " 원";
            }
        }

        private void button1_Click(object sender, EventArgs e)  // 데이터 그리드 뷰에서 선택한 행의 데이터 삭제
        {
            string sid = label4.Text;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "delete from Sale Where SID = " + sid;
                command.ExecuteNonQuery();

                MessageBox.Show("판매 내역이 초기화 되었습니다");
            }

            DataSet ds = new DataSet(); // 삭제 후 데이터 그리드 뷰 새로고침
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();

                string sql = "SELECT SID, Sname, Ccount FROM Sale;";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Table_1");
            }
            dataGridView1.DataSource = ds.Tables[0];
            TotalCost();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // 클릭한 행의 SID 부분을 가져오는 메소드
        {
            label4.Text = dataGridView1.Rows[e.RowIndex].Cells["SID"].Value.ToString();
        }
    }
}
