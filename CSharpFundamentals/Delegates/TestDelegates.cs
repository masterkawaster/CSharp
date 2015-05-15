using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Delegates
{
    [TestFixture]
    public class TestDelegates
    {
        [Test]
        public void delegatesTest()
        {
            Func<string, int> delegateFunc;
            delegateFunc = method;

            Assert.That(delegateFunc("4"), Is.EqualTo(4));

            Action delegateNoArgs = methodAction;

            Action<int> delegateAction = null;

            delegateAction += methodAction;
            delegateAction += methodAction;
            delegateAction += methodAction;

            delegateAction(4);
            Assert.That(invokeList, Is.EqualTo("iii"));

            Predicate<int> delegatePredicate;
            delegatePredicate = methodPredicate;

            Assert.That(delegatePredicate(4));

        }

        public int method(string a)
        {
            return 4;
        }

        public void methodAction(int a)
        {
            invokeList += "i";
        }

        public void methodAction()
        {
            invokeList += "i";
        }

        public bool methodPredicate(int a)
        {
            return true; //np. porównanie
        }

        static string invokeList = string.Empty;


    }
}
