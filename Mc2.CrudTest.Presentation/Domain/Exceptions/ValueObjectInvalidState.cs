namespace Project1.Domain.Exceptions;

public class ValueObjectInvalidState : DomainException
{
    public ValueObjectInvalidState(string message) : base(message)
    {
    }
}