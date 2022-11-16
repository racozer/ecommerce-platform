namespace Platform.Api.Core.BuildingBlocks.Exceptions;

public abstract class ProblemBaseException : Exception
{
    protected ProblemBaseException() { }

    protected ProblemBaseException(string? message) : base(message) { }

    public abstract string Message { get; }
}