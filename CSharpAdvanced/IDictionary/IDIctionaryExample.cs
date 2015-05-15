﻿using NUnit.Framework;
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
using System.Collections.Generic;

namespace IDictionary
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void DictionaryTest()
        {
            var animals = new Dictionary<int, Animal>
                {
                    { 0, new Animal {Name="Mouse"}},
                    { 1, new Animal {Name="Elephant"}},
                };

            Assert.That(animals[0].Name, Is.EqualTo("Mouse"));

        }
    }

    public class Animal
    {
        public string Name { get; set; }
    }


}
