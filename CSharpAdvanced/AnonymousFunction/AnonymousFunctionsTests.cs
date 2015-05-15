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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFunctions
{
    [TestFixture]
    public class AnonymousFunctionsTest
    {
        delegate int CalcNumber(int x, int y);

        [Test]
        public void AnonymousFunctions()
        {
            Assert.That(() => { return 4; }, Is.EqualTo(4));
        }

        [Test]
        public void InvokeManyTimes()
        {
            Func<int> calculateNumber = () => { return 4; };
            Assert.That(calculateNumber(), Is.EqualTo(4));
            Assert.That(calculateNumber() * 2, Is.EqualTo(8));
        }

        [Test]
        public void WithArguments()
        {
            CalcNumber calculateNumber = (x, y) => { return x * y; };
            Assert.That(calculateNumber(2, 3), Is.EqualTo(6));
            Assert.That(calculateNumber(7, 8), Is.EqualTo(56));
        }

        [Test]
        public void voidDelegateTest()
        {
            int number = 2;
            Action changeNumber = () => number = 4;
            changeNumber();
            Assert.That(number, Is.EqualTo(4));
        }
    }
}
