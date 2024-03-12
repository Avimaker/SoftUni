using System;

namespace LogForU.Core.Exceptions;

public class EmptyCreatedTimeException : Exception
{
    //дефолтен месидж за дефолтния конструктор
    private const string DefaultMessage =
        "Created time of message cannot be null or whitespace";

    // ползва се с този конструктор
    public EmptyCreatedTimeException()
        : base(DefaultMessage)
    {
    }

    // тук може да сложим наш месидж и той излиза с този конструктор вместо дефолтния
    public EmptyCreatedTimeException(string message)
        : base(message)
    {
    }
}