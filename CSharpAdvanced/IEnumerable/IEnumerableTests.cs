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

namespace IEnumerableExample
{
    [TestFixture]
    public class IEnumerableTests
    {
        [Test]
        public void givenTeam_whenForeach_IterateThroughPlayers()
        {
            var team = new Team();

            for (int i = 0; i < 12; i++)
            {
                team.AddPlayer(string.Format("p{0}", i), i);
            }

            string enumerableCheck = string.Empty;

            foreach (var player in team)
            {
                enumerableCheck += player;
            }

            Assert.That(enumerableCheck, Is.EqualTo("p0p1p2p3p4p5p6p7p8p9p10p11"));
        }

        [Test]
        public void givenBetterTeam_whenForeach_thenEnumerateByFirstlyEvenThenOdd()
        {
            var enumerableCheck = string.Empty;

            var betterTeam = new BetterTeam();

            for (int i = 0; i < 12; i++)
            {
                betterTeam.AddPlayer(string.Format("p{0}", i), i);
            }

            foreach (var player in betterTeam)
            {
                enumerableCheck += player;
            }

            Assert.That(enumerableCheck, Is.EqualTo("p0p2p4p6p8p10p1p3p5p7p9p11"));

        }

        [Test]
        public void givenMuchBetterTeam_whenForeach_thenEnumerateInReverseOrder()
        {
            var enumerableCheck = string.Empty;

            var muchBetterTeam = new MuchBetterTeam();

            for (int i = 0; i < 12; i++)
            {
                muchBetterTeam.AddPlayer(string.Format("p{0}", i), i);
            }

            foreach (var player in muchBetterTeam.GetPlayersReversed())
            {
                enumerableCheck += player;
            }

            Assert.That(enumerableCheck, Is.EqualTo("p11p10p9p8p7p6p5p4p3p2p1p0"));
        }
    }
}
