using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DLL;
using UHFReader.API;

namespace UHFReader
{
    public partial class ViewNotify : Form
    {
        public static Dictionary<String, int> ListEpc = new Dictionary<string, int>();
        public static string EpcInprogess = "";
        bool isEpcIn = true;
        bool isBlink = true;
        int isOut = 0;
        bool isCheckIn;
        public static bool TestNoEPC;
        static DateTime timeCheck = DateTime.Now;
        int Language;
        RFID_StandardProtocol rfid_sp = new RFID_StandardProtocol();
        hComSocket CS;

        public ViewNotify()
        {
            InitializeComponent();
            SetIteamForGlobal();
            new LoginApi().Login();


                button1.Visible = TestNoEPC;

            

        }
        #region[Set Varible Global]
        private void SetIteamForGlobal()
        {
            CostGlobal.lblName = lblName;
            CostGlobal.lblLpnVeh = lblLpnVeh; 
            CostGlobal.btnDoneFuel = btnDoneFuel; 
            CostGlobal.timeProgess = timeProgess; 
            CostGlobal.timeVehOut = timeVehOut; 
            CostGlobal.plnLpn = plnLpn; 

        }
        #endregion
        private void CertificationForm_Load(object sender, EventArgs e)
        {

        }

        private void SET_button_Click(object sender, EventArgs e)
        {

        }

        private void QUERY_button_Click(object sender, EventArgs e)
        {

        }




        private void ViewNotify_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private async void timeProgess_Tick(object sender, EventArgs e)
        {
            if (isEpcIn)
            {
                isEpcIn = false;
                
                var epcInlane = ListEpc.Where(x => x.Value > AppSettings.AccessEpcPerCount).FirstOrDefault().Key;

                if (epcInlane != null && EpcInprogess == "")
                {
                    plnLpn.BackColor = Color.FromArgb(255, 204, 0);
                    lblLpnVeh.Text = "XE ĐÃ VÀO";
                    lblName.Text = "Đang kiểm tra tài khoản \n" + epcInlane.ToUpper();
                    EpcInprogess = epcInlane;
                    timeCheck = DateTime.Now;
                    if (TestNoEPC)
                    {
                        button2.Visible = true;

                    }
                    

                }
                else if (EpcInprogess == "")
                {
                    isCheckIn = false;
                    lblName.Text = "";
                    lblLpnVeh.Text = "SẴN SÀNG";
                    plnLpn.BackColor = Color.FromArgb(153, 195, 48);
                    btnDoneFuel.Visible = false;
                    button2.Visible = false;

                }
                else if ((DateTime.Now > timeCheck.AddSeconds(1))&&(isCheckIn == false))
                {
                    isCheckIn = true;
                    plnLpn.BackColor = Color.FromArgb(255, 204, 0);
                   await new InfoEpc().InfoEpcApi(EpcInprogess);
                    //if (CheckInEpc(epcInlane))
                    //{
                    //    timeProgess.Enabled = false;
                    //    timeVehOut.Enabled = true;
                    //}
                }

                if (lblLpnVeh.Text == "XE ĐÃ VÀO")
                {
                    if (isBlink)
                    {
                        plnLpn.BackColor = Color.FromArgb(255, 204, 0);
                        isBlink = false;
                    }
                    else
                    {
                        plnLpn.BackColor = Color.FromArgb(255, 255, 255);
                        isBlink = true;

                    }
                }
                isEpcIn = true;
            }


        }
        private void timeVehOut_Tick(object sender, EventArgs e)
        {
            var checkEpcOutLane = ListEpc.Where(x => x.Key == EpcInprogess).FirstOrDefault().Key;
            if (checkEpcOutLane == null)
            {
                isOut++;
                if (isOut > AppSettings.RejectEpcPerCount)
                {
                    EpcInprogess = "";
                    timeProgess.Enabled = true;
                    timeVehOut.Enabled = false;
                    isOut = 0;
                }

            }
        }


        //private bool CheckInEpc(string epc)
        //{
           

        //}
        private async void CheckOutEpc(string epc)
        {
            lblName.Text = "Đang tiến hành thành toán.";
            int transId = FactoryFunction.GetLastId();

            PaymentRequest paymentRequest = new PaymentRequest();
            paymentRequest.plate = InfoEpc.infoEpcResponse.plate.Replace("-","");
            paymentRequest.etag = epc;
            paymentRequest.plxId = "PLX001";
            paymentRequest.transId = $"PLXTRANS{transId:D3}";
            paymentRequest.token = AppSettings.TokenApi;
            paymentRequest.amount = "200000";
            paymentRequest.terminalId = "NPS";
            paymentRequest.terminalName = "Cửa hàng xăng Mễ Trì";
            paymentRequest.mid = "PLX";
            paymentRequest.transDatetime = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

           await new Payment().PaymentApi(paymentRequest);

            var dataResp = Payment.paymentResponse;
            if (dataResp.result == "SUCCESS")
            {
            //lblLpnVeh.Text = "200.000 VNĐ";
                lblName.Text = "Thanh toán thành công";
                lblLpnVeh.Text = $"{FactoryFunction.StringToMoney(paymentRequest.amount, ".")} VNĐ";
                plnLpn.BackColor = Color.FromArgb(51, 153, 0);
                btnDoneFuel.Visible = false;
            }
            else
            {
                lblName.Text = "Thanh toán không thành công";
                lblLpnVeh.Text = $"{dataResp.message}";
                plnLpn.BackColor = Color.FromArgb(204, 51, 0);
                btnDoneFuel.Visible = true;
            }
            FactoryFunction.SetLastId(transId + 1);



        }
        private void btnDoneFuel_Click(object sender, EventArgs e)
        {
            CheckOutEpc(EpcInprogess);

        }

        private void timeEpc_Tick(object sender, EventArgs e)
        {
            if (EpcInprogess != "")
            {
                label1.Text = $"{EpcInprogess} -:- {ListEpc.Where(x => x.Key == EpcInprogess).FirstOrDefault().Value}";

            }
            else
            {
                label1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //await new InfoEpc().InfoEpcApi("8930110002060900FFBCEC45");
            string[] ArEPC = new string[] { "8930110002060900FFBCEC45", "3416214B886A650004773230", "3416214B883D590005342651" };
            string EPC = ArEPC[new Random().Next(0, 3)];

            //string EPC = "3416214B886A650004773230";
            if (ListEpc != null && ListEpc.Count == 0)
            {
                ListEpc.Add(EPC, 1);
            }
            AddValueInDic(ListEpc, EPC, 60);
        }
        public void AddValueInDic(Dictionary<string, int> dic, string key, int value)
        {
            if (dic.Count > 0)
            {
                dic[key] = dic[key] + value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListEpc.Clear();
        }
    }
}
