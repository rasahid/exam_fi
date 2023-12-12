using System;

// 1: Create a class to pass as an argument for the event handlers 
public class SimpleEventArgs : EventArgs
{
    public string Message { get; }

    public SimpleEventArgs(string message)
    {
        Message = message;
    }
}

// 2:Set up the delegate for the event
public delegate void SimpleEventHandler(object sender, SimpleEventArgs e);

//  3: Declare the code for the event
public class EventPublisher
{
    // Event 
    public event SimpleEventHandler SimpleEvent;

    // 4: Create code that will be run when the event occurs 
    protected virtual void OnSimpleEvent(string message)
    {
    
        SimpleEvent?.Invoke(this, new SimpleEventArgs(message));
    }

    // 5: Associate the event with the event handler
    public void TriggerEvent(string message)
    {
        Console.WriteLine("Event triggered!");
      
        OnSimpleEvent(message);
    }
}

 
public class EventHandler
{
    public void HandleEvent(object sender, SimpleEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}

class Program
{
    static void Main()
    {
        //  instances   classes
        EventPublisher eventPublisher = new EventPublisher();
        EventHandler eventHandler = new EventHandler();
         
        eventPublisher.SimpleEvent += eventHandler.HandleEvent;

        // Trigger the event  
        eventPublisher.TriggerEvent("Hello, omer!");

         
    }
}
