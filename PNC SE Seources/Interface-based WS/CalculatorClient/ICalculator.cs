// © 2001 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Web.Services;

namespace WSInterfacesDemo
{
	public interface ICalculator
	{
		int Add(int num1,int num2);
		int Subtract(int num1,int num2);
		int Divide(int num1,int num2);
		int Multiply(int num1,int num2);
	}
	namespace localhost
	{
		public partial class SimpleCalculator : ICalculator
		{ }
	}
	namespace localhost1
	{
		public partial class ScientificCalculator : ICalculator
		{ }
	}
}


