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
            //json 값을 웹에서 받아오기
            WebClient webClient = new WebClient();
            webClient.Headers["Contents-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            Stream stream = webClient.OpenRead("https://open.neis.go.kr/hub/mealServiceDietInfo?Type=json&ATPT_OFCDC_SC_CODE=D10&SD_SCHUL_CODE=7240454&MLSV_YMD=20210323");

            Root root = new Root();
            StreamReader reader = new StreamReader(stream);
            root = JsonConvert.DeserializeObject<Root>(reader.ReadToEnd());
            textBox1.Text = root.mealServiceDietInfo[1].row[0].DDISH_NM.Replace("<br/>", "\r\n");
            textBox2.Text = root.mealServiceDietInfo[1].row[1].DDISH_NM.Replace("<br/>", "\r\n");
            textBox3.Text = root.mealServiceDietInfo[1].row[2].DDISH_NM.Replace("<br/>", "\r\n");
            //textBox1.Text = reader.ReadToEnd();



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
