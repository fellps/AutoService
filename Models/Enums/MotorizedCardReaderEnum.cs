using System;
using System.ComponentModel;

namespace AutoService.Models.Enums
{
    [Flags]
    public enum MotorizedCardReaderEnum : byte
    {
        [Description("MT318V4")]
        MT318V4 = 0x01
    }
}
