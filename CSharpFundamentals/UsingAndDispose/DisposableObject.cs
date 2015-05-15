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

namespace CSharpFundamentals.UsingAndDispose
{
    public class DisposableObject : IDisposable
    {
        public virtual void Dispose()
        {
            //free manually unmanaged resources
            System.Diagnostics.Trace.WriteLine("DisposeBase called");
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            System.Diagnostics.Trace.WriteLine("DestructorBase called when garbage collector is run - without using");
            Dispose();
        }
    }

    public class DisposableObjectTest : DisposableObject
    {
        public static string commandsExecution;

        public override void Dispose()
        {
            System.Diagnostics.Trace.WriteLine("Dispose called");
            commandsExecution += "Dispose";
            GC.SuppressFinalize(this);
        }

        ~DisposableObjectTest()
        {
            System.Diagnostics.Trace.WriteLine("Destructor called when garbage collector is run - without using");
        }
    }

}
