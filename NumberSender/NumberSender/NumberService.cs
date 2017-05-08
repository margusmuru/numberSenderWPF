using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NumberSender
{
    public class NumberService
    {
        private static readonly HttpClient client = new HttpClient();

        public static MainWindowVM _vm = new MainWindowVM();

        Dictionary<string, string> values = new Dictionary<string, string>
            {
               { "Telia", _vm.str1 },
               { "Swedbank", _vm.str2 },
               { "Maanteeamet", _vm.str3 }
            };


        public async Task postNumbersAsync()
        {
            
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:29594", content);

            var responseString = await response.Content.ReadAsStringAsync();
            
        }
    }
}
