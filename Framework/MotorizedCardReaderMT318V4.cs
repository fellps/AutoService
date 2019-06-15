using AutoService.Models;
using System;
using System.Runtime.InteropServices;

namespace AutoService.Framework
{
    public class MotorizedCardReaderMT318V4 : IMotorizedCardReader
    {
        public IntPtr ComHandle;

        [DllImport(@"D:\ModuleV30.dll", EntryPoint = "CommOpenWithBaut", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CommOpenWithBaut(string port, uint data = 9600);

        [DllImport(@"D:\ModuleV30.dll", EntryPoint = "CommClose", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CommClose(IntPtr comHandle);

        [DllImport(@"D:\ModuleV30.dll", EntryPoint = "CRT_R_SetComm", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int CRT_R_SetComm(IntPtr comHandle, int data = 9600);

        [DllImport(@"D:\ModuleV30.dll", EntryPoint = "CRT310_MovePosition", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int CRT310_MovePosition(IntPtr comHandle, byte position);

        public object CommOpen(Models.MotorizedCardReaderModel motorizedCardReader)
        {
            ComHandle = CommOpenWithBaut(motorizedCardReader.Port, motorizedCardReader.Baut);
            if (ComHandle.ToInt32() == 0)
                throw new Exception("Cannot connect to device");
            return ComHandle;
        }

        public void CommClose()
        {
            CommClose(ComHandle);
        }

        public void SetComm(int data = 9600)
        {
            int status = CRT_R_SetComm(ComHandle, data);

            if (status != 0)
                throw new Exception("Cannot update baut!");
        }

        public void MovePosition(byte position)
        {
            int status = CRT310_MovePosition(ComHandle, position);

            if (status != 0)
                throw new Exception("Cannot move card!");
        }
    }
}
