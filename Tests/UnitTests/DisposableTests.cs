using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    internal class DisposableTests
    {
        [Test]
        public void DisposeClass()
        {
            var c1 = new TestClass();
            using (c1)
            {
                Assert.IsFalse(c1.GetDisposeState());
            }
            Assert.IsTrue(c1.GetDisposeState());
        }

        [Test]
        public async Task AsyncDisposeClass()
        {
            var c1 = new AsyncTestClass();
            await using (c1)
            {
                Assert.IsFalse(c1.GetDisposeState());
            }
            Assert.IsTrue(c1.GetDisposeState());
        }
        [Test]
        public void DisposeStruct()
        {
            var c1 = new TestStruct();
            using (c1)
            {
                Assert.IsFalse(c1.GetDisposeState());
            }
            Assert.IsFalse(c1.GetDisposeState());
        }

        [Test]
        public async Task AsyncDisposeStruct()
        {
            var c1 = new AsyncTestStruct();
            await using (c1)
            {
                Assert.IsFalse(c1.GetDisposeState());
            }
            Assert.IsFalse(c1.GetDisposeState());
        }

        public struct TestStruct : IDisposable
        {
            private bool _disposed;
            public bool GetDisposeState() => _disposed;
            public void Dispose()
            {
                _disposed = true;
            }
        }

        public class TestClass : IDisposable
        {
            private bool _disposed;
            public bool GetDisposeState() => _disposed;
            public void Dispose()
            {
                _disposed = true;
            }
        }

        public class AsyncTestClass : IAsyncDisposable
        {
            private bool _disposed;
            public bool GetDisposeState() => _disposed;
            public async ValueTask DisposeAsync()
            {
                // Async cleanup mock
                await Task.Yield();
                _disposed = true;
            }
        }

        public struct AsyncTestStruct : IAsyncDisposable
        {
            private bool _disposed;

            public bool GetDisposeState() => _disposed;
            public async ValueTask DisposeAsync()
            {
                // Async cleanup mock
                await Task.Yield();
                _disposed = true;
            }
        }
    }
}
