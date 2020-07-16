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
    public partial class Form2 : Form
    {

        private SqlConnection sqlconn = null;
        private string constr = "SERVER=127.0.0.1,1200; DATABASE = EX01; UID = kim; PASSWORD = 1234";

        int[] int_price = new int[25] {3000, 4000, 4500, 1500, 1500, 1500, 1500, 2000, 2000, 2000, 2000, 1500, 1500, 1500,
            1500, 3500, 3500, 3500, 2500, 3000, 3000, 3500, 3500, 1500, 1500};
        int[] counts = new int[25] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int prices = 0;
        string test;

        public Form2()
        {
            InitializeComponent();

            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            AlertMessage(i, i-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 2;
            AlertMessage(i, i - 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 3;
            AlertMessage(i, i - 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 4;
            AlertMessage(i, i - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 5;
            AlertMessage(i, i - 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 6;
            AlertMessage(i, i - 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = 7;
            AlertMessage(i, i - 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = 8;
            AlertMessage(i, i - 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = 9;
            AlertMessage(i, i - 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 10;
            AlertMessage(i, i - 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i = 11;
            AlertMessage(i, i - 1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i = 12;
            AlertMessage(i, i - 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int i = 13;
            AlertMessage(i, i - 1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int i = 14;
            AlertMessage(i, i - 1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int i = 15;
            AlertMessage(i, i - 1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int i = 16;
            AlertMessage(i, i - 1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int i = 17;
            AlertMessage(i, i - 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int i = 18;
            AlertMessage(i, i - 1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int i = 19;
            AlertMessage(i, i - 1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i = 20;
            AlertMessage(i, i - 1);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int i = 21;
            AlertMessage(i, i - 1);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int i = 22;
            AlertMessage(i, i - 1);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int i = 23;
            AlertMessage(i, i - 1);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int i = 24;
            AlertMessage(i, i - 1);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int i = 25;
            AlertMessage(i, i - 1);
        }

        private void printList(int i)   // 리스트뷰에 추가하는 메소드
        {
            counts[i - 1]++;    // 수량 증가

            ListViewItem item = new ListViewItem();

            item.Text = i.ToString();

            // 버튼 누르면 리스트뷰에 db에서 가져와서 출력 시킬 부분
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "select Name from Product where PID =" + i;
                string name = ((string)command.ExecuteScalar());

                command.CommandText = "select Price from Product where PID =" + i;
                int price = (int)command.ExecuteScalar();

                item.SubItems.Add(name);
                item.SubItems.Add(counts[i - 1].ToString());
                item.SubItems.Add(price.ToString());
                item.SubItems.Add((counts[i - 1] * price).ToString());

                listView1.Items.Add(item);
            }
            Total(i);
        }

        private void countUp(int i, int y)  //수량 증가시키는 메소드
        {
            if (counts[y] >= 1)
            {
                for (int x = 0; x < listView1.Items.Count; x++)
                {
                    if (listView1.Items[x].Text == i.ToString())
                    {
                        counts[y]++;
                        int b = counts[y];
                        listView1.Items[x].SubItems[2].Text = b.ToString();


                        // 제품의 가격을 바꿔도 적용되게
                        using (SqlConnection conn = new SqlConnection(constr))
                        {
                            conn.Open();
                            SqlCommand command = conn.CreateCommand();

                            command.CommandText = "select Price from Product where PID =" + i;
                            int price = (int)command.ExecuteScalar();

                            listView1.Items[x].SubItems[4].Text = (counts[y] * price).ToString();
                        }
                    }
                }
                Total(i);
            }
            else
            {
                printList(i);
            }
        }

        private void AlertMessage(int i, int y) // 수량이 없으면 알림을 띄어줌
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "select Ccount from Product where PID =" + i; // db에서 재고를 가져옴
                int count = (int)command.ExecuteScalar();

                int sub = count - counts[y];

                if (sub <= 0)
                {
                    MessageBox.Show("재고가 부족합니다.");
                }
                else
                {
                    countUp(i, y);
                }
            }
        }

        private void Total(int i)   // 총액 구하는 메소드
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = "select Price from Product where PID =" + i;
                int price = (int)command.ExecuteScalar();

                prices += price;
                label4.Text = prices.ToString();
            }
            
        }

        private void button22_Click(object sender, EventArgs e) // 결제 이벤트
        {
            int pid;
            string product_name;
            int product_count;
            int cost;

            for(int i =0; i < listView1.Items.Count; i++)
            {
                pid = int.Parse(listView1.Items[i].SubItems[0].Text); // 제품 pid
                product_name = listView1.Items[i].SubItems[1].Text; // 제품 이름
                product_count = int.Parse(listView1.Items[i].SubItems[2].Text); // 제품 수량
                cost = int_price[pid - 1];
                counts[pid - 1] = 0;

                // 판매 테이블에 기록
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();

                    command.Connection = conn;
                    command.CommandText = "INSERT INTO Sale(Sname ,Sprice, Ccount, PID) VALUES('" + product_name + "','" + cost + "','" + product_count + "','" + pid + "');";
                    command.ExecuteNonQuery();
                }

                // 재고 업데이트
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();

                    command.Connection = conn;
                    command.CommandText = "UPDATE Product SET Ccount = ( select Ccount from Product where PID = '" + pid + "' ) - '" + product_count + "' WHERE PID =" + pid;
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("성공적으로 " + prices + " 결제가 완료 되었습니다.");

            listView1.Items.Clear();
            prices = 0;
            label4.Text = "0원";
        }

        private void button21_Click(object sender, EventArgs e) // 삭제버튼 클릭시 작동
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int selectRow = listView1.SelectedItems[0].Index;
                test = listView1.Items[selectRow].SubItems[0].Text;
                int pid = int.Parse(test);
                int count_num = 0;

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "select Price from Product where PID =" + pid;
                    int price = (int)command.ExecuteScalar();

                    // 삭제하면 금액 줄어듬
                    count_num = counts[pid - 1];
                    prices -= (count_num * price);
                    label4.Text = prices.ToString();
                } 

                // 수량을 0으로 초기화               
                counts[pid - 1] = 0;

                // 선택된 항목 리스트에서 삭제
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }
    }
}
