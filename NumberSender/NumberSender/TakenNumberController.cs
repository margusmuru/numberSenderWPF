using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;


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

        public async Task Post(MainWindowVM vm, int id, TakenNumberDTO dto)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString: vm.Url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(stream: httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(value: dto.toJSON());
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(stream: httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
#if DEBUG
                Trace.WriteLine(message: result);
                //Trace.WriteLine(newDto.ToString());
#endif
                JObject myJsonNetObject = JObject.Parse(json: result);
                
#if DEBUG
                Trace.WriteLine(message: (string) myJsonNetObject[key: "id"]);
#endif
                int newId = 0;
                Int32.TryParse(s: (string) myJsonNetObject[key: "id"], result: out newId);
                if (newId != 0)
                {
                    dto.Id = newId;
                }

                vm.SetNumberResult(id: id, text: "Returned: \n" + result + "\n", dto: dto);
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
