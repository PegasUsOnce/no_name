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
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(9000)]
        [TestCase(8000)]
        public void Sale_3for2_test(int countInArray)
        {
            var products = new (decimal Price, int Quanity)[countInArray];

            var rand = new Random();
            for (int i = 0; i < countInArray; i++)
                products[i] = ((rand.Next(10, 10000) / 10m, rand.Next(1, 30)));

            var sw = new Stopwatch();

            sw.Start();

            var resLinq = products.GroupBy(x => x.Price)
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

            foreach (var product in products)
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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(resDict, resLinq);
                Assert.IsTrue(timeDict <= timeLinq);
                Assert.AreEqual(timeDict, timeLinq, "Время выполнения");

                Assert.LessOrEqual(0, products.Length - products.GroupBy(x => x.Price).Count(), "Количество повторяющихся значений");
            });
        }
    }
}
