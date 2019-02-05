// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationEx
{
   public interface IGenericFormatter
   {
      T Deserialize<T>(Stream serializationStream);
      void Serialize<T>(Stream serializationStream,T graph);
   } 
}
