using AutoService.Models;
using AutoService.Models.Enums;
using System;

namespace AutoService.Framework
{
    public class MotorizedCardReader
    {
        private static IMotorizedCardReader _instance;
        private static readonly object _mutex = new object();

        public static IMotorizedCardReader Instance(MotorizedCardReaderModel motorizedCardReader = null)
        {
            if (_instance == null)
            {
                lock (_mutex)
                {
                    if (motorizedCardReader != null)
                        _instance = InitializeMotorizedCardReader(motorizedCardReader);
                    else
                        throw new Exception("Please, enter a MotorizedCardReader!");
                }
            }

            return _instance;
        }

        private static IMotorizedCardReader InitializeMotorizedCardReader(MotorizedCardReaderModel motorizedCardReader)
        {
            switch (motorizedCardReader.Type)
            {
                case MotorizedCardReaderEnum.MT318V4:
                    _instance = new MotorizedCardReaderMT318V4();
                    _instance.CommOpen(motorizedCardReader);
                    break;
                default:
                    throw new Exception("Device not implemented yet!");
            }

            return _instance;
        }
    }
}
