using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.NetworkInformation;



namespace NeisMeal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool connected = NetworkInterface.GetIsNetworkAvailable();
            //json 값을 웹에서 받아오기
            string today = System.DateTime.Now.ToString("yyyyMMdd");
            WebClient webClient = new WebClient();
            webClient.Headers["Contents-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string neis = "https://open.neis.go.kr/hub/mealServiceDietInfo?Type=json&ATPT_OFCDC_SC_CODE=D10&SD_SCHUL_CODE=7240454&MLSV_YMD=";
                neis += today;
                Stream stream = webClient.OpenRead(neis);

                Root root = new Root();
                StreamReader reader = new StreamReader(stream);
                root = JsonConvert.DeserializeObject<Root>(reader.ReadToEnd());
                textBox1.TextAlign = HorizontalAlignment.Center;
                textBox2.TextAlign = HorizontalAlignment.Center;
                textBox3.TextAlign = HorizontalAlignment.Center;
                textBox4.TextAlign = HorizontalAlignment.Center;
                textBox5.TextAlign = HorizontalAlignment.Center;
                textBox6.TextAlign = HorizontalAlignment.Center;
                BackColor = Color.Azure;
                textBox1.BackColor = Color.AliceBlue;
                textBox2.BackColor = Color.AliceBlue;
                textBox3.BackColor = Color.AliceBlue;
                textBox4.BackColor = Color.AliceBlue;
                textBox5.BackColor = Color.AliceBlue;
                textBox6.BackColor = Color.AliceBlue;
                textBox4.Text = "저녁";
                textBox5.Text = "점심";
                textBox6.Text = "아침";
                try
                {
                    textBox1.Text = root.mealServiceDietInfo[1].row[0].DDISH_NM.Replace("<br/>", "\r\n");
                    textBox2.Text = root.mealServiceDietInfo[1].row[1].DDISH_NM.Replace("<br/>", "\r\n");
                    textBox3.Text = root.mealServiceDietInfo[1].row[2].DDISH_NM.Replace("<br/>", "\r\n");
                }
                catch
                {
                    textBox1.Text = root.mealServiceDietInfo[1].row[0].DDISH_NM.Replace("<br/>", "\r\n");
                    textBox2.Text = root.mealServiceDietInfo[1].row[1].DDISH_NM.Replace("<br/>", "\r\n");
                }
            }
                //textBox1.Text = reader.ReadToEnd();
            catch(System.Net.WebException)
            {
                MessageBox.Show("인터넷 연결을 확인해 주세요.");
                textBox1.Text = "연결 안됨";
                textBox2.Text = "연결 안됨";
                textBox3.Text = "연결 안됨";
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class RESULT
    {
        public string CODE { get; set; }
        public string MESSAGE { get; set; }
    }

    public class Head
    {
        public int list_total_count { get; set; }
        public RESULT RESULT { get; set; }
    }

    public class Row
    {
        public string ATPT_OFCDC_SC_CODE { get; set; }
        public string ATPT_OFCDC_SC_NM { get; set; }
        public string SD_SCHUL_CODE { get; set; }
        public string SCHUL_NM { get; set; }
        public string MMEAL_SC_CODE { get; set; }
        public string MMEAL_SC_NM { get; set; }
        public string MLSV_YMD { get; set; }
        public string MLSV_FGR { get; set; }
        public string DDISH_NM { get; set; }
        public string ORPLC_INFO { get; set; }
        public string CAL_INFO { get; set; }
        public string NTR_INFO { get; set; }
        public string MLSV_FROM_YMD { get; set; }
        public string MLSV_TO_YMD { get; set; }
    }

    public class MealServiceDietInfo
    {
        public List<Head> head { get; set; }
        public List<Row> row { get; set; }
    }

    public class Root
    {
        public List<MealServiceDietInfo> mealServiceDietInfo { get; set; }
    }
}
