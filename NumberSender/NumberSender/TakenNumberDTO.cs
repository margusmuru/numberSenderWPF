using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSender
{
    public class TakenNumberDTO
    {
        public string Id { get; set; }
        public int Number { get; set; }

        public DateTime DateTaken { get; set; }

        public int OfficeId { get; set; }

        public DateTime? DateService { get; set; }

        public int? WaitTime { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"id: {Id}\n");
            builder.Append($"number: {Number}\n");
            builder.Append($"DateTaken: {DateTaken}\n");
            builder.Append($"OfficeId: {OfficeId}\n");
            builder.Append($"DateService: {DateService}\n");
            builder.Append($"WaitTime: {WaitTime}");
            return builder.ToString();
        }

        public string toJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
