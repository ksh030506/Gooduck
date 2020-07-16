using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goos_Manage
{
    public partial class Form3 : Form
    {
        private SqlConnection sqlconn = null;
        private string constr = "SERVER=127.0.0.1,1200; DATABASE = EX01; UID = kim; PASSWORD = 1234";

        private Byte[] byteBLOBData;

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)  // DB 연결
        {
            try
            {
                sqlconn = new SqlConnection(constr);
                sqlconn.Open();

                MessageBox.Show("연결 성공");
            }
            catch (Exception EX)
            {
                MessageBox.Show("오류 발생 : \n" + EX.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)  // DB 연결 해제
        {
            if (sqlconn != null)
            {
                sqlconn.Close();

                MessageBox.Show("연결 해제 성공");
            }
        }

        private void button4_Click(object sender, EventArgs e)  // 사진 업로드 
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fsBLOBFile = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                byteBLOBData = new byte[fsBLOBFile.Length];

                fsBLOBFile.Read(byteBLOBData, 0, byteBLOBData.Length);

                fsBLOBFile.Close();

                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);

                pictureBox1.Image = Image.FromStream(stmBLOBData);
            }
        }

        private void button1_Click(object sender, EventArgs e)  // 제품 등록 
        {
            string Name = textBox1.Text;
            string Price = textBox2.Text;
            string Type = textBox3.Text;
            string Count = textBox4.Text;
            Byte[] image = byteBLOBData;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "INSERT INTO Product(Name ,Type, Price, Image, Ccount) VALUES('" + Name + "','" + Type + "','" + Price + "','" + image + "','" + Count + "');";
                command.ExecuteNonQuery();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                MessageBox.Show("성공적으로 등록이 완료 되었습니다.");
            }
        }
    }
}
