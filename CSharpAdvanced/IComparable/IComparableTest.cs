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

namespace CSharpAdvanced.IComparableTest
{
    [TestFixture]
    public class IComparableTest
    {
        [Test]
        public void givenTwoAnimals_ComparableTest()
        {
            var elephant = new Animal("Elephant", 10000);
            var mouse = new Animal("Mouse", 1);
            Assert.That(7, Is.GreaterThan(3));

            Assert.That(elephant as IComparable, Is.GreaterThan(mouse as IComparable));
            Assert.That(mouse, Is.LessThan(elephant));

            Assert.That(elephant.CompareTo(mouse) == 1);

            Assert.That(mouse.CompareTo(elephant) == -1);

        }
        [Test]
        public void givenTwoAnimals_whenCompareTest()
        {
            var mouse = new Animal("Mouse", 1);
            var mouseTwin = new Animal("Mouse", 1);
            Assert.That(mouse.CompareTo(mouseTwin) == 0);
        }

        [Test]
        public void givenAnimalsSet_checkSortingSetFunctionality()
        {
            var mouse = new Animal("mouse", 1);
            var dog = new Animal("dog", 100);
            var elephant = new Animal("elephant", 100000);

            var sortedSet = new SortedSet<Animal>();
            sortedSet.Add(dog);
            sortedSet.Add(elephant);
            sortedSet.Add(mouse);

            Assert.That(sortedSet, Is.EquivalentTo(new[] { mouse, dog, elephant }));
        }
    }
}
