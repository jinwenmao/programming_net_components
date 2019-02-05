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
   public class GenericSerializationInfo
   {
      SerializationInfo m_SerializationInfo;
      public GenericSerializationInfo(SerializationInfo info)
      {
         m_SerializationInfo = info;
      }
      public void AddValue<T>(string name,T value)
      {
         m_SerializationInfo.AddValue(name,value,value.GetType());
      }
      public T GetValue<T>(string name)
      {
         object obj = m_SerializationInfo.GetValue(name,typeof(T));
         return (T)obj;
      }
   }
}