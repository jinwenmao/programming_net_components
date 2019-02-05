// © 2005 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.Windows.Forms;
using System.Diagnostics;

public class NumberArg : EventArgs
{
	public readonly int Args;	
   
   public NumberArg(int number)
	{
		Args = number;
	}

}
[Flags]
public enum EventType
{
	OnEvent1,
	OnEvent2,
	OnEvent3,
	OnAllEvents = OnEvent1|OnEvent2|OnEvent3
}
public interface IMyEvents
{
	void OnEvent1(object sender,EventArgs eventArgs);
	void OnEvent2(object sender,EventArgs eventArgs);
	void OnEvent3(object sender,EventArgs eventArgs);
}
public class MyPublisher
{
   EventHandler m_Event1 = delegate{};
   EventHandler m_Event2 = delegate{};
   EventHandler m_Event3 = delegate{};

	public void Subscribe(IMyEvents subscriber,EventType eventType)
	{
		Debug.Assert(subscriber != null);
		if((eventType & EventType.OnEvent1) == EventType.OnEvent1)
		{
			m_Event1 += subscriber.OnEvent1;                        
		}
		if((eventType & EventType.OnEvent2) == EventType.OnEvent2)
		{
			m_Event2 += subscriber.OnEvent2;                        
		}
		if((eventType & EventType.OnEvent3) == EventType.OnEvent3)
		{
			m_Event3 += subscriber.OnEvent3;                        
		}
	}
	public void Unsubscribe(IMyEvents subscriber,EventType eventType)
	{
		Debug.Assert(subscriber != null);
		if((eventType & EventType.OnEvent1) == EventType.OnEvent1)
		{
			m_Event1 -= subscriber.OnEvent1;                        
		}
		if((eventType & EventType.OnEvent2) == EventType.OnEvent2)
		{
			m_Event2 -= subscriber.OnEvent2;                        
		}
		if((eventType & EventType.OnEvent3) == EventType.OnEvent3)
		{
			m_Event3 -= subscriber.OnEvent3;                        
		}
	}
	public void FireEvent(EventType eventType)
	{
		if((eventType & EventType.OnEvent1) == EventType.OnEvent1)
		{
			m_Event1(this,EventArgs.Empty);                        
		}
      if((eventType & EventType.OnEvent2) == EventType.OnEvent2)
      {
         m_Event2(this,EventArgs.Empty);                        
      }
      if((eventType & EventType.OnEvent3) == EventType.OnEvent3)
      {
         m_Event2(this,EventArgs.Empty);                        
      }
	}

	public void SomeMethod(int number)
	{
		if(m_Event1 != null)
		{
			EventArgs eventArgs = new NumberArg(number);
			m_Event1(this,eventArgs);
		}
      if(m_Event2 != null)
      {
         EventArgs eventArgs = new NumberArg(number);
         m_Event2(this,eventArgs);
      }
      if(m_Event3 != null)
      {
         EventArgs eventArgs = new NumberArg(number);
         m_Event3(this,eventArgs);
      }
   }
}

public class MySubscriber : IMyEvents
{
	public void OnEvent1(object sender,EventArgs eventArgs)
	{
		int number = ((NumberArg)eventArgs).Args;
		MessageBox.Show("The new number is "+ number,"OnEvent1");
	}
	public void OnEvent2(object sender,EventArgs eventArgs)
	{
		int number = ((NumberArg)eventArgs).Args;
		MessageBox.Show("The new number is "+ number,"OnEvent2");
	}
	public void OnEvent3(object sender,EventArgs eventArgs)
	{
		int number = ((NumberArg)eventArgs).Args;
		MessageBox.Show("The new number is "+ number,"OnEvent3");
	}
}
