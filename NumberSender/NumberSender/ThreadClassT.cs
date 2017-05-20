using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberSender
{
    public class ThreadClassT
    {
        private readonly TakenNumberController _takenNumber = new TakenNumberController();

        private readonly Random _random = new Random();

        private readonly int _threadNum;
        private readonly int _rndMin;
        private readonly int _rndMax;
        private readonly MainWindowVM _vm;
        public ThreadClassT(MainWindowVM vm, int threadNum, int rndMin, int rndMax)
        {
            _rndMin = rndMin * 1000;
            _rndMax = rndMax * 1000;
            _vm = vm;
            _threadNum = threadNum;
        }

        public void PostNumber()
        {
            while (true)
            {
                //TODO

                int waitTime = 1000;

                if (
                    (_threadNum == 1 && _vm.Thread1Dtos.Count > 0) ||
                    (_threadNum == 2 && _vm.Thread2Dtos.Count > 0) ||
                    (_threadNum == 3 && _vm.Thread3Dtos.Count > 0)
                    )
                {
                    waitTime = _random.Next(minValue: _rndMin, maxValue: _rndMax);
                    _vm.SetSleepingTimeT(id: _threadNum, text: waitTime.ToString());
                    Thread.Sleep(millisecondsTimeout: waitTime);

                    TakenNumberDTO dto = null;
                    switch (_threadNum)
                    {
                        case 1:
                            dto = _vm.Thread1Dtos[index: 0];
                            break;
                        case 2:
                            dto = _vm.Thread2Dtos[index: 0];
                            break;
                        case 3:
                            dto = _vm.Thread3Dtos[index: 0];
                            break;
                    }

                    dto.DateService = DateTime.Now;
                    string dtoJSON = dto.toJSON();

                    switch (_threadNum)
                    {
                        case 1:
                            _vm.Thread1Dtos.Remove(item: dto);
                            break;
                        case 2:
                            _vm.Thread2Dtos.Remove(item: dto);
                            break;
                        case 3:
                            _vm.Thread3Dtos.Remove(item: dto);
                            break;
                    }

                    _vm.SetNumberValueT(id: _threadNum, text: dto.Number.ToString());
                    _vm.SetNumberResult(id: _threadNum, text: "Posted update: \n" + dto.toJSON() + "\n", dto: null);

                    _takenNumber.Put(_vm, id: _threadNum, json: dtoJSON);
                }
                else
                {
                    _vm.SetSleepingTimeT(id: _threadNum, text: waitTime.ToString());

                    Thread.Sleep(millisecondsTimeout: waitTime);
                }

                
            }

        }

        
    }
}
