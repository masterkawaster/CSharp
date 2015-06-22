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
    [Category("ArgsModifiers")]
    public class ArgsModifiersTest
    {
        private int _validInt1 = 1;
        private int _validInt2 = 5;

        private void namedArgumentsMethod(int arg1, int arg2)
        {
            Assert.That(arg1, Is.EqualTo(_validInt1));
            Assert.That(arg2, Is.EqualTo(_validInt2));
        }

        private void outArgumentsMethod(out int arg1)
        {
            arg1 = 10;
        }

        private void refArgumentsMethod(string arg1, ref string arg2)
        {
            arg1 = "new value 1";
            arg2 = "new value 2";
        }

        [Test]
        public void GivenMethodWithArgs_WhenPassingArguments_thenUseNamedArgs()
        {
            namedArgumentsMethod(arg2: _validInt2, arg1: _validInt1);
        }

        [Test]
        public void GivenUninitialisedVariable_WhenPassingAsOutArg_ThenExpectInitialised()
        {
            int outArg;
            outArgumentsMethod(out outArg);

            Assert.That(outArg, Is.EqualTo(10));
        }

        [Test]
        public void GivenInitialisedVariables_WhenPassingByRef_ThenExpectModifiedReference()
        {
            var copyByValue = "old string 1";
            var copyByReference = "old string 2";//must be initialised first
            refArgumentsMethod(copyByValue, ref copyByReference); //you need to have named variable with ref keyword

            Assert.That(copyByValue, Is.EqualTo("old string 1"));
            Assert.That(copyByReference, Is.EqualTo("new value 2"));
        }
    }
}