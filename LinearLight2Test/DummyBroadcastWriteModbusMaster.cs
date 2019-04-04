﻿using System;
using LinearLight2;
using NUnit.Framework;

namespace LinearLight2Test
{
    internal class DummyBroadcastWriteModbusMaster : IModbusMaster
    {
        private readonly ushort[] setRegister;
        private readonly ushort[] expectedIntensity;
        private int i;

        public DummyBroadcastWriteModbusMaster(ushort[] setRegister, ushort[] expectedIntensity)
        {
            this.setRegister = setRegister;
            this.expectedIntensity = expectedIntensity;
        }
        public void BroadcastWriteSingleRegister(ushort registerAddress, ushort value)
        {
            Assert.Multiple(() =>
                            {
                                Assert.AreEqual(expectedIntensity[i], value);
                                Assert.AreEqual(setRegister[i++], registerAddress);
                            });
        }

        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            throw new NotImplementedException();
        }

        public bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            throw new NotImplementedException();
        }

        public void BroadcastWriteSingleCoil(ushort coilAddress, bool value)
        {
            throw new NotImplementedException();
        }
    }
}