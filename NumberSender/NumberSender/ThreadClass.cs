﻿using System;
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
        private readonly int _numType;
        private readonly int _numMin;
        private readonly int _numMax;

        public ThreadClass(MainWindowVM vm, int num, int office, int rndStart, int rndStop, int numType, int numMin, int numMax)
        {
            _vm = vm;
            _threadNum = num;
            _officeId = office;
            _rndMin = rndStart;
            _rndMax = rndStop;
            _numType = numType;
            _numMin = numMin;
            _numMax = numMax;
        }

        public void PostNumber()
        {
            int i = _numMin - 1;
            while (true)
            {
                if (i == _numMax)
                {
                    i = _numMin;
                }
                else
                {
                    i++;
                }

                int waitTime = _random.Next(minValue: _rndMin, maxValue: _rndMax);

                _vm.SetSleepingTime(id: _threadNum, text: waitTime.ToString());

                Thread.Sleep(millisecondsTimeout: waitTime * 1000);

                _vm.SetNumberValue(id: _threadNum, text: i.ToString());

                TakenNumberDTO dto = new TakenNumberDTO()
                {
                    PostId = GetTimestamp(value: DateTime.Now),
                    Number = i,
                    DateTaken = DateTime.Now,
                    OfficeId = _officeId,
                    TakenNumberTypeId = _numType
                };

                _vm.SetNumberResult(id: _threadNum, text: "Posted: \n" + dto.toJSON() + "\n", dto: null);

                _takenNumber.Post(_vm, id: _threadNum, dto: dto);
            }

        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString(format: "yyyyMMddHHmmssffff");
        }
    }


}
