namespace Platform.Core.Exceptions;

public abstract class BaseException : Exception
{
    protected BaseException() { }

    protected BaseException(string? message) : base(message) { }

    public abstract string Message { get; }
}
