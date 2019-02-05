// © 2001 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

namespace CalculationServices
{
	[WebService(Name="ICalculator",Namespace="http://CalculationServices",
	 Description="This web service is only the definition of the interface. You cannot invoke method calls on it.")]
	abstract class ICalculatorShim : ICalculator
	{
		public abstract int Add(int num1,int num2);
		public abstract int Subtract(int num1,int num2);
		public abstract int Divide(int num1,int num2);
		public abstract int Multiply(int num1,int num2);
	}
}