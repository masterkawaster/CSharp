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
    public class Linq
    {
        [Test]
        public void TestSimpleLambdaExpression()
        {
            var list = new List<string> { "Ford", "Opel" };
            var query = from c in list select c;

            Assert.That(query.Last() == "Opel");
        }

        [Test]
        public void givenQuery_whenModifingListAndExecutingTwoTimes_thenGetTwoDifferentResults()
        {
            var list = new List<string> { "Ford", "Opel" };
            var query = from c in list select c;

            list.Add("Renault");

            Assert.That(query.Last() == "Renault");
        }

        [Test]
        public void givenQuery_whenExecutingTwoTimesAndAssigningItToVariable_thenGetTwoDifferentResults()
        {
            var list = new List<string> { "Ford", "Opel" };
            var query = from c in list select c;

            var variable = query.Last();
            Assert.That(variable == "Opel");

            list.Add("Renault");

            Assert.That(query.Last() == "Renault");
            Assert.That(variable == "Opel");
        }

        [Test]
        public void GettingSingleElement()
        {
            var list = new List<string> { "Ford", "Opel" };
            var query = from c in list select c;

            Assert.That(query.Last() == "Opel");
        }
    }
}
