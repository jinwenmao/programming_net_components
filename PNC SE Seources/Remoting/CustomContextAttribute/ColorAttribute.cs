// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

/****************************************************
The ColorAttribute class is a good staring point when developing custom context 
attributes in .NET
Use the ColorAttribute to add a color property to an object execution context.

Usage:
~~~~~~

using ContextAttributeDemo;

[Color(ColorAttribute.ColorOption.Blue)]
public class A :ContextBoundObject 
{}

[Color]//Default is Red
public class B :ContextBoundObject 
{}

****************************************************/
using System;
using System.Runtime.Remoting.Contexts;	
using System.Runtime.Remoting.Activation;

namespace ContextAttributeDemo
{

	/// <summary>
	/// Color option to add to a context
	/// </summary>
	public enum ColorOption {Red,Green,Blue}

	/// <summary>
	///   The ColorProperty is added to the context properties collection by the 
	//    ColorAttribute class
	/// </summary>
	public class ColorProperty : IContextProperty
	{
		protected ColorOption m_Color;

		public ColorProperty(ColorOption ContextColor) 
		{   
			Color = ContextColor;
		}
		public String Name
		{
			get 
			{
				return "Color";
			}
		}
		/// <summary>
		/// IsNewContextOK called by the runtime in the new context
		/// </summary>
		public bool IsNewContextOK(Context ctx)
		{
			ColorProperty newContextColorProperty = null;
			//Find out if the new context has a color property. If not, reject it
			newContextColorProperty = ctx.GetProperty("Color") as ColorProperty;
			if(newContextColorProperty == null)
			{
				return false;
			}
			//It does have color property. Verify color match
			bool contextOK = (this.Color == newContextColorProperty.Color);
			return contextOK;
		}

		public void Freeze(Context ctx)
		{
			//Calling ctx.Freeze() prevents adding new properties of any kind.
			//We have no objection for new properties 
			return;
		} 
		/// <summary>
		///   Public property storing the color. Needs to be public so that the 
		//    attribute class can access it
		/// </summary>
		public ColorOption Color
		{
			get 
			{ 
				return m_Color; 
			}
			set
			{
				m_Color = value;
			}
		}
	}

	/// <summary>
	/// Use the ColorAttribute to add a color property to an object execution context.
	/// The object has to derive from ContextBoundObject
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class ColorAttribute : ContextAttribute
	{
		public ColorAttribute():this(ColorOption.Red)//Default color is "Red"
		{}
      
		public ColorAttribute(ColorOption color):base("ColorAttribute")
		{
			this.Color = color;  
		}
		/// <summary>
		/// Add a new color property to the new context 
		/// </summary>
		public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
		{
			IContextProperty colorProperty = new ColorProperty(Color);
			ctor.ContextProperties.Add(colorProperty);
		}

		protected ColorOption m_Color;
		protected ColorOption Color
		{
			get 
			{ 
				return m_Color; 
			}
			set
			{
				m_Color = value;
			}
		}
		/// <summary>
		/// Called by the runtime in the creating client's context 
		/// </summary>
		public override bool IsContextOK(Context ctx,IConstructionCallMessage ctorMsg) 
		{ 
			ColorProperty contextColorProperty = null;
			//Find out if the creating context has a color property. If not, reject it
			contextColorProperty = ctx.GetProperty("Color") as ColorProperty;
			if(contextColorProperty == null)
			{
				return false;
			}
			//it does have a color property. Verify color match 
			bool contextOK = (this.Color == contextColorProperty.Color);
			return contextOK;
		}
	}
}