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

namespace ObserverPattern
{
    [TestFixture]
    public class TestsOPwithInterfaces
    {
        [Test]
        public void test()
        {
            NumbersObservable observable = new NumbersObservable();
            NumbersObserver observer1 = new NumbersObserver("BaggageClaimMonitor1");
            NumbersObserver observer2 = new NumbersObserver("SecurityExit");

            observer1.Subscribe(observable);
            observable.changeNumber(1);
            observable.changeNumber(2);
            observable.changeNumber(3);
            observer2.Subscribe(observable);
            observable.changeNumber(4);
            observable.changeNumber(5);

            Assert.AreEqual("12345", observer1.invokeList);
            Assert.AreEqual("45", observer2.invokeList);

        }
    }
}
