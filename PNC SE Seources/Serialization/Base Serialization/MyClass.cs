// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using SerializationEx;

namespace Serialization
{
   public class MyBaseClass
   {
      public int m_PublicNum;
      int m_PrivateNum;
      public int Num
      {
         get
         {
            return m_PrivateNum;
         }
         set
         {
            m_PrivateNum = value;
         }
      }
   }
   [Serializable]
   public class MyClass : MyBaseClass,ISerializable
   {
      public MyClass(){}
      public void GetObjectData(SerializationInfo info,StreamingContext context)
      {
         SerializationUtil.SerializeBaseType(this,info,context);
      }
      protected MyClass(SerializationInfo info,StreamingContext context)
      {
         SerializationUtil.DeserializeBaseType(this,info,context);
      }
   }
}
