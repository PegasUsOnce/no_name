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
        public void SameStringsTest()
        {
            // Строковые литералы и константы сцепляются во время компиляции, а не во время выполнения.
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Assert.IsTrue(s1 == s2);
            Assert.IsFalse((object)s1 == (object)s2);
            Assert.IsTrue(s2 == s3);
            Assert.IsTrue((object)s2 == (object)s3);

            string userName = "<Type your name here>";
            string dateString = DateTime.Today.ToShortDateString();

            // Use the + and += operators for one-time concatenations.
            string str1 = "Hello " + userName + ". Today is " + dateString + ".";
            string str2 = $"Hello {userName}. Today is {dateString}.";

            Assert.IsTrue(str1 == str2);
            Assert.IsFalse((object)str1 == (object)str2);
        }

        [Test]
        public void StringBuilderCapacityTest()
        {
            // Размер массива char увеличивается вдвое при превышении
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
