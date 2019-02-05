// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using ContextLogger;

namespace LogbookDemo
{
   [Logbook]
	public class TestClass : ContextBoundObject
	{
      public event EventHandler SomeEvent = delegate{};
      public TestClass()
      {
         m_SomeField = 0;   
      }
      public void SomeMethod()
      {
      }
      public void LogEvent()
      {
         Logbook.AddEvent("Some event took place");
      }
      public void SomeMethodWithError()
      {
         throw new ArgumentException("Some error message");
      }
      public int m_MyMember;
      public int SomeProperty
      {
         set
         {
            m_SomeField = value;
         }
         get
         {
            return m_SomeField;
         }
      }
      public int m_SomeField;

      public int this[int index]
      {
         get
         {
            return 0;
         }
         set
         {
         }
      }
   }
}
