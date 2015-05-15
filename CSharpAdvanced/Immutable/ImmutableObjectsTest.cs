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

namespace CSharpAdvanced.Immutable
{
    [TestFixture]
    public class ImmutableObjectsTest
    {
        [Test]
        public void ImmutableTest()
        {
            var ticket = new Ticket("Michael");
            var newTicket = ticket.ChangeTicketOwner("Scottie");

            Assert.That(ticket.Name, Is.EqualTo("Michael"));

            string testString = "Michael".Replace('a', 'e');

            var list = new List<int> { 2, 3, 7 };

            Assert.That(newTicket.Name, Is.EqualTo("Scottie"));
            Assert.That(newTicket.Signature, Is.Not.EqualTo(ticket.Signature));
        }
    }

    public class Ticket
    {
        private Guid signature;

        public Ticket(string name)
        {
            Name = name;
            signature = Guid.NewGuid();
        }

        public Ticket ChangeTicketOwner(string name)
        {
            return new Ticket(name);
        }

        public Guid Signature { get { return signature; } }

        public string Name { get; private set; }
    }

    public class TicketManager
    {
        public void ChangeTicketOwner(Ticket ticket, string newName)
        {
            var newTicket = ticket.ChangeTicketOwner("newOwner");
            DeactivateTicketInDatabase(ticket);
            SaveTicketToDatabase(newTicket);

            SendConfirmationToTicketOwner(newTicket);
        }

        private void SaveTicketToDatabase(Ticket NewTicket) { }
        private void DeactivateTicketInDatabase(Ticket ticket) { }
        private void SendConfirmationToTicketOwner(Ticket ticket) { }
    }
}
