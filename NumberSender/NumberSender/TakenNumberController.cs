using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;



namespace NumberSender
{
    public class TakenNumberController
    {
        private static readonly HttpClient client = new HttpClient();

        public static MainWindowVM _vm = new MainWindowVM();

       
        public async Task Post(Dictionary<string, string> values)
        {
           
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:29594/api/takennumbers", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
        




    }
}
