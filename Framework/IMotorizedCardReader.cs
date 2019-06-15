using AutoService.Models;

namespace AutoService.Framework
{
    public interface IMotorizedCardReader
    {
        object CommOpen(Models.MotorizedCardReaderModel motorizedCardReader);
        void CommClose();
        void SetComm(int data = 9600);
        void MovePosition(byte position);
    }
}