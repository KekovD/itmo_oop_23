﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class BuilderNullException : Exception
{
    public BuilderNullException()
        : base("Property is null.")
    {
    }

    public BuilderNullException(string message)
        : base(message)
    {
    }

    public BuilderNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}