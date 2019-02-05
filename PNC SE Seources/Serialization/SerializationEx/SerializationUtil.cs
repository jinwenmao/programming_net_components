// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializationEx
{
   public static class SerializationUtil
   {
      public static void SerializeBaseType(object obj,SerializationInfo info,StreamingContext context)
      {

         Type baseType = obj.GetType().BaseType;
         SerializeBaseType(obj,baseType,info,context);
      }
      public static void SerializeBaseType(object obj,bool serializeSelf,SerializationInfo info,StreamingContext context) 
      {
         Type type;//Type to serialize 
         if(serializeSelf == false)
         {
            type = obj.GetType().BaseType;
         }
         else 
         {
            type = obj.GetType();
         }
         SerializeBaseType(obj,type,info,context);
      }
      static void SerializeBaseType(object obj,Type type,SerializationInfo info,StreamingContext context)
      {
         if(type == typeof(object))
         {
            return;
         }
         BindingFlags flags = BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.NonPublic|BindingFlags.Public;
         FieldInfo[] fields = type.GetFields(flags);
         foreach(FieldInfo field in fields)
         {
            if(field.IsNotSerialized)
            {
               continue;
            }
            string fieldName = type.Name + "+" + field.Name;
            info.AddValue(fieldName,field.GetValue(obj));
         }
         SerializeBaseType(obj,type.BaseType,info,context);
      }
      public static void DeserializeBaseType(object obj,SerializationInfo info,StreamingContext context) 
      {
         Type baseType = obj.GetType().BaseType;
         DeserializeBaseType(obj,baseType,info,context);
      }      
      public static void DeserializeBaseType(object obj,bool deserializeSelf,SerializationInfo info,StreamingContext context) 
      {
         Type type;//Type to serialize 
         if(deserializeSelf == false)
         {
            type = obj.GetType().BaseType;
         }
         else 
         {
            type = obj.GetType();
         }
         DeserializeBaseType(obj,type,info,context);
      }      
      static void DeserializeBaseType(object obj,Type type,SerializationInfo info,StreamingContext context)
      {
         if(type == typeof(object))
         {
            return;
         }
         BindingFlags flags = BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.NonPublic|BindingFlags.Public;   
         FieldInfo[] fields = type.GetFields(flags);
         foreach(FieldInfo field in fields)
         {
            if(field.IsNotSerialized)
            {
               continue;
            }
            string fieldName = type.Name + "+" + field.Name;
            object fieldValue = info.GetValue(fieldName,field.FieldType);
            field.SetValue(obj,fieldValue);
         }
         DeserializeBaseType(obj,type.BaseType,info,context);
      }
      static public Version GetVersion(SerializationInfo info)
      {
         string assemblyName = info.AssemblyName;
         //	assemblyName is in the form of "MyAssembly, Version=1.2.3.4,Culture=neutral, PublicKeyToken=null"	
         char[] separators  = {',','='};
         string[] nameParts = assemblyName.Split(separators);
         return new Version(nameParts[2]);
      }
      static public T Clone<T>(T source)
      {
         Debug.Assert(typeof(T).IsSerializable);
         IGenericFormatter formatter = new GenericBinaryFormatter(); 
         Stream stream = new MemoryStream(); 
         using(stream)         
         {
            formatter.Serialize(stream,source);
            stream.Seek(0,SeekOrigin.Begin);
            T clone = formatter.Deserialize<T>(stream);
            return clone;
         }
      }
      public static int OptionalMemebrVersion(Type type,string member)
      {
         Debug.Assert(type.IsSerializable);
         MemberInfo[] members = type.GetMember(member,BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.DeclaredOnly);

         Debug.Assert(members.Length == 1);
         object[] attributes = members[0].GetCustomAttributes(typeof(OptionalFieldAttribute),false);
         Debug.Assert(attributes.Length == 1);

         OptionalFieldAttribute attribute = attributes[0] as OptionalFieldAttribute;

         Debug.Assert(attribute != null);
         return attribute.VersionAdded;
      }
      public static void ConstrainType(Type type)
      {
         bool serializable = type.IsSerializable;
         if(serializable == false)
         {
            string message = "The type " + type + " is not serializable";
            throw new SerializationException(message);
         }
         bool genericType = type.IsGenericType;
         if(genericType)
         {
            Type[] typeArguments = type.GetGenericArguments();
            Debug.Assert(typeArguments.Length >= 1);
            
            Array.ForEach(typeArguments,ConstrainType);
         }
      }
   }
}