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
using System.Collections.Generic;

namespace CSharpAdvanced.IEquatable
{
    [TestFixture]
    public class IEquatableCollectionsNamespaceTest
    {
        [Test]
        public void FindObjectWithoutEquatableAndGetHashCode()
        {
            var car1 = new Auto("Mustang");
            var car2 = new Auto("Mustang");

            var list = new List<Auto> { car1 };
            foreach (var item in list)
            {
                //CANNOT FIND THIS OBJECT
                Assert.That(findObjectEquality(car2, item) == false);
            }
        }

        [Test]
        public void FindObjectWithEquatableAndGetHashCode()
        {
            var car1 = new AutoWithOverrides("Mustang");
            var car2 = new AutoWithOverrides("Mustang");

            //car1.name == car2.name;

            var list = new List<AutoWithOverrides> { car1 };
            foreach (var item in list)
            {
                Assert.That(findObjectEquality<AutoWithOverrides>(car2, item));
            }
        }

        private bool findObjectEquality<T>(T car2, T item) where T : class
        {
            return car2 == item || item.Equals(car2);
        }
    }
}
