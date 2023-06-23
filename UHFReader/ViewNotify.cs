using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;

namespace UHFReader
{
    public partial class ViewNotify : Form
    {
        public static Dictionary<String, int> ListEpc = new Dictionary<string, int>();
        public static string EpcInprogess = "";
        bool isEpcIn = true;
        bool isBlink = true;
        int isOut = 0;
        static DateTime timeCheck = DateTime.Now;
        int Language;
        RFID_StandardProtocol rfid_sp = new RFID_StandardProtocol();
        hComSocket CS;

        public ViewNotify()
        {
            InitializeComponent();
        }

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

        private void timeProgess_Tick(object sender, EventArgs e)
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

                }
                else if (EpcInprogess == "")
                {
                    lblName.Text = "";
                    lblLpnVeh.Text = "SẴN SÀNG";
                    plnLpn.BackColor = Color.FromArgb(153, 195, 48);
                    btnDoneFuel.Visible = false;

                }
                else if (DateTime.Now > timeCheck.AddSeconds(2))
                {
                    plnLpn.BackColor = Color.FromArgb(255, 204, 0);
                    if (CheckInEpc(epcInlane))
                    {
                        timeProgess.Enabled = false;
                        timeVehOut.Enabled = true;
                    }
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


        private bool CheckInEpc(string epc)
        {
            lblName.Text = "Xin chào " + "PHẠM NGỌC HOÀI";
            lblLpnVeh.Text = "38A-344.23";
            btnDoneFuel.Visible = true;
            return true;
        }
        private void CheckOutEpc(string epc)
        {
            lblName.Text = "Đang tiến hành thành toán.";
            //lblLpnVeh.Text = "200.000 VNĐ";
            lblName.Text = "Thanh toán thành công";
            lblLpnVeh.Text = "200.000 VNĐ";
            plnLpn.BackColor = Color.FromArgb(51, 153, 0);
            btnDoneFuel.Visible = false;


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
    }
}
