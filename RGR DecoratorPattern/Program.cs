using System;

public interface INotifier
{
    void Send();
}

public class EmailNotifier : INotifier
{
    public void Send()
    {
        Console.WriteLine("Надiслано email-повiдомлення.");
    }
}

public abstract class NotifierDecorator : INotifier
{
    protected INotifier wrappee;

    public NotifierDecorator(INotifier notifier)
    {
        wrappee = notifier;
    }

    public virtual void Send()
    {
        wrappee.Send();
    }
}

public class SMSNotifier : NotifierDecorator
{
    public SMSNotifier(INotifier notifier) : base(notifier) { }

    public override void Send()
    {
        base.Send();
        Console.WriteLine("Надiслано SMS.");
    }
}

class Program
{
    static void Main()
    {
        INotifier notifier = new SMSNotifier(new EmailNotifier());
        notifier.Send();
    }
}
