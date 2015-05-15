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
using System.Text;
using System.Threading.Tasks;

namespace Using
{
    public class DisposeExample
    {
        private int objectState = 0;
        public int ObjectState { get { return objectState; } set { objectState = value; } }

        internal int whenThrowingInTry_thenCodeAfterFinallyIsReachable()
        {
            var number = 0;
            try
            {
                number = 1;
                throw new Exception();
            }
            catch
            {
                number = 1;
            }
            finally
            {
                number = 2;
            }
            number = 3;
            return number;
        }

        internal object whenReturningInCatch_thenCodeAfterFinallyIsUnreachable()
        {
            var number = 0;
            try
            {
                number = 1;
                throw new Exception();
            }
            catch
            {
                return number;
            }
            finally
            {
                number = 2;
                ObjectState = 1;
            }
            number = 3;
            return number;
        }

        internal object whenThrowInCatch_thenCodeAfterFinallyIsUnreachable()
        {
            var number = 0;
            try
            {
                number = 1;
                throw new Exception();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                number = 2;
                ObjectState = 1;
            }
            number = 3;
            return number;
        }
    }
}
