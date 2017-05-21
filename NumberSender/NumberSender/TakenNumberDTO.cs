using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSender
{
    public class TakenNumberDTO
    {
        public string PostId { get; set; }
        public int Number { get; set; }

        public DateTime DateTaken { get; set; }

        public int OfficeId { get; set; }

        public DateTime? DateService { get; set; }

        public int TakenNumberType { get; set; }

        public int? WaitTime { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(value: $"id: {PostId}\n");
            builder.Append(value: $"number: {Number}\n");
            builder.Append(value: $"DateTaken: {DateTaken}\n");
            builder.Append(value: $"OfficeId: {OfficeId}\n");
            builder.Append(value: $"DateService: {DateService}\n");
            builder.Append(value: $"TakenNumberType: {TakenNumberType}\n");
            builder.Append(value: $"WaitTime: {WaitTime}\n");
            return builder.ToString();
        }

        public string toJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value: this);
        }
    }
}
