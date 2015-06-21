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

using System;
using NUnit.Framework;

namespace Using
{
    [TestFixture]
    public class DisposeExampleTest
    {
        [Test]
        public void givenTryCatch_whenExecutingMethod_valueIsAssignedAfterFinallyBlock()
        {
            var dispose = new DisposeExample();
            int valueAfterFinally = 3;
            Assert.AreEqual(valueAfterFinally, dispose.whenThrowingInTry_thenCodeAfterFinallyIsReachable());
        }

        [Test]
        public void givenTryCatch_whenExecutingMethod_valueIsAssignedInFinallyBlock_SecondCase()
        {
            var dispose = new DisposeExample();
            int objectState = 1;
            dispose.whenReturningInCatch_thenCodeAfterFinallyIsUnreachable();
            Assert.AreEqual(objectState, dispose.ObjectState);
        }

        [Test]
        public void givenTryCatch_whenExecutingMethod_valueIsAssignedInFinallyBlock_oneCase()
        {
            var dispose = new DisposeExample();
            int objectState = 1;
            Assert.Catch<Exception>(() => dispose.whenThrowInCatch_thenCodeAfterFinallyIsUnreachable());

            Assert.AreEqual(objectState, dispose.ObjectState);
        }
    }
}