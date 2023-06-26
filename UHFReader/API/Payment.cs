using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFReader.API
{
    public class Payment
    {
        public static PaymentResponse paymentResponse = new PaymentResponse();

        public async Task PaymentApi(PaymentRequest paymentRequest)
        {
            var options = new RestClientOptions("https://uat-vai-api.vetc.com.vn")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/v1/payment/charge", Method.Post);
            request.AddHeader("x-request-id", "request-plx-1");
            request.AddHeader("App-Code", "PLXCorp_PLXPayment_PROD");
            request.AddHeader("Partner", "PLX");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {LoginApi.loginResponse.access_token}");

            var body = JsonConvert.SerializeObject(paymentRequest);
            request.AddStringBody(body, DataFormat.Json);

            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(response.Content);
        }
    }
    public class PaymentRequest
    {
        public string plate { get; set; }
        public string etag { get; set; }
        public string plxId { get; set; }
        public string transId { get; set; }
        public string token { get; set; }
        public string amount { get; set; }
        public string terminalId { get; set; }
        public string terminalName { get; set; }
        public string mid { get; set; }
        public string transDatetime { get; set; }
    }
    public class PaymentResponse
    {
        public string result { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public int responseTime { get; set; }
        public string plxTransId { get; set; }
        public string transId { get; set; }
    }
}
