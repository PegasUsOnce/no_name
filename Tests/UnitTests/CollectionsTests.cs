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
    internal class CollectionsTests
    {
        class TestClass
        {
            public int ValueInt { get; set; }
            public string ValueString { get; set; }
        }

        public void HasSetTest()
        {
            var mas = new int[1000];
            var x = new HashSet<TestClass>(1000);

            for (int i = 0; i < 1000; i++)
            {
                var value = 2 * i + (-45 + 75 * i * i) + 4 * (i + 13);
                mas[i] = value;
                x.Add(value);
            }

            var sw = new Stopwatch();
        }
    }
}
