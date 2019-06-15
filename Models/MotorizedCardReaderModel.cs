using AutoService.Models.Enums;
using System;

namespace AutoService.Models
{
    public class MotorizedCardReaderModel
    {
        public Guid IdMotorizedCardReaderModel { get; set; }
        public object Connection { get; set; }
        public string Port { get; set; }
        public uint Baut { get; set; }
        public MotorizedCardReaderEnum Type { get; set; }
        public string Name { get; set; }
    }
}
