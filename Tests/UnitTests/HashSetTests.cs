using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    internal class HashSetTests
    {
        private class TestClass
        {
            private int _hash;
            public int Value { get; set; }

            public TestClass(int value, int hash)
            {
                Value = value;
                _hash = hash;
            }

            public override bool Equals(object? obj)
            {
                return Value.Equals(obj);
            }

            public override int GetHashCode()
            {
                return _hash;
            }
        }

        [Test]
        public void HasSet_Duplicates_Test()
        {
            var item1 = new TestClass(1, 133);
            var item2 = new TestClass(2, 133);
            var item3 = new TestClass(1, 111);
            var item4 = new TestClass(1, 111);

            var hashset = new HashSet<TestClass>
            {
                item1, item2, item3
            };

            Assert.AreEqual(3, hashset.Count);
        }
    }
}
