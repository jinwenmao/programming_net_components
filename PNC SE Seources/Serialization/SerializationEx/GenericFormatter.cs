// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationEx
{
   public class GenericFormatter<F> : IGenericFormatter where F : IFormatter,new()
   {
      IFormatter m_Formatter = new F();

      public T Deserialize<T>(Stream serializationStream)
      {
         return (T)m_Formatter.Deserialize(serializationStream); 
      }
      public void Serialize<T>(Stream serializationStream,T graph)
      {
         m_Formatter.Serialize(serializationStream,graph); 
      }
   }
}