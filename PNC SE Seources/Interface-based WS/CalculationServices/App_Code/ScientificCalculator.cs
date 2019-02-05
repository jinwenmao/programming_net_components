// © 2001 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

namespace CalculationServices
{
	[WebService(Namespace="http://CalculationServices.com",Description="The ScientificCalculator web service implements <a href=\"ICalculator.asmx\">ICalculator</a>. It provides the four basic arithmetic operations for integers.")]
	class ScientificCalculator : ICalculator
	{
		public int Add(int num1,int num2)
		{
			return num1 + num2;
		}
		public int Subtract(int num1,int num2)
		{
			return num1 - num2;
		}
		public int Divide(int num1,int num2)
		{
			return num1 / num2;
		}
		public int Multiply(int num1,int num2)
		{
			return num1 * num2;
		}
	}
}