using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture, NonParallelizable]
    internal class StringTests
    {
        [Test]
        public void StringBuilderCapacityTest()
        {
            var builder = new StringBuilder();
            
            Assert.AreEqual(16, builder.Capacity);

            for (int i = 1; i < 19; i++)
            {
                var stringToAppend = $"some string number {i % 10}\n";
                builder.Append(stringToAppend);
                var builderCapacity = builder.Capacity;

                var expectedCapacity = Math.Pow(2, Math.Ceiling(Math.Log2(stringToAppend.Length * i)));

                Assert.AreEqual(expectedCapacity, builderCapacity);
            }
        }
    }
}
