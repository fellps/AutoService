using AutoService.Models.Enums;
using SQLite;
using System;

namespace AutoService.Models
{
    public class MotorizedCardReaderModel
    {
        [PrimaryKey]
        public Guid IdMotorizedCardReader { get; set; }
        public string Port { get; set; }
        public uint Baut { get; set; }
        public MotorizedCardReaderEnum Type { get; set; }
        public string Name { get; set; }

        [Ignore]
        public object Connection { get; set; }
    }
}
