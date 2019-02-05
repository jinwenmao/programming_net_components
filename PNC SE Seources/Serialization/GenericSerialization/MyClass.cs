// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using SerializationEx;

[Serializable]
public class MyClass<T> : ISerializable
{
   public T m_T;
   public string m_Name;
   public MyClass()
   {}
   public void GetObjectData(SerializationInfo info,StreamingContext context)
   {
      GenericSerializationInfo genericInfo = new GenericSerializationInfo(info);
      genericInfo.AddValue("m_T",m_T); //using type inference 
      genericInfo.AddValue("m_Name",m_Name); //using type inference 
   }
   protected MyClass(SerializationInfo info,StreamingContext context)
   {
      GenericSerializationInfo genericInfo = new GenericSerializationInfo(info);
      m_T = genericInfo.GetValue<T>("m_T");
      m_Name = genericInfo.GetValue<string>("m_Name");
   }
}
