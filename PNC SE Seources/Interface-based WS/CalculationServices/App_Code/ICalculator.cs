// © 2001 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

namespace CalculationServices
{
   [WebServiceBinding(Name = "ICalculator")]
   public interface ICalculator 
   {
      [WebMethod(Description = "Adds two integers and returns the sum")]
      int Add(int num1,int num2);
 
	   [WebMethod(Description = "Subtracts two integers and returns the result")]
      int Subtract(int num1,int num2);
      
	   [WebMethod(Description = "Divides two integers and returns the result")]
      int Divide(int num1,int num2);
      
      [WebMethod(Description = "Multiplies two integers and returns the result")]
	   int Multiply(int num1,int num2);
   }  
}