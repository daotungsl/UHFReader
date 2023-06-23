using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLL;

namespace UHFReader
{
    public partial class CertificationForm : Form
    {
        int Language;
        RFID_StandardProtocol rfid_sp = new RFID_StandardProtocol();
        hComSocket CS;

        public CertificationForm()
        {
            InitializeComponent();
        }

        private void CertificationForm_Load(object sender, EventArgs e)
        {
            LOGIN_label.Visible = false;
            PW_textBox.Visible = false;
            SIX_label.Visible = false;

            CTF_label.Visible = false;
            CTF_textBox.Visible = false;
            TBYTE_label.Visible = false;

            SET_button.Visible = false;
            QUERY_button.Visible = false;

            MPW_textBox.Visible = true;
            MTITLE_label.Visible = true;
            MANAGER_button.Visible = true;

            MainForm.ReadLanguageFile(ref Language);
            if (0 == Language)
            {
                MTITLE_label.Text = "请输入(6位)标签认证管理密码";
                MANAGER_button.Text = "开始管理";
                LOGIN_label.Text = "管理密码:";
                CTF_label.Text = "标签验证码:";
                SET_button.Text = "设置";
                QUERY_button.Text = "查询";
            }
            else
            {
                MTITLE_label.Text = "Please input six numbers with certification";
                MANAGER_button.Text = "Manager";
                LOGIN_label.Text = "Access PW:";
                CTF_label.Text = "Certification:";
                SET_button.Text = "Set";
                QUERY_button.Text = "Query";
                MTITLE_label.Left = (this.Width - INFO_label.Width) / 2 - 150;
            }
        }

        private void SET_button_Click(object sender, EventArgs e)
        {
         
        }

        private void QUERY_button_Click(object sender, EventArgs e)
        {

        }

        private void MANAGER_button_Click(object sender, EventArgs e)
        {
            string mPW = "";
            byte[] MPW = new byte[10];

            mPW = MPW_textBox.Text;
            MainForm.HexStrToByte(MPW, mPW);

            if (0 == rfid_sp.CheckManagePW(CS, MPW, 0xFF))
            {
                //((CButton*)GetDlgItem(IDC_STATIC_LOGIN))->ShowWindow(true);
                //((CButton*)GetDlgItem(IDC_EDIT_PW))->ShowWindow(true);
                //((CButton*)GetDlgItem(IDC_STATIC_SIX))->ShowWindow(true);

                //((CButton*)GetDlgItem(IDC_STATIC_CERTIFICATION))->ShowWindow(true);
                //((CButton*)GetDlgItem(IDC_EDIT_CTF))->ShowWindow(true);
                //((CButton*)GetDlgItem(IDC_STATIC_TBYTE))->ShowWindow(true);

                //((CButton*)GetDlgItem(IDC_BUTTON_SET))->ShowWindow(true);
                //((CButton*)GetDlgItem(IDC_BUTTON_QUERY))->ShowWindow(true);

                //((CButton*)GetDlgItem(IDC_STATIC_MTITLE))->ShowWindow(false);
                //((CButton*)GetDlgItem(IDC_EDIT_MPW))->ShowWindow(false);
                //((CButton*)GetDlgItem(IDC_BUTTON_MANAGER))->ShowWindow(false);
            }
            else
            {
                if (0 == Language)
                    INFO_label.Text = "管理密码校验错误!请重新输入……";
                else  
                    INFO_label.Text = "access password check error,please input again";
                
            }
        }

        private void MPW_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
