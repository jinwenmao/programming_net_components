// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializationEx
{
   public class GenericSoapFormatter : GenericFormatter<SoapFormatter>
   {}
}
