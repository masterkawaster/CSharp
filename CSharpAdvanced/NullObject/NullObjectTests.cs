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

namespace CSharpAdvanced.NullObject
{
    [TestFixture]
    public class NullObjectTests
    {
        AnimalManager animalManager;

        [SetUp]
        public void SetUp()
        {
            animalManager = new AnimalManager();
        }

        [Test]
        public void getSoundFromBigDog()
        {
            var dog = animalManager.CreateAnimal(7);
            Assert.That(dog.MakeSound(), Is.EqualTo("wow wow"));
        }

        [Test]
        public void getSoundFromSmallDog()
        {
            var dog = animalManager.CreateAnimal(1);
            Assert.That(dog.MakeSound(), Is.EqualTo("how how"));
        }

        [Test]
        public void ProvideWrongWeightForDog()
        {
            var dog = animalManager.CreateAnimal(17777);
            Assert.That(dog.MakeSound(), Is.EqualTo(null));

            dog = animalManager.CreateAnimal(-17);
            Assert.That(dog.MakeSound(), Is.EqualTo(null));
        }
    }

    public interface IAnimal
    {
        int Weight { get; set; }
        string MakeSound();
    }

    public class Dog : IAnimal
    {
        private string _animalSound;
        public Dog(string animalSound)
        {
            this._animalSound = animalSound;
        }

        public int Weight
        {
            get;
            set;
        }

        public string MakeSound()
        {
            return _animalSound;
        }
    }

    public class NullDog : IAnimal
    {
        public int Weight
        {
            get { return 0; }
            set { }
        }

        public string MakeSound()
        {
            return null; //return "Wrong weight provided";
        }
    }

    public class AnimalManager
    {
        public IAnimal CreateAnimal(int weight)
        {
            if (weight < 3 && weight > 0)
                return new Dog("how how");
            else if (weight > 3 && weight < 10)
                return new Dog("wow wow");
            else
                return new NullDog();

        }
    }
}
