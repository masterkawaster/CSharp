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

namespace CSharpFundamentals.SwitchCase
{
    [TestFixture]
    [Category("SwitchCase")]
    public class SwitchCaseTest
    {
        public class Car
        {
            public string Name { get; set; }
        }

        [Test]
        public void SwitchCaseWithObjects()
        {
            int number = 0;
            var auto = new Car { Name = "Opel" };
            switch (auto.Name)
            {
                case "Opel":
                    number = 1;
                    break;
                case "Ford":
                    number = 2;
                    break;
                case "Renault":
                    number = 3;
                    break;
            }
            Assert.That(number, Is.EqualTo(1));
        }

        [Test]
        public void SwitchCaseWithoutBreakTest()
        {
            int number = 0;
            string switchArg = "arg";
            switch (switchArg)
            {
                case "first":
                    number = 1;
                    break;
                case "arg":
                    number = 2;
                    break;
                case "third":
                    number = 3;
                    break;
            }
            Assert.That(number, Is.EqualTo(2));
        }
    }
}