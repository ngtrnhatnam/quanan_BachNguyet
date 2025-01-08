using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace quan_an_Bach_Nguyet.Models
{
    public class CreatePaymentQR
    {
        private readonly string clientId = "YOUR_CLIENT_ID";
        private readonly string apiKey = "YOUR_API_KEY";
        private readonly string apiUrl = "https://api.vietqr.io/v2/generate";

        public async Task<string> _CreatePaymentQR(decimal _amount)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-client-id", clientId);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);

                var requestData = new
                {
                    accountNo = "0918749407",
                    accountName = "NGUYEN TRAN NHAT NAM",
                    acqId = 970422,
                    amount = _amount,
                    addInfo = "THONG TIN THANH TOAN",
                    format = "base64",
                    template = "compact"
                };

                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseString);

                if (responseObject.code == "00")
                {
                    return responseObject.data.qrDataURL;
                }
                else
                {
                    throw new Exception($"Error: {responseObject.desc}");
                }
            }
        }
    }
}

