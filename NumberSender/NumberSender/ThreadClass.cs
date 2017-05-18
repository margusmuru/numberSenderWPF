using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberSender
{
    public class ThreadClass
    {

        private readonly TakenNumberController _takenNumber = new TakenNumberController();

        private readonly Random _random = new Random();

        private readonly MainWindowVM _vm;
        private readonly int _threadNum;
        private readonly int _officeId;
        private readonly int _rndMin;
        private readonly int _rndMax;

        public ThreadClass(MainWindowVM vm, int num, int office, int rndStart, int rndStop)
        {
            _vm = vm;
            _threadNum = num;
            _officeId = office;
            _rndMin = rndStart * 1000;
            _rndMax = rndStop * 1000;
        }

        public void PostNumber()
        {
            int i = 0;
            while (true)
            {
                if (i == 300)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }

                int waitTime = _random.Next(minValue: _rndMin, maxValue: _rndMax);

                //Console.WriteLine("Thread sleeps now " + waitTime);
                _vm.SetSleepingTime(id: _threadNum, text: waitTime.ToString());

                Thread.Sleep(millisecondsTimeout: waitTime);

                _vm.SetNumberValue(id: _threadNum, text: i.ToString());

                TakenNumberDTO dto = new TakenNumberDTO()
                {
                    Id = GetTimestamp(DateTime.Now),
                    Number = i,
                    DateTaken = DateTime.Now,
                    OfficeId = _officeId
                };

                //Console.WriteLine("Post: " + dto.toJSON());

                _vm.SetNumberResult(id: _threadNum, text: "Posted: \n" + dto.toJSON() + "\n");

                _takenNumber.Post(_vm, id: _officeId, json: dto.toJSON());
            }

        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString(format: "yyyyMMddHHmmssffff");
        }
    }


}
