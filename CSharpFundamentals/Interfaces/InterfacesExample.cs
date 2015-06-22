// ************************************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2015 Marek Kawa (masterkawaster)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// ************************************************************************************************

using NUnit.Framework;

namespace CSharpFundamentals.Interfaces
{
    [TestFixture]
    [Category("Interfaces")]
    public class InterfacesExample
    {
        public class Animal : IRunable, IDangerous
        {
            public bool IsDangerous { get; set; }
            public int MilesPerHour { get; set; }
        }

        private interface IDangerous
        {
            bool IsDangerous { get; set; }
        }

        private interface IRunable
        {
            int MilesPerHour { get; set; }
        }

        [Test]
        public void InterfaceSegregationTest()
        {
            var animal = new Animal { MilesPerHour = 10, IsDangerous = true };

            IDangerous dangerous = animal;
            IRunable runable = animal;

            Assert.That(runable.MilesPerHour, Is.EqualTo(10));
            Assert.That(dangerous.IsDangerous, Is.True);
        }
    }
}