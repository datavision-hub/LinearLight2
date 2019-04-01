﻿namespace LinearLight2.NModbus.NModbusExtension
{
    public static class ModbusSerialMasterExtensions
    {
        public static void BroadcastWriteSingleRegister(this global::NModbus.IModbusMaster master, ushort addr, ushort value)
        {
            master.Transport.Write(new BroadcastWriteRegisterMessage(addr, value));
        }
    }
}
