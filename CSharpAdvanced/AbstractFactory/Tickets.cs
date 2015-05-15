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

namespace CSharpAdvanced.AbstractFactory
{
    public class NormalTicket : IStampable
    {
        public NormalTicket(int priceInCents)
        {
            this.PriceInCents = priceInCents;
        }

        public void Stamp()
        {
            IsStamped = true;
        }

        public bool IsStamped
        {
            get;
            private set;
        }

        public int PriceInCents { get; private set; }
    }

    public class HalfPriceTicket : IStampable
    {
        public HalfPriceTicket(int priceInCents)
        {
            this.PriceInCents = priceInCents;
        }

        public void Stamp()
        {
            //logic
            IsStamped = true;
        }

        public bool IsStamped
        {
            get;
            private set;
        }

        public int PriceInCents { get; private set; }

    }

    public interface IStampable
    {
        void Stamp();
        bool IsStamped { get; }
        int PriceInCents { get; }
    }

    public class GdanskTicketFactory : ITicketFactory
    {
        public IStampable createTicket(string ticketType)
        {
            switch (ticketType)
            {
                case "Normal": return new NormalTicket(360);
                case "HalfPrice": return new HalfPriceTicket(180);
                default: throw new ApplicationException(); //exception that inherits from application exception
                //may be also null object
            }
        }

        public string[] AvailableTicketNames
        {
            get { return new string[] { "Normal", "HalfPrice" }; }
        }
    }

    public class WarsawTicketFactory : ITicketFactory
    {
        public IStampable createTicket(string ticketType)
        {
            switch (ticketType)
            {
                case "Normal": return new NormalTicket(500);
                case "HalfPrice": return new HalfPriceTicket(250);
                default: throw new ApplicationException(); //exception that inherits from application exception
                //may be also null object
            }
        }

        public string[] AvailableTicketNames
        {
            get { return new string[] { "Normal", "HalfPrice" }; }
        }
    }

    public interface ITicketFactory
    {
        IStampable createTicket(string ticketType);
        string[] AvailableTicketNames { get; }
    }

    public class TicketDistributor
    {
        private ITicketFactory ticketFactory;

        public TicketDistributor(ITicketFactory ticketFactory)
        {
            this.ticketFactory = ticketFactory;
        }
    }
}
