using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFReader.API
{
    public class InfoEpc
    {
        public static InfoEpcResponse infoEpcResponse = new InfoEpcResponse();

        public async Task InfoEpcApi(string etag)
        {
            try
            {
                var options = new RestClientOptions("https://uat-vai-api.vetc.com.vn")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/v1/vehicle/info?etag=" + etag, Method.Get);
                request.AddHeader("Authorization", $"Bearer {LoginApi.loginResponse.access_token}");
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                infoEpcResponse = JsonConvert.DeserializeObject<InfoEpcResponse>(response.Content);
                if (infoEpcResponse != null && infoEpcResponse.status == "1")
                {
                    FactoryFunction.SetTextLable(CostGlobal.lblName, "Xin chào " + infoEpcResponse.cust_name);
                    FactoryFunction.SetTextLable(CostGlobal.lblLpnVeh, infoEpcResponse.plate);
                    FactoryFunction.SetVisibleButton(CostGlobal.btnDoneFuel, true);
                }
                else
                {
                    FactoryFunction.SetTextLable(CostGlobal.lblName, infoEpcResponse.message);
                    FactoryFunction.SetTextLable(CostGlobal.lblLpnVeh, infoEpcResponse.error_code);
                    FactoryFunction.SetTextLable(CostGlobal.lblLpnVeh, infoEpcResponse.error_code); 
                    FactoryFunction.SetColorPanel(CostGlobal.plnLpn, Color.FromArgb(204, 51, 0)); 
                }
                CostGlobal.timeProgess.Enabled = false;
                CostGlobal.timeVehOut.Enabled = true;
            }
            catch (Exception)
            {
               
            }
           
            
        }

    }

    public class InfoEpcRequest
    {

    }

    public class InfoEpcResponse
    {
        public string plate { get; set; }
        public string etag { get; set; }
        public int weight { get; set; }
        public int weight_all { get; set; }
        public int weight_goods { get; set; }
        public int seat { get; set; }
        public string register_vehicle_type { get; set; }
        public string acv_vehicle_type { get; set; }
        public int account_id { get; set; }
        public string account_number { get; set; }
        public string account_status { get; set; }
        public string mobi_number { get; set; }
        public int avaiable_balance { get; set; }
        public string cust_name { get; set; }
        public string cust_address { get; set; }
        public object cust_tax_code { get; set; }
        public string cust_type { get; set; }
        public string status { get; set; }
        public string vehicle_type { get; set; }
        public string mig_object_id { get; set; }
        public string stack_trace { get; set; }
        public string error_code { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
    }
}
