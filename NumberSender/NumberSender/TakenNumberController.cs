using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;



namespace NumberSender
{
    public class TakenNumberController
    {
        private static readonly HttpClient Client = new HttpClient();
       
        public async Task Post(Dictionary<string, string> values)
        {
           
            var content = new FormUrlEncodedContent(nameValueCollection: values);

            var response = await Client.PostAsync("http://localhost:29594/api/takennumbers", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(value: responseString);
        }

        public async Task Post(MainWindowVM vm, int id, String json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString: "http://localhost:29594/api/takennumbers");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(stream: httpWebRequest.GetRequestStream()))
            {
                //string json = "{\"user\":\"test\"," +
                  //            "\"password\":\"bla\"}";

                streamWriter.Write(json);
                //streamWriter.Flush();
                //streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(stream: httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Console.WriteLine(value: "result: " + result);
                vm.SetNumberResult(id: id, text: "Returned: \n" + result + "\n");
            }
        }




    }
}
