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
    internal class Tasks
    {
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(50)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(10000)]
        [TestCase(9000)]
        [TestCase(8000)]
        public void Sale_3for2_test(int countInArray)
        {
            var _products = new (decimal Price, int Quanity)[countInArray];

            var rand = new Random();
            for (int i = 0; i < countInArray; i++)
                _products[i] = ((rand.Next(10, 3000) / 10m, rand.Next(1, 30)));

            var sw = new Stopwatch();

            sw.Start();

            var resLinq = _products.GroupBy(x => x.Price)
                .Aggregate(0m, (sum, nextValue) =>
                {
                    var quantity = nextValue.Sum(n => n.Quanity);
                    var freeProducts = quantity / 3;
                    return sum + (nextValue.Key * (quantity - freeProducts));
                });

            sw.Stop();
            var timeLinq = sw.ElapsedMilliseconds;
            sw.Restart();

            var dict = new Dictionary<decimal, int>();

            foreach (var product in _products)
            {
                if (dict.ContainsKey(product.Price))
                    dict[product.Price] += product.Quanity;
                else
                    dict[product.Price] = product.Quanity;
            }

            var resDict = 0m;

            foreach (var priceWithQuantity in dict)
            {
                var freeProducts = priceWithQuantity.Value / 3;
                resDict += (priceWithQuantity.Key * (priceWithQuantity.Value - freeProducts));
            }

            sw.Stop();
            var timeDict = sw.ElapsedMilliseconds;

            Assert.AreEqual(resDict, resLinq);
            Assert.IsTrue(timeDict <= timeLinq);
        }
    }
}
