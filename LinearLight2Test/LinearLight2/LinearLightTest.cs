using System.Linq;
using LinearLight2;
using NUnit.Framework;

namespace LinearLight2Test.LinearLight2
{
    [TestFixture]
    public class LinearLightTest
    {
        [Test]
        public void SetIntensityTest()
        {
            ushort expectedIntensity = 15;
            var master = new DummyBroadcastWriteModbusMaster(new ushort[]{4000-1, 4001 - 1}, new[]{expectedIntensity, expectedIntensity});
            var linearLight = new LinearLight(master, 0);
            linearLight.Intensity = expectedIntensity;
        }

        [Test]
        public void SetFanSpeedTest()
        {
            ushort setSpeed = 50;
            var master = new DummyBroadcastWriteModbusMaster(new ushort[] { 4002 - 1 }, new[] { setSpeed});
            var linearLight = new LinearLight(master, 0);
            linearLight.FanSpeed = setSpeed;
        }

        [Test]
        public void ReadIntensities1Test()
        {
            var addresses = new byte[] {1, 2, 3};
            var startAddresses = new ushort[] {4000 - 1, 4000 - 1, 4000 - 1,};
            var lengths = new ushort[] {1, 1, 1};
            var intensities = new ushort[] {30, 54, 15};
            var returnVals = intensities.Select(x => new[] {x}).ToArray();

            var master = new DummyReadRegistersModbusMaster(addresses, startAddresses, lengths, returnVals);
            var lili = new LinearLight(master,addresses.Length);
            CollectionAssert.AreEqual(intensities, lili.SetIntensities1);
        }
        [Test]
        public void ReadIntensities2Test()
        {
            var addresses = new byte[] { 1, 2, 3 };
            var startAddresses = new ushort[] { 4001 - 1, 4001 - 1, 4001 - 1, };
            var lengths = new ushort[] { 1, 1, 1 };
            var intensities = new ushort[] { 30, 54, 15 };
            var returnVals = intensities.Select(x => new[] { x }).ToArray();

            var master = new DummyReadRegistersModbusMaster(addresses, startAddresses, lengths, returnVals);
            var lili = new LinearLight(master, addresses.Length);
            CollectionAssert.AreEqual(intensities, lili.SetIntensities2);
        }

        [Test]
        public void ReadFanEnablesTest()
        {
            var addresses = new byte[] {1, 2, 3};
            var startAddresses = new ushort[] { 1001 - 1, 1001 - 1, 1001 - 1, };
            var lengths = new ushort[] { 1, 1, 1 };
            var values = new[] { false, false, true };
            var returnVals = values.Select(x => new[] { x }).ToArray();

            var master = new DummyReadCoilsModbusMaster(addresses, startAddresses, lengths, returnVals);
            var lili = new LinearLight(master, addresses.Length);
            CollectionAssert.AreEqual(values,lili.FanEnables);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SetFanEnableTest(bool value)
        {
            var master = new DummyBroadcastWriteCoilModbusMaster(new ushort[] {1001 - 1}, new[] {value});
            var lili = new LinearLight(master, 0);
            lili.FanEnable = value;
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SetSwTriggerTest(bool value)
        {
            var master = new DummyBroadcastWriteCoilModbusMaster(new ushort[] { 1000 - 1 }, new[] { value });
            var lili = new LinearLight(master, 0);
            lili.SwTrigger = value;
        }


    }
}