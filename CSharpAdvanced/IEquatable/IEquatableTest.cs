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

namespace CSharpAdvanced.IEquatable
{
    [TestFixture]
    public class IEquatableTest
    {
        [Test]
        public void givenSameValueTypes_whenEquals_thenValueTypesAreEqual()
        {
            int value1 = 2;
            int value2 = 2;
            Assert.That(value1.Equals(value2));
            Assert.False(Is.ReferenceEquals(value1, value2));
            Assert.That(object.Equals(value1, value2));
        }

        [Test]
        public void givenSameValueTypes_whenEqualityComparer_thenValueTypesAreEqual()
        {
            int value1 = 2;
            int value2 = 2;
            Assert.That(value1 == value2);
            Assert.False(Is.ReferenceEquals(value1, value2));
            Assert.That(object.Equals(value1, value2));
        }

        [Test]
        public void givenSameReferenceTypes_whenEquals_thenValueTypesAreEqual()
        {
            int value1 = 2;
            int value2 = 2;

            object obj1 = value1;
            object obj2 = value2;

            Assert.That(obj1.Equals(obj2));
            Assert.False(ReferenceEquals(obj1, obj2));
            Assert.That(object.Equals(obj1, obj2));
        }

        //NOT EQUAL - REFERENCE TYPES
        [Test]
        public void givenSameReferenceTypes_whenEqualityComparer_thenValueTypesAreNotEqual()
        {
            int value1 = 2;
            int value2 = 2;

            object obj1 = value1;
            object obj2 = value2;

            Assert.That(!(obj1 == obj2));
            Assert.False(Is.ReferenceEquals(obj1, obj2));
            Assert.That(object.Equals(obj1, obj2));
        }

        [Test]
        public void givenSameStringsTypes_whenEquals_thenValueTypesAreEqual()
        {
            string value1 = "2";
            string value2 = "2";
            Assert.That(value1.Equals(value2));
            Assert.That(Is.ReferenceEquals(value1, value2));
            Assert.That(object.Equals(value1, value2));
        }

        [Test]
        public void givenSameStringsTypes_whenEqualityComparer_thenValueTypesAreEqual()
        {
            string value1 = "2";
            string value2 = "2";
            Assert.That(value1 == value2);
            Assert.That(Is.ReferenceEquals(value1, value2));
            Assert.That(object.Equals(value1, value2));
        }
    }
}
