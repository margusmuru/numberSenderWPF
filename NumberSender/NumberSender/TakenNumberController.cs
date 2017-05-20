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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString: vm.Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(stream: httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(stream: httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                vm.SetNumberResult(id: id, text: "Returned: \n" + result + "\n", dto: null);
            }
        }

        public async Task Put(MainWindowVM vm, int id, String json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString: vm.Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(stream: httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(stream: httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                vm.SetNumberResultT(id: id, text: "Returned from update: \n" + result + "\n");
            }
        }



    }
}
