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
using System.Linq;

[TestFixture]
public class Program
{
    [Test]
    public void givenTwoObjectsWithWronglyGetHashCode_whenGettingCountElements_CountsWrong()
    {
        // first and second are logically equivalent
        var first = new SimpleTableRow<int>(1, 2, 3, 4, 5, 6);

        var second = new SimpleTableRow<int>(1, 2, 3, 4, 5, 6);

        if (first.Equals(second) && first.GetHashCode() != second.GetHashCode())
        {
            Console.WriteLine("We have a problem");
        }
        HashSet<SimpleTableRow<int>> set = new HashSet<SimpleTableRow<int>>();
        set.Add(first);
        set.Add(second);
        Assert.That(set.Count == 1); // change hash implementation so that this fails

        var list = new List<SimpleTableRow<int>>();
        list.Add(first);
        list.Add(second);
        Assert.That(list.Count == 2); // no matter what hash algorithm is 
    }

    class SimpleTableRow<T> : IEquatable<SimpleTableRow<T>>
    {

        public SimpleTableRow(int id, params T[] values)
        {
            this.Id = id;
            this.Values = values;
        }
        public int Id { get; private set; }
        public T[] Values { get; private set; }

        //public override int GetHashCode() // wrong
        //{
        //    return Id.GetHashCode() ^ Values.GetHashCode();
        //}

        public override int GetHashCode() // right
        {
            int hash = Id;
            if (Values != null)
            {
                hash = (hash * 17) + Values.Length;
                foreach (T t in Values)
                {
                    hash *= 17;
                    if (t != null) hash = hash + t.GetHashCode();
                }
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimpleTableRow<T>);
        }
        public bool Equals(SimpleTableRow<T> other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Check for same Id and same Values
            return Id == other.Id && Values.SequenceEqual(other.Values);
        }
    }
}