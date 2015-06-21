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

namespace CSharpFundamentals.Operators
{
    [TestFixture]
    public class OperatorsExample
    {
        [Test]
        public void CheckNullable()
        {
            int? nullable = null;
            int? nullableWithValue = 4;

            int check1 = nullable ?? 0;
            Assert.That(check1 == 0);

            int check2 = nullableWithValue ?? 0;
            Assert.That(check2 == 4);
        }

        [Test]
        public void CheckValue()
        {
            int value = 0;
            int assignment = value == 0 ? 15 : 25;

            Assert.That(assignment == 15);
        }

        [Test]
        public void moduloTest()
        {
            Assert.That(23%5, Is.EqualTo(3));
        }

        [Test]
        public void shift()
        {
            Assert.That(56 >> 3, Is.EqualTo(7)); //division by 8 = 2^3
            Assert.That(26 << 1, Is.EqualTo(52)); //multiplication by 2 = 2^1
        }

        [Test]
        public void shortOperation()
        {
            int a = 4;
            int b = 5;
            b += a; //b = b + a

            Assert.That(b == 9);
        }
    }
}