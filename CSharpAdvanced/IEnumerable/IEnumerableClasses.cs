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
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableExample
{
    public class Team : IEnumerable
    {
        private string[] players = new string[12];

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return players.GetEnumerator();
        }

        public void AddPlayer(string playerName, int position)
        {
            players[position] = playerName;
        }
    }

    public class BetterTeam : IEnumerable<string>
    {
        private string[] players = new string[12];


        public IEnumerator<string> GetEnumerator()
        {
            yield return (string)GetEnumerator().Current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return players.GetEnumerator();
        }

        public void AddPlayer(string playerName, int position)
        {
            players[position] = playerName;
        }
    }

    public class MuchBetterTeam : IEnumerable<string>
    {
        private string[] players = new string[12];


        public IEnumerator<string> GetEnumerator()
        {
            yield return players[0];
        }

        public IEnumerable GetPlayersReversed()
        {
            yield return players[11];
            yield return players[10];
            yield return players[9];
            yield return players[8];
            yield return players[7];
            yield return players[6];
            yield return players[5];
            yield return players[4];
            yield return players[3];
            yield return players[2];
            yield return players[1];
            yield return players[0];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return players.GetEnumerator();
        }

        public void AddPlayer(string playerName, int position)
        {
            players[position] = playerName;
        }
    }
}
