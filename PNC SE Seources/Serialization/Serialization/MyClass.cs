// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

namespace Serialization
{
   [Serializable]
   public class MyClass 
   {
      public string m_String;
      public int m_Int1;
      private int m_Int2;
      //[OptionalField]
      //int m_NewMemeber = 123;      
      
      public MyClass()
      {
         m_String = "My String";
         m_Int1 = 1;
         m_Int2 = 2;
         m_Int3 = 3;
      }
      public void SomeMethod()
      {
         Debug.Assert(m_Int1 == 1);
      }

      public int Int2
      {
         set
         {
            m_Int2 = value;
         }
         get
         {
            return m_Int2;
         }
      }
      [NonSerialized]
      public int m_Int3;

      [OnSerializing]
      void OnSerializing(StreamingContext context)
      {
         Trace.WriteLine("MyClass.OnSerializing");
      }

      [OnSerialized]
      void OnSerialized(StreamingContext context)
      {
         Trace.WriteLine("MyClass.OnSerialized");
      }

      [OnDeserializing]
      void OnDeserializing(StreamingContext context)
      {
         Trace.WriteLine("MyClass.OnDeserializing");
      }

      [OnDeserialized]
      void OnDeserialized(StreamingContext context)
      {
         Trace.WriteLine("MyClass.OnDeserialized");
      }
   }
}
