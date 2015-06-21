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

namespace CSharpFundamentals.ArgsModifiers
{
    [TestFixture]
    public class ArgsModifiersTest
    {
        private void namedArgumentsMethod(int arg1, int arg2)
        {
        }

        private void refArgumentsMethod(int arg1, ref int arg2)
        {
            arg1 = 11;
            arg2 = 10;
        }

        private void outArgumentsMethod(out int arg1)
        {
            arg1 = 10;
        }

        [Test]
        public void NamedArguments()
        {
            namedArgumentsMethod(arg2: 1, arg1: 5);
        }

        [Test]
        public void OutArguments()
        {
            int outArg;
            outArgumentsMethod(out outArg);

            Assert.That(outArg, Is.EqualTo(10));
        }

        [Test]
        public void RefArguments()
        {
            int copyByValue = 1;
            int copyByReference = 5;
            refArgumentsMethod(copyByValue, ref copyByReference); //you need to have named variable with ref keyword

            Assert.That(copyByValue, Is.EqualTo(1));
            Assert.That(copyByReference, Is.EqualTo(10));
        }
    }
}