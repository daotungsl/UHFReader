using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UHFReader
{
    public class FactoryFunction
    {
        public static void SetLastId(int lastId)
        {
            try
            {
                string path = $"{Environment.CurrentDirectory}/Data/LastTransId.text";
                if (File.Exists(path))
                {
                    File.WriteAllText(path, lastId.ToString());
                }
                else
                {

                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    }

                    using (FileStream fs = File.Create(path))
                    {
                        byte[] data = new UTF8Encoding(true).GetBytes(lastId.ToString());
                        fs.Write(data, 0, data.Length);
                    }

                }
            }
            catch (Exception)
            {

            }
        }
        public static int GetLastId()
        {
            try
            {
                string path = $"{Environment.CurrentDirectory}/Data/LastTransId.text";
                if (!File.Exists(path))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    }
                    SetLastId(1);
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(File.ReadAllText(path));

                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
        
        public static void SetTextLable(Label label, string text)
        {
            try
            {
                if (label != null)
                {
                    if (label.InvokeRequired)
                    {
                        label.BeginInvoke((MethodInvoker)delegate
                        {
                            label.Text = text;
                        });
                    }
                    else
                    {
                        label.Text = text;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public static void SetVisibleButton(Button button, bool visble)
        {
            try
            {
                if (button != null)
                {
                    if (button.InvokeRequired)
                    {
                        button.BeginInvoke((MethodInvoker)delegate
                        {
                            button.Visible = visble;
                        });
                    }
                    else
                    {
                        button.Visible = visble;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public static string StringToMoney(string money,string separator)
        {
            money = money.Replace(",00", "");
            StringBuilder stringBuilder = new StringBuilder(money);
            int i = (money.Length - 3);
            while (i > 0)
            {
                stringBuilder = stringBuilder.Insert(i, separator);
                i -= 3;
            }
            return stringBuilder.ToString();
        }

    }
}
