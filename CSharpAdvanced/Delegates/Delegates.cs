using NUnit.Framework;
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
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced.Delegates
{
    [TestFixture]
    public class MostCommonDelegates
    {
        [Test]
        public void ActionExample()
        {
            var players = new List<string> { "player1", "player2" };

            var announcement = string.Empty;

            players.ForEach(player => announcement += player + " ");

            Action<string> addGame = (string player) =>
            {
                announcement += player + " ";
            };

            players.ForEach(addGame);
            Assert.That(announcement, Is.EqualTo("player1 player2 player1 player2 "));

        }

        [Test]
        public void FuncExample()
        {
            var players = new List<string> { "player1", "player2" };

            var queryFilter = players.Where(x => x.Length == 7);

            Assert.That(queryFilter.Count(), Is.EqualTo(2));

            Func<string, bool> addGameFunc = (string player) =>
            {
                return player.Length == 7;
            };

            queryFilter = players.Where(addGameFunc);

            Assert.That(queryFilter.Count(), Is.EqualTo(2));


            Predicate<string> addGamePredicate = (string player) =>
            {
                return player.Length == 7;
            };
        }

        [Test]
        public void givenMethod_whenExecutingBuiltWrapper_thenAddLogging()
        {
            string logs = string.Empty;

            Action testMethodWithLogging = () =>
            {
                logs += "Before executing testMethod";
                testMethod();
                logs += "After executing testMethod";
            };

            testMethodWithLogging();

            Assert.That(logs, Is.EqualTo("Before executing testMethodAfter executing testMethod"));
        }

        private void testMethod()
        {

        }
    }
}
