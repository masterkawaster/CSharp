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
using System.Linq;

namespace CSharpAdvanced.LinqLambda
{
    [TestFixture]
    public class Lambda
    {
        [Test]
        public void TestSimpleLambdaExpression()
        {
            var list = new List<string> { "Ford", "Opel" };
            var query = list.Where(item => item == "Ford");

            Assert.That(query.Last() == "Ford");

            var list2 = new List<string>();

            foreach (var item in list)
                list2.Add(item);

            list.ForEach(item => list2.Add(item));
        }

        [Test]
        public void givenQuery_whenModifingListAndExecutingTwoTimes_thenGetTwoDifferentResults()
        {
            var list = new List<string> { "Ford", "Opel", "Mazda", "Suzuki" };
            var query = list.Where(item => item.Contains('o'));

            Assert.That(query.ToList().Count == 1);
        }

    }
}
