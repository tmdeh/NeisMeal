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

            Stream stream = webClient.OpenRead("https://open.neis.go.kr/hub/mealServiceDietInfo?Type=json&ATPT_OFCDC_SC_CODE=D10&SD_SCHUL_CODE=7240454&MMEAL_SC_CODE=3&MLSV_YMD=20210323");
            // json 값을 분석
        }
    }
}
