// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting;

namespace ContextAttributeDemo
{
	public class A
	{
		public string TraceContext()
		{
			int contextID = Thread.CurrentContext.ContextID;
			return "A is context agile. Current context ID = " + contextID.ToString()+ System.Environment.NewLine;
		}
		public string CreateObjects()
		{
			string trace;
			B b = new B();
			trace = b.TraceContext();

			C c = new C();
			trace += c.TraceContext();
			return trace+ System.Environment.NewLine;
		}
	}
	public class B : ContextBoundObject
	{
		public string TraceContext()
		{
			int contextID = Thread.CurrentContext.ContextID;
			return "B is context bound, but has no context attribute. Should be in creator's context, context ID = " + contextID.ToString()+ System.Environment.NewLine;
		}
	}

	[Color]
	public class C : ContextBoundObject
	{
		public string TraceContext()
		{
			int contextID = Thread.CurrentContext.ContextID;
			return "C is context bound, with color Red. Context ID = " + contextID.ToString()+ System.Environment.NewLine;
		}
		public string CreateObjects()
		{
			string trace;
			D d = new D();
			trace = d.TraceContext();
         Debug.Assert(RemotingServices.IsTransparentProxy(d));

			E e = new E();
			trace += e.TraceContext();
			return trace + System.Environment.NewLine;
		}
		public string TraceA(A a)
		{
			return a.TraceContext();
		}
		public string TraceB(B b)
		{
			return b.TraceContext();
		}
		public string TraceD(D d)
		{
			return d.TraceContext();
		}
	}

	[Color(ColorOption.Red)]
	public class D : ContextBoundObject
	{
		public string TraceContext()
		{
			int contextID = Thread.CurrentContext.ContextID;
			return "D is context bound, with color Red. Context ID = " + contextID.ToString()+ System.Environment.NewLine;
		}
	}

	[Color(ColorOption.Green)]
	public class E : ContextBoundObject
	{
		public string TraceContext()
		{
			int contextID = Thread.CurrentContext.ContextID;
			return "E is context bound, with color Green. Context ID = " + contextID.ToString()+ System.Environment.NewLine;
		}
	}
}


